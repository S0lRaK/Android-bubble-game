using UnityEngine;
using System.Collections;

/* Singleton. Instanciar con Logic.Instance; */
public class Logic : MonoBehaviour {

	private static Logic instance = null;

	private int score;
	private int lives = 3;
	private bool running = true;
	public GUIText guiScore;
	public GameObject[] hearts;

	static Logic() {}
	private Logic() {}

	public static Logic Instance {

		get {

			if (instance == null) {

				instance = GameObject.FindObjectOfType<Logic>();
				
				//Tell unity not to destroy this object when loading a new scene!
				DontDestroyOnLoad(instance.gameObject);
			}
			
			return instance;

		}

	}

	void Awake() {

		if (instance == null) {

			instance = this;
			DontDestroyOnLoad (this);

		} else if (this != instance) {

			Destroy (this.gameObject);

		}

	}

	public bool IsRunning() {

		return this.running;

	}

	public void Run() {
		
		this.running = true;
		
	}

	public void Stop() {

		this.running = false;
		
	}

	public void ScoreUp(int bubbleSize) {

		score += 10 * (6 - bubbleSize); // 50, 40, 30
		Debug.Log ("New score: " + score.ToString ());

	}

	public void LifeDown() {

		lives--;

		if (lives == -1)
			this.Stop ();
		else {

			RenderHearts ();
			Debug.Log ("Lives: " + lives);

		}

	}

	private void RenderHearts() {

		for (int i = 0; i < (3 - lives); i++) {

			Debug.Log (hearts[i]);
			hearts[i].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .3f);

		}

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		guiScore.text = score.ToString ();


	}
}
