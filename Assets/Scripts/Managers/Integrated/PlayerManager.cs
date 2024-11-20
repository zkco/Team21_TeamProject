using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IManager
{
    public Player Player;
    public EnemyObjectPool EnemyPool;

    public void Init()
    {
        
    }

    public void Awake()
    {
        Application.targetFrameRate = 60;
        EnemyPool = this.gameObject.AddComponent<EnemyObjectPool>();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        Player.Status.LevelUp();
    }
}
