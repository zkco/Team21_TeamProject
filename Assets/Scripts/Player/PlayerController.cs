using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;

public class PlayerController : MonoBehaviour
{
    private readonly int _platformLayerToHash = "Platform".GetHashCode();

    public event Action AttackAction;

    private Camera _cam;

    //캐릭터 반전 관련 옵션(Look)
    private Vector2 _mousePos;

    //이동 관련 옵션
    public float Speed;
    public Player Player;

    private float _moveDir;

    //점프 관련 옵션
    public LayerMask Platform;

    private bool _isJumping;


    private void Awake()
    {
        _cam = Camera.main;
        Player = GetComponentInParent<Player>();
    }

    private void FixedUpdate()
    {
        Move();
        Look();
        CameraMove();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveDir = context.ReadValue<float>();
        
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            Jump();
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            AttackAction?.Invoke();
        }
    }

    private bool OnGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(Player.transform.position, Vector2.down, 2f, Platform);
        if (hit.collider.gameObject.layer == 7)
        {
            return true;
        }
        else return false;
    }

    private void Move()
    {
        if (_moveDir > 0)
        {
            Player.Rigidbody.velocity = Speed * Vector2.right;
        }
        else if (_moveDir < 0)
        {
            Player.Rigidbody.velocity = Speed * Vector2.left;
        }
        else
        {
            Player.Rigidbody.velocity = Speed * Vector2.zero;
        }
    }

    private void Jump()
    {
        if (OnGround() == true)
        {
            Player.Rigidbody.AddForce(Vector3.up * 30, ForceMode2D.Impulse);
            Debug.Log("점프가 문제요");
        }
    }

    private void Look()
    {
        _mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
        if (_mousePos.x > Player.transform.position.x)
        {
            Player.Renderer.flipX = false;
        }
        else
        {
            Player.Renderer.flipX = true;
        }
    }

    private void CameraMove()
    {
        float Z = -10f;
        Vector3 TargetPosition = Player.transform.position;
        TargetPosition.z = Z;
        _cam.transform.position = Vector3.Lerp(_cam.transform.position, TargetPosition, Time.deltaTime * 2);
    }
}
