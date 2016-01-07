using UnityEngine;
using System.Collections;

public class TestUITable : MonoBehaviour {

	float tempTime = 0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		tempTime += Time.deltaTime;
		if(tempTime >= 1f)
		{
			tempTime = 0f;
			UITable table = GetComponentInChildren<UITable> ();
			table.Reposition();
		}
	}
}
