using UnityEngine;
using System.Collections;

public class AddNumEffect : MonoBehaviour {
	public UILabel num;
	public UISprite sp;
	int startNum = 0;
	int endNum = 0;
	int allChangeNum = 0;
	
	float curTime = 0f;
	bool finish = true;
	float upTime = 0.3f;
	float waitTime = 0.5f;
	float leftTime = 0.5f;
	bool isRuning = false;

	int state = 0;

	enum State
	{
		WAIT,
		UP,
		LEFT,
		END,
	}
	// Use this for initialization
	void Start () 
	{
//		start(400,500);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(finish)
		{
			return;
		}

		curTime += Time.deltaTime;
		switch(state)
		{
		case (int)State.UP:
			if(curTime >= upTime)
			{
				state++;
				state++;
				curTime = 0f;
			}

			break;
		case (int)State.WAIT:
			if(curTime >= waitTime)
			{
				curTime = 0f;
				state = (int)State.UP;
				runAction();
//				runLeft();
			}
			break;
//		case (int)State.LEFT:
//			if(curTime >= leftTime)
//			{
//				curTime = 0f;
//				state++;
//			}
//			break;
		case (int)State.END:
			Color c = num.color;
			c.a -= 0.01f;
			num.color = c;
			sp.color = c;
			if(c.a <= 0)
			{
				finish = true;
				isRuning = false;
				BagUIManager manager = (BagUIManager)FindObjectOfType(typeof(BagUIManager));
				if(manager)
				{
					manager.runFightNumEffect();
				}

			}
			break;
		}
	}
	public void start(int start, int end)
	{
		finish = false;
		startNum = start;
		endNum = end;
		allChangeNum = start - end;
		curTime = 0f;

		num.text = ""+startNum;

		Color c = num.color;
		c.a = 0f;
		num.color = c;
		sp.color = c;
		state = 0;

		Vector3 pos = transform.localPosition;
		pos.y = 0;
		pos.x = -43.42f;
		transform.localPosition = pos;
	}
	public void runAction()
	{
		isRuning = true;
		Color c = num.color;
		c.a = 1f;
		num.color = c;
		sp.color = c;

		Vector3 pos = transform.localPosition;
		pos.y = 85;
		TweenPosition.Begin(gameObject, 1f, pos);
	}
	public void runLeft()
	{
		Vector3 pos = transform.localPosition;
		pos.x = -143.42f;
		TweenPosition.Begin(gameObject, 0.5f, pos);
	}
}
