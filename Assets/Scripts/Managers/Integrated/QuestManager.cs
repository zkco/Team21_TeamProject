using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestManager : MonoBehaviour, IManager
{
    private Dictionary<int, Quest> questDict = new Dictionary<int, Quest>();            // Quest 타입으로 저장하는 dictionary
    public Quest curQuest;      // 현재 진행중인 퀘스트
    public UIQuest uiQuest;

    public Quest GetQuest(int questId)          // 퀘스트 id를 받으면 그 Data를 가진 Quest 타입 변수 반환
    {
        if(questDict.ContainsKey(questId))
            return questDict[questId];
        return null;
    }

    public void UpdateQuestProgress(int questId, int amount)            // 퀘스트 진행 상황 업데이트 - 퀘스트 진행 중일때만 업데이트 됨
    {
        Quest quest = GetQuest(questId);
        quest.UpdateProgress(amount);
    }
    private void QuestComplete()                // 퀘스트 완료시 다음 퀘스트 진행시킴
    {
        curQuest = GetQuest(curQuest.data.nextQuestId);
        curQuest.StartQuest();
    }

    public void Init()
    {
        //uiQuest =                                     // TODO: 퀘스트 UI 할당하기
        foreach (QuestData data in DataManager.QuestDb.Values())
        {
            Quest tempQuest = new Quest();
            tempQuest.SetData(data);
            tempQuest.onProgressAction += uiQuest.UpdateUI;
            questDict.Add(data.id, tempQuest);
        }
    }
}