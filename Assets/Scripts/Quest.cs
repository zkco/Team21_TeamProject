using System;

public class Quest
{
    public QuestData data;
    public int curProgress;
    public Action onProgressAction;
    private bool isComplete;
    private bool onProgress;

    public void SetData(QuestData data)
    {
        this.data = data;
    }


    public void UpdateProgress(int amount)
    {
        if (onProgress) { 
            curProgress += amount;

            if (curProgress >= data.number)
            {
                isComplete = true;
                onProgress = false;
            }
            onProgressAction?.Invoke();         // UI update ¾×¼Ç

        }
    }

    public void StartQuest()
    {
        onProgress = true;
    }

}