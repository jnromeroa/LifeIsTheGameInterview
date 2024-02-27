using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    [SerializeField]
    protected float _speed = 5f;
    protected Rigidbody _rb;
    protected Transform _t;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _t = transform;
        _rb.velocity = _t.forward * _speed;
    }


    void Update()
    {
        HandleMovement();
        HandleRotation();
    }

    protected virtual void HandleRotation()
    {
    }

    protected virtual void HandleMovement()
    {
        _rb.velocity = _t.forward * _speed;
    }
}
