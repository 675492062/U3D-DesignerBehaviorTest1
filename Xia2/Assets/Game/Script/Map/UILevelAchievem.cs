using UnityEngine;
using System.Collections;

/// <summary>
/// UI里一个成就的显示
/// 
/// Maintaince Logs: 
/// 2014-12-19  WP      Initial version
/// </summary>
public class UILevelAchievem : MonoBehaviour
{
    /// <summary>
    ///  0 , 1 ,2
    /// </summary>
    private int index = 0;

    public enum ShowType
    {
        UI,
        Battle,
    }

    public ShowType showType = ShowType.UI;

    public UILabel labDesc;

    public UISprite sprStar;

    /// <summary>
    /// 亮时 名字
    /// </summary>
    const string nameLightOn = "zd-xing01";

    const string nameLightOff = "zd-xing02";

    private LevelAchievem achievem;

    /// <summary>
    /// 用于判断是否在实例化之前OnEnable了
    /// </summary>
    private bool isEnable = false;

    public void Init(int index, int configId = 0)
    {
        this.index = index;
        switch (showType)
        {
            case ShowType.UI:
                achievem = LevelAchievemCtrl.GetAchievement(configId).achieves[index];
                break;
            case ShowType.Battle:
                achievem = LevelAchievemCtrl.instance.GetAchievem(index);

                break;
            default:
                Debug.Log("----------please add ");
                break;
        }
    }

    void OnEnable()
    {
        if (isEnable) return;

        isEnable = true;
        if (achievem != null)
        {
            switch (showType)
            {
                case ShowType.UI:
                    achievem.onAchievemChangeWithUI += Refresh;
                    Refresh(achievem.descForMenu);
                    break;
                case ShowType.Battle:
                    achievem.onAchievemChange += Refresh;
                    Refresh(achievem.isFinished, achievem.descForGame);
                    break;
                default:
                    Debug.Log("----------please add ");
                    break;
            }
        }
        else
        {
            Debug.Log("----------index is error!!!", gameObject);
        }
    }

    void OnDisable()
    {
        if (!isEnable) return;
        isEnable = false;

        if (achievem != null)
        {
            switch (showType)
            {
                case ShowType.UI:
                    achievem.onAchievemChangeWithUI -= Refresh;

                    break;
                case ShowType.Battle:
                    achievem.onAchievemChange -= Refresh;
                    break;
                default:
                    Debug.Log("----------please add ");
                    break;
            }
        }
        else
        {
            Debug.Log("----------index is error!!!", gameObject);
        }
    }

    void Refresh(bool isComplete, string desc)
    {
        //Debug.Log("Refresh -------" + desc, gameObject);
        Refresh(desc);
        labDesc.color = isComplete ? Color.green : Color.white;

        //星星图标的改变：
        if (showType == ShowType.Battle && sprStar != null)
        {
            sprStar.spriteName = isComplete ? nameLightOn : nameLightOff;
        }
    }

    public void Refresh(string desc)
    {
        labDesc.text = desc;
    }
}