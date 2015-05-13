using UnityEngine;
using System.Collections;

public class Bubble : MonoBehaviour {

	public Animator animator;

	// Use this for initialization
	void Start () {
	
		animator = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {

		//if (Input.touches[0].phase == TouchPhase.Began || Input.GetButtonDown("Fire1")) {

			//FireRocket();

		//}

	}

	void OnMouseDown() {

		Debug.Log ("Holaaaaa");

		animator.SetBool ("exploded", true);

	}
}
