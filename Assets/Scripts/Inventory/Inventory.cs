using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Slot> Slots = new List<Slot>();

    private void Awake()
    {
        Slot[] slots = GetComponentsInChildren<Slot>();
        foreach (Slot slot in slots)
        {
            Slots.Add(slot);
        }
    }



    /// <summary>
    /// code∏¶ ≈Î«ÿ ΩΩ∑‘ø°º≠ æ∆¿Ã≈€¿ª πﬁæ∆ø»
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
    /// ∫Û ΩΩ∑‘ø° item¿ª √ﬂ∞°«‘, ∫Û ΩΩ∑‘¿Ã æ¯¥Ÿ∏È Debug
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
        Debug.Log("∫Û ƒ≠¿Ã æ¯Ω¿¥œ¥Ÿ.");
        return;
    }
}