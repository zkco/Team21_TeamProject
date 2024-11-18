using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Player : MonoBehaviour
{
    public SpriteRenderer Renderer;
    public PlayerController Controller;
    public Transform WeaponPivot;
    public Rigidbody2D Rigidbody;
    public Collider2D Collider;
    public PlayerStatus Status;
    public Animator Animator;
    //public PlayerCondition Condition;
    //public Weapon weapon; //�������� �ۼ�
    //public Item curItem; //�����ۿ��� �ۼ�
    //public Inventory Inventory;

    private void Awake()
    {
        Managers.PlayerManager.Player = this;
        Controller = GetComponent<PlayerController>();
        Renderer = GetComponentInChildren<SpriteRenderer>();
        WeaponPivot = GameObject.Find("WeaponPivot").transform;
        Rigidbody = GetComponent<Rigidbody2D>();
        Collider = GetComponent<Collider2D>();
        Animator = GetComponentInChildren<Animator>();
        //Renderer.sprite = Status.PlayerSprite;
    }
}
