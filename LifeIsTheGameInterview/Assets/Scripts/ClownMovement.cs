using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClownMovement : ProjectileMovement
{

    [SerializeField]
    private float _targetCheckRadius = 5;
    [SerializeField]
    private LayerMask _targetLayer;
    [SerializeField]
    private float _rotationSpeed = 5;



    protected override void HandleMovement()
    {
        _rb.velocity = new Vector3(_t.forward.x * _speed, _rb.velocity.y, _t.forward.z * _speed);
    }
    protected override void HandleRotation()
    {
        Vector3? target = CheckSurroundingsForTarget();
        if ( target == null) return;
        Vector3 positionToLookAt = (target.Value - _t.position).normalized;
        Quaternion currentRotation = _t.rotation;
        Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
        _rb.rotation = Quaternion.Slerp(currentRotation,targetRotation, _rotationSpeed * Time.deltaTime);
    }

    

    private Vector3? CheckSurroundingsForTarget()
    {
        Collider[] results = new Collider[1];
        if (Physics.OverlapSphereNonAlloc(_t.position, _targetCheckRadius, results, _targetLayer) < 1) return null;        
        Debug.Log(results);
        return results[0].transform.position;
    }
}
