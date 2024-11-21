using EnumTypes;
using System;
using System.Collections.Generic;

[Serializable]
public class ItemData : DataModel
{
    public ItemType type;
    public string name;
    public string description;
    public string iconPath;

    public ConsumableType consumableType;
    public List<TargetStat> targets;
    public float duration;
    public List<float> values;

    public EquipType equipType;
    public int levelLimit;

    public ItemData(int id, ItemType type, string name, string description, string iconPath, ConsumableType consumableType, List<TargetStat> targets, float duration, List<float> values, EquipType equipType, int levelLimit)
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

        this.equipType = equipType;
        this.levelLimit = levelLimit;
    }
}
