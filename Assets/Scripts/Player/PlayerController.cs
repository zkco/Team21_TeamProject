using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;

public class PlayerController : MonoBehaviour
{
    private readonly WaitForSeconds wait = new WaitForSeconds(0.45f);

    public event Action AttackAction;
    public event Action PlayerDead;

    public Player Player;
    private Animator _animator;
    private Camera _cam;
    private Collider2D _collider;

    //캐릭터 반전 관련 옵션(Look)
    private Vector2 _mousePos;

    //이동 관련 옵션
    public float JumpPower;
    private float _moveDir;
    private bool _canMove;

    //점프 관련 옵션
    public LayerMask Platform;
    private bool _downJump;

    //공격 관련
    private float _lastAttackTime;
    private float _lastDamagedTime;

    private void Awake()
    {
        _cam = Camera.main;
        Player = GetComponentInParent<Player>();
    }

    private void Start()
    {
        _collider = Player.Collider;
        _animator = Player.Animator;
        AttackAction += AttackAnim;
        StartCoroutine(CoPlayerChecker());
        _canMove = true;
    }

    private void Update()
    {
        _lastAttackTime += Time.deltaTime;
        _lastDamagedTime += Time.deltaTime;
        Debug.DrawRay(new Vector2(Player.transform.position.x, Player.transform.position.y - 1), Vector2.up * 1.5f, Color.red);
        Debug.DrawRay(new Vector2(Player.transform.position.x - 0.5f, Player.transform.position.y), Vector2.right, Color.red);
        Debug.DrawRay(new Vector2(Player.transform.position.x, Player.transform.position.y - 0.8f), Vector2.up * 1.4f, Color.red, 1f);
    }

    private void AttackAnim()
    {
        _animator.SetTrigger("Attacking");
        _lastAttackTime = 0;
    }

    private void FixedUpdate()
    {
        if(_canMove == true)
        {
            Move();
            Look();
            CameraMove();
        }
    }

    private IEnumerator CoPlayerChecker()
    {
        while (true)
        {
            if (Player.Rigidbody.velocity.y > 0 && IsPassable() == true)
            {
                _collider.isTrigger = true;
            }
            else if (_downJump == true)
            {
                _animator.SetBool("Falling", true);
                yield return wait;
                _downJump = false;
            }
            else if (Player.Rigidbody.velocity.y < -1 && _downJump == false)
            {
                _animator.SetBool("Falling", true);
                _collider.isTrigger = false;
            }
            else
            {
                _animator.SetBool("Falling", false);
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
        if (context.phase == InputActionPhase.Started 
            && _canMove == true)
        {
            Jump();
            Managers.PlayerManager.EnemyPool.SpawnWithStagePosition(1);
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started 
            && _lastAttackTime >= Player.Status.AttackRate 
            && _canMove == true)
        {
            _lastAttackTime = 0f;
            AttackAction?.Invoke();
        }
    }

    public void OnDown(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started 
            && _canMove == true)
        {
            DownJump();
        }
    }

    private void DownJump()
    {
        if (OnGround() == true 
            && OnPlatform() == true)
        {
            Player.Collider.isTrigger = true;
            _downJump = true;
        }
    }

    private bool OnGround()
    {
        //Todo : 캐릭터 스프라이트 정해지고 나서 레이 갯수를 늘려서 스프라이트 끝에서 끝까지
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(Player.transform.position.x, Player.transform.position.y - 1f), Vector2.down, 0.3f);

        if (hit.collider?.gameObject != null)
        {
            return true;
        }
        else return false;
    }

    private bool OnPlatform()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(Player.transform.position.x, Player.transform.position.y - 1f), Vector2.down, 0.3f);

        if (hit.collider?.gameObject.layer == 7)
        {
            return true;
        }
        else return false;
    }

    private bool IsPassable()
    {
        RaycastHit2D[] detector =
            {
                Physics2D.Raycast(new Vector2(Player.transform.position.x, Player.transform.position.y - 0.8f), Vector2.up, 1.4f, Platform),
                Physics2D.Raycast(new Vector2(Player.transform.position.x - 0.5f, Player.transform.position.y), Vector2.right, 1f, Platform)
            };
        bool passable = false;
        for (int i = 0; i < detector.Length; i++)
        {
            if (detector[i].collider?.gameObject.layer == 7)
            {
                passable = true;
            }
        }
        return passable;
    }


    private void Move()
    {
        if (_moveDir != 0)
        {
            _animator.SetBool("Running", true);
            Vector2 dir = new Vector2(_moveDir * Player.Status.Speed, Player.Rigidbody.velocity.y);
            Player.Rigidbody.velocity = dir;
        }
        else
        {
            _animator.SetBool("Running", false);
            Vector2 dir = new Vector2(0, Player.Rigidbody.velocity.y);
            Player.Rigidbody.velocity = dir;
        }
        if (OnGround())
        {
            _animator.SetBool("Falling", false);
        }
        Player.Rigidbody.velocity = new Vector2(Player.Rigidbody.velocity.x, Mathf.Clamp(Player.Rigidbody.velocity.y, -10, 10));
    }

    private void Jump()
    {
        if (OnGround() == true)
        {
            Player.Rigidbody.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
        }
    }

    private void Look()
    {
        _mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
        if (_mousePos.x > Player.transform.position.x)
        {
            Player.Renderer.flipX = false;
            Player.WeaponPivot.transform.position = new Vector2(Player.transform.position.x + 1f, Player.transform.position.y);
        }
        else
        {
            Player.Renderer.flipX = true;
            Player.WeaponPivot.transform.position = new Vector2(Player.transform.position.x - 1f, Player.transform.position.y);
        }
    }

    private void CameraMove()
    {
        float Z = -10f;
        Vector3 TargetPosition = Player.transform.position;
        TargetPosition.y = Player.transform.position.y + 2f;
        TargetPosition.z = Z;
        _cam.transform.position = Vector3.Lerp(_cam.transform.position, TargetPosition, Time.deltaTime * 3f);
    }

    //피격 구현 시 구독
    public void GetDamage(int damage)
    {
        if(_lastDamagedTime > 1 && _canMove == true)
        {
            _lastDamagedTime = 0;
            _animator.SetTrigger("Hitted");
            Player.Status.Hp -= damage;
        }
        Dead();
    }

    private void Dead()
    {
        if (Player.Status.Hp <= 0)
        {
            _animator.SetTrigger("Dead");
            PlayerDead?.Invoke();
            Managers.PlayerManager.EnemyPool.DeSpawnAllEnemy();
            _canMove = false;
        }
    }
}
