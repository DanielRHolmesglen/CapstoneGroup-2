using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Liminal.SDK.VR;
using Liminal.SDK.VR.Input;

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
	public bool isCarMoved, hasMoved;
	public Text txtTriggerToStart, txtHowToPlay;

	void Start()
	{
		isCarMoved = false;
		hasMoved = false;
		txtTriggerToStart = GameObject.Find("TriggerToStart").GetComponent<Text>();
		txtTriggerToStart.text = "Trigger to start";
		//txtHowToPlay = GameObject.Find("HowToPlay").GetComponent<Text>();
		//txtHowToPlay.text = "Press \"A\" To Left and \"X\" To Right";
		_movingObject = gameObject.GetComponentInParent<MovingObject>();
		movingLane = _movingObject.movingLane;
		laneDistance = _movingObject.laneDistance;


	}

	void Update()
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

		var primaryInput = VRDevice.Device.PrimaryInputDevice;
		var vrInputs = primaryInput.GetAxis2D(VRAxis.One);
		var trigger = primaryInput.GetAxis1D(VRButton.Trigger);


		if (Input.GetKey(KeyCode.Space) || primaryInput.GetButtonDown(VRButton.Trigger))
		{
			isCarMoved = true;
			Destroy(txtTriggerToStart);
		}

		if (!isCarMoved) return;

		// get the input on which lane we should be
		// if (Input.GetAxis("Horizontal") > 0) // right
		//if (Input.GetKeyDown(KeyCode.D) || vrInputs.x > 0)
		//if (Input.GetKeyDown(KeyCode.D) || primaryInput.GetButtonDown(VRButton.One)) working
		if (Input.GetKeyDown(KeyCode.D) || vrInputs.x > 0 && !hasMoved)
		{
			movingLane++;
			if (movingLane == 3)
			{
				movingLane = 2;	
			}
			Invoke("ResetHasMoved", 1);
			hasMoved = true;
		}

		// if (Input.GetAxis("Horizontal") < 0) // left
		// if (Input.GetKeyDown(KeyCode.A) || vrInputs.x < 0)
		//if (Input.GetKeyDown(KeyCode.A) || primaryInput.GetButtonDown(VRButton.Three)) working
		if (Input.GetKeyDown(KeyCode.A) || vrInputs.x < 0 && !hasMoved)
		{
			movingLane--;
			if (movingLane == -1)
			{
				movingLane = 0;
				//Invoke("ResetHasMoved", 1);
			}
			Invoke("ResetHasMoved", 1);
			hasMoved = true;
		}
		if (vrInputs.x == 0) hasMoved = false;
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

		//transform.position = targetPosition;
		transform.position = Vector3.Lerp(transform.position, targetPosition, 5 * Time.deltaTime);
	}

    void ResetHasMoved()
    {
		hasMoved = false;
	}
}