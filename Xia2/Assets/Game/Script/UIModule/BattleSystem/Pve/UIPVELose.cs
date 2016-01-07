using UnityEngine;
using System.Collections;

public class UIPVELose : MonoBehaviour
{
    public UIPVEFinishPanel m_BattleCensus { get { return UIPVEFinishPanel.instance; } }

    public GameObject pnlMain;
    public UIPlayTween twnEff;

   
    public void ShowEffect()
    {
        twnEff.Play(true);
    }

    public void ShowMain()
    {
        pnlMain.SetActive(true);
    }

}
