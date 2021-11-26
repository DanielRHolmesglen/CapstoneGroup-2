using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTrigger : MonoBehaviour
{
    public List<GameObject> spawnItem = new List<GameObject>();
    void Start()
    {
        GetComponent<BoxCollider>().isTrigger = true;
        foreach (var item in spawnItem)
        {
            item.SetActive(false);
        }
    }

    public void OnTriggerEnter(Collider _other)
    {
        if (_other.gameObject)
        {
            Activate();
            gameObject.SetActive(false);
            Invoke("Deactivate", 15f);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position, transform.localScale);
    }

    void Activate()
    {
        foreach (var item in spawnItem)
        {
            item.SetActive(true);
        }
    }

    void Deactivate()
    {
        foreach (var item in spawnItem)
        {
            if (item.activeSelf)
            {
                Debug.Log("Deactivate is called");
                item.SetActive(false);
            }
        }
    }
}
