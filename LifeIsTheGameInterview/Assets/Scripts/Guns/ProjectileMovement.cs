using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    [SerializeField] protected ProjectileSO _projectileData;
    protected Rigidbody _rb;
    protected Transform _t;
    private float _time = 0;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _t = transform;
        _rb.velocity = _t.forward * _projectileData.Speed;
        Destroy(this.gameObject, _projectileData.LifeTimeSeconds);
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
        if (_projectileData.ApplyGravity) return;
        _rb.velocity = _t.forward * _projectileData.Speed;
    }


}
