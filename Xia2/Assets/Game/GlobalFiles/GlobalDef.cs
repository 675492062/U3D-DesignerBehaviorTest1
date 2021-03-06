using UnityEngine;
using System.Collections;

public static class GlobalDef {

	public const int START_MOVE = 0;
	public const int MOVEING = 1;
	public const int ENG_MOVE = 2;
	public static long startReciveMsg = 0;
	public static long endParseAllMsg = 0;
	public static long sendMsg = 0;
	public static long reciveMsg = 0;
    public const string MAILERROR = "邮箱格式错误"; 
	public const string NAMEISNULL = "请输入账号";
	public const string PASSWORDISNULL = "请输入密码";
	public const string CONFIRMPASSWORDISNULL = "请确认密码";
	public const string PASSWORDOINCONFORMITY = "密码不一致，请重新输入";
	public const string SYSTEMCHATCHANNEL = "系统";
	public const string WORLDCHATCHANNEL = "世界";
	public const string PRIVATECHATCHANNEL = "私聊";
	public const string MYSELF = "我";
	public const int MAXCHATITEM = 20;
	public const int MAXFIGHTHERONUM = 9;
	public const int MAX_USE_SKILL = 3;
	public const int MAX_HERO = 3;
	public const float SEND_HEARTBEAT_TIME = 5;//发送心跳包时间间隔
	public const int MAX_DISCONNECT_TIME = 15; //最大断开连接的时间
	
	public static UIState mainSceneState = UIState.UI_NORMAL;				//进入主场景，默认显示的ui，UIState.UI_NORMAL(none)不作处理 , 
	
	public enum PLAYER_STATE
	{
		//玩家的状态  
		PLAYER_IDLE = 0,
		PLAYER_WALK = 1,
		PLAYER_RUN = 2,
		PLAYER_Attack = 3,
		PLAYER_Attack_1 = 4,
		PLAYER_Attack_2 = 5,
		PLAYER_Attack_3 = 6,
		PLAYER_Attack_4 = 7,
		PLAYER_Attack_5 = 8,
		PLAYER_Attacked_1 = 9,
		PLAYER_STDOWN = 10,
	}

	public enum MONSTER_STATE
	{
		//状态  
		MONSTER_IDLE = 0,
		MONSTER_WALK = 1,
		MONSTER_RUN = 2,
		MONSTER_Attack_1 = 3,
		MONSTER_Attack_2 = 4,
		MONSTER_Attack_3 = 5,
		MONSTER_Attacked_1 = 6,
		MONSTER_Attacked_2 = 7,
		MONSTER_Attacked_3 = 8,
		MONSTER_Dead = 9,
		MONSTER_HitBack = 10,
		MONSTER_HitDown = 11,
		MONSTER_ReStand = 12,
	}

	public enum MoveState
	{
		START,
		MOVEING,
		END,
	}

	public enum ATTACK_EFFECT
	{
		ATTACK1_DM = 0,
		ATTACK1_SHUIMO = 1,
		ATTACK1_JZ = 2,
		ATTACK2_DM = 3,
		ATTACK2_JZ = 4,
		ATTACK3_CANLIU = 5,
		ATTACK3_DM = 6,
		ATTACK3_JZ = 7,
        ATTACK_XULI = 8,
    }

    //聊天
    public enum CHAT_CHANNEL
    {
        ALL_CHANNEL = 0,    //系统
        WORLD_CHANNEL = 1,  //世界聊天
        PRIVATE_CHANNEL = 2,//私密聊天
    }

	// Item
	public enum ItemType
	{
		ITEM_NORMAL,
		ITEM_EQUIPMENT = 1,
		ITEM_MATERIAL = 2,
		ITEM_MEDICINE = 3,
		ITEM_DIAMOND = 4,
		ITEM_HERO = 5,
		ITEM_MONSTER = 6,
		ITEM_HERO_DEBRIS = 7,
		ITEM_GOLD = 8,
		ITEM_FOOD = 9,
		ITEM_MAX = 10,
	}

	// Money
	public enum MoneyType
	{
		MONEY_GOLD,     //金币
		MONEY_DIAMOND,  //宝石
		MONEY_SOULSTONE,//魂石
	}

    //server status
    public enum ServerStatusType
    {
        SERVERTYPEGOOD = 0,
        SERVERTYPEHOT = 1,
        SERVERTYPEMOTIFY = 2,
    }

	public enum UIState
	{
		UI_NORMAL = 0,
		UI_SHOP = 1,
		UI_BAG = 2,
		UI_MAIL = 3,
		UI_FRIEND = 4,
		UI_ANNOUNCEMENT = 5,
        UI_CHAT = 6,
		UI_BAGNEW = 7,
		UI_TASK_WINDOW = 8,
		UI_GM_WINDOW = 9,
		UI_EQUIPMENTSYS_WINDOW = 10,
		UI_HEROSYS_WINDOW = 11,
		UI_CAPTER_WINDOW = 12,
		UI_AREAN_RANK_LIST = 13,
		UI_BLOODSOUL_WINDOW = 14,
    }

    public enum FriendType
    {
        FriendList = 0,
        InviteList = 1,
    }

	public enum EnterBagType
	{
		E_MAINUI,
		E_CHAT,
	}

	public enum ChatPosition
	{
		CHATINFOPOSITION = 180,
		CHATGRIDPOSITION = 0,
		CHATVIEWHEIGHT = 390,
	}

	public enum HeroType
	{
		H_STR = 0,
		H_ILG = 1,
		H_SMART = 2,
	}

	public enum HeroProperty 
	{
		PRO_LIFE          = 0, //生命
		PRO_STRENGTH      = 1, //力量
		PRO_INTELLIGENCE  = 2, //智力
		PRO_SMART         = 3, //敏捷
		PRO_MANAPOINT     = 4, //无双段
		PRO_CRITICALLV    = 5, //爆击等级
		PRO_CRITICALDAMAGE= 6, //爆机伤害
		PRO_HITLV         = 7, //命中等级
		PRO_ATKDELTA      = 8, //攻击力伤害
		PRO_FIREDAMAGE    = 9, //火焰伤害
		PRO_ICEDAMAGE     = 10, //冰霜伤害
		PRO_POISONDAMAGE  = 11, //毒素伤害
		PRO_LIGHTNINGDAMAGE= 12, //雷电伤害
		PRO_HITREGEN       = 13, //击中回复
		PRO_KILLREGEN      = 14, //击杀回复
		PRO_LIFESTEAK      = 15, //生命窃取
		PRO_RECOVERY       = 16, //战斗回复
		PRO_TRUEDAMAGE     = 17, //真实伤害
		PRO_DODGELV        = 18, //闪避等级
		PRO_TENACITYLV     = 19, //韧性等级
		PRO_FIRERESIST     = 20, //火焰抗性
		PRO_ICERESIST      = 21, //冰霜抗性
		PRO_POISONRESIST   = 22, //毒素抗性
		PRO_LIGHTNINGRESIST= 23, //闪电抗性
		PRO_TRUEDGRESIST   = 24, //真实伤害减免
		PRO_REDHOLE        = 25, //红宝石孔
		PRO_PURPLEHOLE     = 26, //紫色宝石孔
		PRO_GREENHOLE      = 27, //绿色宝石孔
		PRO_BLUEHOLE       = 28, //蓝色宝石孔
		PRO_EXP            = 29, //经验
		PRO_ARMOR          = 30, //防御 
		PRO_ATTACK         = 31, //攻击 
		PRO_TENACITY       = 32, //韧性
		PRO_DEFENCE        = 33, //防御
	}   

	public static string []HeroPropertyName = 
	{
		"生命",//        PRO_LIFE          = 0, //
		"力量",//        PRO_STRENGTH      = 1, //
		"智力",//        PRO_INTELLIGENCE  = 2, //
		"敏捷",//        PRO_SMART         = 3, //
		"无双段",//       PRO_MANAPOINT     = 4, //
		"爆击等级",//      PRO_CRITICALLV    = 5, //
		"爆机伤害",//      PRO_CRITICALDAMAGE= 6, //
		"命中等级",//      PRO_HITLV         = 7, //
		"攻击力伤害",//     PRO_ATKDELTA      = 8, //
		"火焰伤害",//      PRO_FIREDAMAGE    = 9, //
		"冰霜伤害",//     PRO_ICEDAMAGE     = 10, /
		"毒素伤害",//     PRO_POISONDAMAGE  = 11, /
		"雷电伤害",//    PRO_LIGHTNINGDAMAGE= 12, 
		"击中回复",//    PRO_HITREGEN       = 13, 
		"击杀回复",//    PRO_KILLREGEN      = 14, 
		"生命窃取",//    PRO_LIFESTEAK      = 15, 
		"战斗回复",//    PRO_RECOVERY       = 16, 
		"真实伤害",//    PRO_TRUEDAMAGE     = 17, 
		"闪避等级",//    PRO_DODGELV        = 18, 
		"韧性等级",//    PRO_TENACITYLV     = 19, 
		"火焰抗性",//    PRO_FIRERESIST     = 20, 
		"冰霜抗性",//    PRO_ICERESIST      = 21, 
		"毒素抗性",//    PRO_POISONRESIST   = 22, 
		"闪电抗性",//    PRO_LIGHTNINGRESIST= 23, 
		"真实伤害减免",//  PRO_TRUEDGRESIST   = 24, 
		"红宝石孔",//    PRO_REDHOLE        = 25, 
		"紫色宝石孔",//   PRO_PURPLEHOLE     = 26, 
		"绿色宝石孔",//   PRO_GREENHOLE      = 27, 
		"蓝色宝石孔",//   PRO_BLUEHOLE       = 28, 
		"经验",//      PRO_EXP            = 29, 
		"防御",//      PRO_ARMOR          = 30, 
		"攻击",//      PRO_ATTACK         = 31, 
		"韧性",//      PRO_TENACITY       = 32, 
		"防御",//      PRO_DEFENCE        = 33, 
		
	} ;

	public enum NewHeroProperty
	{
		PRO_LIFEGROWTH_1	 = 0, 	//英雄生命成长率	
		PRO_ATTACKGROWTH_1	 = 1,	//英雄攻击力成长率	
		PRO_ARMORGROWTH_1	 = 2,	//英雄护甲成长率
		PRO_LIFEGROWTH_2	 = 3,	//英雄生命成长率
		PRO_ATTACKGROWTH_2	 = 4,	//英雄攻击力成长率
		PRO_ARMORGROWTH_2	 = 5,	//英雄护甲成长率
		PRO_LIFEGROWTH_3	 = 6,	//英雄生命成长率
		PRO_ATTACKGROWTH_3	 = 7,	//英雄攻击力成长率
		PRO_ARMORGROWTH_3	 = 8,	//英雄护甲成长率
		PRO_LIFEGROWTH_4	 = 9,	//英雄生命成长率
		PRO_ATTACKGROWTH_4	 = 10,	//英雄攻击力成长率
		PRO_ARMORGROWTH_4	 = 11,	//英雄护甲成长率
		PRO_LIFEGROWTH_5	 = 12,	//英雄生命成长率
		PRO_ATTACKGROWTH_5	 = 13,	//英雄攻击力成长率
		PRO_ARMORGROWTH_5	 = 14,	//英雄护甲成长率
		PRO_LIFEPOINT		 = 15,	//初始生命值	
		PRO_ATTACK			 = 16,	//初始攻击力	
		PRO_ARMOR			 = 17,	//初始护甲
		PRO_MANAPOINT		 = 18,	//（无双）单位段长度
		PRO_MANAGETPT		 = 19,	//初始MP自我获取
		PRO_MANAHITPT		 = 20,	//初始MP被击获取	
		PRO_MANARVRPT		 = 21,	//初始MP自动回复
		PRO_MOVEPOWER		 = 22,	//初始气力（能量）上限
		PRO_MOVECD			 = 23,	//初始气力cd	
		PRO_HITLV			 = 24,	//初始命中等级	
		PRO_DODGELV			 = 25,	//初始闪避等级	
		PRO_CRITICALLV		 = 26,	//初始暴击等级
		PRO_CRITICAL_DAMAGE	 = 27,	//初始韧性等级	
		PRO_TENACITYLV		 = 28,	//初始暴击伤害	
		PRO_ATKSPD			 = 29,	//初始攻击速度
		PRO_MOVSPD			 = 30,	//初始移动速度	
		PRO_TRUEDAMAGE		 = 31,	//初始真实伤害	
		PRO_TRUEDGRESIST	 = 32,	//初始真实伤害减免
		PRO_HITREGEN		 = 33,	//初始命中回复	
		PRO_KILLREGEN		 = 34,	//初始击杀回复	
		PRO_LIFESTEAK		 = 35,	//初始生命窃取	
		PRO_RECOVERY		 = 36,	//初始战斗回复
		PRO_ATKRANGE		 = 37,	//怪物用 攻击范围
		PRO_WALKSPD			 = 38,	//初始移动速度	
		PRO_MINATTACK		 = 39,	//最小攻击力	
		PRO_MAXATTACK		 = 40,	//最大攻击力	
		PRO_HARDSTRAIGHT     = 41,  //硬直
		PRO_AIID		     = 42,	//ai模板ID
		PRO_MANAPOINT_NUM	 = 43,	//（无双）总共有几段
		PRO_MP_GETSEL        = 44,  //初始MP自我获取
		PRO_MP_GETHIT 		 = 45,  //初始MP被击获取
		PRO_MP_GETAUTO	     = 46,  //初始MP自动回复
		MAX,
	}

	public static string []NewHeroPropertyName = 
	{
		"生命成长率",
		"攻击力成长率",
		"护甲成长率",
		"生命成长率",
		"攻击力成长率",
		"护甲成长率",
		"生命成长率",
		"攻击力成长率",
		"护甲成长率",
		"生命成长率",
		"攻击力成长率",
		"护甲成长率",
		"生命成长率",
		"攻击力成长率",
		"护甲成长率",
		"生命	",
		"攻击力	",
		"护甲",
		"无双单位段长度",
		"MP回复",
		"MP被击回复",	
		"MP自动回复",
		"气力（能量）上限",
		"气力cd	",
		"命中等级	",
		"闪避等级	",
		"暴击等级",
		"韧性等级	",
		"暴击伤害	",
		"攻击速度",
		"移动速度	",
		"真实伤害	",
		"真实伤害减免",
		"命中回复	",
		"击杀回复	",
		"生命窃取	",
		"战斗回复",
		"怪物用 攻击范围",
		"移动速度	",
		"最小攻击力	",
		"最大攻击力	",
		"硬直",
		"ai模板ID",
		"无双总共有几段",
	} ;

	public enum UnitState
	{
		State_IngoreDefense = 100,		//忽略防御
		State_ReflectDamage,			//反伤
		State_Silent,					//沉默
		State_Shackles,					//束缚
		State_ImmuneAllDamage ,			//免疫所有伤害
		State_Vertigo,					//眩晕
		State_DoubleDamage,				//双倍伤害
		State_DoubleManaPoint,			//无双翻倍
		State_UpDamage,					//被攻击的伤害提升
		State_Charm,					//魅惑
		State_SkillDamageUp,			//技能伤害提升
		State_AllDamageUp,				//整体伤害提升
		State_DelSkillCd,				//减技能cd
		State_AtackCombosOne,			//普通攻击一次,额外会再攻击一次
		State_HardStraight,				//硬直
		State_CriticalCertain,			//必然暴击
		State_AddAttackByHp,			//添加攻击力，增加的数值与当前血量相关
		State_ShieldBoom,				//护盾爆
		State_CumulativeThreeAtk,		//每第3次攻击造成大量伤害
		State_ReflectDamageAddHp,		//反伤+AddHP
		State_SkillNotUseMp,			//use skill not use mp
	}
	
	public enum EquipmentTpye  
	{
		E_WEAPON = 1,//武器
		E_BODY = 2,  //胸甲
		E_LEG  = 3,  //护腿
		E_HAND = 4,  //手套
		E_BOOT = 5,  //长靴
		E_CLOTHES = 6,//时装
		E_MAX,
	}

	public enum BagType
	{
		B_NORMAL    = 0,//
		B_EQUIPMENT = 1,//装备
		B_MATERIAL  = 2,//材料
		B_POTION    = 3,//药水
		B_DIAMOND   = 4,//宝石
	}

	public enum EquipStateType
	{
		EQUIP_ONDRESS,      //当前装备的
		EQUIP_INBAG,        //背包里的
        EQUIP_LOWGRADE,     //低档区分(全部)
        EQUIP_HIGHTGRADE,   //高档区分(全部)
        EQUIP_ALLGRADE,     //低高档区分（混合）
        EQUIP_LEFT,         //左边显示
        EQUIP_RIGHT,        //右边显示
        EQUIP_CENTER        //居中显示
	}

	public enum EquipNeedRoleType
	{
		E_KNIFE = 1,       //刀类——刀客
		E_TWOKNIFE = 2,    //双刀——刺客
		E_LONGKNIFE = 3,   //长柄利器类长斧长刀——猛士
		E_LONGWEAPON = 4,  //长柄类长矛长枪——力士
		E_LONGDISTANCE = 5,//远程类——射手
		E_MAGE = 6,        //法师类——谋士
	}

	public enum HeroCountry
	{
		ROLE_NORMAL = 0,//全部
		ROLE_WEI = 1,   //魏
		ROLE_SHU = 2,   //蜀
		ROLE_WU  = 3,   //吴
		ROLE_QUN = 4,   //群
		ROLE_JIN = 5,   //晋
	}

	public enum EquipQuality
	{
		Q_NORMAL     = 1,//普通
		Q_EXCELLENCE = 2,//优秀
		Q_EXCELLENT  = 3,//精良
		Q_EPIC       = 4,//史诗
		Q_STORY      = 5,//传说
		Q_IMMORTAL   = 6,//不朽
		Q_ARTIFACT   = 7,//神器
		Q_GOD        = 8,//逆天
	}

	public enum EquipmentChange
	{
		E_PUTON = 1,
		E_PUTOFF = 2
	}

	public enum TaskType
	{
		T_ONECE     = 1,//一次性任务
		T_EVERTYDAY = 2,//每日任务
	}

	public enum TaskTargetType
	{
		T_DGBREAKER = 1,  //完成指定副本
		T_HEROGOT   = 2,  //获得指定英雄
		T_KILLER    = 3,  //杀死指定数量的怪物
		T_LOOTER    = 4,  //进行指定数量的抽卡
		T_OLBATTLELV= 5,  //完成指定的势力死斗关卡
		T_GARDCOUNT = 6,  //完成守城的次无数
		T_DUELIST   = 7,  //进行指定数量的竞技
		T_GUILDCOUNT= 8,  //加入指定数量的公会
		T_GUILDACT  = 9,  //进行指定数量的工会活动
		T_ROBBER    = 10,  //抢夺指定数量矿藏
		T_FASTROBBER= 11,  //进行指定数量的夺宝
		T_LOGIN     = 12,  //登陆指定数量
	}

	public enum TaskAwardType
	{
		T_A_EXP,         //战队经验 
		T_A_EQUIPMENT,   //装备
		T_A_MATERIAL,    //材料
		T_A_MEDICINE,    //药水
		T_A_DIAMOND,     //宝石
		T_A_HERO,        //英雄
		T_A_HERO_DEBRIS, //英雄碎片类
		T_A_GOLD,        //金币
		T_A_YUANBAO,     //元宝
		T_A_MONEYTYPE1,  //类型货币1
		T_A_MONEYTYPE2,  //类型货币2
		T_A_MONEYTYPE3,  //类型货币3
		T_A_MONEYTYPE4,  //类型货币4
	}

	public enum FightResultType
	{
		FIGHT_SUCCESS = 0,  //战斗胜利
		FIGHT_FAILED = 1,   //战斗失败
	}

	//连击等级
	public enum BomboLevel
	{
		BOMBO_D = 1,
		BOMBO_C = 2,
		BOMBO_B = 3,
		BOMBO_A = 4,
		BOMBO_S = 5,
		BOMBO_SS = 6,
	}

	//< 技能效果类型
	public enum SkillType
	{
		SKILL_TYPE_ATK = 1,
		SKILL_TYPE_ADD_HP = 2,
		SKILL_TYPE_BUFF = 3,
	}

	public enum SkillPosObjectType
	{
		SKILL_POS_SELF = 1,
		SKILL_POS_TARGET = 2,
	}

	//< 技能对象类型
	public enum SkillObject
	{
		SKILL_OBJ_MINE = 0,
		SKILL_OBJ_FRIEND = 1,
		SKILL_OBJ_ENEMY = 2,
		SKILL_OBJ_PET = 3,
	}

	//< 技能释放类型
	public enum SkillActionType
	{
		SKILL_ACT_NORMAL = 0,
		SKILL_ACT_JUMP   = 1,
		SKILL_ACT_WHEEL  = 2,
		SKILL_ACT_TELEPORT = 3,
	}

	//< 对象类型
	public enum UnitType
	{
		UNIT_TYPE_NONE = 0,
		UNIT_TYPE_PLAYER = 1,
		UNIT_TYPE_MONSTER = 2,
		UNIT_TYPE_ENEMY_HERO = 3,
		UNIT_TYPE_BOSS = 4,
		UNIT_TYPE_DOOR = 5,
	}

	public enum ReconnectProcessType
	{
		RE_NEED,     //需要进行重连
		RE_EXIT,     //需要退出游戏
		RE_SENDMSG,  //重连成功发送验证消息
		RE_CONNECT,  //需要立即进行重连操作
	}

	//< 成就类型
	public enum AchievementType
	{
		ACHIEVE_GROW = 1,	//成长
		ACHIEVE_RECHARGE,	//充值
		ACHIEVE_BATTLE,		//战斗
		ACHIEVE_RANK,		//排行
		ACHIEVE_HOLIDY,		//节日
		ACHIEVE_STORY		//事迹
	}

}                      
