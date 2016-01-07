using UnityEngine;
using System.Collections;

public class OnHeroToggleChanged : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnValueChange(bool value)
	{
		Debug.Log("change");
	}
}
