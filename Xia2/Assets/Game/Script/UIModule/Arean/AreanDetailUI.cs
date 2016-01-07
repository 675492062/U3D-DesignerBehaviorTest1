using UnityEngine;
using System.Collections;

public class AreanDetailUI : MonoBehaviour {
	public GameObject btnBack;
	public UILabel labelFightNum;
	
	public AreanDetailHeroSc[] detailHeros;
	
	void Awake(){
		UIEventListener.Get(btnBack).onClick += Close;
	}
	
	void Close(GameObject sender){
		this.gameObject.SetActive(false);
	}
	
	public void FreshUI(){
//		labelFightNum = MonoInstancePool.getInstance<AreanManager>().detailInfo.
		var areanMng = MonoInstancePool.getInstance<AreanManager>();
		var detailInfo = areanMng.detailInfo;
		for(int i = 0 ; i < detailHeros.Length && i < areanMng.detailInfo.GetHeroList().Count; i++){
			detailHeros[i].BindingData(areanMng.detailInfo.GetHeroList()[i]);
			detailHeros[i].FreshUI();
		}
	}
	
	void OnEnable()
	{
		UIPanel panel = NGUITools.FindInParents<UIPanel> (gameObject);
		UICurrencyManager.Show (transform,panel.depth);
	}
}