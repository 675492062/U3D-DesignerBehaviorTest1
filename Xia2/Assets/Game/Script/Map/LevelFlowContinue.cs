/****************************************************************************** 
 * 
 * Maintaince Logs: 
 * 2014-11-18   WP      Initial version: Added member
 *      12-08   WP      删除指示标（改为UI显示），加上是否最后一个外部事件
 *                      加入杀完小怪之后是否销毁的逻辑
 * 
 * *****************************************************************************/

using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// level flow external events
/// </summary>
public class LevelFlowContinue : MonoBehaviour
{
    public LevelFlowContinue nextEvent;

    public Transform parcloseParnet;

    /// <summary>
    /// 杀完敌人之后是否销毁Parclose
    /// </summary>
    public bool isDestroyParclose = false;

    /// <summary>
    /// 是否已经进入触发器：这个值将影响区分实例化与路标显示间的判断
    /// </summary>
    private bool isEnterTrigger = false;

    /// <summary>
    /// 是否是最后一个屏障
    /// </summary>
    public bool isLast
    {
        get { return nextEvent == null; }
    }

    private Transform prbParclose { get { return PrefabPool.prbParclose; } }

    void Start()
    {
        //Init();
    }

    public void Init()
    {
        //显示指路标 指向我
        Debug.Log("Show sign ------------", gameObject);
        UIBattleManager.instance.ShowSign(transform);

    }

    GameObject CreateParclose(Transform parent)
    {
        return Create(prbParclose.gameObject, parent);
    }

    GameObject Create(GameObject obj, Transform parent)
    {
        GameObject go = KMTools.AddGameObj(parent.gameObject, obj, true, true);
        go.transform.localEulerAngles = Vector3.zero;
        go.transform.localPosition = Vector3.zero;
        go.transform.localScale = Vector3.one;
        return go;
    }

    //触发事件
    void OnTriggerEnter(Collider other)
    {
        //隐藏指示标
        UIBattleManager.instance.HideSign();

        //通知游戏继续
        if (!isEnterTrigger && LevelFlowCtrl.instance.ExternalContinue())
        {
            isEnterTrigger = true;

            //UIBattleManager.instance.HideSign();

            //添加外部事件:杀完场景所有敌人
            LevelFlowCtrl.instance.executor.KillAllEvent += KillAllEvent;

            //触发屏蔽事件
            foreach (Transform t in parcloseParnet)
            {
                //可以被攻击设置
                Parclose lp = t.GetComponent<Parclose>();
                if (lp)
                {
                    lp.ExternalInit();
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        UIBattleManager.instance.ShowSign(transform);
    }

    /// <summary>
    /// 事件完成
    /// </summary>
    void KillAllEvent()
    {
        LevelFlowCtrl.instance.executor.KillAllEvent -= KillAllEvent;
        Debug.Log("Enemy is kill all  call back----------");

        //不在接受碰撞显示等
        GetComponent<Collider>().enabled = false;

        //对屏蔽进行销毁处理
        if (isDestroyParclose)
            foreach (Transform t in parcloseParnet)
            {
                //TODO 屏障破碎效果
                NGUITools.SetActive(t.gameObject, false);
            }

        //下一事件
        if (nextEvent != null)
        {
            NGUITools.SetActive(nextEvent.gameObject, true);
            nextEvent.Init();
        }
        else
        {
            Debug.Log("------the last");
        }

        enabled = false;
    }

#if UNITY_EDITOR

    private List<Transform> mParcloseList = new List<Transform>();
    public List<Transform> parcloseList
    {
        get
        {
            if (mParcloseList.Count != parcloseParnet.childCount)
            {
                mParcloseList.Clear();
                int i = 1;
                foreach (Transform t in parcloseParnet)
                {
                    t.name = "parclose" + i;
                    mParcloseList.Add(t);
                    i++;
                }
            }
            return mParcloseList;
        }
    }

    /// <summary>
    /// 添加屏障
    /// </summary>
    /// <returns></returns>
    public GameObject AddParclose()
    {
        //实例Prefab，Prefab自带Collider
        GameObject go = KMTools.AddGameObj(parcloseParnet.gameObject);
        go.AddComponent<Parclose>();


        return go;
    }

    /// <summary>
    /// editor only
    /// </summary>
    public void SaveToPrefab()
    {
        //新版本无需
        //foreach (Transform t in parcloseParnet)
        //{
        //    NGUITools.SetActive(t.gameObject, false);
        //}

        //foreach (Transform t in signParnet)
        //{
        //    NGUITools.SetActive(t.gameObject, true);
        //}
    }

#endif
}
