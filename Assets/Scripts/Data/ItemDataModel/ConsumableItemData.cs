using EnumTypes;
using System;
using System.Collections.Generic;
[Serializable]
public class ConsumableItemData 
{
    public ConsumableType consumableType;
    public List<TargetStat> targets;
    public float duration;
    public List<float> values;

    public ConsumableItemData()
        {
    }
}

