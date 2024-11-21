using System.Collections.Generic;
using UnityEngine;
using Constants;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System;

public class DataManager : MonoBehaviour, IManager
{
   
    private DataBase<ItemData> itemDb;          // ������ DB
    public static DataBase<ItemData> ItemDb
    {
        get
        {
            if (Managers.DataManager.itemDb == null)
            {
                List<ItemData> list = new List<ItemData>();
                string jsonData = Resources.Load<TextAsset>("JSON/ItemDB").text;
                list = JsonUtility.FromJson<Wrapper<ItemData>>(jsonData).items;
                Managers.DataManager.itemDb = new DataBase<ItemData>(list);

            }
            return Managers.DataManager.itemDb;
        }
    }

    private DataBase<ProductData> productDb;                    // ��ǰ DB (������ ID�� ����)
    public static DataBase <ProductData> ProductDb
    {
        get
        {
            if (Managers.DataManager.productDb == null)
            {
                List<ProductData> list = new List<ProductData>();
                string jsonData = Resources.Load<TextAsset>("JSON/ProductDB").text;
                list = JsonUtility.FromJson<Wrapper<ProductData>>(jsonData).items;

                Managers.DataManager.productDb = new DataBase<ProductData>(list);
            }
            return Managers.DataManager.productDb;
        }
    }

    private DataBase<ShopData> shopDb;                          // ���� DB (product�� List�� �����̸� ����)
    public static DataBase<ShopData> ShopDb
    {
        get
        {
            if (Managers.DataManager.shopDb == null)
            {
                List<ShopData> list = new List<ShopData>();
                string jsonData = Resources.Load<TextAsset>("JSON/ShopDB").text;
                list = JsonUtility.FromJson<Wrapper<ShopData>>(jsonData).items;

                Managers.DataManager.shopDb = new DataBase<ShopData>(list);
            }
            return Managers.DataManager.shopDb;
        }
    }

    private DataBase<QuestData> questDb;                          // ����Ʈ DB (����Ʈ ����, ��ǥ)
    public static DataBase<QuestData> QuestDb
    {
        get
        {
            if (Managers.DataManager.questDb == null)
            {
                List<QuestData> list = new List<QuestData>();
                string jsonData = Resources.Load<TextAsset>("JSON/QuestDB").text;
                list = JsonUtility.FromJson<Wrapper<QuestData>>(jsonData).items;

                Managers.DataManager.questDb = new DataBase<QuestData>(list);
            }
            return Managers.DataManager.questDb;
        }
    }


    public List<EnemyData> enemyDatas;

    public List<EnemyData> EnemyDatas
    {
        get
        {
            if(enemyDatas == null)
            {
                enemyDatas = new List<EnemyData>();
                TextAsset monsterCSV = Resources.Load<TextAsset>("CSV/MonsterCSV");

                var Data = monsterCSV.text.TrimEnd();
                string[] rowData = Data.Split("\r\n");

                for (int i = 1; i < rowData.Length; i++)
                {
                    EnemyData enemyData = new EnemyData();
                    string[] data = rowData[i].Split(',');
                    enemyData.stage = int.Parse(data[0]);
                    enemyData.XPos = float.Parse(data[1]);
                    enemyData.YPos = float.Parse(data[2]);
                    enemyData.path = data[3];
                    enemyDatas.Add(enemyData);
                }
            }
            return enemyDatas;
        }
    }

    public void Init()
    {
        
    }
}

[Serializable]
public class Wrapper<T>
{
    public List<T> items;
}