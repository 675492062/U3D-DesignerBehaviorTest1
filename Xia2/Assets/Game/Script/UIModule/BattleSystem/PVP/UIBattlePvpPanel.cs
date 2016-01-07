using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// PVP 战斗面板 管理器
/// 
/// Maintaince Logs: 
/// 2014-11-26  WP      Initial version.
/// 2014-11-27  WP      Added switch rival char and set hp + energy + HardStraight
/// </summary>
public class UIBattlePvpPanel : UIBattlePanel
{
    /// <summary>
    /// 对方英雄
    /// </summary>
    public BTLHeroInfo[] otherHeros;

    public HeroData curRivalData;

    public static PVPBattleData pvpRocardData;

    protected BTLCurHero curRivalHero { get { return otherHeros[0] as BTLCurHero; } }

    public override void InitUI()
    {
        base.InitUI();

        for (int i = 0; i < GlobalDef.MAX_HERO; i++)
        {
            HeroData data = MonoInstancePool.getInstance<EnemyHeroManager>().getFightHeroByIdx(i);
            if (i == 0) curRivalData = data;
            RefreshEnemyAide(i, data);
        }
    }

    public void SwitchRivalChar(HeroData data)
    {
        //Debug.Log("-------------swithc Rival hero guid is " + data.guid);
        //HeroData tempData = curRivalData;
        //if (tempData == null)
        //{
        //    Debug.Log("Fuck ---------------------");
        //}
        otherHeros[0].Refresh(data);

        //切换副将
        for (int i = 1; i < otherHeros.Length; i++)
        {
            if (otherHeros[i].IsHero(data))
            {
                otherHeros[i].Refresh(curRivalData);
                //Debug.Log("-------------swithc cur Rival hero guid is " + curRivalData.guid);
            }
        }
        //-----------------------
        curRivalData = data;
    }

    private void RefreshEnemyAide(int heroIndex, HeroData data)
    {
        if (heroIndex < otherHeros.Length && heroIndex >= 0)
        {
            otherHeros[heroIndex].Refresh(data);

            //Debug.Log("data t id is:" + data.guid + " hp " + data.getPercentByHP() + "  name " + data.name);

        }
    }

    public void SetRivalHP() { curRivalHero.SetHP(); }

    public void SetRivalEnergy() { curRivalHero.SetEnergy(); }

    public void SetRivalHardStraight() { curRivalHero.SetHardStraight(); }

    public void SetRivalMP() { curRivalHero.SetMP(); }
}

/// <summary>
/// 会用于结束后期显示
/// </summary>
public class PVPBattleData
{
    public int playerCurRank;
    public int playerUp;

    public int rivalCurRank;
    public int rivalDown;

    public string rivalName;

    public PVPBattleData(int playerCurRank, int playerUp, int rivalCurRank, int rivalDown, string rivalName)
    {
        this.playerCurRank = playerCurRank;
        this.playerUp = playerUp;
        this.rivalCurRank = rivalCurRank;
        this.rivalDown = rivalDown;
        this.rivalName = rivalName;
    }
}