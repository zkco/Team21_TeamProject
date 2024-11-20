using System.Collections.Generic;
using UnityEngine;

public class EnemyObjectPool : MonoBehaviour
{
    public Dictionary<int, Queue<GameObject>> EnemyPool;
    public Queue<GameObject> Enemies;

    private void Start()
    {
        EnemyPool = new Dictionary<int, Queue<GameObject>>();
        Enemies = new Queue<GameObject>();


    }
}