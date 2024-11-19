using System;
using UnityEngine;
using UnityEngine.UI;

public class UIItemSlot : MonoBehaviour
{
    [SerializeField] private Image imgIcon;
    [SerializeField] private Outline outline;
    [SerializeField] private Button buttonSlot;
    
    public Action<int> OnClickAction;
    private ProductData data;
    private void Start()
    {
        buttonSlot.onClick.AddListener(Click);
    }

    public void SetData(ProductData product)
    {
        data = product;
        if (product.itemId < 2000) {
            var item = DataManager.ConsumableDb.Get(product.itemId);
            imgIcon.sprite = Resources.Load<Sprite>(item.iconPath);

        }
        else 
        {
            var item = DataManager.EquipDb.Get(product.itemId);
            imgIcon.sprite = Resources.Load<Sprite>(item.iconPath);
        }
    }
    private void Click()
    {
        OnClickAction?.Invoke(data.id);
    }
}