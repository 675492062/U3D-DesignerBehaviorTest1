using UnityEngine;
using System.Collections;

/// <summary>
/// 战斗场景中的UI关卡评星管理器
/// 
/// Maintaince Logs:
/// 2014-12-23  WP      Initial version. 
/// </summary>
public class UILevelAchievemCtrl : MonoBehaviour
{
    public UILevelAchievem prbUIAch;

    public UIGrid grdParent;

    // Use this for initialization
    void Start()
    {
        //PVP
        if (LevelData.levelType == 8) return;

        if (prbUIAch != null)
        {
            for (int i = 0; i < 3; i++)
            {
                UILevelAchievem uiLa = KMTools.AddChild<UILevelAchievem>(grdParent.gameObject, prbUIAch);
                uiLa.Init(i);
                uiLa.gameObject.SetActive(true);
            }

            grdParent.repositionNow = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
