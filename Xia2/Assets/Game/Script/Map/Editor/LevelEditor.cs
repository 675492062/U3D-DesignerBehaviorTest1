/****************************************************************************** 
 * 
 * Maintaince Logs: 
 * 2014-11-17   WP      Initial version: Added member
 * 
 * *****************************************************************************/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;




public class SelectDatas
{
    public const string PATH_CONFIG = AllStrings.PATH_LEVEL_CONFIG;
    public const string HEAD_CONFIG = AllStrings.FILE_HEAD_CONFIG;
    public const string PATH_CAMERA = AllStrings.PATH_LEVEL_CAMERA;
    public const string HEAD_CAMERA = AllStrings.FILE_HEAD_CAMERA;

    #region current chapter

    private int mCprIndex = -1;
    public int curChapterIndex
    {
        get { return mCprIndex; }
        set
        {
            if (mCprIndex != value)
            {
                mCprIndex = value;
                ResetDungeon();
            }
        }
    }
    private ChapterItem mChapter;
    public ChapterItem curChapter
    {
        get
        {
            if (mChapter == null)
                mChapter = new ChapterItem(chapterIDs[curChapterIndex]);
            else mChapter.Reset(chapterIDs[curChapterIndex]);
            return mChapter;
        }
    }

    #endregion

    #region current dungeon

    private int mDgnIndex = -1;
    public int curDungeonIndex
    {
        get { return mDgnIndex; }
        set
        {

            mDgnIndex = value;
            mRes = null;
            ResetTable();

        }
    }
    private DungeonItem mDungeon;
    public DungeonItem curDungeon
    {
        get
        {
            if (mDungeon == null)
                mDungeon = new DungeonItem(curChapter.GetAllDungeonId()[curDungeonIndex]);
            else
            {
                if (curDungeonIndex > curChapter.GetAllDungeonId().Length - 1)
                {
                    Debug.Log(" curDungeonIndex ----------" + curDungeonIndex);
                    curDungeonIndex = 0;
                }
                int id = curChapter.GetAllDungeonId()[curDungeonIndex];
                mDungeon.id = id;
                //Debug.Log("---------dungeon id is" + id);
            }
            return mDungeon;
        }
    }

    #endregion

    #region currnet Res

    private Object mRes;
    public Object prbMapRes
    {
        get
        {
            if (mRes == null) mRes = Resources.Load(AllStrings.PATH_MAP_RES + curDungeon.resname);
            return mRes;
        }
    }

    #endregion

    #region chapter and dungeon Editor popup

    private static string GetChapterName(int id)
    {
        return StaticChapter.Instance().getStr(id, "name");
    }

    private static string GetDungeonName(int id)
    {
        return StaticDungeon.Instance().getStr(id, "name");
    }

    private static List<string> mChapters;
    public List<string> allChapterPopup
    {
        get
        {
            if (mChapters == null)
            {
                mChapters = new List<string>();
                string eleStr = "";

                for (int i = 0; i < chapterIDs.Length; i++)
                {
                    eleStr = chapterIDs[i] + "   ---  " + GetChapterName(chapterIDs[i]);
                    mChapters.Add(eleStr);
                }
            }
            return mChapters;

        }
    }

    private static List<string> mDungeons;
    public List<string> allDungeonPopup
    {
        get
        {
            if (mDungeons == null)
            {
                mDungeons = new List<string>();
                ResetDungeon();
            }

            return mDungeons;
        }
    }
    public void ResetDungeon()
    {
        if (mDungeons == null)
        {
            mDungeons = new List<string>();
        }
        mDungeons.Clear();

        curChapter.ResetIDs();
        int[] allID = curChapter.GetAllDungeonId();
        string eleStr = "";
        for (int i = 0; i < allID.Length; i++)
        {
            eleStr = allID[i] + "   ---  " + GetDungeonName(allID[i]);
            mDungeons.Add(eleStr);
        }
        //reset res prefab
        mRes = null; mLevelCameraPath = null;

        curDungeonIndex = 0;
    }

    private static int[] mChapterIDs;//= new int[] { 350001, 350002 };
    /// <summary>
    /// all chapter ids
    /// </summary>
    private int[] chapterIDs
    {
        get
        {
            if (mChapterIDs == null)
            {
                mChapterIDs = StaticChapter.Instance().allID;
            }
            return mChapterIDs;
        }
    }

    #endregion

    #region current difficulty and editor popup

    private static List<string> mTables;
    public List<string> allTablePopup
    {
        get
        {
            if (mTables == null)
            {
                mTables = new List<string>();
                ResetTable();
            }
            return mTables;
        }
    }
    private void ResetTable()
    {
        //Debug.Log(" Reset   table");
        if (mTables == null) mTables = new List<string>();
        curConfigIndex = 0;
        mTables.Clear();
        int[] allID = GetAllTableFiles();
        string eleStr = "";
        for (int i = 0; i < allID.Length; i++)
        {
            eleStr = allID[i] + "   ---  table" + (i + 1);
            mTables.Add(eleStr);
        }
        mConfig = null;
    }
    const int MAX_TABLE_COUNT = 5;
    private int[] GetAllTableFiles()
    {
        int[] mTables = new int[MAX_TABLE_COUNT];
        for (int i = 0; i < MAX_TABLE_COUNT; i++)
        {
            mTables[i] = StaticDungeon.Instance().getInt(curDungeon.templateID, "tablefile" + (i + 1));
        }

        return mTables;
    }

    #endregion

    #region LevelConfig

    private int mCfgIndex = -1;
    public int curConfigIndex
    {
        get { return mCfgIndex; }
        set
        {
            //if (mCfgIndex != value)
            {
                mCfgIndex = value;
                configId = GetAllTableFiles()[value];
                mConfig = null;
            }
        }
    }
    private int configId = 0;

    private Object mConfig;
    public Object prbLevelConfig
    {
        get
        {
            if (mConfig == null) mConfig = Resources.Load(PATH_CONFIG + GetNameByCurConfig());
            return mConfig;
        }
    }
    public string GetNameByCurConfig()
    {
        return HEAD_CONFIG + configId;
    }

    private Object mModelConfig;
    public Object prbModelConfig
    {
        get
        {
            if (mModelConfig == null) mModelConfig = Resources.Load(PATH_CONFIG + HEAD_CONFIG + "Model");
            return mModelConfig;
        }
    }

    public int GetConfigId() { return configId; }

    #endregion

    #region LevelCamera

    private Object mModelCamera;
    public Object prbModelLevelCamera
    {
        get
        {
            if (mModelCamera == null) mModelCamera = Resources.Load(PATH_CAMERA + "LevelCamer_Model");
            return mModelCamera;
        }
    }

    private Object mLevelCameraPath;
    public Object prbLevelCameraPath
    {
        get
        {
            if (mLevelCameraPath == null)
            {
                if (prbMapRes == null) mLevelCameraPath = null;
                else mLevelCameraPath = Resources.Load(PATH_CAMERA + GetNameByCurCamera());
            }
            return mLevelCameraPath;
        }
    }

    public string GetNameByCurCamera()
    {
        return HEAD_CAMERA + prbMapRes.name;
    }

    #endregion
}