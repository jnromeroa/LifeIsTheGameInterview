using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionHandler : MonoBehaviour
{
    private Camera _mainCamera;
    [SerializeField] LayerMask _interactableLayer;
    [SerializeField] Image _pointer;
    [SerializeField] Transform _holdTransform;
    IHiglightable _lastHighlighted;
    IDropable _lastInteracted;
    IShootable _currentlyHoldingShootable;
    bool _isPointerRed;
    private void Start()
    {
        _mainCamera = Camera.main;
    }
    private void Update()
    {
        GameObject collidedWithRay = CreateRay();

        if (Input.GetMouseButtonDown(1) && collidedWithRay != null)
        {
            
            Grab(collidedWithRay);
        }

        if(Input.GetMouseButton(0) && _currentlyHoldingShootable != null)
        {
            _currentlyHoldingShootable.Shoot();
        }

    }

    private GameObject CreateRay()
    {
        GameObject collidedWithRay = null;
        Ray ray = _mainCamera.ScreenPointToRay(new Vector3(_mainCamera.pixelWidth / 2, _mainCamera.pixelHeight / 2, 0));
        Debug.DrawRay(ray.origin, ray.direction * 50, Color.red);
        RaycastHit hit;
        if (!Physics.Raycast(ray, out hit, Mathf.Infinity, _interactableLayer))
        {
            if (!_isPointerRed) return collidedWithRay;
            _pointer.color = Color.white;
            _isPointerRed = false;
            _lastHighlighted.Unhighlight();
            _lastHighlighted = null;
            return collidedWithRay;
        }
        if (!_isPointerRed)
        {
            _pointer.color = Color.red;
            _isPointerRed = true;
            _lastHighlighted = hit.collider.GetComponent<IHiglightable>();
            _lastHighlighted.Highlight();
        }
        collidedWithRay = hit.collider.gameObject;
        return collidedWithRay;
    }
    private void Grab(GameObject interactedGO)
    {
        if (_lastInteracted != null) Drop();
        interactedGO.transform.parent = _holdTransform;
        interactedGO.transform.localPosition = Vector3.zero;
        interactedGO.transform.localRotation = Quaternion.Euler(interactedGO.GetComponent<Gun>().GunData.OffsetRotation);
        _lastInteracted = interactedGO.GetComponent<IDropable>();
        _currentlyHoldingShootable = interactedGO.GetComponent<IShootable>();
    }
    private void Drop()
    {
        _lastInteracted.Drop();
        _lastInteracted = null;
        _currentlyHoldingShootable = null;
    }
}
