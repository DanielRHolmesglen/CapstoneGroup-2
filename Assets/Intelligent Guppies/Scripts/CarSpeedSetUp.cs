using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]

public class CarSpeedSetUp : MonoBehaviour, IInteractable
{
    private float speedChanged = 500f;
    private float currentSpeed, newSpeed;
    public GameObject speedChangedEffect;
    private WaitForSeconds timeBeforeReverseBack = new WaitForSeconds(4f);

    void Start()
    {
        GetComponent<SphereCollider>().isTrigger = true;
    }

    public void OnTriggerEnter(Collider _other)
    {
        if (_other.gameObject)
        {
            StartCoroutine(AdjustSpeed(_other));
            gameObject.SetActive(false);
        }
    }

    public void ChangeColor() { }

    public void SpawnObject() { }

    IEnumerator AdjustSpeed(Collider _car) 
    {
        /* ----- Adjust speed for the car when it collide with an item -----
         *  1. Spawn an effect to let a player know that they hit something
         *  2. Apply to the car, in this case, car's speed
         *  3. Wait before reverse the speed back to normal using Coroutine
         *  4. Reverse the speed back to normal
         */
        
        Instantiate(speedChangedEffect, transform.position, transform.rotation);
        CarController carControllerAccessd = _car.GetComponent<CarController>();
        Debug.Log("Current speed = " + carControllerAccessd.motorForce);
        carControllerAccessd.motorForce += speedChanged;
        Debug.Log("new speed = " + carControllerAccessd.motorForce);
        yield return timeBeforeReverseBack;
        carControllerAccessd.motorForce -= speedChanged;
        Debug.Log("current new speed = " + carControllerAccessd.motorForce);
        // this comment is for push again for Daniel to see this script 
    }
}
