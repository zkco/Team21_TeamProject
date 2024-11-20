using UnityEngine;
using TMPro;
public class UIQuest : MonoBehaviour
{
    private Quest quest;
    private TMP_Text txtQuestName;
    private TMP_Text txtQuestDescription;
    private TMP_Text txtnumber;
    private TMP_Text txtTargetNumber;

    
    private void UpdateQuest()                  // �� ����Ʈ�� �ٲ� �� ������Ʈ
    {
        //quest = QuestManager.curQuest;                
        UpdateUI();
    }
    public void UpdateUI()                      // ����Ʈ �����Ȳ ������Ʈ
    {
        txtQuestName.text = quest.data.name;
        txtQuestDescription.text = quest.data.description;
        txtnumber.text = quest.curProgress.ToString();
        txtTargetNumber.text = quest.data.number.ToString();
    }
}