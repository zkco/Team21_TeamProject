using EnumTypes;
using System;

[Serializable]
public class QuestData : DataModel
{
    public string name;
    public string description;
    public QuestType type;      // ����Ʈ ��ǥ ����
    public int targetId;        // ����Ʈ ��ǥ Ÿ���� id
    public int number;          // ����Ʈ ��ǥ ����
    public int reward;          // ����Ʈ ����
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