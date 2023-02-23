using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeutronMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private GameObject coreSphere;
    private Quaternion direction;
    private bool flag = true;

    private void Start()
    {

    }
    void Update()
    {

        // Debug.Log(Vector3.Magnitude(transform.position - coreSphere.transform.position) + " -- " + coreSphere.GetComponent<SphereCollider>().radius);
        if (Vector3.Magnitude(transform.position - coreSphere.transform.position) >= coreSphere.GetComponent<SphereCollider>().radius)
        {
            if (!flag)
            {
                transform.localRotation = GetRandomQuaternion();
                Debug.Log("Rotation Changed!");
                flag = true;
            }
        }
        
        if (flag)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            flag = false;
        }
    }

    private Quaternion GetRandomQuaternion()
    {
        Quaternion q = new Quaternion();
        q.x = Random.Range(150, 210) - transform.localRotation.x;
        q.y = transform.localRotation.y + Random.Range(-20, 20);
        q.z = transform.localRotation.z + Random.Range(-20, 20);
        // q.z = Random.Range(150, 210) - transform.localRotation.z; 
        q.y = transform.localRotation.y;
        q.z = transform.localRotation.z;
        q.w = 1;
        return q;
    }

}
