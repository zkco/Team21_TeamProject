using EnumTypes;
using System.Collections.Generic;
public class ConsumableItemData : ItemData
{
    public ConsumableType consumableType;
    public List<ConsumableTarget> targets;
    public float duration;
    public List<float> values;

    public ConsumableItemData(int id, ItemType type, string name, string description, string iconPath, ConsumableType consumableType, List<ConsumableTarget> targets, float duration, List<float> values)
    {
        this.id = id;
        this.type = type;
        this.name = name;
        this.description = description;
        this.iconPath = iconPath;
        this.consumableType = consumableType;
        this.targets = targets;
        this.duration = duration;
        this.values = values;
    }
}

