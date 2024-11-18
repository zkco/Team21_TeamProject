using System.Collections.Generic;
using UnityEngine;
using Constants;

public class DataManager : MonoBehaviour, IManager
{
    public static DataManager Instance;

    private DataBase<ConsumableItemData> consumableDb;          // 소모품 아이템 DB
    public static DataBase<ConsumableItemData> ConsumableDb
    {
        get
        {
            if(Managers.DataManager.consumableDb == null)
            {
                List<ConsumableItemData> list = new List<ConsumableItemData>();
                // TODO: 소모품 데이터 불러오기
                //string jsonData = "JSON/ConsumableDB";
                //list = JsonUtility.FromJson<List<ConsumableItemData>>(jsonData);
                //Managers.DataManager.consumableDb = new DataBase<ConsumableItemData>(list);
                Debug.Log(list);
            }
            return Managers.DataManager.consumableDb;
        }
    }

    private DataBase<EquipItemData> equipDb;                    // 장비 아이템 DB
    public static DataBase<EquipItemData> EquipDb
    {
        get
        {
            if (Managers.DataManager.equipDb == null)
            {
                List<EquipItemData> list = new List<EquipItemData>();
                // TODO: 장비 데이터 불러오기
                Managers.DataManager.equipDb = new DataBase<EquipItemData>(list);
            }
            return Managers.DataManager.equipDb;
        }
    }

    private DataBase<ProductData> productDb;                    // 상점 품목 DB (아이템 ID와 가격)
    public static DataBase <ProductData> ProductDb
    {
        get
        {
            if (Managers.DataManager.productDb == null)
            {
                List<ProductData> list = new List<ProductData>();
                // TODO: 상품 데이터 불러오기
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
                Managers.DataManager.shopDb = new DataBase<ShopData>(list);
            }
            return Managers.DataManager.shopDb;
        }
    }

    public void Init()
    {
        
    }
}