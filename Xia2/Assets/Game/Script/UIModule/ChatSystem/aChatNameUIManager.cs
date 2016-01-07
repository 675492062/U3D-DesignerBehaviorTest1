using UnityEngine;
using System.Collections;

public class aChatNameUIManager : MonoBehaviour {
    public UILabel Label;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setName(string name)
    {
        Label.text = name;
    }
}
