using UnityEngine;
using EnumTypes;
using Unity.VisualScripting;
public class EquipItem : Item
{
    //private ItemData data;

    //protected override void Start()
    //{
    //    base.Start();
    //    base.ItemData = data;
    //}

    //public override void Use()
    //{
    //    Equip();
    //}

    //public void SetData(int itemId)
    //{
    //    data = DataManager.ItemDb.Get(itemId);
    //}
    //public void Equip()             // ��� ������ ����
    //{
    //    if(data.levelLimit > player.Status.Lv)
    //    {
    //        Debug.Log("������ ���� ������ �� �����ϴ�.");
    //        return;
    //    }
    //    //if(status.equippedId[(int)data.equipType] != 0)
    //    //{
    //    //    var temp = DataManager.EquipDb.status.equippedId[(int)data.equipType];
    //    //}
    //    //status.equippedId[(int)data.equipType] = data.id;
    //    ChangeStatus(data.value);
    //}

    //public void Unequip()           // ��� ������ ����
    //{
    //    //status.equippedId[(int)data.equipType] = 0;
    //    ChangeStatus(-data.value);
    //}

    //private void ChangeStatus(float value)      // �� ������ ���� ���� ����
    //{
    //    switch (data.equipType)
    //    {
    //        case EquipType.Weapon:
    //            player.Status.AddValueTemp("damage", value);
    //            break;
    //        case EquipType.Armor:
    //            player.Status.AddValueTemp("maxHP", value);
    //            break;
    //        case EquipType.Accessory:
    //            player.Status.AddValueTemp("maxMP", value);
    //            break;
    //    }
    //}
}