using UnityEngine;
using System.Collections;

public class ClosePanel : MonoBehaviour {

	public UIPanel panel;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnClick()
	{
		if(panel != null)
		{
			panel.gameObject.SetActive(false);
		}
		UIEventTrigger.current = null;
	}
}
