using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class RealmSysManager : MonoBehaviour {

	public UILabel RealmLevel;  //本页的境界阶段
	public UILabel SoulPoint;   //总共的魂石个数

	public RealmPage []pages;  //境界页面

	public UILabel AllRealmLevel; //统计页面境界等级显示 和本页的相同
	public UILabel curOpenRealmNum; //本页开启了几个点 
	public UILabel []ProName; //总的加成属性名字1
	public UILabel []ProValue;//总的加成属性数值1


	// Use this for initialization
	void Start () 
	{
		MonoInstancePool.getInstance<HeroManager> ().addTempHero ();
		refresh ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		HeroData data = MonoInstancePool.getInstance<HeroManager>().getCurShowHero();
		HeroRealm realm = data.realmList;
		if(realm.isDirty)
		{
			realm.isDirty = false;
			refresh();
		}
	}
	public void refresh()
	{
		HeroData data = MonoInstancePool.getInstance<HeroManager>().getCurShowHero();
		HeroRealm realm = data.realmList;
		int templateID = data.templateID;
		int curPage = realm.curPage();
		int curIdx = realm.curStarIdx();
		int curLevel = realm.curRealmLevel;
//		int curPage = 0;
//		int curIdx = 0;
//		int curLevel = 0;
//		int templat\eID = 100001;
		if(curPage > pages.Length)
		{
			return;
		}
		for(int i = 0; i < pages.Length; i++)
		{
			pages[i].gameObject.SetActive(false);
		}
		curSelectWindow = curPage;	//保存当前页面
		pages[curPage].gameObject.SetActive (true);
		pages [curPage].refreh ( curIdx);
		pages[curPage].refreshProAndCostPos (curIdx);
		pages [curPage].refreshProperty (templateID,curLevel);

		string name = StaticRealmframe.Instance ().getStr (curLevel, "name");
		int num = StaticRealmframe.Instance ().getInt(curLevel, "level");
		if(num > 0){
			RealmLevel.text = name + " [85ff16]+" + num;
		}
		else {
			RealmLevel.text = name;
		}
		AllRealmLevel.text = RealmLevel.text;

		SoulPoint.text = ""+MonoInstancePool.getInstance<UserData> ().soulPoint;


		Dictionary<int, int> pro = realm.getRealmEffectDic ();
		if(curIdx > 0)
		{
			curOpenRealmNum.gameObject.SetActive(true);
			curOpenRealmNum.text = "" + curIdx + "阶";
		}
		else 
		{
			curOpenRealmNum.gameObject.SetActive(false);
		}
		for(int i = 0; i < ProName.Length; i++)
		{
			ProName[i].gameObject.SetActive(false);
		}
		for(int i = 0; i < pro.Count; i++)
		{
			int type = pro.ElementAt(i).Key;
			int value = pro.ElementAt(i).Value;
			string ss = GlobalDef.HeroPropertyName[type];
			ProName[i].gameObject.SetActive(true);
			ProName[i].text = ss;
			ProValue[i].text = "" + value;
		}
	}
	public int curSelectStar{get; set;}
	public int curSelectWindow{ get; set;}
	public void lightCurStarItem()//点亮当前操作的境界点
	{
		pages [curSelectWindow].ReamlStars [curSelectStar].showLight ();

//		//update data
		HeroData data = MonoInstancePool.getInstance<HeroManager>().getCurShowHero();
		HeroRealm realm = data.realmList;
//		realm.curRealmLevel += 1;
		realm.isDirty = true;
	}
	public void runBarAction()//播放进度条动画
	{
		if(curSelectStar > 0)
		{
			pages [curSelectWindow].ReamlStars [curSelectStar-1].barEffect.startRunAni();
		}
		else
		{
//			//update data
			HeroData data = MonoInstancePool.getInstance<HeroManager>().getCurShowHero();
			HeroRealm realm = data.realmList;
//			realm.curRealmLevel += 1;
			realm.isDirty = true;
		}
	}
}
