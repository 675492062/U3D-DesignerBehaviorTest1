using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 战斗面板的UI
/// 
/// Maintaince Logs: 
/// 2014-11-26  WP      Initial version.
/// 2014-11-28  WP      Added finished panel
/// </summary>
public class UIBattlePanel : MonoBehaviour
{
    /// <summary>
    /// 当前出战英雄
    /// </summary>
    public BTLHeroInfo[] uiHeros;

    public UIGrid grdSkill;

    protected MyPlayer m_player { get { return ObjectManager.instance.myPlayer; } }

    protected HeroData curHero;

    protected BTLCurHero curUIHero { get { return uiHeros[0] as BTLCurHero; } }

    /// <summary>
    /// 战斗技能按钮Prefab
    /// </summary>
    public UIBtnBattleSkill prbBtnSkill { get { return UIBattleManager.instance.prbBtnSkill; } }

    public UIBattleFinishPanel pnlFinish;

    /// <summary>
    /// 计时器
    /// </summary>
    public UILabel labTimer;

    /// <summary>
    /// key 为英雄的 m_idx
    /// </summary>
    protected Dictionary<int, List<UIBtnBattleSkill>> skillDir = new Dictionary<int, List<UIBtnBattleSkill>>();

    public delegate void CDEvent();

    /// <summary>
    /// 全局等待CD事件
    /// </summary>
    public event CDEvent waitCDEvent;

    public event CDEvent cdFinishEvent;

    public virtual void InitUI()
    {
        FightHeroList heroList = MonoInstancePool.getInstance<HeroManager>().fightHeroList;
        Dictionary<int, long> dict = heroList.getFightHeroDict();

        curHero = heroList.getHeroData(0);
        SetSkillButton(heroList);

        curUIHero.SetSkills(skillDir[curHero.templateID]);

        curUIHero.Refresh(curHero);

        List<HeroData> heros = heroList.getHeros();

        SetAideCount(heros.Count);

        for (int i = 0; i < heros.Count; i++)
        {
            if (i == 0)
            { }
            else
            {
                RefreshAide(i, heros[i]);
            }
        }
    }

    /// <summary>
    /// 切换英雄
    /// </summary>
    /// <param name="ch">需要切换的英雄</param>
    public void SwitchChar(HeroData data)
    {
        curUIHero.Refresh(data);
        //Debug.Log(" SetSkills =======================" + data.templateID);
        //curUIHero.SetSkills(skillDir[data.templateID]);
        ChangeCharSkills(data.templateID);

        //切换副将
        for (int i = 1; i < uiHeros.Length; i++)
        {
            if (uiHeros[i].IsHero(data))
            {
                uiHeros[i].Refresh(curHero);
                Debug.Log("Switch --------------");
            }
        }
        //-----------------------

        //ChangeCharSkills(data.templateID);
        curHero = data;
    }

    /// <summary>
    /// 切换技能
    /// </summary>
    /// <param name="index">英雄ID</param>
    public virtual void ChangeCharSkills(int index)
    {
        //设置英雄的技能
        curUIHero.SetSkills(skillDir[index]);

        //设置UI显示与检测
        foreach (int idx in skillDir.Keys)
        {
            bool isCharSkill = idx == index;
            foreach (UIBtnBattleSkill btn in skillDir[idx])
            {
                if (btn == null || btn.gameObject == null)
                    continue;

                btn.gameObject.SetActive(isCharSkill);
                if (isCharSkill)
                {
                    btn.EnableMPListener();
                }
            }
        }

        grdSkill.repositionNow = true;
    }

    /// <summary>
    /// 放技能
    /// </summary>
    /// <param name="idx">0 , 1 ,2</param>
    public bool OnSkill(int skillID, int mp)
    {
        // m_player has OnSkill function , but it's empty

        bool onSkill = m_player.OnSkill(skillID);
        if (onSkill)
        {
            m_player.OnMp(-mp);

            foreach (UIBtnBattleSkill btn in curUIHero.GetSkills())
            {
                btn.EnableMPListener();
            }
        }
        return onSkill;
    }


    /// <summary>
    /// 设置各英雄技能
    /// </summary>
    /// <param name="charDatas">英雄</param>
    private void SetSkillButton(FightHeroList heroList)
    {
        UIBtnBattleSkill btnSkill;
        //Debug.Log("-------------" + heroList.getFightHeroDict().Count);
        for (int i = 0; i < heroList.getFightHeroDict().Count; i++)
        {
            List<UIBtnBattleSkill> listSkill = new List<UIBtnBattleSkill>();

            HeroData hData = heroList.getHeroData(i);
            if (hData == null)
                continue;

            bool isActive = i == 0;
            for (int j = 0; j < GlobalDef.MAX_USE_SKILL; j++)
            {
                //SkillItem skill = hData.skillList.getUseSkillByIdx(j);

                //Debug.Log(charDatas[i].m_skillIds[j]);
                btnSkill = KMTools.AddChild<UIBtnBattleSkill>(grdSkill.gameObject, prbBtnSkill, true);

                // set active：
                btnSkill.gameObject.SetActive(isActive);

                btnSkill.Init(this, hData.skillList.getUseSkillByIdx(j));
                listSkill.Add(btnSkill);
            }

            //Debug.Log(" -----tempid" + hData.templateID);
            skillDir.Add(hData.templateID, listSkill);
            //Debug.Log(" add =======================" + heroList.getHeroData(i).templateID);
        }
        //Debug.Log("set skill complete : and count is " + skillDir.Count);
        grdSkill.repositionNow = true;

        prbBtnSkill.gameObject.SetActive(false);
		if(curHero != null)
	        ChangeCharSkills(curHero.templateID);
    }

    //设置副将个数
    private void SetAideCount(int count)
    {
        for (int i = 1; i < uiHeros.Length; i++)
        {
            if (i < count)
                uiHeros[i].gameObject.SetActive(true);
            else
                uiHeros[i].gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// 设置副将UI显示
    /// </summary>
    /// <param name="heroIndex"></param>
    /// <param name="data"></param>

    private void RefreshAide(int heroIndex, HeroData data)
    {
        if (heroIndex < uiHeros.Length && heroIndex >= 0)
        {
            uiHeros[heroIndex].Refresh(data);
        }
    }

    public void SetHP() { curUIHero.SetHP(); }
    public void SetMP() { curUIHero.SetMP(); }
    public void SetEXP() { curUIHero.SetEXP(); }
    public void SetEnergy() { curUIHero.SetEnergy(); }
    public void SetHardStraight() { curUIHero.SetHardStraight(); }

    public void ShowGameEnd(bool isWin) { pnlFinish.ShowPanel(isWin); }

    /// <summary>
    /// 技能点击等待事件
    /// </summary>
    public void WaitForSkill() { if (waitCDEvent != null) waitCDEvent(); }

    public void SkillFinished() { if (cdFinishEvent != null) cdFinishEvent(); }

    /// <summary>
    /// 计时事件
    /// </summary>
    /// <param name="time"></param>
    public void EventTimer(float time) 
    {
        if (labTimer)
        {
            if (labTimer.enabled == false) labTimer.enabled = true;
            
            //FloorToInt  为最大整数
            System.TimeSpan timeSpan = new System.TimeSpan(0, 0, Mathf.CeilToInt(time));
            labTimer.text = timeSpan.ToString().Substring(3);
        }
    }
}
