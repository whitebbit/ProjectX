using System;
using System.Collections;
using System.Collections.Generic;
using Movements;
using UnityEngine;

public class Player : Unit
{
    [SerializeField] private Transform camera;
    private IMoveble _movement;
    private IRotatable _rotate;
    private Rigidbody _rigidbody;
    private void Awake()
    {
        Initialize();
    }

    private void Update()
    {
        Rotate();
    }
    
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector2 axis = InputService.GetMoveAxis();
        Vector3 direction = new Vector3(axis.x, 0, axis.y);
        _movement.Move(transform.TransformDirection(direction), Config.Speed);
    }

    private void Rotate()
    {
        _rotate.Rotate(InputService.GetRotateAxis(), 1);
    }

    private void Initialize()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _rigidbody = GetComponent<Rigidbody>();
        _movement = new RigidbodyMove(_rigidbody);
        _rotate = new FirstPersonLookRotation(transform, camera);
    }
}
