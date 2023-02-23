using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectronRotate : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] Vector3 axis = Vector3.up;

    private void Update()
    {
        transform.RotateAround(transform.parent.transform.position, axis, rotationSpeed * Time.deltaTime);
    }
}
