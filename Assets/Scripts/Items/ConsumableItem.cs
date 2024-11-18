using UnityEngine;
using EnumTypes;
using System.Collections;
public class ConsumableItem : MonoBehaviour
{
    private ConsumableItemData data;
    //private Condition condition;

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
                        //condition.heal(data.values[i]);
                        break;
                    case ConsumableTarget.MP:
                        //condition.mpheal(data.values[i]);
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

                        break;
                    case ConsumableTarget.MP:

                        break;
                    case ConsumableTarget.Damage:
                        StartCoroutine(UseBuffPotion(data, i));
                        break;
                }
            }
        }
    }

    IEnumerator UseBuffPotion(ConsumableItemData data, int index)
    {
        /* condition.buff       
         * 
         */
        yield return new WaitForSeconds(data.duration);
        //yield return StartCoroutine(OnBuffUI(, data.duration));
        //condition.            // 버프 전 상태로 돌아가기
    }

    //IEnumerator OnBuffUI(ConsumableTarget target, int duration)
    //{
    //    //switch(target)
    //    //{
    //    //  case ConsumableTarget.Damage:
    //    //      
    //    //}
    //    yield return new WaitForSeconds(duration);
    //}

}