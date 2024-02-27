using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explotion : MonoBehaviour
{
    [SerializeField]
    private float intensity;
    [SerializeField]
    private float radius;

    private void OnTriggerEnter(Collider other)
    {
        Debug.LogWarning("EXPLODING");
        other.attachedRigidbody.AddExplosionForce(intensity, transform.position, radius);
    }
}
