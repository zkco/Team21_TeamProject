using TMPro;
using UnityEngine;

public class QuestManager : MonoBehaviour, IManager
{
    private TMP_Text txtQuestName;
    private TMP_Text txtQuestDescription;
    private TMP_Text txtnumber;
    private QuestData curQuestData;
    private int curNumber;

    
    private void QuestComplete()
    {
        curNumber = 0;
        curQuestData = DataManager.QuestDb.Get(curQuestData.nextQuestId);
        UpdateUI();
    }
    private void UpdateUI()
    {
        txtQuestName.text = curQuestData.name;
        txtQuestDescription.text = curQuestData.description;
        txtnumber.text = curNumber.ToString() + " / " + curQuestData.number.ToString();
    }
    public void Init()
    {

    }
}