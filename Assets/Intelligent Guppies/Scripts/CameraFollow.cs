using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform cameraTarget;
    private Vector3 cameraOffset;

    void Start()
    {
        cameraTarget = GameObject.Find("Player").transform;
        cameraOffset = transform.position - cameraTarget.position;
    }

    void Update()
    {
        Vector3 cameraPosition = new Vector3(transform.position.x, transform.position.y, 
            cameraOffset.z + cameraTarget.position.z);
        transform.position = cameraPosition;
    }

    /*
    //private Vector3 offset = new Vector3(0, 0.1f, -0.4f);
    public Vector3 offset;
    private Transform target;
    //public float speed = 25f;
    public GameObject cameraTarget;
    private Car _car;
    private float cameraFollowingSpeed;

    void Start()
    {
        //cameraTarget = GameObject.Find("Player");
        //_car = cameraTarget.GetComponent<Car>();
        _car = GameObject.Find("Player").GetComponentInChildren<Car>();
        //cameraTarget = GameObject.Find("Player");
    }

    void FixedUpdate()
    {
        //cameraTarget.transform.position = transform.TransformPoint(offset);
        cameraFollowingSpeed = _car.carSpeed;
        gameObject.transform.position = transform.position + new Vector3(0, 0, Time.deltaTime * cameraFollowingSpeed);

    }
    */
}
