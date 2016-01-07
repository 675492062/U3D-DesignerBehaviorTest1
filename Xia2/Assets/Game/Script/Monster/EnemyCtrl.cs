/****************************************************************************** 
 * 
 * Maintaince Logs: 
 * 2014-11-20   WP      Initial version: Added member
 * 
 * *****************************************************************************/

using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// enemies creater and some effect 
/// </summary>
public class EnemyCtrl : MonoBehaviour
{
    private static EnemyCtrl mInstance;
    public static EnemyCtrl instance
    {
        get
        {
            if (mInstance == null)
            {
                mInstance = GameObject.FindObjectOfType(typeof(EnemyCtrl)) as EnemyCtrl;

                if (mInstance == null)
                {
                    mInstance = KMTools.AddGameObj(null).AddComponent<EnemyCtrl>();
                    mInstance.name = "EnemyCtrl";
                }
            }
            return mInstance;
        }
    }

    private Transform mEnemiesParent;
    private Transform enemyParent
    {
        get
        {
            if (mEnemiesParent == null)
            {
                GameObject go = KMTools.AddGameObj(gameObject);
                go.name = "EnemyParnet";
                mEnemiesParent = go.transform;
            }
            return mEnemiesParent;
        }
    }

    private Transform mEffectParent;
    private Transform effectParent
    {
        get
        {
            if (mEffectParent == null)
            {
                GameObject go = KMTools.AddGameObj(gameObject);
                go.name = "EffectParnet";
                mEffectParent = go.transform;
            }
            return mEffectParent;
        }
    }

    const int maxMonDestroyCount = 4;
    private Object[] mMonDestroy;
    public Object[] monDestroy
    {
        get
        {
            if (mMonDestroy == null)
            {
                mMonDestroy = new Object[maxMonDestroyCount];
                string resName = "";
                for (int i = 0; i < maxMonDestroyCount; i++)
                {
                    resName = AllStrings.PATH_ENEMIES + AllStrings.FILE_HEAD_ENEMY_DESDORY + (i + 1);
                    //Debug.Log("-----------------" + resName);
                    mMonDestroy[i] = Resources.Load(resName);
                }
            }
            return mMonDestroy;
        }
    }

    int destroy_human_kind = 0;
    int destroy_beast_kind = 3;
    int destroy_last_kind = 0;
    Transform[] clone_destroy = new Transform[6];

    private List<Enemy> prbEnemies = new List<Enemy>();

    /// <summary>
    /// 杀怪统计： ID ：数量
    /// </summary>
    private Dictionary<int, int> dictEnemyKills = new Dictionary<int, int>();

    public delegate void DelEnemyKills(Dictionary<int, int> dict);

    public event DelEnemyKills enemyKillsEvent;

    private int kills = 0;

    public delegate void DelKills(int num);

    public event DelKills killsEvent;

    public int existingEnemyCount { get { return enemyParent.childCount; } }

    public static float createRange = 0.32f;

    void Start()
    {
        GameObject go;
        for (int i = 0; i < 3; ++i)
        {
            go = (GameObject)Instantiate(monDestroy[i], Vector3.one * 6, Quaternion.identity);
            clone_destroy[i] = go.transform;
            go = (GameObject)Instantiate(monDestroy[3], Vector3.one * 6, Quaternion.identity);
            clone_destroy[i + 3] = go.transform;

            clone_destroy[i].parent = effectParent;
            clone_destroy[i + 3].parent = effectParent;
        }
    }

    private Vector3 AroundPos(Vector3 pos)
    {
        pos.x += Random.Range(-createRange, createRange);
        pos.z += Random.Range(-createRange, createRange);
        return pos;
    }

    private Enemy GetPrefab(int enemyId)
    {
        string resName = StaticMonster.Instance().getStr(enemyId, "resname");
        Enemy prefab = null;

        foreach (Enemy e in prbEnemies)
        {
            if (e.name == resName) { prefab = e; break; }
        }

        if (prefab == null)
        {
            GameObject go = (GameObject)Resources.Load(AllStrings.PATH_ENEMIES + resName);
            //Debug.Log("res Name is    " + resName);
            prefab = go.GetComponent<Enemy>();
            if (prefab == null) Debug.LogError("the enemy script is null");
            else
            {
                prbEnemies.Add(prefab);
            }
        }

        return prefab;
    }

    public Enemy AddEnemy(int enemyID, Vector3 pos)
    {
        Enemy prefab = GetPrefab(enemyID);

        Enemy e = KMTools.AddChild<Enemy>(enemyParent.gameObject, prefab, false, true);
        Vector3 createPos = pos;

        // 晓华的状态机必须设置位置
        e.setOriginPos(createPos);
        e.setTemplateID(enemyID);

        //添加死亡事件。为了统计是哪个英雄杀死的
        e.deadEvent += EventCountToNum;

        return e;
    }

    public Enemy AddEnemy(int enemyID, Vector3 pos, bool aroundPos)
    {
        Vector3 createPos = pos;
        if (aroundPos) createPos = AroundPos(pos);
        return AddEnemy(enemyID, createPos);
    }

    //记录当前是哪个英雄击杀的
    public void EventCountToNum(int id)
    {
        if (id > 100)
            MonoInstancePool.getInstance<FightManager>().killEnemyEvent(id, ObjectManager.instance.myPlayer.GetCurCharData().guid);
        else Debug.Log("-------------the id is error-----" + id);

        //本地统计 敌人ID + 数量
        if (dictEnemyKills.ContainsKey(id))
        {
            dictEnemyKills[id]++;
        }
        else
        {
            dictEnemyKills.Add(id, 1);
        }

        if (enemyKillsEvent != null)
        {
            enemyKillsEvent(dictEnemyKills);
        }
        //本地统计 数量
        kills++;
        if (killsEvent != null)
        {
            killsEvent(kills);
        }
    }

    //死亡效果
    public void EnemyDead(int _destroy, Vector3 _pos, Texture _tex, Vector3 _scale, Vector3 _forcedir)
    {
        //TODO by wp:
        _destroy = 2;

        int randomY = Random.Range(0, 360);

        if (_destroy == 2)
        {
            clone_destroy[destroy_human_kind].position = _pos + _forcedir * 0.15f;
            clone_destroy[destroy_human_kind].rotation = Quaternion.Euler(0, randomY, 0);
            clone_destroy[destroy_human_kind].GetComponent<Mon_Destroy>().TextureChange(_tex, _scale, _destroy);
            clone_destroy[destroy_human_kind].gameObject.SetActive(true);
            destroy_human_kind = 0;//(destroy_human_kind +1)%3;
            destroy_last_kind = 0;//destroy_human_kind;
        }
        else if (_destroy == 1)
        {
            clone_destroy[destroy_beast_kind].position = _pos + _forcedir * 0.15f;
            clone_destroy[destroy_beast_kind].rotation = Quaternion.Euler(0, randomY, 0);
            clone_destroy[destroy_beast_kind].GetComponent<Mon_Destroy>().TextureChange(_tex, _scale, _destroy);
            clone_destroy[destroy_beast_kind].gameObject.SetActive(true);
            destroy_beast_kind = (destroy_beast_kind + 1) % 3 + 3;
            destroy_last_kind = destroy_beast_kind;
        }
        else if (_destroy == 3)
        {
            clone_destroy[destroy_last_kind].position = _pos;
            clone_destroy[destroy_last_kind].rotation = Quaternion.Euler(0, randomY, 0);

            if (destroy_last_kind < 3)
                _destroy = 2;
            else
                _destroy = 1;
            clone_destroy[destroy_last_kind].GetComponent<Mon_Destroy>().TextureChange(_tex, _scale, _destroy);
            clone_destroy[destroy_last_kind].gameObject.SetActive(true);
            destroy_last_kind = (destroy_last_kind + 1) % 6;
            //Debug.Log(destroy_last_kind);
            //destroy_beast_kind = (destroy_beast_kind +1)%3 +3;
        }

        //Todo Lee
        //		if (script_IngameUI.GetExp(_destroy))
        //		{
        //			clone_soul[soulcount].gameObject.active = true;
        //			clone_soul[soulcount].position = _pos;
        //			soulcount = (soulcount+1)%3;
        //		}
    }
}
