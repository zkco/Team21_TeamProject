using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int HP;
    public int MaxHP;
    public int Damage;
    public int Speed;
    public int Gold;
    public EnemyController Controller;
    public Rigidbody2D Rigidbody;
    public Animator Animator;
    public SpriteRenderer SR;
    public Collider2D Collider;
    public int WhichStage;

    private void Awake()
    {
        Controller = GetComponent<EnemyController>();
        Rigidbody = GetComponent<Rigidbody2D>();
        Collider = GetComponent<Collider2D>();
        Animator = GetComponentInChildren<Animator>();
        SR = GetComponentInChildren<SpriteRenderer>();
        Controller.Enemy = this;
    }
}