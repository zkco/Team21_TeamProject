using UnityEngine;

public class SlotButton : MonoBehaviour
{
    [SerializeField] private Slot _slot;
    [SerializeField] private ItemInfo _itemInfo;

    private void Awake()
    {
        _itemInfo = GameObject.FindObjectOfType<ItemInfo>();
        _slot = GetComponentInParent<Slot>();
    }

    public void OnClick()
    {
        GetCode(_slot.code);
    }

    private void GetCode(int code)
    {
        _itemInfo.CurCode = _slot.code;
        _itemInfo.ChangeUIInfo();
    }

    private int GetInfoCode()
    {
        return _itemInfo.CurCode;
    }

    public void EquipItem()
    {
        Slot slot = Managers.PlayerManager.Player.Inventory.GetSlot(GetInfoCode());
        slot.EquipItem(GetInfoCode());
    }

    public void UnequipItem()
    {
        Slot slot = Managers.PlayerManager.Player.Inventory.GetSlot(GetInfoCode());
        slot.UnequipItem(GetInfoCode());
    }

    public void RemoveItem()
    {
        Slot slot = Managers.PlayerManager.Player.Inventory.GetSlot(GetInfoCode());
        slot.RemoveItem(_slot.code);
    }
    public void UseItem()
    {
        Slot slot = Managers.PlayerManager.Player.Inventory.GetSlot(GetInfoCode());
        slot.Use(GetInfoCode());
    }
}