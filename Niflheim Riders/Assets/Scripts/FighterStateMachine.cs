using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FighterStateMachine : MonoBehaviour {
	//State machine that swaps between 

	public GameObject commander;
	public GameObject focus;
	public float expectOrders = 5.0f;
	public float scanrange = 10.0f;

	private bool fireMode = false;



	// Use this for initialization
	void Start () {
		StartCoroutine(DetermineOrders());
		StartCoroutine(DetermineManeuvers());
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	IEnumerator DetermineOrders() {
		while (true) {
			List<GameObject> enemies;

			//Issue own commands if the commander is dead.
			if (commander == null) {
				//Make focus reassignment more frequent if morale is broken.
				expectOrders = 5.0f;
				enemies = ScanForEnemies();

				//Focus on taking the objective if there's no enemies in range.
				if (enemies.Count == 0) {
					if (focus != GameObject.FindGameObjectWithTag("Objective")) {
						focus = GameObject.FindGameObjectWithTag("Objective");
					}
				}
				else {
					//Just pick a random ship in the list.
					focus = enemies[Random.Range(0,enemies.Count-1)];
				}
			}
			else {
				//Use the commands issued by the commander.
				if (commander == this) {
					gameObject.GetComponent<CommanderBehaviour>().ScanForEnemies();
				}
			}

			//Ask for new orders every so often, or determine their own
			yield return new WaitForSeconds(expectOrders);
		}
	}



	//Individual state machine governing individual movement patterns and behaviour
	//Movement is a constant, but the sweet spots for various state triggers are
	//Firing: 2-6 units distance, while in field of view
	//Speed up: > 5 units distance
	//Slow down < 3 units distance
	IEnumerator DetermineManeuvers() {
		while (true) {

			//Check for relevant states if the target is an enemy ship.
			if (focus == null || focus.tag == "Objective") {
				//Determine states for objective or null focuses.
				if (fireMode == true) {
					SetFireMode(false);
				}

				if (focus == null) {
					focus = GameObject.FindGameObjectWithTag("Objective");
				}

				//Speed back to the objective
				gameObject.GetComponent<AIThrottleController>().RaiseThrottle();
			}
			else if (focus.tag == "unionist" || focus.tag == "rider") {
				if (Vector3.Distance(gameObject.transform.position, focus.transform.position) > 2.0f && Vector3.Distance(gameObject.transform.position, focus.transform.position) < 6.0f) {
					SetFireMode(true);
				}
				else {
					SetFireMode(false);
				}

				//Speed up or slow down to get to the perfect flanking speed.
				if (Vector3.Distance(gameObject.transform.position, focus.transform.position) > 5.0f) {
					gameObject.GetComponent<AIThrottleController>().RaiseThrottle();
				}
				else if (Vector3.Distance(gameObject.transform.position, focus.transform.position) < 3.0f) {
					gameObject.GetComponent<AIThrottleController>().LowerThrottle();
				}
			}

			//Look at the object selected
			//This is a rather clumsy way of doing it, admittedly.
			gameObject.transform.LookAt(focus.transform.position);


			yield return new WaitForSeconds(3.0f);
		}
	}


	public void SetFireMode(bool mode) {
		fireMode = mode;
	}


	public List<GameObject> ScanForEnemies() {
		List<GameObject> enemies = new List<GameObject>();
		GameObject[] tempList;

		//Get all enemy objects, then return the ones in scan range.
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

	public void SetFocus(GameObject newFocus) {
		focus = newFocus;
	}

	public GameObject GetFocus() {
		return focus;
	}
}
