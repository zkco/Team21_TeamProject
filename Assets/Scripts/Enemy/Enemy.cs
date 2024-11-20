using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int HP;
    public int MaxHP;
    public int Damage;
    public int Speed;
    public int Gold;
    public EnemyController Controller;
    public Rigidbody Rigidbody;
    public Animator Animator;
    public int WhichStage;

    private void Awake()
    {
        Controller = GetComponent<EnemyController>();
        Rigidbody = GetComponent<Rigidbody>();
    }
}