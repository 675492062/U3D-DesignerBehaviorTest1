using UnityEngine;
using System.Collections;

public class testScrollView : MonoBehaviour {

	public UIScrollView scrollView;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnClick()
	{
		scrollView.SetDragAmount(0.5f, 1f, false);
	}
}
