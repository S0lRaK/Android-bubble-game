using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour
{
	// Use this for initialization
	void Start ()
	{
		DontDestroyOnLoad(GameObject.FindWithTag("Music"));
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
