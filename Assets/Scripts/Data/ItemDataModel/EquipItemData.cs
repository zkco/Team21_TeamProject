using EnumTypes;
using Unity.VisualScripting;

public class EquipItemData : ItemData
{
    public EquipType equipType;
    public float value;
    public int levelLimit;
    //public GameObject objectPrefab;       // 착용 시 외형 바뀔때
    //public List<EquipTarget> targets;     // 여러 스탯이 올라가야 할 때
    //public List<float> value;

    public EquipItemData(int id, ItemType type, string name, string description, string iconPath, EquipType equipType, float value, int levelLimit)
    {
        this.id = id;
        this.name = name;
        this.description = description;
        this.iconPath = iconPath;
        this.equipType = equipType;
        this.value = value;
        this.levelLimit = levelLimit;
    }
}