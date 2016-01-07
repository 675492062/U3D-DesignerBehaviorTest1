using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 普通关卡的UI控制面板
/// 
/// Maintaince Logs: 
/// 2014-11-26   WP      Initial version.
/// </summary>
public class UIBattlePvePanel : UIBattlePanel
{

    /// <summary>
    /// 战斗历史数据，用于战斗结束后更新用
    /// </summary>
    public List<BattleStartHeroData> historyDatas = new List<BattleStartHeroData>();
    public BattleStartPlayerData hisPlayerData;

    public Transform LevelUPeffect;			//人物升级特效

    /// <summary>
    /// key 连击特效
    /// </summary>
    public BomboEffect bombEffect;

    public override void InitUI()
    {
        base.InitUI();

        FightHeroList heroList = MonoInstancePool.getInstance<HeroManager>().fightHeroList;
        List<HeroData> heros = heroList.getHeros();

        for (int i = 0; i < heros.Count; i++)
        {
            if (i == 0)
            { }
            else
            {
                //记录历史数据 英雄
                historyDatas.Add(new BattleStartHeroData(heros[i]));
            }
        }
        //记录历史数据 玩家
        UserData d = MonoInstancePool.getInstance<UserData>();
        hisPlayerData = new BattleStartPlayerData(d.exp, d.level);
    }

    #region Buttons event

    //暂停事件
    public void BtnPause()
    {
        //暂停事件
        Time.timeScale = 0;
    }

    public void BtnContinue()
    {
        Time.timeScale = 1;
    }

    public void BtnRestart()
    {
        UIPVEFinishPanel.SendFightEndEvent(false, null);
        //SceneCtrl.ToGame();
        UIPVEFinishPanel.SendEnterFight();
    }

    public void BtnExit()
    {
        UIPVEFinishPanel.SendFightEndEvent(false, null);
        GlobalDef.mainSceneState = GlobalDef.UIState.UI_CAPTER_WINDOW;
        SceneCtrl.ToMenu();

        //test code
        //MonoInstancePool.getInstance<SendFightMsgHander>().SendFightEndReq(true, new List<FightMessage.Killer>(), new List<FightMessage.Skada>(), 1, new List<int>());

    }

    #endregion

    public void AddBombNum()
    {
        if (!bombEffect.gameObject.activeSelf) bombEffect.gameObject.SetActive(true);
        bombEffect.addBomboNum();
    }

    /// <summary>
    /// 升级动画
    /// </summary>
    public void AddLevelUPEffect()
    {
        Transform obj2 = Instantiate(LevelUPeffect, Vector3.zero, Quaternion.identity) as Transform;
        obj2.parent = ((UIBattleManager)FindObjectOfType(typeof(UIBattleManager))).gameObject.transform;
        obj2.localScale = new Vector3(1, 1, 1);
        obj2.gameObject.SetActive(true);
        obj2.gameObject.AddComponent<ChangeRenderQueue>();
    }

}

public struct BattleStartHeroData
{
    public int level;
    public int exp;

    public HeroData heroData;

    public BattleStartHeroData(HeroData data)
    {
        this.heroData = data;
        level = data.level;
        exp = data.exp;
    }

    public int expByNextLv { get { return StaticLevel.Instance().getInt(level, "exp"); } }

    private int ExpByNextLv(int level)
    {
        return StaticLevel.Instance().getInt(level, "exp");
    }

    /// <summary>
    /// 取历史中的EXP百分比
    /// </summary>
    /// <returns></returns>
    public float GetPercentByEXP()
    {
        //TODO:最后一级的设定
        int max = expByNextLv;
        return exp * 1.0f / max;
    }

    /// <summary>
    /// 取EXP增加量
    /// </summary>
    /// <returns></returns>
    public int GetEXPInct()
    {
        int i = level; int inct = 0;
        if (i == heroData.level)
        {
            inct = heroData.exp - exp;
        }
        else
        {
            inct = ExpByNextLv(i) - exp;
            i++;
            for (; i < heroData.level; i++)
            {
                inct += ExpByNextLv(i);
            }
            inct += heroData.exp;
        }
        return inct;
    }
}

public struct BattleStartPlayerData
{
    public int exp;
    public int level;

    public int expByNextLv { get { return StaticLead_level.Instance().getInt(level, "exp"); } }

    public BattleStartPlayerData(int exp, int level)
    {
        this.exp = exp;
        this.level = level;
    }

    /// <summary>
    /// 取历史中的EXP百分比
    /// </summary>
    /// <returns></returns>
    public float GetPercentByEXP()
    {
        //TODO:最后一级的设定
        int max = expByNextLv;
        return exp * 1.0f / max;
    }
}