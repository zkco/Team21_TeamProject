using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPopup2 : BasePopup
{
    [SerializeField] private Scrollbar bgmScrollbar;
    [SerializeField] private Scrollbar sfxScrollbar;

    public override void Init()
    {
        bgmScrollbar.value = PlayerPrefs.GetFloat("BGM", 1);
        sfxScrollbar.value = PlayerPrefs.GetFloat("SFX", 1);
    }

    public void OnBGMScrollbar()
    {
        Managers.SoundManager.SetVolume("BGM", bgmScrollbar.value);
    }

    public void OnSFXScrollbar()
    {
        Managers.SoundManager.SetVolume("SFX", sfxScrollbar.value);
    }

    
}
