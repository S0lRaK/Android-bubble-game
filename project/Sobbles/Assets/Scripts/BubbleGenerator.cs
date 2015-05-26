using UnityEngine;
using System.Collections;

public class BubbleGenerator : MonoBehaviour {

	private Logic logic;
	public GameObject BlueBubble;
	public GameObject GreenBubble;
	public GameObject RedBubble;
	public GameObject YellowBubble;
	public int floatingSpeed = 40;
	public float generationTime = 5f;
	private float startPosition;
	
	void NewBubble(float startPosition) {
	
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


		bubble.GetComponent<Bubble>().Initialize(Random.Range(1, 4), floatingSpeed);

	}

	void Awake() {

		startPosition = (Camera.main.orthographicSize * -1) - 1;
		logic = Logic.Instance;

	}

	void Start() {

		StartCoroutine (GenerateBubbles ());
		//NewBubble (); // Descomentar esta y comentar la de arriba para pruebas con una burbuja

	}

	IEnumerator GenerateBubbles() {

		while (logic.IsRunning()) {

			NewBubble (this.startPosition);
			NewBubble (this.startPosition - 2f);
			//NewBubble (this.startPosition - 4f);
			
			yield return new WaitForSeconds (this.generationTime);

			if (this.generationTime > 0.5f) this.generationTime -= 0.1f;
			if (this.floatingSpeed < 60) this.floatingSpeed += 1;
			Debug.Log ("Floating speed: " + this.floatingSpeed);
			Debug.Log ("Generation speed: " + this.generationTime);

		}

	}
}
