using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class AttackRange : MonoBehaviour
{
    private Collider2D _collider;
    [SerializeField] private List<Enemy> _target;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }

    private void Start()
    {
        Managers.PlayerManager.Player.Controller.AttackAction += Attack;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        _target.Add(enemy);
        return;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        foreach (Enemy listEnemy in _target)
        {
            if(collision.gameObject.TryGetComponent<Enemy>(out Enemy detectedEnemy))
            {
                if(listEnemy == detectedEnemy)
                {
                    _target.Remove(detectedEnemy);
                    return;
                }
                if(listEnemy == null)
                {
                    _target.Remove(listEnemy);
                }
            }
        }
    }

    private void Attack()
    {
        if (_target == null) return;
        else
        {
            foreach (Enemy enemy in _target)
            {
                if (_target.Count < 1) return;
                enemy?.Controller.GetDamage(Managers.PlayerManager.Player.Status.Damage);
            }
        }
       
    }
}