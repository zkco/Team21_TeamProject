namespace EnumTypes
{
    public enum ItemType
    {
        Consumable, // �Ҹ�ǰ
        Equip       // ���
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
}