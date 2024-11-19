using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPopup : BasePopup
{
    public override void Init()
    {
        //base.Init();을 호출하면 부모 클래스의 Init 메서드가 먼저 실행
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
        //여기에 저장된 JSON 파일 불러올 코드 추가.
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
        //에디터에서는 종료되지 않음
        Invoke("Wait", 0.5f);
    }

    private void Wait()
    {
        Debug.Log("게임 종료(에디터에서는 종료되지 않습니다)");
        Application.Quit();
    }
}
