using System.Collections.Generic;
using UnityEngine;
using Constants;

public class DataManager : MonoBehaviour, IManager
{
    private DataBase<ConsumableItemData> consumableDb;
    public DataBase<ConsumableItemData> ConsumableDb
    {
        get
        {
            if(consumableDb == null)
            {
                List<ConsumableItemData> list = new List<ConsumableItemData>();
                // TODO: 소모품 데이터 불러오기
                // Instance.consumableDb = new DataBase<ConsumableItemData>(list);
            }
            return consumableDb;
        }
    }

    private DataBase<EquipItemData> equipDb;
    public DataBase<EquipItemData> EquipDb
    {
        get
        {
            if (equipDb == null)
            {
                List<EquipItemData> list = new List<EquipItemData>();
                // TODO: 장비 데이터 불러오기
                // Instance.equipDb = new DataBase<EquipItemData>(list);
            }
            return equipDb;
        }
    }

    private DataBase<ProductData> productDb;
    public DataBase <ProductData> ProductDb
    {
        get
        {
            if (productDb == null)
            {
                List<ProductData> list = new List<ProductData>();
                // TODO: 상품 데이터 불러오기
                // Instance.productDb = new DataBase<ProductData>(list);
            }
            return productDb;
        }
    }

    private DataBase<ShopData> shopDb;
    public DataBase<ShopData> ShopDb
    {
        get
        {
            if (shopDb == null)
            {
                List<ProductData> list = new List<ProductData>();
                // TODO: 상점 데이터 불러오기
                // Instance.shopDb = new DataBase<ProductData>(list);
            }
            return shopDb;
            //return manager.Instance.DataManager.shopDb;
        }
    }

    public void Init()
    {

    }
}