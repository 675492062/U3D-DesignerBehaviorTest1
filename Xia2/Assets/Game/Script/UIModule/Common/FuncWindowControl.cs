using UnityEngine;
using System.Collections;

public class FuncWindowControl : MonoBehaviour {

	public int  uiState;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnClick()
	{
		showWindow (uiState);
	}
	public void showWindow(int state)
	{
		var manager = (UIManager)FindObjectOfType(typeof(UIManager));
		switch(uiState)
		{
		case (int)GlobalDef.UIState.UI_NORMAL:
			manager.hideAll();
			break;
		case (int)GlobalDef.UIState.UI_SHOP:
			//			manager.show("");// openShop();
			break;
		case (int)GlobalDef.UIState.UI_BAG:
			manager.show("BagPanel"); // openBag((int)GlobalDef.EnterBagType.E_MAINUI);
			BagUIManager bag = (BagUIManager)FindObjectOfType(typeof(BagUIManager));
			if(bag)
			{
				bag.refreshAllData();
			}
			break;
		case (int)GlobalDef.UIState.UI_MAIL:
			//			manager.openMail();
			break;
		case (int)GlobalDef.UIState.UI_FRIEND:
			//			manager.openFriend();
			break;
		case (int)GlobalDef.UIState.UI_ANNOUNCEMENT:
			//			manager.openAnnouncenment();
			break;
		case (int)GlobalDef.UIState.UI_CHAT:
			//			manager.openChat();
			break;
		case (int)GlobalDef.UIState.UI_BAGNEW:
			//			manager.openNewBag();
			break;
		case (int)GlobalDef.UIState.UI_TASK_WINDOW:
			manager.show("TaskSysWindow");
			break;
		case (int)GlobalDef.UIState.UI_GM_WINDOW:
			manager.show("GM");
			break;
		case (int)GlobalDef.UIState.UI_EQUIPMENTSYS_WINDOW:
			manager.show("EquipmentPanel");
			manager.hide("HeroSystem");
			break;
		case (int)GlobalDef.UIState.UI_HEROSYS_WINDOW:
			manager.show("HeroSysHeadList");
			manager.hide("EquipmentPanel");
			MonoInstancePool.getInstance<HeroManager>().isDirty = true;
			break;
		case (int)GlobalDef.UIState.UI_CAPTER_WINDOW:
			manager.hide("HeroSysHeadList");
			manager.hide("EquipmentPanel");
			manager.show("uichapterpanel");
			Transform tChapter = manager.getPanel("uichapterpanel");
			var chapterMap = (UIChapterDgnManager)tChapter.GetComponent(typeof(UIChapterDgnManager));
			chapterMap.OpenOChapterMapUI();

			MainMenuManager menu = (MainMenuManager)FindObjectOfType(typeof(MainMenuManager));
			if(menu != null)
			{
				menu.hideEffect();
			}
			break;
		case (int)GlobalDef.UIState.UI_AREAN_RANK_LIST:
			manager.show("AreanUI");
			Transform tArean = manager.getPanel("AreanUI");
			var areanUiManager = (AreanUiManager)tArean.GetComponent(typeof(AreanUiManager));
			areanUiManager.ShowRankUI();
			break;
		case (int)GlobalDef.UIState.UI_BLOODSOUL_WINDOW:
			manager.show("BloodSoulSysWindow");
			break;
		}
	}
}