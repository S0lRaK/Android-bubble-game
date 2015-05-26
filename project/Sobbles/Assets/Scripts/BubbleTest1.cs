using UnityEngine;
using System.Collections;

public class BubbleTest1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -1.01f);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
