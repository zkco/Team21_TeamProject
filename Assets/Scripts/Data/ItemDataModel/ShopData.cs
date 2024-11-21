using System;
using System.Collections.Generic;
[Serializable]
public class ShopData : DataModel
{
    public string name;
    public List<int> productList;

    public ShopData(int id, string name, List<int> productList)
    {
        this.id = id;
        this.name = name;
        this.productList = productList;
    }
}
