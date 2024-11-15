public enum ItemType
{
    Consumable,
    Equip
}

public enum ConsumableType 
{ 
    Instant,
    Buff
}

public enum EquipType
{
    Weapon,
    Armor,
    Accessory
}

public class ItemData : DataModel
{
    public ItemType type;
    public string name;
    public string description;
    public string iconPath;
}
