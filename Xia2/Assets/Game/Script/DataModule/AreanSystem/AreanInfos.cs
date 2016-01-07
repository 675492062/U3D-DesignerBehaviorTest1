using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class AreanHeroData{
	public int id;
	public int lv;
	public int starLv;			// 星级
	public int realm;		 	// 境界
}

public class AreanRecordData : AreanRankData {
	public bool result;
	
	public int type;			// 挑战类型 挑战/被挑战
	
	public string time;
	
	public AreanRecordData() : base(){
		
	}
}

public class AreanRankData{
	public int uid;
	
	public int rankIndex;					//名次 ,名次差距
	
	public string name;
	
	public int fightStrength;
	
	public AreanHeroData[] heroDatas;
	
	public AreanRankData(){
		heroDatas = new AreanHeroData[3];
	}
}
//竞技个人信息
public class AreanUserInfo{
	public int index;
	
	public int hIndex;
	
	public int coin;
	
	public Action modifyAction;
	
	int fightTimes;
	
	public int fightCount{
		set{
			fightTimes = value;
		}
		get{
			return fightTimes;
		}
	}
	
	public int buyCount;
	
	public float countCdTime;
	
	public AreanHeroData[] heroDatas;
	
	bool change;
	
	public bool modified{
		set{
			change = value;
			if(modifyAction != null)modifyAction();
		}
	}
	
	public AreanUserInfo(){
		heroDatas = new AreanHeroData[3];
	}
}
//排行里的具体信息
public class AreanDetailInfo{
	int uid;
	
	List<HeroData> heros;
	
	public List<HeroData> GetHeroList(){return heros;}
	
	public AreanDetailInfo(){
		heros = new List<HeroData>();
	}
	
	public void Init(int uid){
		heros.Clear();
		this.uid = uid;
	}
	
	public void AddHeroData(HeroData hero){
		heros.Add(hero);
	}
	
//	bool modify;
	
	public Action notifyAction;
	
//	public bool Notified{
//		set{
//			modify = value;
//		}
//	}
}