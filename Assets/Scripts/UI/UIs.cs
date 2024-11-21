using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIs : BasePopup
{
    public void OnClickSettingBtn()
    {
        Managers.SoundManager.PlaySFX(SFXType.Button);
        Time.timeScale = 0f;
        Managers.UIManager.CreateUI(UIType.SettingPopup);
    }
}
