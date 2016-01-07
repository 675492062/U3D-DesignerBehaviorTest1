using UnityEngine;
using System.Collections;

public class PanelControl : MonoBehaviour {

	public UIPanel panel;
	public int  uiState;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnClick()
	{
		if (panel.gameObject.activeSelf) 
		{
			panel.gameObject.SetActive(false);
		}
		else 
		{
			panel.gameObject.SetActive(true);
		}
	}
}
