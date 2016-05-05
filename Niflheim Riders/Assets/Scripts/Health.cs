using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public GameObject Explosion;

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
			Instantiate(Explosion, gameObject.transform.position, new Quaternion(0, 0, 0, 0));

			if (gameObject.tag == "Player") {
				//Create a camera to observe your death
			}

			if (gameObject.GetComponent<CommanderBehaviour>() != null) {
				//Trigger a commander death: Check if each extra fleet member will panic or rally
				gameObject.GetComponent<CommanderBehaviour>().CommanderDeath();
			}

			Destroy(this.gameObject);
		}
	}

	public void SetHealth(int Health) {
		health = Health;
	}
}
