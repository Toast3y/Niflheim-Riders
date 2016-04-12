using UnityEngine;
using System.Collections;

public class CameraTurn : MonoBehaviour {

	float timePassed = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		timePassed = timePassed + Time.deltaTime;
		/*
		if(timePassed >= 0.5f){
			Camera.main.transform.Rotate( new Quaternion(0, Camera.main.transform.rotation.x + 1.0f, 0, 0));
			timePassed = 0.0f;

		}

		*/
		Camera.main.transform.Rotate(new Vector3(0,5,0) * Time.deltaTime);
	}
}
