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

    private void Awake()
    {
        Controller = GetComponent<EnemyController>();
        Rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        HP = MaxHP;
    }
    public void GetDamage(int damage)
    {
        HP -= damage;
    }

    public void Dead()
    {
        if (HP <= 0)
        {
            
        }
    }
}
