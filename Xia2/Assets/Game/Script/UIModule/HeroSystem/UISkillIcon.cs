using UnityEngine;
using System.Collections;

public class UISkillIcon : MonoBehaviour {
	public UISprite Back;
	public UISprite Icon;
	public UISprite Lock;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	public void refresh(SkillItem skill)
	{
		if(null == skill)
			return;
		string icon = skill.icon;
		Icon.spriteName = icon;
		setLock (skill.active);
	}
	void setLock(bool l)
	{
		if(l)
		{
			Lock.gameObject.SetActive(false);
			Color c = Back.color;
			c.a = 1f;
			Icon.color = c;
		}
		else 
		{
			Lock.gameObject.SetActive(true);
			Color c = Back.color;
			c.a = 0.2f;
			Icon.color = c;
		}
	}
	void OnClick()
	{

	}
}
