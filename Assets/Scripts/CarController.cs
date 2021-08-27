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

    private float horizontalInput;
    private float verticalInput;
    private float steerAngle;
    private bool isBreaking;

    public WheelCollider frontLeftWheelCollider;
    public WheelCollider frontRightWheelCollider;
    public WheelCollider rearLeftWheelCollider;
    public WheelCollider rearRightWheelCollider;
    public Transform frontLeftWheelTransform;
    public Transform frontRightWheelTransform;
    public Transform rearLeftWheelTransform;
    public Transform rearRightWheelTransform;

    public float maxSteeringAngle = 30f;
    public float motorForce = 50f;
    public float brakeForce = 0f;
    
    public float speed, turningSpeed;
    Vector3 direction;
    Quaternion rotation;
    Rigidbody carRigibody;

    /* ----- For fixing car flipping issue -----
     * Fixed by moving center of the mass up
     * public float mass = -0.9f;   >> for normal in unity
     */
    public float mass = 0f;

    void Start()
    {
        carRigibody = GetComponent<Rigidbody>();
        carRigibody.centerOfMass = new Vector3(0f, mass, 0f);
    }

    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }

    private void GetInput()
    {
        /* ----- Car movement -----
         * Horizontal is to move left and right
         * Vertical is to move forward and back
         */
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        isBreaking = Input.GetKey(KeyCode.Space);

        var primaryInput = VRDevice.Device.PrimaryInputDevice;
        var inputs = new Vector2(horizontalInput, verticalInput); 
        var trigger = primaryInput.GetAxis1D(VRButton.Trigger);
        isBreaking = Input.GetKey(KeyCode.Space);

        if(trigger > 0.01 || isBreaking)
        {
            direction.Set(inputs.x, 0, inputs.y);
            rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, turningSpeed);
            carRigibody.AddForce(transform.forward * speed, ForceMode.Acceleration);
        }
    }

    private void HandleSteering()
    {
        steerAngle = maxSteeringAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = steerAngle;
        frontRightWheelCollider.steerAngle = steerAngle;
    }

    private void HandleMotor()
    {
        frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
        frontRightWheelCollider.motorTorque = verticalInput * motorForce;

        brakeForce = isBreaking ? 3000f : 0f;
        frontLeftWheelCollider.brakeTorque = brakeForce;
        frontRightWheelCollider.brakeTorque = brakeForce;
        rearLeftWheelCollider.brakeTorque = brakeForce;
        rearRightWheelCollider.brakeTorque = brakeForce;
    }

    private void UpdateWheels()
    {
        UpdateWheelPos(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateWheelPos(frontRightWheelCollider, frontRightWheelTransform);
        UpdateWheelPos(rearLeftWheelCollider, rearLeftWheelTransform);
        UpdateWheelPos(rearRightWheelCollider, rearRightWheelTransform);
    }

    private void UpdateWheelPos(WheelCollider wheelCollider, Transform trans)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        trans.rotation = rot;
        trans.position = pos;
    }
}
