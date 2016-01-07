using UnityEngine;
using System.Collections;

public class BloodSoulAchievementItem : MonoBehaviour {

	public UISprite m_icon;

	public UILabel m_title;

	public UILabel m_num;

	public UISlider m_progress;

	public UIButton m_btnInfo;
	
	public UILabel m_btnInfoTitle;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Refresh(string icon, string name, string key, int achievementValue, string achievementName, int curTotalExtra, int curMaxExtra) {
		m_icon.spriteName = icon;
		m_title.text = name;
		m_num.text = "+" + achievementValue;
		m_progress.value = (float)curTotalExtra/(float)curMaxExtra;
		m_btnInfoTitle.text = achievementName;

		BloodSoulAchievementItemBtn script = m_btnInfo.GetComponent<BloodSoulAchievementItemBtn>();
		script.m_btnKey = key;

	}
}
