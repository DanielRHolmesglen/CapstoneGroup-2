using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class ResetCarSpeed : MonoBehaviour
{
    private float carCurrentSpeed, carSpeedChanged;

    void Start()
    {
        //_car = gameObject.GetComponent<Car>();
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
        Car carSpeed = _car.GetComponent<Car>();
        carCurrentSpeed = carSpeed.motorForce;
        carSpeedChanged = carSpeed.speedChanged;
        Debug.Log("[Reset] current speed = " + carCurrentSpeed);

        if (carCurrentSpeed > 300)
        {
            carCurrentSpeed -= carSpeedChanged;
            Debug.Log("[Reset] current new speed = " + carCurrentSpeed);
            carSpeed.motorForce = carCurrentSpeed;
        }
        else if (carCurrentSpeed < 300)
        {
            carCurrentSpeed += carSpeedChanged;
            Debug.Log("[Reset] current new speed = " + carCurrentSpeed);
            carSpeed.motorForce = carCurrentSpeed;
        }
    }
}
