using UnityEngine;
using TMPro;
public class UIQuest : MonoBehaviour
{
    private Quest quest;
    [SerializeField] private TMP_Text txtQuestName;
    [SerializeField] private TMP_Text txtQuestDescription;
    [SerializeField] private TMP_Text txtnumber;
    [SerializeField] private TMP_Text txtTargetNumber;

    private void Start()
    {
        Managers.QuestManager.uiQuest = this;
        quest = Managers.QuestManager.curQuest;
        Managers.QuestManager.AddProgressAction();
        UpdateUI();
    }
    public void UpdateQuest()                  // 새 퀘스트로 바뀔 때 업데이트
    {
        quest = Managers.QuestManager.curQuest;
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