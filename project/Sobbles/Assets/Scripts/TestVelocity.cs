using UnityEngine;
using System.Collections;

public class TestVelocity : MonoBehaviour {

	public Vector2 initVel;

	// Use this for initialization
	void Start () {
	
		this.GetComponent<Rigidbody2D>().velocity = initVel;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
