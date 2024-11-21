using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UITitle : MonoBehaviour
{

    public void OnStartButton()
    {
        Managers.SoundManager.PlaySFX(SFXType.Button);
        SceneManagerEx.LoadScene(SceneType.Town);
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }

}
