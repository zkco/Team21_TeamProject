namespace EnumTypes
{
    public enum ItemType
    {
        Consumable, // �Ҹ�ǰ
        Equipable       // ���
    }

    public enum ConsumableType
    {
        Instant,    // �����
        Buff,       // ������
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