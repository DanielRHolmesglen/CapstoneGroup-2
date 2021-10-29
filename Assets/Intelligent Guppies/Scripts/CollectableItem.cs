using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(MeshCollider))]
public class CollectableItem : MonoBehaviour, IInteractable
{
    public Transform spawnPoint;
    public GameObject objectToBeSpawned;

    void Start()
    {
        GetComponent<MeshCollider>().isTrigger = true;
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
        Instantiate(objectToBeSpawned, spawnPoint.position, spawnPoint.rotation);
    }
}
