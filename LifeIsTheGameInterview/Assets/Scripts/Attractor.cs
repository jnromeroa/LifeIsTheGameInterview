using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    [SerializeField]
    private float _effectRadius;
    [SerializeField]
    private LayerMask _targetLayer;
    [SerializeField]
    private float _intensity;
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
        if (Physics.OverlapSphereNonAlloc(_t.position, _effectRadius, _colliders, _targetLayer) < 1) return;
        foreach (var collider in _colliders)
        {
            if (collider == null) continue;
            Debug.Log(collider);
            Vector3 attractionVector = (collider.attachedRigidbody.position - _t.position).normalized;
            collider.attachedRigidbody.AddForce(_intensity * -attractionVector, ForceMode.Acceleration);
        }
    }

}
