using UnityEngine;
using System.Collections;

public class SkillItemDescribe{

	public string des = "";
	int resParam1 = 0;
	int resParam2 = 0;
	int resParam3 = 0;
	int templateID = 0;

	public SkillItemDescribe()
	{

	}


	public void refresh(HeroData data, SkillItem skill)
	{
		des = info;
		resParam1 = processDes (formula0,data, skill);
		resParam2 = processDes (formula1,data, skill);
		resParam3 = processDes (formula2,data, skill);
		des = string.Format(info, resParam1, resParam2, resParam3);
	}

	public string parseData(int id, HeroData data, SkillItem skill)
	{
		templateID = id;

		info   = StaticSkill_info.Instance().getStr(templateID,"info");
		param1 = StaticSkill_info.Instance().getFloat(templateID, "param1");
		param2 = StaticSkill_info.Instance().getFloat(templateID, "param2");
		param3 = StaticSkill_info.Instance().getFloat(templateID, "param3");
		param4 = StaticSkill_info.Instance().getFloat(templateID, "param4");
		param5 = StaticSkill_info.Instance().getFloat(templateID, "param5");
		param6 = StaticSkill_info.Instance().getFloat(templateID, "param6");
		varaible1 = StaticSkill_info.Instance().getFloat(templateID, "varaible1");
		varaible2 = StaticSkill_info.Instance().getFloat(templateID, "varaible2");
		varaible3 = StaticSkill_info.Instance().getFloat(templateID, "varaible3");
		formula0  = StaticSkill_info.Instance().getInt(templateID,  "formula0");
		formula1  = StaticSkill_info.Instance().getInt(templateID,  "formula1");
		formula2  = StaticSkill_info.Instance().getInt(templateID,  "formula2");

		des = info;
		resParam1 = processDes (formula0,data, skill);
		resParam2 = processDes (formula1,data, skill);
		resParam3 = processDes (formula2,data, skill);
		des = string.Format(info, resParam1, resParam2, resParam3);

		return "";
	}

//作者:
//		1:参数1/100*英雄当前伤害+参数2+变量1*lv
//		2:参数3/100*英雄当前伤害+参数4+变量2*lv
//		3：参数5/100*英雄当前伤害+参数6+变量3*lv
//		4:（参数1+变量1*lv）/100*英雄当前伤害+参数2
//		5:（参数3+变量2*lv）/100*英雄当前伤害+参数4
//		6:（参数5+变量3*lv）/100*英雄当前伤害+参数6
//		7:参数1/100+参数2+变量1*lv
//		8:参数3/100+参数4+变量2*lv
//		9：参数5/100+参数6+变量3*lv
//		10:（参数1+变量1*lv）/100+参数2
//		11:（参数3+变量2*lv）/100+参数4
//		12:（参数5+变量3*lv）/100+参数6
//		13：参数1+（变量1*lv）
//		14:参数3+（变量2*lv）
//		15：参数5+（变量3*lv）

	public int processDes(int desID, HeroData data, SkillItem skill)
	{
		float res = 0;
		int min = (int)data.getMinAttack();
		int max = (int)data.getMaxAttack();
		int atk = (max + min)/2;
		switch(desID)
		{
		case 1:
			res = param1/100*atk + param2 + varaible1*skill.level;
			break;
		case 2:
			res = param3/100*atk + param4 + varaible2*skill.level;
			break;
		case 3:
			res = param5/100*atk + param6 + varaible3*skill.level;
			break;
		case 4:
			res = (param1 + varaible1*skill.level) / 100 * atk + param2;
			break;
		case 5:
			res = (param3 + varaible2*skill.level) / 100 * atk + param4;
			break;
		case 6:
			res = (param5 + varaible3*skill.level) / 100 * atk + param6;
			break;
		case 7:
			res = param1 / 100 + param2 + varaible1*skill.level;
			break;
		case 8:
			res = param3 / 100 + param4 + varaible2*skill.level;
			break;
		case 9:
			res = param5 / 100 + param6 + varaible3*skill.level;
			break;
		case 10:
			res = (param1 + varaible1*skill.level) + param2;
			break;
		case 11:
			res = (param3 + varaible2*skill.level) + param4;
			break;
		case 12:
			res = (param5 + varaible3*skill.level) + param6;
			break;
		case 13:
			res = param1 + varaible1*skill.level;
			break;
		case 14:
			res = param3 + varaible2*skill.level;
			break;
		case 15:
			res = param5 + varaible3*skill.level;
			break;
		default :
			return 0;
		}
		return (int)res;
	}


	public string info;
	public float	param1;
	public float	param2;
	public float	param3;
	public float	param4;
	public float	param5;
	public float	param6;
	public float	varaible1;
	public float	varaible2;
	public float	varaible3;
	public int		formula0;
	public int		formula1;
	public int		formula2;
}
