using UnityEngine;
using System.Collections;
using DataMessage;
using System.Linq;

public class UserDataModuleMsg : MonoBehaviour{

	public string sceneName = "Game_CreateTeam";
	string MainSence = "DemoMainScene";

	public int parse(SocketModel module)
	{
        switch (module.messageID)
        {
        case (int)DataMessage.DATA_MSG_ID.ID_S2C_PLAYER_CREATE:// 创建战队
            onPlayerCreate(module);
            break;
        case (int)DataMessage.DATA_MSG_ID.ID_S2C_PLAYER_SELECT_HERO:// 选择初始英雄
            onPlayerSelHero(module);
            break;
		case (int)DataMessage.DATA_MSG_ID.ID_S2C_PLAYER_BASE://登录成功后返回战队基础信息
			onPlayerDataBase(module);
			break;
		case (int)DataMessage.DATA_MSG_ID.ID_S2C_PLAYER_LEVEL://               = 20005; // 更新战队等级经验
			onUpdateLevel(module);
			break;
		case (int)DataMessage.DATA_MSG_ID.ID_S2C_PLAYER_VIP://                 = 20006; // 更新战队VIP等级经验
			onUpdateVip(module);
			break;
		case (int)DataMessage.DATA_MSG_ID.ID_S2C_PLAYER_GOLD://                = 20007; // 更新战队金币
			onUpdateGold(module);
			break;
		case (int)DataMessage.DATA_MSG_ID.ID_S2C_PLAYER_DIAMOND://             = 20008; // 更新战队钻石
			onUpdateDiamond(module);
			break;
		case (int)DataMessage.DATA_MSG_ID.ID_S2C_PLAYER_SOUL://                = 20009; // 更新战队魂魄点
			onUpdateSoul(module);
			break;
		case (int)DataMessage.DATA_MSG_ID.ID_S2C_PLAYER_STAMINA://             = 20010; // 更新战队体力
			onUpdateStamina(module);
			break;
		case (int)DataMessage.DATA_MSG_ID.ID_S2C_PLAYER_BUY_STAMINA://		   = 20014;	//购买体力
			onBuyStamina(module);
			break;
		case (int)DataMessage.DATA_MSG_ID.ID_S2C_PLAYER_FIGHTING://            = 20011; // 更新战队战斗力
			onUpdateFighting(module);
			break;
		case (int)DataMessage.DATA_MSG_ID.ID_S2C_PLAYER_BUY_GOLD:
			onBuyGold(module);
			break;
		case (int)DataMessage.DATA_MSG_ID.ID_S2C_HERO_PROPERTY:                //更新公式参数
			onMathParam(module);
			break;
		case (int)DataMessage.DATA_MSG_ID.ID_S2C_HERO_LIST:                    //获取英雄列表
			onGetHeroList(module);
			break;
		case (int)DataMessage.DATA_MSG_ID.ID_S2C_HERO_UPDATE:                  //更新英雄
			onUpgradeHero(module);
			break;
		case (int)DataMessage.DATA_MSG_ID.ID_S2C_HERO_UPDATE_EQUIP:            //更新装备数据
			onUpdateEquipment(module);
			break;
		case (int)DataMessage.DATA_MSG_ID.ID_S2C_HERO_UPDATE_STAR:			   // 更新英雄星级
			onUpdateHeroStar(module);
			break;
		case (int)DataMessage.DATA_MSG_ID.ID_S2C_HERO_UPDATE_DEBRIS: 		   // 更新碎片个数
			onUpdateDebrisNum(module);
			break;
		case (int)DataMessage.DATA_MSG_ID.ID_S2C_HERO_UPDATE_REALM: 		   // 更新英雄境界
			onUpdateHeroRealm(module);
			break;
		case (int)DataMessage.DATA_MSG_ID.ID_S2C_HERO_BATTLE_SLOT:             //变更出战数据
			onUpdateFightHeroData(module);
			break;
		case (int)DataMessage.DATA_MSG_ID.ID_S2C_HERO_UPDATE_EXP:              // 更新英雄等级经验
			onUpdateHeroLevelExp(module);
			break;
		case (int)DataMessage.DATA_MSG_ID.ID_S2C_HERO_USE_SKILL:			   // 设置使用技能
			onSetUseSkill(module);
			break;
		case (int)DataMessage.DATA_MSG_ID.ID_S2C_HERO_UPGRADE_SKILL:           // 英雄升级技能
			onUpgradeHeroSkill(module);
			break;
		default:
			return -1;
		}
		return 0;
	}

    public void onPlayerCreate(SocketModel module)
    {
        DataMessage.MsgPlayerCreateRep msg = MsgSerializer.Deserialize<DataMessage.MsgPlayerCreateRep>(module);

        bool bResult = msg.result;
        if (bResult)
        {
            Debug.Log("创建战队成功!");

            MonoInstancePool.getInstance<SendUserDataMsgHander>().SendGetPlayerBaseReq();

//             CreateTeamSystemUIManager window = (CreateTeamSystemUIManager)FindObjectOfType(typeof(CreateTeamSystemUIManager));
//             if (window != null)
//             {
//                 window.ShowSelHero();
//            }
        }
        else
        {

        }
    }

    public void onPlayerSelHero(SocketModel module)
    {
        Debug.Log("选择初始英雄成功!");
        MonoInstancePool.getInstance<SendHeroSysMsgHander>().SendGetHeroList();
    }

	public void onPlayerDataBase(SocketModel module)
	{
		DataMessage.MsgPlayerBaseRep msg = MsgSerializer.Deserialize<DataMessage.MsgPlayerBaseRep>(module);

		int uid = msg.uid;
        Random random = new Random();
        //发送创建战队消息
      
		//uid为-1则切换到创建战队场景，如不是-1则切换到大厅场景
        if (uid == -1)
        {
            Application.LoadLevel("CreateTeam");
            //int ImageId = Random.Range(1000, 10000);
            //MonoInstancePool.getInstance<SendMessageHander>().SendCreateTeamRequest(1, ImageId.ToString());

			//Debug.LogError("uid is -1");
			return;
        }
        else
        {
            Debug.Log("team name" + msg.name);
		}
		//设置战队属性
		MonoInstancePool.getInstance<UserData>().guid = msg.uid;
		//MonoInstancePool.getInstance<UserData>().headID = msg.headid;
        MonoInstancePool.getInstance<UserData>().imageID = msg.image;
		MonoInstancePool.getInstance<UserData>().teamName = msg.name;
		MonoInstancePool.getInstance<UserData>().level = msg.level;
		MonoInstancePool.getInstance<UserData>().exp = msg.exp;
		MonoInstancePool.getInstance<UserData>().vipLevel = msg.vip;
		MonoInstancePool.getInstance<UserData>().vipExp = msg.vipExp;
		MonoInstancePool.getInstance<UserData>().soulPoint = msg.soul;
		MonoInstancePool.getInstance<UserData>().gold = msg.gold;
		MonoInstancePool.getInstance<UserData>().diamond = msg.diamond;
		MonoInstancePool.getInstance<UserData>().stamina = msg.stamina;
		MonoInstancePool.getInstance<UserData>().fighting = msg.fighting;
		MonoInstancePool.getInstance<UserData>().staminaInfo.durationTime = msg.staminaTime;
		MonoInstancePool.getInstance<UserData>().staminaInfo.boughtCount = msg.buyStamina;
		MonoInstancePool.getInstance<UserData>().UpdateStaminaInfo();
		MonoInstancePool.getInstance<UserData>().goldInfo.boughtCount = msg.buyGold;
//		MonoInstancePool.getInstance<UserData>().todayShopRefreshCount = msg.todayShopRefreshCount;
//		MonoInstancePool.getInstance<UserData>().lastChageStaminaTime = msg.lastChangeStamina;

        MonoInstancePool.getInstance<SendHeroSysMsgHander>().SendGetHeroList();

        GetOtherPlayerData();
	}

    void GetOtherPlayerData()
    {
        MonoInstancePool.getInstance<SendItemSystemMsgHander>().sendGetItemListReq((int)GlobalDef.BagType.B_EQUIPMENT);
        MonoInstancePool.getInstance<SendItemSystemMsgHander>().sendGetItemListReq((int)GlobalDef.BagType.B_DIAMOND);
        MonoInstancePool.getInstance<SendItemSystemMsgHander>().sendGetItemListReq((int)GlobalDef.BagType.B_MATERIAL);
        MonoInstancePool.getInstance<SendItemSystemMsgHander>().sendGetItemListReq((int)GlobalDef.BagType.B_POTION);
        //test
        MonoInstancePool.getInstance<SendShopMsgHandler>().SendShopListReq();
        MonoInstancePool.getInstance<SendUserDataMsgHander>().SendGetMatchParamReq();
        MonoInstancePool.getInstance<SendTaskSysMessage>().sendGetTaskList();
        MonoInstancePool.getInstance<ChapterManager>().LoadAllChapters();
        MonoInstancePool.getInstance<SendChapterDgnHandler>().SendChapteredListReq();

        MonoInstancePool.getInstance<SendAreanHandler>().SendAreanUserInfoReq();

        // achievement
        MonoInstancePool.getInstance<SendTaskSysMessage>().sendGetAchievementList();
        MonoInstancePool.getInstance<SendTaskSysMessage>().sendGetSoulMessage();
    }
	
	public void onUpdateLevel(SocketModel module)
	{
		DataMessage.MsgPlayerLevelRep msg = MsgSerializer.Deserialize<DataMessage.MsgPlayerLevelRep>(module);
		
		int oldLevel = MonoInstancePool.getInstance<UserData>().level;
		MonoInstancePool.getInstance<UserData>().level = msg.level;
		MonoInstancePool.getInstance<UserData>().exp = msg.exp;
		MonoInstancePool.getInstance<UserData>().UpdateStaminaInfo();
		
		//当升级到可以打开竞技场等级时，开启竞技场，取数据;				直接跳2级???
		int arenaOpenLv = StaticGlobal_parameter.Instance().getInt(850048 , "parameter");
		if(oldLevel != 0 && oldLevel <  arenaOpenLv && msg.level == arenaOpenLv){
			MonoInstancePool.getInstance<SendAreanHandler>().SendAreanUserInfoReq();
		}

		InitTeamProperty team = (InitTeamProperty)FindObjectOfType(typeof(InitTeamProperty));
		if(team != null)
		{
			team.refreshData();
		}
	}
	
	public void onUpdateVip(SocketModel module)
	{
		DataMessage.MsgPlayerVipRep msg = MsgSerializer.Deserialize<DataMessage.MsgPlayerVipRep>(module);

		MonoInstancePool.getInstance<UserData>().vipLevel = msg.vip;
		MonoInstancePool.getInstance<UserData>().vipExp = msg.vipExp;
		MonoInstancePool.getInstance<UserData>().UpdateStaminaInfo();
	
		InitTeamProperty team = (InitTeamProperty)FindObjectOfType(typeof(InitTeamProperty));
		if(team != null)
		{
			team.refreshData();
		}
	}
	
	public void onBuyGold(SocketModel module){
		DataMessage.MsgPlayerBuyGoldRep msg = MsgSerializer.Deserialize<DataMessage.MsgPlayerBuyGoldRep>(module);
		MonoInstancePool.getInstance<UserData>().goldInfo.boughtCount = msg.count; 
	}
	
	public void onUpdateGold(SocketModel module)
	{
		DataMessage.MsgPlayerGoldRep msg = MsgSerializer.Deserialize<DataMessage.MsgPlayerGoldRep>(module);

		MonoInstancePool.getInstance<UserData>().gold = msg.gold;

		InitTeamProperty team = (InitTeamProperty)FindObjectOfType(typeof(InitTeamProperty));
		if(team != null)
		{
			team.refreshData();
		}
	}
	
	public void onBuyStamina(SocketModel module){
		DataMessage.MsgPlayerBuyStaminaRep msg = MsgSerializer.Deserialize<DataMessage.MsgPlayerBuyStaminaRep>(module);
		MonoInstancePool.getInstance<UserData>().staminaInfo.boughtCount = msg.count;
	}
	
	public void onUpdateDiamond(SocketModel module)
	{
		DataMessage.MsgPlayerDiamondRep msg = MsgSerializer.Deserialize<DataMessage.MsgPlayerDiamondRep>(module);

		MonoInstancePool.getInstance<UserData>().diamond = msg.diamond;

		InitTeamProperty team = (InitTeamProperty)FindObjectOfType(typeof(InitTeamProperty));
		if(team != null)
		{
			team.refreshData();
		}
	}
	public void onUpdateSoul(SocketModel module)
	{
		DataMessage.MsgPlayerSoulRep msg = MsgSerializer.Deserialize<DataMessage.MsgPlayerSoulRep>(module);

		MonoInstancePool.getInstance<UserData>().soulPoint = msg.soul;

		InitTeamProperty team = (InitTeamProperty)FindObjectOfType(typeof(InitTeamProperty));
		if(team != null)
		{
			team.refreshData();
		}
	}
	public void onUpdateStamina(SocketModel module)
	{
		DataMessage.MsgPlayerStaminaRep msg = MsgSerializer.Deserialize<DataMessage.MsgPlayerStaminaRep>(module);

		MonoInstancePool.getInstance<UserData>().stamina = msg.stamina;
		MonoInstancePool.getInstance<UserData>().staminaInfo.durationTime = msg.time;

		InitTeamProperty team = (InitTeamProperty)FindObjectOfType(typeof(InitTeamProperty));
		if(team != null)
		{
			team.refreshData();
		}
	}
	public void onUpdateFighting(SocketModel module)
	{
		DataMessage.MsgPlayerFightingRep msg = MsgSerializer.Deserialize<DataMessage.MsgPlayerFightingRep>(module);

		MonoInstancePool.getInstance<UserData>().fighting = msg.fighting;

		InitTeamProperty team = (InitTeamProperty)FindObjectOfType(typeof(InitTeamProperty));
		if(team != null)
		{
			team.refreshData();
		}
	}
	public void onMathParam(SocketModel module)
	{
		DataMessage.MsgHeroPropertyRep msg = MsgSerializer.Deserialize<DataMessage.MsgHeroPropertyRep>(module);

		float baseNum = 10000f;
		MonoInstancePool.getInstance<MathParam>().dod_attenuation_coefficient_a = msg.dod_attenuation_coefficient_a / baseNum;
		MonoInstancePool.getInstance<MathParam>().dod_attenuation_coefficient_b = msg.dod_attenuation_coefficient_b / baseNum;
		MonoInstancePool.getInstance<MathParam>().dod_attenuation_coefficient_c = msg.dod_attenuation_coefficient_c / baseNum;
		MonoInstancePool.getInstance<MathParam>().dodrate_coefficient_a = msg.dodrate_coefficient_a / baseNum;
		MonoInstancePool.getInstance<MathParam>().dodrate_coefficient_b = msg.dodrate_coefficient_b / baseNum;
		MonoInstancePool.getInstance<MathParam>().cri_attenuation_coefficient_a = msg.cri_attenuation_coefficient_a / baseNum;
		MonoInstancePool.getInstance<MathParam>().cri_attenuation_coefficient_b = msg.cri_attenuation_coefficient_b / baseNum;
		MonoInstancePool.getInstance<MathParam>().cri_attenuation_coefficient_c = msg.cri_attenuation_coefficient_c / baseNum;
		MonoInstancePool.getInstance<MathParam>().crirate_coefficient_a = msg.crirate_coefficient_a / baseNum;
		MonoInstancePool.getInstance<MathParam>().crirate_coefficient_b = msg.crirate_coefficient_b / baseNum;

//
		MonoInstancePool.getInstance<MathParam>().hit_attenuation_coefficient_a = msg.hit_attenuation_coefficient_a / baseNum;   //命中衰减参数计算系数
		MonoInstancePool.getInstance<MathParam> ().hit_attenuation_coefficient_b = msg.hit_attenuation_coefficient_b / baseNum;  //命中衰减参数计算系数
		MonoInstancePool.getInstance<MathParam> ().hit_attenuation_coefficient_c = msg.hit_attenuation_coefficient_c / baseNum;  //命中衰减参数计算系数
		MonoInstancePool.getInstance<MathParam> ().hitrate_coefficient_a = msg.hitrate_coefficient_a / baseNum;	   //命中计算参数
		MonoInstancePool.getInstance<MathParam> ().hitrate_coefficient_b = msg.hitrate_coefficient_b / baseNum;      //命中计算参数
		
		MonoInstancePool.getInstance<MathParam> ().armor_attenuation_coefficient_a = msg.armor_attenuation_coefficient_a / baseNum;//护甲衰减参数计算系数
		MonoInstancePool.getInstance<MathParam> ().armor_attenuation_coefficient_b = msg.armor_attenuation_coefficient_b / baseNum;//护甲衰减参数计算系数
		MonoInstancePool.getInstance<MathParam> ().armor_attenuation_coefficient_c = msg.armor_attenuation_coefficient_c / baseNum;//护甲衰减参数计算系数
		MonoInstancePool.getInstance<MathParam> ().armorrate_coefficient_a = msg.armorrate_coefficient_a / baseNum;  //护甲计算参数
		MonoInstancePool.getInstance<MathParam> ().armorrate_coefficient_b = msg.armorrate_coefficient_b / baseNum;  //护甲计算参数

//		string temp = "";
//		temp += msg.dod_attenuation_coefficient_a + "\n";
//		temp += msg.dod_attenuation_coefficient_b + "\n";
//		temp += msg.dod_attenuation_coefficient_c + "\n";
//		temp += msg.dodrate_coefficient_a + "\n";
//		temp += msg.dodrate_coefficient_b + "\n";
//		temp += msg.cri_attenuation_coefficient_a + "\n";
//		temp += msg.cri_attenuation_coefficient_b + "\n";
//		temp += msg.cri_attenuation_coefficient_c + "\n";
//		temp += msg.crirate_coefficient_a + "\n";
//		temp += msg.crirate_coefficient_b + "\n";
//		Debug.Log("MathParam " + temp);

		//MonoInstancePool.getInstance<SendHeroSysMsgHander>().SendGetHeroList();
	}
	public void onGetHeroList(SocketModel module)
	{
		DataMessage.MsgHeroListRep msg = MsgSerializer.Deserialize<DataMessage.MsgHeroListRep>(module);

        if (msg.heroList.Count == 0)
        {
            // 战队为空
            Application.LoadLevel("CreateTeam");
            return;
        }
        

		MonoInstancePool.getInstance<HeroManager> ().fightHeroList.clear ();      //清空参战列表
		MonoInstancePool.getInstance<HeroManager> ().fightHeroList.isDirty = true;//设置刷新标志
		MonoInstancePool.getInstance<HeroManager> ().clear();
		for(int i = 0; i < msg.heroList.Count; i++)
		{
			MonoInstancePool.getInstance<HeroManager>().isDirty = true;
			MonoInstancePool.getInstance<HeroManager>().fightHeroList.updateMenuModel = true;

			HeroData hero = new HeroData();
			Property.Hero data = msg.heroList[i];
			hero.parseServerHero(data);

			MonoInstancePool.getInstance<HeroManager>().addHero(hero.guid, hero);
			if(hero.battle >= 0)
			{
				MonoInstancePool.getInstance<HeroManager>().fightHeroList.setFightHero(hero.battle, hero.guid);
			}
		}

		HeroInfoManager manager = (HeroInfoManager)FindObjectOfType(typeof(HeroInfoManager));
		if(manager != null)
		{
			manager.refreshList();
		}
		MonoInstancePool.getInstance<HeroManager> ().fightHeroList.updateMenuModel = true;

		//切换场景
		MonoInstancePool.getInstance<UserData>().ChangeScene(MainSence);
	}
	public void onUpgradeHero(SocketModel module)
	{
		DataMessage.MsgHeroUpdateRep msg = MsgSerializer.Deserialize<DataMessage.MsgHeroUpdateRep>(module);

		bool needcreate = msg.isNeedCreate;
		Property.Hero data = msg.heroInfo;
		HeroData hero = null;
		if(needcreate)
		{
			hero = new HeroData();

			MonoInstancePool.getInstance<TaskManager>().addTaskParam((int)GlobalDef.TaskTargetType.T_HEROGOT, data.heroid, 1);
		}
		else 
		{
			hero = MonoInstancePool.getInstance<HeroManager>().getHero((long)data.guid);
		}
		if(data == null || hero == null)
		{
			Debug.LogError("data error!");
			return;
		}
		if(needcreate)
		{
			MonoInstancePool.getInstance<HeroManager>().addHero(hero.guid, hero);
		}
		MonoInstancePool.getInstance<HeroManager>().isDirty = true;

		hero.parseServerHero(data);
	}
	public void onUpdateEquipment(SocketModel module)
	{
		DataMessage.MsgHeroUpdateEquipRep msg = MsgSerializer.Deserialize<DataMessage.MsgHeroUpdateEquipRep>(module);

		long heroid = (long)msg.heroGuid;
		int type = msg.type;
		HeroData hero =  MonoInstancePool.getInstance<HeroManager>().getHero(heroid);
		if(null == hero)
		{
			return;
		}
		if(type == (int)GlobalDef.EquipmentChange.E_PUTON)
		{
			EquipmentItem item = new EquipmentItem();
			item.parseData(msg.equipInfo);
			Debug.Log("    ********************************* recive" + (long)msg.equipInfo.guid);
			hero.equipmentList.addItem((long)msg.equipInfo.guid,item);
			hero.equipmentList.isDirty = true;

			//背包列表
			HeroSysEquipBagWindow window = (HeroSysEquipBagWindow)FindObjectOfType(typeof(HeroSysEquipBagWindow));
			if(window != null)
			{
				window.refresh();
			}
			//身上装备列表
			UIEquipmentList window1 = (UIEquipmentList)FindObjectOfType(typeof(UIEquipmentList));
			if(window1 != null)
			{
				window1.refresh(hero);
			}
		}
		else if(type == (int)GlobalDef.EquipmentChange.E_PUTOFF)
		{
			long guid = (long)msg.guid;
//			MonoInstancePool.getInstance<BagManager>().getEquipmentBag().removeItem(guid);
//			MonoInstancePool.getInstance<BagManager>().getEquipmentBag().IsDirty = true;

			hero.equipmentList.removeItem(guid);
			hero.equipmentList.isDirty = true;

			HeroSysEquipBagWindow window = (HeroSysEquipBagWindow)FindObjectOfType(typeof(HeroSysEquipBagWindow));
			if(window != null)
			{
				window.refresh();
			}
			//身上装备列表
			UIEquipmentList window1 = (UIEquipmentList)FindObjectOfType(typeof(UIEquipmentList));
			if(window1 != null)
			{
				window1.refresh(hero);
			}
		}
	}
	public void onUpdateHeroStar(SocketModel module)
	{
		DataMessage.MsgHeroUpdateStarRep msg = MsgSerializer.Deserialize<DataMessage.MsgHeroUpdateStarRep>(module);

		long guid = msg.heroGuid;
		HeroData data = MonoInstancePool.getInstance<HeroManager> ().getHero (guid);
		if(null == data)
		{
			return;
		}
		data.starLevel = msg.star;

		BagUIManager window = (BagUIManager)FindObjectOfType (typeof(BagUIManager));
		if(window != null)
		{
			window.refreshAllData();
		}
	}
	public void onUpdateDebrisNum(SocketModel module)
	{
		DataMessage.MsgHeroUpdateDebrisRep msg = MsgSerializer.Deserialize<DataMessage.MsgHeroUpdateDebrisRep>(module);
		long guid = msg.heroGuid;
		HeroData data = MonoInstancePool.getInstance<HeroManager> ().getHero (guid);
		if(null == data)
		{
			return;
		}
		Debug.Log ("debris " + msg.debris);
		data.debris = msg.debris;
	}
	public void onUpdateHeroRealm(SocketModel module)
	{
		DataMessage.MsgHeroUpdateRealmRep msg = MsgSerializer.Deserialize<DataMessage.MsgHeroUpdateRealmRep>(module);

		long guid = msg.heroGuid;
		HeroData data = MonoInstancePool.getInstance<HeroManager> ().getHero (guid);
		if(null == data)
		{
			return;
		}
		data.realmList.curRealmLevel = msg.realm;


		BagUIManager manager = (BagUIManager)FindObjectOfType (typeof(BagUIManager));
		if(manager != null)
		{
			manager.realmManager.runBarAction();
			manager.updateBagMoney();
		}
	}
	public void onUpdateFightHeroData(SocketModel module)
	{
		DataMessage.MsgHeroBattleSlotRep msg = MsgSerializer.Deserialize<DataMessage.MsgHeroBattleSlotRep>(module);
		long battleHeroID = msg.heroGuid;
		int  battleHeroPos = msg.slot;
		long restHeroID = msg.restGuid;

		HeroData data = MonoInstancePool.getInstance<HeroManager> ().getHero (battleHeroID);
		if(data != null)
		{
			data.battle = battleHeroPos;
			MonoInstancePool.getInstance<HeroManager> ().fightHeroList.setFightHero(battleHeroPos, data.guid);
		}
		if(restHeroID > 0)
		{
			HeroData rest = MonoInstancePool.getInstance<HeroManager> ().getHero (restHeroID);
			if(rest != null)
			{
				rest.battle = -1;
				MonoInstancePool.getInstance<HeroManager> ().fightHeroList.removeByGuid(restHeroID);
			}
		}
		MonoInstancePool.getInstance<HeroManager>().fightHeroList.isDirty = true;
		MonoInstancePool.getInstance<HeroManager>().fightHeroList.updateMenuModel = true;
		MonoInstancePool.getInstance<HeroManager>().isDirty = true;
	}
	public void onUpdateHeroLevelExp(SocketModel module)
	{
		DataMessage.MsgHeroUpdateLevelRep msg = MsgSerializer.Deserialize<DataMessage.MsgHeroUpdateLevelRep>(module);

		long guid = msg.heroGuid; // 英雄id
		int level = msg.level;    // 英雄等级
		int exp = msg.exp;        // 英雄经验
		HeroData data = MonoInstancePool.getInstance<HeroManager> ().getHero (guid);
		if(data == null)
		{
			return;
		}
		data.level = level;
		data.exp = exp;
	}
	public void onSetUseSkill(SocketModel module)
	{
		DataMessage.MsgHeroUseSkillRep msg = MsgSerializer.Deserialize<DataMessage.MsgHeroUseSkillRep>(module);
		long heroGuid = msg.heroGuid; // 英雄id

		HeroData data = MonoInstancePool.getInstance<HeroManager> ().getHero (heroGuid);
		if(data == null)
		{
			return;
		}
		//skill
		data.skillList.clearUseSkill();
		data.skillList.useSkills [0] = msg.skill_1;
		data.skillList.useSkills [1] = msg.skill_2;
		data.skillList.useSkills [2] = msg.skill_3;

		HeroUISkillList list = (HeroUISkillList)FindObjectOfType(typeof(HeroUISkillList));
		if(null != list)
		{
			list.refreshUseSkill(data);
		}
	}
	public void onUpgradeHeroSkill(SocketModel module)
	{
		DataMessage.MsgHeroUpgradeSkillRep msg = MsgSerializer.Deserialize<DataMessage.MsgHeroUpgradeSkillRep>(module);
		long guid = msg.heroGuid;
		int pos = msg.slot;
		int level = msg.level;

		HeroData data = MonoInstancePool.getInstance<HeroManager> ().getHero (guid);
		if(data != null)
		{
			SkillItem  skill = data.skillList.getSkillByIdx(pos);
			if(skill == null)
			{
				return;
			}
			skill.level = level;
			//refresh ui
			SkillInfoWindow list = (SkillInfoWindow)FindObjectOfType(typeof(SkillInfoWindow));
			if(list != null)
			{
				list.refresh(data, skill, pos);
			}
		}

	}
}
