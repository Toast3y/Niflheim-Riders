using UnityEngine;
using System.Collections;

public class ShootingBehaviour : MonoBehaviour {

	//Shoots a laser forward if the left mouse button is held down every delay
	public float rateOfFire = 0.75f;
	public GameObject Laser;
	public Vector3 offset;

	// Use this for initialization
	void Start () {
		StartCoroutine(Fire(rateOfFire));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Fire(float seconds) {
		while (true) {

			if (Input.GetMouseButton(0)) {
				//Fire weapons
				Instantiate(Laser, gameObject.transform.position, gameObject.transform.rotation);
				//new Vector3(gameObject.transform.position.x + offset.x, gameObject.transform.position.y + offset.y, gameObject.transform.position.z + offset.z)
            }

			yield return new WaitForSeconds(seconds);
		}
	}
}
