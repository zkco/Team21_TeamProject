using System.Collections.Generic;
using Unity.VisualScripting;

public class DataBase<T> where T : DataModel
{
    private Dictionary<int, T> db = new Dictionary<int, T>();

    public DataBase(List<T> list)   // DataBase 생성자
    {
        GenerateDbFromList(list);
    }

    private void GenerateDbFromList(List<T> list)   // Data의 List를 변수로 받아 Dictionary 생성
    {
        foreach (var data in list)
            db.Add(data.id, data);
    }

    public T Get(int id)        // id를 가진 data 반환
    {
        if (db.ContainsKey(id))
            return db[id];

        return null;
    }

    public bool IsContain(int id)   // id를 가진 data가 있는지 반환
    {
        return db.ContainsKey(id);
    }

    public Dictionary<int, T>.ValueCollection Values()  // db의 모든 Value값 반환
    {
        return db.Values;
    }
}
