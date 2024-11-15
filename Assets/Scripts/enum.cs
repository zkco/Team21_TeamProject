namespace EnumTypes
{
    public enum ItemType
    {
        Consumable, // 소모품
        Equip       // 장비
    }

    public enum ConsumableType
    {
        Instant,    // 즉발형
        Buff        // 버프형
    }

    public enum EquipType
    {
        Weapon,
        Armor,
        Accessory
    }

    public enum ConsumableTarget
    {
        HP,
        MP,
        Damage /* ,
    something else
            */
    }
}