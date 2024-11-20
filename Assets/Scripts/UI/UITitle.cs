using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UITitle : MonoBehaviour
{

    public void OnStartButton()
    {
        SceneManager.LoadScene("Stagetown");
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }

}
