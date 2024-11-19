using UnityEngine;
using EnumTypes;
using System.Collections;
public class ConsumableItem : Item
{
    private ConsumableItemData data;

    protected override void Start()
    {
        
        status = Managers.PlayerManager.Player.Status;
    }

    public void SetData(int itemId)
    {
        data = DataManager.ConsumableDb.Get(itemId);
    }

    public void Use()       // �Ҹ�ǰ ����� �� ȣ���ϴ� �Լ�
    {
        if(data.consumableType == ConsumableType.Instant)       // ������϶�
        {
            for (int i = 0; i < data.targets.Count; i++)
            {
                switch (data.targets[i])
                {
                    case ConsumableTarget.HP:
                        player.Status.AddValueTemp("hp", data.values[i]);
                        break;
                    case ConsumableTarget.MP:
                        player.Status.AddValueTemp("mp", data.values[i]);
                        break;
                    default:
                        Debug.Log("It's not HP or MP Potion - OnUse, Instant");
                        break;
                }
            }
        }

        else    // if (data.consumableType == ConsumableType.Buff)  // �������϶�
        {
            for (int i = 0; i < data.targets.Count; i++)
            {
                switch (data.targets[i])
                {
                    case ConsumableTarget.HP:
                        player.Status.AddValueDur("hp", data.values[i], data.duration);
                        break;
                    case ConsumableTarget.MP:
                        player.Status.AddValueDur("mp", data.values[i], data.duration);
                        break;
                    case ConsumableTarget.Damage:
                        player.Status.AddValueDur("damage", data.values[i], data.duration);
                        break;
                    default:
                        Debug.Log("Error - ���ӽð� ����");
                        break;
                }
            }
        }
    }
}