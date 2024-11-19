using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UIShop : MonoBehaviour
{
    [SerializeField] private TMP_Text txtTitle;
    [Header("Item Slots")]
    [SerializeField] private Transform slotRoot;
    [SerializeField] private UIItemSlot uiItemSlot;
    [Header("infoBG")]
    [SerializeField] private TMP_Text txtItemName;
    [SerializeField] private TMP_Text txtItemDescription;
    [SerializeField] private TMP_Text txtStatName;
    [SerializeField] private TMP_Text txtStatValue;
    [SerializeField] private TMP_Text txtPrice;
    [SerializeField] private Button buyButton;

    private List<UIItemSlot> slotList = new List<UIItemSlot>();
    private Stack<UIItemSlot> slotPool = new Stack<UIItemSlot>();

    private int selectItemIndex;

    public void SetShop(int shopId)
    {
        ShopData shopData = DataManager.ShopDb.Get(shopId);

        txtTitle.text = shopData.shopName;

        var productList = shopData.productList;
        foreach (var productId in productList)
        {
            var product = DataManager.ProductDb.Get(productId);

            UIItemSlot slot;

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

    public void SetText(int productId)
    {
        int itemId = DataManager.ProductDb.Get(productId).itemId;
        ItemData data = DataManager.ItemDb.Get(itemId);
        txtItemName.text = data.name;
        txtItemDescription.text = data.description;
        txtPrice.text = DataManager.ProductDb.Get(productId).price.ToString();
        txtStatName.text = string.Empty;
        for (int i = 0; i < data.targets.Count; i++)
        {
            txtStatName.text += data.targets[i].ToString() + "\n";
            txtStatValue.text += data.values[i].ToString() + "\n";
        }
        
    }

    public void BuyItem(int productId)
    {
        int price = DataManager.ProductDb.Get(productId).price;
        if (Managers.PlayerManager.Player.Status.Gold < price)
            return;

        Managers.PlayerManager.Player.Status.Gold -= price;
        //
    }
}