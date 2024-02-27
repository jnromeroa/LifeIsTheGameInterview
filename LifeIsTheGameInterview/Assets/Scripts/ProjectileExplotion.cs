using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileExplotion : MonoBehaviour
{
    [SerializeField]
    private GameObject _particlesPrefab;
    [SerializeField]
    private LayerMask _targetLayer;

    private void OnCollisionEnter(Collision collision)
    {
        if (((1 << collision.gameObject.layer) & _targetLayer) != 0)
        {
            Instantiate(_particlesPrefab, transform.position, transform.rotation);
            Deactivate();
        }
    }

    private void Deactivate()
    {
        Destroy(this.gameObject);
    }
}
