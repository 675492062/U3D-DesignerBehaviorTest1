using UnityEngine;
using System.Collections;

public class TestClick : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	void OnClick()
	{
		Vector3 pos = UICamera.lastHit.point;
		UIRoot root = (UIRoot)FindObjectOfType(typeof(UIRoot));
		Debug.Log("click " + pos + " " + root.manualHeight);

	}
}
