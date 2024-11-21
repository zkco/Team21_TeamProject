using System.Collections.Generic;
using UnityEngine;
using Constants;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System;

public class DataManager : MonoBehaviour, IManager
{
   
    private DataBase<ItemData> itemDb;          // 아이템 DB
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

    private DataBase<ProductData> productDb;                    // 상품 DB (아이템 Id와 가격)
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

    private DataBase<ShopData> shopDb;                          // 상점 DB (product의 List와 상점 이름)
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

    private DataBase<QuestData> questDb;                          // 퀘스트 DB (퀘스트 정보, 목표, 보상)
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


    public List<EnemyData> enemyDatas = new List<EnemyData>();

    public List<EnemyData> EnemyDatas
    {
        get
        {
            if(enemyDatas == null)
            {
                TextAsset monsterCSV = Resources.Load<TextAsset>("CSV/MonsterCSV");
                EnemyData enemyData = new EnemyData();

                var Data = monsterCSV.text.TrimEnd();
                string[] rowData = Data.Split('\n');

                for (int i = 1; i < rowData.Length; i++)
                {
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