using UnityEngine;
using System.Collections;

public class RouteController : MonoBehaviour {

	public void SpawnRoutes(){
		StartCoroutine(GeneratRoute());
	}
	
	//生成副本与副本之前的白色/红色的路标
	IEnumerator GeneratRoute(){
		int childcount = this.transform.childCount;
		for(int i = 0 ; i < childcount ; i++){
			Transform child = transform.GetChild(i);
			var routeSpawn = (RouteSpawn)child.GetComponent(typeof(RouteSpawn));
			if(routeSpawn.CreateRoute())yield return 0;
		}
	}
}