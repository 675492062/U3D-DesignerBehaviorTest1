using UnityEngine;
using System.Collections;

/// <summary>
/// PVP 结束管理器
/// 
/// Maintaince Logs: 
/// 2014-12-28  WP      Initial version
/// </summary>
public class UIPVPFinish : UIBattleFinishPanel
{

    public UIPVPWin pnlWin;
    public UIPVPLose pnlLose;

    private bool isShow = false;

    public override void ShowPanel(bool isWin)
    {

        MonoInstancePool.getInstance<SendFightMsgHander>().SendAreanFightEndReq(isWin);

        gameObject.SetActive(true);

        if (isWin)
        {
            StartCoroutine(ShowWin());
        }
        else
        {
            ShowLose();
        }
    }

    IEnumerator ShowWin()
    {
        //Debug.Log("=================================== is finish   win1");

        while (UIBattlePvpPanel.pvpRocardData == null)
        {
            yield return null;
        }

        Debug.Log("=================================== is finish   win2");
        pnlWin.gameObject.SetActive(true);

        pnlWin.Show(UIBattlePvpPanel.pvpRocardData);

        UIBattlePvpPanel.pvpRocardData = null;

        isShow = true;
    }

    void ShowLose()
    {

        //Debug.Log("=================================== is finish   lose");
        pnlLose.gameObject.SetActive(true);

        pnlLose.Show();

        isShow = true;

    }

    public void BtnToMenu()
    {
        if (isShow)
            SceneCtrl.ToMenu();
    }
}
