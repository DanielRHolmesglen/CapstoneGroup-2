using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class ResetCarSpeed : MonoBehaviour
{
    private float carOriginalSpeed, carCurrentSpeed, carSpeedChanged;

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
        Car carSpeed = _car.GetComponent<Car>();
        carCurrentSpeed = carSpeed.carSpeed;
        carSpeedChanged = carSpeed.speedChanged;
        Debug.Log("[Reset] current speed = " + carCurrentSpeed);

        if (carCurrentSpeed > 25)
        {
            carCurrentSpeed -= carSpeedChanged;
            Debug.Log("[Reset] current new speed = " + carCurrentSpeed);
            carSpeed.carSpeed = carCurrentSpeed;
        }
        else if (carCurrentSpeed < 25)
        {
            carCurrentSpeed += carSpeedChanged;
            Debug.Log("[Reset] current new speed = " + carCurrentSpeed);
            carSpeed.carSpeed = carCurrentSpeed;
        }
    }
}
