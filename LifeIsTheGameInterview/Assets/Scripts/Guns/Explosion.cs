using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float Intensity;
    public float Radius;

    private void OnTriggerEnter(Collider other)
    {
        other.attachedRigidbody.AddExplosionForce(Intensity, transform.position, Radius);
    }
}
