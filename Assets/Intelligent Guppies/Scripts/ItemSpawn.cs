using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(MeshCollider))]
public class ItemSpawn : MonoBehaviour, IInteractable
{
    //public Transform spawnPoint;
    //public GameObject objectToBeSpawned;
    public List<GameObject> spawnItem = new List<GameObject>();
    private AudioSource sound;

    void Start()
    {
        sound = GetComponent<AudioSource>();
        GetComponent<MeshCollider>().isTrigger = true;
        foreach (var item in spawnItem)
        {
            item.SetActive(false);
        }
    }

    public void OnTriggerEnter(Collider _other)
    {
        if (_other.gameObject)
        {
            sound.Play();
            SpawnObject();
            gameObject.SetActive(false);
        }
    }

    public void ChangeColor() { }

    public void SpawnObject()
    {
        var randomSpawn = spawnItem[Random.Range(0, spawnItem.Count)];
        randomSpawn.SetActive(true);
    }
}
