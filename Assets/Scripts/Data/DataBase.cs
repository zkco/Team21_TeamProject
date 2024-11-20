using System.Collections.Generic;
using Unity.VisualScripting;

public class DataBase<T> where T : DataModel
{
    private Dictionary<int, T> db = new Dictionary<int, T>();

    public DataBase(List<T> list)
    {
        GenerateDbFromList(list);
    }

    private void GenerateDbFromList(List<T> list)
    {
        foreach (var data in list)
            db.Add(data.id, data);
    }

    public T Get(int id)
    {
        if (db.ContainsKey(id))
            return db[id];

        return null;
    }

    public bool IsContain(int id)
    {
        return db.ContainsKey(id);
    }

    public Dictionary<int, T>.ValueCollection Values()
    {
        return db.Values;
    }
}
