using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
	[HideInInspector]
	public GameObject targetForCamera;

	/* Set up a number for moving object to specific lane
	 * 0 = left, 1 = middle, 2 = right
	 *
	 */
	[HideInInspector]
	public int movingLane = 1;

	/* the distance between each lane */
	[HideInInspector]
	public float laneDistance = 4;
	private Car _car;
	private Vector3 moveDirection;

	void Start()
    {
		targetForCamera = GameObject.Find("CameraLookAt");
		_car = gameObject.GetComponentInChildren<Car>();
	}

	void Update()
	{
		moveDirection.z = _car.carSpeed;
	}

	void FixedUpdate()
	{
		transform.Translate(moveDirection * Time.fixedDeltaTime);
	}
}
