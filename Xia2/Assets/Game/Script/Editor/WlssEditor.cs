using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 亡灵杀手 提供编辑器类
/// 
/// Maintaince Logs:
/// 2014-12-11  WP      Initial version. 加入敌人选择弹窗系列函数
/// </summary>
public class WlssEditor
{
    #region  玩家数据

    static int[] heroIds { get { return StaticHero.Instance().allID; } }
    static List<int> mHeroIdsList;
    static List<int> listHeroId
    {
        get
        {
            if (mHeroIdsList == null) mHeroIdsList = new List<int>(heroIds);
            return mHeroIdsList;
        }
    }

    static List<string> mPopHeroIdsList;
    static string[] mPopHeroIds;
    static string[] popHeroIds
    {
        get
        {
            if (mPopHeroIdsList == null)
            {
                mPopHeroIdsList = new List<string>();
                for (int i = 0; i < heroIds.Length; i++)
                {
                    string desc = heroIds[i] + "--";
                    desc += StaticHero.Instance().getStr(heroIds[i], "name");
                    mPopHeroIdsList.Add(desc);
                }
                mPopHeroIds = mPopHeroIdsList.ToArray();
            }
            return mPopHeroIds;
        }
    }

    static public int PopupHeroIds(int id)
    {
        int index = 0;

        if (!listHeroId.Contains(id))
        {
            id = listHeroId[0];
        }
        else
        {
            index = listHeroId.IndexOf(id);
        }

        index = EditorGUILayout.Popup(index, popHeroIds);

        return heroIds[index];
    }

    #endregion

    #region 敌人弹出框

    /// <summary>
    /// 敌人ID 数组 
    /// </summary>
    static int[] enemiesIds { get { return StaticMonster.Instance().allID; } }
    static List<int> mEnemyIdList;
    static List<int> listEnemyId
    {
        get
        {
            if (mEnemyIdList == null) mEnemyIdList = new List<int>(enemiesIds);
            return mEnemyIdList;
        }
    }


    /// <summary>
    /// 敌人ID + 描述 数组，只用于更好的显示和选择某个敌人
    /// </summary>
    static string[] popEnemies { get { return StaticEditorDatas.popEnemies; } }

    /// <summary>
    /// 编辑器画敌人列表
    /// </summary>
    /// <param name="enemyId">传入敌人ID</param>
    /// <returns>返回当前所选择的敌人ID</returns>
    static public int PopupEnemies(int enemyId) { return PopupEnemies(enemyId, null); }

    static public int PopupEnemies(int enemyId, params GUILayoutOption[] options) { return PopupEnemies("", enemyId, options); }

    static public int PopupEnemies(string label, int enemyId) { return PopupEnemies(label, enemyId, null); }

    static public int PopupEnemies(string label, int enemyId, params GUILayoutOption[] options)
    {
        int index = 0;

        if (!listEnemyId.Contains(enemyId))
        {
            enemyId = enemiesIds[0];
        }
        else
        {
            index = listEnemyId.IndexOf(enemyId);
        }

        if (string.IsNullOrEmpty(label))
            index = EditorGUILayout.Popup(index, popEnemies, options);
        else index = EditorGUILayout.Popup(label, index, popEnemies, options);

        return enemiesIds[index];
    }

    #endregion

    #region 关卡流程行动弹出框

    static List<string> listActions { get { return LevelFlowCtrl.getMethodList; } }
    static string[] mPopMethods;
    private static string[] popMethods
    {
        get { if (mPopMethods == null) mPopMethods = listActions.ToArray(); return mPopMethods; }
    }

    static public string PopupActions(string actionName)
    {
        int index = 0;

        if (!listActions.Contains(actionName))
        {
            actionName = listActions[0];
        }
        else
        {
            index = listActions.IndexOf(actionName);
        }

        index = EditorGUILayout.Popup(index, popMethods, GUILayout.MaxWidth(200f));

        return listActions[index];
    }

    #endregion

    #region 关卡成就相关

    static int[] achieveIds { get { return StaticDungeon_star.Instance().allID; } }
    static List<int> mAchievemList;
    static List<int> achievemList
    {
        get
        {
            if (mAchievemList == null) mAchievemList = new List<int>(achieveIds);
            return mAchievemList;
        }
    }

    static List<string> mPopAchievementsList;
    static string[] mPopAchievements;
    static string[] popAchievements
    {
        get
        {
            if (mPopAchievementsList == null)
            {
                mPopAchievementsList = new List<string>();
                for (int i = 0; i < achieveIds.Length; i++)
                {
                    string desc = achieveIds[i] + "--";
                    desc += StaticDungeon_star.Instance().getStr(achieveIds[i], "name");
                    mPopAchievementsList.Add(desc);
                }

                mPopAchievements = mPopAchievementsList.ToArray();
            }
            return mPopAchievements;
        }
    }

    static public int PopupAchievements(int id)
    {
        int index = 0;

        if (!achievemList.Contains(id))
        {
            id = achievemList[0];
        }
        else
        {
            index = achievemList.IndexOf(id);
        }

        index = EditorGUILayout.Popup(index, popAchievements);

        return achieveIds[index];
    }

    static public int ShowValueByAchieveType(LevelAchievem.ParamType pt, int id)
    {
        switch (pt)
        {
            case LevelAchievem.ParamType.Hero:
                return PopupHeroIds(id);
            case LevelAchievem.ParamType.Enemy:
                return PopupEnemies(id);
            case LevelAchievem.ParamType.NPC:
                break;
            case LevelAchievem.ParamType.Number:
                return EditorGUILayout.IntSlider(id, 1, 100);
            default:
                Debug.Log("----------please add to -----");
                break;
        }

        return 0;
    }

    #endregion

    #region 关卡章节

    static int[] chapterIDs { get { return StaticChapter.Instance().allID; } }
    static List<int> mChapterList;
    static List<int> listChapterId { get { if (mChapterList == null) mChapterList = new List<int>(chapterIDs); return mChapterList; } }

    static List<string> mPopChapterIdsList;
    static string[] mPopChapterIds;
    static string[] popChapterIds
    {
        get
        {
            if (mPopChapterIdsList == null)
            {
                mPopChapterIdsList = new List<string>();
                for (int i = 0; i < chapterIDs.Length; i++)
                {
                    string desc = chapterIDs[i] + "--";
                    desc += StaticChapter.Instance().getStr(chapterIDs[i], "name");
                    mPopChapterIdsList.Add(desc);
                }
                mPopChapterIds = mPopChapterIdsList.ToArray();
            }
            return mPopChapterIds;
        }
    }

    static public int PopupChapterIds(int id)
    {
        int index = 0;

        if (!listChapterId.Contains(id))
        {
            id = listChapterId[0];
        }
        else
        {
            index = listChapterId.IndexOf(id);
        }

        index = EditorGUILayout.Popup(index, popChapterIds);

        return chapterIDs[index];
    }

    #endregion
}
