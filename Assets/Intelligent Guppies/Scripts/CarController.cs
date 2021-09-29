using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Liminal.SDK.VR;
using Liminal.SDK.VR.Input;

public class CarController : MonoBehaviour
{
	/*  ----- CarController Class -----
     * 
     * 
     * 
     * 
     * 
     * 
     */
	private float horizontalInput, verticalInput, steeringAngle;
	//private bool isBreaking;

	//public WheelCollider frontLeftWheelC, frontRightWheelC, rearLeftWheelC, rearRightWheelC;
	//public Transform frontLeftWheelT, frontRightWheelT, rearLeftWheelT, rearRightWheelT;
	//private float maxSteerAngle, motorForce, brakeForce;
	private Car _car;
	//public float maxSteerAngle = 30f;
	//public float carSpeed;
	//private float brakeForce = 0f;
	private Rigidbody carRigibody;
	private Vector3 carDirection;
	//public GameObject targetForCamera;

	/* ----- For fixing car flipping issue -----
     * Fixed by moving center of the mass up
     * public float mass = -0.9f;   >> for normal in unity
     */
	//private float mass = 0f;

	private CharacterController controller;
	private Vector3 direction;
	public float forwardSpeed;

	// 0 = left, 1 = middle, 2 = right
	private int movingLane = 1;
	// the distance between two lanes
	public float laneDistance = 4;

	void Start()
	{
		_car = gameObject.GetComponent<Car>();
		carRigibody = GetComponent<Rigidbody>();
		carRigibody.centerOfMass = new Vector3(0f, _car.mass, 0f);
		_car.targetForCamera = GameObject.Find("CameraLookAt");
		//maxSteerAngle = _car.maxSteerAngle;
		//carSpeed = _car.carSpeed;
		//brakeForce = _car.brakeForce;
	}

    private void FixedUpdate()
	{
		GetInput();
		
		//Steer();
		//Accelerate();
		//UpdateAllWheelPositions();
		//UpdateWheelRotation();
	}

	public void GetInput()
	{
		/* ----- Get input for car movement -----
         * Horizontal is to move left and right
         * Vertical is to move forward and back
         */

		/*Input.GetAxis("Vertical") > 0 // gets forward
         * Input.GetAxis("Vertical") < 0 // gets backward
         * Input.GetAxis("Horizontal") > 0 // gets right
         * Input.GetAxis("Horizontal") < 0 // gets left
         */

		var primaryInput = VRDevice.Device.PrimaryInputDevice;
		//var inputsFromVR = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		//var inputsFromVR = Input.GetAxis("Horizontal");
		var inputsFromVR = primaryInput.GetAxis2D(VRAxis.One);
		//var trigger = primaryInput.GetAxis1D(VRButton.Trigger);
		//isBreaking = Input.GetKey(KeyCode.Space);

		carDirection.z = forwardSpeed;
		transform.Translate(carDirection * Time.deltaTime);
	}

	/*private void Steer()
	{
		if (horizontalInput != 0)
		{
			steeringAngle = maxSteerAngle * horizontalInput;
			frontRightWheelC.steerAngle = steeringAngle;
			frontLeftWheelC.steerAngle = steeringAngle;
		}
		else
		{
			steeringAngle = 0;
			frontRightWheelC.steerAngle = steeringAngle;
			frontLeftWheelC.steerAngle = steeringAngle;
		}
	}

	private void Accelerate()
	{
		/* To handle accelaration for the front wheels */
	/*frontRightWheelC.motorTorque = verticalInput * motorForce;
	frontLeftWheelC.motorTorque = verticalInput * motorForce;

	brakeForce = isBreaking ? 3000f : 0f;
	frontLeftWheelC.brakeTorque = brakeForce;
	frontRightWheelC.brakeTorque = brakeForce;
	rearLeftWheelC.brakeTorque = brakeForce;
	rearRightWheelC.brakeTorque = brakeForce;
}*/


	/*private void UpdateAllWheelPositions()
	{
		/* To update the rotation of the wheels (how the wheels look)
		 * By calling UpdateWheelPosition function
		 */
	/*UpdateWheelPosition(frontRightWheelC, frontRightWheelT);
		UpdateWheelPosition(frontLeftWheelC, frontLeftWheelT);
		UpdateWheelPosition(rearRightWheelC, rearRightWheelT);
		UpdateWheelPosition(rearLeftWheelC, rearLeftWheelT);
	}
*/

	/*private void UpdateWheelRotation()
    {
		/* For fixing Kye's car wheel
		 * comment this function if using another car
		 */
	/*RotationWheelCorrection(frontRightWheelT);
		RotationWheelCorrection(frontLeftWheelT);
		RotationWheelCorrection(rearRightWheelT);
		RotationWheelCorrection(rearLeftWheelT);
	}*/

	/*private void UpdateWheelPosition(WheelCollider _collider, Transform _transform)
	{
		Vector3 _pos;
		Quaternion _quat;

		_collider.GetWorldPose(out _pos, out _quat);

		_transform.position = _pos;
		_transform.rotation = _quat;
	}

	private void RotationWheelCorrection(Transform transform)
	{
		Quaternion _rot = transform.rotation;
		_rot = _rot * Quaternion.Euler(0, 0, -90);
		transform.rotation = _rot;
	}*/
	// this comment is for test commit 17/9/2021
}
