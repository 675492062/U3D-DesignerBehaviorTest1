using UnityEngine;
using System.Collections;

public class MoveTo : MonoBehaviour {

	float unitTime = 1f/40.0f;
	float unitSpeedX = 0.0f;
	float unitSpeedY = 0.0f;
	Vector3 targetPos;
	bool run = true;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!run)
			return;
		float dis = Vector3.Distance(transform.localPosition, targetPos);
		if(dis <= 2)
		{
			run = false;
			return;
		}
		Vector3 pos = transform.localPosition;
		pos.x += unitSpeedX;
		pos.y += unitSpeedY;
		transform.localPosition = pos;
	}
	public void moveTo(Vector3 target, float time)
	{
		run = true;
		targetPos = target;
		int times = (int)(time/unitTime);
		unitSpeedX = (targetPos.x - transform.localPosition.x)/times;
		unitSpeedY = (targetPos.y - transform.localPosition.y)/times;
	}
}
