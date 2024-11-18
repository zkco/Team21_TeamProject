using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;

public class PlayerController : MonoBehaviour
{
    private readonly WaitForSeconds wait = new WaitForSeconds(0.5f);

    public event Action AttackAction;
    public Player Player;
    private Camera _cam;

    //캐릭터 반전 관련 옵션(Look)
    private Vector2 _mousePos;

    //이동 관련 옵션
    public float Speed;
    public float JumpPower;
    private float _moveDir;

    //점프 관련 옵션
    public LayerMask Platform;
    private bool _downJump;


    private void Awake()
    {
        _cam = Camera.main;
        Player = GetComponentInParent<Player>();
    }

    private void Start()
    {
        StartCoroutine(CoPlayerChecker());
    }

    private void FixedUpdate()
    {
        Move();
        Look();
        CameraMove();
        Debug.DrawRay(Player.transform.position, Vector2.down, Color.red);
    }

    private IEnumerator CoPlayerChecker()
    {
        while (true)
        {
            if (Player.Rigidbody.velocity.y > 0)
            {
                Player.Collider.isTrigger = true;
            }
            else if (_downJump == true)
            {
                yield return wait;
                _downJump = false;
            }
            else if (Player.Rigidbody.velocity.y < 0 && _downJump == false)
            {
                Player.Collider.isTrigger = false;
            }
            yield return null;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveDir = context.ReadValue<float>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && OnGround() == true)
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

    public void OnDown(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            DownJump();
        }
    }

    private void DownJump()
    {
        Player.Collider.isTrigger = true;
        _downJump = true;
    }

    private bool OnGround()
    {
        //Todo : 캐릭터 스프라이트 정해지고 나서 레이 갯수를 늘려서 스프라이트 끝에서 끝까지
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(Player.transform.position.x, Player.transform.position.y - 0.5f), Vector2.down, 0.2f, Platform);

        if (hit.collider?.gameObject.layer == 7)
        {
            return true;
        }
        else return false;
    }

    private void Move()
    {
        if (_moveDir != 0)
        {
            Vector2 dir = new Vector2(_moveDir * Speed, Player.Rigidbody.velocity.y);
            Player.Rigidbody.velocity = dir;
        }
        else
        {
            Vector2 dir = new Vector2(0, Player.Rigidbody.velocity.y);
            Player.Rigidbody.velocity = dir;
        }
    }

    private void Jump()
    {
        Player.Rigidbody.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
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
