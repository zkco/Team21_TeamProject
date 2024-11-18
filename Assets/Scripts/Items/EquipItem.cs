using UnityEngine;
using EnumTypes;
using Unity.VisualScripting;
public class EquipItem : MonoBehaviour
{
    private EquipItemData data;

    [SerializeField] private PlayerStatus status;

    private void Start()
    {
        //status = Managers. .... 
    }

    public void Equip()
    {
        if(data.levelLimit > status.Lv)
        {
            Debug.Log("레벨이 낮아 착용할 수 없습니다.");
            return;
        }
        //if(status.equippedId[(int)data.equipType] != 0)
        //{
        //    var temp = DataManager.EquipDb.status.equippedId[(int)data.equipType];
        //}
        //status.equippedId[(int)data.equipType] = data.id;
        ChangeStatus(data.value);
    }

    public void Unequip()
    {
        //status.equippedId[(int)data.equipType] = 0;
        ChangeStatus(-data.value);
    }

    private void ChangeStatus(float value)
    {
        switch (data.equipType)
        {
            case EquipType.Weapon:
                status.AddValueTemp("damage", value);
                break;
            case EquipType.Armor:
                status.AddValueTemp("maxHP", value);
                break;
            case EquipType.Accessory:
                status.AddValueTemp("maxMP", value);
                break;
        }
    }
}