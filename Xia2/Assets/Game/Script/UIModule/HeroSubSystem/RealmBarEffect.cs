using UnityEngine;
using System.Collections;

public class RealmBarEffect : MonoBehaviour {

	UITexture tex;

	public UISprite Foreground;

	bool  startRun = false;
	float updateInterval = 0.01f;
	float tempTime = 0f;
	float speed = 0.01f;
	public UIProgressBar bar;
	Vector3 scale;
	// Use this for initialization
	void Start () 
	{
		BagUIManager manager = (BagUIManager)FindObjectOfType (typeof(BagUIManager));
//		UITexture tttttt = KMTools.AddChild<UITexture> (gameObject, manager.BarEffectTex);
		                                          
		Transform t =  (Transform)Instantiate(manager.BarEffectTex.transform, Vector3.zero, Quaternion.identity);
		t.transform.parent = transform;
		t.transform.localPosition = Vector3.zero;
		t.transform.localRotation = Quaternion.identity;
		t.transform.localScale = Vector3.one;

		tex = t.GetComponentInChildren<UITexture> ();
		tex.pivot = UIWidget.Pivot.Left;
		tex.depth = 3;
		tex.width = Foreground.width;

		scale = tex.transform.localScale;
		scale.x = bar.value;
		tex.transform.localScale = scale;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(startRun == false || bar.value >= 1)
		{
			return;
		}
		tempTime += Time.deltaTime;
		if(tempTime >= updateInterval)
		{
			tempTime = 0f;
			bar.value += speed;
//			tex.width = (int)(Foreground.width*bar.value);
			scale = tex.transform.localScale;
			scale.x = (bar.value);
			tex.transform.localScale = scale;
			if(bar.value >= 1)
			{
				startRun =false;
				//跑到头就点亮
				RealmSysManager manager = (RealmSysManager)FindObjectOfType(typeof(RealmSysManager));
				if(manager != null)
				{
					manager.lightCurStarItem();
				}
			}
		}
	}
	public void startRunAni()
	{
		startRun = true;
	}
	public void setBarValue(float value)
	{
		if(null == bar || null == tex)
		{
			return;
		}
		bar.value = value;
		scale = tex.transform.localScale;
		scale.x = (bar.value);
		tex.transform.localScale = scale;
	}
}
