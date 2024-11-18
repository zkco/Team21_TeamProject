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
    public PlayerStatus Status;
    //public PlayerCondition Condition;
    //public Weapon weapon; //웨폰에서 작성
    //public Item curItem; //아이템에서 작성
    //public Inventory Inventory;

    private void Awake()
    {
        Controller = GetComponent<PlayerController>();
        Animator = GetComponent<Animator>();
        Renderer = GetComponentInChildren<SpriteRenderer>();
        WeaponPivot = GameObject.Find("WeaponPivot").transform;
        Rigidbody = GetComponent<Rigidbody2D>();
        Collider = GetComponent<Collider2D>();

        //Renderer.sprite = Status.PlayerSprite;
        Controller.Speed = Status.Speed;

    }
}
