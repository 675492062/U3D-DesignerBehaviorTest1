using UnityEngine;
using System.Collections;

public class TestAddBtn : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnClick()
	{
		AddFunctionBtn func = (AddFunctionBtn)FindObjectOfType(typeof(AddFunctionBtn));
		func.addHBtn();
		func.addVBtn();
	}
}
