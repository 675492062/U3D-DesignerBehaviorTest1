#if UNITY_EDITOR || (!UNITY_FLASH && !NETFX_CORE && !UNITY_WP8)
#define REFLECTION_SUPPORT
#endif

#if REFLECTION_SUPPORT
using System.Reflection;
#endif

using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// 关卡流程控制器流程事件函数
/// 
/// Maintaince Logs: 
/// 2014-12-03  WP      Initial version
///         11  WP      时间控制将不在由执行者处理，而是自己处理。
///         18  WP      时间计时改变，加入关卡完成后时间事件
/// 
/// </summary>
public partial class LevelFlowCtrl
{
    /// <summary>
    /// 当前游戏时间
    /// </summary>
    private float curTime = 0;

    /// <summary>
    /// 倒计时时间参数
    /// </summary>
    private float paramTimeOver = 0;

    /// <summary>
    /// 关卡是否已经结束
    /// </summary>
    private bool isFinish = false;

    public delegate void Timing(float time);

    /// <summary>
    /// 顺计时事件
    /// </summary>
    public event Timing EventCountUpTimer;

    /// <summary>
    /// 关卡倒计时事件
    /// </summary>
    public event Timing EventCountDownTimer;

    /// <summary>
    /// 能关时间
    /// </summary>
    public event Timing EventTimeByFinishedLevel;

    public void ExecuteAction()
    {
        if (!isWaitExternal)
        {
            if (curActionIndex >= actions.Count)
            {
                if (!isSetSuccess)
                {
                    StartCoroutine(executor.WaitForKillAndSuccess());
                    Debug.Log("Wait For Kill all And Success!!!!!!!!!!!");
                }
                return;
            }
            ToAction(actions[curActionIndex++].action);
        }
        else
        {
            Debug.LogError(" external was exist but is not execute");
        }
    }

    void ToAction(List<string> list)
    {
        string mMethodName = list[0];
        //list.RemoveAt(0);

        List<string> parameters = new List<string>();
        for (int i = 1; i < list.Count; i++)
        {
            parameters.Add(list[i]);
            //Debug.Log("-------param: " + list[i]);
        }

        Debug.Log(" -----------------To Action " + curActionIndex + "  " + mMethodName);

#if REFLECTION_SUPPORT
        MethodInfo mMethod = this.GetType().GetMethod(mMethodName, BindingFlags.Instance | BindingFlags.NonPublic);

        ParameterInfo[] pis = mMethod.GetParameters();

        if (pis.Length == 0)
        {
            //Debug.Log("param is 0");
            mMethod.Invoke(this, null);
        }
        else
        {
            mMethod.Invoke(this, parameters.ToArray());
        }
#else
        SendMessage(STR_SENDMSG_HEAD + mMethodName, parameters, SendMessageOptions.DontRequireReceiver);
#endif
    }

    #region Action ------------  Warning : Method name is Act******


    void SendMsgActAddSuccessToEnemy(object list)
    {
        if (list is List<string>)
        {
            List<string> parameters = list as List<string>;
            ActAddSuccessToEnemy(parameters[1], parameters[2], parameters[3]);
        }
        else
            Debug.LogError("Error param ");
    }

    void SendMsgActCreateEnemy(object list)
    {
        if (list is List<string>)
        {
            List<string> parameters = list as List<string>;
            ActCreateEnemy(parameters[1], parameters[2], parameters[3], parameters[4]);
        }
        else
            Debug.LogError("Error param ");
    }

    //int id, string pos, int count, float disTime
    void ActCreateEnemy(string id, string posIndex, string count, string disTime)
    {
        int ID = int.Parse(id);
        Vector3 POS = curConfig.enemyPos[int.Parse(posIndex)].position;
        int COUNT = int.Parse(count);
        float DISTIME = float.Parse(disTime);
        //object[] objs = new object[4] { ID, POS, COUNT, DISTIME };

        executor.AddEnemies(ID, COUNT, POS, DISTIME);
    }

    void ActWaitForTime(string time)
    {
        float TIME = float.Parse(time);
        executor.WaitForTime(TIME);
    }

    void ActSetMaxCount(string max)
    {
        int MAX = int.Parse(max);
        executor.SetMaxEnemyCount(MAX);
    }

    void ActWaitForKill()
    {
        executor.WaitForKillAll();
    }

    void ActTimeOver(string time)
    {
        float TIME = float.Parse(time);
        SetTimeOver(TIME);
        //执行一下事件
        ExecuteAction();
    }

    private bool isStartExternal = false;

    void ActWaitExternal()
    {
        if (!isStartExternal)
        {
            isStartExternal = true;
            Invoke("ShowSign", 2f);
        }
        //添加外部等待事件：这里为杀完所有敌人
        //List<string> objs = new List<string>();
        //objs.Add(AllStrings.actWaitForKill);
        //LevelAction ac = new LevelAction(objs);
        //actions.Insert(curActionIndex + 1, ac);
        //curActionIndex
        //Debug.Log(" ----------------------Wait  External");
        isWaitExternal = true;
    }

    void ShowSign()
    {
        if (curConfig.events.Count > 0)
        {
            curConfig.events[0].Init();
        }
    }

    void ActAddSuccessToEnemy(string id, string posIndex, string scale)
    {
        int ID = int.Parse(id);
        Vector3 POS = curConfig.enemyPos[int.Parse(posIndex)].position;
        float SCALE = float.Parse(scale);

        executor.AddSuccessToLast(ID, POS, SCALE);
        //wait call back
        isSetSuccess = true;
    }

    /// <summary>
    /// 添加敌人到每个点： 18波用
    /// </summary>
    void ActAddEnemiesToAllPos(string enemyId, string count, string timeByPosCount)
    {
        int id = int.Parse(enemyId);
        int COUNT = int.Parse(count);
        float time = float.Parse(timeByPosCount);

        executor.AddEnemiesToAllPos(id, COUNT, time, curConfig.enemyPos);
    }

    #endregion

    public void SetTimeOver(float time)
    {
        //顺计时显示结束
        CancelInvoke("CountUpTimer");

        paramTimeOver = time;

        StartCoroutine(BeginTimeOver());

        UIBattleManager.instance.LoginCountDownTimer();
        UIBattleManager.instance.LogoutCountUp();
        InvokeRepeating("CountDownTimer", 0f, 1f);
        //Debug.Log("------------timer");
    }

    private IEnumerator BeginTimer()
    {
        while (!isFinish)
        {
            curTime += Time.deltaTime;
            yield return null;
        }
    }

    private IEnumerator BeginTimeOver()
    {
        while (paramTimeOver > 0)
        {
            paramTimeOver -= Time.deltaTime;
            yield return null;
        }

        TimeOver();
    }

    private void TimeOver()
    {
        //TODO: UI不同显示 
        Debug.Log("Time over ");
        Failed();
    }

    private void CountUpTimer()
    {
        if (EventCountUpTimer != null)
        {
            EventCountUpTimer(curTime);
        }
    }

    private void CountDownTimer()
    {
        if (EventCountDownTimer != null)
        {
            EventCountDownTimer(paramTimeOver);
        }
    }

    /// <summary>
    /// 击杀兵营
    /// </summary>
    public void KillBarrackEvent()
    {
        //未设置成功事件或者已经成功
        if (killBarracks <= 0)
        {
            return;
        }

        killBarracks--;
        Debug.Log("kill ------------" + killBarracks);
        if (killBarracks <= 0)
        {
            Success();
        }
    }

    /// <summary>
    /// 击杀城门
    /// </summary>
    public void KillGateEvent()
    {
        //未设置成功事件或者已经成功
        if (killGates <= 0)
        {
            return;
        }

        killGates--;
        Debug.Log("Kill ----------- gate " + killGates);
        if (killGates <= 0)
        {
            Success();
        }
    }



    #region editor

#if UNITY_EDITOR

    static List<string> mListMethods;
    public static List<string> getMethodList
    {
        get
        {
            if (instance == null)
            {
                Debug.Log("  -----------instance is null");
                return null;
            }

            if (mListMethods == null)
            {
                mListMethods = new List<string>();
                MethodInfo[] infos = instance.GetType().GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
                for (int i = 0; i < infos.Length; ++i)
                {
                    MethodInfo mi = infos[i];

                    if (mi.ReturnType == typeof(void))
                    {
                        string methodName = mi.Name;
                        //Debug.Log(name);
                        if (!methodName.StartsWith("Act")) continue;
                        if (mListMethods.Contains(methodName)) continue;

                        mListMethods.Add(mi.Name);
                    }
                }
            }

            return mListMethods;
        }
    }

    public Camera GetCamera()
    {
        return heroCamera;
    }
#endif
    #endregion
}
