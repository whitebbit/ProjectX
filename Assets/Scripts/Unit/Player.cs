using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : Unit
{
    [Header("Player")]
    [SerializeField] private Transform head;
    [SerializeField] private Transform weaponSpawnPoint;
    [Space]
    [SerializeField] private List<WeaponConfig> weaponConfigs = new List<WeaponConfig>();
    private IMoveble _movement;
    private IRotatable _rotate;
    private IJumpble _jump;
    private Ammunition _ammunition;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        Initialize();
    }

    private void Update()
    {
        Rotate();
        Jump();
        Attack();
        SwitchWeapon();
    }

    private void Attack()
    {
        if (InputService.GetBoolBinds()[Binds.Attack])
        {
            _ammunition.CurrentWeapon.PerformAttack();
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Jump()
    {
        if (ReadyForJump())
            _jump.Jump(Config.JumpForce);
    }

    private bool ReadyForJump()
    {
        bool input = InputService.GetBoolBinds()[Binds.Jump];
        bool grounded = (transform.position + transform.up).IsGrounded(-transform.up, 1.25f);
        return input && grounded;
    }
    
    private void Move()
    {
        Vector2 axis = InputService.GetMovementAxis();
        Vector3 direction = new Vector3(axis.x, 0, axis.y);
        _movement.Move(transform.TransformDirection(direction), Config.Speed);
    }

    private void Rotate()
    {
        _rotate.Rotate(InputService.GetCameraRotationAxis(), 1);
    }

    private void SwitchWeapon()
    {
        float scroll = InputService.GetFloatBinds()[Binds.SwitchWeapon];
        if(scroll != 0 )
            _ammunition.SwitchWeapon(scroll);
    }
    private void Initialize()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _rigidbody = GetComponent<Rigidbody>();
        _movement = new RigidbodyMove(_rigidbody);
        _rotate = new FirstPersonLookRotation(transform, head);
        _jump = new RigidbodyJump(_rigidbody);
        _ammunition = new Ammunition(weaponConfigs, weaponSpawnPoint);
    }
}
