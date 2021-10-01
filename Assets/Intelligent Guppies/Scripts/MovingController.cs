using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingController : MonoBehaviour
{
	/*  ----- CarController Class -----
     * 
     * 
     * 
     * 
     * 
     * 
     */

	private MovingObject _movingObject;
	private int movingLane;
	private float laneDistance;

	void Start()
	{
		_movingObject = gameObject.GetComponentInParent<MovingObject>();
		movingLane = _movingObject.movingLane;
		laneDistance = _movingObject.laneDistance;
	}

	void Update()
	{
		GetInput();
	}

	public void GetInput()
	{
		/* ----- Get input for car movement -----
         * Horizontal is to move left and right
         * Vertical is to move forward and back
         * 
         * Input.GetAxis("Vertical") > 0 // gets forward
         * Input.GetAxis("Vertical") < 0 // gets backward
         * Input.GetAxis("Horizontal") > 0 // gets right
         * Input.GetAxis("Horizontal") < 0 // gets left
         */

		// get the input on which lane we should be
		//if (Input.GetAxis("Horizontal") > 0)
		if (Input.GetKeyDown(KeyCode.D))
		{
			movingLane++;
			if (movingLane == 3)
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
}