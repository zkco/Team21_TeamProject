using UnityEngine;
using EnumTypes;
using Unity.VisualScripting;
public class EquipItem : MonoBehaviour
{
    private EquipItemData data;

    private Player player;

    private void Start()
    {
        player = Managers.PlayerManager.Player;
    }

    public void SetData(int itemId)
    {
        data = DataManager.EquipDb.Get(itemId);
    }
    public void Equip()             // 장비 아이템 착용
    {
        if(data.levelLimit > player.Status.Lv)
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

    public void Unequip()           // 장비 아이템 해제
    {
        //status.equippedId[(int)data.equipType] = 0;
        ChangeStatus(-data.value);
    }

    private void ChangeStatus(float value)      // 방어구 종류에 따라 스탯 변경
    {
        switch (data.equipType)
        {
            case EquipType.Weapon:
                player.Status.AddValueTemp("damage", value);
                break;
            case EquipType.Armor:
                player.Status.AddValueTemp("maxHP", value);
                break;
            case EquipType.Accessory:
                player.Status.AddValueTemp("maxMP", value);
                break;
        }
    }
}