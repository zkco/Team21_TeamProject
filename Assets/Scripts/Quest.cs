using System;

public class Quest
{
    public QuestData data;
    public int curProgress;
    public Action onProgressAction;
    private bool isComplete;
    private bool onProgress;
    public Action onCompleteAction;

    /// <summary>
    /// 퀘스트의 데이터를 할당시키는 함수
    /// </summary>
    public void SetData(QuestData data)
    {
        this.data = data;
    }


    public void UpdateProgress(int amount)
    {
        if (!onProgress) return;            // 진행 중이 아닌 퀘스트일 때 무시함
        

        curProgress += amount;

        if (curProgress >= data.number)
        {
            isComplete = true;
            onProgress = false;
            onCompleteAction?.Invoke();
        }
        onProgressAction?.Invoke();         // UI update 액션

    }

    /// <summary>
    /// 퀘스트 시작 시 onProgress 값을 true로 만듦
    /// </summary>
    public void StartQuest()
    {
        onProgress = true;
    }

}