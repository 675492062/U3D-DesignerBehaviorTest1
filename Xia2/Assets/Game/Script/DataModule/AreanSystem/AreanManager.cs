using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class AreanManager : MonoBehaviour {
	public AreanUserInfo areanUserInfo = new AreanUserInfo();

	List<AreanRankData>  areanRankList = new List<AreanRankData>();
	List<AreanRecordData> areanRecordList = new List<AreanRecordData>();
	
	public AreanDetailInfo detailInfo = new AreanDetailInfo();
	
	public AreanUserInfo GetSelfRankData(){return areanUserInfo;}
	
	public List<AreanRankData> GetAreanRankList(){return areanRankList;}
	
	public List<AreanRecordData> GetAreanRecordList(){return areanRecordList;}
	
	public Action rankModifyAction;
	
	public void AddRankData(AreanRankData rankData){
		areanRankList.Add(rankData);
	}
	
	public void SortRankList(){
		areanRankList.Sort(delegate(AreanRankData x, AreanRankData y) {
			if(x.rankIndex == y.rankIndex)return 0;
			return x.rankIndex < y.rankIndex ? -1 : 1;
		});
		if(rankModifyAction != null){
			rankModifyAction();
		}
	}
	
	public void AddRecordData(AreanRecordData recordData){
		areanRecordList.Add(recordData);
	}
	
	public void InsertRecordData(AreanRecordData recordData){
		areanRankList.Insert(0 , recordData);
	}
	
	void Update(){
		if(areanUserInfo.countCdTime >=0)areanUserInfo.countCdTime -= Time.deltaTime;
	}
}