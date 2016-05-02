using UnityEngine;
using System.Collections;

public class SelfDestruct : MonoBehaviour {

	public float waitTime = 10.0f;

	// Use this for initialization
	void Start () {
		StartCoroutine(BlowUp(waitTime));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator BlowUp(float seconds) {
		yield return new WaitForSeconds(seconds);
		Destroy(this.gameObject);
	}
}
