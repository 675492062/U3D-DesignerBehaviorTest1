using UnityEngine;
using System.Collections;
using FSMTestingProject;
using System.Collections.Generic;
using LitJson;
//
//public class AI_FSM 
//{
//	/// <summary>
//	/// state machine
//	/// </summary>
//	public FSM fsm;
//	public bool isRunning = false;
//	/// <summary>
//	/// state names
//	/// </summary>
//	public string []StateName = new string[(int)AI_Define.AI_State.S_MAX];
//	public List<Condition>[]CondList = new List<Condition>[(int)AI_Define.AI_State.S_MAX]; 
//	public AI_FSM()
//	{
//
//	}
//
//	public void initFSM(GameObject AIParent, string fsmName = "")
//	{
//		isRunning = true;
//		//实例化 FSM
//		fsm = new FSM("FSM: " + fsmName);
//		// add some into fsm black board, u can add anythings for every states to calcs
//		fsm.Blackboard.AddData("GameObject", AIParent);
//
//		// 添加状态和条件数据
//		addStateData ();
//
//		//initData
//		for(int i = 0; i < (int)AI_Define.AI_State.S_MAX; i++)
//		{
//			AI_BaseState base_state = (AI_BaseState)fsm.GetState(StateName [i]);
//			if(base_state != null)
//				base_state.initData(fsm);
//		}
//		//设置出生点
//		AI_BaseState state = (AI_BaseState)fsm.GetState (StateName[(int)AI_Define.AI_State.S_RETURN]);
//		if(state != null)
//		{
//			state.bornPos = new Vector3(AIParent.transform.position.x, AIParent.transform.position.y, AIParent.transform.position.z);
//		}
//
//		// 增加参数
//		addParam ();
//		//读取配置  行为树时候需要这么做，状态机暂时不用
//		//readConfig ();
//	
//		// 设置默认状态
//		fsm.AnyState = new AI_AnyState(StateName [(int)AI_Define.AI_State.S_ANY]);
//		fsm.CurState = fsm.GetState(StateName [(int)AI_Define.AI_State.S_BORN]);
//		// 创建每个状态之间的连接
//		createTransition ();		
//	}
//	public void addStateData()
//	{
//		//设置状态名字
//		StateName [(int)AI_Define.AI_State.S_BORN]   = "born";
//		StateName [(int)AI_Define.AI_State.S_ANY]    = "any";
//		StateName [(int)AI_Define.AI_State.S_SEARCH] = "search";
//		StateName [(int)AI_Define.AI_State.S_IDLE]   = "idle";
//		StateName [(int)AI_Define.AI_State.S_WALK]   = "walk";
//		StateName [(int)AI_Define.AI_State.S_WALKBACK]= "walkback";
//		StateName [(int)AI_Define.AI_State.S_RUN]    = "run";
//		StateName [(int)AI_Define.AI_State.S_WAIT_ATTACK]  = "wait_attack";
//		StateName [(int)AI_Define.AI_State.S_PLAYER_NORMAL_ATTACK] = "player_normal_attack";
//		StateName [(int)AI_Define.AI_State.S_MONSTER_SKILL_ATTACK] = "monsterAttack";
//		StateName [(int)AI_Define.AI_State.S_DEAD]         = "dead";
//		StateName [(int)AI_Define.AI_State.S_HIT]          = "hit";
//		StateName [(int)AI_Define.AI_State.S_PLAYER_HIT]   = "player_hit";
//		StateName [(int)AI_Define.AI_State.S_PATROL]       = "patrol";
//		StateName [(int)AI_Define.AI_State.S_RETURN]       = "return";
//		StateName [(int)AI_Define.AI_State.S_SKILL_NORMAL] = "skill_normal";
//		StateName [(int)AI_Define.AI_State.S_SKILL_JUMP]   = "skill_jump";
//		StateName [(int)AI_Define.AI_State.S_SKILL_WHEEL]  = "skill_wheel";
//		StateName [(int)AI_Define.AI_State.S_SKILL_TELEPORT]= "skill_teleport";
//		StateName [(int)AI_Define.AI_State.S_ROLLINGBACK]   = "rolling_back";
//		StateName [(int)AI_Define.AI_State.S_RUN_AWAY]      = "runaway";
//		StateName [(int)AI_Define.AI_State.S_END]   = "END";
//		//addState
//		fsm.AddState (new AI_AnyState     (StateName [(int)AI_Define.AI_State.S_ANY]));
//		fsm.AddState (new AI_Born 		  (StateName [(int)AI_Define.AI_State.S_BORN]));
//		fsm.AddState (new AI_SearchTarget (StateName [(int)AI_Define.AI_State.S_SEARCH]));
//		fsm.AddState (new AI_IdleState    (StateName [(int)AI_Define.AI_State.S_IDLE]));
//		fsm.AddState (new AI_WalkState    (StateName [(int)AI_Define.AI_State.S_WALK]));
//		fsm.AddState (new AI_WalkBackState(StateName [(int)AI_Define.AI_State.S_WALKBACK]));
//		fsm.AddState (new AI_RunState     (StateName [(int)AI_Define.AI_State.S_RUN]));
//		fsm.AddState (new AI_WaitForAttack(StateName [(int)AI_Define.AI_State.S_WAIT_ATTACK]));
//		fsm.AddState (new AI_MonsterSkillAttack  (StateName [(int)AI_Define.AI_State.S_MONSTER_SKILL_ATTACK]));
//		fsm.AddState (new AI_Normal_Hit   		 (StateName [(int)AI_Define.AI_State.S_HIT]));
//		fsm.AddState (new AI_Player_Hit   		 (StateName [(int)AI_Define.AI_State.S_PLAYER_HIT]));
//		fsm.AddState (new AI_MonsterDeadState    (StateName [(int)AI_Define.AI_State.S_DEAD]));
//		fsm.AddState (new AI_Patrol		  (StateName [(int)AI_Define.AI_State.S_PATROL]));
//		fsm.AddState (new AI_Return		  (StateName [(int)AI_Define.AI_State.S_RETURN]));
//		fsm.AddState (new AI_PlayerNormalAtk (StateName [(int)AI_Define.AI_State.S_PLAYER_NORMAL_ATTACK]));
//		fsm.AddState (new AI_SkillNormal  (StateName [(int)AI_Define.AI_State.S_SKILL_NORMAL]));
//		fsm.AddState (new AI_SkillJump    (StateName [(int)AI_Define.AI_State.S_SKILL_JUMP]));
//		fsm.AddState (new AI_SkillWheel   (StateName [(int)AI_Define.AI_State.S_SKILL_WHEEL]));
//		fsm.AddState (new AI_SkillTeleport(StateName [(int)AI_Define.AI_State.S_SKILL_TELEPORT]));
//		fsm.AddState (new AI_RollingBack  (StateName [(int)AI_Define.AI_State.S_ROLLINGBACK]));
//		fsm.AddState (new AI_RunAway      (StateName [(int)AI_Define.AI_State.S_RUN_AWAY]));
//		fsm.AddState (new AI_End          (StateName [(int)AI_Define.AI_State.S_END]));
//		// 条件列表
//		CondList [(int)AI_Define.AI_State.S_ANY] 	      = new List<Condition> () { AI_Define.COND_ANY, 	AI_Define.COND_ALIVE_HP };
//		CondList [(int)AI_Define.AI_State.S_BORN] 	      = new List<Condition> () { AI_Define.COND_BORN,   AI_Define.COND_ALIVE_HP };
//		CondList [(int)AI_Define.AI_State.S_SEARCH] 	  = new List<Condition> () { AI_Define.COND_SEARCH, AI_Define.COND_ALIVE_HP };
//		CondList [(int)AI_Define.AI_State.S_IDLE] 		  = new List<Condition> () { AI_Define.COND_IDLE,   AI_Define.COND_ALIVE_HP };
//		CondList [(int)AI_Define.AI_State.S_WALK] 		  = new List<Condition> () { AI_Define.COND_WALK,   AI_Define.COND_ALIVE_HP };
//		CondList [(int)AI_Define.AI_State.S_WALKBACK] 	  = new List<Condition> () { AI_Define.COND_WALKBACK, AI_Define.COND_ALIVE_HP };
//		CondList [(int)AI_Define.AI_State.S_RUN] 		  = new List<Condition> () { AI_Define.COND_RUN,          AI_Define.COND_ALIVE_HP };
//		CondList [(int)AI_Define.AI_State.S_WAIT_ATTACK]  = new List<Condition> () { AI_Define.COND_WAIT_ATTACK,  AI_Define.COND_ALIVE_HP };
//		CondList [(int)AI_Define.AI_State.S_MONSTER_SKILL_ATTACK] = new List<Condition> () { AI_Define.COND_MONSTER_SKILL_ATTACK,  AI_Define.COND_ALIVE_HP };
//		CondList [(int)AI_Define.AI_State.S_HIT] 		  = new List<Condition> ()  { AI_Define.COND_HIT,   AI_Define.COND_ALIVE_HP };
//		CondList [(int)AI_Define.AI_State.S_PLAYER_HIT]   = new List<Condition> ()  { AI_Define.COND_PLAYER_HIT,   AI_Define.COND_ALIVE_HP };
//		CondList [(int)AI_Define.AI_State.S_DEAD]         = new List<Condition> () { AI_Define.COND_DEAD,   AI_Define.COND_ALIVE_HP };
//		CondList [(int)AI_Define.AI_State.S_PATROL]       = new List<Condition> () { AI_Define.COND_PATROL, AI_Define.COND_ALIVE_HP };
//		CondList [(int)AI_Define.AI_State.S_RETURN]       = new List<Condition> () { AI_Define.COND_RETURN, AI_Define.COND_ALIVE_HP };
//		CondList [(int)AI_Define.AI_State.S_PLAYER_NORMAL_ATTACK]= new List<Condition> () { AI_Define.COND_PLAYER_NORMAL_ATTACK, AI_Define.COND_ALIVE_HP };
//		CondList [(int)AI_Define.AI_State.S_SKILL_NORMAL] = new List<Condition> () { AI_Define.COND_SKILL_NORMAL, AI_Define.COND_ALIVE_HP };
//		CondList [(int)AI_Define.AI_State.S_SKILL_JUMP]   = new List<Condition> () { AI_Define.COND_SKILL_JUMP,   AI_Define.COND_ALIVE_HP };
//		CondList [(int)AI_Define.AI_State.S_SKILL_WHEEL]  = new List<Condition> () { AI_Define.COND_SKILL_WHEEL,  AI_Define.COND_ALIVE_HP };
//		CondList [(int)AI_Define.AI_State.S_SKILL_TELEPORT]= new List<Condition> () { AI_Define.COND_SKILL_TELEPORT, AI_Define.COND_ALIVE_HP };
//		CondList [(int)AI_Define.AI_State.S_ROLLINGBACK]   = new List<Condition> () { AI_Define.COND_ROLLINGBACK, AI_Define.COND_ALIVE_HP };
//		CondList [(int)AI_Define.AI_State.S_RUN_AWAY]      = new List<Condition> () { AI_Define.COND_RUNAWAY, AI_Define.COND_ALIVE_HP };
//		CondList [(int)AI_Define.AI_State.S_END   ]        = new List<Condition> () { AI_Define.COND_END };
//
//	}
//	public void addParam()
//	{
//		/// 增加参数
//		fsm.AddParam(new ParamValue(AI_Define.P_STATE){ Value = 0});   // 目标 
//		fsm.AddParam(new ParamValue(AI_Define.P_HP) { Value = 100 });  // init hp = 100   血量
//		fsm.AddParam (new ParamValue (AI_Define.P_START_ATTACK, ParamType.Float){ Value = 0.2f});
//	}
//	public State getState(int type)
//	{
//		if(type < 0 || type >= StateName.Length)
//		{
//			return null;
//		}
//		return fsm.GetState (StateName[type]);
//	}
//	public State getCurState()
//	{
//		return fsm.CurState;
//	}
//	public void FsmUpdate()
//	{
//		if (!isRunning)
//			return;
//		fsm.Update();
//	}
//	/// <summary>
//	/// 创建每个状态之间的连接
//	/// </summary>
//	public void createTransition()
//	{
//		for(int i = 1; i < (int)AI_Define.AI_State.S_MAX; i++)
//		{
//			State s = fsm.GetState(StateName [i]);
//			if(s != null)
//			{
//				for(int j = 1; j < (int)AI_Define.AI_State.S_MAX; j++)
//				{
//					State sub = fsm.GetState(StateName [j]);
//					if(sub == s || sub == null)
//						continue;
////					Debug.Log("src " + StateName [i] + " dst " + StateName [j]);
//					FSM.TransitionTo(fsm, StateName [i],   StateName [j],  CondList [j]);
//				}
//			}
//		}
//	}
//	public void PrintCurState ()
//	{
//		if (fsm == null)
//			return;
//		int state = fsm.GetParamValue <int>(AI_Define.P_STATE);
//	//	Debug.Log ("cur state: " + fsm.CurState.Name + " value: " + state);
//	}
//	public void readConfig()
//	{
//		string file = "Json/StacitAIConfig";
//		TextAsset textObj =  Resources.Load(file, typeof(TextAsset)) as TextAsset;  
//		JSONNode data = JSON.Parse(textObj.text);
//		Debug.Log ("read fileName = " + file);
//
//		JSONClass obj =  data.AsObject;
//		JSONNode name = obj["name"];
//		string stateName = name.Value;
////		Debug.Log ("state " + stateName);
//		State state = fsm.GetState (stateName);
//		if(state != null)
//		{
//			((AI_BaseState)state).parseData(obj);
//			readNext (state, obj);
//		}
//	}
//	public void readNext(State parent,JSONClass obj)
//	{
//		if (obj ["next"] == null)
//			return;
//		JSONArray arr = obj["next"].AsArray;
//		for(int i = 0; i < arr.Count; i++)
//		{
//			string stateName = arr[i]["name"].Value;
//			if(string.Compare(parent.Name ,stateName) != 0 )
//				((AI_BaseState)parent).addNextState(stateName);
//			State state = fsm.GetState (stateName);
//			if(state != null)
//			{
//				((AI_BaseState)state).parseData(obj);
//				readNext(state, arr[i].AsObject);
//			}
//		}
//	}
//}
