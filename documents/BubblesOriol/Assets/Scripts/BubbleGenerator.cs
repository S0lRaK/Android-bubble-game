using UnityEngine;
using System.Collections;

public class BubbleGenerator : MonoBehaviour {

	public Rigidbody2D BlueBubble;
	public Rigidbody2D GreenBubble;
	public Rigidbody2D RedBubble;
	public Rigidbody2D YellowBubble;

	void newBubble() {

		Debug.Log ("Nueva burbuja");
		Rigidbody2D bubble = (Rigidbody2D) Instantiate(BlueBubble, new Vector2 (0.0f, 0.0f), Quaternion.identity);

		bubble.GetComponent<Transform> ().localScale = new Vector2 (0.4f, 0.4f);
		bubble.gravityScale = -0.2f;

	}

	void Start() {

		Debug.Log ("Inicio");
		newBubble();

	}
}
