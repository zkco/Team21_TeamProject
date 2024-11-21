using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingBtn : BasePopup
{
    public override void Init()
    {
        base.Init();
    }

    public void OnClickSettingBtn()
    {
        Managers.SoundManager.PlaySFX(SFXType.Button);
        Managers.UIManager.CreateUI(UIType.SettingPopup);
        Time.timeScale = 0f;
    }
}
