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

    private void PlayerFlip(bool flipx)
    {
        if(flipx == true)
        {

        }
    }

    private void Attack()
    {
        if (_target == null) return;
        foreach (Enemy enemy in _target)
        {
            enemy.Controller.GetDamage(Managers.PlayerManager.Player.Status.Damage);
        }
    }
}