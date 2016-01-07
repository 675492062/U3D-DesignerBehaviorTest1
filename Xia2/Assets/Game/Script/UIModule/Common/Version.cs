using UnityEngine;
using System.Collections;

public class Version : MonoBehaviour {

	// Use this for initialization
	void Start () {
		UILabel label = GetComponentInChildren<UILabel> ();
		if(label != null)
		{
//			string ver = StaticVersion.Instance().getStr(1,"version");
			label.text = "Version: 12.26";
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
