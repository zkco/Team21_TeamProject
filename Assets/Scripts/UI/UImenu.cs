using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UImenu : MonoBehaviour
{
    public GameObject volumePanel;



    public void OnSettingButton()
    {
        if (isOpen())
        {
            volumePanel.SetActive(false);
        }
        else
        {
            volumePanel.SetActive(true);
        }
    }

    public bool isOpen()
    {
        return volumePanel.activeInHierarchy;
    }


}
