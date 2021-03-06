using UnityEngine;
using System.Collections;

public class HeroSkillUIManager : MonoBehaviour {

	public HeroUISkillList      normalSkillList;//技能列表
	public HeroUIMergeSkillList mergeSkillList; //缘分技能列表
	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	void OnEnable()
	{
		refresh ();
	}
	public void refresh()
	{
		HeroData data = MonoInstancePool.getInstance<HeroManager> ().getCurShowHero();
		if(data == null)
		{
			return;
		}
		normalSkillList.refresh (data);
	}
}
