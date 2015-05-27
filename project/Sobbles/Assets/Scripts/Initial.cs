using UnityEngine;
using System.Collections;

public class Initial : MonoBehaviour
{
	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnMouseDown ()
	{
		Application.LoadLevel("MainScene");
	}
}
