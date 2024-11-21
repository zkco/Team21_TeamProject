using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
    public Queue<Slot> Slots = new Queue<Slot>();

    private void Awake()
    {
        if (Managers.PlayerManager.Player.Inventory == null)
            Managers.PlayerManager.Player.Inventory = this;
    }

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

        SetItem(Resources.Load<GameObject>("Prefabs/Item/TestItem").GetComponent<Item>());
    }

    /// <summary>
    /// code∏¶ ≈Î«ÿ ΩΩ∑‘ø°º≠ æ∆¿Ã≈€¿ª πﬁæ∆ø»
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    public Item GetItem(int code)
    {
        foreach(var slot in Slots)
        {
            if(slot.code == code)
            return slot.GetItem(code);
        }
        return null;
    }

    public Slot GetSlot(int code)
    {
        foreach (var slot in Slots)
        {
            if (slot.code == code)
                return slot;
        }
        return null;
    }

    /// <summary>
    /// ∫Û ΩΩ∑‘ø° item¿ª √ﬂ∞°«‘, ∫Û ΩΩ∑‘¿Ã æ¯¥Ÿ∏È Debug
    /// </summary>
    /// <param name="item"></param>
    public void SetItem(Item item)
    {
        foreach (var slot in Slots)
        {
            if(slot.item == null)
            {
                slot.SetItem(item);
                RegenIcon();
                return;
            }
        }
        Debug.Log("∫Û ƒ≠¿Ã æ¯Ω¿¥œ¥Ÿ.");
        return;
    }

    public void RemoveItem(int code)
    {
        foreach (var slot in Slots)
        {
            if (slot.code == code)
            {
                slot.RemoveItem();
                RegenIcon();
                return;
            }
        }
    }

    public void RegenIcon()
    {
        foreach(var slot in Slots)
        {
            slot.Regen();
        }
    }
}