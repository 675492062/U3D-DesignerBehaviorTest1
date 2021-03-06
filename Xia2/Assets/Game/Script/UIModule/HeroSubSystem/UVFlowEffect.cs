using UnityEngine;
using System.Collections;

public class UVFlowEffect : MonoBehaviour {

//	public Transform start;
//	public Transform end;

	float updateInterval = 0.06f;
	float tempTime = 0f;
	Rect UV;
	UITexture tex;
	float speed = 0.05f;
	// Use this for initialization
	void Start () 
	{
		tex = GetComponentInChildren<UITexture> ();
		UV = tex.uvRect;
	}
	
	// Update is called once per frame
	void Update () 
	{
		tempTime += Time.deltaTime;
		if(tempTime >= updateInterval)
		{
			tempTime = 0f;
			UV.x -= speed;
			tex.uvRect = UV;

		}
	}
}
