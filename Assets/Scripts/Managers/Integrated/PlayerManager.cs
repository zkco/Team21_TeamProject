using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IManager
{
    public Player Player;

    public void Init()
    {

    }

    public void Awake()
    {
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        Player.Status.LevelUp();
    }
}
