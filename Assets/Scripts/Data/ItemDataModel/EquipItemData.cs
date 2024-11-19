using EnumTypes;
using Unity.VisualScripting;

public class EquipItemData : ItemData
{
    public EquipType equipType;
    public float value;
    public int levelLimit;
    //public GameObject objectPrefab;       // ���� �� ���� �ٲ�
    //public List<EquipTarget> targets;     // ���� ������ �ö󰡾� �� ��
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