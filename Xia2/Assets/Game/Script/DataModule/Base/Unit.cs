using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// State parameters.
/// </summary>
//[System.Serializable]
//public class StateParams
//{
//    public int value1;
//    public int value2;
//    public int value3;
//    public int value4;
//}
using BehaviorDesigner.Runtime;

public class Unit : MonoBehaviour
{

    /// <summary>
    /// 移动 和 攻击的目标
    /// </summary>
    public Transform target;    				 //目标物体
    public Vector3 originPos = new Vector3();  //出生点 
    public string target_tag = "Player";      //目标得标记，用于查找

    [HideInInspector]
    public Vector3 m_directionVector;	//< 朝向方向
    public Vector3 attackdir;      		  //人朝向怪物

    public Transform m_transform { set; get; } //< 角色Transform
    public Animation m_animation { set; get; }  //< 角色动作
    public Rigidbody m_rigidbody { set; get; }	  //< 角色刚体
    public AudioSource m_audio { set; get; }	  //< 角色声音
    public Renderer m_render { set; get; }	  //< 渲染对象
    public GlobalDef.UnitType m_unitType;	  //< 对象类型 
    public Skill m_skillScript { set; get; }

    public bool m_bSkilling { set; get; }	//< 释放技能状态
    public bool m_bHiting { set; get; }	//< 被击状态
    public float m_attackforce;	  //< 击打的力量
    public bool m_downhigh;      //< 击飞
    public bool m_down;      	  //< 击退

    public float m_height;        //所有模型的高度     
    public bool m_isDead { set; get; }
    /// <summary>
    /// 模板ID
    /// </summary>
    public int m_TemplateID { get; set; }

    /// <summary>
    /// 英雄数据的引用
    /// </summary>
    public HeroData m_curHeroData = null;

    public float m_curDamage { set; get; }
    public int m_curDamageType = 0;

    public delegate void DelOnDead(int id);

    /// <summary>
    /// 死亡委托事件
    /// </summary>
    public event DelOnDead deadEvent;

    //重点关注下
    public virtual BufferController GetBufferControl()
    {
        return null;
    }

    /// <summary>
    /// 这个状态是否存在
    /// </summary>
    public bool hasState(int type)
    {
        if (m_curHeroData == null)
            return false;
        return m_curHeroData.hasState(type);
    }
    /// <summary>
    /// 设置状态
    /// </summary>
    public void setState(int type, StateParams param)
    {
        m_curHeroData.setState(type, param);
    }

    /// <summary>
    /// 获取状态参数
    /// </summary>
    public StateParams getStateParam(int type)
    {
        return m_curHeroData.getStateParam(type);
    }

    /// <summary>
    /// 删除状态
    /// </summary>
    public void removeState(int type)
    {
        m_curHeroData.removeState(type);
    }

    /// <summary>
    /// 获取模型坐标
    /// </summary>
    public virtual Vector3 GetModPos()
    {
        return Vector3.one;
    }

    public virtual float GetModeHeight()
    {
        return m_height;
    }

    public virtual Vector3 GetRightHandPos()
    {
        return new Vector3(0, 0, 0);
    }

    public virtual Vector3 GetLeftHandPos()
    {
        return new Vector3(0, 0, 0);
    }

    public virtual Transform GetRightHand()
    {
        return null;
    }

    public virtual Transform GetLeftHand()
    {
        return null;
    }

    public virtual void SetHitStat(string name)
    {
        if (m_animation != null)
        {
            m_animation.Stop();
            if (name == "down_high")
            {
                m_transform.Rotate(0, Random.Range(0, 360), 0);
            }
            m_animation.Play(name);
        }
    }

    //< 监测是否是敌方
    public bool CheckIsEnemy(GlobalDef.UnitType atker, GlobalDef.UnitType target)
    {
        if (atker == GlobalDef.UnitType.UNIT_TYPE_PLAYER)
        {
            if (atker == target)
                return false;

            return true;
        }
        else
        {
            if (target > GlobalDef.UnitType.UNIT_TYPE_PLAYER)
                return false;

            return true;
        }
    }

    /// <summary>
    /// 基础属性
    /// </summary>
    public virtual float getBaseProperty(int type)
    {
        if (m_curHeroData == null)
        {
            return 0;
        }

        return m_curHeroData.property.getPro(type);
    }

    /// <summary>
    /// 算完加成属性后的结果值
    /// </summary>
    public virtual float getProperty(int type)
    {
        if (m_curHeroData == null)
        {
            return 0;
        }
        return m_curHeroData.getResPro(type);
    }

    /// <summary>
    /// 设置可变化的属性
    /// </summary>
    public virtual void setProperty(int type, int value)
    {
        if (m_curHeroData == null)
        {
            return;
        }
        m_curHeroData.setResPro(type, value);
        return;
    }

    /// <summary>
    /// 算完加成属性后的结果值
    /// </summary>
    public virtual float getCurProperty(int type)
    {
        if (m_curHeroData == null)
        {
            return 0;
        }
        return m_curHeroData.getCurPro(type);
    }

    /// <summary>
    /// 设置可变化的属性
    /// </summary>
    public virtual void setCurProperty(int type, int value)
    {
        if (m_curHeroData == null)
        {
            return;
        }
        m_curHeroData.setCurPro(type, value);
        return;
    }

    /// <summary>
    /// 添加可变化的属性
    /// </summary>
    public virtual float addCurProperty(int type, int value, int max = -1, int min = 0)
    {
        if (m_curHeroData == null)
        {
            return -1;
        }

        float tmp = getCurProperty(type);
        tmp += value;

        if (tmp < min)
            tmp = min;
        if (max != -1)
        {
            if (tmp > max) tmp = max;
        }
        m_curHeroData.setCurPro(type, tmp);
        return getCurProperty(type);
    }


    public void ProcessSkillHit(float skillId, int hitEffectType, Transform atkCollider)
    {
        SkillItem skill = SkillItem.GetStaticData((int)skillId); //skill obj
        Ef_base ef_base = atkCollider.GetComponent<Ef_base>();
        Unit atker = ef_base.m_user.GetComponent<Unit>();

        switch ((int)skillId)
        {
            case 400203: ProcessSkill400203(skill, atkCollider, atker); return;
            case 400204: ProcessSkill400204(skill, atkCollider, atker); return;
        }

        if (hitEffectType == -1)
        {
            for (int i = 0; i < 5; i++)
            {
                ProcessEffectHit(skill, i, atkCollider);
            }
        }
        else
        {
            ProcessEffectHit(skill, hitEffectType, atkCollider);
        }
    }

    public void ProcessEffectHit(SkillItem skill, int efctIdx, Transform atkCollider)
    {
        GlobalDef.SkillType type = (GlobalDef.SkillType)skill.m_effects[efctIdx].type;
        if (type == 0)
            return;
        int hitMotion = skill.m_effects[efctIdx].RT_effect;// 1.击倒 2.击退 3.击飞
        string hitFx = skill.m_effects[efctIdx].acceptor_effectid;
        float param1 = skill.m_effects[efctIdx].parameter1;
        float param2 = skill.m_effects[efctIdx].parameter2;
        switch (type)
        {
            case GlobalDef.SkillType.SKILL_TYPE_ATK:
                {
                    if (hitFx != "0")
                    {
                        Transform obj = PrefabManager.Instance().GetFx(hitFx, PrefabManager.enEfPathType.EF_SKILL);
                        Transform fx = (Transform)Instantiate(obj, m_transform.position, m_transform.rotation);
                    }
                    //< 伤害计算
                    Transform atker = atkCollider.GetComponent<Ef_base>().m_user;
                    m_curDamage = Unit.CalcAttackDamage(true, atker.GetComponent<Unit>(), this, param1, param2, out m_curDamageType);
                }
                break;
            case GlobalDef.SkillType.SKILL_TYPE_BUFF:
                {
                    if (m_unitType == GlobalDef.UnitType.UNIT_TYPE_PLAYER || m_unitType == GlobalDef.UnitType.UNIT_TYPE_ENEMY_HERO)
                    {
                        int buffID = (int)skill.m_effects[efctIdx].parameter1;
                        string effect = StaticBuff.Instance().getStr(buffID, "effectid");
                        effect = "buff" + "/" + effect;
                        Transform obj = PrefabManager.Instance().GetFx(effect, PrefabManager.enEfPathType.EF_SKILL);
                        if (obj != null)
                        {
                            Transform fx = (Transform)Instantiate(obj, m_transform.position, m_transform.rotation);
                            Ef_base ef = fx.GetComponent<Ef_base>();
                            ef.m_user = m_transform;
                            m_curHeroData.bufferController.AddOneBufferById(buffID, fx, atkCollider);
                        }
                    }
                }
                break;
        }

        switch (hitMotion)
        {
            case 0:
                m_attackforce = 0;
                m_down = false;
                m_downhigh = false;
                break;
            case 1:
                m_attackforce = 10;
                m_down = true;
                break;
            case 2:
                m_down = true;
                m_attackforce = 40;
                break;
            case 3:
                m_downhigh = true;
                break;
        }
    }

    //< 曹操第3个技能处理
    public void ProcessSkill400203(SkillItem skill, Transform atkCollider, Unit atker)
    {
        bool b = atker.hasState((int)GlobalDef.UnitState.State_ReflectDamageAddHp);
        int idx = 0;
        if (b) idx = 1;
        ProcessEffectHit(skill, idx, atkCollider);
    }

    //< 曹操第4个技能处理
    public void ProcessSkill400204(SkillItem skill, Transform atkCollider, Unit atker)
    {
        int idx = 1;
        ProcessEffectHit(skill, idx, atkCollider);
    }

    public virtual string ProcessHit(Transform attackObj)
    {
        CamMove cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CamMove>();
        bool isDoubleDamage = false;
        bool isPvp = false;
        if (LevelData.levelType == 8)
            isPvp = true;

        bool isSkillDamage = false;
        int attack_obj_layer = attackObj.gameObject.layer;
        bool isHardStraight = false;
        Unit script_atker;

        switch (attack_obj_layer)
        {
            case 20: // normal atk
            case 21: // power atk
            case 23: // push atk
                {
                    //< 我普通攻击别人震动
                    if (m_unitType == GlobalDef.UnitType.UNIT_TYPE_PLAYER)
                        cam = null;

                    if (attack_obj_layer == 20)
                    {
                        m_attackforce = 40;
                        if (m_unitType == GlobalDef.UnitType.UNIT_TYPE_MONSTER)
                            m_down = true;
                        if (cam) cam.Hitcam();
                    }
                    else if (attack_obj_layer == 21)
                    {
                        m_attackforce = 30;
                        if (cam) cam.Hitcam2(1);
                        m_downhigh = true;
                    }
                    else if (attack_obj_layer == 23)
                    {
                        m_attackforce = 40;
                        if (m_unitType == GlobalDef.UnitType.UNIT_TYPE_MONSTER)
                            m_down = true;
                        if (cam) cam.Hitcam();
                    }

                    Transform atker = attackObj.GetComponent<Ef_atkBase>().m_attker;
                    script_atker = atker.GetComponent<Unit>();
                    GlobalDef.UnitType unitType = script_atker.m_unitType;

                    //< 友方的话退出
                    if (!CheckIsEnemy(unitType, m_unitType))
                        return "";

                    m_downhigh = attackObj.GetComponent<Ef_atkBase>().m_attackRising;

                    //< 普通攻击招招击飞
                    if (isPvp || m_unitType == GlobalDef.UnitType.UNIT_TYPE_BOSS)
                    {
                        m_attackforce = 0;
                        m_down = false;
                        m_downhigh = true;
                    }

                    //< 伤害计算
                    m_curDamage = Unit.CalcAttackDamage(false, script_atker, this, 0, 0, out m_curDamageType);
                    //< 每第3次攻击造成大量伤害
                    if (script_atker.GetBufferControl() != null)
                        m_curDamage = script_atker.GetBufferControl().CheckTriggerThreeAtkBuff(m_curDamage);

                    addHitEffect();//添加被击特效
                }
                break;
            case 22: // skill atk
                {
                    Transform atker = attackObj.GetComponent<Ef_base>().m_user;
                    if (atker == null)
                        return "";
                    script_atker = atker.GetComponent<Unit>();
                    GlobalDef.UnitType unitType = script_atker.m_unitType;
                    //< 友方的话退出
                    if (!CheckIsEnemy(unitType, m_unitType))
                        return "";
                    float skillID = attackObj.GetComponent<Ef_base>().m_skillId;
                    float hitEffectType = attackObj.GetComponent<Ef_base>().m_param[0];

                    ProcessSkillHit(skillID, (int)hitEffectType, attackObj);
                    isSkillDamage = true;

                } break;
            default:
                return "";
        }

        //< 反伤
        if (hasState((int)GlobalDef.UnitState.State_ReflectDamage))
        {
            StateParams reflectParam = getStateParam((int)GlobalDef.UnitState.State_ReflectDamage);
            float val = reflectParam.fvalue;
            val /= 100;
            float reflectDamag = m_curDamage * val;
            script_atker.OnDamaged((int)reflectDamag, false, 3);

            //< 反伤的同时给自己加血
            if (hasState((int)GlobalDef.UnitState.State_ReflectDamageAddHp))
            {
                StateParams p = getStateParam((int)GlobalDef.UnitState.State_ReflectDamageAddHp);
                //add hp
                OnHp((int)(reflectDamag * p.fvalue / 100));
            }
        }

        //< PVP的时候两方都有硬直判断  Boss的时候只有Boss有硬直计算
        if (isPvp || m_unitType == GlobalDef.UnitType.UNIT_TYPE_BOSS)
        {
            //< 获取是否是硬直状态
            if (hasState((int)GlobalDef.UnitState.State_HardStraight))
            {
                m_attackforce = 0;
                m_downhigh = false;
                m_down = false;
                isHardStraight = true;
            }
        }

        string aniName = "";
        if (m_downhigh)  //击飞
        {
            SetHitStat("down_high");
            aniName = "down_high";
        }

        else if (m_down) // 击倒
        {
            SetHitStat("down");
            aniName = "down";
        }

        if (m_unitType == GlobalDef.UnitType.UNIT_TYPE_PLAYER && m_attackforce == 0 && m_down == false)
        {
            GetComponent<MyPlayer>().m_camScript.ZoomIn(5, 22, 0.2f);
        }

        attackdir = new Vector3();
        //计算方向

        if (attack_obj_layer == 28)
        {
            attackdir = m_transform.position - attackObj.position;
            attackdir.y = 0;
            attackdir = Vector3.Normalize(attackdir);
        }
        else
        {
            float magnitude_behitdir = 0;
            magnitude_behitdir = attackdir.magnitude;
            attackdir = m_transform.position - attackObj.position;
            attackdir.y = 0;
            magnitude_behitdir = attackdir.magnitude;
            if (magnitude_behitdir == 0)
            {
            }
            else if (magnitude_behitdir < 0.08f)
                attackdir = attackdir / magnitude_behitdir * 1.6f;
            else
                attackdir = attackdir / magnitude_behitdir;
        }

        m_rigidbody.AddForce(attackdir * m_attackforce); //击退

        //< 被击伤害提升
        if (hasState((int)GlobalDef.UnitState.State_UpDamage))
        {
            StateParams reflectParam = getStateParam((int)GlobalDef.UnitState.State_UpDamage);
            float val = reflectParam.fvalue;
            val /= 100;
            m_curDamage *= val;
        }


        //< 两次攻击
        if (!isSkillDamage && script_atker.hasState((int)GlobalDef.UnitState.State_AtackCombosOne))
        {
            OnDamaged((int)m_curDamage, isSkillDamage, m_curDamageType);
        }
        OnDamaged((int)m_curDamage, isSkillDamage, m_curDamageType);



        if (m_unitType == GlobalDef.UnitType.UNIT_TYPE_ENEMY_HERO)
        {
            //处理进入被击状态
            if (m_bSkilling)
                return aniName;
        }


        float waitTime = 0;
        if (m_animation != null && m_animation.GetClip(aniName) != null)
        {
            float length = m_animation[aniName].length;
            float speed = m_animation[aniName].speed;
            waitTime = length / speed;

            m_bHiting = true;
            CancelInvoke("cancelHiting");
            Invoke("cancelHiting", waitTime);
        }
        else if (isHardStraight)
        {
            waitTime = 0f;
            m_bHiting = false;
        }
        //		else 
        //		{
        //			waitTime = 0.5f;
        //		}

        if (m_unitType == GlobalDef.UnitType.UNIT_TYPE_MONSTER)
        {
            //bomb effect
            if (target != null)
            {
                MyPlayer player = target.GetComponent<MyPlayer>();
                if (player != null)
                    player.m_ui.addBombNum();
            }
        }
        return aniName;
    }
    public void cancelHiting()
    {
        m_bHiting = false;
    }

    //1暴击率  2闪避率  3命中率
    public virtual void OnDamaged(int damage, bool isSkillDamage, int type)
    {
    }

    public virtual void OnMp(int mp)
    {

    }
    public virtual void OnHp(int hp)
    {

    }

    public virtual SkillItem getCanUseSkill()
    {
        return null;
    }

    //< 攻击力获取
    public virtual float GetAtk() { return 1f; }
    //< 伤害减免
    public virtual float GetReduceAtk() { return 1f; }
    //< 真实伤害
    public virtual float GetRealAttack() { return 1f; }
    //< 真实伤害减免
    public virtual float GetReduceRealAttack() { return 1f; }
    //< 计算爆击
    public virtual float GetCritical() { return 1f; }
    //< 暴击率
    public virtual float GetCritRate() { return 1f; }
    //< 暴击减免
    public virtual float GetCritReduce() { return 1f; }
    //< 命中率
    public virtual float GetHitRate() { return 1f; }
    //< 闪避率
    public virtual float GetDodgeRate() { return 1f; }
    //< 闪避减免
    public virtual float GetDodgeReduce() { return 1f; }

    //< 普通攻击伤害
    static public float AttackDamage(Unit atker, Unit target)
    {
        float targetReduceAtk = target.GetReduceAtk();
        //< 忽略防御
        if (atker.hasState((int)GlobalDef.UnitState.State_IngoreDefense))
        {
            StateParams reflectParam = atker.getStateParam((int)GlobalDef.UnitState.State_IngoreDefense);
            float val = reflectParam.fvalue;
            val /= 100;
            targetReduceAtk = targetReduceAtk * (1 - val);
        }

        float val1 = atker.GetAtk() * (1 - targetReduceAtk) + atker.GetRealAttack() * (1 - target.GetReduceRealAttack());
        return val1;
    }

    //< 普通攻击暴击伤害
    static public float AttackCritDamage(Unit atker, Unit target)
    {
        float targetReduceAtk = target.GetReduceAtk();
        //< 忽略防御
        if (atker.hasState((int)GlobalDef.UnitState.State_IngoreDefense))
        {
            StateParams reflectParam = atker.getStateParam((int)GlobalDef.UnitState.State_IngoreDefense);
            float val = reflectParam.fvalue;
            val /= 100;
            targetReduceAtk = targetReduceAtk * (1 - val);
        }
        float val1 = atker.GetAtk() * (1 - targetReduceAtk) * atker.GetCritical() + atker.GetRealAttack() * (1 - target.GetReduceRealAttack());
        return val1;
    }

    //< 技能伤害
    static public float SkillDamage(Unit atker, Unit target, float parm1, float parm2)
    {
        float targetReduceAtk = target.GetReduceAtk();
        //< 忽略防御
        if (atker.hasState((int)GlobalDef.UnitState.State_IngoreDefense))
        {
            StateParams reflectParam = atker.getStateParam((int)GlobalDef.UnitState.State_IngoreDefense);
            float val = reflectParam.fvalue;
            val /= 100;
            targetReduceAtk = targetReduceAtk * (1 - val);
        }
        float val1 = atker.GetAtk() * (1 - targetReduceAtk) * parm1 / 100 + parm2 + atker.GetRealAttack() * (1 - target.GetReduceRealAttack());
        return val1;
    }

    //< 技能暴击伤害
    static public float SkillCritDamage(Unit atker, Unit target, float parm1, float parm2)
    {
        float targetReduceAtk = target.GetReduceAtk();
        //< 忽略防御
        if (atker.hasState((int)GlobalDef.UnitState.State_IngoreDefense))
        {
            StateParams reflectParam = atker.getStateParam((int)GlobalDef.UnitState.State_IngoreDefense);
            float val = reflectParam.fvalue;
            val /= 100;
            targetReduceAtk = targetReduceAtk * (1 - val);
        }
        float val1 = (atker.GetAtk() * (1 - targetReduceAtk) * parm1 / 100 + parm2) * atker.GetCritical() + atker.GetRealAttack() * (1 - target.GetReduceRealAttack());
        return val1;
    }

    //< 对战暴击率
    static public float FightCriteRate(Unit atker, Unit target)
    {
        float val = atker.GetCritRate() * (1 - target.GetCritReduce());
        return val;
    }

    //< 对战闪避率
    static public float FightDodgeRate(Unit atker, Unit target)
    {
        float val = target.GetDodgeRate() * (1 - atker.GetDodgeReduce());
        return val;
    }

    //< 计算伤害
    static public float CalcAttackDamage(bool skill, Unit atker, Unit target, float parm1, float parm2, out int type)
    {
        float crite_rate = FightCriteRate(atker, target);
        float dodge_rate = FightDodgeRate(atker, target);
        crite_rate *= 10000;
        dodge_rate *= 10000;

        if (crite_rate + dodge_rate > 10000)
        {
            crite_rate = crite_rate * (crite_rate / (crite_rate + dodge_rate));
            dodge_rate = dodge_rate * (dodge_rate / (crite_rate + dodge_rate));
        }
        int r = Random.Range(1, 10000);
        if (r > 0 && r <= crite_rate)
        {
            type = 1; //< 暴击率
        }
        else if (r > crite_rate && r <= dodge_rate)
        {
            type = 2; //< 闪避率
            if (skill) type = 3;
        }
        else
        {
            type = 3; //< 命中率
        }

        float val = 0;
        switch (type)
        {
            case 1: //< 暴击率
                if (skill)
                    val = SkillCritDamage(atker, target, parm1, parm2);
                else
                    val = AttackCritDamage(atker, target);
                break;
            case 2: //< 闪避率
                break;
            case 3: //< 命中率
                if (skill)
                    val = SkillDamage(atker, target, parm1, parm2);
                else
                    val = AttackDamage(atker, target);
                break;
        }
        //		val = 10;
        return val;
    }

    /// <summary>
    /// 获取AI参数数据
    /// </summary>
    public virtual AI_Data getAIData() { return null; }

    /// 获取攻击距离
    public virtual float getAttackDis()
    {
        SkillItem skill = getCanUseSkill();
        if (skill != null)
        {
            return skill.range_R / 100f;
        }

        AI_Data data = getAIData();
        if (data != null)
        {
            return data.walk_back;
        }

        return 0.1f;
    }

    public virtual void Begin(float angle, Vector3 standPos)
    {

    }

    public virtual void StartAI()
    {

    }

    public virtual SkillItem getUseSkillByTemplateID(int temp)
    {
        return null;
    }

    public virtual void addHitEffect()
    {

    }

    //死亡时触发事件
    public void OnDeadEvent()
    {
        if (deadEvent != null) deadEvent(m_TemplateID);
    }
}
