using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
	[HideInInspector]
	public float maxSteerAngle = 5f;
	//[HideInInspector]
	public float motorForce = 300f;
	[HideInInspector]
	public float brakeForce = 0f;

	/* ----- For fixing car flipping issue -----
     * Fixed by moving center of the mass up
     * public float mass = -0.9f;   >> for normal in unity
     */
	[HideInInspector]
	public float mass = 0f;

	public float carSpeed = 25f;
}
