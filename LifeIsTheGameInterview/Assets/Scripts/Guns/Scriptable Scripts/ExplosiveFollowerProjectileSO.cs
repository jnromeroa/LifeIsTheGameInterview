using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Explosive Follower Projectile", menuName = "Projectile/Explosive Follower Projectile")]
public class ExplosiveFollowerProjectileSO : ProjectileSO
{
    public float TargetFollowRadius;
    public float TargetFollowRotationSpeed;
    public float ExplosionForce;
    public float ExplosionRadius;
    public LayerMask TargetLayer;
    public GameObject ParticlesPrefab;
}
