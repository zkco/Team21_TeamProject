using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Queue<Slot> Slots = new Queue<Slot>();

    private void Start()
    {
        Slot[] slots = GetComponentsInChildren<Slot>();
        int i = 0;
        foreach (Slot slot in slots)
        {
            Slots.Enqueue(slot);
            slot.code = i;
            i++;
        }
    }

    /// <summary>
    /// code�� ���� ���Կ��� �������� �޾ƿ�
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    public Item GetItem(int code)
    {
        foreach(var item in Slots)
        {
            if(item.code == code)
            return item.GetItem(code);
        }
        return null;
    }

    /// <summary>
    /// �� ���Կ� item�� �߰���, �� ������ ���ٸ� Debug
    /// </summary>
    /// <param name="item"></param>
    public void SetItem(Item item)
    {
        foreach (var slot in Slots)
        {
            if(slot.item == null)
            {
                slot.item = item;
                return;
            }
        }
        Debug.Log("�� ĭ�� �����ϴ�.");
        return;
    }
}