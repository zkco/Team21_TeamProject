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
        Managers.SoundManager.PlaySFX(SFXType.Button);
        Managers.UIManager.CloseUI();
    }

    /// <summary>
    /// 닫으면서 다음 씬 불러오는 함수
    /// </summary>
    protected void Close(SceneType type)
    {
        Managers.SoundManager.PlaySFX(SFXType.Button);
        Managers.UIManager.CloseUI(() => SceneManagerEx.LoadScene(type));
    }

}
