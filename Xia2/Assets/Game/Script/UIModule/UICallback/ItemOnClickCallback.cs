using UnityEngine;
using System.Collections;

public class ItemOnClickCallback : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClick()
    {
        var label = GetComponentInChildren<UILabel>();
        MonoInstancePool.getInstance<UserData>().setImage(label.text);
    }
}
