using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
    public List<Slot> Slots = new List<Slot>();

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
            Slots.Add(slot);
            slot.code = i;
            i++;
        }

        LoadInventoryData(Managers.PlayerManager.InventoryData);
        ProductData data = DataManager.ProductDb.Get(3001);
        Item ItemInstance = new Item();
        ItemInstance.SetData(data);
        SetItem(ItemInstance);
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
            SaveInventoryData();
        }
    }

    public List<int> GetID()
    {
        var ids = new List<int>();
        foreach(Slot slot in Slots)
        {
            if(slot.item != null)
            ids.Add(slot.item.ItemData.id);
        }
        return ids;
    }

    private void SaveInventoryData()
    {
        Managers.PlayerManager.InventoryData = GetID();
    }

    public void LoadInventoryData(List<int> ids)
    {
        foreach(Slot slot in Slots)
        {
            if(slot.item != null)
            slot.item = null;
        }
        for(int i = 0; i < ids.Count; i++)
        {
            Slots[i].item = new Item();
            Slots[i].item.ItemData = DataManager.ItemDb.Get(ids[i]);
        }
    }
}