using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Constants;

public class QuestManager : MonoBehaviour, IManager
{
    private Dictionary<int, Quest> questDict = new Dictionary<int, Quest>();            // Quest Ÿ������ �����ϴ� dictionary
    public Quest curQuest;      // ���� �������� ����Ʈ
    public UIQuest uiQuest;     // ����Ʈ ���� ��Ȳ UI


    /// <summary>
    /// Quest Id�� �ް�, Id�� ���� Data�� QuestŸ�� ���� ��ȯ
    /// </summary>
    public Quest GetQuest(int questId)
    {
        if(questDict.ContainsKey(questId))
            return questDict[questId];
        return null;
    }


    /// <summary>
    /// ����Ʈ ���� ��Ȳ ������Ʈ �ϴ� �Լ�, ����Ʈ ���� ���� ���� count�� �ö�
    /// </summary>
    public void UpdateQuestProgress(int questId, int amount) 
    {
        Quest quest = GetQuest(questId);
        quest.UpdateProgress(amount);
    }


    /// <summary>
    /// ����Ʈ �Ϸ� �� ȣ��Ǵ� �Լ�
    /// </summary>
    private void QuestComplete()                // ����Ʈ �Ϸ�� ���� ����Ʈ �����Ŵ
    {
        if (curQuest.data.nextQuestId == QuestCode.EndQuestId)
        {
            Debug.Log("Quest End");
            uiQuest.gameObject.SetActive(false);
            return;
        }

        curQuest = GetQuest(curQuest.data.nextQuestId);
        curQuest.StartQuest();
        uiQuest.UpdateQuest();
    }

    /// <summary>
    /// �� ����Ʈ ���� ���� ��Ȳ�� ������Ʈ �� �� UI�� ���� ������Ʈ ������
    /// </summary>
    public void AddProgressAction()
    {
        foreach(Quest quest in questDict.Values)
        {
            quest.onProgressAction += uiQuest.UpdateQuest;
        }
    }

    public void Init()
    {
        foreach (QuestData data in DataManager.QuestDb.Values())        // �ʱ�ȭ �� �� �� QuestData�� ���� Quest ��ü�� ����� questDict�� �߰�
        {
            Quest tempQuest = new Quest();
            tempQuest.SetData(data);
            tempQuest.onCompleteAction += QuestComplete;
            questDict.Add(data.id, tempQuest);
        }
        curQuest = GetQuest(QuestCode.StartQuestId);
        curQuest.StartQuest();
        
    }
}