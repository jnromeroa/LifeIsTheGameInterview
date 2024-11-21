using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveFollowerProjectileMovement : ProjectileMovement
{
    bool isFollowing = false;
    private void OnEnable()
    {
        Invoke(nameof(StartFollowing), 1f);
    }
    protected override void HandleMovement()
    {
        _rb.velocity = new Vector3(_t.forward.x * _projectileData.Speed, _rb.velocity.y, _t.forward.z * _projectileData.Speed);
    }
    protected override void HandleRotation()
    {
        if (!isFollowing) return;
        Vector3? target = CheckSurroundingsForTarget();
        if (target == null) return;
        Vector3 positionToLookAt = (target.Value - _t.position).normalized;
        Quaternion currentRotation = _t.rotation;
        Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
        _rb.rotation = Quaternion.Slerp(currentRotation, targetRotation, (_projectileData as ExplosiveFollowerProjectileSO).TargetFollowRotationSpeed * Time.deltaTime);
    }
    void StartFollowing()
    {
        isFollowing = true;
    }
    

    private Vector3? CheckSurroundingsForTarget()
    {
        Collider[] results = new Collider[1];
        if (Physics.OverlapSphereNonAlloc(_t.position, (_projectileData as ExplosiveFollowerProjectileSO).TargetFollowRadius, results, (_projectileData as ExplosiveFollowerProjectileSO).TargetLayer) < 1) return null;        
        return results[0].transform.position;
    }
}
