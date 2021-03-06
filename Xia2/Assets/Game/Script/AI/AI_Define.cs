using UnityEngine;
using System.Collections;


using UnityEngine;
using System.Collections;
using FSMTestingProject;

public static class AI_Define 
{

	// 参数部分
//	public const string P_DISTANCE_WALK    		= "walk_distance";   	   //用于判断切换 走路 状态的距离
//	public const string P_DISTANCE_WALK_BACK    = "walkBack_distance";     //用于判断切换 后退 状态的距离
//	public const string P_DISTANCE_RUN    		= "run_distance";   	   //用于判断切换 跑 状态的距离
//	public const string P_DISTANCE_WAIT_ATTACK  = "wait_attack_distance";  //用于判断切换 等待攻击状态 的距离
//	public const string P_DISTANCE_NORMAL_ATTACK= "normal_attack_distance";//用于判断切换 普通攻击 状态的距离
//	public const string P_DISTANCE_SKILL_ATTACK = "skill_attack_distance"; //用于判断切换 技能攻击 状态的距离
	public const string P_START_ATTACK = "start_attack_distance"; //用于判断开始攻击的距离

	public const string P_STATE       = "State";        	  // 状态
	public const string P_HP          = "hp";           	  //血量 用于检测
	public const string P_ATTACK_COLLIDER_OBJ = "attack_collider_obj";    //攻击的碰撞盒物体

	public enum AI_State
	{
		S_ANY,                  //任意状态
		S_BORN,				    //出生状态
		S_SEARCH,				//搜索状态
		S_IDLE,					//待机状态
		S_WALK,					//走路状态
		S_WALKBACK,				//回退状态
		S_RUN,					//跑步状态
		S_WAIT_ATTACK,			//等待攻击状态
		S_PLAYER_NORMAL_ATTACK, //人物普通攻击状态
		S_MONSTER_SKILL_ATTACK,	//怪物攻击状态
		S_DEAD,					//死亡状态
		S_HIT,					//受击状态
		S_PLAYER_HIT,			//人物受击状态
		S_PATROL,               //巡逻状态
		S_RETURN,               //返回出生点
		S_SKILL_NORMAL,         //普通技能
		S_SKILL_JUMP,          //跳跃技能
		S_SKILL_WHEEL,         //旋转技能
		S_SKILL_TELEPORT,      //瞬移技能
		S_ROLLINGBACK,         //翻滚
		S_RUN_AWAY,            //逃跑
		S_END,                 //结束 目标死亡
		S_MAX,					
	}

	public enum AI_ParamType
	{
		NONE = 0,
		DISTANCE_TARGET  = 1,  //距离目标 
		DISTANCE_BORNPOS = 2,  //距离出生点
		Boolean = 3,
		Str = 4,
	}
	public enum AI_EqualType
	{
		None = 0,
		Less = 1,
		LessEquals = 2,
		Equals = 4,
		Greater = 8,
		GreaterEquals = 16,
		NotEquals = 32,
	}

	/// <summary>
	/// 公共的条件参数
	/// </summary>
	public static readonly Condition COND_ANY  		    	   = new Condition(P_STATE, (int)AI_State.S_ANY,           ConditionType.Equals); // 
	public static readonly Condition COND_BORN 			       = new Condition(P_STATE, (int)AI_State.S_BORN, 	       ConditionType.Equals); // 
	public static readonly Condition COND_SEARCH 			   = new Condition(P_STATE, (int)AI_State.S_SEARCH, 	   ConditionType.Equals); // 
	public static readonly Condition COND_IDLE 				   = new Condition(P_STATE, (int)AI_State.S_IDLE, 		   ConditionType.Equals); // 
	public static readonly Condition COND_WALK 				   = new Condition(P_STATE, (int)AI_State.S_WALK, 		   ConditionType.Equals); // 
	public static readonly Condition COND_WALKBACK 			   = new Condition(P_STATE, (int)AI_State.S_WALKBACK,      ConditionType.Equals); // 
	public static readonly Condition COND_RUN  				   = new Condition(P_STATE, (int)AI_State.S_RUN,  		   ConditionType.Equals); // 
	public static readonly Condition COND_WAIT_ATTACK   	   = new Condition(P_STATE, (int)AI_State.S_WAIT_ATTACK,   ConditionType.Equals); // 
	public static readonly Condition COND_PLAYER_NORMAL_ATTACK = new Condition(P_STATE, (int)AI_State.S_PLAYER_NORMAL_ATTACK, ConditionType.Equals);// 
	public static readonly Condition COND_MONSTER_SKILL_ATTACK = new Condition(P_STATE, (int)AI_State.S_MONSTER_SKILL_ATTACK, ConditionType.Equals);//
	public static readonly Condition COND_DEAD          	   = new Condition(P_STATE, (int)AI_State.S_DEAD,          ConditionType.Equals);  //
	public static readonly Condition COND_HIT           	   = new Condition(P_STATE, (int)AI_State.S_HIT,           ConditionType.Equals);  //
	public static readonly Condition COND_PLAYER_HIT           = new Condition(P_STATE, (int)AI_State.S_PLAYER_HIT,    ConditionType.Equals);  //
	public static readonly Condition COND_RETURN     	       = new Condition(P_STATE, (int)AI_State.S_RETURN,        ConditionType.Equals);  //
	public static readonly Condition COND_PATROL           	   = new Condition(P_STATE, (int)AI_State.S_PATROL,        ConditionType.Equals);  //
	public static readonly Condition COND_SKILL_NORMAL         = new Condition(P_STATE, (int)AI_State.S_SKILL_NORMAL,  ConditionType.Equals);  //
	public static readonly Condition COND_SKILL_JUMP           = new Condition(P_STATE, (int)AI_State.S_SKILL_JUMP,    ConditionType.Equals);  //
	public static readonly Condition COND_SKILL_WHEEL          = new Condition(P_STATE, (int)AI_State.S_SKILL_WHEEL,   ConditionType.Equals);  //
	public static readonly Condition COND_SKILL_TELEPORT       = new Condition(P_STATE, (int)AI_State.S_SKILL_TELEPORT,ConditionType.Equals);  //
	public static readonly Condition COND_ROLLINGBACK          = new Condition(P_STATE, (int)AI_State.S_ROLLINGBACK,   ConditionType.Equals);  //
	public static readonly Condition COND_RUNAWAY              = new Condition(P_STATE, (int)AI_State.S_RUN_AWAY,      ConditionType.Equals);  //
	public static readonly Condition COND_END                  = new Condition(P_STATE, (int)AI_State.S_END,           ConditionType.Equals);  //


	public static readonly Condition COND_ALIVE_HP = new Condition(P_HP, 0, ConditionType.Greater);          // 血量大于0
	public static readonly Condition COND_DEAD_HP = new Condition(P_HP, 0, ConditionType.LessEquals);        // 血量小于等于0
}
