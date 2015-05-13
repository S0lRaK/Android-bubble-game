using UnityEngine;
using System.Collections;

public class BubbleGenerator : MonoBehaviour {

	public Rigidbody2D BlueBubble;
	public Rigidbody2D GreenBubble;
	public Rigidbody2D RedBubble;
	public Rigidbody2D YellowBubble;

	void newBubble() {

		Debug.Log ("Nueva burbuja");
		Rigidbody2D bubble1 = (Rigidbody2D) Instantiate(BlueBubble, new Vector2 (-0.2f, -7.0f), Quaternion.identity);

		bubble1.GetComponent<Transform> ().localScale = new Vector2 (0.4f, 0.4f);
		bubble1.gravityScale = -0.02f;

		Rigidbody2D bubble2 = (Rigidbody2D) Instantiate(GreenBubble, new Vector2 (-1.5f, -9.0f), Quaternion.identity);
		
		bubble2.GetComponent<Transform> ().localScale = new Vector2 (0.3f, 0.3f);
		bubble2.gravityScale = -0.02f;

		Rigidbody2D bubble3 = (Rigidbody2D) Instantiate(RedBubble, new Vector2 (0.0f, -10.0f), Quaternion.identity);
		
		bubble3.GetComponent<Transform> ().localScale = new Vector2 (0.5f, 0.5f);
		bubble3.gravityScale = -0.02f;

		Rigidbody2D bubble4 = (Rigidbody2D) Instantiate(YellowBubble, new Vector2 (0.6f, -13.0f), Quaternion.identity);
		
		bubble4.GetComponent<Transform> ().localScale = new Vector2 (0.3f, 0.3f);
		bubble4.gravityScale = -0.02f;

		Rigidbody2D bubble5 = (Rigidbody2D) Instantiate(GreenBubble, new Vector2 (-1.1f, -15.0f), Quaternion.identity);
		
		bubble5.GetComponent<Transform> ().localScale = new Vector2 (0.4f, 0.4f);
		bubble5.gravityScale = -0.02f;

	}

	void Start() {

		Debug.Log ("Inicio");
		newBubble();

	}
}
