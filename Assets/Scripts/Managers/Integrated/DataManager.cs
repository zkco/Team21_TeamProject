using System.Collections.Generic;
using UnityEngine;
using Constants;

public class DataManager : MonoBehaviour, IManager
{
    public static DataManager Instance;

    private DataBase<ConsumableItemData> consumableDb;          // �Ҹ�ǰ ������ DB
    public static DataBase<ConsumableItemData> ConsumableDb
    {
        get
        {
            if(Managers.DataManager.consumableDb == null)
            {
                List<ConsumableItemData> list = new List<ConsumableItemData>();
                // TODO: �Ҹ�ǰ ������ �ҷ�����
                //string jsonData = "JSON/ConsumableDB";
                //list = JsonUtility.FromJson<List<ConsumableItemData>>(jsonData);
                //Managers.DataManager.consumableDb = new DataBase<ConsumableItemData>(list);
                Debug.Log(list);
            }
            return Managers.DataManager.consumableDb;
        }
    }

    private DataBase<EquipItemData> equipDb;                    // ��� ������ DB
    public static DataBase<EquipItemData> EquipDb
    {
        get
        {
            if (Managers.DataManager.equipDb == null)
            {
                List<EquipItemData> list = new List<EquipItemData>();
                // TODO: ��� ������ �ҷ�����
                Managers.DataManager.equipDb = new DataBase<EquipItemData>(list);
            }
            return Managers.DataManager.equipDb;
        }
    }

    private DataBase<ProductData> productDb;                    // ���� ǰ�� DB (������ ID�� ����)
    public static DataBase <ProductData> ProductDb
    {
        get
        {
            if (Managers.DataManager.productDb == null)
            {
                List<ProductData> list = new List<ProductData>();
                // TODO: ��ǰ ������ �ҷ�����
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
                // TODO: ���� ������ �ҷ�����
                Managers.DataManager.shopDb = new DataBase<ShopData>(list);
            }
            return Managers.DataManager.shopDb;
        }
    }

    public void Init()
    {
        
    }
}