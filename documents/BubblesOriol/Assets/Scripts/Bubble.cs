using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Bubble : MonoBehaviour {

	public Animator animator;
	public float floatingSpeed = 0.005f;
	private Queue<float> movements = new Queue<float>();
	private bool isBouncing = false;
	private Rigidbody2D rigidbody;

	void setMovements(int amount) {

		float shift;

		for (int i = 0; movements.Count < amount; i++) {
			
			do {
				
				shift = Mathf.Round (Random.Range(-0.01f, 0.01f) * 100f) / 100f;
				
			} while (shift == 0f);
			
			for (int x = 0; x < Mathf.RoundToInt (Random.Range (50f, 100f)); x++) {
				
				movements.Enqueue (shift);
				
			}
			
		}

	}

	// Use this for initialization
	void Awake () {

		animator = GetComponent<Animator> ();
		rigidbody = GetComponent<Rigidbody2D> ();

		setMovements (1000);

		//int index = 0;

		//foreach (float movement in movements) { Debug.Log(index + " " + movement); index++; }
		



	}

	void OnCollisionEnter2D(Collision2D collision) {

		Debug.Log ("Me toco, oh, sí!");

		isBouncing = true;

		Debug.Log (collision.relativeVelocity.magnitude);

	}
	

	// Update is called once per frame
	void Update () {

		float shift;

		//Physics2D.

		if (movements.Count == 0) setMovements(1000);

		shift = (float)movements.Dequeue ();

		//if (!isBouncing) transform.localPosition = new Vector2 (transform.localPosition.x + shift, transform.localPosition.y + floatingSpeed);
		if (!isBouncing) rigidbody.position = new Vector2 (rigidbody.position.x + shift, rigidbody.position.y + floatingSpeed);
		
		//if (Input.touches[0].phase == TouchPhase.Began || Input.GetButtonDown("Fire1")) {

			//FireRocket();

		//}

	}

	void OnMouseDown() {

		Debug.Log ("Holaaaaa");

		animator.SetBool ("exploded", true);
		Destroy (GetComponent<CircleCollider2D> ());

		isBouncing = true;

	}
}
