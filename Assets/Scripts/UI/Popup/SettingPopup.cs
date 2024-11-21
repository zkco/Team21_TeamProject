using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPopup : BasePopup
{
    public override void Init()
    {
        //base.Init();�� ȣ���ϸ� �θ� Ŭ������ Init �޼��尡 ���� ����
        Time.timeScale = 0f;
    }

    public void OnClickContinueButton()
    {
        Managers.SoundManager.PlaySFX(SFXType.Button);
        Close();
        Time.timeScale = 1f;
        
    }

    public void OnClickLoadButton()
    {

        //���⿡ ����� JSON ���� �ҷ��� �ڵ� �߰�.
        Time.timeScale = 1f;
    }

    public void OnClickSettingButton()
    {
        Managers.SoundManager.PlaySFX(SFXType.Button);
        Managers.UIManager.CreateUI(UIType.SettingPopup2, false);
    }

    public void OnClickQuitButton()
    {
        Managers.SoundManager.PlaySFX(SFXType.Button);
        //�����Ϳ����� ������� ����
        Invoke("Wait", 0.5f);
    }

    private void Wait()
    {
        Debug.Log("���� ����(�����Ϳ����� ������� �ʽ��ϴ�)");
        Application.Quit();
    }
}
