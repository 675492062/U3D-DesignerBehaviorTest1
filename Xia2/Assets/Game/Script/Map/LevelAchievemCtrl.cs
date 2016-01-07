using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 关卡战斗成就管理
/// 
/// Maintaince Logs: 
/// 2014-12-17  WP      Initial version
///         18  WP      添加事件实例化
/// </summary>
public class LevelAchievemCtrl : MonoBehaviour
{
    private static LevelAchievemCtrl mInstance;
    /// <summary>
    /// 只用于单例，如果菜单想调用 请用GetAchievement
    /// </summary>
    public static LevelAchievemCtrl instance
    {
        get
        {
            if (mInstance == null)
            {
                //Debug 
                mInstance = GameObject.FindObjectOfType(typeof(LevelAchievemCtrl)) as LevelAchievemCtrl;
                if (mInstance == null)
                {
                    string resPath = AllStrings.PATH_LEVEL_ACHIEVEMENT + AllStrings.FILE_LEVEL_ACHIEVEMENT + LevelData.curConfigID;
                    Object obj = Resources.Load(resPath);
                    if (obj)
                    {
                        GameObject prefab = obj as GameObject;
                        GameObject go = KMTools.AddGameObj(null, prefab, false);
                        mInstance = go.GetComponent<LevelAchievemCtrl>();

                    }
                    else
                    {
                        Debug.Log("Achevem is null!!!=----------- config id : " + LevelData.curConfigID);
                        Debug.Log("Load Model Achievement:::");
                        resPath = AllStrings.PATH_LEVEL_ACHIEVEMENT + AllStrings.FILE_LEVEL_ACHIEVEMENT + "Model";
                        obj = Resources.Load(resPath);

                        GameObject prefab = obj as GameObject;
                        GameObject go = KMTools.AddGameObj(null, prefab, false);
                        mInstance = go.GetComponent<LevelAchievemCtrl>();
                    }
                }
            }
            return mInstance;
        }
    }

    /// <summary>
    ///1：击杀10个狼
    ///2：击杀10个怪
    ///3：张飞上阵
    ///4：收集10个刀
    ///5：所有英雄血量不曾低于20%
    ///6：无英雄阵亡
    ///7：90秒内通关
    /// </summary>
    public enum AchievemType
    {
        KillEnemies = 1,
        Kills = 2,
        HasHero = 3,
        FindSomething = 4,
        AllHeroHPLimit = 5,
        HeroDead = 6,
        LevelTimeLimit = 7,
    }

    [SerializeField]
    /// <summary>
    /// 三个成就
    /// </summary>
    public LevelAchievem[] achieves = new LevelAchievem[3];

    /// <summary>
    /// 菜单UI 使用
    /// </summary>
    /// <param name="configId"></param>
    /// <returns></returns>
    public static LevelAchievemCtrl GetAchievement(int configId)
    {
        string resPath = AllStrings.PATH_LEVEL_ACHIEVEMENT + AllStrings.FILE_LEVEL_ACHIEVEMENT + configId;
        Object obj = Resources.Load(resPath);
        if (obj)
        {
            GameObject prefab = obj as GameObject;
            return prefab.GetComponent<LevelAchievemCtrl>();
        }
        else Debug.Log("--------null" + configId);
        return null;
    }

    /// <summary>
    /// 仅用于战斗中UI
    /// </summary>
    public void Init()
    {
        foreach (LevelAchievem achievem in achieves)
        {
            AchievemType atp = (AchievemType)achievem.type;

            //Debug.Log(atp.ToString() + "--------- id " + achievem.id);

            switch (atp)
            {
                case AchievemType.KillEnemies:
                    EnemyCtrl.instance.enemyKillsEvent += achievem.EventKillEnemies;
                    break;
                case AchievemType.Kills:
                    EnemyCtrl.instance.killsEvent += achievem.EventKills;
                    break;
                case AchievemType.HasHero:
                    CheckHasHero(achievem);
                    break;
                case AchievemType.FindSomething:
                    break;
                case AchievemType.AllHeroHPLimit:
                    ObjectManager.instance.myPlayer.getHpPercent += achievem.EventCheckHeroHp;
                    achievem.isFinished = true;
                    break;
                case AchievemType.HeroDead:
                    achievem.isFinished = true;
                    ObjectManager.instance.myPlayer.deadEvent += achievem.EventHeroDead;
                    break;
                case AchievemType.LevelTimeLimit:
                    LevelFlowCtrl.instance.EventTimeByFinishedLevel += achievem.EventLevelTimeLimit;
                    break;
                default:
                    Debug.Log("---------------- Achievement not instance!!!");
                    break;
            }

            achievem.OnChangeAchievem();
        }
    }

    /// <summary>
    /// 取关卡成就的当前完成状态
    /// </summary>
    /// <param name="achIndex">成就Index 0，1，2</param>
    /// <returns></returns>
    public LevelAchievem GetAchievem(int achIndex)
    {
        if (achIndex < achieves.Length)
        {
            return achieves[achIndex];
        }
        Debug.Log("index error ==================");
        return null;
    }

    /// <summary>
    /// 取成就所在数组的位置
    /// </summary>
    /// <param name="ach"></param>
    /// <returns></returns>
    private int GetIndex(LevelAchievem ach)
    {
        List<LevelAchievem> achs = new List<LevelAchievem>(achieves);
        return achs.IndexOf(ach);
    }

    private void CheckHasHero(LevelAchievem la)
    {
        if (MonoInstancePool.getInstance<HeroManager>().fightHeroList.hasHeroTemplateId(la.param1))
        {
            la.Finished();
        }
        else
        {
            la.Losed();
        }
    }

}
