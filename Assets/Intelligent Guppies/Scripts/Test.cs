using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;
    private float horizontalInput;

    // 0 = left, 1 = middle, 2 = right
    private int movingLane = 1;
    // the distance between two lanes
    public float laneDistance = 4;
    private Car _car;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        horizontalInput = Input.GetAxis("Horizontal");
    }

    void Update()
    {
        /*Input.GetAxis("Vertical") > 0 // gets forward
         * Input.GetAxis("Vertical") < 0 // gets backward
         * Input.GetAxis("Horizontal") > 0 // gets right
         * Input.GetAxis("Horizontal") < 0 // gets left
         */
        direction.z = forwardSpeed;
        // get the input on which lane we should be
        //if (Input.GetAxis("Horizontal") > 0)
        if (Input.GetKeyDown(KeyCode.D))
        {
            movingLane++;
            if(movingLane == 3)
            {
                movingLane = 2;
            }
        }

        //if (Input.GetAxis("Horizontal") < 0)
        if (Input.GetKeyDown(KeyCode.A))
        {
            movingLane--;
            if (movingLane == -1)
            {
                movingLane = 0;
            }
        }

        // calculate where the car should be in the future
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (movingLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }
        else if (movingLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }

        transform.position = targetPosition;
    }

    void FixedUpdate()
    {
        controller.Move(direction * Time.fixedDeltaTime);
    }
}
