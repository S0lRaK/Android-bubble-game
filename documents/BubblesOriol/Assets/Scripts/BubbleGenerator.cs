using UnityEngine;
using System.Collections;

public class BubbleGenerator : MonoBehaviour {

	public GameObject BlueBubble;
	public GameObject GreenBubble;
	public GameObject RedBubble;
	public GameObject YellowBubble;
	public int generationTime = 5;
	private float startPosition;
	
	void NewBubble() {
	
		GameObject bubble = null;

		switch (Random.Range (0, 4)) {
		
			case 0:

				bubble = Instantiate(BlueBubble, new Vector2 (Random.Range(-2f, 2f), startPosition), Quaternion.identity) as GameObject;
				break;

			case 1:
			
				bubble = Instantiate(GreenBubble, new Vector2 (Random.Range(-2f, 2f), startPosition), Quaternion.identity) as GameObject;
				break;
				
			case 2:
				
				bubble = Instantiate(RedBubble, new Vector2 (Random.Range(-2f, 2f), startPosition), Quaternion.identity) as GameObject;
				break;
				
			case 3:
				
				bubble = Instantiate(YellowBubble, new Vector2 (Random.Range(-2f, 2f), startPosition), Quaternion.identity) as GameObject;
				break;

		}


		bubble.GetComponent<Bubble>().Initialize(Random.Range(1, 4), 5);

	}

	void Awake() {

		startPosition = (Camera.main.orthographicSize * -1) - 1;

	}

	void Start() {

		StartCoroutine (GenerateBubbles ());
		//NewBubble (); // Descomentar esta y comentar la de arriba para pruebas con una burbuja

	}

	IEnumerator GenerateBubbles() {

		while (true) {

			NewBubble ();
			
			yield return new WaitForSeconds (this.generationTime);

		}

	}
}
