using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//竞技场排名奖励,竞技规则中出现
public class AreanRankAward {

	public class Award{
		public int type;
		
		public int id;
		
		public int num;
		
		public string icon;
	}

	public enum Type : int{
		Equip = 1,							//装备
		Matrial = 2,						//材料
		Potion = 3,							//药水
		Jewel = 4,							//钻石
		HeroFragment = 7,					//英雄碎片
		Currency = 8,						//货币
		Buns = 9,							//包子
	}
	
	public static int GetAwardId(int rankIndex){
		foreach(int key in StaticCompetition_settlement.Instance().dict.Keys){
			int min = StaticCompetition_settlement.Instance().getInt(key , "rank_min");
			int max = StaticCompetition_settlement.Instance().getInt(key , "rank_max");
			if(rankIndex >= min && rankIndex <= max){
				return key;
			}
		}
		Debug.LogError("[AreanRankAward] cannot find the award id by the rankindex!");
		return 891520;
	}
	
	public static List<AreanRankAward.Award> GetAwardListById(int id){
		List<AreanRankAward.Award> list = new List<AreanRankAward.Award>();
		
		for(int i = 0 ; i < 5 ; i++){
			AreanRankAward.Award award = new AreanRankAward.Award();
			int type = StaticCompetition_settlement.Instance().getInt(id ,"type" + (i + 1));
			if(type != 0){
				award.type = type;
				award.id = StaticCompetition_settlement.Instance().getInt(id ,"itemid" + (i + 1));
				award.num = StaticCompetition_settlement.Instance().getInt(id , "num" + (i +1));
				
				switch(type){
					case (int)AreanRankAward.Type.Equip:
						award.icon = StaticEquipment.Instance().getStr(award.id , "icon");
						break;
					case (int)AreanRankAward.Type.Matrial:
						award.icon = StaticMaterial.Instance().getStr(award.id , "icon");
						break;
					case (int)AreanRankAward.Type.Potion:
						award.icon = StaticPotion.Instance().getStr(award.id , "icon");
						break;
					case (int)AreanRankAward.Type.Jewel:
						award.icon = StaticGem.Instance().getStr(award.id , "icon");
						break;
					case (int)AreanRankAward.Type.HeroFragment:
						award.icon = "ui_mon_linghunshi";
						break;
					case (int)AreanRankAward.Type.Currency:
						award.icon = ShopConstants.PriceIcon(award.id);
						break;
					case (int)AreanRankAward.Type.Buns:
						award.icon = "ui_mon_linghunshi";
						break;
					default:
//						Debug.LogError();
						break;
				}
				list.Add(award);				
			}
		}
		return list;
	}
}