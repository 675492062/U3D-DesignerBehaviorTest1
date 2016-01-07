using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BloodSoulManager : MonoBehaviour {

	/// 是否需要更新
	public bool IsUpdateDirty {get;set;}
	public bool IsFinishDirty {get;set;}

	/// record select achievement key
	public string m_selAchievementKey {get; set;}
	/// record select got achievement index
	public int m_selAchievementType {get; set;}

	/// 血魂等级
	private int m_iBloodSoulLevel = 1;
	/// 血魂进度
	private int m_iBloodSoulProgress = 0;
	/// 血魂数据类
	private BloodSoulStruct m_bloodSoulData = new BloodSoulStruct();
	/// 生命
	public int extraHp{get;set;}
	/// 攻击力
	public int extraAttack{get;set;}
	/// 防御
	public int extraArmor{get;set;}
	/// 爆击等级
	public int extraCriticalLvl{get;set;}
	/// 命中等级
	public int extraHitLvl{get;set;}
	/// 闪避等级
	public int extraDodgeLvl{get;set;}
	/// 韧性等级
	public int extraTenacityLvl{get;set;}
	
	//private ArrayList m_curAchievements = new ArrayList();
	private Dictionary<int, int> m_curAchievements = new Dictionary<int, int>();
	
	//private ArrayList m_finishedAchievements = new ArrayList();
	private Dictionary<int, bool> m_finishedAchievements = new Dictionary<int, bool>();
	private Dictionary<int, List<int>> m_finishedAchievementList = new Dictionary<int, List<int>>();
	public List<int> getFinishedAchievementList(int type)
	{
		if (m_finishedAchievementList.ContainsKey(type))
		{
			return m_finishedAchievementList[type];
		}
		else
		{
			return null;
		}
	}


	/// <summary>
	/// The m_cur blood soul achievements.
	/// </summary>
	private Dictionary<string, AchievementItem> m_curBloodSoulAchievements = new Dictionary<string, AchievementItem>();

	public BloodSoulManager() {
		IsUpdateDirty = true;
		IsFinishDirty = true;
		m_selAchievementType = (int)GlobalDef.AchievementType.ACHIEVE_GROW;
		updateAchievement(825003, 0);
	}

	#region record server data
	/////////////////////////////////////
	/// 用于从服务器收到消息数据的解析和存储
	public void clearCurAchievementList() {
		m_curAchievements.Clear();
		m_curBloodSoulAchievements.Clear();
	}

	public void clearFinishedAchievement() {
		m_finishedAchievements.Clear();
		m_finishedAchievementList.Clear();
	}

	/// 完成一个成就
	public void finishAchievement(int id) {
		m_finishedAchievements[id] = true;
		if (m_curAchievements.ContainsKey(id)) {
			m_curAchievements.Remove(id);
		}
		// list
		AchievementItem item = getAchievementData(id);
		if (!m_finishedAchievementList.ContainsKey(item.myType)) {
			List<int> list = new List<int>();
			m_finishedAchievementList[item.myType] = list;
		}
		if (!m_finishedAchievementList[item.myType].Contains(id)) {
			m_finishedAchievementList[item.myType].Add(id);
			m_finishedAchievementList[item.myType].Sort();
		}

		IsFinishDirty = true;
	}

	/// 更新成就进度
	public void updateAchievement(int id, int progress) {
		m_curAchievements[id] = progress;

		AchievementItem item = getAchievementData(id);
		item.progress = progress;
		m_curBloodSoulAchievements[item.effect_key] = item;

		IsUpdateDirty = true;
	}

	public void recordBloodSoulInfo(int nLvl, int nProgress) {
		m_iBloodSoulLevel = nLvl;
		m_iBloodSoulProgress = nProgress;

		IsUpdateDirty = true;
	}
	/////////////////////////////////////
	#endregion record server data

	#region get data for ui left
	/////////////////////////////////////
	///  用于血魂主界面左侧数据填充
	/// 战斗力计算公式
	/// 血魂战斗力 = 血魂等级 * m + 血魂生命总值 * n + 血魂攻击力总值 * p + 血魂防御总值* q
	/// + 血魂暴击等级 * r + 血魂命中等级 * s + 血魂闪避等级 * t + 血魂韧性等级 * d 
	/// + 血魂印记1战斗力 +血魂印记2战斗力 + …  +血魂印记5战斗力
	public int getCurBloodSoulFighting() {
		int iFighting = 0;
		float fFighting = 0.0f;
		fFighting += m_iBloodSoulLevel * StaticGlobal_parameter.Instance().getInt(850097 , "parameter");
		fFighting += getTotalExtraHp() * StaticGlobal_parameter.Instance().getInt(850090 , "parameter");
		fFighting += getTotalExtraAttack() * StaticGlobal_parameter.Instance().getInt(850091 , "parameter");
		fFighting += getTotalExtraArmor() * StaticGlobal_parameter.Instance().getFloat(850092 , "parameter");
		fFighting += getTotalExtraCriticalLvl() * StaticGlobal_parameter.Instance().getInt(850093 , "parameter");
		fFighting += getTotalExtraHitLvl() * StaticGlobal_parameter.Instance().getInt(850094 , "parameter");
		fFighting += getTotalExtraDodgeLvl() * StaticGlobal_parameter.Instance().getInt(850095 , "parameter");
		fFighting += getTotalExtraTenacityLvl() * StaticGlobal_parameter.Instance().getInt(850096 , "parameter");
		fFighting += 0;
		fFighting += 0;
		fFighting += 0;
		fFighting += 0;
		fFighting += 0;
		iFighting = (int)fFighting;
		return iFighting;
	}

	public int getCurBloodSoulLvl() {
		return m_iBloodSoulLevel;
	}
	
	public int getCurBloodSoulExpProgress() {
		return m_iBloodSoulProgress;
	}

	public int getCurBloodSoulExpMax() {
		int nExpMax = getCurBloodSoulData().exp;
		return nExpMax;
	}

	public int getCurBloodSoulMarkBoxCount() {
		int count = getCurBloodSoulData().markbox;
		return count;
	}
	/////////////////////////////////////
	#endregion get data for ui left

	#region get data for ui right list
	/////////////////////////////////////
	/// 用于血魂主界面右侧列表的数据填充
	public AchievementItem getAchievementData(int _id) {
		return m_bloodSoulData.getAchievementItem(_id);
	}

	public AchievementItem getCurBloodSoulAchievement(string key) {
		if (m_curBloodSoulAchievements.ContainsKey(key)) {
			return m_curBloodSoulAchievements[key];
		}else{
			return null;
		}
		//foreach (KeyValuePair<int, int> kvp in m_curAchievements) {
		//	AchievementItem item = getAchievementData(kvp.Key);
		//	if (item.effect_key == key) {
		//		achievement = item;
		//		break;
		//	}
		//}
	}

	public bool getHpAchievementData(out int achievementValue, out string achievementName, out int curTotalExtra, out int curMaxExtra) {
		achievementValue = 0;
		achievementName = "";
		curTotalExtra = 0;
		curMaxExtra = 0;

		BloodsoulItem bloodSoul = getCurBloodSoulData();
		int bloodSoulHp = bloodSoul.hp;
		bool bHas = (bloodSoulHp != 0);
		if (bHas) {
			AchievementItem item = getCurBloodSoulAchievement("hp");
			if (item == null) {
				bHas = false;
			} else {
				achievementValue = item.effect_value;
				achievementName = item.name;
				curTotalExtra = getTotalExtraHp();
				curMaxExtra = bloodSoul.hpmax;
			}
		}
		return bHas;
	}
	
	public bool getAttackAchievementData(out int achievementValue, out string achievementName, out int curTotalExtra, out int curMaxExtra) {
		achievementValue = 0;
		achievementName = "";
		curTotalExtra = 0;
		curMaxExtra = 0;

		BloodsoulItem bloodSoul = getCurBloodSoulData();
		int bloodSoulAttack = bloodSoul.attack;
		bool bHas = (bloodSoulAttack != 0);
		if (bHas) {
			AchievementItem item = getCurBloodSoulAchievement("attack");
			if (item == null) {
				bHas = false;
			} else {
				achievementValue = item.effect_value;
				achievementName = item.name;
				curTotalExtra = getTotalExtraAttack();
				curMaxExtra = bloodSoul.attackmax;
			}
		}
		return bHas;
	}
	
	public bool getArmorAchievementData(out int achievementValue, out string achievementName, out int curTotalExtra, out int curMaxExtra) {
		achievementValue = 0;
		achievementName = "";
		curTotalExtra = 0;
		curMaxExtra = 0;

		BloodsoulItem bloodSoul = getCurBloodSoulData();
		int bloodSoulArmor = bloodSoul.armor;
		bool bHas = (bloodSoulArmor != 0);
		if (bHas) {
			AchievementItem item = getCurBloodSoulAchievement("armor");
			if (item == null) {
				bHas = false;
			} else {
				achievementValue = item.effect_value;
				achievementName = item.name;
				curTotalExtra = getTotalExtraArmor();
				curMaxExtra = bloodSoul.armormax;
			}
		}
		return bHas;
	}
	
	public bool getCriticalLvlAchievementData(out int achievementValue, out string achievementName, out int curTotalExtra, out int curMaxExtra) {
		achievementValue = 0;
		achievementName = "";
		curTotalExtra = 0;
		curMaxExtra = 0;

		BloodsoulItem bloodSoul = getCurBloodSoulData();
		int bloodSoulCriticalLvl = bloodSoul.criticallv;
		bool bHas = (bloodSoulCriticalLvl != 0);
		if (bHas) {
			AchievementItem item = getCurBloodSoulAchievement("criticallv");
			if (item == null) {
				bHas = false;
			} else {
				achievementValue = item.effect_value;
				achievementName = item.name;
				curTotalExtra = getTotalExtraCriticalLvl();
				curMaxExtra = bloodSoul.criticallvmax;
			}
		}
		return bHas;
	}
	
	public bool getHitLvlAchievementData(out int achievementValue, out string achievementName, out int curTotalExtra, out int curMaxExtra) {
		achievementValue = 0;
		achievementName = "";
		curTotalExtra = 0;
		curMaxExtra = 0;

		BloodsoulItem bloodSoul = getCurBloodSoulData();
		int bloodSoulHitLvl = bloodSoul.hitlv;
		bool bHas = (bloodSoulHitLvl != 0);
		if (bHas) {
			AchievementItem item = getCurBloodSoulAchievement("hitlv");
			if (item == null) {
				bHas = false;
			} else {
				achievementValue = item.effect_value;
				achievementName = item.name;
				curTotalExtra = getTotalExtraHitLvl();
				curMaxExtra = bloodSoul.hitlvmax;
			}
		}
		return bHas;
	}
	
	public bool getDodgeLvlAchievementData(out int achievementValue, out string achievementName, out int curTotalExtra, out int curMaxExtra) {
		achievementValue = 0;
		achievementName = "";
		curTotalExtra = 0;
		curMaxExtra = 0;

		BloodsoulItem bloodSoul = getCurBloodSoulData();
		int bloodSoulDodgeLvl = bloodSoul.dodgelv;
		bool bHas = (bloodSoulDodgeLvl != 0);
		if (bHas) {
			AchievementItem item = getCurBloodSoulAchievement("dodgelv");
			if (item == null) {
				bHas = false;
			} else {
				achievementValue = item.effect_value;
				achievementName = item.name;
				curTotalExtra = getTotalExtraDodgeLvl();
				curMaxExtra = bloodSoul.dodgelvmax;
			}
		}
		return bHas;
	}
	
	public bool getTenacityLvlAchievementData(out int achievementValue, out string achievementName, out int curTotalExtra, out int curMaxExtra) {
		achievementValue = 0;
		achievementName = "";
		curTotalExtra = 0;
		curMaxExtra = 0;

		BloodsoulItem bloodSoul = getCurBloodSoulData();
		int bloodSoulTenacityLvl = bloodSoul.tenacitylv;
		bool bHas = (bloodSoulTenacityLvl != 0);
		if (bHas) {
			AchievementItem item = getCurBloodSoulAchievement("tenacitylv");
			if (item == null) {
				bHas = false;
			} else {
				achievementValue = item.effect_value;
				achievementName = item.name;
				curTotalExtra = getTotalExtraTenacityLvl();
				curMaxExtra = bloodSoul.tenacitylvmax;
			}
		}
		return bHas;
	}

	public string getStrByKey(string key)
	{
		if (key == "hp")
		{
			return "生命";
		}
		else if (key == "attack")
		{
			return "攻击";
		}
		else if (key == "armor")
		{
			return "防御";
		}
		else if (key == "criticallv")
		{
			return "爆击";
		}
		else if (key == "hitlv")
		{
			return "命中";
		}
		else if (key == "dodgelv")
		{
			return "闪避";
		}
		else if (key == "tenacitylv")
		{
			return "韧性";
		}
		return "";
	}

	/////////////////////////////////////
	#endregion get data for ui right list

	#region for in game data interface
	/////////////////////////////////////
	/// 给游戏中人物属性计算提供的接口
	private BloodsoulItem getCurBloodSoulData() {
		return m_bloodSoulData.getBloodsoulItem(m_iBloodSoulLevel);
	}
	public int getTotalExtraHp() {
		int bloodSoulHp = getCurBloodSoulData().hp;
		int total = bloodSoulHp + this.extraHp;
		return total;
	}

	public int getTotalExtraAttack() {
		int bloodSoulAttack = getCurBloodSoulData().attack;
		int total = bloodSoulAttack + this.extraAttack;
		return total;
	}

	public int getTotalExtraArmor() {
		int bloodSoulArmor = getCurBloodSoulData().armor;
		int total = bloodSoulArmor + this.extraArmor;
		return total;
	}

	public int getTotalExtraCriticalLvl() {
		int bloodSoulCriticalLvl = getCurBloodSoulData().criticallv;
		int total = bloodSoulCriticalLvl + this.extraCriticalLvl;
		return total;
	}

	public int getTotalExtraHitLvl() {
		int bloodSoulHitLvl = getCurBloodSoulData().hitlv;
		int total = bloodSoulHitLvl + this.extraHitLvl;
		return total;
	}
	
	public int getTotalExtraDodgeLvl() {
		int bloodSoulDodgeLvl = getCurBloodSoulData().dodgelv;
		int total = bloodSoulDodgeLvl + this.extraDodgeLvl;
		return total;
	}
	
	public int getTotalExtraTenacityLvl() {
		int bloodSoulTenacityLvl = getCurBloodSoulData().tenacitylv;
		int total = bloodSoulTenacityLvl + this.extraTenacityLvl;
		return total;
	}
	/////////////////////////////////////
	#endregion for in game data interface

}
