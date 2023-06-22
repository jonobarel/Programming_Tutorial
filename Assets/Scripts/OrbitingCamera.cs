using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class OrbitingCamera : MonoBehaviour
{
    [SerializeField] Transform focusTarget;
    [SerializeField] private Vector3 relPositionLocal;
    [Tooltip("degrees per second")]
    [SerializeField] private float rotationSpeed;

    public float RotationSpeed
    {
        get => rotationSpeed;
        set => rotationSpeed = value;
    }
    
    void Start()
    {
        
        Vector3 relPositionGlobal = transform.position-focusTarget.position;
        relPositionLocal = transform.InverseTransformVector(relPositionGlobal);
        
    }

    void LateUpdate()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
        Vector3 worldPosition = transform.TransformVector(relPositionLocal);
        transform.position = focusTarget.position + worldPosition;
        
    }
    
}
