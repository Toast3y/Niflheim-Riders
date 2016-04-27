using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	//Spawns an attack force of ships, and randomly promotes one to captain.

	public GameObject ship;
	public float radius = 10.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, radius);
	}
}
