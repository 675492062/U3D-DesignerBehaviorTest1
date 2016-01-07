using UnityEngine;
using System.Collections;

public class AchievementItem : BaseItem
{
	public AchievementItem() {
		progress = 0;
	}

	public int id{
		set{
			templateID = value;
		}
		get{
			return templateID;
		}
	}
	/// <summary>
	/// Gets or sets the progress.
	/// </summary>
	/// <value>The progress.</value>
	public int progress{set;get;}

	/// 名称
	public string name{get;private set;}
	/// 描述
	public string desc{get;private set;}
	/// 前置解锁
	public int unLockId{get;private set;}
	/// 目标类型 1:成长2：充值3：战斗4：排行5：节日6：事迹
	public int myType{get;private set;}
	/// 图标名
	public string icon{get;private set;}
	/// 目标条件
	public int target_value{get;private set;}
	/// 成就效果：
	/// 生命值:hp
	/// 攻击力:attack
	/// 护甲:armor
	/// 爆击等级:criticallv
	/// 韧性等级:tenacitylv
	/// 闪避等级:dodgelv
	/// 命中等级:hitlv
	public string effect_key{get;private set;}
	/// 成就效果值
	public int effect_value{get;private set;}
	/// 达成成就获得的血魂经验
	public int exp{get;private set;}
	/// 限时开始时间
	public int begin_date{get;private set;}
	/// 限时结束时间
	public int end_date{get;private set;}

	public void parseData(int _id){
		id = _id;
		StaticAchievement datas = StaticAchievement.Instance();
		name = datas.getStr(_id, "name");
		desc = datas.getStr(_id, "describe");
		unLockId = datas.getInt(_id, "unlock");
		myType = datas.getInt(_id, "target_id");
		icon = datas.getStr(_id, "icon");
		target_value = datas.getInt(_id, "target_value");
		effect_key = datas.getStr(_id, "effect_key");
		effect_value = datas.getInt(_id, "effect_value");
		exp = datas.getInt(_id, "exp");
		begin_date = datas.getInt(_id, "begin_date");
		end_date = datas.getInt(_id, "end_date");
	}
}
