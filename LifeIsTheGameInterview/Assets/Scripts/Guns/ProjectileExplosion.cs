using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileExplosion : MonoBehaviour
{
    [SerializeField] 
    ExplosiveFollowerProjectileSO _projectileData;


    private void OnCollisionEnter(Collision collision)
    {
        if (((1 << collision.gameObject.layer) & _projectileData.TargetLayer) != 0)
        {
            Explosion explosion = Instantiate(_projectileData.ParticlesPrefab, transform.position, transform.rotation).GetComponent<Explosion>();
            explosion.Intensity = _projectileData.ExplosionForce;
            explosion.Radius = _projectileData.ExplosionRadius;
            Deactivate();
        }
    }

    private void Deactivate()
    {
        Destroy(this.gameObject);
    }
}
