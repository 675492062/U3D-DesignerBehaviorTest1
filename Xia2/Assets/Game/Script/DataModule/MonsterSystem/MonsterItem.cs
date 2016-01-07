/****************************************************************************** 
 * 
 * Maintaince Logs: 
 * 2014-10-09   WP      Initial version: Added member
 * 
 * *****************************************************************************/

using UnityEngine;
using System.Collections;

public class MonsterItem : BaseItem
{
    private StaticMonster datas { get { return StaticMonster.Instance(); } }

    public int id { get { return datas.getInt(templateID, "id"); } }
    public string icon { get { return datas.getStr(templateID, "icon"); } }
    public string name { get { return datas.getStr(templateID, "name"); } }
    /// <summary>
    /// 资源名
    /// </summary>
    public string resname { get { return datas.getStr(templateID, "resname"); } }
    public int level { get { return datas.getInt(templateID, "level"); } }
    public int exp { get { return datas.getInt(templateID, "exp"); } }
    public int life { get { return datas.getInt(templateID, "life"); } }

    public int MIN_attack { get { return datas.getInt(templateID, "MIN_attack"); } }
    public int MAX_attack { get { return datas.getInt(templateID, "MAX_attack"); } }
    public int armor { get { return datas.getInt(templateID, "armor"); } }

    /// <summary>
    /// 无双段
    /// </summary>
    public int manapoint { get { return datas.getInt(templateID, "manapoint"); } }
    /// <summary>
    /// 命中等级
    /// </summary>
    public int hitlv { get { return datas.getInt(templateID, "hitlv"); } }
    /// <summary>
    /// 上臂等级
    /// </summary>
    public int dodgelv { get { return datas.getInt(templateID, "dodgelv"); } }
    /// <summary>
    /// 暴击等级
    /// </summary>
    public int criticallv { get { return datas.getInt(templateID, "criticallv"); } }
    /// <summary>
    /// 韧性等级
    /// </summary>
    public int tenacitylv { get { return datas.getInt(templateID, "tenacitylv"); } }
    /// <summary>
    /// 攻击速度
    /// </summary>
    public int atkspd { get { return datas.getInt(templateID, "atkspd"); } }
    /// <summary>
    /// 移动速度
    /// </summary>
    public int movspd { get { return datas.getInt(templateID, "movspd"); } }
    /// <summary>
    /// 攻击范围
    /// </summary>
    public int atkrange { get { return datas.getInt(templateID, "atkrange"); } }

    //TODO: 表里面还有很多
    


    
    
    public string describe { get { return datas.getStr(templateID, "describe"); } }
    public int realm { get { return datas.getInt(templateID, "realm"); } }

    public MonsterItem() { }

    private static MonsterItem mInstance;
    public static MonsterItem GetData(int templateID)
    {
        if (mInstance == null)
        {
            mInstance = new MonsterItem();
        }
        mInstance.templateID = templateID;
        return mInstance;
    }


}
