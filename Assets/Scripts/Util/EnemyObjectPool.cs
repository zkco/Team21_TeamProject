using EnumTypes;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyObjectPool : MonoBehaviour
{
    public Dictionary<int, Queue<GameObject>> EnemyPool;
    public Queue<GameObject> Enemies;
    public Queue<Vector2> SpawnPosition;
    public List<EnemyData> EnemiesData;

    private void Start()
    {
        EnemiesData = Managers.PlayerManager.EnemiesData;
        Enemies = new Queue<GameObject>();
        foreach (EnemyData enemy in EnemiesData)
        {
            GameObject obj = Instantiate(Resources.Load<GameObject>(enemy.path), new Vector2(enemy.XPos, enemy.YPos), Quaternion.identity);
            SpawnPosition.Enqueue(obj.transform.position);
            obj.GetComponent<Enemy>().WhichStage = enemy.stage;
            obj.SetActive(false);
            Enemies.Enqueue(obj);
        }
    }

    /// <summary>
    /// Stage 불러올 때 stage의 숫자에 맞는 몬스터가 스폰됨
    /// </summary>
    /// <param name="stage">몬스터의 WhichStage와 일치하는 몬스터가 스폰 됨</param>
    public void SpawnWithStagePosition(int stage) //스테이지 불러올 때 stage에 스테이지 번호를 입력하면
                                                  //해당 스테이지 몬스터가 스폰 됨
    {
        foreach(GameObject obj in Enemies)
        {
            Vector2 temp = SpawnPosition.Dequeue();
            SpawnPosition.Enqueue(temp);
            GameObject tempObj = Enemies.Dequeue();
            Enemies.Enqueue(tempObj);
            if (tempObj.GetComponent<Enemy>().WhichStage == stage)
            {
                Enemy enemy = tempObj.GetComponent<Enemy>();
                enemy.HP = enemy.MaxHP;
                tempObj.transform.position = temp;
                tempObj.SetActive(true);
            }
        }
        
    }
}

[Serializable]
public class EnemyData
{ 
    public int stage;
    public float XPos;
    public float YPos;
    public string path;
}