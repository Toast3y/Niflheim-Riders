using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	//Spawns an attack force of ships, and randomly promotes one to captain.

	public GameObject ship;
	public float radius = 10.0f;
	public float secondsToWait = 20.0f;

	// Use this for initialization
	void Start () {
		StartCoroutine(SpawnSquadron(secondsToWait));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, radius);
	}


	IEnumerator SpawnSquadron(float seconds) {
		//Spawn reinforcements every few seconds.
		while (true) {

			for (int i = 0; i < Random.Range(2, 7); i++) {
				GameObject newShip = SpawnShip();

				//If this is the first spawn, make it the squadron commander
				if (i == 0) {

				}
				else {

				}
			}
			
			yield return new WaitForSeconds(seconds);
		}
	}

	private GameObject SpawnShip() {
		GameObject newShip = (GameObject) Instantiate(ship, Random.insideUnitSphere*radius + transform.position, new Quaternion(0,0,0,0));
		Vector3 coords = GameObject.FindGameObjectWithTag("Objective").transform.position;
        newShip.transform.LookAt(coords);

		return newShip;
	}
}
