using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightMessage;


public partial class MyPlayer : BasePlayer
{

    private static MyPlayer mInstance;
    public static MyPlayer instance
    {
        get
        {
            if (mInstance == null)
            {
                mInstance = Object.FindObjectOfType(typeof(MyPlayer)) as MyPlayer;
            }
            return mInstance;
        }
    }

    Collider m_mapCollider;
    public CamMove m_camScript { set; get; }
    public Vector3 currentTouchPos;
    RaycastHit m_mouseCastHit;
    Ray m_ray;

    bool m_keyDown;
    Vector3 m_lastTouchPos;
    bool m_bSaveTouchPos;
    float m_dubbleClick = 1;

    AnimationState m_tmpAttack;

    float m_speedFactor = 0;

    SkillStateMgr m_skillStateMgr;

    internal float m_limit_x_l = 2.65f;
    internal float m_limit_x_r = 2.65f;
    internal float m_limit_y_b = -2.6f;
    internal float m_limit_y_f = 2.5f;

    public bool m_bIsStoryCaming { set; get; }

    bool btest = true;

    public float angle = 300;

    void Awake()
    {
        MonoInstancePool.getInstance<HeroManager>().addTempHero();
        Time.timeScale = 1;
        m_camScript = Camera.main.GetComponent<CamMove>();
        m_mapCollider = GameObject.Find("ground").GetComponent<Collider>();
        init();
        m_isDead = false;
    }

    void Start()
    {
        m_bIsStoryCaming = true;
        m_unitType = GlobalDef.UnitType.UNIT_TYPE_PLAYER;
        m_skillStateMgr = new SkillStateMgr(this);

    }

    void LoadSource()
    {
        base.LoadSource();
    }

    public void ExternalInit()
    {
        m_curHeroData = GetFightHeroData(0);
        if (m_curHeroData == null)
        {
            Debug.LogError("set m_curHeroData Error! ");
        }
        m_ui.InitUI();
        CreateHeros();


        if (LevelData.levelType == 8)
        {
            m_transform.localScale = m_transform.localScale * 1.25f;
        }
    }

    public void SetCharUI()
    {
        m_ui.SwitchChar(GetCurCharData());
    }

    public override void ChangeCharacter()
    {
        base.ChangeCharacter();
        SetCharUI();
        InvokeRepeating("OnReplyMp", 1, 1);
    }

    public void FindItem(Transform _finditem)
    {

    }

    public void GetItem(int itemidx, int level, DropItem item)
    {
        Transform obj = null;
        Transform fx = null;

        switch (item.type)
        {
            case (int)GlobalDef.ItemType.ITEM_FOOD:
                fx = PrefabManager.Instance().GetFx("ef_other_jiaxue_01", PrefabManager.enEfPathType.EF_OTHER);
                obj = Instantiate(fx, m_transform.position, Quaternion.identity) as Transform;
                OnHp((int)GetCurCharData().getMaxHP() / 10);
                break;

            case (int)GlobalDef.ItemType.ITEM_GOLD:
                fx = PrefabManager.Instance().GetFx("ef_other_jinbi_01", PrefabManager.enEfPathType.EF_OTHER);
                obj = Instantiate(fx, m_transform.position, Quaternion.identity) as Transform;
                break;

            case (int)GlobalDef.ItemType.ITEM_EQUIPMENT:
                fx = PrefabManager.Instance().GetFx("ef_other_xiangzi_01", PrefabManager.enEfPathType.EF_OTHER);
                obj = Instantiate(fx, m_transform.position, Quaternion.identity) as Transform;
                break;

            default:
                return;
        }
        obj.parent = m_transform;
        obj.gameObject.SetActive(true);

        obj.gameObject.AddComponent<AutoDestroyParticle>();

        //item.type;
    }

    public void Skilling()
    {
        m_skillStateMgr.Update();
        return;
    }

    public bool Deading()
    {
        if (m_animation && m_animation.IsPlaying("dead"))
        {
            m_atkCollider.enabled = false;
            m_curStat = 500;
            m_directionVector = Vector3.zero;
            return true;
        }
        return false;
    }

    public bool ChangeCharing()
    {
        return m_changing;
    }

    public bool processKeyDown()
    {
        if (Input.GetKeyDown((KeyCode)'a'))
        {

            StateParams p = new StateParams();
            p.extraValue = new object[1];
            p.extraValue[0] = currentTouchPos;
            setState((int)GlobalDef.UnitState.State_Charm, p);

        }
        else if (Input.GetKeyDown((KeyCode)'s'))
        {
            Begin(angle, Vector3.zero);
            //LevelFlowCtrl.instance.ExternalSuccess();
        }
        else if (Input.GetKeyDown((KeyCode)'f'))
        {
            CancelAtk();
        }
        else if (Input.anyKeyDown)
        {
            m_keyDown = true;
            m_bSaveTouchPos = false;
        }
        else if (Input.anyKey)
        {
            if (getCurProperty((int)GlobalDef.NewHeroProperty.PRO_LIFEPOINT) <= 0)
                return false;

            m_ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (m_mapCollider.Raycast(m_ray, out m_mouseCastHit, 4) && 
                UICamera.hoveredObject == null)
            {
                currentTouchPos = m_mouseCastHit.point;
                if (!m_bSaveTouchPos)
                {
                    m_lastTouchPos = currentTouchPos;
                    m_bSaveTouchPos = true;
                }

                Vector3 tempMovedir = currentTouchPos - m_transform.position;
                tempMovedir[1] = 0;
                float magnitude_temp = tempMovedir.magnitude;
                tempMovedir = tempMovedir / magnitude_temp;

                //< 缈绘粴
                float curEnergy = getCurProperty((int)GlobalDef.NewHeroProperty.PRO_MOVEPOWER);
                //				if (m_dubbleClick<0.3f && (int)curEnergy > 0 )
                if (m_dubbleClick < 0.3f)
                {
                    if (m_curStat < 50 && m_curStat >= 0)
                    {
                        if (Vector3.Distance(currentTouchPos, m_lastTouchPos) < 0.1f)
                        {
                            CancelInvoke("OnReplyEnergy");
                            m_directionVector = tempMovedir;
                            m_transform.rotation = Quaternion.LookRotation(m_directionVector);
                            m_speedFactor = 6.5f;
                            m_rigidbody.mass = 2;
                            CancelAtk();
                            m_animation.Stop();
                            m_animation.Play("dodge");
                            m_curStat = 53;
                            m_rigidbody.AddForce(m_directionVector * 220);
                            m_atkCollider.enabled = false;
                            OnEnergy(-1);
                            InvokeRepeating("OnReplyEnergy", 5, 5);
                        }
                    }
                }

                if (magnitude_temp > 0.08f)
                {
                    m_directionVector = tempMovedir;
                    m_speedFactor = 6.5f;
                }
            }
            m_keyDown = true;
        }
        else if (m_keyDown)
        {
            m_dubbleClick = 0;
            m_keyDown = false;
        }

        m_dubbleClick += 2 * Time.deltaTime;
        return true;
    }

    public bool Attacking()
    {
        if (m_animation.IsPlaying("attack1"))
        {
            m_curStat = 11;
        }
        else if (m_animation.IsPlaying("attack2"))
        {
            m_curStat = 13;
        }
        else if (m_animation.IsPlaying("attack3"))
        {
            m_curStat = 11;
            m_curFogDelay = 0;
        }
        else if (m_animation.IsPlaying("attack4"))
        {
            int weaponType = GetCurCharData().heroType;
            if (weaponType != 6)
            {
                if (m_curFogDelay >= 0.15f)
                {
                    OnFog(1);
                    m_curFogDelay = 0;
                }
                else
                {
                    m_curFogDelay += Time.deltaTime;
                }
            }
            //GetCurCharData().property.movspd = 0.48f;
            m_curStat = 12;
        }
        else if (m_animation.IsPlaying("attack5"))
        {
            m_curStat = 13;
        }
        else
        {
            return false;
        }
        return true;
    }

    public bool Hiting()
    {
        if (m_animation.IsPlaying("down_high"))
        {
            return true;
        }
        if (m_animation.IsPlaying("down"))
        {
            return true;
        }
        return false;
    }

    //眩晕状态
    public bool Vertigoing()
    {
        bool b = hasState((int)GlobalDef.UnitState.State_Vertigo);
        if (!b)
            return false;
        if (!m_animation.IsPlaying("idle"))
        {
            m_animation.Stop();
            m_animation.Play("idle");
        }
        return true;
    }

    //魅惑,向敌人靠近
    public bool Charming()
    {
        bool b = hasState((int)GlobalDef.UnitState.State_Charm);
        if (!b)
            return false;
        StateParams param = getStateParam((int)GlobalDef.UnitState.State_Charm);
        Vector3 targetPos = (Vector3)param.extraValue[0];

        if (!m_animation.IsPlaying("walk"))
        {
            m_animation.CrossFade("walk");
            m_animation["walk"].speed = 0.35f;
        }

        float moveSpeed = 0.2f;
        Vector3 dir = targetPos - m_curPos;
        dir.y = 0;
        dir.Normalize();

        float len = Vector3.Distance(targetPos, m_curPos);
        if (len >= 0.1f)
        {
            m_curPos += dir * Time.deltaTime * moveSpeed;
            Quaternion rotate = Quaternion.LookRotation(dir);
            m_transform.rotation = Quaternion.Lerp(m_transform.rotation, rotate, Time.deltaTime * 8.0f);
            m_transform.position = m_curPos;
        }
        return true;
    }

    public void Walking()
    {
        if (m_animation.IsPlaying("run"))
        {
            //GetCurCharData().property.movspd = 0.48f;
            if (m_curStat == 2)
            {
            }
            else if (m_curStat != 3)
            {
                m_rigidbody.mass = 2;
                m_rigidbody.drag = 5;
                m_curStat = 2;

                m_atkCollider.radius = m_atkColliderRadius;
                m_atkCollider.center = m_atkColliderCenter;
                m_atkCollider.enabled = false;
                m_atkCollider.enabled = true;
            }
        }
        else if (m_animation.IsPlaying("walk"))
        {
            if (m_curStat != 1)
            {
                m_atkCollider.enabled = true;
                m_curStat = 1;
            }
        }
        else if (m_animation.IsPlaying("idle"))
        {
            m_curStat = 0;
        }
    }

    public void Moveing()
    {

        HeroData data = GetCurCharData();
        if (data == null)
        {
            Debug.LogError("have not curHeroData");
            return;
        }

        float moveSpeed = (float)data.getMoveSpeed(); //获得移动速度
        Quaternion rotate;							//角度

        if (!m_animation.isPlaying || m_curStat <= 10 || m_curStat > 200)
        {
            if (m_directionVector == Vector3.zero || m_curStat < 0)
            {
                m_animation.CrossFade("idle");
                //return;
            }
            else
            {
                rotate = Quaternion.LookRotation(m_directionVector);

                if (m_speedFactor > 4.5f)
                {
                    m_speedFactor -= 2.0f * Time.deltaTime;
                    m_animation.CrossFade("run");
                    moveSpeed = 0.48f;
                }
                else if (m_speedFactor > 0.2f)
                {
                    m_speedFactor -= 2.0f * Time.deltaTime;
                    m_animation.CrossFade("walk");
                    m_animation["walk"].speed = m_speedFactor / 7.5f + 0.2f;
                    moveSpeed = m_speedFactor / 12.0f;
                }
                else
                {
                    m_directionVector = Vector3.zero;
                }

                m_curPos += m_directionVector * Time.deltaTime * moveSpeed;
                m_transform.rotation = Quaternion.Lerp(m_transform.rotation, rotate, Time.deltaTime * 8.0f);
                m_transform.position = m_curPos;
            }
        }
        m_curPos[0] = Mathf.Clamp(m_curPos[0], m_limit_x_l, m_limit_x_r);
        m_curPos[2] = Mathf.Clamp(m_curPos[2], m_limit_y_b, m_limit_y_f);
        m_transform.position = m_curPos;
    }

    public bool StoryCaming()
    {
        return m_bIsStoryCaming;
    }


    void Update()
    {
        if (m_bIsStoryCaming)
            return;

        m_curPos = m_transform.position;

        if (StoryCaming())
            return;

        if (Deading())
            return;

        if (Hiting())
            return;

        if (Vertigoing())
            return;

        if (Charming())
            return;

        if (!processKeyDown())
        {
            return;
        }

        if (ChangeCharing())
        {
            return;
        }

        if (m_bSkilling)
            Skilling();

        else if (!Attacking())
        {
            Walking();
        }

        Moveing();
    }

    public override HeroData GetFightHeroData(int idx)
    {
        return MonoInstancePool.getInstance<HeroManager>().getFightHeroByIdx(idx);
    }
}
