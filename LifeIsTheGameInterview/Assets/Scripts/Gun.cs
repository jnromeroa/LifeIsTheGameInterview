using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour, IShootable, IDropable, IHiglightable, IGrabable
{
    [SerializeField] 
    GameObject _highlightGameObject;
    [SerializeField]
    GameObject _projectilePrefab;
    [SerializeField]
    Transform _projectileSpawner;
    public Vector3 OffsetRotation;

    Vector3 _originalPosition;
    Quaternion _originalRotation;
    
    public bool IsHighlighted { get; protected set; }

    private void Start()
    {
        _originalPosition = transform.position;
        _originalRotation = transform.rotation;
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
        Instantiate(_projectilePrefab, _projectileSpawner.position, transform.parent.rotation);
    }

    public void Drop()
    {
        Debug.Log($"succesfully dropped, {gameObject.name}");
        transform.parent = null;
        transform.position = _originalPosition;
        transform.rotation = _originalRotation;
    }

    public void Grab()
    {
        throw new System.NotImplementedException();
    }
}
