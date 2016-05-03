using UnityEngine;
using System.Collections;

public class DamageBehaviour : MonoBehaviour {

	//Script to damage an enemy ship and despawn the object

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision) {
		//If it hits an npc ship, damage them.
		//Else, handle player hits separately.

		if (collision.gameObject.tag == "unionist" || collision.gameObject.tag == "rider") {
			collision.gameObject.GetComponent<Health>().LoseHealth();
			Destroy(this.gameObject);
		}
	}
}
