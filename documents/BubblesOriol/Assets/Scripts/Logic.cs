using UnityEngine;
using System.Collections;

/* Singleton. Instanciar con Logic.Instance; */
public class Logic : MonoBehaviour {

	private static readonly Logic instance = new Logic();

	private int score;

	static Logic() {}
	private Logic() {}

	public static Logic Instance {

		get { return instance; }

	}


	public void ScoreUp(int bubbleSize) {

		score += 10 * bubbleSize;
		RenderScore ();

	}

	private void RenderScore() {

		// TO DO
		// http://unity3d.com/es/learn/tutorials/projects/space-shooter/counting-points

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
