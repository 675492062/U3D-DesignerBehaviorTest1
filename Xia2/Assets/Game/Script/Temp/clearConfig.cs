using UnityEngine;
using System.Collections;

public class clearConfig : MonoBehaviour {

	void Awake()
	{
		PlayerPrefs.DeleteAll();
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
