using System;
using UnityEngine;
using UnityEngine.UI;

public class UIShopSlot : MonoBehaviour
{
    [SerializeField] private Image imgIcon;
    [SerializeField] private Image outline;
    [SerializeField] private Button buttonSlot;
    
    public Action<int> OnClickAction;
    private ProductData data;

    private void Start()
    {
        outline.enabled = false;
        buttonSlot.onClick.AddListener(Click);
    }

    public void SetData(ProductData product)
    {
        data = product;
        var item = DataManager.ItemDb.Get(product.itemId);
        imgIcon.sprite = Resources.Load<Sprite>(item.iconPath);

    }
    public void Click()
    {
        OnClickAction?.Invoke(data.id);
        ToggleOutline();
    }

    public void ToggleOutline()
    {
        outline.enabled = !outline.enabled;
    }
}