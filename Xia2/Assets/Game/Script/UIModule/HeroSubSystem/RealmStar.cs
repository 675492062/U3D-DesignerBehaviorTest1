using UnityEngine;
using System.Collections;

public class RealmStar : MonoBehaviour {
	public UISprite skillIcon;
	public UISprite skillLight;
	public UISprite nomalBack;
	public UISprite lightBack;
	public RealmBarEffect barEffect;

	public int idx;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	public void OnClick()
	{
		RealmSysManager manager = (RealmSysManager)FindObjectOfType(typeof(RealmSysManager));
		if(manager != null)
		{
			manager.curSelectStar = idx;
			MonoInstancePool.getInstance<SendHeroSysMsgHander>().SendUpgradeRealm(idx);
//			manager.runBarAction();
		}

//		Debug.Log ("click + 1111111");

	}
	public void showEmpty()
	{
		if (nomalBack != null) nomalBack.gameObject.SetActive (true);
		if (lightBack != null) lightBack.gameObject.SetActive (false);

		if(skillIcon != null) skillIcon.gameObject.SetActive(false);
		if(skillLight != null) skillLight.gameObject.SetActive(false);
	}
	public void showLight()
	{
		if (nomalBack != null) nomalBack.gameObject.SetActive (false);
		if (lightBack != null) lightBack.gameObject.SetActive (true);
		
		if (skillIcon != null) 
		{	
			skillIcon.gameObject.SetActive (true); 
			if(skillLight != null) skillLight.gameObject.SetActive(false);
		}
		else {
			if(skillLight != null) skillLight.gameObject.SetActive(true);
		}
	}
}