using UnityEngine;
using System.Collections;

public class StroyPlay : MonoBehaviour {
	enum Hero_Pos  //坐标类型
	{
		E_LEFT,    //出现在左边
		E_RIGHT,   //出现在右边
	}

	public UISprite []LeftHero;    // 左边英雄半身像的数组
	public UISprite []RightHero;   // 右边英雄半身像的数组
	public UISprite TextList;      // 对话内容
	public UIPanel screenPanel;    // 父panel对象
	public UISprite Back_Top;
	public UISprite Back_Bottom;

	StoryItem story = new StoryItem();  //初始化对话数据对象
	int curIdx = 0;       //当前说到第几句的索引
	int curLeftIdx = 0;   //当前左边半身像的索引 数组下标
	int curRightIdx = 0;  //当前右边半身像的索引 数组下标
	Vector2 leftPos = new Vector2(0,0); //记录左边的坐标
	Vector2 rightPos = new Vector2(0,0);//记录右边的坐标
	float heroPicY = 0;      //
	UITextList textList;     // 对话内容
	float gobackTime = 0.2f; // 撤回去时候的时间
	float goFrontTime = 0.1f;// 高亮显示时候的时间
	Color blackColor = new Color(0.5f, 0.5f, 0.5f);   // 变暗的颜色值
	Color diffuseColor = new Color(1.0f, 1.0f, 1.0f); // 变亮的颜色值
	float goFrontPos = 0f;
	float goBackPos = 0f;
	public bool bFinish = false;

	void Awake()
	{
		textList = TextList.GetComponentInChildren<UITextList>();
		Back_Top.width = 2000;
		Back_Top.height = (int)Screen.height/4;
		Back_Bottom.width = 2000;
		Back_Bottom.height = (int)Screen.height/4;
		TextList.width = (int)(Screen.width * 0.8f);
		goFrontPos = Screen.width /4f;
		goBackPos = Screen.width /3f;
		bFinish = false;
	}
	// Use this for initialization
	void Start () 
	{
//		play(611001);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetMouseButtonUp(0) && !bFinish ) // play next 
		{
			next();
		}
	}
	public void goBack(int type)
	{
		if(type == (int)Hero_Pos.E_LEFT)
		{
			if(leftPos == Vector2.zero)
			{
				return;
			}
			Vector3 target = LeftHero[curLeftIdx].transform.localPosition;
			target.x = -1*goBackPos;
			TweenPosition.Begin(LeftHero[curLeftIdx].gameObject, gobackTime, target);

			LeftHero[curLeftIdx].color = blackColor;
		}
		else if(type == (int)Hero_Pos.E_RIGHT)
		{
			if(rightPos == Vector2.zero)
			{
				return;
			}
			Vector3 target = RightHero[curRightIdx].transform.localPosition;
			target.x = goBackPos;
			TweenPosition.Begin(RightHero[curRightIdx].gameObject, gobackTime, target);

			RightHero[curRightIdx].color = blackColor;
		}
	}
	public void goFront(int type)
	{
		if(type == (int)Hero_Pos.E_LEFT)
		{
			//有新的人物加进来 进行替换
			StroyStruct nextData = story.getDataByIdx(curIdx);
			if(nextData != null)
			{
				if(LeftHero[curLeftIdx].spriteName != nextData.heroPic && 
				   nextData.pos == (int)Hero_Pos.E_LEFT)
				{
					addNewLeftHero(nextData);
					LeftHero[curLeftIdx].color = diffuseColor;
					return;
				}
			}
			//退到后边 变暗显示
			Vector3 target = LeftHero[curLeftIdx].transform.localPosition;
			target.x = -1*goFrontPos;
			TweenPosition.Begin(LeftHero[curLeftIdx].gameObject, goFrontTime, target);

			LeftHero[curLeftIdx].color = diffuseColor;
		}
		else if(type == (int)Hero_Pos.E_RIGHT)
		{
			//有新的人物加进来 进行替换
			StroyStruct nextData = story.getDataByIdx(curIdx);
			if(nextData != null)
			{
				if(RightHero[curRightIdx].spriteName != nextData.heroPic &&
				   nextData.pos == (int)Hero_Pos.E_RIGHT)
				{
					addNewRightHero(nextData);
					RightHero[curRightIdx].color = diffuseColor;
					return;
				}
			}
			//退到后边 变暗显示
			Vector3 target = RightHero[curRightIdx].transform.localPosition;
			target.x = goFrontPos;
			TweenPosition.Begin(RightHero[curRightIdx].gameObject, goFrontTime, target);

			RightHero[curRightIdx].color = diffuseColor;
		}
	}
	public void play(int templateID)
	{
		story.parseData(templateID);

		StroyStruct data = story.getDataByIdx(curIdx);
		if(data.pos == (int)Hero_Pos.E_LEFT)
		{
			if(leftPos == Vector2.zero)
			{
				leftPos.x =  -1*screenPanel.width/2 - LeftHero[curLeftIdx].width;
				float h = 0;// (screenPanel.height/2 - LeftHero[curLeftIdx].height/2);
				leftPos.y = 0;//h > 0 ? -1*h : h;
			}
			LeftHero[curLeftIdx].spriteName = data.heroPic;
			LeftHero[curLeftIdx].transform.localPosition = leftPos;

			Vector3 target = LeftHero[curLeftIdx].transform.localPosition;
			target.x = -1*goFrontPos;
			TweenPosition.Begin(LeftHero[curLeftIdx].gameObject, goFrontTime, target);

			addTalkText(data.des);
		}
		else if(data.pos == (int)Hero_Pos.E_RIGHT)
		{
			if(rightPos == Vector2.zero)
			{
				rightPos.x = screenPanel.width/2 + RightHero[curRightIdx].width;
				float h = 0;//(screenPanel.height/2 - RightHero[curRightIdx].height/2);
				rightPos.y = 0;// h > 0 ? -1*h : h;
			}
			RightHero[curRightIdx].spriteName = data.heroPic;
			RightHero[curRightIdx].transform.localPosition = leftPos;
			
			Vector3 target = RightHero[curRightIdx].transform.localPosition;
			target.x = -1*goFrontPos;
			TweenPosition.Begin(RightHero[curRightIdx].gameObject, goFrontTime, target);
			
			addTalkText(data.des);
		}
	}
	public void next()
	{
		curIdx++;

		StroyStruct data = story.getDataByIdx(curIdx);
		if(data == null) //finish
		{
			finish();
			return;
		}
		addTalkText(data.des);

		if(data.pos == (int)Hero_Pos.E_LEFT)
		{
			if(leftPos == Vector2.zero)
			{
				leftPos.x =  -1*screenPanel.width/2 - LeftHero[curLeftIdx].width;
				float h = heroPicY;//(screenPanel.height/2 - LeftHero[curLeftIdx].height/2);
				leftPos.y = heroPicY;//h > 0 ? -1*h : h;

				LeftHero[curLeftIdx].transform.localPosition = leftPos;
				
				Vector3 target = LeftHero[curLeftIdx].transform.localPosition;
				target.x = -1*goFrontPos;
				TweenPosition.Begin(LeftHero[curLeftIdx].gameObject, goFrontTime, target);

				if(rightPos == Vector2.zero)
				{
					goBack((int)Hero_Pos.E_RIGHT);
				}
			}
			else
			{
				goFront((int)Hero_Pos.E_LEFT);
				goBack((int)Hero_Pos.E_RIGHT);
			}
		}
		else if(data.pos == (int)Hero_Pos.E_RIGHT)
		{
			if(rightPos == Vector2.zero)
			{
				rightPos.x = screenPanel.width/2 + RightHero[curRightIdx].width;
				float h = heroPicY;//(screenPanel.height/2 - RightHero[curRightIdx].height/2);
				rightPos.y = heroPicY;//h > 0 ? -1*h : h;

				RightHero[curRightIdx].transform.localPosition = rightPos;

				Vector3 target = RightHero[curRightIdx].transform.localPosition;
				target.x = goFrontPos;
				TweenPosition.Begin(RightHero[curRightIdx].gameObject, goFrontTime, target);

				if(leftPos != Vector2.zero)
				{
					goBack((int)Hero_Pos.E_LEFT);
				}
			}
			else
			{
				
				goFront((int)Hero_Pos.E_RIGHT);
				goBack((int)Hero_Pos.E_LEFT);
			}
		}
	}
	void addTalkText(string text)
	{
		textList.Clear();
		textList.Add(text);

		Vector3 scale = TextList.transform.localScale;
		scale.y = 0;
		TextList.transform.localScale = scale;
		scale = Vector3.one;
		TweenScale.Begin(TextList.gameObject, 0.1f, scale);
	}
	public void addNewLeftHero(StroyStruct nextData)
	{
		int tempLeftIdx = curLeftIdx;
		if(tempLeftIdx >= (LeftHero.Length-1))
		{
			tempLeftIdx = 0;
		}

		UISprite new_sp = Instantiate(LeftHero[curLeftIdx]) as UISprite;
		new_sp.transform.parent = screenPanel.transform;
		new_sp.transform.localScale = Vector3.one;
		new_sp.transform.localPosition = Vector3.zero;
		new_sp.spriteName = nextData.heroPic;
		LeftHero[++tempLeftIdx] = new_sp;
		//pos
		Vector3 left_out = LeftHero[tempLeftIdx].transform.localPosition;
		left_out.x =  -1*screenPanel.width/2 - LeftHero[tempLeftIdx].width;
		float h = heroPicY;//(screenPanel.height/2 - LeftHero[tempLeftIdx].height/2);
		left_out.y = heroPicY;//h > 0 ? -1*h : h;
		LeftHero[tempLeftIdx].transform.localPosition = left_out;

		//oldPic goback
		Vector3 pos = LeftHero[curLeftIdx].transform.localPosition;
		pos.x = -1*LeftHero[curLeftIdx].width/2 - screenPanel.width;
		TweenPosition.Begin(LeftHero[curLeftIdx].gameObject, gobackTime, pos);
		curLeftIdx = tempLeftIdx;

		//newPic goFront
		pos = LeftHero[curLeftIdx].transform.localPosition;
		pos.x = -1*goFrontPos;
		TweenPosition.Begin(LeftHero[curLeftIdx].gameObject, gobackTime, pos);
	}
	public void addNewRightHero(StroyStruct nextData)
	{
		int tempRightIdx = curRightIdx;
		if(tempRightIdx >= RightHero.Length-1)
		{
			tempRightIdx = 0;
		}
		
		UISprite new_sp = Instantiate(RightHero[curRightIdx]) as UISprite;
		new_sp.transform.parent = screenPanel.transform;
		new_sp.transform.localScale = Vector3.one;
		new_sp.transform.localPosition = Vector3.zero;
		new_sp.spriteName = nextData.heroPic;
		RightHero[++tempRightIdx] = new_sp;
		//pos
		Vector3 right_out = RightHero[tempRightIdx].transform.localPosition;
		right_out.x =  screenPanel.width/2 + RightHero[tempRightIdx].width;
		float h = heroPicY;//(screenPanel.height/2 - RightHero[tempRightIdx].height/2);
		right_out.y = heroPicY;//h > 0 ? -1*h : h;
		RightHero[tempRightIdx].transform.localPosition = right_out;
		//oldPic goback
		Vector3 pos = RightHero[curRightIdx].transform.localPosition;
		pos.x = RightHero[curRightIdx].width/2 + screenPanel.width;
		TweenPosition.Begin(RightHero[curRightIdx].gameObject, gobackTime, pos);
		curRightIdx = tempRightIdx;

		//newPic goFront
		pos = RightHero[curRightIdx].transform.localPosition;
		pos.x = goFrontPos;
		TweenPosition.Begin(RightHero[curRightIdx].gameObject, gobackTime, pos);
	}
	public void finish()
	{
		if(bFinish)
		{
			return;
		}

		bFinish = true;

		Vector3 tempRight = RightHero[curRightIdx].transform.localPosition;
		tempRight.x = screenPanel.width*2;
		TweenPosition.Begin(RightHero[curRightIdx].gameObject, 0.5f, tempRight);

		Vector3 tempLeft = LeftHero[curLeftIdx].transform.localPosition;
		tempLeft.x = -1*screenPanel.width*2;
		TweenPosition.Begin(LeftHero[curLeftIdx].gameObject, 0.5f, tempLeft);

		Vector3 tempBottom = Back_Bottom.transform.localPosition;
		tempBottom.y = -1*screenPanel.height*2;
		TweenPosition.Begin(Back_Bottom.gameObject, 0.5f, tempBottom);
		TweenPosition.Begin(TextList.gameObject, 0.5f, tempBottom);

		Vector3 tempTop = Back_Top.transform.localPosition;
		tempTop.y = screenPanel.height*2;
		TweenPosition.Begin(Back_Top.gameObject, 0.5f, tempTop);

		//end 
		StroyManager manager = (StroyManager)FindObjectOfType(typeof(StroyManager));
		if(manager != null)
		{
			manager.endStroy(story.endParam);
		}
	}
}
