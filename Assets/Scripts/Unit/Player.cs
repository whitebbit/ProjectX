using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : Unit
{
    [SerializeField] private Transform camera;
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
        
    }

    private void Attack()
    {
        if (InputService.GetBinds()[Binds.Attack])
        {
            _ammunition.CurrentWeapon.PerformAttack();
            Debug.Log("Attack");
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
        bool input = InputService.GetBinds()[Binds.Jump];
        bool grounded = (transform.position + transform.up).IsGrounded(-transform.up, 2f);
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

    private void Initialize()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _rigidbody = GetComponent<Rigidbody>();
        _movement = new RigidbodyMove(_rigidbody);
        _rotate = new FirstPersonLookRotation(transform, camera);
        _jump = new RigidbodyJump(_rigidbody);
        _ammunition = new Ammunition(camera, weaponConfigs);
    }
}
