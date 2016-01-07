using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class HeadItemManager : MonoBehaviour {

	public UIScrollView scrollView;
	public Transform headItem;
	public UISprite selectBorder;
	public int H_Interval = 10;

	int HEAD_WIDTH = 82;
	// Use this for initialization
	void Start () 
	{
	
	}
	Dictionary<long, Transform> headDict = new Dictionary<long, Transform>();
	// Update is called once per frame
	void Update () 
	{
		if(MonoInstancePool.getInstance<HeroManager>().isDirty)
		{
			MonoInstancePool.getInstance<HeroManager>().isDirty = false;
			refreshBag();
		}
	}
	public void refreshBag()
	{
		clear();

		int num = MonoInstancePool.getInstance<HeroManager>().getCount();
		for(int i = 0; i < num; i++)
		{
			HeroData data = MonoInstancePool.getInstance<HeroManager>().getHeroByIdx(i);
			if(null == data)
			{
				break;
			}
		
			Transform instance = Instantiate(headItem) as Transform;
			instance.gameObject.SetActive(true);
			instance.transform.parent = scrollView.transform;
			instance.transform.localScale = Vector3.one;
			instance.transform.localPosition = Vector3.zero;
			int star = data.starLevel;
			int level = data.level;
			HeadItemInfo info = instance.GetComponentInChildren<HeadItemInfo>();
			if(info != null)
			{
				info.headIndex = i;
				info.setStar(star);
				info.setLevel(level);
				info.HeadIcon.spriteName = data.icon_middle;
			}



			Vector3 pos = Vector3.zero;
			pos.x = pos.x - scrollView.panel.width/2 + HEAD_WIDTH/2 + i * HEAD_WIDTH + i*H_Interval;
			instance.transform.localPosition = pos;

			headDict.Add(data.guid, instance);
		}

		refreshSelectBorder();
	}
	public void refreshSelectBorder()
	{
		int curIdx = MonoInstancePool.getInstance<HeroManager>().curSelectHero;
		if(curIdx < 0 || curIdx >= headDict.Count)
		{
			return;
		}
		selectBorder.gameObject.SetActive(true);
//		selectBorder.transform.parent = headDict.ElementAt(curIdx).Value.transform;
		selectBorder.transform.localPosition = headDict.ElementAt(curIdx).Value.transform.localPosition;
	}
	public void clear()
	{
		for(int i = 0; i < headDict.Count; i++)
		{
			Destroy(headDict.ElementAt(i).Value.gameObject);
		}
		headDict.Clear();
	}
}
