using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestManager : MonoBehaviour, IManager
{
    private Dictionary<int, Quest> questDict = new Dictionary<int, Quest>();            // Quest Ÿ������ �����ϴ� dictionary
    public Quest curQuest;      // ���� �������� ����Ʈ
    public UIQuest uiQuest;

    public Quest GetQuest(int questId)          // ����Ʈ id�� ������ �� Data�� ���� Quest Ÿ�� ���� ��ȯ
    {
        if(questDict.ContainsKey(questId))
            return questDict[questId];
        return null;
    }

    public void UpdateQuestProgress(int questId, int amount)            // ����Ʈ ���� ��Ȳ ������Ʈ - ����Ʈ ���� ���϶��� ������Ʈ ��
    {
        Quest quest = GetQuest(questId);
        quest.UpdateProgress(amount);
    }
    private void QuestComplete()                // ����Ʈ �Ϸ�� ���� ����Ʈ �����Ŵ
    {
        curQuest = GetQuest(curQuest.data.nextQuestId);
        curQuest.StartQuest();
    }

    public void Init()
    {
        //uiQuest =                                     // TODO: ����Ʈ UI �Ҵ��ϱ�
        foreach (QuestData data in DataManager.QuestDb.Values())
        {
            Quest tempQuest = new Quest();
            tempQuest.SetData(data);
            tempQuest.onProgressAction += uiQuest.UpdateUI;
            questDict.Add(data.id, tempQuest);
        }
    }
}