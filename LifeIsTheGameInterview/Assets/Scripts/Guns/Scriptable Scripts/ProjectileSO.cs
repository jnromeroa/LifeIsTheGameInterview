using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Projectile", menuName = "Projectile/Generic Projectile")]
public class ProjectileSO : ScriptableObject
{
    public float Speed;
    public float LifeTimeSeconds;
    public bool ApplyGravity;


}
