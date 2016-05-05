using UnityEngine;
using System.Collections;

public class AIThrottleController : MonoBehaviour {

	public float throttlePower;
	public float maxThrottle = 8.0f;
	public float minThrottle = 2.0f;

	public float newPower;
	public float lerpSpeed = 2.5f;

	// Use this for initialization
	void Start () {
		throttlePower = 5.0f;
		newPower = 5.0f;
	}
	
	// Update is called once per frame
	void Update () {
		//Lerp the ship speed to simulate transitions between throttle better
		throttlePower = Mathf.Lerp(throttlePower, newPower, lerpSpeed * Time.deltaTime);
		//Then translate our ships movement across the forward vector
		transform.position = transform.position + ((transform.forward * throttlePower) * Time.deltaTime);
	}

	public void RaiseThrottle() {
		if (newPower + 1.0f > maxThrottle) {
			newPower = maxThrottle;
		}
		else {
			newPower = newPower + 1.0f;
		}
	}

	public void LowerThrottle() {
		if (newPower - 1.0f < minThrottle) {
			newPower = minThrottle;
		}
		else {
			newPower = newPower - 1.0f;
		}
	}
}
