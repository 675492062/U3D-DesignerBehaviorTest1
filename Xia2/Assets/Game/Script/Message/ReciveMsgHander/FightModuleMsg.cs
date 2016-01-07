using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightMessage;

public class FightModuleMsg : MonoBehaviour
{
	public int parse(SocketModel module)
	{
		switch (module.messageID) {
			case (int)FIGHT_MSG_ID.ID_S2C_FIGHT_START://              = 70002; // 战斗开始
				onEnterFight(module);
				break;
			case (int)FIGHT_MSG_ID.ID_S2C_FIGHT_END:
				onFightEndRep(module);
				break;
			case (int)FIGHT_MSG_ID.ID_S2C_CHAPTERED_LIST:
			case (int)FIGHT_MSG_ID.ID_S2C_CHAPTERED_INFO:
			case (int)FIGHT_MSG_ID.ID_S2C_CHAPTERED_BOX:
				MonoInstancePool.getInstance<ChapterDungeonMsg>().parse(module);
				break;
			case (int)FIGHT_MSG_ID.ID_S2C_ARENA_RANKLIST:
			case (int)FIGHT_MSG_ID.ID_S2C_ARENA_INFO:
			case (int)FIGHT_MSG_ID.ID_S2C_ARENA_OTHER_INFO:
			case (int)FIGHT_MSG_ID.ID_S2C_ARENA_FIGHT_INFO:
			case (int)FIGHT_MSG_ID.ID_S2C_ARENA_COIN:
			case (int)FIGHT_MSG_ID.ID_S2C_ARENA_COUNT:
			case (int)FIGHT_MSG_ID.ID_S2C_ARENA_BUY_COUNT:
				MonoInstancePool.getInstance<AreanModuleMsg>().parse(module);
				break;
			case (int)FIGHT_MSG_ID.ID_S2C_ARENA_FIGHT_START:
				OnAreanStartFight(module);
				break;
			case (int)FIGHT_MSG_ID.ID_S2C_ARENA_FIGHT_END:
				OnAreanEndFight(module);
				break;
			default:
				return -1;
		}
		return 0;
	}

    public void onEnterFight(SocketModel module)
    {
        MsgFightStartRep msg = MsgSerializer.Deserialize<MsgFightStartRep>(module);

        FightManager fightMng = MonoInstancePool.getInstance<FightManager>();
        fightMng.clear();

        int normalCount = msg.normal.Count;
        for (int i = 0; i < normalCount; i++)
        {
            DropItem item = new DropItem();
            item.id = msg.normal[i].id;
            item.type = msg.normal[i].type;
            item.number = msg.normal[i].number;
            item.quality = msg.normal[i].quality;

            if ((item.type == (int)GlobalDef.ItemType.ITEM_HERO && item.number > 1) ||
                (item.type == (int)GlobalDef.ItemType.ITEM_HERO_DEBRIS && item.number > 1) ||
                (item.type == (int)GlobalDef.ItemType.ITEM_EQUIPMENT && item.number > 1)
              )
            {
                for (int j = 0; j < item.number; j++)
                    fightMng.normalMonItem[item.type].Add(item);
                continue;
            }
            fightMng.dropItems.Add(item);
        }

        int bossCount = msg.boss.Count;
        for (int i = 0; i < bossCount; i++)
        {
            DropItem item = new DropItem();
            item.id = msg.boss[i].id;
            item.type = msg.boss[i].type;
            item.number = msg.boss[i].number;
            item.quality = msg.boss[i].quality;
            fightMng.bossItem.Add(item);
        }
        int boxCount = msg.box.Count;
        //Debug.Log("--------------------------------box count " + boxCount);
        for (int i = 0; i < boxCount; i++)
        {
            DropItem item = new DropItem();
            item.id = msg.box[i].id;
            item.type = msg.box[i].type;
            item.number = msg.box[i].number;
            item.quality = msg.box[i].quality;
            fightMng.boxItem.Add(item);
        }
        //Debug.Log("server call back enter battle---------------------------------------------");
        SceneCtrl.ToGame();
    }

    /// <summary>
    /// 成功事件回馈，失败无回馈
    /// </summary>
    /// <param name="module"></param>
    public void onFightEndRep(SocketModel module)
    {
        Debug.Log("server call back success --------------------------------------------");
        MsgFightEndRep msg = MsgSerializer.Deserialize<MsgFightEndRep>(module);

        FightManager fightMng = MonoInstancePool.getInstance<FightManager>();
        fightMng.clear();
        //		
        int normalCount = msg.normal.Count;
        for (int i = 0; i < normalCount; i++)
        {
            DropItem item = new DropItem();
            item.id = msg.normal[i].id;
            item.type = msg.normal[i].type;
            item.number = msg.normal[i].number;
            item.quality = msg.normal[i].quality;

            if ((item.type == (int)GlobalDef.ItemType.ITEM_HERO && item.number > 1) ||
               (item.type == (int)GlobalDef.ItemType.ITEM_HERO_DEBRIS && item.number > 1) ||
               (item.type == (int)GlobalDef.ItemType.ITEM_EQUIPMENT && item.number > 1)
               )
            {
                for (int j = 0; j < item.number; j++)
                    fightMng.normalMonItem[item.type].Add(item);
                continue;
            }
            fightMng.dropItems.Add(item);
        }

        int boxCount = msg.award.Count;
        for (int i = 0; i < boxCount; i++)
        {
            DropItem item = new DropItem();
            item.id = msg.award[i].id;
            item.type = msg.award[i].type;
            item.number = msg.award[i].number;
            item.quality = msg.award[i].quality;
            fightMng.boxItem.Add(item);
        }

        fightMng.playerExp = msg.playerExp;
        fightMng.heroExp = msg.heroExp;
        fightMng.money = msg.money;
        //Debug.Log("------------------fightMng.money   " + fightMng.money);
        UIPVEFinishPanel manager = UIPVEFinishPanel.instance;

		if(manager != null)
		{
			 manager.CallBackSuccess();
		}
	}
	
	void OnAreanStartFight(SocketModel module)
	{
		MsgArenaFightStartRep msg = MsgSerializer.Deserialize<MsgArenaFightStartRep>(module);
		MonoInstancePool.getInstance<EnemyHeroManager> ().playerGUID = msg.uid;

		MonoInstancePool.getInstance<EnemyHeroManager> ().fightHeroList.clear ();      //清空参战列表
		MonoInstancePool.getInstance<EnemyHeroManager> ().clear();
		for(int i = 0; i < msg.heroList.Count; i++)
		{
			
			HeroData hero = new HeroData();
			Property.Hero data = msg.heroList[i];
			hero.parseServerHero(data);
			float maxHP = hero.getResPro((int)GlobalDef.NewHeroProperty.PRO_LIFEPOINT);
			MonoInstancePool.getInstance<EnemyHeroManager> ().addHero((long)data.guid,hero);

			hero.refreshCurPorperty();
			float maxHP1 = hero.getResPro((int)GlobalDef.NewHeroProperty.PRO_LIFEPOINT);
			if(hero.battle >= 0)
			{
				MonoInstancePool.getInstance<EnemyHeroManager>().fightHeroList.setFightHero(hero.battle, hero.guid);
			}
		}

		LevelData.SetData(360000, 400000, 1);
		SceneCtrl.ToGame();
	}
	void OnAreanEndFight(SocketModel module)
	{
        MsgArenaFightEndRep msg = MsgSerializer.Deserialize<MsgArenaFightEndRep>(module);
        AreanManager manager = MonoInstancePool.getInstance<AreanManager>();

        UIBattlePvpPanel.pvpRocardData =
            new PVPBattleData(msg.rank, msg.record.rank, msg.rank + msg.record.rank, msg.record.rank, msg.record.name);


        Debug.Log("-------------PVP finish");

        //set player rank
        manager.areanUserInfo.index = msg.rank;
        //update the fight record
		var areanMng = MonoInstancePool.getInstance<AreanManager>();
		ArenaRecord record = msg.record;
		var data = new AreanRecordData();
		data.uid = record.uid;
		data.type = record.type;
		data.rankIndex = record.rank;
		data.result = record.result;
		areanMng.InsertRecordData(data);
	}
}