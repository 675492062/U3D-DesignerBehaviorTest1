using UnityEngine;
using System.Collections;

public class DragModerRender : MonoBehaviour {

    public GameObject target;
    private bool mStarted = false;
    private bool starMove = false;
    public float speed = 1f;
	public int idx; //1:center  战斗列表第一个; 2: left 战斗列表第二个; 3: right 战斗列表第三个
	// Use this for initialization
	void Start () {
        mStarted = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnEnable()
    {
        starMove = true;    
    }

    void OnPress(bool pressed)
    {
        starMove = true;
    }

    void OnDrag(Vector2 delta)
    {
        
        if (starMove)
        {

            if (target != null)
            {
                target.transform.localRotation = Quaternion.Euler(0f, -0.5f * delta.x * speed, 0f) * target.transform.localRotation;
            }
        }
        
    }
	void OnClick()
	{
//		if(idx == 0)
//		{
//			return;
//		}
//		FightHeroList list = MonoInstancePool.getInstance<HeroManager> ().fightHeroList;
//		bool has = list.hasKey (idx);
//		if(has)
//		{
//			long guid = list.getGuidByKey(idx);
//			int idx = MonoInstancePool.getInstance<HeroManager>().getIdxByGUID(guid);
//			MonoInstancePool.getInstance<HeroManager>().curSelectHero = idx;
//			MonoInstancePool.getInstance<HeroManager>().curSelectHeroGUID = guid;
//		}
	}
}
