using EnumTypes;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class EnemyObjectPool : MonoBehaviour
{
    public Dictionary<int, Queue<GameObject>> EnemyPool;
    public Queue<GameObject> Enemies;
    public Queue<Vector2> SpawnPosition;
    public List<EnemyData> EnemiesData;

    private void Start()
    {
        EnemiesData = Managers.DataManager.EnemyDatas;
        SpawnPosition = new Queue<Vector2>();
        Enemies = new Queue<GameObject>();
        for(int i = 0; i < EnemiesData.Count; i++)
        {
            GameObject obj = Instantiate(Resources.Load<GameObject>(EnemiesData[i].path));
            Vector2 pos = new Vector2(EnemiesData[i].XPos, EnemiesData[i].YPos);
            obj.GetComponent<Enemy>().WhichStage = EnemiesData[i].stage;
            Enemies.Enqueue(obj);
            DontDestroyOnLoad(obj);
            SpawnPosition.Enqueue(pos);
            obj.SetActive(false);
        }
    }

    /// <summary>
    /// Stage �ҷ��� �� stage�� ���ڿ� �´� ���Ͱ� ������
    /// </summary>
    /// <param name="stage">������ WhichStage�� ��ġ�ϴ� ���Ͱ� ���� ��</param>
    public void SpawnWithStagePosition(int stage) //�������� �ҷ��� �� stage�� �������� ��ȣ�� �Է��ϸ�
    {                                             //�ش� �������� ���Ͱ� ���� ��
        for(int i = 0; i < Enemies.Count; i++)
        {
            GameObject obj = Enemies.Dequeue();
            obj.transform.position = SpawnPosition.Dequeue();
            if (stage == EnemiesData[i].stage)
            {
                obj.SetActive(true);
            }
            Enemies.Enqueue(obj);
            SpawnPosition.Enqueue(obj.transform.position);
        }
    }

    public void DeSpawnAllEnemy()
    {
        foreach (GameObject obj in Enemies)
        {
            obj.SetActive(false);
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