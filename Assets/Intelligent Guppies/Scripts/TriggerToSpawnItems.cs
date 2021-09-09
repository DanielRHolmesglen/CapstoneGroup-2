using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class TriggerToSpawnItems : MonoBehaviour, IInteractable
{
    public Transform objectSpawnPoint_1, objectSpawnPoint_2, objectSpawnPoint_3;
    public GameObject objectToBeSpawned;

    void Start()
    {
        GetComponent<BoxCollider>().isTrigger = true;
    }

    public void OnTriggerEnter(Collider _other)
    {
        if (_other.gameObject)
        {
            SpawnObject();
            gameObject.SetActive(false);
        }
    }

    public void ChangeColor() { }

    public void SpawnObject()
    {
        Instantiate(objectToBeSpawned, objectSpawnPoint_1.position, objectSpawnPoint_1.rotation);
        Instantiate(objectToBeSpawned, objectSpawnPoint_2.position, objectSpawnPoint_2.rotation);
        Instantiate(objectToBeSpawned, objectSpawnPoint_3.position, objectSpawnPoint_3.rotation);
    }
}
