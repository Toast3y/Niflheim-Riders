using UnityEngine;
using System.Collections;

public class RotationController : MonoBehaviour {

	//Rotates the player on the X and Y axis based on mouse movement
	//Should have inertia based on the throttle controller.

	//Partial implementation from FPSController.cs from first semester Game Engines 1 module.

	private float xRotate;
	private float yRotate;
	private Quaternion rotation;



	// Use this for initialization
	void Start () {
		rotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		//Capture any movement of the mouse from the previous frame.
		//Mouse controls the X and Y, keyboard controls the Z.
		if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0) {
			xRotate = Input.GetAxis("Mouse X");
			yRotate = Input.GetAxis("Mouse Y");
		}

		
		//Translate mouse movements to the new pitch and yaw
		Yaw(xRotate);
		Pitch(-yRotate);

		transform.rotation = rotation;
	}

	void Yaw(float angle) {
		Quaternion newrot = Quaternion.AngleAxis(angle, Vector3.up);
		rotation = newrot * rotation;
	}

	void Pitch(float angle) {
		float invcosTheta1 = Vector3.Dot(transform.forward, Vector3.up);
		float threshold = 0.95f;
		if ((angle > 0 && invcosTheta1 < (-threshold)) || (angle < 0 && invcosTheta1 > (threshold))) {
			return;
		}

		Quaternion rot = Quaternion.AngleAxis(angle, transform.forward);

		rotation = rot * rotation;
	}
}
