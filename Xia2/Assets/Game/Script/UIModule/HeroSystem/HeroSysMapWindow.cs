using UnityEngine;
using System.Collections;

public class HeroSysMapWindow : MonoBehaviour {
	public UISprite headBack;  // 头像背景
	public UISprite headIcon;  // 头像图标
	public UILabel  heroName;  // 英雄名称
	public UILabel  debrisName;// 英雄碎片个数
	public UILabel  canNotGetDes;// 无法获取的描述

	public UIScrollView levelList;  // 关卡列表
	public Transform levelListItem; // 关卡项
	public UIProgressBar processBar;// 滚动进度
	// Use this for initialization
	void Start () 
	{
		showScrollView ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	public void hideMapWindow()
	{
		HeroListWindowManager manager = (HeroListWindowManager)FindObjectOfType(typeof(HeroListWindowManager));
		if(manager != null)
		{
			manager.hideBlackBack();
		}
		this.gameObject.SetActive (false);
	}
	public void showCanNotGet()
	{
		levelList.gameObject.SetActive(false);  // 关卡列表
		processBar.gameObject.SetActive(false);
		canNotGetDes.gameObject.SetActive (true);
	}
	public void showScrollView()
	{
		levelList.gameObject.SetActive(true);  // 关卡列表
		processBar.gameObject.SetActive(true);
		canNotGetDes.gameObject.SetActive (false);
	}
}
