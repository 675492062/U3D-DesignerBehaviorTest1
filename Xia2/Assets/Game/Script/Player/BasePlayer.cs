using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightMessage;


public class BasePlayer : Unit
{

    public SphereCollider m_atkCollider { set; get; }   //< 攻击范围碰撞体
    protected GameObject m_gameObject;	    	  	  //< 当前object对象
    protected SphereCollider m_hitCollider;	 	  	  //< 被击范围碰撞体
    protected Transform m_bip01;		 	 	  	  //< 玩家骨骼

    //< Atk Fx
    protected Transform m_shadow;			 //< 影子
    protected Transform m_efSwing1;			 //< 普通攻击刀光特效
    protected Transform m_efSwingEx1;		 //< 普通攻击刀光特效
    protected Transform m_efSwing2;			 //< 普通攻击刀光特效
    protected Transform m_efThrust;		 	 //< 普通攻击推的特效
    protected Transform m_screenEffect;		 //< 被击窗口特效
    protected Transform m_efPunch;
    protected Transform m_efPlash;

    protected Transform[] m_aryStepfog = new Transform[4];	//< 脚后面的云 Ary
    protected Transform[] m_aryThrustfog = new Transform[4];	//< 攻击时候的 圆圈云 Ary

    protected Transform m_efAtkMagic1;
    protected Transform m_efAtkMagic2;
    protected Transform m_efAtkMagic3;

    //< Script
    protected Cha_Weapon m_weaponScript; 	 	 //< 武器对象
    protected Ef_swing1 m_swingScript;		 //< 刀光特效脚本
    protected Ef_swing1 m_swingEx1Script;		 //< 刀光特效脚本
    protected Ef_swing1 m_swingScript2;		 //< 刀光特效脚本
    protected Ef_swing1 m_thrustScript;	     //< 红色的冲刺效果

    //protected Spawn 			  m_spawnScript;	 	 //< 怪物生成器脚本
    protected Bullet_punch m_punchScript;
    protected Ef_splash m_splashScript;
    protected Ef_atkMagic m_atkmagicScript1;
    protected Ef_atkMagic m_atkmagicScript2;
    protected Ef_atkMagic m_atkmagicScript3;

    public Hero m_scriptHero { set; get; }
    //public 	  HeroData 		 m_curHeroData;

    protected Dictionary<string, Transform> m_tempHeros = new Dictionary<string, Transform>();
    protected string m_oldHeroName;

    protected bool m_changing = false;				//< 英雄切换英雄状态
    protected bool m_invincible = false;			//< 无敌状态

    [HideInInspector]
    public Vector3 m_curPos;			//< 当前玩家位置			
 
    //	[HideInInspector] public Vector3	m_directionVector;	//< 玩家方向
    public int m_curStat { set; get; }		//< 当前玩家状态		
    public int m_curAttackStat = 0;	    //< 当前攻击状态
    protected int m_weaponTypeFactor;		    //< 当前武器系数
    protected int m_curWeaponType;		    //< 当前武器类型
    public bool m_attackRising { set; get; }  //< 攻击击飞状态

    public Transform m_curTarget;			  //< 当前攻击目标
    protected float m_atkColliderRadius;	  //< 当前攻击碰撞盒中心点
    protected Vector3 m_atkColliderCenter;	  //< 当前攻击碰撞盒半径
    protected int m_curStepFogCount;		  //< 普通攻击脚下面云特效Count
    protected int m_curThrustFogCount;	  //< 推圆圈云的Count
    protected float m_curFogDelay = 0.15f;	  //< 云的 帧数

    protected AudioSource m_audio;
    protected AudioClip[] m_yell = new AudioClip[3];
    protected AudioClip[] m_skillYell = new AudioClip[2];
    public AudioClip m_soundSwing;
    public AudioClip m_soundSkillstart;
    public AudioClip m_boom;

    //	protected FightHeroList 	m_herolist;

    public int m_curSceneType = 0;  // 0 normal 1 pk

    /// 伤害数字
    public HUDText normalHUD;
    public HUDText critHUD;

    public delegate void DelOnHp(float percent);

    /// <summary>
    /// 取英雄HP 百分比事件
    /// </summary>
    public event DelOnHp getHpPercent;

    /// <summary>
    /// 战斗场景控制UI
    /// </summary>
    public UIBattleManager m_ui { get { return UIBattleManager.instance; } }

    void Awake()
    {
    }

    void Start()
    {
    }

    protected virtual void init()
    {
        m_transform = transform;
        m_rigidbody = GetComponent<Rigidbody>();
        m_gameObject = gameObject;
        m_audio = GetComponent<AudioSource>();

        m_hitCollider = GetComponent<SphereCollider>();
        m_atkCollider = m_transform.Find("atk_collider").GetComponent<SphereCollider>();

        LoadSource();

        m_efSwing2.localScale = new Vector3(1.3f, 1.7f, 1.7f);
        m_efThrust.localPosition = new Vector3(0, 0.05f, 0.08f);

        m_swingScript = m_efSwing1.GetComponent<Ef_swing1>();
        m_swingScript.m_attker = m_transform;

        m_swingScript2 = m_efSwing2.GetComponent<Ef_swing1>();
        m_swingScript2.m_attker = m_transform;

        m_swingEx1Script = m_efSwingEx1.GetComponent<Ef_swing1>();
        m_swingEx1Script.m_attker = m_transform;

        m_thrustScript = m_efThrust.GetComponent<Ef_swing1>();
        m_thrustScript.m_attker = m_transform;

        m_punchScript = m_efPunch.GetComponent<Bullet_punch>();
        m_punchScript.m_attker = m_transform;

        m_splashScript = m_efPlash.GetComponent<Ef_splash>();
        m_splashScript.m_attker = m_transform;

        m_skillScript = GetComponent<Skill>();

        m_atkmagicScript1 = m_efAtkMagic1.GetComponent<Ef_atkMagic>();
        m_atkmagicScript1.m_attker = m_transform;

        m_atkmagicScript2 = m_efAtkMagic2.GetComponent<Ef_atkMagic>();
        m_atkmagicScript2.m_attker = m_transform;
        //		m_atkmagicScript3= m_efAtkMagic3.GetComponent<Ef_atkMagic> ();
        //		m_atkmagicScript3.m_attker = m_transform;

        //m_spawnScript = GameObject.FindWithTag ("Respawn").GetComponent<Spawn> ();
    }

    protected virtual void LoadSource()
    {
        //fx
        Transform fx = PrefabManager.Instance().GetFx("shadow", PrefabManager.enEfPathType.EF_OTHER);
        m_shadow = (Transform)Instantiate(fx, m_transform.position, fx.localRotation);
        m_shadow.parent = m_transform;

        fx = PrefabManager.Instance().GetFx("ef_swing", PrefabManager.enEfPathType.EF_ATK);
        m_efSwing1 = (Transform)Instantiate(fx, fx.localPosition, fx.localRotation);
        m_efSwing1.parent = m_transform;

        fx = PrefabManager.Instance().GetFx("ef_swing_ex1", PrefabManager.enEfPathType.EF_ATK);
        m_efSwingEx1 = (Transform)Instantiate(fx, fx.localPosition, fx.localRotation);
        m_efSwingEx1.parent = m_transform;

        fx = PrefabManager.Instance().GetFx("ef_swing1", PrefabManager.enEfPathType.EF_ATK);
        m_efSwing2 = (Transform)Instantiate(fx, fx.localPosition, fx.localRotation);
        m_efSwing2.parent = m_transform;

        fx = PrefabManager.Instance().GetFx("ef_thrust", PrefabManager.enEfPathType.EF_ATK);
        m_efThrust = (Transform)Instantiate(fx, fx.localPosition, m_transform.rotation);
        m_efThrust.parent = m_transform;

        fx = PrefabManager.Instance().GetFx("ef_punch", PrefabManager.enEfPathType.EF_ATK);
        m_efPunch = (Transform)Instantiate(fx, m_transform.position, m_transform.rotation);
        m_efPunch.parent = m_transform;

        fx = PrefabManager.Instance().GetFx("ef_splash", PrefabManager.enEfPathType.EF_ATK);
        m_efPlash = (Transform)Instantiate(fx, m_transform.position, m_transform.rotation);
        //m_efPlash.parent = m_transform;

        fx = PrefabManager.Instance().GetFx("attack_magic_1", PrefabManager.enEfPathType.EF_ATK);
        m_efAtkMagic1 = (Transform)Instantiate(fx, m_transform.position, m_transform.rotation);
        m_efAtkMagic1.parent = m_transform;

        fx = PrefabManager.Instance().GetFx("attack_magic_2", PrefabManager.enEfPathType.EF_ATK);
        m_efAtkMagic2 = (Transform)Instantiate(fx, m_transform.position, m_transform.rotation);
        m_efAtkMagic2.parent = m_transform;

        //		fx = PrefabManager.Instance ().GetFx ( "attack_magic_3",PrefabManager.enEfPathType.EF_ATK );
        //		m_efAtkMagic3  = (Transform) Instantiate (fx, m_transform.position, m_transform.rotation);
        //		m_efAtkMagic3.parent = m_transform;

        for (int i = 0; i < 3; ++i)
        {
            fx = PrefabManager.Instance().GetFx("ef_stepfog", PrefabManager.enEfPathType.EF_ATK);
            m_aryStepfog[i] = (Transform)Instantiate(fx, Vector3.one * 4, transform.root.rotation);
            m_aryStepfog[i].parent = m_transform;

            fx = PrefabManager.Instance().GetFx("ef_thrustfog", PrefabManager.enEfPathType.EF_ATK);
            m_aryThrustfog[i] = (Transform)Instantiate(fx, Vector3.one * 4, fx.localRotation);
            m_aryThrustfog[i].parent = m_transform;
        }

        //only mine
        fx = PrefabManager.Instance().GetFx("screen_effect", PrefabManager.enEfPathType.EF_OTHER);
        m_screenEffect = (Transform)Instantiate(fx, m_transform.position, m_transform.rotation);
        //	m_screenEffect.parent = m_transform;

    }

    public override BufferController GetBufferControl()
    {
        return GetCurCharData().bufferController;
    }

    public override Vector3 GetModPos()
    {
        return m_transform.Find(GetCurCharData().resname).Find("Bip01").position;
    }

    public override Vector3 GetRightHandPos()
    {
        return m_scriptHero.m_rightHand.position;
    }

    public override Vector3 GetLeftHandPos()
    {
        return m_scriptHero.m_leftHand.position;
    }

    public override Transform GetRightHand()
    {
        return m_scriptHero.m_rightHand;
    }

    public override Transform GetLeftHand()
    {
        return m_scriptHero.m_leftHand;
    }

    public HeroData GetCurCharData()
    {
        return m_curHeroData;
    }

    public virtual HeroData GetFightHeroData(int idx)
    {
        return null;
    }

    public void SetHeroSound()
    {
        int whoop_type = GetCurCharData().whoop_type;
        for (int i = 0; i < 3; i++)
        {

            string name = "" + whoop_type + "_whoop_" + (i + 1);
            m_yell[i] = Resources.Load("Sound/" + name) as AudioClip;
        }

        string skill_name = "" + whoop_type + "_skill_" + 1;
        m_skillYell[0] = Resources.Load("Sound/" + skill_name) as AudioClip;
    }

    public virtual void ChangeCharacter()
    {
        for (int i = 0; i < GlobalDef.MAX_HERO; i++)
        {
            HeroData hero = GetFightHeroData(i);

            if (hero == null)
                continue;

            string name = hero.resname;
            if (name == "" || m_transform.Find(name) == null)
                continue;
            if (hero.resname == m_curHeroData.resname)
            {
                m_transform.Find(name).gameObject.SetActive(true);
                m_transform.Find(name).GetComponent<Animation>().Stop();
                m_scriptHero = m_transform.Find(name).GetComponent<Hero>();
            }
            else
                m_transform.Find(name).gameObject.SetActive(false);
        }

        SetHero();

        //< 换人的时候显示特效
        m_curHeroData.bufferController.ShowAllEffect();
    }

    //< 初始化英雄模型
    protected virtual void CreateHeros()
    {
        for (int i = 0; i < GlobalDef.MAX_HERO; i++)
        {
            HeroData heroData = GetFightHeroData(i);
            if (heroData == null)
                continue;
            heroData.refreshProperty();
            heroData.refreshCurPorperty();
            heroData.bufferController.RemoveAllBuffer();
            heroData.bufferController.Init(this);

            //< 设置硬直状态
            heroData.setState((int)GlobalDef.UnitState.State_HardStraight, new StateParams());

            string name = heroData.resname;
            if (string.IsNullOrEmpty(name))
                continue;
            Debug.Log(name);
            Transform obj = PrefabManager.Instance().GetHeroPrefab(name);
            if (obj == null)
                continue;
            Debug.Log("obj " + obj.name + "  m_transform.position" + m_transform.position + " "
                , m_transform);
            Transform hero = (Transform)Instantiate(obj, m_transform.position, m_transform.rotation);
            hero.name = heroData.resname;
            hero.parent = m_transform;

            bool b = hero.GetComponent<Hero>().AddWeaponToHero(heroData);
            if (b == false)
                continue;
            hero.gameObject.SetActive(false);
        }
    }

    //< 设置显示当前英雄模型
    public void SetHero()
    {
        string heroName = GetCurCharData().resname;
        int weaponType = GetCurCharData().heroType;

        m_bip01 = m_transform.Find(heroName).Find("Bip01");
        m_animation = m_transform.Find(heroName).GetComponent<Animation>();

        //get model height
        Mesh mesh = m_transform.Find(heroName).Find("mod").GetComponent<SkinnedMeshRenderer>().sharedMesh;
        Vector3 size = mesh.bounds.size;
        Vector3 scale = m_transform.Find(heroName).lossyScale;
        Vector3 realsize = new Vector3(size.x * scale.x, size.y * scale.y, size.z * scale.z);
        m_height = realsize.z;

        //sharder set
        m_transform.Find(heroName).Find("mod").GetComponent<SkinnedMeshRenderer>().material.shader = Shader.Find("Mobile/VertexLit (Only Directional Lights)");

        //get weapon script
        m_weaponScript = m_scriptHero.m_rightHand.GetComponent<Cha_Weapon>();

        //< shadow follow me
        m_shadow.GetComponent<Shadow>().Pickparent(m_bip01, 1);
        m_shadow.gameObject.SetActive(true);
        m_weaponScript.ReturnBlade();

        SetAnimation(weaponType);

        bool bHaveForce = true;

        //< pvp场景
        if (LevelData.levelType == 8)
        {
            bHaveForce = false;
        }
        switch (weaponType)
        {
            case 1:
                if (bHaveForce)
                    m_atkColliderCenter = new Vector3(0, 0.05f, 0.17f);
                else
                    m_atkColliderCenter = new Vector3(0, 0.05f, 0.10f);

                m_atkColliderRadius = 0.13f;
                m_efSwing1.localScale = new Vector3(1.6f, 2.0f, 2.0f);
                m_weaponTypeFactor = 0;
                m_animation["run"].speed = 0.6f;
                break;

            case 2:
                if (bHaveForce)
                    m_atkColliderCenter = new Vector3(0, 0.05f, 0.16f);
                else
                    m_atkColliderCenter = new Vector3(0, 0.05f, 0.09f);

                m_atkColliderRadius = 0.13f;
                m_weaponTypeFactor = 10;
                m_efSwing1.localScale = new Vector3(1.3f, 1.7f, 1.7f);
                m_animation["run"].speed = 0.6f;
                break;

            case 3:
                if (bHaveForce)
                    m_atkColliderCenter = new Vector3(0, 0.05f, 0.2f);
                else
                    m_atkColliderCenter = new Vector3(0, 0.05f, 0.09f);
                m_atkColliderRadius = 0.15f;
                m_weaponTypeFactor = 30;
                m_efSwing1.localScale = new Vector3(1.6f, 2.0f, 2.0f);
                m_animation["run"].speed = 0.45f;
                break;

            case 4:
                if (bHaveForce)
                    m_atkColliderCenter = new Vector3(0, 0.05f, 0.2f);
                else
                    m_atkColliderCenter = new Vector3(0, 0.05f, 0.09f);
                m_atkColliderRadius = 0.15f;
                m_weaponTypeFactor = 40;
                m_efSwing1.localScale = new Vector3(1.6f, 2.0f, 2.0f);
                m_animation["run"].speed = 0.6f;
                break;

            case 5: //gong
                break;

            case 6: //法师
                if (bHaveForce)
                    m_atkColliderCenter = new Vector3(0, 0.05f, 0.21f);
                else
                    m_atkColliderCenter = new Vector3(0, 0.05f, 0.25f);
                m_atkColliderRadius = 0.27f;
                m_weaponTypeFactor = 60;
                m_animation["run"].speed = 0.6f;
                m_efSwing1.localScale = new Vector3(1.6f, 2.0f, 2.0f);
                break;
        }

        //< get atk collider cender 
        m_atkCollider.center = m_atkColliderCenter;
        m_atkCollider.radius = m_atkColliderRadius;

        m_curAttackStat = m_weaponTypeFactor;
        initAnimation();
        SetHeroSound();

        m_animation.Play("idle");
    }

    //< 设置英雄的动作
    void SetAnimation(int weaponType)
    {
        Animation ani_atk = null, ani_basic = null, ani_skill = null;
        int aniPoolType = GetCurCharData().modelsize;

        switch (aniPoolType)
        {
            case 1:   //m
                {
                    ani_atk = PrefabManager.Instance().GetAnimationPool("m_s_attack").GetComponent<Animation>();
                    ani_basic = PrefabManager.Instance().GetAnimationPool("m_s_basic").GetComponent<Animation>();
                    ani_skill = PrefabManager.Instance().GetAnimationPool("m_s_skill").GetComponent<Animation>();
                } break;
            case 2:   //w
                {
                    ani_atk = PrefabManager.Instance().GetAnimationPool("w_attack").GetComponent<Animation>();
                    ani_basic = PrefabManager.Instance().GetAnimationPool("w_basic").GetComponent<Animation>();
                    ani_skill = PrefabManager.Instance().GetAnimationPool("w_skill").GetComponent<Animation>();
                } break;
            case 3:   //ml
                {
                    ani_atk = PrefabManager.Instance().GetAnimationPool("m_l_attack").GetComponent<Animation>();
                    ani_basic = PrefabManager.Instance().GetAnimationPool("m_l_basic").GetComponent<Animation>();
                    ani_skill = PrefabManager.Instance().GetAnimationPool("m_l_skill").GetComponent<Animation>();
                } break;
        }

        string attack_name = "";

        if (weaponType == 1)
        {
            attack_name = "_blade";
        }
        else if (weaponType == 2)
        {
            attack_name = "_dswords";
        }
        else if (weaponType == 3)
        {
            attack_name = "_axe";
        }
        else if (weaponType == 4)
        {
            attack_name = "_pike";
        }
        else if (weaponType == 6)
        {
            attack_name = "_staff";
        }

        //< attack
        for (int i = 0; i < 5; i++)
        {
            m_animation.AddClip(ani_atk.GetClip(("attack0" + (i + 1).ToString() + attack_name)), ("attack" + (i + 1).ToString()));
        }

        for (int i = 1; i < 5; i++)
        {
            m_animation.AddClip(ani_atk.GetClip(("t0" + (i).ToString()) + attack_name), (i.ToString()) + "t");
        }

        //< basic
        m_animation.AddClip(ani_basic.GetClip("run" + attack_name), "run");
        m_animation.AddClip(ani_basic.GetClip("walk" + attack_name), "walk");
        m_animation.AddClip(ani_basic.GetClip("idle" + attack_name), "idle");
        m_animation.AddClip(ani_basic.GetClip("dodge"), "dodge");

        //< skill
        SkillConfigs configs = GameObject.FindObjectOfType(typeof(SkillConfigs)) as SkillConfigs;

        int len = (int)GlobalDef.MAX_USE_SKILL;//GetCurCharData().skills.Count;

        for (int i = 0; i < len; i++)
        {
            SkillItem skill = GetCurCharData().skillList.getUseSkillByIdx(i);
            if (skill == null)
            {
                Debug.LogError("hero skillID is Error ");
                continue;
            }

            int skillID = skill.templateID;
            Config skill_config = configs.GetConfigByID(skillID);

            if (skill_config == null)
            {
                Debug.LogError("===SkillID = " + skillID);
                continue;
            }

            string aniName = skill_config.m_aniName;

            if (ani_skill.GetClip(aniName))
            {
                m_animation.AddClip(ani_skill.GetClip(aniName), aniName);
                m_animation[aniName].layer = 2;
            }
        }

        m_animation.AddClip(ani_basic.GetClip("dead"), "dead");
        m_animation.AddClip(ani_basic.GetClip("behitdown"), "down");
        m_animation.AddClip(ani_basic.GetClip("behitdown"), "down_high");
        m_animation.AddClip(ani_basic.GetClip("change_in"), "change_in");
        m_animation.AddClip(ani_basic.GetClip("change_out"), "change_out");

        m_animation["attack1"].speed = 0.24f + GetCurCharData().getAttackSpeed();
        m_animation["attack2"].speed = 0.24f + GetCurCharData().getAttackSpeed();
        m_animation["attack3"].speed = 0.24f + GetCurCharData().getAttackSpeed();
        m_animation["attack4"].speed = 0.24f + GetCurCharData().getAttackSpeed();
        m_animation["attack5"].speed = 0.24f + GetCurCharData().getAttackSpeed();

        m_animation["idle"].speed = 0.1f;
        m_animation["walk"].speed = 0.9f;

        m_animation["idle"].layer = 0;
        m_animation["walk"].layer = 0;
        m_animation["run"].layer = 0;

        m_animation["1t"].layer = 1;
        m_animation["2t"].layer = 1;
        m_animation["3t"].layer = 1;
        m_animation["4t"].layer = 1;

        m_animation["attack1"].layer = 1;
        m_animation["attack2"].layer = 1;
        m_animation["attack3"].layer = 1;
        m_animation["attack4"].layer = 1;
        m_animation["attack5"].layer = 1;
    }

    void initAnimation()
    {
        m_animation["dead"].wrapMode = WrapMode.ClampForever;

        m_animation["change_out"].speed = 0.2f;
        m_animation["change_in"].speed = 0.2f;
        m_animation["dodge"].speed = 0.4f;
        m_animation["down"].speed = 0.7f;
        m_animation["dead"].speed = 0.5f;

        //////////////////////////////////////////////////
        m_animation["change_out"].layer = 3;
        m_animation["change_in"].layer = 3;
        m_animation["down"].layer = 3;
        m_animation["dead"].layer = 4;
        m_animation["dodge"].layer = 2;
    }

    public void SwingStart()
    {
        m_audio.PlayOneShot(m_soundSwing);
    }

    public void CancelAtk()
    {
        int weaponType = GetCurCharData().heroType;
        switch (weaponType)
        {
            case 1:
                m_swingScript.SwingOff();
                m_thrustScript.SwingOff();
                break;
            case 2:
                m_swingScript.SwingOff();
                m_swingScript2.SwingOff();
                break;
            case 3:
                m_swingScript.SwingOff();
                m_splashScript.SplashOff();
                m_swingEx1Script.SwingOff();
                break;
            case 4:
                m_thrustScript.SwingOff();
                m_punchScript.PunchOff();
                m_splashScript.SplashOff();
                break;
            //		case 3:
            //			CancelInvoke("Arrow_shoot");
            //			break;
            case 6:
                CancelInvoke("OnMagicShoot1");
                CancelInvoke("OnMagicShoot2");
                CancelInvoke("OnMagicShoot3");
                break;
        }
    }

    public void CreateTempHero(HeroData data, bool isDead)
    {
        string name = data.resname;
        m_tempHeros[name] = null;
        Transform hero = m_transform.Find(GetCurCharData().resname);
        m_tempHeros[name] = (Transform)Instantiate(hero, hero.position, hero.rotation);

        m_tempHeros[name].gameObject.SetActive(true);
        if (isDead)
        {
            m_tempHeros[name].GetComponent<Animation>().Play("dead");
            m_tempHeros[name].GetComponent<Animation>()["dead"].speed = 0.5f;

            //< 死亡状态不需要灯光效果
            m_tempHeros[name].Find("mod").gameObject.layer = 8;
            Hero script_hero = m_tempHeros[name].GetComponent<Hero>();
            script_hero.m_rightHand.Find("wp").gameObject.layer = 8;
            if (script_hero.m_leftHand && script_hero.m_leftHand.Find("wp"))
                script_hero.m_leftHand.Find("wp").gameObject.layer = 8;

        }
        else
        {
            m_tempHeros[name].GetComponent<Animation>().Play("change_out");
            m_tempHeros[name].GetComponent<Animation>()["change_out"].speed = 0.18f;
        }
    }

    //evet
    public virtual void OnHp(int hp)
    {
        float curHp = getCurProperty((int)GlobalDef.NewHeroProperty.PRO_LIFEPOINT);
        float maxHp = getProperty((int)GlobalDef.NewHeroProperty.PRO_LIFEPOINT);
        curHp += hp;
        if (curHp < 0)
        {
            curHp = 0;
        }
        else if (curHp > maxHp)
        {
            curHp = maxHp;
        }

        if (getHpPercent != null)
        {
            float percent = curHp * 1.0f / maxHp;
            getHpPercent(percent);
        }

        setCurProperty((int)GlobalDef.NewHeroProperty.PRO_LIFEPOINT, (int)curHp);
    }

    public virtual void OnMp(int mp)
    {
        float curMp = getCurProperty((int)GlobalDef.NewHeroProperty.PRO_MANAPOINT);
        float maxMp = getProperty((int)GlobalDef.NewHeroProperty.PRO_MANAPOINT);
        curMp += mp;
        if (curMp < 0)
            curMp = 0;
        else if (curMp > maxMp)
            curMp = maxMp;
        setCurProperty((int)GlobalDef.NewHeroProperty.PRO_MANAPOINT, (int)curMp);
    }

    public virtual void OnEnergy(int energy)
    {
        float curEnergy = getCurProperty((int)GlobalDef.NewHeroProperty.PRO_MOVEPOWER);
        float maxEnergy = getProperty((int)GlobalDef.NewHeroProperty.PRO_MOVEPOWER);
        curEnergy += energy;
        if (curEnergy < 0)
            curEnergy = 0;
        else if (curEnergy > maxEnergy)
            curEnergy = maxEnergy;

        setCurProperty((int)GlobalDef.NewHeroProperty.PRO_MOVEPOWER, (int)curEnergy);
    }

    //< 硬直
    public virtual void OnHardStraight(int damage)
    {
        float val = addCurProperty((int)GlobalDef.NewHeroProperty.PRO_HARDSTRAIGHT, damage);
        if (val <= 0)
        {
            if (hasState((int)GlobalDef.UnitState.State_HardStraight))
            {
                removeState((int)GlobalDef.UnitState.State_HardStraight);
            }
        }
        else
        {
            if (!hasState((int)GlobalDef.UnitState.State_HardStraight))
            {
                StateParams p = new StateParams();
                setState((int)GlobalDef.UnitState.State_HardStraight, p);
            }
        }
    }

    public virtual void OnFog(int _kind)
    {
        switch (_kind)
        {
            case 0:
                m_aryStepfog[m_curStepFogCount].gameObject.active = true;
                m_aryStepfog[m_curStepFogCount].position = m_transform.position;
                m_aryStepfog[m_curStepFogCount].rotation = m_transform.rotation;
                m_curStepFogCount = (m_curStepFogCount + 1) % 3;
                break;
            case 1:
                m_aryThrustfog[m_curThrustFogCount].gameObject.active = true;
                m_aryThrustfog[m_curThrustFogCount].position = m_transform.position + m_transform.forward * 0.2f + Vector3.up * 0.15f;
                m_aryThrustfog[m_curThrustFogCount].up = m_transform.forward;
                m_aryThrustfog[m_curThrustFogCount].RotateAround(m_transform.forward, Random.Range(0, 360));
                m_curThrustFogCount = (m_curThrustFogCount + 1) % 3;
                break;
            case 2:
                m_aryThrustfog[m_curThrustFogCount].gameObject.active = true;
                m_aryThrustfog[m_curThrustFogCount].position = m_bip01.position + m_bip01.forward * 0.2f + Vector3.up * 0.15f;
                m_aryThrustfog[m_curThrustFogCount].up = m_bip01.forward;
                m_aryThrustfog[m_curThrustFogCount].RotateAround(m_bip01.forward, Random.Range(0, 360));
                m_curThrustFogCount = (m_curThrustFogCount + 1) % 3;
                break;
        }
    }

    public virtual void OnAttack(Transform target)
    {
    }

    public void OnChangeing()
    {
        m_changing = false;
        CancelInvoke("OnChangeing");
        m_shadow.gameObject.SetActive(true);

        if (m_oldHeroName != "")
            m_tempHeros[m_oldHeroName].gameObject.SetActive(false);
        m_curStat = 1;
    }

    public void OnInvincible()
    {
        m_invincible = false;
        CancelInvoke("OnInvincible");
    }

    //< 新英雄飞进来	
    public IEnumerator OnChangeIn(float angle)
    {
        yield return new WaitForSeconds(0.5f);
        m_transform.gameObject.SetActive(true);
        m_transform.Find(GetCurCharData().resname).gameObject.SetActive(true);
        m_transform.rotation = Quaternion.AngleAxis(angle, new Vector3(0, 1, 0));
        m_animation.Play("change_in");
    }

    //< 换英雄
    public virtual bool OnChangeChar(HeroData data, bool isDead)
    {
        if (m_bSkilling)
            return false;

        if (!m_changing)
        {
            m_changing = true;
            InvokeRepeating("OnChangeing", 0.8f, 0.1f);
        }
        else
        {
            return false;
        }

        CancelInvoke("OnInvincible");
        InvokeRepeating("OnInvincible", 1.5f, 0.1F);
        CancelAtk();
        m_changing = true;
        m_animation.Stop();
        //		m_transform.localScale = Vector3.one;
        m_curStat = 100;
        m_rigidbody.drag = 100;

        //< 换人隐藏所有特效
        m_curHeroData.bufferController.HideAllEffect();

        if (isDead)
        {
            m_oldHeroName = "";
            CreateTempHero(GetCurCharData(), true);
        }
        else
        {
            //m_skillScript.DelAllFx ();
            m_oldHeroName = GetCurCharData().resname;
            CreateTempHero(GetCurCharData(), false);
        }
        m_curHeroData = data;

        ChangeCharacter();

        m_transform.Find(GetCurCharData().resname).gameObject.SetActive(false);
        m_shadow.gameObject.SetActive(false);

        //< pvp场景
        if (LevelData.levelType == 8)
        {
            m_transform.localScale = Vector3.one * 1.25f;
        }
        return true;
    }

    public override float getAttackDis()
    {
        float attack_dis = 0.2f;
        SkillItem skill = getCanUseSkill();
        if (skill != null)
        {
            attack_dis = skill.range_R / 100f;
        }
        else
        {
            AI_Data data = getAIData();
            if (data != null)
            {
                attack_dis = data.walk_back;
            }
        }
        //		Debug.Log ("attack distance: " + attack_dis);
        return attack_dis;
    }

    public override SkillItem getUseSkillByTemplateID(int temp)
    {
        return m_curHeroData.skillList.getUseSkillByTemplateID(temp);
    }

    //< 攻击力获取
    public override float GetAtk()
    {
        if (null == m_curHeroData)
            return 0;

        float min = m_curHeroData.getMinAttack();
        float max = m_curHeroData.getMaxAttack();
        float res = Random.Range(min, max);
        return res;
    }

    //< 伤害减免
    public override float GetReduceAtk()
    {
        if (null == m_curHeroData)
            return 0;
        float res = m_curHeroData.getReduceDamage();
        return res;
    }

    //< 真实伤害
    public override float GetRealAttack()
    {
        if (null == m_curHeroData)
            return 0;
        float res = m_curHeroData.getRealAttack();
        return res;
    }

    //< 真实伤害减免
    public override float GetReduceRealAttack()
    {
        if (null == m_curHeroData)
            return 0;
        float res = m_curHeroData.getReduceRealAttack();
        return res;
    }

    //< 计算爆击
    public override float GetCritical()
    {
        if (null == m_curHeroData)
            return 0;
        float res = m_curHeroData.getCriticalDamage();
        return res;
    }

    //< 暴击率
    public override float GetCritRate()
    {
        float res = m_curHeroData.getCriticalRate();
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
        float res = m_curHeroData.getHitRate();
        return res;
    }

    //< 闪避率
    public override float GetDodgeRate()
    {
        float res = m_curHeroData.getDodgeRate();
        return res;
    }

    //< 闪避减免
    public override float GetDodgeReduce()
    {
        return GetHitRate();
    }

    public override void SetHitStat(string name)
    {
        if (m_bSkilling)
            return;

        base.SetHitStat(name);
        CancelAtk();
    }

}
