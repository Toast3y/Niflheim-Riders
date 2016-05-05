using UnityEngine;
using System.Collections.Generic;

public class CommanderBehaviour : MonoBehaviour {

	private List<GameObject> squad = new List<GameObject>();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddSquadMember(GameObject member) {
		squad.Add(member);
	}

	//Implement all methods to issue orders and command squad

	//There are 3 potential orders to issue
		//FocusTarget, to fire on
		//ScanForEnemies, for intel and to better issue orders
		//DefendObjective, to regroup near the centre and better position themselves.




	public void ScanForEnemies() {
		//Scan for enemies using all members of the fleet as vision
		//If a unit is deciding for itself, use only it's vision, not the fleet vision.
		List<GameObject> targets = new List<GameObject>();

		foreach (GameObject ship in squad) {
			if (ship == null) {
				//prune any dead ships
				squad.Remove(ship);
			}
			else {
				//Retrieve a list of targets from each squad mate
				List<GameObject> temp = new List<GameObject>();
				temp = ship.GetComponent<FighterStateMachine>().ScanForEnemies();

				foreach (GameObject target in temp) {
					targets.Add(target);
				}
			}
		}

		IssueTargets(targets);
	}

	public void IssueTargets(List<GameObject> targets) {
		//Issue targets to each squad member
		//If they're already focusing someone, this might cause them to peel and re-engage.

		foreach (GameObject ship in squad) {
			//Determine if the target is a good fit
			//Potential states and reasons to change:
			//Has no target, or target is the objective: switch to help allies or wait for enemies to approach the objective
			//Current target is too far away: switch or peel towards objective

			if (ship.GetComponent<FighterStateMachine>().GetFocus() == null || ship.GetComponent<FighterStateMachine>().GetFocus() == GameObject.FindGameObjectWithTag("Objective")) {

				//Focus on the objective instead of chasing fleeing targets.
				if (Vector3.Distance(gameObject.transform.position, ship.transform.position) > 15.0f) {
					ship.GetComponent<FighterStateMachine>().SetFocus(GameObject.FindGameObjectWithTag("Objective"));
                }
				else {

					bool assigned = false;

					foreach (GameObject target in targets) {

						//check if potential target is too far away
						if (Vector3.Distance(ship.transform.position, target.transform.position) > 15.0f) {
							//Don't assign this target due to distance
						}
						else {
							ship.GetComponent<FighterStateMachine>().SetFocus(target);
							assigned = true;
						}
					}

					//If no target fits the criteria, just fly towards the objective
					if (!assigned) {
						ship.GetComponent<FighterStateMachine>().SetFocus(GameObject.FindGameObjectWithTag("Objective"));
					}
				}
				
			}
			

		}

	}



	public void CommanderDeath() {
		//Trigger morale loss
		bool rally = false;
		GameObject newCommander = null;


		//Check if a new commander is assigned.
		foreach (GameObject ship in squad) {

			if (rally == true) {
				//Do not assign the commander role twice
			}
			else {
				if (ship == null) {
					//Prune any dead ships
					squad.Remove(ship);
				}
				else {
					//Check and see if the commander role is reassigned
					//Squad contains the commander too for ease of use when interacting with the whole squad
					//A simple check ensures you're not assigning the new commander to the one that just died
					if (Random.Range(0, 100) < 5 && ship != this) {
						ship.AddComponent<CommanderBehaviour>();
						newCommander = ship;
						rally = true;
					}
				}
			}
			
		}


		//If there's a new commander, hand over command to them
		if (newCommander != null) {
			foreach (GameObject ship in squad) {
				newCommander.GetComponent<CommanderBehaviour>().AddSquadMember(ship);
				ship.GetComponent<FighterStateMachine>().commander = newCommander;
			}
		}
	}
}
