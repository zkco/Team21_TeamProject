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
        Buff,       // 버프형
        OTHER
    }

    public enum EquipType
    {
        Weapon,
        Armor,
        Accessory,
        OTHER
    }

    public enum TargetStat
    {
        HP,
        MP,
        Damage,
        MaxHP,
        MaxMP /* ,
    something else
            */
    }
}