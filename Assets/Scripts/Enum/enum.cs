namespace EnumTypes
{
    public enum ItemType
    {
        Consumable,     // 소모품
        Equipable       // 장비
    }

    public enum ConsumableType
    {
        Instant,    // 즉시 발동
        Buff,       // 지속시간 포션
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

    public enum QuestType
    {
        Kill,
        Clear
    }
    public enum AttackType
    {
        Touch,
        Military,
        Ranged,
        Rush
    }
}