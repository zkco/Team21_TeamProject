using System;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class EnemyController : MonoBehaviour
{
    public Enemy Enemy;
    private bool _followPlayer;
    private float _distanceToPlayer;
    private Vector2 _positionToPlayer;

    private void Awake()
    {
        Enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        Move();
        _positionToPlayer = Managers.PlayerManager.Player.transform.position - Enemy.transform.position;
    }

    private void Move()
    {
        Enemy.Rigidbody.velocity = _positionToPlayer.normalized * Enemy.Speed;
        if (Mathf.Abs(Enemy.Rigidbody.velocity.x) > 0)
        {
            Enemy.Animator.SetBool("Moving", true);
        }
        else Enemy.Animator.SetBool("Moving", false);
    }

    public void GetDamage(int damage)
    {
        Enemy.Animator.SetTrigger("Damaged");
        Enemy.HP -= damage;
        if(Enemy.HP <= 0) Dead();
    }

    public void Dead()
    {
        Enemy.Animator.SetTrigger("Dead");
        this.gameObject.SetActive(false);
    }
}