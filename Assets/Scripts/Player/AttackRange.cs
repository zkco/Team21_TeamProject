using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackRange : MonoBehaviour
{
    private Collider2D _collider;
    private List<Enemy> _target;

    private void Start()
    {
        Managers.PlayerManager.Player.Controller.AttackAction += Attack;
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
            enemy.HP -= Managers.PlayerManager.Player.Status.Damage;
        }
    }
}