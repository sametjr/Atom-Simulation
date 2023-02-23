using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerRotate : MonoBehaviour
{
    [SerializeField] public float electronSpeed = 10f;
    [SerializeField] private Vector3 axis = Vector3.down;
    public bool isRotating = false;
    private void Update()
    {
        if(isRotating) transform.Rotate(axis * Time.deltaTime * electronSpeed);
    }
}
