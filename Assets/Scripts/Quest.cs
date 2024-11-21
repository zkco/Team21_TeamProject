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
    /// ����Ʈ�� �����͸� �Ҵ��Ű�� �Լ�
    /// </summary>
    public void SetData(QuestData data)
    {
        this.data = data;
    }


    public void UpdateProgress(int amount)
    {
        if (!onProgress) return;            // ���� ���� �ƴ� ����Ʈ�� �� ������
        

        curProgress += amount;

        if (curProgress >= data.number)
        {
            isComplete = true;
            onProgress = false;
            onCompleteAction?.Invoke();
        }
        onProgressAction?.Invoke();         // UI update �׼�

    }

    /// <summary>
    /// ����Ʈ ���� �� onProgress ���� true�� ����
    /// </summary>
    public void StartQuest()
    {
        onProgress = true;
    }

}