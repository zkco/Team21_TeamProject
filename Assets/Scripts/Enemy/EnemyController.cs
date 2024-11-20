using System;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class EnemyController : MonoBehaviour
{
    public Enemy Enemy;
    private bool _followPlayer;
    private float _distanceToPlayer;
    private Vector2 _positionToPlayer;
    private Vector2 dir;

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
        dir = new Vector2(_positionToPlayer.normalized.x * Enemy.Speed, Enemy.Rigidbody.velocity.y);
        Enemy.Rigidbody.velocity = dir;
        if (Mathf.Abs(Enemy.Rigidbody.velocity.x) > 0)
        {
            Enemy.Animator.SetBool("Moving", true);
            if(Enemy.Rigidbody.velocity.x < 0) 
                Enemy.SR.flipX = true;
            else Enemy.SR.flipX = false;
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