using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightMessage;

public class AreanModuleMsg : MonoBehaviour {
	
	public int parse(SocketModel module){
		switch(module.messageID){
			case (int)FIGHT_MSG_ID.ID_S2C_ARENA_RANKLIST:				// 获取竞技场排行榜
				OnGetRankList(module);
				break;
			case (int)FIGHT_MSG_ID.ID_S2C_ARENA_INFO:					// 获取竞技场信息
				OnGetAreanSelf(module);
				break;
			case (int)FIGHT_MSG_ID.ID_S2C_ARENA_OTHER_INFO:				// 获取排行榜用户信息
				OnGetOtherAreanInfo(module);
				break;
			case (int)FIGHT_MSG_ID.ID_S2C_ARENA_FIGHT_INFO:				// 竞技场挑战记录
				OnGetFightRecord(module);
				break;
			case (int)FIGHT_MSG_ID.ID_S2C_ARENA_COIN:					// 更新竞技场币
				OnUpdateAreanCoin(module);
				break;
			case (int)FIGHT_MSG_ID.ID_S2C_ARENA_COUNT:					// 更新挑战次数
				OnUpdateAreanCount(module);
				break;
			case (int)FIGHT_MSG_ID.ID_S2C_ARENA_BUY_COUNT:				// 购买挑战次数
				OnBuyFightCount(module);
				break;
		}
		return 0;
	}
	
	void OnGetRankList(SocketModel module){
		MsgArenaRanklistRep msg = MsgSerializer.Deserialize<MsgArenaRanklistRep>(module);
		var areanMng = MonoInstancePool.getInstance<AreanManager>();
		areanMng.GetAreanRankList().Clear();
		
		List<Ranklist> rankList = msg.list;
		for(int i = 0 ; i < rankList.Count ; i++){
			
			var rankInfo = rankList[i];
			if(rankInfo.rank == MonoInstancePool.getInstance<AreanManager>().GetSelfRankData().index){
				continue;
			}
			var rankData = new AreanRankData();
			rankData.uid = rankInfo.uid;
			rankData.rankIndex = rankInfo.rank;
			rankData.fightStrength = rankInfo.fighting;
			rankData.name = rankInfo.name;
			List<HeroBase> heroList = rankInfo.list;
			
			for(int j = 0 ; j < heroList.Count && j < 3; j++){
				rankData.heroDatas[j] = new AreanHeroData();
				rankData.heroDatas[j].id = heroList[j].heroid;
				rankData.heroDatas[j].lv = heroList[j].level;
				rankData.heroDatas[j].starLv = heroList[j].starLevel;
				rankData.heroDatas[j].realm = heroList[j].realm;
			}
			areanMng.AddRankData(rankData);
		}
		areanMng.SortRankList();
	}
	
	void OnGetAreanSelf(SocketModel module){
		var areanMng = MonoInstancePool.getInstance<AreanManager>();
		MsgArenaInfoRep msg = MsgSerializer.Deserialize<MsgArenaInfoRep>(module);
		
		areanMng.areanUserInfo.index = msg.rank;
		areanMng.areanUserInfo.hIndex = msg.hrank;
		areanMng.areanUserInfo.coin = msg.arenaCoin;
		areanMng.areanUserInfo.fightCount = msg.count;
		areanMng.areanUserInfo.buyCount = msg.buyCount;
		areanMng.areanUserInfo.countCdTime = msg.countTime;
		
		areanMng.areanUserInfo.modified = true;
				
		List<ArenaRecord> records = msg.record;
		for(int i = 0 ; i < records.Count ; i++){
			var data = new AreanRecordData();
			data.uid = records[i].uid;
			data.type = records[i].type;
			data.rankIndex = records[i].rank;
			data.result = records[i].result;
			data.time = records[i].time;
			areanMng.AddRecordData(data);
		}
		MonoInstancePool.getInstance<SendAreanHandler>().SendAreanRankListReq();
	}
	
	void OnGetOtherAreanInfo(SocketModel module){
		var areanMng = MonoInstancePool.getInstance<AreanManager>();
		
		MsgArenaOtherInfoRep msg = MsgSerializer.Deserialize<MsgArenaOtherInfoRep>(module);
		areanMng.detailInfo.Init(msg.uid);
		List<Property.Hero> heroList = msg.heroList;
		for(int i = 0 ; i < heroList.Count ; i++){
			HeroData heroData = new HeroData();
			heroData.parseServerHero(heroList[i]);
			areanMng.detailInfo.AddHeroData(heroData);
		}
		if(areanMng.detailInfo.notifyAction != null){
			areanMng.detailInfo.notifyAction();
			areanMng.detailInfo.notifyAction = null;
		}
	}

	void OnGetFightRecord(SocketModel module){
		MsgArenaFightInfoRep msg = MsgSerializer.Deserialize<MsgArenaFightInfoRep>(module);
		
		var areanMng = MonoInstancePool.getInstance<AreanManager>();
		ArenaRecord record = msg.record;
		var data = new AreanRecordData();
		data.uid = record.uid;
		data.type = record.type;
		data.rankIndex = record.rank;
		data.result = record.result;
		areanMng.InsertRecordData(data);
	}
	
	void OnUpdateAreanCoin(SocketModel module){
		MsgArenaCoinRep msg = MsgSerializer.Deserialize<MsgArenaCoinRep>(module);
		var areanMng = MonoInstancePool.getInstance<AreanManager>();
		areanMng.areanUserInfo.coin = msg.coin;
		areanMng.areanUserInfo.modified = true;
		
	}

	void OnUpdateAreanCount(SocketModel module){
		MsgArenaCountRep msg = MsgSerializer.Deserialize<MsgArenaCountRep>(module);
		var areanMng = MonoInstancePool.getInstance<AreanManager>();
		areanMng.areanUserInfo.fightCount = msg.count;
		areanMng.areanUserInfo.countCdTime = msg.time;
		areanMng.areanUserInfo.modified = true;
	}	
	
	void OnBuyFightCount(SocketModel module){
		MsgArenaBuyCountRep msg = MsgSerializer.Deserialize<MsgArenaBuyCountRep>(module);
		var areanMng = MonoInstancePool.getInstance<AreanManager>();
		areanMng.areanUserInfo.buyCount = msg.count;
		areanMng.areanUserInfo.modified = true;
	}
}