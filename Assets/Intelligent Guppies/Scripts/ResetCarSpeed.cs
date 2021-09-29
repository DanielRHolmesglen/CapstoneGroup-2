using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class ResetCarSpeed : MonoBehaviour
{
    private float carOriginalSpeed, carCurrentSpeed, carSpeedChanged;

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
        carOriginalSpeed = carSpeed.forwardSpeed;
        carCurrentSpeed = carSpeed.forwardSpeed;
        carSpeedChanged = carSpeed.speedChanged;
        Debug.Log("[Reset] current speed = " + carCurrentSpeed);

        if (carCurrentSpeed > carOriginalSpeed)
        {
            carCurrentSpeed -= carSpeedChanged;
            Debug.Log("[Reset] current new speed = " + carCurrentSpeed);
            carSpeed.forwardSpeed = carCurrentSpeed;
        }
        else if (carCurrentSpeed < carOriginalSpeed)
        {
            carCurrentSpeed += carSpeedChanged;
            Debug.Log("[Reset] current new speed = " + carCurrentSpeed);
            carSpeed.forwardSpeed = carCurrentSpeed;
        }
    }
}
