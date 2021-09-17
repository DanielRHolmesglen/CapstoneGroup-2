using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]

public class CarSpeedSetUp : MonoBehaviour
{
    public GameObject speedChangedEffect;
    private float carCurrentSpeed, carSpeedChanged;
    private WaitForSeconds timeBeforeReverseBack = new WaitForSeconds(4f);

    void Start()
    {
        GetComponent<SphereCollider>().isTrigger = true;
    }

    public void OnTriggerEnter(Collider _other)
    {
        if (_other.gameObject)
        {
            SetUpNewSpeed(_other);
            //StartCoroutine(AdjustSpeed(_other));
            gameObject.SetActive(false);
        }
    }

    void SetUpNewSpeed(Collider _car)
    {
        Instantiate(speedChangedEffect, transform.position, transform.rotation);
        Car carSpeed = _car.GetComponent<Car>();
        carCurrentSpeed = carSpeed.motorForce;
        carSpeedChanged = carSpeed.speedChanged;

        Debug.Log("Current speed = " + carCurrentSpeed);
        carCurrentSpeed += carSpeedChanged;
        Debug.Log("new speed after power up = " + carCurrentSpeed);
        carSpeed.motorForce = carCurrentSpeed;
        Debug.Log("new current speed after power up = " + carSpeed.motorForce);
    }

    IEnumerator AdjustSpeed(Collider _car) 
    {
        /* ----- Adjust speed for the car when it collide with an item -----
         *  1. Spawn an effect to let a player know that they hit something
         *  2. Apply to the car, in this case, car's speed
         *  3. Wait before reverse the speed back to normal using Coroutine
         *  4. Reverse the speed back to normal
         */
        
        Instantiate(speedChangedEffect, transform.position, transform.rotation);
        //CarController carControllerAccessd = _car.GetComponent<CarController>();
        Car carSpeed = _car.GetComponent<Car>();
        carCurrentSpeed = carSpeed.motorForce;
        carSpeedChanged = carSpeed.speedChanged;
        Debug.Log("Current speed = " + carCurrentSpeed);
        carSpeed.motorForce += carSpeedChanged;
        Debug.Log("new speed = " + carCurrentSpeed);
        yield return timeBeforeReverseBack;
        //carSpeed.motorForce -= carSpeedChanged;
        //Debug.Log("current new speed = " + carCurrentSpeed);
        // this comment is for push again for Daniel to see this script
    }
}
