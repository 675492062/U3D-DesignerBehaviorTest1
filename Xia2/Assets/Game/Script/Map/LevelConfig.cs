/****************************************************************************** 
 * 
 * Maintaince Logs: 
 * 2014-11-11   WP      Initial version: Added member
 * 2014-12-16   WP      加入地图大小控制
 * 
 * *****************************************************************************/

#if UNITY_EDITOR || (!UNITY_FLASH && !NETFX_CORE && !UNITY_WP8)
#define REFLECTION_SUPPORT
#endif

#if REFLECTION_SUPPORT
using System.Reflection;
#endif

#if UNITY_EDITOR
#endif

using System;
using UnityEngine;
using System.Collections.Generic;

[Serializable]
public class LevelAction
{
    /// <summary>
    /// 第1个元素为方法名，之后为参数名
    /// </summary>

    [SerializeField]
    public List<string> action = new List<string>();

    public LevelAction(List<string> objs)
    {
        action = objs;
        if (action == null)
        {
            Debug.Log("action is null /??????????");
        }
    }
}

/// <summary>
/// a level config
/// </summary>
public class LevelConfig : MonoBehaviour
{
    public Transform heroStartPos;

    public Transform enemyParent;

    public Transform eventParent;

    const string nameParcloseParent = "parcloses";
    
    [SerializeField]
    [HideInInspector]
    private Transform mParcloseParent;
    private Transform parcloseParent
    {
        get
        {
            if (mParcloseParent == null)
            {
                mParcloseParent = transform.FindChild(nameParcloseParent);

                if (mParcloseParent == null)
                {
                    mParcloseParent = KMTools.AddGameObj(gameObject).transform;
                    mParcloseParent.name = nameParcloseParent;
                }
            }
            return mParcloseParent;
        }
    }

    const string nameBarrackParent = "barracks";
    [SerializeField]
    [HideInInspector]
    private Transform mBarrackParent;
    private Transform barrackParent
    {
        get
        {
            if (mBarrackParent == null)
            {
                mBarrackParent = transform.FindChild(nameBarrackParent);

                if (mBarrackParent == null)
                {
                    mBarrackParent = KMTools.AddGameObj(gameObject).transform;
                    mBarrackParent.name = nameBarrackParent;
                }
            }
            return mBarrackParent;
        }
    }

    const string nameGateParent = "gates";
    [SerializeField]
    [HideInInspector]
    private Transform mGateParent;
    private Transform gateParent
    {
        get
        {
            if (mGateParent == null)
            {
                mGateParent = transform.FindChild(nameGateParent);

                if (mGateParent == null)
                {
                    mGateParent = KMTools.AddGameObj(gameObject).transform;
                    mGateParent.name = nameGateParent;
                }
            }
            return mGateParent;
        }
    }

    const string nameCastleParent = "castles";
    [SerializeField]
    [HideInInspector]
    private Transform mCastleParent;
    private Transform castleParent
    {
        get
        {
            if (mCastleParent == null)
            {
                mCastleParent = transform.FindChild(nameCastleParent);

                if (mCastleParent == null)
                {
                    mCastleParent = KMTools.AddGameObj(gameObject).transform;
                    mCastleParent.name = nameCastleParent;
                }
            }
            return mCastleParent;
        }
    }

    const string nameGround = "ground";
    [SerializeField]
    [HideInInspector]
    private MapRange mGround;
    public MapRange ground
    {
        get
        {
            if (mGround == null)
            {
                Transform t = transform.FindChild(nameGround);

                if (t == null)
                {
                    GameObject go = KMTools.AddGameObj(gameObject);
                    mGround = go.AddComponent<MapRange>();
                    go.AddComponent<DrawMapArea>();
                    mGround.name = nameGround;
                    mGround.Reset();
                }
                else
                {
                    mGround = t.GetComponent<MapRange>();
                }
            }
            return mGround;
        }
    }

    private List<Transform> mEnemyPos = new List<Transform>();
    public List<Transform> enemyPos
    {
        get
        {
            if (enemyParent.childCount != mEnemyPos.Count)
            {
                mEnemyPos.Clear();
                int i = 1;
                foreach (Transform t in enemyParent)
                {
                    t.name = "EnemyPos" + i;
                    mEnemyPos.Add(t);
                    i++;
                }
            }
            return mEnemyPos;
        }
    }

    private List<LevelFlowContinue> mEvents = new List<LevelFlowContinue>();
    public List<LevelFlowContinue> events
    {
        get
        {
            if (eventParent.childCount != mEvents.Count)
            {
                ResetEvent();
            }
            return mEvents;
        }
    }

    private List<Parclose> mParcloses = new List<Parclose>();
    public List<Parclose> parcloses
    {
        get
        {
            if (parcloseParent.childCount != mParcloses.Count)
            {
                mParcloses.Clear();
                foreach (Transform t in parcloseParent)
                {
                    Parclose lp = t.GetComponent<Parclose>();
                    if (lp)
                        mParcloses.Add(lp);
                    else
                    {
                        Debug.Log("Delete ------------");
                        DestroyImmediate(t.gameObject);
                    }
                }
            }
            return mParcloses;
        }
    }

    private List<Barrack> mbarracks = new List<Barrack>();
    public List<Barrack> barracks
    {
        get
        {
            if (barrackParent.childCount != mbarracks.Count)
            {
                mbarracks.Clear();
                foreach (Transform t in mBarrackParent)
                {
                    Barrack bar = t.GetComponent<Barrack>();
                    if (bar)
                        mbarracks.Add(bar);
                    else
                        DestroyImmediate(t.gameObject);
                }
            }
            return mbarracks;
        }
    }

    //城门
    private List<Gate> mGates = new List<Gate>();
    public List<Gate> gates
    {
        get
        {
            if (gateParent.childCount != mGates.Count)
            {
                mGates.Clear();
                foreach (Transform t in gateParent)
                {
                    Gate gate = t.GetComponent<Gate>();
                    if (gate)
                        mGates.Add(gate);
                    else
                        DestroyImmediate(t.gameObject);
                }
            }
            return mGates;
        }
    }

    private List<Castle> mCastles = new List<Castle>();
    public List<Castle> castles
    {
        get
        {
            if (castleParent.childCount != mCastles.Count)
            {
                mCastles.Clear();
                foreach (Transform t in castleParent)
                {
                    Castle bar = t.GetComponent<Castle>();
                    if (bar)
                        mCastles.Add(bar);
                    else
                        DestroyImmediate(t.gameObject);
                }
            }
            return mCastles;
        }
    }

    /// <summary>
    /// 设置这个数之后，关卡默认会以杀兵营为成功事件
    /// </summary>
    public int barrackKills = 0;

    /// <summary>
    /// 设置这个数之后，关卡默认会以杀城门为成功事件
    /// </summary>
    public int gateKills = 0;

    /// <summary>
    /// for game flow: a action : 1 : methon name .
    /// </summary>
    public List<LevelAction> actions = new List<LevelAction>();

    public void ResetEvent()
    {
        mEvents.Clear();

        foreach (Transform t in eventParent)
        {
            LevelFlowContinue lft = t.GetComponent<LevelFlowContinue>();
            if (lft)
            {
                mEvents.Add(lft);
            }
            else
            {
                Debug.Log(" Destory object ", t.gameObject);
            }
        }
        for (int i = 0; i < mEvents.Count; i++)
        {
            mEvents[i].name = "Event_" + (i + 1);
            if (i != mEvents.Count - 1)
            {
                mEvents[i].nextEvent = mEvents[i + 1];
            }
        }
    }

    public void Init()
    {
        ground.Init();
    }

    #region editor
#if UNITY_EDITOR

    private List<string> mPopEnemyPos = new List<string>();
    /// <summary>
    /// 敌人点选择 only editor
    /// </summary>
    public string[] popEnemyPos
    {
        get
        {
            if (mPopEnemyPos.Count != enemyPos.Count)
            {
                mPopEnemyPos.Clear();
                for (int i = 0; i < enemyPos.Count; i++)
                {
                    mPopEnemyPos.Add(enemyPos[i].name);
                }
            }

            return mPopEnemyPos.ToArray();
        }
    }


    /// <summary>
    /// 添加敌人出生点
    /// </summary>
    /// <returns></returns>
    public GameObject AddEnemyPos()
    {
        GameObject go = KMTools.AddGameObj(enemyParent.gameObject);
        go.name = "EnemyPos" + (mEnemyPos.Count + 1);
        go.AddComponent<DrawEnemyCreatePos>();

        return go;
    }

    public void RemoveEnemyPos(Transform t)
    {
        if (mEnemyPos.Count < 2)
        {
            Debug.Log(" you need one pos to scene");
            return;
        }

        if (mEnemyPos.Contains(t))
        {
            mEnemyPos.Remove(t);
            DestroyImmediate(t.gameObject);
        }
    }

    public GameObject AddEventTrigger()
    {
        GameObject go = (GameObject)Instantiate(Resources.Load("Prefab/Map/Other/EventTrigger"));
        go.transform.parent = eventParent;
        return go;
    }

    /// <summary>
    /// 添加全局屏障
    /// </summary>
    /// <returns></returns>
    public GameObject AddParcloses()
    {
        //实例Prefab，Prefab自带Collider
        GameObject go = KMTools.AddGameObj(parcloseParent.gameObject);
        go.AddComponent<Parclose>();

        go.name = "Parclose";
        return go;
    }

    public void RemoveParclose(int index)
    {
        Debug.Log("------del");
        DestroyImmediate(parcloses[index].gameObject);
    }

    /// <summary>
    /// 添加军营
    /// </summary>
    /// <returns></returns>
    public GameObject AddBarrack()
    {
        GameObject go = KMTools.AddGameObj(barrackParent.gameObject);
        go.AddComponent<Barrack>();

        //兵营胜利条件
        barrackKills++;
        go.name = "Barrack";
        return go;
    }

    public void RemoveBarrack(int index)
    {
        //兵营胜利条件
        barrackKills--;
        DestroyImmediate(barracks[index].gameObject);
    }

    /// <summary>
    /// 添加城门
    /// </summary>
    public GameObject AddGate()
    {
        GameObject go = KMTools.AddGameObj(gateParent.gameObject);
        go.AddComponent<Gate>();

        //兵营胜利条件
        gateKills++;
        go.name = "Gate";
        return go;
    }

    public void RemoveGate(int index)
    {
        gateKills--;
        DestroyImmediate(gates[index].gameObject);
    }

    /// <summary>
    /// 添加城堡
    /// </summary>
    /// <returns></returns>
    public GameObject AddCastle()
    {
        GameObject go = KMTools.AddGameObj(castleParent.gameObject);
        go.AddComponent<Castle>();

        go.name = "Castle";
        return go;
    }

    public void RemoveCastle(int index)
    {
        DestroyImmediate(castles[index].gameObject);
    }

    public void RemoveEventTrigger(LevelFlowContinue lft)
    {
        if (mEvents.Contains(lft))
        {
            mEvents.Remove(lft);
            DestroyImmediate(lft.gameObject);
        }
    }

    public void AddAction()
    {
        List<string> objs = new List<string>();
        objs.Add(LevelFlowCtrl.getMethodList[0]);
        InitAction(objs);


        actions.Add(new LevelAction(objs));
    }

    public void InsertAction(int index)
    {
        List<string> objs = new List<string>();
        objs.Add(LevelFlowCtrl.getMethodList[0]);
        InitAction(objs);

        actions.Insert(index, new LevelAction(objs));
    }

    public void RemoveAction(int index)
    {
        DeleteEvent(index);

        actions.RemoveAt(index);
    }

    public void DeleteEvent(int actionIndex)
    {
        //是否外部事件
        int remoteIndex = GetExteralEventIndex(actionIndex);
        if (remoteIndex != -1)
        {
            //Debug.Log("the index is " + remoteIndex);
            //return;
            Transform t = eventParent.GetChild(remoteIndex);
            Debug.Log("remote  " + t.name);
            DestroyImmediate(t.gameObject);
        }
        else
        {
            //has't event
        }
    }

    /// <summary>
    /// 取事件在父对象之下的Index
    /// </summary>
    /// <param name="actionIndex">当前行动的Index</param>
    /// <returns>非外部事件返回-1</returns>
    public int GetExteralEventIndex(int actionIndex)
    {
        if (actions[actionIndex].action[0] != AllStrings.actWaitExternal)
        {
            return -1;
        }

        int index = -1;
        //查找这个在数组里面是第几个actWaitExternal
        for (int i = 0; i < actions.Count; i++)
        {
            if (actions[i].action[0] == AllStrings.actWaitExternal) { index++; }
            if (i == actionIndex)
            {
                return index;
            }
        }
        return -1;
    }

    /// <summary>
    /// 检查当前的方法与参数个数是否匹配
    /// </summary>
    /// <param name="methodName"></param>
    /// <param name="count"></param>
    /// <returns>合法为True</returns>
    public bool IsLegalAction(string methodName, int count)
    {
        MethodInfo mMethod = LevelFlowCtrl.instance.GetType().GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);
        ParameterInfo[] pis = mMethod.GetParameters();

        if (pis.Length != count) return false;

        return true;
    }

    public void InitAction(List<string> parameters, int index = -1)
    {
        if (parameters == null)
        {
            Debug.Log(" list is null ???????????");
            return;
        }

        string methodName = parameters[0];

        LevelFlowCtrl ctrl = GameObject.FindObjectOfType(typeof(LevelFlowCtrl)) as LevelFlowCtrl;

        MethodInfo mMethod = ctrl.GetType().GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);

        if (mMethod == null)
        {
            Debug.Log("method  is null ");
        }

        ParameterInfo[] pis = mMethod.GetParameters();

        //clear all 
        for (int i = 1; i < parameters.Count; ) { parameters.RemoveAt(i); }
        //add params
        for (int i = 0; i < pis.Length; ++i) { parameters.Add(""); }


        //Debug.Log(methodName + "--------------" + pis.Length + "   name--- " + methodName);

        switch (methodName)
        {
            case AllStrings.actCreateEnemy:
                //int id, string pos, int count, float disTime
                parameters[1] = 200001 + "";
                //位置索引
                parameters[2] = "0";
                parameters[3] = 1 + "";
                parameters[4] = 0.5f + "";

                break;
            case AllStrings.actWaitForTime:
            case AllStrings.actTimeOver:
                //time 1
                parameters[1] = 1f + "";
                break;
            case AllStrings.actSetMaxCount:
                parameters[1] = 1 + "";
                break;
            case AllStrings.actAddSuccessToEnemy:
                //id and pos
                parameters[1] = 200001 + "";
                //位置索引
                parameters[2] = "0";
                //缩放比例
                parameters[3] = "1";
                //Debug.Log("--------" + AllStrings.actAddSuccessToEnemy);
                break;
            case AllStrings.actWaitExternal:
                //外部事件添加 如果是插入到中间，需要手动移动代码
                AddEventTrigger();
                break;
            case AllStrings.actAddEnemiesToAllPos:
                parameters[1] = 200001 + "";
                //位置索引
                parameters[2] = "10";
                parameters[3] = 1 + "";
                break;
            default:
                Debug.Log("------------.no name " + methodName);
                break;
        }
    }

    public void SavePrefab()
    {
        ResetEvent();

        for (int i = 0; i < events.Count; i++)
        {
            events[i].SaveToPrefab();
            if (i == 0)
            {
                NGUITools.SetActive(events[i].gameObject, true);
            }
            else
            {
                NGUITools.SetActive(events[i].gameObject, false);
            }
        }
    }

#endif
    #endregion
}
