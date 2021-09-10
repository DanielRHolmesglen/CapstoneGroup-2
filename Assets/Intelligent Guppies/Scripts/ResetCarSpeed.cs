using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class ResetCarSpeed : MonoBehaviour
{
    private float speedChanged = 500f;
    private float carCurrentSpeed;
    void Start()
    {
        GetComponent<BoxCollider>().isTrigger = true;
    }

    public void OnTriggerEnter(Collider _other)
    {
        if (_other.gameObject)
        {
            ResetSpeed(_other);
            gameObject.SetActive(false);
        }
    }

    void ResetSpeed(Collider _car)
    {
        CarController carControllerAccessd = _car.GetComponent<CarController>();
        carCurrentSpeed = carControllerAccessd.motorForce;
        Debug.Log("Current speed = " + carCurrentSpeed);

        if (carCurrentSpeed > 300)
        {
            carCurrentSpeed -= speedChanged;
            Debug.Log("current new speed = " + carCurrentSpeed);
            carControllerAccessd.motorForce = carCurrentSpeed;
        }
        else if (carCurrentSpeed < 300)
        {
            carCurrentSpeed += speedChanged;
            Debug.Log("current new speed = " + carCurrentSpeed);
            carControllerAccessd.motorForce = carCurrentSpeed;
        }
    }
}
