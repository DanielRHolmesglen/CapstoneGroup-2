using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class SpeedSetup : MonoBehaviour
{
    public GameObject collectedEffect;
    private float currentCarSpeed;
    private List<float> speedUp = new List<float> { 10f, 12f, 15f };
    private List<float> speedDown = new List<float> { 5f, 7f, 9f };
    private float turbo = 50f;

    void Start()
    {
        GetComponent<SphereCollider>().isTrigger = true;
        collectedEffect.SetActive(false);
    }

    public void OnTriggerEnter(Collider _other)
    {
        if (_other.gameObject)
        {
            if (gameObject.name == "Boost")
            {
                Debug.Log(gameObject.name);
                SpeedUp(_other);
                gameObject.SetActive(false);
                Debug.Log(collectedEffect);
                collectedEffect.SetActive(true);
                Invoke("Deactivate", 3f);
            }
        }
        
        if (_other.gameObject)
        {
            if (gameObject.name == "Slow")
            {
                Debug.Log(gameObject.name);
                SpeedDown(_other);
                gameObject.SetActive(false);
            }
        }
        
        if (_other.gameObject)
        {
            if (gameObject.name == "Turbo")
            {
                Debug.Log(gameObject.name);
                SpeedUp(_other);
                gameObject.SetActive(false);
            }
        }
    }

    void SpeedUp(Collider _car)
    {
        collectedEffect.SetActive(true);
        Car carSpeed = _car.GetComponent<Car>();

        currentCarSpeed = carSpeed.carSpeed;
        Debug.Log("Current speed = " + currentCarSpeed);

        var randomNo = speedUp[Random.Range(0, speedUp.Count)];
        Debug.Log("random speed up = " + randomNo);

        currentCarSpeed += randomNo;
        Debug.Log("new speed after power up = " + currentCarSpeed);

        carSpeed.carSpeed = currentCarSpeed;
        Debug.Log("new current speed after power up = " + carSpeed.carSpeed);
    }

    void SpeedDown(Collider _car)
    {
        collectedEffect.SetActive(true);
        Car carSpeed = _car.GetComponent<Car>();

        currentCarSpeed = carSpeed.carSpeed;
        Debug.Log("Current speed = " + currentCarSpeed);

        var randomNo = speedDown[Random.Range(0, speedDown.Count)];
        Debug.Log("random slow down = " + randomNo);

        currentCarSpeed -= randomNo;
        Debug.Log("new speed after slow down = " + currentCarSpeed);

        carSpeed.carSpeed = currentCarSpeed;
        Debug.Log("new current speed after slow down = " + carSpeed.carSpeed);
    }

    void Deactivate()
    {
        collectedEffect.SetActive(false);
    }
}
