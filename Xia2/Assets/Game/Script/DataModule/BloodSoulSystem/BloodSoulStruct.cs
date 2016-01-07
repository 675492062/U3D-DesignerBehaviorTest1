using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class BloodSoulStruct {

	Dictionary<int, BloodsoulItem> m_bloodSoulData = new Dictionary<int, BloodsoulItem>();

	public BloodsoulItem getBloodsoulItem(int nLvl) {
		BloodsoulItem item = null;
		if (m_bloodSoulData.ContainsKey(nLvl)) {
			item = m_bloodSoulData[nLvl];
		} else {
			item = new BloodsoulItem();
			item.parseData(nLvl);
			m_bloodSoulData[nLvl] = item;
		}

		return item;
	}

	Dictionary<int, AchievementItem> m_achievementData = new Dictionary<int, AchievementItem>();

	public AchievementItem getAchievementItem(int _id) {
		AchievementItem item = null;
		if (m_achievementData.ContainsKey(_id)) {
			item = m_achievementData[_id];
		} else {
			item = new AchievementItem();
			item.parseData(_id);
			m_achievementData[_id] = item;
		}
		return item;
	}
}
