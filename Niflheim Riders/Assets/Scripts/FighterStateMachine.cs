using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FighterStateMachine : MonoBehaviour {
	//State machine that governs 

	public GameObject commander;
	public GameObject focus;
	public float expectOrders = 20.0f;
	public float scanrange = 10.0f;



	// Use this for initialization
	void Start () {
		StartCoroutine(DetermineState());
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	IEnumerator DetermineState() {
		while (true) {
			List<GameObject> enemies;

			//Issue own commands if the commander is dead.
			if (commander == null) {
				enemies = ScanForEnemies();
			}
			else {
				//Get the commands issued by the commander.
			}

			//Ask for new orders every so often, or determine their own
			yield return new WaitForSeconds(expectOrders);
		}
	}

	private List<GameObject> ScanForEnemies() {
		List<GameObject> enemies = new List<GameObject>();
		GameObject[] tempList;

		//Get all objects, then return the ones in scan range.
		if (gameObject.tag == "unionist") {
			tempList = GameObject.FindGameObjectsWithTag("rider");
		}
		else {
			tempList = GameObject.FindGameObjectsWithTag("unionist");
		}

		foreach (GameObject ship in tempList) {
			if (Vector3.Distance(gameObject.transform.position, ship.transform.position) < 10.0f) {
				enemies.Add(ship);
			}
		}

		return enemies;
	}
}
