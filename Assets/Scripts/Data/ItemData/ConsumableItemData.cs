public class ConsumableItemData : ItemData
{
    public ConsumableType consumableType;
    public ConsumableTarget target;
    public float duration;
    public float value;

    public ConsumableItemData(int id, ItemType type, string name, string description, string iconPath, ConsumableType consumableType, ConsumableTarget target, float duration, float value)
    {
        this.id = id;
        this.type = type;
        this.name = name;
        this.description = description;
        this.iconPath = iconPath;
        this.consumableType = consumableType;
        this.target = target;
        this.duration = duration;
        this.value = value;
    }
}

public enum ConsumableTarget
{
    HP,
    MP,
    Damage /* ,
    something else
            */
}