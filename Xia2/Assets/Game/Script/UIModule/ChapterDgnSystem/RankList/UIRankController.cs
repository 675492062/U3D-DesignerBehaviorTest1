using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIRankController : MonoBehaviour {
	
	public GameObject btnClose;
	
	public UILabel userRankIndex;
	
	public UILabel userTotalStarNum;
	
	public Transform tGrid;
	
	void Awake(){
		UIEventListener.Get(btnClose).onClick += UIClickCloseBtn;
	}
	
	public void FreshUI(){
		List<RankerStruct> list = MonoInstancePool.getInstance<RankManager>().GetRankList();
		
		int count = list.Count;
		GameObject prefab = Resources.Load("Prefab/ChapterDgnSystem/ranklist/rankitem") as GameObject;
		for(int i = 0 ; i < count ; i++){
			GameObject instance = NGUITools.AddChild(tGrid.gameObject , prefab);
			instance.name = "ranker" + i;
			instance.SetActive(true);
			var rankScript = (RankItemScript)instance.GetComponent(typeof(RankItemScript));
			rankScript.BindingData(list[i]);
			rankScript.FreshUI();
		}
		
		UIGrid uiGrid = (UIGrid)tGrid.GetComponent(typeof(UIGrid));
		uiGrid.Reposition();
	}
	
	void UIClickCloseBtn(GameObject gameobject){
		this.gameObject.SetActive(false);
	}
	
	void OnDisable(){
		foreach(Transform child in tGrid){
			Destroy(child.gameObject);
		}
	}
}
