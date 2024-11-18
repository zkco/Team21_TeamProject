using UnityEngine;
using EnumTypes;
using System.Collections;
public class ConsumableItem : MonoBehaviour
{
    private ConsumableItemData data;
    private PlayerStatus status;

    private void Start()
    {
        //condition = Managers.instance. ..... // 현재 플레이어의 HP,MP 등 상태창 받아옴
    }

    public void OnUse()
    {
        if(data.consumableType == ConsumableType.Instant)
        {
            for (int i = 0; i < data.targets.Count; i++)
            {
                switch (data.targets[i])
                {
                    case ConsumableTarget.HP:
                        status.AddValueTemp("hp", data.values[i]);
                        break;
                    case ConsumableTarget.MP:
                        status.AddValueTemp("mp", data.values[i]);
                        break;
                    default:
                        Debug.Log("It's not HP or MP Potion - OnUse, Instant");
                        break;
                }
            }
        }

        else    // if (data.consumableType == ConsumableType.Buff)
        {
            for (int i = 0; i < data.targets.Count; i++)
            {
                switch (data.targets[i])
                {
                    case ConsumableTarget.HP:
                        status.AddValueDur("hp", data.values[i], data.duration);
                        break;
                    case ConsumableTarget.MP:
                        status.AddValueDur("mp", data.values[i], data.duration);
                        break;
                    case ConsumableTarget.Damage:
                        status.AddValueDur("damage", data.values[i], data.duration);
                        break;
                    default:
                        Debug.Log("Error - 지속시간 물약");
                        break;
                }
            }
        }
    }

}