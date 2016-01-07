using UnityEngine;
using System.Collections;

public class AchievementGotUIBtn : MonoBehaviour {

	public int m_achievementType;

	// Use this for initialization
	void Start ()
	{
	}

	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnClick()
	{
		BloodSoulManager mng = MonoInstancePool.getInstance<BloodSoulManager>();
		mng.m_selAchievementType = m_achievementType;

		AchievementGotUI window = (AchievementGotUI)FindObjectOfType(typeof(AchievementGotUI));
		if (window != null)
		{
			window.Refresh();
		}
	}
}	
