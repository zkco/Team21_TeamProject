using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class AttackRange : MonoBehaviour
{
    private Collider2D _collider;
    private List<Enemy> _target;

    private void Start()
    {
        Managers.PlayerManager.Player.Controller.AttackAction += Attack;
    }

    private void Update()
    {
        if(Managers.PlayerManager.Player.Renderer.flipX == true)
        {
            this.gameObject.transform.position *= new Vector2(-1, 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy);
        _target.Add(enemy);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy);
        _target.Remove(enemy);
    }

    private void Attack()
    {
        foreach (Enemy enemy in _target)
        {
            enemy.GetDamage(Managers.PlayerManager.Player.Status.Damage);
            enemy.Dead();
        }
    }
}