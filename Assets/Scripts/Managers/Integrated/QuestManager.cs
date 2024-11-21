using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Constants;

public class QuestManager : MonoBehaviour, IManager
{
    private Dictionary<int, Quest> questDict = new Dictionary<int, Quest>();            // Quest 타입으로 저장하는 dictionary
    public Quest curQuest;      // 현재 진행중인 퀘스트
    public UIQuest uiQuest;     // 퀘스트 진행 상황 UI


    /// <summary>
    /// Quest Id를 받고, Id를 가진 Data의 Quest타입 변수 반환
    /// </summary>
    public Quest GetQuest(int questId)
    {
        if(questDict.ContainsKey(questId))
            return questDict[questId];
        return null;
    }


    /// <summary>
    /// 퀘스트 진행 상황 업데이트 하는 함수, 퀘스트 진행 중일 때만 count가 올라감
    /// </summary>
    public void UpdateQuestProgress(int questId, int amount) 
    {
        Quest quest = GetQuest(questId);
        quest.UpdateProgress(amount);
    }


    /// <summary>
    /// 퀘스트 완료 시 호출되는 함수
    /// </summary>
    private void QuestComplete()                // 퀘스트 완료시 다음 퀘스트 진행시킴
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
    /// 각 퀘스트 마다 진행 상황이 업데이트 될 때 UI도 같이 업데이트 시켜줌
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
        foreach (QuestData data in DataManager.QuestDb.Values())        // 초기화 될 때 각 QuestData를 가진 Quest 객체를 만들어 questDict에 추가
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