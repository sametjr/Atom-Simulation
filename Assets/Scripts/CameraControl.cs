using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Transform coreTransform;
    public float speedH = 2.0f;
    public float speedV = 2.0f;
    private float yaw = 0.0f;
    private float pitch = 0.0f;
    void Update()
    {
        if (Input.GetKey(KeyCode.D)) transform.Translate(speed * Time.deltaTime, 0, 0);
        if (Input.GetKey(KeyCode.A)) transform.Translate(-speed * Time.deltaTime, 0, 0);
        if (Input.GetKey(KeyCode.W)) transform.Translate(0, 0, speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.S)) transform.Translate(0, 0, -speed * Time.deltaTime);
        // if(Input.GetKey(KeyCode.X)) transform.Translate(-speed * Time.deltaTime, 0, 0);
        // if(Input.GetKey(KeyCode.C)) transform.Translate(-speed * Time.deltaTime, 0, 0);
        // if(Input.GetKey(KeyCode.DownArrow)) transform.Rotate(new Vector3(.3f, 0, 0), Space.World);
        // if(Input.GetKey(KeyCode.UpArrow)) transform.Rotate(new Vector3(-.3f, 0, 0), Space.World);

        // if(Input.GetKey(KeyCode.LeftArrow)) transform.Rotate(new Vector3(0, -.3f, 0), Space.World);
        // if(Input.GetKey(KeyCode.RightArrow)) transform.Rotate(new Vector3(0, .3f, 0), Space.World);


        if (Input.GetMouseButton(0))
        {
            yaw += speedH * Input.GetAxis("Mouse X");
            pitch -= speedV * Input.GetAxis("Mouse Y");
            transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        }
    }
}
