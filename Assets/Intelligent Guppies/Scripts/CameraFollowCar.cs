using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowCar : MonoBehaviour
{
    /*[SerializeField] private Vector3 offset = new Vector3(0, 0.1f, -0.4f);
    [SerializeField] private Transform target;
    [SerializeField] private float translateSpeed = 5f;

    private void FixedUpdate()
    {
        HandleTranslation();
    }

    private void HandleTranslation()
    {
        var targetPosition = target.TransformPoint(offset);
        transform.position = Vector3.Lerp(transform.position, targetPosition, translateSpeed * Time.deltaTime);
    }*/

    /*public GameObject cameraTarget;
    public GameObject child;
    public float speed = 5f;

    void Awake()
    {
        cameraTarget = GameObject.Find("CAR");
        child = cameraTarget.transform.Find("Camera Constraint").gameObject;
    }

    void FixedUpdate()
    {
        Follow();
    }

    void Follow()
    {
        gameObject.transform.position = Vector3.Lerp(transform.position, child.transform.position, Time.deltaTime * speed);
        gameObject.transform.LookAt(cameraTarget.gameObject.transform.position);
    }*/

    public GameObject cameraTarget;
    //public GameObject child;
    //public float speed = 5f;
    public CarController _carController;

    void Start()
    {
        cameraTarget = GameObject.Find("CAR");
        _carController = cameraTarget.GetComponent<CarController>();
    }

    void FixedUpdate()
    {
        gameObject.transform.position = _carController.targetForCamera.transform.GetChild(0).transform.position;
        gameObject.transform.LookAt(_carController.targetForCamera.transform.GetChild(1).transform.position);
    }
}
