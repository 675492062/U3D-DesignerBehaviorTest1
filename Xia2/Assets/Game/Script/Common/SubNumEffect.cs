using UnityEngine;
using System.Collections;

public class SubNumEffect : MonoBehaviour {

	public UILabel num;
	public UISprite sp;
	int startNum = 0;
	int endNum = 0;
	int allChangeNum = 1;
	
	float interval = 0.1f;
	float curTime = 0f;
	bool finish = true;
	// Use this for initialization
	void Start () 
	{
//		start(500,400);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(finish)
		{
			return;
		}
		
		curTime += Time.deltaTime;
		if(curTime >= interval)
		{
			startNum--;
			
			if(startNum < endNum)
			{
				finish = true;
				gameObject.SetActive(false);
			}
			else 
			{
				num.text = ""+startNum;
				float now = (float)(endNum - startNum)/(float)allChangeNum;
				Color c =  num.color;
				c.a = now;
				num.color = c;
				sp.color = c;
			}
		}
	}
	public void start(int start, int end)
	{
		finish = false;
		startNum = start;
		endNum = end;
		allChangeNum = end - start;
		
		num.text = ""+startNum;
		
		Vector3 pos = transform.localPosition;
		pos.y = 80;
		transform.localPosition = pos;
		
		pos.y = 0;
		TweenPosition.Begin(gameObject, 0.5f, pos);
	}
}
