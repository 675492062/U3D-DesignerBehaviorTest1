using UnityEngine;
using System.Collections;
using FightMessage;
using System.Collections.Generic;
using FSMTestingProject;

public class Enemy : Unit 
{
	/// 播放技能所需要的
	public SkillState   skillData;
	public SkillManager skillList;
	/// 伤害数字
	HUDText normalHUD;
	HUDText critHUD;
	/// 物品掉落列表
	public List<DropItem> m_dropItems;
	public AI_Data aiData = new AI_Data ();
	/// 方向剪头和血条
	public Transform direction_arrow;
	Transform clone_arrow;
	Transform hpbar;
	
//	bool life = false;
	bool showme = false;
	bool lastmon = false;
	int shadow_index = 0;
	float hpbar_height = 0;
	/// 属性列表
	public EnemyProperty property = new EnemyProperty ();
	/// 属性部分
	short hp;
	short level;
	short maxhp;
	short power;
	float haveExp;
	short block;
	short sizekind;
	float runspeed;
	float backspeed;
	float firerange;
	float moving_atk;
	float restrictArea = 100;
	monster enemy;

	/// 声音 摄影机 特效所需要的
	SoundEf_slash script_sound;
	CamMove script_cam;
	Hp_bar script_hpbar;
	Monster_efs script_monEf;


	void Awake()
	{
		m_transform = transform;
		m_animation = GetComponent<Animation>();
		m_audio = GetComponent<AudioSource>();
		m_rigidbody = GetComponent<Rigidbody>();
		script_monEf = Monster_efs.instance;
		enemy = GameObject.FindWithTag("Respawn").GetComponent<DB_Monster>().enemy[1];

		script_sound = GameObject.FindWithTag("sound").GetComponent<SoundEf_slash>();
		script_cam = Camera.main.GetComponent<CamMove>();
		//
		gameObject.AddComponent<Skill> ();
		m_skillScript = gameObject.GetComponent<Skill> ();
		skillData = new SkillState("enemy_normal_skill");
		skillData.Init (this);
		skillList = new SkillManager ();
		m_isDead = false;
	}
	public void setTemplateID(int templateID)
	{
		m_TemplateID = templateID;
		property.parseData (m_TemplateID);
		int aiID = (int)getBaseProperty ((int)GlobalDef.NewHeroProperty.PRO_AIID);
		aiData.parseData (aiID);

		// add skill
		for(int i = 0; i < property.skillid.Length; i++)
		{
			if(property.skillid[i] <= 0)
				continue;

			skillList.Add(new SkillItem(property.skillid[i]));
			if(i < GlobalDef.MAX_USE_SKILL)
			{
				skillList.useSkills[i] = i;
			}
		}
		// 设置属性
		setProperty ();
	}
	void Start () 
	{
		m_unitType = GlobalDef.UnitType.UNIT_TYPE_MONSTER;

		SetLevel(0,0 ,false,100);
		CountDown ();

		// 设置动作数据
		setAnimation ();
		// 设置属性
		setProperty ();
		//渲染组件
		m_render = m_transform.GetChild(1).GetComponent<Renderer>();
		//设置血条
		hpbar = script_monEf.SetHpbar();
		hpbar.position = m_transform.position;
		hpbar_height = 0.1f+sizekind*0.007f;
		script_hpbar = hpbar.GetComponent<Hp_bar>();
		script_hpbar.Damaged(maxhp,hp,m_transform,hpbar_height,0);
		//创建影子
		shadow_index = script_monEf.CreatShadow(m_transform.GetChild(0),1);

		//get model height
		Mesh mesh = m_transform.Find ("mon").GetComponent<SkinnedMeshRenderer> ().sharedMesh;
		Vector3 size = mesh.bounds.size;
		Vector3 scale = m_transform.lossyScale;
		Vector3 realsize = new Vector3 (size.x * scale.x, size.y * scale.y, size.z * scale.z);
		m_height = realsize.z;

//		setTemplateID (200001);
	}
	public void setOriginPos(Vector3 origin)
	{
        transform.position = origin;

		originPos.x = origin.x;
		originPos.y = origin.y;
		originPos.z = origin.z;
	}

	/// <summary>
	/// 获取模型位置
	/// </summary>
	public override Vector3 GetModPos()
	{
		return m_transform.Find ("mon").position;
	}
	/// <summary>
	/// 设置属性
	/// </summary>
	public void setProperty()
	{
		//level = 	enemy._level ;
		maxhp += (short)getBaseProperty((int)GlobalDef.NewHeroProperty.PRO_LIFEPOINT);//enemy._maxhp;
		power += 5;  //enemy._power;
		haveExp += enemy._haveExp;
		block += enemy._block;
		sizekind = enemy._sizekind;
		runspeed = 0.35f;//enemy._runspeed;
		backspeed = 0.3f;//enemy._backspeed;
		firerange = enemy._firerange;
		moving_atk = enemy._moving_atk;

//		property.OutPut ();
//		maxhp = (short)property.getResPro((int)GlobalDef.NewHeroProperty.PRO_LIFEPOINT);
//		power = (short)property.getResPro((int)GlobalDef.NewHeroProperty.PRO_ATTACK);
//		haveExp = property.exp;
//		block = (short)property.getResPro((int)GlobalDef.NewHeroProperty.PRO_ARMOR);
//		int sp = property.getResPro ((int)GlobalDef.NewHeroProperty.PRO_MOVSPD);
//		runspeed = (float)property.getResPro((int)GlobalDef.NewHeroProperty.PRO_MOVSPD) / 100f;
		hp = maxhp;
	}

	/// <summary>
	/// 设置动作数据
	/// </summary>
	void setAnimation()
	{
		m_animation["move"].speed = 0.3f;//enemy._speed_move;
		m_animation["down"].speed = 0.24f;
		m_animation["down_high"].speed =  0.28f;
		m_animation["m_attack1"].speed = 0.3f;//enemy._speed_m_attack1;
		m_animation["m_attack1_i"].speed = 0.3f;//enemy._speed_m_attack1_i;
		
		m_animation["idle"].speed = 0.25f;//enemy._speed_idle  - 0.05f;
		
		/////////////////////////////////////////////
		m_animation["down"].layer = 2;
		m_animation["down_high"].layer = 2;
		m_animation["move"].layer = 0;
		m_animation["m_attack1"].layer = 1;
		m_animation["m_attack1_i"].layer = 1;
		
		m_animation["idle"].layer = 0;
	}


	/// <summary>
	/// 被击部分
	/// </summary>
	void OnTriggerEnter(Collider other)
	{
		if(m_isDead)
		{
			return;
		}
		
		string aniName = ProcessHit ( other.transform );


	}
	public override void addHitEffect()
	{
        if(m_unitType == GlobalDef.UnitType.UNIT_TYPE_MONSTER)
		    script_monEf.CreatHitEffect_Only(m_transform.position,attackdir);
	}
	public void SetLevel(short _level ,int _playkind , bool _issummon , float _restrictArea)
	{
		level = (short) (_level+1);
		restrictArea = _restrictArea;     //限制区域
		//restrictArea_sqrt = Mathf.Sqrt (restrictArea-0.05f);
		//maxhp += (short)(level *10);//4
		maxhp +=(short)( 0.1445f * level *level + 6.3873f * level -5) ;//最大血
		power += (short)(0.0058f * level*level +1.008f * level -5);    //攻击 
		//power += (short)(level);
		block += (short)(level*0.4f);   // 防御
		hp = maxhp;
		
		haveExp += level *0.1f;
	}
	
	public void SetDropItems()
	{
		FightManager fightMng =  MonoInstancePool.getInstance<FightManager> ();
		fightMng.getItem ();
		if( fightMng.temp_items.Count <= 0 )
			return;
		m_dropItems = new List<DropItem> (fightMng.temp_items);
	}

	// 生成箭头
	public void CountDown()
	{
		if (m_isDead && target != null)
		{
			clone_arrow = (Transform)Instantiate (direction_arrow, target.position , Quaternion.identity);
			showme = true;
			lastmon = true;
		}
	}

	void Update () 
	{
		if(skillList != null)
			skillList.Update ();
		//失去目标
		if(target == null)
		{
			return;
		}
		//死亡
		if (!m_isDead ) return;
		
		if (lastmon )
		{
			if (showme)
			{
				Vector3 arrowTargetVector = Vector3.Normalize(m_transform.position - target.transform.position);
				if (arrowTargetVector!= Vector3.zero)
					clone_arrow.rotation = Quaternion.LookRotation (arrowTargetVector);
				arrowTargetVector = target.position + Vector3.up*0.02f +arrowTargetVector *0.3f;
				clone_arrow.position = Vector3.Lerp (clone_arrow.position, arrowTargetVector, Time.deltaTime *4);
//				clone_arrow.renderer.enabled = true;
			}
		}
	}
	/// <summary>
	/// 显示被击数字
	/// </summary>
	public override void OnDamaged( int num ,bool isSkillDamage,int type )
	{
		Vector3 pos = transform.position;
		pos.y += .16f;
		//生成被击数字
		if (normalHUD == null || critHUD == null)
		{
			GameObject go = KMTools.AddGameObj(gameObject);
			go.transform.parent = transform;
			go.transform.position = pos;
			normalHUD = HUDRoot.AddNormalHarmNFollow(go.transform);
			critHUD = HUDRoot.AddCritHarmNFollow(go.transform);
		}
		
		if (normalHUD != null && critHUD != null)
		{
			if( type == 1 )
				critHUD.Add(num.ToString(), pos);
			else if( type == 3 )
				normalHUD.Add(num.ToString()); 
		}
		// 计算伤害
		BurnDamage (num);
	}
	/// <summary>
	/// 计算伤害
	/// </summary>
	public virtual void BurnDamage(int damage)
	{
		if (damage<1)
			damage = 1;
		//更新血条
		hp -= (short)damage;
		if(script_hpbar != null)
			script_hpbar.Damaged(maxhp,hp,m_transform,hpbar_height,-1);

		if (hp <=0)
		{
			m_isDead = true;
			if(script_hpbar != null)
				script_hpbar.FreeSelect();
		}
//		Dead(0);
	}
	public bool isDead()
	{
		return m_isDead;
	}
	//设置属性
	public override void setProperty(int type, int value)
	{
		property.setResPro (type, value);
	}
	//获取属性
	public override float getProperty(int type)
	{
		return property.getResPro (type);
	}
	//获取基础属性
	public override float  getBaseProperty(int type)
	{
		return property.getBasePro(type);
	}
	/// 获取AI参数数据
	public override AI_Data getAIData()
	{ 
		return aiData; 
	}
	/// 获取一个可使用的技能
	public override SkillItem getCanUseSkill()
	{
		return skillList.getCanUseSkill();
	}

//	public override AI_FSM getAI()
//	{
//		return ai;
//	}
	public override SkillItem getUseSkillByTemplateID(int temp)
	{
		return skillList.getUseSkillByTemplateID (temp);
	}
	//< 攻击力获取
	public override float GetAtk()
	{ 
		float min = property.getResPro ((int)GlobalDef.NewHeroProperty.PRO_MINATTACK);
		float max = property.getResPro ((int)GlobalDef.NewHeroProperty.PRO_MAXATTACK);
		float res = Random.Range (min, max);
		return res; 
	}
	//< 伤害减免
	public override float GetReduceAtk()
	{ 
		float res = property.getResPro ((int)GlobalDef.NewHeroProperty.PRO_ARMOR);
		return res; 
	}
	//< 真实伤害
	public override float GetRealAttack()
	{ 
		float res = property.getResPro ((int)GlobalDef.NewHeroProperty.PRO_TRUEDAMAGE);
		return res; 
	}
	//< 真实伤害减免
	public override float GetReduceRealAttack()
	{ 
		float res = property.getResPro ((int)GlobalDef.NewHeroProperty.PRO_TRUEDGRESIST);
		return res;
	}
	//< 计算爆击
	public override float GetCritical()
	{ 
		float normal_atk = GetAtk ();
		float percent = property.getResPro ((int)GlobalDef.NewHeroProperty.PRO_TRUEDGRESIST);
		return normal_atk * percent;
	}
	//< 暴击率
	public override float GetCritRate()
	{ 
		float res = property.getResPro ((int)GlobalDef.NewHeroProperty.PRO_CRITICALLV);
		return res; 
	}
	//< 暴击减免
	public override float GetCritReduce()
	{ 
		return 0f;
	}
	//< 命中率
	public override float GetHitRate()
	{ 
		float res = property.getResPro ((int)GlobalDef.NewHeroProperty.PRO_HITLV);
		return res;  
	}
	//< 闪避率
	public override float GetDodgeRate()
	{ 
		float res = property.getResPro ((int)GlobalDef.NewHeroProperty.PRO_DODGELV);
		return res;  
	}
	//< 闪避减免
	public override float GetDodgeReduce()
	{ 
		return GetDodgeRate(); 
	}
}
