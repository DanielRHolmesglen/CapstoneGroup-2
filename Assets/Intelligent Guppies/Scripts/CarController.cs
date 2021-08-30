using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Liminal.SDK.VR;
using Liminal.SDK.VR.Input;

public class CarController : MonoBehaviour
{
	/*  ----- CarController Class -----
     * g_ is for global variables
     * 
     * 
     * 
     * 
     * 
     */
	private float g_horizontalInput, g_verticalInput, g_steeringAngle;
	private bool g_isBreaking;

	public WheelCollider frontLeftWheelC, frontRightWheelC, rearLeftWheelC, rearRightWheelC;
	public Transform frontLeftWheelT, frontRightWheelT, rearLeftWheelT, rearRightWheelT;
	public float maxSteerAngle = 30f;
	public float motorForce = 50f;
	public float brakeForce = 0f;
	private Rigidbody carRigibody;
	private Vector3 carDirection;

	/* ----- For fixing car flipping issue -----
     * Fixed by moving center of the mass up
     * public float mass = -0.9f;   >> for normal in unity
     */
	private float mass = 0f;

	void Start()
	{
		carRigibody = GetComponent<Rigidbody>();
		carRigibody.centerOfMass = new Vector3(0f, mass, 0f);
	}

	private void FixedUpdate()
	{
		GetInput();
		Steer();
		Accelerate();
		UpdateAllWheelPositions();
	}

	public void GetInput()
	{
		/* ----- Get input for car movement -----
         * Horizontal is to move left and right
         * Vertical is to move forward and back
         */
		var primaryInput = VRDevice.Device.PrimaryInputDevice;
		var inputsFromVR = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		var trigger = primaryInput.GetAxis1D(VRButton.Trigger);
		g_isBreaking = Input.GetKey(KeyCode.Space);

		if (trigger > 0.01)
		{
			g_horizontalInput = inputsFromVR.x;
			g_verticalInput = inputsFromVR.y;

			carDirection.Set(inputsFromVR.x, 0, inputsFromVR.y);
			transform.Translate(carDirection * motorForce * Time.deltaTime);
		}
		else
		{
			g_horizontalInput = Input.GetAxis("Horizontal");
			g_verticalInput = Input.GetAxis("Vertical");

			//carDirection.Set(g_horizontalInput, 0, g_verticalInput);
			//transform.Translate(carDirection * motorForce * Time.deltaTime);
		}
	}

	private void Steer()
	{
		if (g_horizontalInput != 0)
		{
			g_steeringAngle = maxSteerAngle * g_horizontalInput;
			frontRightWheelC.steerAngle = g_steeringAngle;
			frontLeftWheelC.steerAngle = g_steeringAngle;
		}
		else
		{
			g_steeringAngle = 0;
			frontRightWheelC.steerAngle = g_steeringAngle;
			frontLeftWheelC.steerAngle = g_steeringAngle;
		}
	}

	private void Accelerate()
	{
		frontRightWheelC.motorTorque = g_verticalInput * motorForce;
		frontLeftWheelC.motorTorque = g_verticalInput * motorForce;

		brakeForce = g_isBreaking ? 3000f : 0f;
		frontLeftWheelC.brakeTorque = brakeForce;
		frontRightWheelC.brakeTorque = brakeForce;
		rearLeftWheelC.brakeTorque = brakeForce;
		rearRightWheelC.brakeTorque = brakeForce;
	}

	private void UpdateAllWheelPositions()
	{
		UpdateWheelPosition(frontRightWheelC, frontRightWheelT);
		UpdateWheelPosition(frontLeftWheelC, frontLeftWheelT);
		UpdateWheelPosition(rearRightWheelC, rearRightWheelT);
		UpdateWheelPosition(rearLeftWheelC, rearLeftWheelT);
	}

	private void UpdateWheelPosition(WheelCollider _collider, Transform _transform)
	{
		Vector3 _pos;
		Quaternion _quat;

		_collider.GetWorldPose(out _pos, out _quat);

		_transform.position = _pos;
		_transform.rotation = _quat;
	}
}
