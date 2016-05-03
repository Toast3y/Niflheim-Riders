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
				//Due to model positions, fire the laser across negative objects right vector

				Vector3 pos = new Vector3(gameObject.transform.position.x + offset.x, gameObject.transform.position.y + offset.y, gameObject.transform.position.z + offset.z);

				Instantiate(Laser, pos, Quaternion.LookRotation(-(gameObject.transform.right)));
				//new Vector3(gameObject.transform.position.x + offset.x, gameObject.transform.position.y + offset.y, gameObject.transform.position.z + offset.z)
            }

			yield return new WaitForSeconds(seconds);
		}
	}
}
