using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Constants;
public class UIShop : BasePopup
{
    [SerializeField] private TMP_Text txtTitle;
    [Header("Item Slots")]
    [SerializeField] private Transform slotRoot;
    [SerializeField] private UIShopSlot uiItemSlot;
    [Header("infoBG")]
    [SerializeField] private TMP_Text txtItemName;
    [SerializeField] private TMP_Text txtItemDescription;
    [SerializeField] private TMP_Text txtStatName;
    [SerializeField] private TMP_Text txtStatValue;
    [SerializeField] private TMP_Text txtPrice;
    [SerializeField] private Button buyButton;

    private List<UIShopSlot> slotList = new List<UIShopSlot>();
    private Stack<UIShopSlot> slotPool = new Stack<UIShopSlot>();

    private int selectItemIndex;
    private string slotPath = "Prefabs/UI/UI/Slot";

    private void Start()
    {
        uiItemSlot = Resources.Load<GameObject>(slotPath).GetComponent<UIShopSlot>();
        SetShop(ShopCode.EquipShopId);
    }

    public void SetShop(int shopId)     // ���� �̸� ǥ��,  ���� ���� �߰�
    {
        ShopData shopData = DataManager.ShopDb.Get(shopId);

        txtTitle.text = shopData.name;

        var productList = shopData.productList;
        foreach (var productId in productList)
        {
            var product = DataManager.ProductDb.Get(productId);

            UIShopSlot slot;

            if (slotPool.Count == 0)
                slot = Instantiate(uiItemSlot, slotRoot);
            else
                slot = slotPool.Pop();

            slot.SetData(product);
            //slot.SetClickListener((id) => { ShopManager.Instance.BuyItem(id); });

            slot.gameObject.SetActive(true);
            slot.transform.SetAsLastSibling();

            slot.OnClickAction += SetText;
            slotList.Add(slot);
        }
        
    }

    public void SetText(int productId)      // ���� ���� ���� �� �� ������ ���� �ؽ�Ʈ ǥ��
    {
        int itemId = DataManager.ProductDb.Get(productId).itemId;
        ItemData data = DataManager.ItemDb.Get(itemId);
        txtItemName.text = data.name;
        txtItemDescription.text = data.description;
        txtPrice.text = DataManager.ProductDb.Get(productId).price.ToString() + " G";
        txtStatName.text = string.Empty;
        txtStatValue.text = string.Empty;
        for (int i = 0; i < data.targets.Count; i++)
        {
            txtStatName.text += data.targets[i].ToString() + "\n";
            txtStatValue.text += data.values[i].ToString() + "\n";
        }
        
    }

    public void BuyItem(int productId)      // ���� ��ư ���� �� ����
    {
        int price = DataManager.ProductDb.Get(productId).price;
        if (Managers.PlayerManager.Player.Status.Gold < price)
            return;

        Managers.PlayerManager.Player.Status.Gold -= price;


        ProductData data = DataManager.ProductDb.Get(productId);        // �÷��̾� ���� �����ۿ� ItemData ������ Item instance �߰�
        Item itemInstance = new Item();
        itemInstance.SetData(data);
        Managers.PlayerManager.Player.Inventory.SetItem(itemInstance);
        Managers.SoundManager.PlaySFX(SFXType.buyShop);
    }
}