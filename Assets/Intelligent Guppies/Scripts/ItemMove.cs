using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMove : MonoBehaviour
{
    public float movingSpeed;
    public Vector3 targetPosition;
    private bool isMoving;
    private AudioSource sound;

    void Start()
    {
        sound = GetComponent<AudioSource>();
        GetComponent<BoxCollider>().isTrigger = true;
        isMoving = false;
    }

    void Update()
    {
        if (isMoving == true)
        {
            sound.Play();
            transform.position = Vector3.Lerp(transform.position, targetPosition, movingSpeed * Time.deltaTime);
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
