using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChapterAwardManager : MonoBehaviour {
	public Dictionary<int , ChapterAwardItem> awardDic = new Dictionary<int, ChapterAwardItem>();
	
	ChapterAwardItem LoadAward(int id){
		ChapterAwardItem item = new ChapterAwardItem(id);
		awardDic.Add(id , item);
		return item;
	}
	
	public ChapterAwardItem GetAwardItem(int id){
		if(awardDic.ContainsKey(id)){
			return awardDic[id];
		}
		return LoadAward(id);
	}
}