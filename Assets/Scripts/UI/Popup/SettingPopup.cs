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
        Close();
        Time.timeScale = 1f;
    }

    public void OnClickLoadButton()
    {
        Close();
        //���⿡ ����� JSON ���� �ҷ��� �ڵ� �߰�.
        Time.timeScale = 1f;
    }

    public void OnClickSettingButton()
    {
        Close();
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
