using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private float _mouseSensitivity = 100f;
    [SerializeField]
    private Transform _cameraTransform;
    private Transform _t;




    float rotacionX = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _t = transform;
    }

    void Update()
    {
        float movimientoHorizontal = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
        float movimientoVertical = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;

        _t.Rotate(Vector3.up * movimientoHorizontal);

        rotacionX -= movimientoVertical;
        rotacionX = Mathf.Clamp(rotacionX, -90f, 90f);

        _cameraTransform.localRotation = Quaternion.Euler(rotacionX, 0f, 0f);
    }
}

