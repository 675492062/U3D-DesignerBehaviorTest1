using UnityEngine;
using System.Collections;

public class testInput : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnChange()
	{
		Debug.Log("change ");
	}
	void OnSubmit()
	{
		Debug.Log("onSubmit ");
	}
	void OnKey(KeyCode k)
	{

//		if(k == KeyCode.Backspace || KeyCode.Delete)
//		{
//
//		}
	}
	void OnInput (string text)
	{
		Debug.Log("onInput " + text);
	}

	public void test()
	{
		Debug.Log("test test event");
	}

}
