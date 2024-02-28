using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    [SerializeField]
    AttractorProjectileSO _projectileData;
    private Transform _t;
    private Collider[] _colliders = new Collider[5];
    

    private void Start()
    {
        _t = transform;
    }
    private void Update()
    {
        Attract();   
    }
    
    private void Attract()
    {
        if (Physics.OverlapSphereNonAlloc(_t.position, _projectileData.EffectRadius, _colliders, _projectileData.EffectLayer) < 1) return;
        foreach (var collider in _colliders)
        {
            if (collider == null) continue;
            Vector3 attractionVector = (collider.attachedRigidbody.position - _t.position).normalized;
            collider.attachedRigidbody.AddForce(_projectileData.EffectIntensity * -attractionVector, ForceMode.Acceleration);
        }
    }

}
