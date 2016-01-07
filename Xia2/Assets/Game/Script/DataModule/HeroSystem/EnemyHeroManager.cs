using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class EnemyHeroManager : HeroManager
{
	public int playerGUID;//敌方玩家的唯一ID

	void Start()
	{
	}
//	public HeroData getCurFightHero()
//	{
//		if(curSelectHero < 0 || curSelectHero >= heroDict.Count)
//		{
//			//Debug.LogError("you have not selected any hero! curIdx:  " + curSelectHero);
//			return null;
//		}
//		return heroDict.ElementAt(curSelectHero).Value;
//	}
}
