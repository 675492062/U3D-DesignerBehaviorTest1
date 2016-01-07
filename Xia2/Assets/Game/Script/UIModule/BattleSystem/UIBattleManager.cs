/****************************************************************************** 
 * 
 * Maintaince Logs: 
 * 2014-??-??   ??      Initial version.
 * 2014-09-26   WP      添加技能相关的逻辑。修改一些方法的访问限制
 * 
 * *****************************************************************************/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightMessage;

public class UIBattleManager : MonoBehaviour
{
    public UIBattlePvePanel pnlPVE;
    public UIBattlePvpPanel pnlPVP;

    protected UIBattlePanel curPanel;

    public GameObject goFightStart;

    /// <summary>
    /// UI 限制用户输入对象
    /// </summary>
    public GameObject parclose;

    /// <summary>
    /// 战斗技能按钮Prefab
    /// </summary>
    public UIBtnBattleSkill prbBtnSkill;

    /// <summary>
    /// 指格标
    /// </summary>
    public UISign uiSign;

    private MyPlayer m_player { get { return ObjectManager.instance.myPlayer; } }

    private static UIBattleManager mInstance;
    public static UIBattleManager instance
    {
        get
        {
            if (mInstance == null)
            {
                mInstance = GameObject.FindObjectOfType(typeof(UIBattleManager)) as UIBattleManager;
            }
            return mInstance;
        }
    }

    public void InitUI()
    {
        bool isPvp = LevelData.levelType == 8;
        if (!isPvp)
        {
            pnlPVE.InitUI();
            curPanel = pnlPVE;
        }
        else
        {
            pnlPVP.InitUI();
            curPanel = pnlPVP;
        }

        pnlPVP.gameObject.SetActive(isPvp);
        pnlPVE.gameObject.SetActive(!isPvp);
    }

    /// <summary>
    /// 切换英雄
    /// </summary>
    /// <param name="ch">需要切换的英雄</param>
    public void SwitchChar(HeroData data)
    {
        curPanel.SwitchChar(data);
    }

    public void SetHP() { curPanel.SetHP(); }
    public void SetMP() { curPanel.SetMP(); }
    public void SetEXP() { curPanel.SetEXP(); }
    public void SetEnergy() { curPanel.SetEnergy(); }
    public void SetHardStraight() { curPanel.SetHardStraight(); }

    public void FightBegin()
    {
        parclose.SetActive(false);
        EffectByFight();
    }

    /// <summary>
    /// 战斗开始效果
    /// </summary>
    private void EffectByFight()
    {
        goFightStart.SetActive(true);
    }

    public void SwitchRivalChar(HeroData data) { if (curPanel == pnlPVP) pnlPVP.SwitchRivalChar(data); }
    public void SetRivalHP() { if (curPanel == pnlPVP) pnlPVP.SetRivalHP(); }
    public void SetRivalMP() { if (curPanel == pnlPVP) pnlPVP.SetRivalMP(); }
    public void SetRivalEnergy() { if (curPanel == pnlPVP) pnlPVP.SetRivalEnergy(); }
    public void SetRivalHardStraight() { if (curPanel == pnlPVP) pnlPVP.SetRivalHardStraight(); }

    public void addBombNum() { if (curPanel == pnlPVE) pnlPVE.AddBombNum(); }

    /// <summary>
    /// 升级动画
    /// </summary>
    public void addLevelUPEffect() { if (curPanel == pnlPVE) pnlPVE.AddLevelUPEffect(); }

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

    public void ShowGameEnd(bool isWin) { curPanel.ShowGameEnd(isWin); }

    public void ShowSign(Transform target) { uiSign.Show(target); }

    public void HideSign() { uiSign.Hide(); }

    /// <summary>
    /// 关卡计时注册
    /// </summary>
    public void LoginCountUpTimer() { LevelFlowCtrl.instance.EventCountUpTimer += curPanel.EventTimer; }

    public void LoginCountDownTimer() { LevelFlowCtrl.instance.EventCountDownTimer += curPanel.EventTimer; }

    /// <summary>
    /// 关卡默认计时注销：当有到计时时，会调用此函数
    /// </summary>
    public void LogoutCountUp() { LevelFlowCtrl.instance.EventCountUpTimer -= curPanel.EventTimer; }
}
