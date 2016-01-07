using UnityEngine;
using System.Collections;

public class BloodSoulSystemUIManager : MonoBehaviour {

	public UISlider m_bloodSoulLevelBar;

	public UILabel m_bloodSoulFighting;

	public UILabel m_bloodSoulLevel;

	public UILabel m_bloodSoulProgress;

	public Transform [] m_markBoxTransform;

	private ArrayList m_markBoxs = new ArrayList();

	public UIScrollView m_achievementList;
	public UIGrid m_achievementListGrid;

	public BloodSoulAchievementItem m_prbAchievementItem;

	public Transform m_achievementGot;
	public void showAchievementGot()
	{
		if (m_achievementGot != null)
		{
			m_achievementGot.gameObject.SetActive(true);
		}
	}
	public Transform m_achievementInfo;
	public void showAchievementInfo()
	{
		if (m_achievementInfo != null)
		{
			m_achievementInfo.gameObject.SetActive(true);
		}
	}

	// Use this for initialization
	void Start () {
		InitMarkBoxs();
	}

	// Update is called once per frame
	void Update () {
	
	}
	
	void OnEnable() {
		//SendMessageToServer();
		Refresh();
	}
	
	void SendMessageToServer()
	{
	}
	
	void Refresh() {
		BloodSoulManager mng = MonoInstancePool.getInstance<BloodSoulManager>();
		bool bDirty = mng.IsUpdateDirty;
		//if (bDirty)
		{
			mng.IsUpdateDirty = false;
			// 战斗力
			int fighting = mng.getCurBloodSoulFighting();
			m_bloodSoulFighting.text = fighting.ToString();
			// 血魂等级
			int curLvl = mng.getCurBloodSoulLvl();
			m_bloodSoulLevel.text = "Lv." + curLvl.ToString() + " 血魂";
			// 血魂进度
			int curProgress = mng.getCurBloodSoulExpProgress();
			int maxProgress = mng.getCurBloodSoulExpMax();
			m_bloodSoulLevelBar.value = (float)curProgress/(float)maxProgress;
			m_bloodSoulProgress.text = curProgress + "/" + maxProgress;
			// 血魂印记
			RefreshMarkBoxs();
			// 血魂成就
			RefreshAchievementList();
		}
	}

	void InitMarkBoxs() {
		for(int i = 0; i < m_markBoxTransform.Length; i++)
		{
			if(m_markBoxTransform[i] == null)
			{
				continue;
			}
			BloodSoulMarkBoxUI script = m_markBoxTransform[i].GetComponent<BloodSoulMarkBoxUI>();
			m_markBoxs.Add(script);
			script.m_icon.gameObject.SetActive(false);
		}
	}

	void RefreshMarkBoxs() {
	}

	void RefreshAchievementList() {

		foreach (Transform t in m_achievementListGrid.transform)
		{
			Destroy(t.gameObject);
		}

		BloodSoulManager mng = MonoInstancePool.getInstance<BloodSoulManager>();
		bool bActive = false;
		int achievementValue = 0;
		string achievementName = "";
		int curTotalExtra = 0;
		int curMaxExtra = 0;
		GameObject gridGameObj = m_achievementListGrid.gameObject;
		// hp
		bActive = mng.getHpAchievementData(out achievementValue, out achievementName, out curTotalExtra, out curMaxExtra);
		if (bActive) {
			BloodSoulAchievementItem item = KMTools.AddChild<BloodSoulAchievementItem>(gridGameObj, m_prbAchievementItem);
			item.gameObject.name = "hp";
			item.Refresh("xuehun_04", "生命", "hp", achievementValue, achievementName, curTotalExtra, curMaxExtra);
		}
		// attack
		bActive = mng.getAttackAchievementData(out achievementValue, out achievementName, out curTotalExtra, out curMaxExtra);
		if (bActive) {
			BloodSoulAchievementItem item = KMTools.AddChild<BloodSoulAchievementItem>(gridGameObj, m_prbAchievementItem);
			item.gameObject.name = "attack";
			item.Refresh("xuehun_05", "攻击", "attack", achievementValue, achievementName, curTotalExtra, curMaxExtra);
		}
		// armor
		bActive = mng.getArmorAchievementData(out achievementValue, out achievementName, out curTotalExtra, out curMaxExtra);
		if (bActive) {
			BloodSoulAchievementItem item = KMTools.AddChild<BloodSoulAchievementItem>(gridGameObj, m_prbAchievementItem);
			item.gameObject.name = "armor";
			item.Refresh("xuehun_06", "防御", "armor", achievementValue, achievementName, curTotalExtra, curMaxExtra);
		}
		// criticallv
		bActive = mng.getCriticalLvlAchievementData(out achievementValue, out achievementName, out curTotalExtra, out curMaxExtra);
		if (bActive) {
			BloodSoulAchievementItem item = KMTools.AddChild<BloodSoulAchievementItem>(gridGameObj, m_prbAchievementItem);
			item.gameObject.name = "criticallv";
			item.Refresh("xuehun_04", "爆击", "criticallv", achievementValue, achievementName, curTotalExtra, curMaxExtra);
		}
		// hitlv
		bActive = mng.getHitLvlAchievementData(out achievementValue, out achievementName, out curTotalExtra, out curMaxExtra);
		if (bActive) {
			BloodSoulAchievementItem item = KMTools.AddChild<BloodSoulAchievementItem>(gridGameObj, m_prbAchievementItem);
			item.gameObject.name = "hitlv";
			item.Refresh("xuehun_08", "命中", "hitlv", achievementValue, achievementName, curTotalExtra, curMaxExtra);
		}
		// dodgelv
		bActive = mng.getDodgeLvlAchievementData(out achievementValue, out achievementName, out curTotalExtra, out curMaxExtra);
		if (bActive) {
			BloodSoulAchievementItem item = KMTools.AddChild<BloodSoulAchievementItem>(gridGameObj, m_prbAchievementItem);
			item.gameObject.name = "dodgelv";
			item.Refresh("xuehun_07", "闪避", "dodgelv", achievementValue, achievementName, curTotalExtra, curMaxExtra);
		}
		// tenacitylv
		bActive = mng.getTenacityLvlAchievementData(out achievementValue, out achievementName, out curTotalExtra, out curMaxExtra);
		if (bActive) {
			BloodSoulAchievementItem item = KMTools.AddChild<BloodSoulAchievementItem>(gridGameObj, m_prbAchievementItem);
			item.gameObject.name = "tenacitylv";
			item.Refresh("xuehun_04", "韧性", "tenacitylv", achievementValue, achievementName, curTotalExtra, curMaxExtra);
		}

		m_achievementListGrid.repositionNow = true;

		m_achievementList.ResetPosition();
	}
}	
