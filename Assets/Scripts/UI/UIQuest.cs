using UnityEngine;
using TMPro;
public class UIQuest : MonoBehaviour
{
    private Quest quest;
    private TMP_Text txtQuestName;
    private TMP_Text txtQuestDescription;
    private TMP_Text txtnumber;
    private TMP_Text txtTargetNumber;

    
    private void UpdateQuest()                  // 새 퀘스트로 바뀔 때 업데이트
    {
        //quest = QuestManager.curQuest;                
        UpdateUI();
    }
    public void UpdateUI()                      // 퀘스트 진행상황 업데이트
    {
        txtQuestName.text = quest.data.name;
        txtQuestDescription.text = quest.data.description;
        txtnumber.text = quest.curProgress.ToString();
        txtTargetNumber.text = quest.data.number.ToString();
    }
}