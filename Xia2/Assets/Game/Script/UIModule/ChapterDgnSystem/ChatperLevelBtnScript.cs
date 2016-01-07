using UnityEngine;
using System.Collections;

//章节难度按钮控制脚本
public class ChatperLevelBtnScript : MonoBehaviour {

	public Transform tSelected;
	
	public Transform tLocked;
	
	public ChapterLevel level;
	
	public void FreshUI(ChapterStruct data){
		if(data.Level == level){
			tSelected.gameObject.SetActive(true);
			tLocked.gameObject.SetActive(false);
			return;
		}
		
		tSelected.gameObject.SetActive(false);
		tLocked.gameObject.SetActive(!data.UnLocked((int)level));
	}
}