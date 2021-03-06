using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class HeroListWindowManager : MonoBehaviour {

	public UIScrollView scrollView;
	public UISprite    scrollViewBack;
	public Transform   HeroItemPrefab;
	public UISprite    blackBack;
	public Transform   relativeCenterPos;
	public UIWidget    page;

	// the page dictionary
	Dictionary<long , UIWidget> itemPageDict = new Dictionary<long, UIWidget>();
	// the item dictionary
	Dictionary<long , Transform> HeroItemDict = new Dictionary<long, Transform>();

	int X_Offset = 10;
	int Y_Offset = 20;
	int Grid_Width = 200;
	int Grid_Heigh = 220;
	int Grid_Interval = 0;
	int curFilterType = 0;  //当前筛选类型
	int onePageCount = 10;  //一页的头像个数
	int oneLineCount = 5;   //一行的头像个数
	public int curSlectedIdx{get; set;}
	public long curSlectedGUID{get; set;}
	public int lastSlectedIdx{get; set;}
	void Awake()
	{
		curSlectedIdx  = -1;
		curSlectedGUID = -1;
		lastSlectedIdx = -1;
	}
	// Use this for initializations
	void Start () 
	{
//		MonoInstancePool.getInstance<HeroManager> ().addTempHero ();
		addHeroItem ();

		// 现实金币 体力
		UIPanel panel = NGUITools.FindInParents<UIPanel> (gameObject);
		UICurrencyManager.Show (transform,panel.depth + 1);
	}
	void OnEnable()
	{
		refrehsShowState();
	}
	// Update is called once per frame
	void Update () 
	{
		if(MonoInstancePool.getInstance<HeroManager> ().isDirty)
		{
			MonoInstancePool.getInstance<HeroManager> ().isDirty = false;
			refrehsShowState();
		}
	}

	public void filter(int type)
	{
		if(curFilterType == type)
		{
			return;
		}
		curFilterType = type;
		hideAll();
		HeroManager manager = MonoInstancePool.getInstance<HeroManager>();
		if(null == manager)
		{
			return;
		}
		int initNum = manager.getCount();
		int idx = 0;
		for(int i = 0; i < initNum; i++)
		{
			HeroData data = manager.getHeroByIdx(i);
			if(data.property.country == curFilterType || curFilterType == (int)GlobalDef.HeroCountry.ROLE_NORMAL)
			{
				HeroItemDict.ElementAt(idx).Value.gameObject.SetActive(true);
				HeroItemProperty item = HeroItemDict.ElementAt(idx).Value.GetComponentInChildren<HeroItemProperty>();
				item.refreshInfo(data);
				item.idx = idx;
				item.heroGuid = data.guid;
				idx++;
			}
		}
	}
	public void addPage(int num)
	{
		int pageNum = num / onePageCount;
		float more = (float)num / (float)onePageCount;
		if(more > pageNum)
			pageNum++;

		for(int i = 0; i < pageNum; i++)
		{
			if(i < itemPageDict.Count)
				continue;
			if(null == page)
			{
				Debug.LogError("have not page prefab!");
				break;
			}
			UIWidget instance = Instantiate(page) as UIWidget;
			instance.transform.parent = scrollView.transform;
			instance.transform.localScale = Vector3.one;
			Vector3 pos = Vector3.zero;
			pos.x = i * instance.width;
			instance.transform.localPosition = pos;
			itemPageDict.Add (i, instance);
		}
	}
	public void addHeroItem()
	{
		delAll();
		HeroManager manager = MonoInstancePool.getInstance<HeroManager>();
		if(null == manager)
		{
			return;
		}
		int initNum = manager.getCount();
		addPage(initNum); //添加页面
		for(int i = 0; i < initNum; i++)
		{
			HeroData data = manager.getHeroByIdx(i);
			if(!data.activate)
			{
				continue;
			}
			int pageIdx = i / onePageCount;
			int num = i % onePageCount;
			int lineIdx = num / oneLineCount;

			Vector3 pos = new Vector3 ();
			Debug.Log("page idx: " + pageIdx);
			pos.x = -1 * itemPageDict[pageIdx].width / 2;
			pos.y = itemPageDict[pageIdx].height / 2;
			
			Transform instance = Instantiate(HeroItemPrefab) as Transform;
			instance.gameObject.SetActive(true);
			instance.transform.parent = itemPageDict[pageIdx].transform;
			instance.transform.localScale = Vector3.one;
			if(lineIdx == 0)
			{
				pos.x += i * Grid_Width  + Grid_Width/2 + X_Offset - lineIdx*itemPageDict[pageIdx].width;
				pos.y -= lineIdx*Grid_Heigh + Grid_Heigh/2 + Y_Offset;
			}
			else if(lineIdx == 1)
			{
				int lastIdx = (pageIdx * onePageCount + num) % oneLineCount;
				pos.x = HeroItemDict.ElementAt(lastIdx).Value.transform.localPosition.x;
				pos.y -= lineIdx*Grid_Heigh + Grid_Heigh/2 + Y_Offset + lineIdx*Y_Offset/2;
			}
			instance.transform.localPosition = pos;
			//add
			HeroItemDict.Add (data.guid, instance);
			//refresh show
			HeroItemProperty pro = instance.GetComponentInChildren<HeroItemProperty> ();
			pro.refreshInfo(data);
			pro.idx = i;
			pro.heroGuid = data.guid;
		}
	}
	
	public void refrehsHeroItem()
	{
		hideAll ();
		updateMoney();
		HeroManager manager = MonoInstancePool.getInstance<HeroManager>();
		if(null == manager)
		{
			return;
		}
		int initNum = manager.getCount();
		for(int i = 0; i < initNum; i++)
		{
			HeroData data = manager.getHeroByIdx(i);
			if(i < HeroItemDict.Count)
			{
				HeroItemProperty item = HeroItemDict[data.guid].GetComponentInChildren<HeroItemProperty>();
				item.refreshInfo(data);
				item.idx = i;
				item.heroGuid = data.guid;
				return;
			}
			
			Vector3 pos = new Vector3 ();
			pos.x = (i+1) * Grid_Width + Grid_Interval*i + X_Offset;
			pos.y = 12;
			
			Transform instance = Instantiate(HeroItemPrefab) as Transform;
			instance.gameObject.SetActive(true);
			instance.transform.parent = scrollView.transform;
			instance.transform.localScale = Vector3.one;
			
			pos.x -= scrollView.panel.width / 2  + Grid_Width/2;
			instance.transform.localPosition = pos;

			HeroItemDict.Add (data.guid, instance);
			//refresh show
			HeroItemProperty pro = instance.GetComponentInChildren<HeroItemProperty> ();
			pro.refreshInfo(data);
			pro.idx = i;
			pro.heroGuid = data.guid;
		}
		blackBack.width = (int)HeroItemDict.Count * Grid_Width;
	}
	//刷新显示状态
	public void refrehsShowState()
	{
		if (HeroItemDict.Count <= 0)  //没有可刷新的就直接返回
			return;

		updateMoney ();
		HeroManager manager = MonoInstancePool.getInstance<HeroManager>();
		if(null == manager)
		{
			return;
		}
		int initNum = manager.getCount();
		int idx = 0;
		for(int i = 0; i < initNum; i++)
		{
			HeroData data = manager.getHeroByIdx(i);
			if(data.property.country == curFilterType || curFilterType == (int)GlobalDef.HeroCountry.ROLE_NORMAL)
			{
				if(idx >= HeroItemDict.Count)
				{
					break;
				}
				HeroItemDict.ElementAt(idx).Value.gameObject.SetActive(true);
				HeroItemProperty item = HeroItemDict.ElementAt(idx).Value.GetComponentInChildren<HeroItemProperty>();
				item.refreshInfo(data);
				item.idx = idx;
				item.heroGuid = data.guid;
				item.stopTempExpAni();
				idx++;
			}
		}
	}
	
	public void refrehsByData(HeroData data)
	{
		if( HeroItemDict.ContainsKey(data.guid) )
		{
			HeroItemProperty item = HeroItemDict[data.guid].GetComponentInChildren<HeroItemProperty>();
			item.refreshInfo(data);
			return;
		}
	}
	public void hideAll()
	{
		for(int i = 0; i < HeroItemDict.Count; i++)
		{
			Transform btn = (Transform)HeroItemDict.ElementAt(i).Value;
			if(null != btn)
			{
				btn.gameObject.SetActive(false);
			}
		}
	}
	public void delAll()
	{
		for(int i = 0; i < HeroItemDict.Count; i++)
		{
			Transform btn = (Transform)HeroItemDict.ElementAt(i).Value;
			if(null != btn)
			{
				Destroy(btn.gameObject);
			}
		}
		HeroItemDict.Clear();
	}
	public HeroItemProperty getItemByIdx(int idx)
	{
		if(idx < 0 || idx >= HeroItemDict.Count)
		{
			return null;
		}
		Transform btn = HeroItemDict.ElementAt (idx).Value;
		return btn.GetComponentInChildren<HeroItemProperty> ();
	}
	public void highLightShow()
	{
		if(curSlectedIdx == -1)
		{
			return;
		}
		cancelHiLightShow (); //取消上一个
		lastSlectedIdx = curSlectedIdx;
		blackBack.gameObject.SetActive (true);
		HeroItemProperty item = getItemByIdx (curSlectedIdx);

		if(item.transform.position.x > relativeCenterPos.transform.position.x)
		{
			item.center ();
		}
		UIWidget[] subs = item.GetComponentsInChildren<UIWidget>();

		for(int i = 0; i < subs.Length; i++)
		{
			subs[i].depth += 30;
		}
	}
	public void cancelHiLightShow()
	{
		if(lastSlectedIdx == -1)
		{
			return;
		}
		blackBack.gameObject.SetActive (false);
		HeroItemProperty item = getItemByIdx (lastSlectedIdx);
		if(item == null)
		{
			return;
		}
		UIWidget[] subs = item.GetComponentsInChildren<UIWidget>();
		
		for(int i = 0; i < subs.Length; i++)
		{
			subs[i].depth -= 30;
		}
	}
	//隐藏黑色背景
	public void hideBlackBack()
	{
		blackBack.gameObject.SetActive (false);
	}
	public long getCurSelectHeroGuid()
	{
		Transform UI_Item = HeroItemDict.ElementAt (curSlectedIdx).Value;
		if(null == UI_Item)
		{
			return -1;
		}
		HeroItemProperty item = UI_Item.GetComponentInChildren<HeroItemProperty> ();
		if(item == null)
		{
			return -1;
		}
		return item.heroGuid;
	}
	public HeroItemProperty getCurSelectItem()
	{
		Transform UI_Item = HeroItemDict.ElementAt (curSlectedIdx).Value;
		if(null == UI_Item)
		{
			return null;
		}
		HeroItemProperty item = UI_Item.GetComponentInChildren<HeroItemProperty> ();
		if(item == null)
		{
			return null;
		}
		return item;
	}
	public void updateMoney()
	{

	}

//	public const float standard_width = 1280;
//	public const float standard_height = 720;
//	public void resizeScrollView()
//	{
//		if(null == scrollView || null == scrollView.panel)
//		{
//			return;
//		}
//		Camera camera = (Camera)this.GetComponentInParent(typeof(Camera));
//		float size = camera.orthographicSize;
//		
//		float device_height = Screen.height;
//		float device_width = Screen.width;
//		
//		float standard_aspect = standard_width / standard_height;
//		float device_aspect = device_width / device_height;
//		
//		float resizeHeight = standard_height * size;
//		float resizeWidth = standard_height * device_aspect * size;
//		
////		UISprite bg = (UISprite)GetComponent(typeof(UISprite));
////		bg.width = (int)resizeWidth;
//
//		scrollViewBack.width = (int)resizeWidth + 10;
//		Vector4 vec = scrollView.panel.baseClipRegion;
//		int width = (int)resizeWidth;
//		int height = (int)((float)scrollViewBack.height * 0.85f);
//		scrollView.panel.baseClipRegion = new Vector4 (0, 0, width, height);
//	}

	public void OnDisable()
	{
		cancelHiLightShow ();
	}





}
