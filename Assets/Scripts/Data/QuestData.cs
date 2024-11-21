using EnumTypes;
using System;

[Serializable]
public class QuestData : DataModel
{
    public string name;
    public string description;
    public QuestType type;      // Äù½ºÆ® ¸ñÇ¥ Á¾·ù
    public int targetId;        // Äù½ºÆ® ¸ñÇ¥ Å¸°ÙÀÇ id
    public int number;          // Äù½ºÆ® ¸ñÇ¥ °¹¼ö
    public int reward;          // Äù½ºÆ® º¸»ó
    public int nextQuestId;
    public QuestData(int id, string name, string description, QuestType type, int targetId, int number, int reward, int nextQuestId)
    {
        this.id = id;
        this.name = name;
        this.description = description;
        this.type = type;
        this.targetId = targetId;
        this.number = number;
        this.reward = reward;
        this.nextQuestId = nextQuestId;
    }
}