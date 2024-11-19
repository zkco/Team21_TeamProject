using System;
using TMPro;
using Unity.VisualScripting;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfo : MonoBehaviour
{
    public Inventory Inventory;

    [SerializeField] private Image Icon;
    [SerializeField] private TextMeshProUGUI ItemName;
    [SerializeField] private TextMeshProUGUI ItemDescription;
    [SerializeField] private TextMeshProUGUI StatName;
    [SerializeField] private TextMeshProUGUI StatValue;

    public int CurCode;

    private void Start()
    {
        Inventory = Managers.PlayerManager.Player.Inventory;
    }

    public void ChangeUIInfo()
    {
        if (Inventory.GetItem(CurCode) != null)
        {
            Slot slot = Inventory.GetSlot(CurCode);
            Item item = slot.GetItem(CurCode);
            Icon = slot.itemImage;
            ItemName.text = item.ItemData.name;
            ItemDescription.text = item.ItemData.description;
            //ItemPrice.text = item.ItemData.price;
            if (item.ItemData.GetType() == typeof(ConsumableItemData))
            {
                //Todo : data 가져오기
            }
            else if (item.ItemData.GetType() == typeof(EquipItemData))
            {
                //Todo : data 가져오기
            }
            return;
        }
        else return;
    }
}