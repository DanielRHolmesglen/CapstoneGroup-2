using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(MeshCollider))]
public class ItemObstacle : MonoBehaviour
{
    private float currentCarSpeed;
    private float speedDown = 1f;

    void Start()
    {
        GetComponent<MeshCollider>().isTrigger = true;
    }

    public void OnTriggerEnter(Collider _other)
    {
        if (_other.gameObject.name == "Car")
        {
            Debug.Log("here.................................");
            SpeedDown(_other);
            gameObject.SetActive(false);
        }
    }

    void SpeedDown(Collider _car)
    {
        Car carSpeed = _car.GetComponent<Car>();

        currentCarSpeed = carSpeed.carSpeed;

        Debug.Log("currentCarSpeed");
        currentCarSpeed -= speedDown;
        carSpeed.carSpeed = currentCarSpeed;
    }
}
