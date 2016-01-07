using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//竞技记录
public class AreanRecordUI : MonoBehaviour {
	public GameObject bgCollider;
	
	public UIGrid uiGrid;
	
	void Awake(){
		UIEventListener.Get(bgCollider).onClick += Close;
	}
	
	void Close(GameObject sender){
		this.gameObject.SetActive(false);
	}

	public void FreshUI(){
		StartCoroutine(FreshGrid());
	}
	
	IEnumerator FreshGrid(){
		foreach(Transform child in uiGrid.transform){
			Destroy(child.gameObject);
		}	
		yield return new WaitForEndOfFrame();
		
		AreanManager areanManager = MonoInstancePool.getInstance<AreanManager>();
		List<AreanRecordData> list = areanManager.GetAreanRecordList();
		for(int i = 0 ; i < list.Count ; i++){
			GameObject prefab = Resources.Load("Prefab/Arean/areanrecorditem") as GameObject;
			
			GameObject rankItem = NGUITools.AddChild(uiGrid.gameObject , prefab);
			var recordItemSc = (AreanRecordItem)rankItem.GetComponent(typeof(AreanRecordItem));
			rankItem.gameObject.SetActive(true);
			recordItemSc.BindingData(list[i]);
			recordItemSc.FreshUI();
			uiGrid.Reposition();
			yield return new WaitForEndOfFrame();
		}
	}
}