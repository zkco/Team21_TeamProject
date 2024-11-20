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
    private StringBuilder sN = new StringBuilder();
    private StringBuilder sV = new StringBuilder();
    public int CurCode;

    private void Start()
    {
        Inventory = Managers.PlayerManager.Player.Inventory;
    }

    public void ChangeUIInfo()
    {
        sN.Clear();
        sV.Clear();
        if (Inventory.GetItem(CurCode) != null)
        {
            Slot slot = Inventory.GetSlot(CurCode);
            Item item = slot.GetItem(CurCode);
            Icon = slot.itemImage;
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
        else return;
        return;
    }
}