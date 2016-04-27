using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

	private bool animating;
	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

		//DO A BARREL ROLL!!!
		if (Input.GetKeyDown("q")) {
			animator.Play("roll_left");
		}

		if (Input.GetKeyDown("e")) {
			animator.Play("roll_right");
		}

	}


}
