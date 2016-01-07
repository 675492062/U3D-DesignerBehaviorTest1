using UnityEngine;
using System.Collections;
using FightMessage;
using BehaviorDesigner.Runtime;


public partial class Player : BasePlayer {

    private static Player mInstance;
    public static Player instance
    {
        get
        {
            if (mInstance == null)
            {
                mInstance = Object.FindObjectOfType(typeof(Player)) as Player;
            }
            return mInstance;
        }
    }

	AnimationState  m_tmpAttack;
	
	float			m_speedFactor = 0;

	AI_Data aiData;
	public int aiState = 0;
	void Awake()
	{
		init ();
		m_isDead = false;
	}
	public override void Begin(float angel,Vector3 standPos)
	{
		ChangeCharacter ();
		transform.position = standPos;
//		string aniName = OnWaitFight (260,Vector3.zero);
		string aniName = OnWaitFight (angel, standPos);
		float length = m_animation [aniName].length;
		float speed  = m_animation [aniName].speed;
		float time = length / speed;

		StartAI ();
	}
	public override void StartAI()
	{
		BehaviorTree ai = GetComponentInChildren<BehaviorTree>();
		ai.EnableBehavior();
	}
	void Start()
	{
	}

    public void externalInit()
    {
        m_unitType = GlobalDef.UnitType.UNIT_TYPE_ENEMY_HERO;
        m_curHeroData = GetFightHeroData(0);
        if (null != m_curHeroData)
        {
            m_TemplateID = m_curHeroData.templateID;
        }
//		m_curHeroData = new HeroData();
        aiData = new AI_Data();
        setTemplateID(m_TemplateID);
        CreateHeros();

		//< pvp场景
		if (LevelData.levelType == 8) {
			m_transform.localScale = m_transform.localScale* 1.25f;
		}
    }

	public void enter()
	{
		Begin (260, Vector3.zero);
	}

	protected override void LoadSource()
	{
		base.LoadSource ();
	}

	public void setTemplateID(int templateID)
	{
		m_TemplateID = templateID;
		if (m_curHeroData == null)
			return;
		m_curHeroData.parseData (m_TemplateID);
		int aiID = (int)getBaseProperty ((int)GlobalDef.NewHeroProperty.PRO_AIID);
		aiData.parseData (aiID);
	}

	void Update()
	{
		if (target != null )
		{
			if(target.GetComponent<Unit> ().m_isDead == true)
				return;
		}
		if (m_isDead == true)
			return;
	}

	/// 获取AI参数数据
	public override AI_Data getAIData()
	{ 
		return aiData; 
	}

	public void setAnimation(string aniName)
	{
		int weaponType = m_curHeroData.heroType;

//		if (weaponType == 1) {
//			aniName += "_blade";
//		} else if (weaponType == 2) {
//			aniName += "_dswords";
//		} else if (weaponType == 3) {
//			aniName += "_axe";		
//		}else if (weaponType == 4) {
//			aniName += "_pike";	
//		}
		if (m_animation != null)
		{
			AnimationClip clip = m_animation.GetClip(aniName);
			if(null != clip)
				m_animation.CrossFade (aniName);
		}
			
	}
	/// 获取一个可使用的技能
	public override SkillItem getCanUseSkill()
	{
		HeroData data = GetCurCharData ();
		return data.skillList.getCanUseSkill();
	}

	public override HeroData GetFightHeroData (int idx)
	{
		HeroData data = MonoInstancePool.getInstance<EnemyHeroManager>().getFightHeroByIdx(idx);
		if(null == data)
		{
			return null;
		}
		int templateID = data.templateID;

		return data;
	}

	public string rollingBack()
	{
		//< 翻滚
		float curEnergy = getCurProperty ((int)GlobalDef.NewHeroProperty.PRO_MOVEPOWER);
		if ((int)curEnergy > 0 )
		{
			float angle = Random.Range(0f,-1f);
			m_directionVector = m_directionVector * angle;
			m_transform.rotation = Quaternion.LookRotation (m_directionVector);
			m_speedFactor = 6.5f;
			m_rigidbody.mass = 2;
			CancelAtk();
			m_animation.Stop();
			m_animation.Play("dodge");
			m_curStat = 53;
			m_rigidbody.AddForce (m_directionVector*220);
			m_atkCollider.enabled = false;
			OnEnergy(-1);
			InvokeRepeating ( "OnReplyEnergy",5,5 );

			return "dodge";
		}
		return "";
	}
	public void OnReplyEnergy()
	{
		OnEnergy (1);
	}

	//	const int MAX_DOTSKILL_TIMES = 2;
//	bool []canDotSkill = {true, true};		  //记录这个区间是否已经闪避过技能
//	int  dotSkillTimes = 0;//闪避过技能次数
	///滚开 躲避技能
	public void calcRollaway(Transform target, int skillID)
	{
		Vector3 curPos = m_transform.position;
		float dis = Vector3.Distance (curPos, target.position);
		float range = StaticSkill.Instance ().getFloat (skillID, "range_R") / 100f;
//		if (range < dis)
//			return;
		//50% 几率
		int rollAway = Random.Range (0, 10000);
		if (rollAway > 5000)
			return;

//		ai.fsm.SetParamValue(AI_Define.P_STATE, AI_Define.AI_State.S_ROLLINGBACK);
//		for(int i = 0; i < MAX_DOTSKILL_TIMES; i++)
//		{
//			if(canDotSkill[i])
//			{
//				canDotSkill[i] = false;
//				ai.fsm.SetParamValue(AI_Define.P_STATE, AI_Define.AI_State.S_ROLLINGBACK);
//				return;
//			}
//		}
				
	}
}
