using EnumTypes;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterSpawnPerStage : MonoBehaviour
{
    private List<EnemyData> enemyDatas;

    private void Awake()
    {
        TextAsset monsterCSV = Resources.Load<TextAsset>("./CSV/MonsterCSV");
        var data = monsterCSV.text.TrimEnd();

        GetData(data);
    }

    private void GetData(string Data)
    {
        string[] rowData = Data.Split('\n');
        for (int i = 1; i < rowData.Length; i++)
        {
            string[] data = rowData[i].Split(',');
            enemyDatas[i].stage = int.Parse(data[0]);
            enemyDatas[i].XPos = float.Parse(data[1]);
            enemyDatas[i].YPos = float.Parse(data[2]);
            enemyDatas[i].path = data[3];
        }
    }

    public List<EnemyData> GetEnemyDatas()
    {
        return enemyDatas;
    }
}