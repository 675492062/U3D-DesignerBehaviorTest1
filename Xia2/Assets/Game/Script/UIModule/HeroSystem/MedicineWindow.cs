using UnityEngine;
using System.Collections;

public class MedicineWindow : MonoBehaviour {

	bool  startTime = false;
	float tempStartTime = 0.0f;
	float tempRepeatTime = 0.0f;
	int   repeatCount = 0;
	float use_interval = 0.1f;
	float onceClickTime = 1f;

	public UISprite selectBorder;
	int curClickIdx;//当前吃的是哪个药水

	public UIMedicineItem[] medicine = new UIMedicineItem[5];
	// Use this for initialization
	void Start () 
	{
		init ();
	}

	// Update is called once per frame
	void Update () 
	{
		if(startTime == false)
		{
			return;
		}
		tempStartTime += Time.deltaTime;
		if(tempStartTime >= onceClickTime)
		{
			tempRepeatTime += Time.deltaTime;
			if(tempRepeatTime >= use_interval)
			{
				if(medicine[curClickIdx].count <= 0)
				{
					sendUseMsg(curClickIdx);
					medicine[curClickIdx].refreshData();
					Debug.LogError("eat finish!");
					return;
				}
				
				tempRepeatTime = 0f;
				repeatCount++;
				int exp =  medicine[curClickIdx].getAddNum();
				
				HeroSysModules manager = (HeroSysModules)FindObjectOfType(typeof(HeroSysModules));
				if(manager == null)
				{
					return;
				}

				manager.headInfo.tempAddExp(exp);
				medicine[curClickIdx].subItemNum();
				Debug.Log("repeat!");
			}
		}
	}
	void OnEnable()
	{
		for(int i = 0; i < medicine.Length; i++)
		{
			medicine[i].refreshData();
		}
	}
	public void init ()
	{
		startTime = false;
		tempStartTime = 0.0f;
		tempRepeatTime = 0.0f;
		repeatCount = 0;
	}
	//按下 
	public void useExp1()
	{
		startTime = true;
		curClickIdx = 0;
		selectBorder.transform.localPosition = medicine [curClickIdx].transform.localPosition;
	}
	public void useExp2()
	{
		startTime = true;
		curClickIdx = 1;
		selectBorder.transform.localPosition = medicine [curClickIdx].transform.localPosition;
	}
	public void useExp3()
	{
		startTime = true;
		curClickIdx = 2;
		selectBorder.transform.localPosition = medicine [curClickIdx].transform.localPosition;
	}
	public void useExp4()
	{
		startTime = true;
		curClickIdx = 3;
		selectBorder.transform.localPosition = medicine [curClickIdx].transform.localPosition;
	}
	public void useExp5()
	{
		startTime = true;
		curClickIdx = 4;
		selectBorder.transform.localPosition = medicine [curClickIdx].transform.localPosition;
	}
	//抬起
	public void releaseExp1()
	{
		sendUseMsg (0);
	}
	public void releaseExp2()
	{
		sendUseMsg (1);
	}
	public void releaseExp3()
	{
		sendUseMsg (2);
	}
	public void releaseExp4()
	{
		sendUseMsg (3);
	}
	public void releaseExp5()
	{
		sendUseMsg (4);
	}
	public void sendUseMsg(int idx)
	{
		startTime = false;//stop timer
		HeroData data = MonoInstancePool.getInstance<HeroManager> ().getCurShowHero ();
		if(data == null)
		{
			return;
		}
		HeroSysModules manager = (HeroSysModules)FindObjectOfType(typeof(HeroSysModules));
		if(manager == null)
		{
			return;
		}
		if(data != null)
		{
			BaseItem item = MonoInstancePool.getInstance<BagManager>().getPotionBag().getItemByTempID(medicine[idx].templateID);
			if(item == null)
			{
				return;
			}
			if(onceClickTime > tempStartTime)
			{
				repeatCount = 1;

				manager.headInfo.tempAddExp(medicine[idx].getAddNum());
				medicine[idx].subItemNum();
			}
			MonoInstancePool.getInstance<SendItemSystemMsgHander>().sendUseItemReq(item.guid, repeatCount, data.guid);
		}
		//reset
		init();
	}
}
