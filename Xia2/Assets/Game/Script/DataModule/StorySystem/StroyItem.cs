using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class StroyStruct
{
	public string heroPic; //英雄图片
	public int pos;        //位置      0 left; 1 right;
	public int fx;         //效果类型
	public string des;        //内容
}
public class StoryItem : BaseItem 
{
	Dictionary<int, StroyStruct> storyDict = new Dictionary<int, StroyStruct>();
	public int type = -1;
	public int endType{ get{ return StaticDialog.Instance().getInt(templateID, "endtype");}}
	public int endParam{ get{ return StaticDialog.Instance().getInt(templateID, "missionid");}}
	public StoryItem()
	{
	}

	public virtual void parseData(int tempID)
	{
		storyDict.Clear();

		templateID = tempID;

		int startID = StaticDialog.Instance().getInt(templateID, "starid");
		int endID = StaticDialog.Instance().getInt(templateID, "endid");

		for(int i = startID; i <= endID; i++)
		{
			string res = StaticSentence.Instance().getStr(i, "res");
			int pos = StaticSentence.Instance().getInt(i, "pos");
			int fx = StaticSentence.Instance().getInt(i, "fx");
			string des = StaticSentence.Instance().getStr(i, "detail");

			StroyStruct stroy = new StroyStruct();
			stroy.heroPic = res;
			stroy.pos = pos;
			stroy.fx = fx;
			stroy.des = des;
			storyDict.Add(i - startID, stroy);
		}
	}

	public int getCount()
	{
		return storyDict.Count;
	}
	public StroyStruct getDataByIdx(int idx)
	{
		if(idx < 0 || idx >= storyDict.Count)
		{
			return null;
		}
		return storyDict[idx];
	}
}
