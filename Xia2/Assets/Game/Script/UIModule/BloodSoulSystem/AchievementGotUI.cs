using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AchievementGotUI : MonoBehaviour {

	public UIGrid m_grid;

	GameObject m_gridGameObj;

	// Use this for initialization
	void Start ()
	{
		m_gridGameObj = m_grid.gameObject;
	}

	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnEnable()
	{
		Refresh();
	}

	public void Refresh()
	{
		foreach (Transform t in m_grid.transform)
		{
			Destroy(t.gameObject);
		}

		BloodSoulManager mng = MonoInstancePool.getInstance<BloodSoulManager>();
		int type = mng.m_selAchievementType;
		List<int> list = mng.getFinishedAchievementList(type);
		if (list != null)
		{
			for (int i = 0; i < list.Count; i++)
			{
				int id = list[i];
				//UISprite _sprite = NGUITools.AddWidget<UISprite>(m_gridGameObj);
				GameObject prefab = Resources.Load("Prefab/BloodSoulSystem/AchievementIcon") as GameObject;
				GameObject icon = KMTools.AddGameObj(m_gridGameObj, prefab, true);
				UISprite _sprite = prefab.GetComponent<UISprite>();
				AchievementItem data = mng.getAchievementData(id);
				_sprite.spriteName = data.icon;
				_sprite.depth = 6;
			}
			m_grid.repositionNow = true;
		}
	}
}	
