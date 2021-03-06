using UnityEngine;
using System.Collections;

public class FightListItem : MonoBehaviour {

	public int idx; //第几个位置
	public UISprite Icon;
	public UILabel  FateNum;
	public Transform StarGroup;
	public UISprite []Stars = new UISprite[5];
	public UISprite Empty;
	public UISprite Lock;
	UILabel  unLockLevel;
	public UISprite BackGround;
	public UISprite HighLight;
	public UILabel Level;

	bool locked = false;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	public void refresh(HeroData data)
	{
		Icon.spriteName = data.icon_middle;
		showNormal ();
		int star = data.starLevel;
		setStarLv (star);
		Level.text = "Lv." + data.level;
//		Icon.spriteName = "";
//		if(FateNum != null)
//		{
//			FateNum = "1缘份";
//		}
	}
	public void showEmpty()
	{
		locked = false;
		if (Icon != null)
			Icon.gameObject.SetActive (false);
		if (StarGroup != null)
			StarGroup.gameObject.SetActive (false);
		if (FateNum != null)
			FateNum.gameObject.SetActive (false);
		if (Level != null)
			Level.gameObject.SetActive (false);
		Lock.gameObject.SetActive(false);

		Empty.gameObject.SetActive (true);
		showHighLight ();
	}
	public void showLocked(int needLevel)
	{
		locked = true;
		if (Icon != null)
			Icon.gameObject.SetActive (false);
		if (StarGroup != null)
			StarGroup.gameObject.SetActive (false);
		if (FateNum != null)
			FateNum.gameObject.SetActive (false);
		if (Level != null)
			Level.gameObject.SetActive (false);
		Empty.gameObject.SetActive (false);

		Lock.gameObject.SetActive(true);
//		BackGround.spriteName = "FS-16";
		unLockLevel = Lock.GetComponentInChildren<UILabel> ();
		if(unLockLevel != null)
		{
			unLockLevel.text = ""+needLevel + "级解锁";
		}

		hideHighLight();
	}
	public void showNormal()
	{
		locked = false;
		if (Icon != null)
			Icon.gameObject.SetActive (true);
		if (StarGroup != null)
			StarGroup.gameObject.SetActive (true);
		if (FateNum != null)
			FateNum.gameObject.SetActive (true);
		if (Level != null)
			Level.gameObject.SetActive (true);
		Lock.gameObject.SetActive(false);
		Empty.gameObject.SetActive (false);
		showHighLight();
	}
	public void showHighLight()
	{
		HighLight.gameObject.SetActive (true);
	}
	public void hideHighLight()
	{
		HighLight.gameObject.SetActive (false);
	}
	public void setStarLv(int lv)
	{
		for(int i = 0; i < Stars.Length; i++)
		{
			Stars[i].gameObject.SetActive(false);
//			if(i < lv)
//			{
//				Stars[i].spriteName = "hb_22";//星星
//			}
//			else
//			{
//				Stars[i].spriteName = "hb_23";//黑色底
//			}
		}
	}
	void OnClick()
	{
		if(locked)
		{
			return;
		}
		UIPanel panel = NGUITools.FindInParents<UIPanel>(gameObject);
		HeroSysFightList list = panel.GetComponentInChildren<HeroSysFightList> ();
		// 0:普通进入  1:点击出战按钮进入 
		int enterType = list.enterType;

		//普通方式进去不可以点击有头像的位置
		if(enterType == 1)
		{
			HeroListWindowManager listWindow = (HeroListWindowManager)FindObjectOfType(typeof(HeroListWindowManager));
			int curSelectedIdx = listWindow.curSlectedIdx;
			long guid = MonoInstancePool.getInstance<HeroManager>().getHeroByIdx(curSelectedIdx).guid;
			MonoInstancePool.getInstance<SendHeroSysMsgHander>().sendSetFightHeroReq( guid, idx);

			HeroSysUIManager manager = (HeroSysUIManager)FindObjectOfType(typeof(HeroSysUIManager));
			if(manager != null)
			{
				manager.hideFightListWindow();
			}
		}
	}
}
