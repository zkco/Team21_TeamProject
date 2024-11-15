public class EquipItemData : ItemData
{
    public EquipType equipType;
    public float value;
    public int levelLimit;

    public EquipItemData(int id, ItemType type, string name, string description, string iconPath, EquipType equipType, float value, int levelLimit)
    {
        this.id = id;
        this.type = type;
        this.name = name;
        this.description = description;
        this.iconPath = iconPath;
        this.equipType = equipType;
        this.value = value;
        this.levelLimit = levelLimit;
    }

}