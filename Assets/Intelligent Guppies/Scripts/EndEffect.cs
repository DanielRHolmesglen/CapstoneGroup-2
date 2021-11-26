using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndEffect : MonoBehaviour
{
    public List<GameObject> endeffect = new List<GameObject>();

    void Start()
    {
        GetComponent<BoxCollider>().isTrigger = true;
    }

    public void OnTriggerEnter(Collider _other)
    {
        if (_other.gameObject)
        {
            Invoke("Deactivate", 5f);
        }
    }

    void Deactivate()
    {
        foreach (var item in endeffect)
        {
            if (item.activeSelf)
            {
                Debug.Log("Deactivate is called");
                item.SetActive(false);
            }
        }
    }
}
