using System.Collections.Generic;
using UnityEngine;
using Constants;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System;

public class DataManager : MonoBehaviour, IManager
{
    public static DataManager Instance;

    private DataBase<ConsumableItemData> consumableDb;          // �Ҹ�ǰ ������ DB
    public static DataBase<ConsumableItemData> ConsumableDb
    {
        get
        {
            if (Managers.DataManager.consumableDb == null)
            {
                List<ConsumableItemData> list = new List<ConsumableItemData>();
                // TODO: �Ҹ�ǰ ������ �ҷ�����
                string jsonData = Resources.Load<TextAsset>("JSON/ConsumableDB").text;
                list = JsonUtility.FromJson<Wrapper<ConsumableItemData>>(jsonData).items;
                Managers.DataManager.consumableDb = new DataBase<ConsumableItemData>(list);
                
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
                string jsonData = Resources.Load<TextAsset>("JSON/EquipDB").text;
                list = JsonUtility.FromJson<Wrapper<EquipItemData>>(jsonData).items;

                Managers.DataManager.equipDb = new DataBase<EquipItemData>(list);
            }
            return Managers.DataManager.equipDb;
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
                // TODO: ��ǰ ������ �ҷ�����
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
                // TODO: ���� ������ �ҷ�����
                string jsonData = Resources.Load<TextAsset>("JSON/ShopDB").text;
                list = JsonUtility.FromJson<Wrapper<ShopData>>(jsonData).items;

                Managers.DataManager.shopDb = new DataBase<ShopData>(list);
            }
            return Managers.DataManager.shopDb;
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