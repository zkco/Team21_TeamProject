using UnityEngine;

public class SlotButton : MonoBehaviour
{
    private Slot slot;

    private void Awake()
    {
        slot = GetComponent<Slot>();
    }

    public void GetItemData()
    {
        slot.GetItem(slot.code);
    }
}