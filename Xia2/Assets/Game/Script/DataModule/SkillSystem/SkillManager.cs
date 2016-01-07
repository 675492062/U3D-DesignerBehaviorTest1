using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SkillManager 
{

	public List<SkillItem>	skills = new List<SkillItem>();
	public int	[]useSkills = new int[(int)GlobalDef.MAX_USE_SKILL];

	// Use this for initialization
	public SkillManager()
	{	
		//init
		for(int i = 0; i < (int)GlobalDef.MAX_USE_SKILL; i++)
		{
			useSkills[i] = -1;
		}
	}

	// Update is called once per frame
	public void Update() 
	{
		//计算 CD
		for(int i = 0; i < skills.Count; i++)
		{
			if(skills[i].curCD > 0)
			{
				skills[i].curCD -= Time.deltaTime;
				if(skills[i].curCD < 0)
					skills[i].curCD = 0;
			}
		}
	}

	public void clearUseSkill()
	{
		for(int i = 0; i  < useSkills.Length; i++)
		{
			useSkills[i] = -1;
		}
	}

	public void Clear()
	{
		skills.Clear ();
	}

	public void Add(SkillItem skill)
	{
		skills.Add (skill);
	}

	public SkillItem getSkillByIdx(int idx)
	{
		if (idx < 0 || idx >= skills.Count) 
		{
			return null;		
		}
		return skills.ElementAt (idx);
	}

	public SkillItem getUseSkillByIdx(int idx)
	{
		if(idx < 0 || idx >= (int)GlobalDef.MAX_USE_SKILL)
		{
			return null;
		}
		if(useSkills[idx] == -1)
		{
			return null;
		}
		int pos = useSkills [idx];
		return getSkillByIdx (pos);
	}

	public SkillItem getUseSkillByTemplateID(int templateID)
	{
		for (int i = 0; i < useSkills.Length; i++) {
			if( useSkills[i] == -1 )
				continue;
			int pos = useSkills [i];
			SkillItem skill = getSkillByIdx (pos);
			if( skill == null )
				continue;
			if(skill.templateID == templateID)
				return skill;
		}
		return null;
	}

	public int count()
	{
		return skills.Count;
	}

	public SkillItem getCanUseSkill()
	{
		int idx = -1;
		int priorityCount = int.MaxValue;
		for(int i = 0; i < skills.Count; i++)
		{
			if(skills[i].canUse())
			{
				if(skills[i].priorityCount < priorityCount)
				{
					idx = i;
					priorityCount = skills[i].priorityCount;
				}
			}
		}
		return (idx == -1) ? null : skills [idx];
	}
}
