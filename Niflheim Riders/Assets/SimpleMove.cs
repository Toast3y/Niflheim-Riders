using UnityEngine;
using System.Collections;

public class SimpleMove : MonoBehaviour {

	public float moveSpeed = 5.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = transform.position + ((transform.forward * moveSpeed) * Time.deltaTime);
	}
}
