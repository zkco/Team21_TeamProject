using System.Collections.Generic;
using Unity.VisualScripting;

public class DataBase<T> where T : DataModel
{
    private Dictionary<int, T> db = new Dictionary<int, T>();

    public DataBase(List<T> list)   // DataBase ������
    {
        GenerateDbFromList(list);
    }

    private void GenerateDbFromList(List<T> list)   // Data�� List�� ������ �޾� Dictionary ����
    {
        foreach (var data in list)
            db.Add(data.id, data);
    }

    public T Get(int id)        // id�� ���� data ��ȯ
    {
        if (db.ContainsKey(id))
            return db[id];

        return null;
    }

    public bool IsContain(int id)   // id�� ���� data�� �ִ��� ��ȯ
    {
        return db.ContainsKey(id);
    }

    public Dictionary<int, T>.ValueCollection Values()  // db�� ��� Value�� ��ȯ
    {
        return db.Values;
    }
}
