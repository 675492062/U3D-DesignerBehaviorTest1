using UnityEngine;
using System.Collections;

public class ScaleTo : MonoBehaviour {

	float scaleTo;
	float startScaleValue;
	float scaleToTime;
	float scaleSpeed;
	float backSpeed;
	bool start;
	bool back;
//	float curScale;
	// Use this for initialization
	void Start () {
		back = false;
		start = true;
	}
	void Awake()
	{
	}
	void init()
	{
		scaleTo = 1.1f;
		startScaleValue = 0.6f;
		scaleSpeed = 0.1f;
		backSpeed = 0.05f;
		scaleToTime = 1.0f;
	}
	// Update is called once per frame
	void Update () {
		if(back)
		{
			Vector3 backScale = transform.localScale;
			if(backScale.x <= 1.0f)
			{
				back = false;
				return;
			}
			backScale.x -= backSpeed;
			backScale.y -= backSpeed;
			transform.localScale = backScale;
			return;
		}

		if(!start)
		{
			return;
		}
//
		Vector3 scale = transform.localScale;
		if(scale.x >= 1.0f)
		{
			start = false;
			back = true;
			return;
		}
		Debug.Log("---scale scale " + scale);
		scale.x += scaleSpeed;
		scale.y += scaleSpeed;
		transform.localScale = scale;
	}

	public void runAction()
	{
		start = true;
		init();
	}
	public void setScale(float value)
	{
		Vector3 scale = transform.localScale;
		scale.x = value;
		scale.y = value;
		transform.localScale = scale;
	}
}
