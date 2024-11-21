using UnityEngine;
using EnumTypes;

public class Item : MonoBehaviour
{
    public ItemData ItemData;
    public bool isEquipped;

    public void SetData(ProductData productData)        // 아이템 데이터 저장
    {
        ItemData = DataManager.ItemDb.Get(productData.itemId);
    }

    public void Use()
    {
        if (ItemData.consumableType == ConsumableType.Instant)       // 즉발형일때
        {
            for (int i = 0; i < ItemData.targets.Count; i++)
            {
                Managers.PlayerManager.Player.Status.AddValueTemp(ItemData.targets[i].ToString().ToLower(), ItemData.values[i]);
            }
        }
        else if (ItemData.consumableType == ConsumableType.Buff)  // 버프형일때
        {
            for (int i = 0; i < ItemData.targets.Count; i++)
            {
                Managers.PlayerManager.Player.Status.AddBuff(ItemData.targets[i].ToString().ToLower(), ItemData.values[i], 10f);
            }
        }
        else return;
    }
    public void Equip()             // 장비 아이템 착용
    {
        if (ItemData.levelLimit > Managers.PlayerManager.Player.Status.Lv)
        {
            Debug.Log("레벨이 낮아 착용할 수 없습니다.");
            return;
        }
        foreach (Item item in Managers.PlayerManager.Player.Status.EquippedItem)
        {
            if (item.ItemData.equipType == this.ItemData.equipType)
            {
                Unequip(item);
            }
        }
        isEquipped = true;
        Managers.PlayerManager.Player.Status.EquippedItem.Add(this);
        Managers.PlayerManager.Player.Status.AddEquippedItemValue();
    }
    public void Unequip(Item isequippedItem)           // 장비 아이템 해제
    {
        foreach (Item item in Managers.PlayerManager.Player.Status.EquippedItem)
        {
            if (item == isequippedItem)
            {
                isEquipped = false;
                Managers.PlayerManager.Player.Status.EquippedItem.Remove(item);
                Managers.PlayerManager.Player.Status.AddEquippedItemValue();
            }
        }
    }
}
