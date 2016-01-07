using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 关卡战斗中的一个成就
/// 
/// Maintaince Logs: 
/// 2014-12-16  WP      Initial version
///         17  WP      添加数据类型
///         19  WP      加入UI、战斗两种不同的描述
/// </summary>
[System.Serializable]
public class LevelAchievem
{

    [SerializeField]
    private int mId = 0;
    /// <summary>
    /// 成就ID，取表用
    /// </summary>
    public int id
    {
        get
        {
            return mId;
        }
        set
        {
            if (mId != value)
            {
                mId = value;
                CalcParamCount();
                SetDesc(true);
            }
        }
    }

    /// <summary>
    /// 数量描述的开始值（改变值）
    /// </summary>
    [SerializeField]
    private int numStart = 0;

    /// <summary>
    /// 数量描述的线束值
    /// </summary>
    [SerializeField]
    private int numEnd = 0;

    /// <summary>
    /// 是否有数量的变化值
    /// </summary>
    [SerializeField]
    private bool isNumDesc = false;

    private StaticDungeon_star datas { get { return StaticDungeon_star.Instance(); } }

    /// <summary>
    /// 成就类型：用于事件判断
    /// "类型
    ///1：击杀10个狼
    ///2：击杀10个怪
    ///3：张飞上阵
    ///4：收集10个刀
    ///5：所有英雄血量不曾低于20%
    ///6：无英雄阵亡
    ///7：90秒内通关
    /// </summary>
    public int type
    {
        get
        {
            return datas.getInt(id, "type");
        }
    }

    /// <summary>
    /// 成就名 例： 击杀{0}个{1}
    /// </summary>
    public string name { get { return datas.getStr(id, "name"); } }

    /// <summary>
    ///0：无
    ///1：怪物id
    ///2：英雄id
    ///3：NPCid
    ///4：数量
    /// </summary>
    public ParamType parameterType1 { get { return (ParamType)datas.getInt(id, "parameter1"); } }
    public ParamType parameterType2 { get { return (ParamType)datas.getInt(id, "parameter2"); } }
    public ParamType parameterType3 { get { return (ParamType)datas.getInt(id, "parameter3"); } }

    [SerializeField]
    private int mP1;
    /// <summary>
    /// 制作人员输入的参数1
    /// </summary>
    public int param1
    {
        get { return mP1; }
        set
        {
            if (value != mP1)
            {
                mP1 = value;
                SetDesc(true);
            }
        }
    }

    [SerializeField]
    private int mP2;
    /// <summary>
    /// 制作人员输入的参数2
    /// </summary>
    public int param2
    {
        get { return mP2; }
        set
        {
            if (value != mP2)
            {
                mP2 = value;
                SetDesc(true);
            }
        }
    }

    [SerializeField]
    private int mP3;
    /// <summary>
    /// 制作人员输入的参数3
    /// </summary>
    public int param3
    {
        get { return mP3; }
        set
        {
            if (value != mP3)
            {
                mP3 = value;
                SetDesc(true);
            }
        }
    }

    /// <summary>
    /// 参数的数量
    /// </summary>
    public int paramsCount = 0;

    /// <summary>
    /// 这个成就在战斗之中的描述
    /// </summary>
    public string descForGame = "";

    /// <summary>
    /// 这个成就在菜单中的描述
    /// </summary>
    public string descForMenu = "";

    /// <summary>
    /// 参数类型枚举
    /// </summary>
    public enum ParamType
    {
        None = 0,//0：无
        Enemy,//1:怪物id           
        Hero,//2：英雄id           
        NPC,//3：npcid           
        Number,//4：数量
    }

    public delegate void DelAchievemChange(bool isCompleted, string desc);

    /// <summary>
    /// 当成就描述改变的事件 战斗实时
    /// </summary>
    public event DelAchievemChange onAchievemChange;

    /// <summary>
    /// 当成就描述改变的事件 UI
    /// </summary>
    public event DelAchievemChange onAchievemChangeWithUI;

    /// <summary>
    /// 取这个成就在UI界面的描述
    /// </summary>
    /// <returns></returns>
    private string GetDesc()
    {
        string[] strs = new string[paramsCount];

        if (paramsCount > 0)
        {
            strs[0] = GetParamDesc(parameterType1, param1);
        }
        else
        {
            return name;
        }
        if (paramsCount > 1)
        {
            strs[1] = GetParamDesc(parameterType2, param2);
        }
        if (paramsCount > 2)
        {
            strs[2] = GetParamDesc(parameterType3, param3);
        }

        //Debug.Log(name + "------" + strs.Length);
        return string.Format(name, strs);
    }

    /// <summary>
    /// 设置这个成就的描述
    /// </summary>
    /// <returns></returns>
    private string SetDesc(bool isSetMenuDesc = false)
    {
        if (isSetMenuDesc)
            descForMenu = GetDesc();
        //初始化 数量描述
        isNumDesc = false;

        if (paramsCount > 0)
        {
            //判断是否有数量的改变
            if (parameterType1 == ParamType.Number)
            {
                isNumDesc = true;
                numEnd = param1;
            }
        }
        if (paramsCount > 1)
        {
            if (parameterType2 == ParamType.Number)
            {
                isNumDesc = true;
                numEnd = param2;
            }
        }
        if (paramsCount > 2)
        {
            if (parameterType3 == ParamType.Number)
            {
                isNumDesc = true;
                numEnd = param3;
            }
        }

        descForGame = descForMenu;

        if (isNumDesc)
        {
            descForGame += "({0}/" + numEnd + ")";
            descForGame = string.Format(descForGame, numStart);
            //Debug.Log(" num sum:" + numEnd + "-------numStart : " + numStart);
        }

        return descForGame;
    }

    /// <summary>
    /// 计算参数的数量
    /// </summary>
    /// <returns></returns>
    private int CalcParamCount()
    {
        paramsCount = 0;
        if (parameterType1 > 0) { paramsCount++; if (parameterType2 > 0) { paramsCount++; if (parameterType3 > 0)paramsCount++; } }
        return paramsCount;
    }

    /// <summary>
    /// 取一个参数对应的描述
    /// </summary>
    /// <param name="tp">参数类型</param>
    /// <returns></returns>
    private string GetParamDesc(ParamType tp, int targetId)
    {
        string desc = "";
        switch (tp)
        {
            case ParamType.Hero:
                desc = HeroItem.GetData(targetId).name;
                break;
            case ParamType.Enemy:
                desc = StaticMonster.Instance().getStr(targetId, "name");
                break;
            case ParamType.NPC:
                desc = "(NPC没有表，需要添加)";
                break;
            case ParamType.Number:
                desc = targetId.ToString();
                break;
            default:
                Debug.Log("----------please add to -----");
                break;
        }
        return desc;
    }

    #region Event

    bool isOver = false;

    [HideInInspector]
    /// <summary>
    /// 用于判断状态true 为亮，false为灰
    /// </summary>
    public bool isFinished = false;

    /// <summary>
    /// 击杀 N 个 敌人ID
    /// </summary>
    /// <param name="dict">敌人ID，数量</param>
    public void EventKillEnemies(Dictionary<int, int> dict)
    {
        if (isOver) return;
        if (dict.ContainsKey(param2))
        {
            numStart = dict[param2];
            SetDesc();

            if (dict[param2] >= param1)
            {
                Finished();
            }
            else OnChangeAchievem();
        }
    }

    /// <summary>
    /// 击杀 N 个敌人
    /// </summary>
    public void EventKills(int count)
    {
        if (isOver) return;

        numStart = count;
        SetDesc();

        if (count >= param1) Finished();
        else OnChangeAchievem();
    }

    /// <summary>
    /// 触发 数量 的 物品ID
    /// </summary>
    /// <param name="dict">物品ID，数量</param>
    public void EventFindSomething(Dictionary<int, int> dict)
    {
        if (isOver) return;
        if (dict.ContainsKey(param2))
        {
            numStart = dict[param2];
            SetDesc();

            if (dict[param2] >= param1)
            {
                Finished();
            }
            else OnChangeAchievem();
        }
    }

    /// <summary>
    /// 英雄的血量是否少于 数量
    /// </summary>
    /// <param name="percent"></param>
    public void EventCheckHeroHp(float percent)
    {
        if (isOver) return;
        percent *= 100;
        if (percent < param1)
        {
            Losed();
        }
    }

    /// <summary>
    /// 英雄是否死亡
    /// </summary>
    public void EventHeroDead(int id)
    {
        if (isOver) return;
        Losed();
    }

    /// <summary>
    /// 通关时间超过多少秒，此事件游戏结束时调用
    /// </summary>
    public void EventLevelTimeLimit(float time)
    {
        if (isOver) return;
        if (time > param1)
        {
            Losed();
        }
        else
        {
            Finished();
        }
    }

    public void Finished()
    {
        isOver = true;
        isFinished = true;
        OnChangeAchievem();
    }

    public void Losed()
    {
        isOver = true;
        isFinished = false;
        OnChangeAchievem();
    }

    /// <summary>
    /// 关卡成就 性质、描述发生改变时
    /// </summary>
    /// <param name="ach"></param>
    public void OnChangeAchievem()
    {
        if (onAchievemChange != null)
        {
            onAchievemChange(isFinished, descForGame);
        }
        if (onAchievemChangeWithUI != null)
        {
            onAchievemChangeWithUI(isFinished, descForMenu);
        }
    }

    #endregion
}