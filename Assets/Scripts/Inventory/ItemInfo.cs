using System;
using System.Text;
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
    [SerializeField] private GameObject UseButton;
    [SerializeField] private GameObject EquipButton;
    [SerializeField] private GameObject UnEquipButton;
    [SerializeField] private GameObject RemoveButton;
    private StringBuilder sN = new StringBuilder();
    private StringBuilder sV = new StringBuilder();
    public int CurCode;

    private void Start()
    {
        Inventory = Managers.PlayerManager.Player.Inventory;
    }

    public void ChangeUIInfo()
    {
        UseButton.SetActive(false);
        EquipButton.SetActive(false);
        UseButton.SetActive(false);
        RemoveButton.SetActive(false);
        sN.Clear();
        sV.Clear();
        if (Inventory.GetItem(CurCode) != null)
        {
            RemoveButton.SetActive(true);
            Slot slot = Inventory.GetSlot(CurCode);
            Item item = slot.GetItem(CurCode);
            Icon.sprite = slot.itemImage.sprite;
            ItemName.text = item.ItemData.name;
            ItemDescription.text = item.ItemData.description;
            //ItemPrice.text = item.ItemData.price;
            
            if (item.ItemData.type == EnumTypes.ItemType.Consumable)
            {
                switch(item.ItemData.consumableType)
                {
                    case EnumTypes.ConsumableType.Instant:
                        sN.Append("Instant \n");
                        sV.Append('\n');
                        break;
                    case EnumTypes.ConsumableType.Buff:
                        sN.Append("Buff \n");
                        sV.Append(item.ItemData.duration);
                        sV.Append(" s \n");
                        break;
                    default:
                        break;
                }
                UseButton.SetActive(true);
            }
            else if (item.ItemData.type == EnumTypes.ItemType.Equipable)
            {
                switch(item.ItemData.equipType)
                {
                    case EnumTypes.EquipType.Weapon:
                        sN.Append("EquipType \n");
                        sV.Append(item.ItemData.equipType.ToString());
                        sV.Append('\n');
                        break;
                    case EnumTypes.EquipType.Armor:
                        sN.Append("EquipType \n");
                        sV.Append(item.ItemData.equipType.ToString());
                        sV.Append('\n');
                        break;
                    case EnumTypes.EquipType.Accessory:
                        sN.Append("EquipType \n");
                        sV.Append(item.ItemData.equipType.ToString());
                        sV.Append('\n');
                        break;
                }
                sN.Append("Level Limit \n");
                sV.Append(item.ItemData.levelLimit.ToString());
                sV.Append('\n');
                if (item.isEquipped == true)
                {
                    UnEquipButton.SetActive(true);
                }
                else
                {
                    EquipButton.SetActive(true);
                }
            }
            foreach (EnumTypes.TargetStat target in item.ItemData.targets)
            {
                sN.Append(target.ToString());
                sN.Append('\n');
            }
            foreach (float value in item.ItemData.values)
            {
                sV.Append(value.ToString());
                sV.Append('\n');
            }
            StatName.text = sN.ToString();
            StatValue.text = sV.ToString();
        }
        else
        {
            Icon.sprite = null;
            ItemName.text = null;
            ItemDescription.text = null;
            StatName.text = null;
            StatValue.text = null;
            UseButton.SetActive(false);
            EquipButton.SetActive(false);
            UnEquipButton.SetActive(false);
            RemoveButton.SetActive(false);
        }
        return;
    }
}