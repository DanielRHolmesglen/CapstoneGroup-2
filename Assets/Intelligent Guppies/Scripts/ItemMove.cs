using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMove : MonoBehaviour
{
    public float movingSpeed;
    public Vector3 targetPosition;
    private bool isMoving;
    
    void Start()
    {
        GetComponent<BoxCollider>().isTrigger = true;
        isMoving = false;
    }

    void Update()
    {
        if (isMoving == true)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, movingSpeed * Time.deltaTime);
            //isMoving = false;
        }
    }

    public void OnTriggerEnter(Collider _other)
    {
        if (_other.gameObject)
        {
            isMoving = true;
        }
    }
}
