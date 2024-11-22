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
        Debug.Log("���� ����!(�����Ϳ����� ������� �ʽ��ϴ�.");
        Application.Quit();
    }
}
