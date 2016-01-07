using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 关卡流程控制器 Debug 模式
/// 可选玩家等级，可选装备类型
/// 
/// Maintaince Logs: 
/// 2014-12-03  WP      Initial version
/// </summary>
public class LevelFlowDebug : MonoBehaviour
{
    private LevelFlowCtrl ctrl { get { return LevelFlowCtrl.instance; } }



    // Keeps the state of each individual foldout item during the editor session
    public Dictionary<object, bool> _editorListItemStates = new Dictionary<object, bool>();

    public bool isDebug = true;

    [SerializeField]
    public List<HeroDebugData> heroDatas = new List<HeroDebugData>();

    public List<HeroDebugData> otherPlayer = new List<HeroDebugData>();

    [System.Serializable]
    public class HeroDebugData
    {
        public int heroId;

        public int heroLevel = 1;

        public int heroStar = 1;


        //public List<int> equipId;
        //public List<int> equipLevel;

        public List<EquipData> equipment;

        [System.Serializable]
        public class EquipData
        {
            public int equipId;
            public int equipLevel;
        }
    }

    void Awake()
    {
        SetData();
    }

    bool isStart = false;
    void OnGUI()
    {
        if (isStart) return;
        if (GUILayout.Button(new GUIContent("Start", "Click it")))
        {
            isStart = true;
            BeginBattle();
        }
    }

    //设置数据
    void SetData()
    {
        // my player
        SetDatas(MonoInstancePool.getInstance<HeroManager>(), heroDatas);

        // other player
        SetDatas( MonoInstancePool.getInstance<EnemyHeroManager>(),otherPlayer);
    }

    void SetDatas(HeroManager manager, List<HeroDebugData> heroDatas)
    {
        HeroDebugData data;
        HeroData hero;
        for (int i = 0; i < heroDatas.Count; i++)
        {
            hero = new HeroData();
            data = heroDatas[i];

            //set max
            for (int j = 0; j < data.equipment.Count; j++)
            {
                EquipmentItem item = new EquipmentItem();
                Property.Equip e = new Property.Equip();

                if (data.equipment[j].equipId > 0 && data.equipment[j].equipLevel > 0)
                {
                    e.templateid = (uint)data.equipment[j].equipId;
                    item.parseData(e);

                    //Debug.Log(item.equitype);
                    //set level
                    item.equiplev = data.equipment[j].equipLevel;
                    hero.equipmentList.addItem(i * 10 + j, item);
                }
            }

            //set id level
            if (data.heroId > 0 && data.heroLevel > 0)
            {
                hero.templateID = data.heroId;
                hero.guid = (long)1111111 + i;
                hero.level = data.heroLevel;
                hero.property.country = i + 1;
                hero.activate = false;
                hero.battle = i;
                hero.starLevel = data.heroStar;

                hero.parseData(hero.templateID);

                hero.refreshProperty();
                manager.addHero(hero.guid, hero);
                Debug.Log("hero is init " + i + "   resname : " + hero.resname);
            }

            if (i < 3)
                manager.fightHeroList.setFightHero(hero.battle, hero.guid);
        }
    }


    void BeginBattle()
    {
        StartCoroutine(ctrl.Init());
    }

}
