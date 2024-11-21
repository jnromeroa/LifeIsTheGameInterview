using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeIncreaser : MonoBehaviour
{
    private Transform _t;
    [SerializeField]
    private float _lerpTime;
    private float _elapsedTime = 0;
    private void Start()
    {
        _t = transform;
    }
    void Update()
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime >= _lerpTime) return;
        _t.localScale = Vector3.Lerp(Vector3.zero, Vector3.one*1.5f, _elapsedTime/ _lerpTime);
    }
}
