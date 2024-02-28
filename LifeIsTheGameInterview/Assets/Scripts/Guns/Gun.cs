using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour, IShootable, IDropable, IHiglightable, IGrabable
{
    public GunSO GunData;

    [SerializeField] 
    GameObject _highlightGameObject;
    [SerializeField]
    Transform _projectileSpawner;

    Vector3 _originalPosition;
    Quaternion _originalRotation;

    private float _shootCooldownTime = 0;

    public bool IsHighlighted { get; protected set; }

    private void Start()
    {
        _highlightGameObject.SetActive(false);
        _originalPosition = transform.position;
        _originalRotation = transform.rotation;
    }
    private void Update()
    {
        _shootCooldownTime += Time.deltaTime;
    }

    public void Highlight()
    {
        if (IsHighlighted) return;
        _highlightGameObject.SetActive(true);
        IsHighlighted = true;
    }


    public void Unhighlight()
    {
        if (!IsHighlighted) return;
        _highlightGameObject.SetActive(false);
        IsHighlighted = false;
    }

    public virtual void Shoot()
    {
        if (_shootCooldownTime < 1 / GunData.fireCadence) return;
         Instantiate(GunData.ProjectilePrefab, _projectileSpawner.position, transform.parent.rotation);
        _shootCooldownTime = 0;
    }

    public void Drop()
    {
        transform.parent = null;
        transform.position = _originalPosition;
        transform.rotation = _originalRotation;
    }

    public void Grab()
    {
        
    }
}
