using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePopup : MonoBehaviour
{
    /// <summary>
    /// �ʱ�ȭ �Լ�
    /// </summary>
    public virtual void Init()
    {

    }

    /// <summary>
    /// �ݴ� �Լ�
    /// </summary>
    public virtual void Close()
    {
        //���� UI ��ư ������ �� ���� �Ҹ� �߰�
        Managers.UIManager.CloseUI();
    }

    /// <summary>
    /// �����鼭 ���� �� �ҷ����� �Լ�
    /// </summary>
    protected void Close(SceneType type)
    {
        //���� UI ��ư ������ �� ���� �Ҹ� �߰�
        Managers.UIManager.CloseUI(() => SceneManagerEx.LoadScene(type));
    }

}
