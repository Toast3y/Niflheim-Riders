using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	private int health = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoseHealth() {
		health--;

		if (health <= 0) {
			//Blow up
		}
	}
}
