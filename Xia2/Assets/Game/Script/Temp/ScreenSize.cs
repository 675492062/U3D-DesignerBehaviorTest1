using UnityEngine;
using System.Collections;

public class ScreenSize : MonoBehaviour {

	// Use this for initialization
	void Start () {
	


	}
	
	// Update is called once per frame
	void Update () {
		UILabel label = GetComponentInChildren<UILabel>();
		if(label != null)
		{
			label.text = "" + Screen.width + "*" + Screen.height;
		}
	}
}
