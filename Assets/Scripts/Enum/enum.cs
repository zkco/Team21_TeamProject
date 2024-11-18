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
        Buff        // ������
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