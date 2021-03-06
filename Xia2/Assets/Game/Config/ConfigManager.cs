using UnityEngine;
using System.Collections;

public class ConfigManager {
	private static ConfigManager manager;
	//Instance
	public static ConfigManager getInstance() {
		if (manager == null) {
			//第一次调用的时候 创建单例对象
			manager = new ConfigManager();
		}
		
		return manager;
	}
	public ConfigManager()
	{
	}
	public void destroy()
	{
		manager = null;
	}

	public int getTypeByTemplateID(int templateID)
	{
		int type = -1;
		type = StaticGem.Instance().getIdxByTemplateID(templateID);
		if(type != -1) return StaticGem.Instance().getInt(templateID, "type");

		type = StaticHero.Instance().getIdxByTemplateID(templateID);
		if(type != -1) return StaticHero.Instance().getInt(templateID, "type");

		type = StaticMaterial.Instance().getIdxByTemplateID(templateID);
		if(type != -1) return StaticMaterial.Instance().getInt(templateID, "type");

		type = StaticPotion.Instance().getIdxByTemplateID(templateID);
		if(type != -1) return StaticPotion.Instance().getInt(templateID, "type");

		type = StaticEquipment.Instance().getIdxByTemplateID(templateID);
		if(type != -1) return StaticEquipment.Instance().getInt(templateID, "type");

		type = StaticEquip_intensify.Instance().getIdxByTemplateID(templateID);
		if(type != -1) return StaticEquip_intensify.Instance().getInt(templateID, "type");

		type = StaticEquip_intensify_exp.Instance().getIdxByTemplateID(templateID);
		if(type != -1) return StaticEquip_intensify_exp.Instance().getInt(templateID, "type");

		type = StaticEquip_star_exp.Instance().getIdxByTemplateID(templateID);
		if(type != -1) return StaticEquip_star_exp.Instance().getInt(templateID, "type");

		type = StaticHero.Instance().getIdxByTemplateID(templateID);
		if(type != -1) return StaticHero.Instance().getInt(templateID, "type");

		type = StaticHero_star.Instance().getIdxByTemplateID(templateID);
		if(type != -1) return StaticHero_star.Instance().getInt(templateID, "type");

		type = StaticHero_state.Instance().getIdxByTemplateID(templateID);
		if(type != -1) return StaticHero_state.Instance().getInt(templateID, "type");

		type = StaticMonster.Instance().getIdxByTemplateID(templateID);
		if(type != -1) return StaticMonster.Instance().getInt(templateID, "type");

		type = StaticMission.Instance().getIdxByTemplateID(templateID);
		if(type != -1) return StaticMission.Instance().getInt(templateID, "type");

		Debug.LogError("have not this item! templateID: " + templateID);
		return -1;
	}
	public void refreshTemplateData()
	{
		Debug.Log ("----------------------- refreshTemplateData");
		StaticDialog.Instance ().readData ();
		StaticEquip_intensify.Instance().readData ();
        StaticEquip_intensify_attribute.Instance().readData();
		StaticEquip_intensify_exp.Instance().readData ();
		StaticEquip_star_exp.Instance().readData ();
		StaticEquipment.Instance ().readData ();
		StaticError.Instance ().readData ();
		StaticGem.Instance ().readData ();
		StaticHero.Instance().readData ();
		StaticHero_star.Instance ().readData ();
		StaticHero_state.Instance ().readData ();
		StaticDungeon.Instance ().readData ();
		StaticLead_level.Instance ().readData ();
		StaticLevel.Instance ().readData ();
		StaticMaterial.Instance().readData ();
		StaticPotion.Instance().readData ();
		StaticMonster.Instance().readData ();
		StaticMission.Instance().readData ();
		StaticSentence.Instance ().readData ();
		StaticTime_price.Instance ().readData ();
		StaticRealmframe.Instance ().readData ();
		StaticRealmpoint.Instance ().readData ();
		StaticVip.Instance ().readData ();
        StaticSkill.Instance().readData();
		StaticGlobal_parameter.Instance().readData();
        StaticEquip_intensify_trigger.Instance().readData();
        StaticEquip_smelt.Instance().readData();
        StaticEquip_forge_formula.Instance().readData();
		StaticCombo.Instance ().readData ();
		Debug.Log ("----------------------- end  refreshTemplateData");
	}

	public string getData(int templateID, string title)
	{
		string name = "";
		//		string title = "name";
		name = StaticDialog.Instance().getStr(templateID, title);
		if(string.Compare(name, "-1") != 0) { return name; }
		name = StaticEquip_intensify.Instance().getStr(templateID, title);
		if(string.Compare(name, "-1") != 0) { return name; }
		name = StaticEquip_intensify_exp.Instance().getStr(templateID, title);
		if(string.Compare(name, "-1") != 0) { return name; }
		name = StaticEquip_star_exp.Instance().getStr(templateID, title);
		if(string.Compare(name, "-1") != 0) { return name; }
		name = StaticEquipment.Instance().getStr(templateID, title);
		if(string.Compare(name, "-1") != 0) { return name; }
		name = StaticGem.Instance().getStr(templateID, title);
		if(string.Compare(name, "-1") != 0) { return name; }
		name = StaticHero.Instance().getStr(templateID, title);
		if(string.Compare(name, "-1") != 0) { return name; }
		name = StaticHero_star.Instance().getStr(templateID, title);
		if(string.Compare(name, "-1") != 0) { return name; }
		name = StaticHero_state.Instance().getStr(templateID, title);
		if(string.Compare(name, "-1") != 0) { return name; }
		name = StaticDungeon.Instance().getStr(templateID, title);
		if(string.Compare(name, "-1") != 0) { return name; }
		name = StaticLead_level.Instance().getStr(templateID, title);
		if(string.Compare(name, "-1") != 0) { return name; }
		name = StaticLevel.Instance().getStr(templateID, title);
		if(string.Compare(name, "-1") != 0) { return name; }
		name = StaticMaterial.Instance().getStr(templateID, title);
		if(string.Compare(name, "-1") != 0) { return name; }
		name = StaticMission.Instance().getStr(templateID, title);
		if(string.Compare(name, "-1") != 0) { return name; }
		name = StaticMonster.Instance().getStr(templateID, title);
		if(string.Compare(name, "-1") != 0) { return name; }
		name = StaticPotion.Instance().getStr(templateID, title);
		if(string.Compare(name, "-1") != 0) { return name; }
		name = StaticSentence.Instance().getStr(templateID, title);
		if(string.Compare(name, "-1") != 0) { return name; }
		
		return string.Empty;
	}
}
