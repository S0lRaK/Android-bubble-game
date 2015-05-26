using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bubble : MonoBehaviour {

	private Logic logic;
	private Animator animator;
	private Rigidbody2D rigidbody;
	private CircleCollider2D collider;
	private Transform transform;
	private int size;
	private float scaleSize;
	private float floatingSpeed;
	private float direction;


	public void Initialize(int size, int speed) {

		this.size = size;
		this.scaleSize = 0.2f + (size / 10.0f);
		this.floatingSpeed = speed / 10.0f;
		transform.localScale = new Vector2 (this.scaleSize, this.scaleSize); // 0.3, 0.4 o 0.5

	}

	void Awake () {
		
		animator = GetComponent<Animator> ();
		rigidbody = GetComponent<Rigidbody2D> ();
		collider = GetComponent<CircleCollider2D> ();
		transform = GetComponent<Transform> ();
		logic = Logic.Instance; 
		
	}

	void Start() {

		StartCoroutine (Move ());
			
	}

	void OnCollisionEnter2D(Collision2D collision) {

		direction = rigidbody.velocity.y;
		Debug.Log ("Opposite: " + (-direction));
		//rigidbody.velocity = new Vector2(rigidbody.velocity.x, -direction);
		
	}
	

	void FixedUpdate () {

		if (transform.localPosition.y > Camera.main.orthographicSize + (scaleSize * 2f) && animator.GetBool ("exploded") == false) {

			Destroy (gameObject); // Se elimina la burbuja
			logic.LifeDown ();

		} else if (!logic.IsRunning ()) {

			rigidbody.velocity = new Vector2 (0, 0);
			StartCoroutine (ExplodeBubble ());

		}

	}
	
	void OnMouseDown() {

		StartCoroutine (ExplodeBubble ());

	}

	IEnumerator ExplodeBubble() {

		animator.SetBool ("exploded", true);
		Destroy (GetComponent<CircleCollider2D> ());
		if (logic.IsRunning ()) logic.ScoreUp (size);
		
		yield return new WaitForSeconds(1);
		Destroy (gameObject); // Se elimina la burbuja

	}

	IEnumerator Move() {
		
		while (logic.IsRunning()) {

			direction = Mathf.Round (Random.Range (-0.1f, 0.1f) * 10f) / 10f;

			rigidbody.velocity = new Vector2 (direction, floatingSpeed);

			yield return new WaitForSeconds (Random.Range (3, 5));
			
		}
		
	}

}
