using UnityEngine;
using System.Collections;
using ProtoBuf;
using System.IO;
using ProtoBuf.Meta;
using DataMessage;

public class SendHeroSysMsgHander : MonoBehaviour{

    public void SendGetHeroList()
    {
		MsgHeroListReq msg = new MsgHeroListReq();
      
		MonoInstancePool.getInstance<NetWorkScript>().sendMessage((int)DataMessage.DATA_MSG_ID.ID_C2S_HERO_LIST, msg);		
    }
	public void SendHeroCall(long heroid)
	{
		HeroData data = MonoInstancePool.getInstance<HeroManager> ().getHero (heroid);
		if(null == data)
		{
			return;
		}
		int curStar = data.starLevel;
		if(curStar == 0)
		{
			curStar = 1;
		}
		int needDebris = StaticHero_star.Instance ().getInt (curStar, "itemnum");
		int haveDebris = data.debris;
		if(haveDebris < needDebris)
		{
			ErrorParse err = (ErrorParse)FindObjectOfType(typeof(ErrorParse));
			if(err != null)
			{
				err.showErrorWindow("没有足够的碎片");
			}
		}

		MsgHeroCallReq msg = new MsgHeroCallReq();
		msg.heroGuid = heroid;
	
		MonoInstancePool.getInstance<NetWorkScript>().sendMessage((int)DataMessage.DATA_MSG_ID.ID_C2S_HERO_CALL, msg);		
	}
	public void SendUpgradeStarlv(long heroid)
	{
		HeroData data = MonoInstancePool.getInstance<HeroManager> ().getHero (heroid);
		if(null == data)
		{
			return;
		}
		int curStar = data.starLevel;
		int needDebris = StaticHero_star.Instance ().getInt (curStar, "itemnum");
		int haveDebris = data.debris;
		if(haveDebris < needDebris)
		{
			ErrorParse err = (ErrorParse)FindObjectOfType(typeof(ErrorParse));
			if(err != null)
			{
				err.showErrorWindow("没有足够的碎片");
				return;
			}
		}

		MsgHeroUpgradeStarReq msg = new MsgHeroUpgradeStarReq();
		msg.heroGuid = heroid;
		MonoInstancePool.getInstance<NetWorkScript>().sendMessage((int)DataMessage.DATA_MSG_ID.ID_C2S_HERO_UPGRADE_STAR, msg);		
	}
	public void SendUpgradeRealm(int idx)
	{
		HeroData data = MonoInstancePool.getInstance<HeroManager> ().getCurShowHero ();
		if(null == data)
		{
			return;
		}
		int level = data.realmList.getLevelByIdx(idx) + 1;
		int needPoint = StaticRealmframe.Instance ().getInt (level,"cost");
		int havePoint = MonoInstancePool.getInstance<UserData> ().soulPoint;
		if(havePoint < needPoint)
		{
			ErrorParse err = (ErrorParse)FindObjectOfType(typeof(ErrorParse));
			if(err != null)
			{
				err.showErrorWindow("没有足够的魂魄点!");
				return;
			}
		}

		MsgHeroUpgradeRealmReq msg = new MsgHeroUpgradeRealmReq();
		msg.heroGuid = data.guid;
		msg.realm = level;
		MonoInstancePool.getInstance<NetWorkScript>().sendMessage((int)DataMessage.DATA_MSG_ID.ID_C2S_HERO_UPGRADE_REALM, msg);		
	}
	public void SendUpgradeRealm(long guid, int curLevel)
	{
		HeroData data = MonoInstancePool.getInstance<HeroManager> ().getCurShowHero ();
		if(null == data)
		{
			return;
		}
		int level = data.realmList.curRealmLevel;
		int needPoint = StaticRealmframe.Instance ().getInt (level,"cost");
		int havePoint = MonoInstancePool.getInstance<UserData> ().soulPoint;
		if(havePoint < needPoint)
		{
			ErrorParse err = (ErrorParse)FindObjectOfType(typeof(ErrorParse));
			if(err != null)
			{
				err.showErrorWindow("没有足够的魂魄点!");
				return;
			}
		}
		
		MsgHeroUpgradeRealmReq msg = new MsgHeroUpgradeRealmReq();
		msg.heroGuid = data.guid;
		msg.realm = level;
		MonoInstancePool.getInstance<NetWorkScript>().sendMessage((int)DataMessage.DATA_MSG_ID.ID_C2S_HERO_UPGRADE_REALM, msg);		
	}
	public void sendSetFightHeroReq(long guid, int pos)
	{
		MsgHeroBattleSlotReq msg = new MsgHeroBattleSlotReq ();
		msg.heroGuid = guid;
		msg.slot = pos;
		MonoInstancePool.getInstance<NetWorkScript>().sendMessage((int)DataMessage.DATA_MSG_ID.ID_C2S_HERO_BATTLE_SLOT, msg);	
	}
	public void sendCancelFightHeroReq(long guid)
	{
		MsgHeroBattleSlotReq msg = new MsgHeroBattleSlotReq ();
		msg.heroGuid = guid;
		msg.slot = -1;
		MonoInstancePool.getInstance<NetWorkScript>().sendMessage((int)DataMessage.DATA_MSG_ID.ID_C2S_HERO_BATTLE_SLOT, msg);	
	}
	public void sendSetUseSkillReq(long heroID, int skillPos, int usePos)
	{
		MsgHeroUseSkillReq msg = new MsgHeroUseSkillReq ();
		msg.heroGuid = heroID;
		msg.skill = skillPos;
		msg.slot = usePos;
		MonoInstancePool.getInstance<NetWorkScript>().sendMessage((int)DataMessage.DATA_MSG_ID.ID_C2S_HERO_USE_SKILL, msg);	
	}

    public void sendHeroStarUp(long heroID)
    {
        MsgHeroUpgradeStarReq msg = new MsgHeroUpgradeStarReq();
        msg.heroGuid = heroID;
        MonoInstancePool.getInstance<NetWorkScript>().sendMessage((int)DataMessage.DATA_MSG_ID.ID_C2S_HERO_UPGRADE_STAR, msg);
    }
	public void sendHeroUpgradeSkill(long heroGuid, int skillPos)
	{
		MsgHeroUpgradeSkillReq msg = new MsgHeroUpgradeSkillReq ();
		msg.heroGuid = heroGuid;
		msg.slot = skillPos;
		MonoInstancePool.getInstance<NetWorkScript>().sendMessage((int)DataMessage.DATA_MSG_ID.ID_C2S_HERO_UPGRADE_SKILL, msg);
	}

  }
