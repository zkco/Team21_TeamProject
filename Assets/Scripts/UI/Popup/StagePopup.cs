using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class StagePopup : BasePopup
{
    public RectTransform cursor;  // �̵��� Ŀ�� RectTransform
    public List<RectTransform> stages;  // stages�� ����Ʈ�� ����
    private int currentIndex = 0; // ���� ��ġ (0: Home, 1~3: Enemies)

    void Update()
    {
        // ������ ȭ��ǥ �Է�
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            Managers.SoundManager.PlaySFX(SFXType.selectStage);
            currentIndex++; // ���� ��ġ ����
            currentIndex = Mathf.Clamp(currentIndex, 0, stages.Count - 1); // 0 ~ stages.Count-1 ���̷� ����
            MoveToNextPosition(); // ���� ��ġ�� �̵�
        }

        // ���� ȭ��ǥ �Է�
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            Managers.SoundManager.PlaySFX(SFXType.selectStage);
            currentIndex--; // ���� ��ġ ����
            currentIndex = Mathf.Clamp(currentIndex, 0, stages.Count - 1); // 0 ~ stages.Count-1 ���̷� ����
            MoveToNextPosition(); // ���� ��ġ�� �̵�
        }

        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            OnClickPlayBtn();
        }
    }

    private void MoveToNextPosition()
    {
        // ���� ��ġ�� �ش��ϴ� RectTransform�� ����Ʈ���� ������
        RectTransform target = stages[currentIndex];

        // �̵��� RectTransform�� null�� �ƴ��� Ȯ��
        if (target != null)
        {
            MoveToTarget(target);  // Ÿ�� RectTransform���� �̵�
        }
    }

    private void MoveToTarget(RectTransform target)
    {
        // ���� ��ġ�� ��������, Y�࿡ 100�� ����
        Vector2 newPosition = target.anchoredPosition;
        newPosition.y += 100;  // Y�� 100��ŭ ���ϱ�

        // Ŀ���� ��ġ�� ����
        cursor.anchoredPosition = newPosition;  // cursor�� ��ġ�� ����
    }



    public void OnClickPlayBtn()
    {
        Managers.SoundManager.PlaySFX(SFXType.enterStage);
        if (currentIndex == 0)
        {
            //���⿡ home �ҷ��� �ڵ�
            //Managers.UIManager.CreateUI(UIType.(���⿡ home ������ �߰�))
        }
        else if (currentIndex == 1)
        {
            //���⿡ stage1 �ҷ��� �ڵ�
            //Managers.UIManager.CreateUI(UIType.(���⿡ stage1 ������ �߰�))
        }
        else if (currentIndex == 2)
        {
            //���⿡ stage2 �ҷ��� �ڵ�
            //Managers.UIManager.CreateUI(UIType.(���⿡ stage2 ������ �߰�))
        }
        else if (currentIndex == 3)
        {
            //���⿡ stage3 �ҷ��� �ڵ�
            //Managers.UIManager.CreateUI(UIType.(���⿡ stage3 ������ �߰�))
        }
    }
}




