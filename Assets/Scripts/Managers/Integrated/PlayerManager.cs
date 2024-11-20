using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IManager
{
    public Player Player;
    private MonsterSpawnPerStage _monsterSpawnPerStage;
    public EnemyObjectPool EnemyPool;
    public List<EnemyData> EnemiesData;

    public void Init()
    {
        _monsterSpawnPerStage = this.gameObject.AddComponent<MonsterSpawnPerStage>();
        EnemyPool = this.gameObject.AddComponent<EnemyObjectPool>();
    }

    public void Awake()
    {
        Application.targetFrameRate = 60;
        
        
    }

    private void Start()
    {
        EnemiesData = _monsterSpawnPerStage.GetEnemyDatas();
    }

    private void Update()
    {
        Player.Status.LevelUp();
    }
}
