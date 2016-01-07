using UnityEngine;
using System.Collections;

public class AddFightNum : MonoBehaviour {

	float interval = 0.1f;
	float curTime = 0f;
	int startNum = 0; 
	int endNum = 0;
	bool finish = false;
	UILabel label = null;
	// Use this for initialization
	void Start () 
	{
		label = GetComponentInChildren<UILabel>();
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
			startNum++;
			if(startNum > endNum)
			{
				finish = true;
				return;
			}
			label.text = ""+startNum;
		}
	}
	public void run(int start, int end)
	{
		start = System.Int32.Parse(label.text);
		end = start + 100;
		label.text = ""+start;
		startNum = start;
		endNum = end;
		curTime = 0f;
		finish = false;
	}
}
