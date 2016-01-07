using UnityEngine;  
using System.Collections;  

public class LoadingBar : MonoBehaviour {  

	public UILabel label;
	UISlider slider;
	//异步对象  
	private AsyncOperation mAsyn;  
	//绑定Tip的GUIText  
	private GUIText mTip;  
	//Tip集合，实际开发中需要从外部文件中读取  
	private string[] mTips=new string[]  
	{  
		"打竞技场可以获得更多金币",  
		"每天登录会有很多奖励哦",  
		"在主城可以看到好友哦",  
		"每天都有好心情",  
		"能看到这条说明快加载完了",  
	};  
	
	//更新Tip的时间  
	private  const float UpdateTime=0.0F;  
	//上一次更细的时间  
//	private  float lastTime=0.0F;  
	
	void Start ()   
	{  
		//memery clear
		Resources.UnloadUnusedAssets ();
		System.GC.Collect ();
//		mTip = GameObject.Find("GUITips").GetComponent<GUIText>();  
		slider = GetComponentInChildren<UISlider>();
		StartCoroutine("Load");  
	}  
	
	IEnumerator Load()  
	{  
		string name = MonoInstancePool.getInstance<UserData>().redirectSceneName;
		mAsyn=Application.LoadLevelAsync(name);  
//		Debug.Log ("progress:  " + mAsyn.progress);

		yield return mAsyn;  
	}  
	
	void Update ()   
	{  
//		//如果场景没有加载完则显示Tip  
//		if(mAsyn!= null && !mAsyn.isDone)  
//		{  
//			//如果达到了更新的时间  
//			if(Time.time-lastTime>=UpdateTime)  
//			{  
//				lastTime=Time.time;  
				label.text=mTips[Random.Range(0,5)]+"("+(float)mAsyn.progress * 100+"%"+")";  
				if(slider!=null)
				{
					slider.value = mAsyn.progress;
				}
//			}  
//		}else  
//		{  
//			Application.LoadLevel("Game_LcNewScene");  
//		}  
	}  
} 