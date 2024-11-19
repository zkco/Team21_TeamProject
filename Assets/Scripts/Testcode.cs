
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class Testcode : MonoBehaviour
{
    private void Start()
    {

        DataBase<ItemData> data = DataManager.ItemDb;
        DataBase<ProductData> data3 = DataManager.ProductDb;
        DataBase<ShopData> data4 = DataManager.ShopDb;

    }
}