using UnityEngine;
using System.Collections;

public class RouteSpawn : MonoBehaviour {
	public enum SignType{
		white = 1,
		red = 2
	}
	
	public const int DISTANCE = 20;
	
	public Transform start;					//
	
	public Transform end;

	//suc or fail
	public bool CreateRoute(){
		if(this.transform.childCount != 0){
			return false;
		}
		string signName = GetSignName(); 
		if(signName == null){
			return false;
		}
		
		Vector3 direction = end.localPosition - start.localPosition;
				
		int distance = (int)direction.magnitude - 50;
		
		int signNum = distance/ DISTANCE + 1;
		int delta = distance % DISTANCE;
		
		Vector3 stepV3 = direction /(signNum - 1);
		
		Vector3  deltaV3 = direction - stepV3 * signNum;
		
		for(int i = 2 ; i < signNum -2 ; i++){
			GameObject sign = CreateOneSign(signName);
			
			Vector3 distanceV3 = stepV3 * i;
			Vector3 newPosition = new Vector3(start.localPosition.x + distanceV3.x , start.localPosition.y + distanceV3.y , 0);
			sign.transform.localPosition = newPosition;
		}
		return true;
	}
	
	GameObject CreateOneSign(string signName){	
		GameObject sign = Instantiate(Resources.Load("Prefab/ChapterDgnSystem/" + signName , typeof(GameObject))) as GameObject;
		sign.transform.parent = this.transform;
		sign.layer = this.gameObject.layer;
		sign.transform.localPosition = Vector3.zero;
		sign.transform.localScale = Vector3.one;
		sign.transform.rotation = Quaternion.identity;
		sign.SetActive(true);
		return sign;
	}
	
	string GetSignName(){
		//只有起点或者只有终点，就不必产生新的路标
		if(start.childCount == 0 || end.childCount == 0){
			return null;
		}
		var startDungeon = (DungeonScript)start.GetChild(0).GetComponent(typeof(DungeonScript));
		var endDungeon = (DungeonScript)end.GetChild(0).GetComponent(typeof(DungeonScript));
		
		if(!startDungeon.gameObject.activeSelf || !endDungeon.gameObject.activeSelf){
			return null;
		}
		
		DungeonItem.DungeonType startType =  startDungeon.DungeonData.baseData.type;
		DungeonItem.DungeonType endType = endDungeon.DungeonData.baseData.type;
		
		int typeNum = (int)startType | (int)endType;
		if(typeNum > ((int)DungeonItem.DungeonType.Normal | (int)DungeonItem.DungeonType.Boss)){
			return ChapterConstants.Chapter.Sign_Red_SpriteName;
		}
		return ChapterConstants.Chapter.Sign_White_SpriteName;
	}
}