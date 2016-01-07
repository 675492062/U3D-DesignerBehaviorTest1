using UnityEngine;
using System.Collections;

public class ErrorWindow : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setText(string str)
	{
		UITextList list = GetComponentInChildren<UITextList> ();
		if(list != null)
		{
			list.Clear ();
			list.Add (str);
		}
	}
}
