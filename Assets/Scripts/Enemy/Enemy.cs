using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemySO Data;
    public EnemyController Controller;
    public Rigidbody Rigidbody;
    public Animator Animator;

    private void Awake()
    {
        Controller = GetComponent<EnemyController>();
        Rigidbody = GetComponent<Rigidbody>();
    }
}
