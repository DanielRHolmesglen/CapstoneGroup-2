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

	//private Car _car;
	private MovingObject _movingObject;
	//private Rigidbody carRigibody;
	private Vector3 carDirection;
	private int movingLane;
	private float laneDistance;

	private CharacterController controller;

	void Start()
	{
		//_car = gameObject.GetComponent<Car>();
		_movingObject = gameObject.GetComponentInParent<MovingObject>();
		movingLane = _movingObject.movingLane;
		laneDistance = _movingObject.laneDistance;

		//carRigibody = GetComponent<Rigidbody>();
		//carRigibody.centerOfMass = new Vector3(0f, _car.mass, 0f);
		//_movingObject.targetForCamera = GameObject.Find("CameraLookAt");
		//controller = GetComponent<CharacterController>();
		//horizontalInput = Input.GetAxis("Horizontal");
	}

	void Update()
	{
		//carDirection.z = _car.carSpeed;
		GetInput();
	}

	//void FixedUpdate()
	//{
		//transform.Translate(carDirection * Time.fixedDeltaTime);
	//}

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