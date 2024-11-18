using System.Collections.Generic;
using UnityEngine;
using Constants;

public class DataManager : MonoBehaviour, IManager
{
    public static DataManager Instance;

    private DataBase<ConsumableItemData> consumableDb;
    public static DataBase<ConsumableItemData> ConsumableDb
    {
        get
        {
            if(Managers.DataManager.consumableDb == null)
            {
                List<ConsumableItemData> list = new List<ConsumableItemData>();
                // TODO: 소모품 데이터 불러오기
                // Instance.consumableDb = new DataBase<ConsumableItemData>(list);
                
            }
            return Managers.DataManager.consumableDb;
        }
    }

    private DataBase<EquipItemData> equipDb;
    public static DataBase<EquipItemData> EquipDb
    {
        get
        {
            if (Managers.DataManager.equipDb == null)
            {
                List<EquipItemData> list = new List<EquipItemData>();
                // TODO: 장비 데이터 불러오기
                // Instance.equipDb = new DataBase<EquipItemData>(list);
            }
            return Managers.DataManager.equipDb;
        }
    }

    private DataBase<ProductData> productDb;
    public static DataBase <ProductData> ProductDb
    {
        get
        {
            if (Managers.DataManager.productDb == null)
            {
                List<ProductData> list = new List<ProductData>();
                // TODO: 상품 데이터 불러오기
                // Instance.productDb = new DataBase<ProductData>(list);
            }
            return Managers.DataManager.productDb;
        }
    }

    private DataBase<ShopData> shopDb;
    public static DataBase<ShopData> ShopDb
    {
        get
        {
            if (Managers.DataManager.shopDb == null)
            {
                List<ProductData> list = new List<ProductData>();
                // TODO: 상점 데이터 불러오기
                // Instance.shopDb = new DataBase<ProductData>(list);
            }
            return Managers.DataManager.shopDb;
            //return manager.Instance.DataManager.shopDb;
        }
    }

    public void Init()
    {

    }
}