using UnityEngine;
using System.Collections;

public class ChatItemUIManager : MonoBehaviour {
	public UILabel ID_Label;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setGuid(ulong guid){
		ID_Label.text = "ID:" + guid.ToString ();
	}
}
