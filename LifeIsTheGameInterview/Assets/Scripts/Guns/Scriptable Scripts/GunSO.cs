using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Gun", menuName = "Gun/Generic Gun")]
public class GunSO : ScriptableObject
{
    public float fireCadence;
    public GameObject ProjectilePrefab;
    public Vector3 OffsetRotation;
}
