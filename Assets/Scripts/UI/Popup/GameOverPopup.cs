using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPopup : BasePopup
{

    public void OnclickRetryBtn()
    {
        Managers.SoundManager.PlaySFX(SFXType.Button);
        string currentSceneName = SceneManager.GetActiveScene().name;
        Managers.PlayerManager.Player.Status.Hp = Managers.PlayerManager.Player.Status.MaxHp;
        Managers.PlayerManager.Player.Condition.isPlayerDead = false;
        SceneManager.LoadScene(currentSceneName);
    }

    public void OnClickQuitBtn()
    {
        Debug.Log("게임 종료!(에디터에서는 종료되지 않습니다.");
        Application.Quit();
    }
}
