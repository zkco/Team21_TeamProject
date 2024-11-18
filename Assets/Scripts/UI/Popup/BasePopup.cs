using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePopup : MonoBehaviour
{
    /// <summary>
    /// 초기화 함수
    /// </summary>
    public virtual void Init()
    {

    }

    /// <summary>
    /// 닫는 함수
    /// </summary>
    public virtual void Close()
    {
        //추후 UI 버튼 눌렀을 때 나올 소리 추가
        Managers.UIManager.CloseUI();
    }

    /// <summary>
    /// 닫으면서 다음 씬 불러오는 함수
    /// </summary>
    protected void Close(SceneType type)
    {
        //추후 UI 버튼 눌렀을 때 나올 소리 추가
        Managers.UIManager.CloseUI(() => SceneManagerEx.LoadScene(type));
    }

}
