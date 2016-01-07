using UnityEngine;
using System.Collections;

public class AchievementInfoUI : MonoBehaviour
{

	public UISprite m_icon;

	public UILabel m_effect;

	public UILabel m_desc;

	public UILabel m_progress;

	// Use this for initialization
	void Start ()
	{
	}

	void OnEnable()
	{
		Refresh();
	}

	// Update is called once per frame
	void Update ()
	{
	
	}

	void Refresh()
	{
		BloodSoulManager mng = MonoInstancePool.getInstance<BloodSoulManager>();
		string key = mng.m_selAchievementKey;
		AchievementItem itemData = mng.getCurBloodSoulAchievement(key);
		m_icon.spriteName = itemData.icon;
		m_effect.text = mng.getStrByKey(key) + "+" + itemData.effect_value;
		m_desc.text = itemData.desc;
		m_progress.text = itemData.progress + "/" + itemData.target_value;
	}
}	
