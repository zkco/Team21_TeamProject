using System;
using System.Collections.Generic;
[Serializable]
public class ShopData : DataModel
{
    public string shopName;
    public List<int> productList;

    public ShopData(int id, string shopName, List<int> productList)
    {
        this.id = id;
        this.shopName = shopName;
        this.productList = productList;
    }

}