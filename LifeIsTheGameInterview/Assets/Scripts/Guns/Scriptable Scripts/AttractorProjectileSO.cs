using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Attractor Projectile", menuName = "Projectile/Attractor Projectile")]
public class AttractorProjectileSO : ProjectileSO
{
    public float EffectRadius;
    public float EffectIntensity;
    public LayerMask EffectLayer;
}
