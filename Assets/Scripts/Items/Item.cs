using UnityEngine;
using EnumTypes;

public abstract class Item : MonoBehaviour
{
    public ItemData ItemData;
    private Player player;

    private void Start()
    {
        player = Managers.PlayerManager.Player;
    }

    public void SetData(ProductData productData)        // 아이템 데이터 저장
    {
        ItemData = DataManager.ItemDb.Get(productData.itemId);
    }

    public void Use()
    {
        if (ItemData.consumableType == ConsumableType.Instant)       // 즉발형일때
        {
            for (int i = 0; i < ItemData.targets.Count; i++)
            {
                ChangeStatus(ItemData.targets[i], ItemData.values[i]);
            }
        }

        else    // if (data.consumableType == ConsumableType.Buff)  // 버프형일때
        {
            for (int i = 0; i < ItemData.targets.Count; i++)
            {
                ChangeStatusDuration(ItemData.targets[i], ItemData.values[i]);
            }
        }
    }
    public void Equip()             // 장비 아이템 착용
    {
        if (ItemData.levelLimit > player.Status.Lv)
        {
            Debug.Log("레벨이 낮아 착용할 수 없습니다.");
            return;
        }
        //if(status.equippedId[(int)data.equipType] != 0)           // 다른 아이템 착용중일 때 해제
        //{
        //    var temp = DataManager.EquipDb.status.equippedId[(int)data.equipType];
        //}
        //status.equippedId[(int)data.equipType] = data.id;

        for (int i = 0; i < ItemData.targets.Count; i++)
        {
            ChangeStatus(ItemData.targets[i], ItemData.values[i]);
        }
    }
    public void Unequip()           // 장비 아이템 해제
    {
        //status.equippedId[(int)data.equipType] = 0;               // 플레이어가 저장중인 착용 아이템 참조값 해제

        for (int i = 0; i < ItemData.targets.Count; i++)
        {
            ChangeStatus(ItemData.targets[i], -ItemData.values[i]);
        }
    }




    private void ChangeStatus(TargetStat target, float value)      // 스탯 변경
    {
        switch (target)
        {
            case TargetStat.HP:
                player.Status.AddValueTemp("hp", value);
                break;
            case TargetStat.MP:
                player.Status.AddValueTemp("mp", value);
                break;
            case TargetStat.Damage:
                player.Status.AddValueTemp("damage", value);
                break;
            case TargetStat.MaxHP:
                player.Status.AddValueTemp("MaxHP", value);
                break;
            case TargetStat.MaxMP:
                player.Status.AddValueTemp("MaxMP", value);
                break;
            default:
                break;
        }
    }

    private void ChangeStatusDuration(TargetStat target, float value)      // 지속시간동안 스탯 변경
    {
        switch (target)
        {
            case TargetStat.HP:
                player.Status.AddBuff("hp", value, ItemData.duration);
                break;
            case TargetStat.MP:
                player.Status.AddBuff("mp", value, ItemData.duration);
                break;
            case TargetStat.Damage:
                player.Status.AddBuff("damage", value, ItemData.duration);
                break;
            case TargetStat.MaxHP:
                player.Status.AddBuff("maxHP", value, ItemData.duration);
                break;
            case TargetStat.MaxMP:
                player.Status.AddBuff("maxMP", value, ItemData.duration);
                break;
            default:
                break;
        }
    }
}
