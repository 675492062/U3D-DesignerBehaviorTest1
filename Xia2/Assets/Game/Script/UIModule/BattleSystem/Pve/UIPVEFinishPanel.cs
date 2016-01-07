using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightMessage;
using System.Linq;

public class UIPVEFinishPanel : UIBattleFinishPanel
{

    public UIPVESelectBox pnlSelectBox; //选宝箱列表  
    public UIPVEWin pnlSuccess;//成功列表
    public UIPVELose pnlFail;//失败列表
    public UIPVEStatistics pnlStatistics;//战斗统计列表
    public UIPlayTween twnSuccessEffect;

    List<int> clickBoxesList = new List<int>();//点击宝箱索引的列表

    private static UIPVEFinishPanel mInstance;
    public static UIPVEFinishPanel instance
    {
        get
        {
            if (mInstance == null)
            {
                mInstance = GameObject.FindObjectOfType(typeof(UIPVEFinishPanel)) as UIPVEFinishPanel;
            }
            return mInstance;
        }
    }

    public enum UI_State
    {
        E_SUCCESS_COMPLETED, // 成功统计表
        E_SUCCESS,    //成功选宝箱列表
        E_FAILED,    //失败列表
        E_CENSUS,     //战斗统计列表
    }

    void OnEnable()
    {
        UIBattleManager.instance.pnlPVE.bombEffect.gameObject.SetActive(false);
    }

    public void AddIndexToList(int index)
    {
        clickBoxesList.Add(index);
    }

    public void SetActive(UI_State state)
    {
        //Debug.Log("              fail");
        switch (state)
        {
            case UI_State.E_SUCCESS_COMPLETED://选宝箱完成列表 
                pnlSuccess.gameObject.SetActive(true);
                pnlSelectBox.gameObject.SetActive(false);
                break;
            case UI_State.E_SUCCESS://成功选宝箱列表
                pnlSuccess.gameObject.SetActive(false);
                pnlSelectBox.gameObject.SetActive(true);
                break;
            case UI_State.E_FAILED://失败列表
                pnlFail.gameObject.SetActive(true);
                pnlFail.ShowEffect();
                //Debug.Log("to fail");
                break;
            case UI_State.E_CENSUS://战斗统计列表
                pnlStatistics.gameObject.SetActive(true);
                break;
        }
    }

    public void ToSelectBox()
    {
        Debug.Log("-------------- Select box");
        SetActive(UI_State.E_SUCCESS);
        pnlSelectBox.setGemList();
    }

    public void BtnBackToSelectMap()
    {
        //跳转至选地图
        GlobalDef.mainSceneState = GlobalDef.UIState.UI_CAPTER_WINDOW;
        SceneCtrl.ToMenu();
    }

    public void BtnReset()
    {
        Debug.Log("Back battle Again !!!!");
        SendEnterFight();
    }

    public override void ShowPanel(bool isWin)
    {
        gameObject.SetActive(true);
        if (isWin)
        {
            //成功统计UI
            twnSuccessEffect.Play(true);
        }
        else
        {
            SetActive(UI_State.E_FAILED);
            SendFailedEvent();
        }
    }

    #region send message and callback

    public static void SendEnterFight()
    {
        //
        MonoInstancePool.getInstance<SendFightMsgHander>().SendEnterFightReq(LevelData.curChapterId, LevelData.curDungeonId, (int)LevelData.levelDifficulty);
    }

    public void SendFailedEvent()
    {
        SendFightEndEvent(false, null);
    }

    public void SendSuccessEvent()
    {
        //TODO
        SendFightEndEvent(true, clickBoxesList);
    }

    public static void SendFightEndEvent(bool isSuccess, List<int> boxes)
    {
        MonoInstancePool.getInstance<SendFightMsgHander>().SendFightEndReq(isSuccess, boxes);
    }

    /// <summary>
    /// 选完宝箱后的回馈事件
    /// </summary>
    public void CallBackSuccess()
    {
        Debug.Log("------------------------to success panel");
        SetActive(UIPVEFinishPanel.UI_State.E_SUCCESS_COMPLETED);
        pnlSuccess.Init();
    }

    #endregion

}
