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

	}

	public void IssueTargets() {
		//Issue targets to each squad member
		//If they're already focusing someone, this might cause them to peel and re-engage.

	}
}
