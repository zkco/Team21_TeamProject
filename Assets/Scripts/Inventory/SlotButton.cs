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
}