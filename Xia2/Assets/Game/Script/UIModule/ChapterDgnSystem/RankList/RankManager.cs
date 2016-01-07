using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RankerStruct{
	public int rankIndex;
	
	public string name;
	
	public int level;
	
	public int vipLevel;
	
	public int totalStarNum;
}

public class RankManager : MonoBehaviour {

	List<RankerStruct> rankersList = new List<RankerStruct>();
		
	public RankerStruct userRanker{set;get;}
	
	public void AddRankerByIndex(RankerStruct ranker){
		rankersList.Add(ranker);
	}
	
	public RankerStruct GetRanker(int rankIndex){
		return rankersList[rankIndex];
	}

	public List<RankerStruct> GetRankList(){
		if(rankersList.Count == 0){
			for(int i = 0 ; i < 50 ; i++){
				RankerStruct ranker = new RankerStruct();
				ranker.rankIndex = (i + 1);
				ranker.name = "Player " + (i + 1);
				ranker.level = (i + 1);
				ranker.vipLevel = 1;
				ranker.totalStarNum = (50 - i) * 100 + UnityEngine.Random.Range(10 , 100);
				rankersList.Insert(i , ranker);
			}
		}
		return rankersList;
	}
}