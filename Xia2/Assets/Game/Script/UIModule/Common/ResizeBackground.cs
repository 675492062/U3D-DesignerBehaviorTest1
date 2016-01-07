using UnityEngine;
using System.Collections;

public class ResizeBackground : MonoBehaviour {

	UISprite  sp = null;
	// Use this for initialization
	void Start () 
	{
		sp = GetComponentInChildren<UISprite>();

		Vector3 pos = sp.transform.localPosition;
		pos.x = 0;
		pos.y = 0;
		sp.transform.localPosition = pos;

		sp.width = Screen.width;				
		sp.height = Screen.height;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
}
