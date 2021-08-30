using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class CollectableRings : MonoBehaviour, IInteractable
{
    public Transform spawnPoint;
    public GameObject objectToBeSpawned;

    void Start()
    {
        GetComponent<SphereCollider>().isTrigger = true;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject)
        {
            spawnWhenRingCollected();
            gameObject.SetActive(false);
        }
    }

    public void changeColor()
    {

    }

    public void spawnWhenRingCollected()
    {
        Instantiate(objectToBeSpawned, spawnPoint.position, spawnPoint.rotation);
    }
}
