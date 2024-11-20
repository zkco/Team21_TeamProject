using System.Collections.Generic;
using UnityEngine;
using Constants;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System;

public class DataManager : MonoBehaviour, IManager
{
    public static DataManager Instance;
    
    //private DataBase<ConsumableItemData> consumableDb;          // 소모품 아이템 DB
    //public static DataBase<ConsumableItemData> ConsumableDb
    //{
    //    get
    //    {
    //        if (Managers.DataManager.consumableDb == null)
    //        {
    //            List<ConsumableItemData> list = new List<ConsumableItemData>();
    //            // TODO: 소모품 데이터 불러오기
    //            string jsonData = Resources.Load<TextAsset>("JSON/ConsumableDB").text;
    //            list = JsonUtility.FromJson<Wrapper<ConsumableItemData>>(jsonData).items;
    //            Managers.DataManager.consumableDb = new DataBase<ConsumableItemData>(list);
                
    //        }
    //        return Managers.DataManager.consumableDb;
    //    }
    //}


    //private DataBase<EquipItemData> equipDb;                    // 장비 아이템 DB
    //public static DataBase<EquipItemData> EquipDb
    //{
    //    get
    //    {
    //        if (Managers.DataManager.equipDb == null)
    //        {
    //            List<EquipItemData> list = new List<EquipItemData>();
    //            // TODO: 장비 데이터 불러오기
    //            string jsonData = Resources.Load<TextAsset>("JSON/EquipDB").text;
    //            list = JsonUtility.FromJson<Wrapper<EquipItemData>>(jsonData).items;

    //            Managers.DataManager.equipDb = new DataBase<EquipItemData>(list);
    //        }
    //        return Managers.DataManager.equipDb;
    //    }
    //}
    private DataBase<ItemData> itemDb;          // 아이템 DB
    public static DataBase<ItemData> ItemDb
    {
        get
        {
            if (Managers.DataManager.itemDb == null)
            {
                List<ItemData> list = new List<ItemData>();
                // TODO: 소모품 데이터 불러오기
                string jsonData = Resources.Load<TextAsset>("JSON/ItemDB").text;
                list = JsonUtility.FromJson<Wrapper<ItemData>>(jsonData).items;
                Managers.DataManager.itemDb = new DataBase<ItemData>(list);

            }
            return Managers.DataManager.itemDb;
        }
    }

    private DataBase<ProductData> productDb;                    // 상품 DB (아이템 ID와 가격)
    public static DataBase <ProductData> ProductDb
    {
        get
        {
            if (Managers.DataManager.productDb == null)
            {
                List<ProductData> list = new List<ProductData>();
                // TODO: 상품 데이터 불러오기
                string jsonData = Resources.Load<TextAsset>("JSON/ProductDB").text;
                list = JsonUtility.FromJson<Wrapper<ProductData>>(jsonData).items;

                Managers.DataManager.productDb = new DataBase<ProductData>(list);
            }
            return Managers.DataManager.productDb;
        }
    }

    private DataBase<ShopData> shopDb;                          // 상점 DB (product의 List와 상점이름 저장)
    public static DataBase<ShopData> ShopDb
    {
        get
        {
            if (Managers.DataManager.shopDb == null)
            {
                List<ShopData> list = new List<ShopData>();
                // TODO: 상점 데이터 불러오기
                string jsonData = Resources.Load<TextAsset>("JSON/ShopDB").text;
                list = JsonUtility.FromJson<Wrapper<ShopData>>(jsonData).items;

                Managers.DataManager.shopDb = new DataBase<ShopData>(list);
            }
            return Managers.DataManager.shopDb;
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