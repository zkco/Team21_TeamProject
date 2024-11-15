using System.Collections.Generic;

public class DataBase<T> where T : DataModel
{
    private Dictionary<int, T> db = new Dictionary<int, T>();

    public DataBase(List<T> list)
    {
        GenerateDbFromList(list);
    }

    private void GenerateDbFromList(List<T> list)
    {
        foreach (T data in list)
            db.Add(data.id, data);
    }

    public T Get(int id)
    {
        if (db.ContainsKey(id))
            return db[id];

        return null;
    }
}
