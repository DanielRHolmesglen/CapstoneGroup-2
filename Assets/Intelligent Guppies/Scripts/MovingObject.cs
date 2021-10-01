using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
	/* Set up a number for moving object to specific lane
	 * 0 = left, 1 = middle, 2 = right
	 *
	 */
	[HideInInspector]
	public int movingLane = 1;
	/* laneDistance = the distance between each lane */
	public float laneDistance = 3.5f;
	private Car _car;
	private Vector3 moveDirection;

	void Start()
    {
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
