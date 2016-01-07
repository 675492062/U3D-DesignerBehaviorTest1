using UnityEngine;
using System.Collections;

public class BloodSoulAchievementItemBtn : MonoBehaviour {

	public string m_btnKey {get; set;}

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
		mng.m_selAchievementKey = m_btnKey;

		BloodSoulSystemUIManager window = (BloodSoulSystemUIManager)FindObjectOfType(typeof(BloodSoulSystemUIManager));
		window.showAchievementInfo();
	}
}
