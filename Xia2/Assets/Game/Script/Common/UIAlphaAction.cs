using UnityEngine;
using System.Collections;

public class UIAlphaAction : MonoBehaviour {

	public float minNum = 0.3f;
	public float maxNum = 1.0f;
	UISprite sp;
	// Use this for initialization
	void Start () 
	{
		sp = GetComponentInChildren<UISprite> ();
		Color c = sp.color;
		c.a = 0.5f;
		sp.color = c;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

}
