using UnityEngine;
using System.Collections;
using System;

public class ClickGeneralCallback : MonoBehaviour {
    public UILabel label;
    public UISprite sprite;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
        MonoInstancePool.getInstance<UserData>().headID = Convert.ToInt32(label.text);
    }
}
