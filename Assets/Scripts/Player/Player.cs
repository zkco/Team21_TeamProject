using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator Animator;
    public SpriteRenderer Renderer;
    public PlayerController Controller;
    public Transform WeaponPivot;
    public Rigidbody2D Rigidbody;
    public Collider2D Collider;
    //public PlayerCondition Condition;
    //public Weapon weapon;
    //public Item curItem;
    //public Inventory Inventory;

    private void Awake()
    {
        Controller = GetComponent<PlayerController>();
        Animator = GetComponent<Animator>();
        Renderer = GetComponentInChildren<SpriteRenderer>();
        WeaponPivot = GameObject.Find("WeaponPivot").transform;
        Rigidbody = GetComponent<Rigidbody2D>();
        Collider = GetComponent<Collider2D>();
    }
}
