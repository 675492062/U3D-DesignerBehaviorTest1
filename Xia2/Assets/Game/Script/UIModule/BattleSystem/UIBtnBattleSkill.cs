/****************************************************************************** 
 * 
 * Maintaince Logs: 
 * 2014-09-25   WP      Initial version.
 * 
 * *****************************************************************************/

using UnityEngine;
using System.Collections;

/// <summary>
/// 战斗中的技能按钮
/// </summary>
public class UIBtnBattleSkill : MonoBehaviour
{
    [SerializeField]
    private UISprite mIcon;
    /// <summary>
    /// cd 专用
    /// </summary>
    [SerializeField]
    private UISprite mCDMask;
    [SerializeField]
    private UISprite mLock;
    /// <summary>
    /// MP 专用
    /// </summary>
    [SerializeField]
    private UISprite mMPMask;

    /// <summary>
    /// 全局等待专用
    /// </summary>
    [SerializeField]
    private UISprite mWaitMask;

    private SkillItem skillData = new SkillItem();

    //private float cdStartTime = 0f;

    private float cdPercent { get { return skillData.curCD * 1.0f / skillData.cd; } }

    private bool isUnlock = false;

    /// <summary>
    /// 公用等待CD时间
    /// </summary>
    private static bool isWaitCD = false;

    private UIBattlePanel manager;

    /// <summary>
    /// 技能槽对应
    /// </summary>
    //private int skillIdx = 0;

    private delegate bool UpdateEvent();

    /// <summary>
    /// 各种判断技能是否可用的委托
    /// </summary>
    private UpdateEvent updateEvent;

    private bool isEnable = false;

    private bool hasMP = false;

    //TODO----------------
    private MyPlayer myPlayer;
    void Start() { myPlayer = ObjectManager.instance.myPlayer; isWaitCD = false; }

    void Update()
    {
        bool isUseSkill = hasMP;
        if (updateEvent != null)
            foreach (UpdateEvent e in updateEvent.GetInvocationList())
            {
                if (!e()) isUseSkill = false;
            }
        if (isWaitCD) isUseSkill = false;

        //TODO  OnCheckFireSkill
        if (myPlayer.OnCheckFireSkill()) mWaitMask.enabled = false;
        else { mWaitMask.enabled = true; isUseSkill = false; }

        isEnable = isUseSkill;
    }

    void OnClick()
    {
        if (isEnable) OnSkill();
        else Debug.Log(" UI Disable------------------------------");
    }

    void OnEnable()
    {
        if (isUnlock)
        {
            updateEvent += HasMP;
            updateEvent += CDEffectEvent;
            manager.waitCDEvent += WaitCDDistance;
            manager.cdFinishEvent += CDDisFinished;
        }
    }

    void OnDisable()
    {
        if (isUnlock)
        {
            manager.waitCDEvent -= WaitCDDistance;
            manager.cdFinishEvent -= CDDisFinished;
        }
    }

    public void Init(UIBattlePanel manager, SkillItem item)
    {
        if (null == item)
        {
            enabled = false;
            mIcon.enabled = false;
            Destroy(this);
            return;
        }
        this.manager = manager;
        this.skillData = item;
        //this.skillIdx = skillData.templateID;
        isUnlock = item.IsUnlock();
        SetLock(!isUnlock);

        if (isUnlock)
        {
            this.enabled = true;
        }

        //初始化CD间隔
        isWaitCD = false;
    }

    public void EnableMPListener()
    {
        updateEvent += HasMP;
    }

    private void SetLock(bool isLock)
    {
        mLock.enabled = isLock;
        isEnable = !isLock;

        //TODO 判断技能是否初始化
        mMPMask.enabled = false;
        mCDMask.fillAmount = 0;
        if (isLock)
        {
            mIcon.enabled = false;
            enabled = false;
        }
        else
        {
            //Debug.Log("is unlock            " + skillData.icon);
            mIcon.spriteName = skillData.icon;
            //todo: 技能是否冷却
            //cdStartTime = -100f;
        }

    }

    /// <summary>
    /// 使用技能
    /// </summary>
    private void OnSkill()
    {
        bool isSkill = manager.OnSkill(skillData.templateID, skillData.consume);
        if (isSkill)
        {
            skillData.resetCDEvent += StartCD;
            manager.WaitForSkill();
        }
        else
        {
            Debug.Log("Char Disable -----------------------");
        }
    }

    /// <summary>
    /// CD 间隔
    /// </summary>
    private void WaitCDDistance()
    {
        //Debug.Log("Global wait skill ------------", gameObject);
        isWaitCD = true;
        if (mWaitMask) mWaitMask.enabled = true;
    }

    private void StartCD()
    {
        //重置带有全局等待事件的技能按钮
        manager.SkillFinished();
        skillData.resetCDEvent -= CDDisFinished;
    }

    /// <summary>
    /// 全局CD 间隔结束回调
    /// </summary>
    private void CDDisFinished()
    {
        updateEvent += CDEffectEvent;

        if (mWaitMask) mWaitMask.enabled = false;
        isWaitCD = false;
    }

    private bool CDEffectEvent()
    {
        bool isCDFinish = false;

        mCDMask.fillAmount = cdPercent;

        if (cdPercent <= 0)
        {
            //Debug.Log("-----------cd finish");
            isCDFinish = true;
            updateEvent -= CDEffectEvent;
        }
        return isCDFinish;
    }

    /// <summary>
    /// 每帧更新事件
    /// </summary>
    private bool HasMP()
    {
        //MP 足够为 true TODO
        if (skillData.hero == null)
        {
            return false;
        }

        bool hasMP = skillData.hero.getCurPro((int)GlobalDef.NewHeroProperty.PRO_MANAPOINT) >= skillData.consume;
        if (hasMP)
        {
            // MP的罩
            mMPMask.enabled = false;
            this.hasMP = true;
            //Debug.Log("----------------has mp", gameObject);
        }
        else
        {
            // 去掉MP的罩
            mMPMask.enabled = true;
            this.hasMP = false;
            //Debug.Log("-------------not mp", gameObject);
        }
        updateEvent -= HasMP;
        return hasMP;
    }
}