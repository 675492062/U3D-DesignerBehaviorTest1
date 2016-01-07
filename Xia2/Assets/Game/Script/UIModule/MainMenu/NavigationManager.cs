using UnityEngine;
using System.Collections;

//only used when the scene recreate   , dirty function

public class NavigationManager : MonoBehaviour {
	// Use this for initialization
	void Start () {
		if(GlobalDef.mainSceneState != GlobalDef.UIState.UI_NORMAL){
			NavigationTo(GlobalDef.mainSceneState);
			GlobalDef.mainSceneState = GlobalDef.UIState.UI_NORMAL;
		}
	}
	// not public ...
	public void NavigationTo(GlobalDef.UIState uiState){
		NavigationTo((int)uiState);
	}
	
	public void NavigationTo(int uiState){
		var manager = (UIManager)FindObjectOfType(typeof(UIManager));
		switch(uiState)
		{
		case (int)GlobalDef.UIState.UI_CAPTER_WINDOW:
			manager.show("uichapterpanel");
			Transform t = manager.getPanel("uichapterpanel");
			var chapterMap = (UIChapterDgnManager)t.GetComponent(typeof(UIChapterDgnManager));
			chapterMap.OpenOChapterMapUI();

			MainMenuManager menu = (MainMenuManager)FindObjectOfType(typeof(MainMenuManager));
			if(menu != null)
			{
				menu.hideEffect();
			}
			break;
		}
	}
}
