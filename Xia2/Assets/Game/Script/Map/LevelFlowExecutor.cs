/****************************************************************************** 
 * 
 * Maintaince Logs: 
 * 2014-11-11   WP      Initial version: Added member
 *      12-11   WP      加入一些事件。执行者将执行流程和注册的事件。
 * 
 * *****************************************************************************/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// the script is attach LevelFlowCtrl.provide some methods such as create enemies
/// </summary>
public class LevelFlowExecutor : MonoBehaviour
{
    private int existingEnemyCount { get { return enemyCtrl.existingEnemyCount; } }

    private int maxEnemyCount = 15;

    private delegate IEnumerator UpdateEvent();

    private UpdateEvent waitEvent;

    public delegate void ExternalEvent();
    public event ExternalEvent KillAllEvent;

    private float paramWaitTime = 0;

    private float paramDisTime = 0;
    private int paramCount = 0;
    private int paramEnemyID = 0;
    private Vector3 paramPos;

    private EnemyCtrl enemyCtrl
    {
        get
        {
            return EnemyCtrl.instance;
        }
    }

    /// <summary>
    /// success or failed
    /// </summary>
    private bool isOver = false;

    public static float createRange { get { return EnemyCtrl.createRange; } }

    #region public methods of Ctrl

    public void AddEnemies(int id, int count, Vector3 pos, float disTime)
    {
        paramCount = count;
        paramDisTime = disTime;
        paramPos = pos;
        paramEnemyID = id;

        waitEvent = EventAddEnemy;
        StartCoroutine(waitEvent());
    }

    public void WaitForTime(float time)
    {
        paramWaitTime = time + Time.time;
        waitEvent = EventTimingWaitForTime;
        StartCoroutine(waitEvent());
    }

    public void WaitForKillAll()
    {
        waitEvent = EventWaitForKillAll;
        StartCoroutine(waitEvent());
    }

    public void SetMaxEnemyCount(int max)
    {
        maxEnemyCount = max;
    }

    public void AddSuccessToLast(int id, Vector3 pos, float scale)
    {
        Enemy e = enemyCtrl.AddEnemy(id, pos, true);

        e.deadEvent += EnemySuccess;

        e.transform.localScale *= scale;
        Debug.Log("------------------- Add success ", e);
        CompletedEvent();
    }

    public void AddEnemiesToAllPos(int id, int count, float time, List<Transform> pos)
    {
        StartCoroutine(EventAddEnemiesToAllPos(id, count, time, pos));
    }

    public IEnumerator WaitForKillAndSuccess()
    {
        while (existingEnemyCount > 0) yield return null;
        LevelFlowCtrl.instance.Success();
    }

    #endregion

    #region effect, ui Event

    public void Success()
    {
        if (!isOver)
        {
            isOver = true;
            StartCoroutine(ExcuteSuccess());


        }
    }

    private IEnumerator ExcuteSuccess()
    {
        //Effect:
        Camera.main.GetComponent<CamMove>().ZoomIn(9, 16, 12f);
        Time.timeScale = 0.25f;
        Camera.main.GetComponent<MotionBlur>().blurAmount = 0.8f;
        Camera.main.GetComponent<MotionBlur>().enabled = true;
        yield return new WaitForSeconds(0.6f);
        //InvokeRepeating("OnGameOver", 0.6f, 0.1f);

        //FIX:
        //script_cha.m_curStat = 0;
        Camera.main.GetComponent<MotionBlur>().enabled = false;
        Time.timeScale = 1;

        //UI:
        UIBattleManager.instance.ShowGameEnd(true);
    }

    public void Failed()
    {
        if (!isOver)
        {
            isOver = true;

            //ui
            UIBattleManager.instance.ShowGameEnd(false);
            //stop event 
            if (waitEvent != null) StopCoroutine(waitEvent());
        }
    }

    #endregion

    #region Wait Event

    /// <summary>
    /// 遍历所有的点生成怪，遍历完一次后等待时长，再生成一次
    /// </summary>
    /// <param name="id"></param>
    /// <param name="count"></param>
    /// <param name="time"></param>
    /// <returns></returns>
    private IEnumerator EventAddEnemiesToAllPos(int id, int count, float time, List<Transform> pos)
    {
        int createCount = 0;

        while (createCount < count)
        {
            for (int i = 0; i < pos.Count; i++)
            {
                while (existingEnemyCount >= maxEnemyCount) yield return null;
                enemyCtrl.AddEnemy(id, pos[i].position, false);
                createCount++;
                if (createCount >= count) break;
            }
            if (time > 0)
                yield return new WaitForSeconds(time);
        }

        CompletedEvent();
    }

    private IEnumerator EventAddEnemy()
    {
        //Enemy prefab = enemyCtrl.GetPrefab(paramEnemyID);
        int count = paramCount;
        float disTime = paramDisTime;
        Vector3 pos = paramPos;

        enemyCtrl.AddEnemy(paramEnemyID, pos, true);
        //existingEnemyCount++;
        count--;
        yield return new WaitForSeconds(disTime);

        for (int i = 0; i < count; i++)
        {
            if (i != 0) yield return new WaitForSeconds(disTime);

            while (existingEnemyCount >= maxEnemyCount) yield return null;

            enemyCtrl.AddEnemy(paramEnemyID, pos, true);
        }

        CompletedEvent();
    }

    private IEnumerator EventWaitForKillAll()
    {
        while (existingEnemyCount > 0) yield return null;

        Debug.Log("---------is kill  and cur " + existingEnemyCount);
        if (KillAllEvent != null) KillAllEvent();
        CompletedEvent();
    }

    private IEnumerator EventTimingWaitForTime()
    {
        while (Time.time <= paramWaitTime) yield return null;
        CompletedEvent();
    }

    #endregion

    private void CompletedEvent()
    {
        waitEvent = null;
        LevelFlowCtrl.instance.ExecuteAction();
    }

    /// <summary>
    /// 敌人死亡触发成功
    /// </summary>
    /// <param name="enemyid"></param>
    private void EnemySuccess(int enemyid)
    {
        LevelFlowCtrl.instance.Success();
    }

    #region 外部独立事件

    /// <summary>
    /// 外部独立事件 生成敌人
    /// </summary>
    /// <param name="enemyID"></param>
    /// <param name="enemyCount"></param>
    /// <param name="timeParam"></param>
    /// <param name="createPos"></param>
    /// <returns></returns>
    public IEnumerator AddEnemies(int enemyID, float timeParam, Vector3 createPos, GameObject target)
    {
        float disTime = timeParam;
        Vector3 pos = createPos;

        enemyCtrl.AddEnemy(enemyID, pos, false);

        yield return new WaitForSeconds(disTime);

        //如果传过来的Target 不为空，会一直循环
        while (target != null)
        {
            yield return new WaitForSeconds(disTime);

            while (existingEnemyCount >= maxEnemyCount) yield return null;
            if (target != null)
                enemyCtrl.AddEnemy(enemyID, pos, false);
        }
    }

    #endregion
}
