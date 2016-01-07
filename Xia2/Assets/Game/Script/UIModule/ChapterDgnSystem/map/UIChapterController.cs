using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//每个章节ui管理类
public class UIChapterController : MonoBehaviour {	
	public Transform dungeonSpawnPointsParent;
	
	public RouteController routeController;
	
	public ChapterStruct chapterData{private set;get;}
	
	List<GameObject> dungeonList;
				
	void Awake(){
		dungeonList = new List<GameObject>();
	}
	
	#region bindingData
	public void BindingData(ChapterStruct newData){
		if(this.chapterData == null){
			this.chapterData = newData;
			RegistAction();
			return;
		}
		UnRegistAction();
		this.chapterData = newData;
		RegistAction();
	}
	
	void RegistAction(){
		if(this.chapterData == null)return;
		this.chapterData.levelChangeAction += LevelChangeAction;
	}
	
	void UnRegistAction(){
		if(this.chapterData == null)return;
		this.chapterData.levelChangeAction -= LevelChangeAction;
	}
	
	#endregion 
	
	#region action
	
	void LevelChangeAction(){
		for(int i = 0 ; i < dungeonList.Count ; i++){
			var dungeon = (DungeonScript)dungeonList[i].GetComponent(typeof(DungeonScript));
			int dungeonId = dungeon.DungeonData.id;
			dungeon.BindingData(chapterData.GetDungeonByLevelAndId(chapterData.Level , dungeonId));
		}
		FreshUI();
	}
	#endregion

	public void FreshUI(){
		if(this.chapterData == null){
			Debug.LogError("[UIChapterController].chapterData is Null");
			return;
		}
		DrawChapterMaps();
		routeController.SpawnRoutes();
	}
	
	void DrawChapterMaps()
	{	
		if(dungeonList.Count == 0){
			Dictionary<int , int> dungeons = chapterData.baseData.GetDungeonIdDic();
			int childcount = dungeonSpawnPointsParent.childCount;
			for(int i = 0 ; i < childcount ; i++){
				Transform transform = dungeonSpawnPointsParent.GetChild(i); 
				
				string pointName = transform.name;
				int index = int.Parse(pointName.Substring(pointName.Length - 2));
				if(dungeons.ContainsKey(index)){
					int dungeonId = dungeons[index];
					GameObject instance = CreateOneDungeon(transform , dungeonId , i);
					dungeonList.Add(instance);
				}
			}
			return;
		}
		
		for(int i = 0 ; i < dungeonList.Count ; i++){
			if(dungeonList[i].gameObject.activeSelf){
				var dungeonScript = (DungeonScript)dungeonList[i].GetComponent(typeof(DungeonScript));
				dungeonScript.FreshUI();
			}
		}
	}
	
	GameObject CreateOneDungeon(Transform parent , int dungeonId , int i){
		var dungeonData = chapterData.GetDungeonByLevelAndId(chapterData.Level , dungeonId);
		GameObject prefab = Resources.Load("Prefab/ChapterDgnSystem/dungeon" + string.Format("{0:D2}",dungeonData.baseData.baseType), typeof(GameObject)) as GameObject;
		
		GameObject instance = NGUITools.AddChild(parent.gameObject , prefab);
		
		instance.SetActive(true);
		var dungeonScript = (DungeonScript)instance.GetComponent(typeof(DungeonScript));
		dungeonScript.BindingData(dungeonData);
		dungeonScript.FreshUI();
		return instance;
	}
	
	void OnDisable(){
		UnRegistAction();
	}
	
	void OnDestory(){
		dungeonList.Clear();
		dungeonList = null;
	}
}