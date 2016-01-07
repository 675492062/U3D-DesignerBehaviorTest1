using UnityEngine;
using System.Collections;

public class ItemProperty : MonoBehaviour {

	public UILabel num_label;
	public UISprite Icon;
	public UISprite MaskBack;

	public long guid{ get; set;}
	public int templateID{ get; set;}
	public int index{ get; set;}
	public int num{ get; set;}
	public int type{get; set;}
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	void OnClick()
	{
		if(templateID == 0)
		{
			return;
		}
		Debug.Log ("click " + templateID);
		var manager = (BagUIManager)FindObjectOfType (typeof(BagUIManager));
		if(manager == null)
		{
			return;
		}
		manager.curSelectIdx = index;
		manager.curSelectGUID = guid;
		if(manager.enterType == (int)GlobalDef.EnterBagType.E_MAINUI)
		{
			if(type == (int)GlobalDef.ItemType.ITEM_EQUIPMENT)
			{
				manager.showEquipInfo(guid);
			}
			else 
			{
				manager.showItemInfo (guid);
			}
		}
		else if(manager.enterType == (int)GlobalDef.EnterBagType.E_CHAT)
		{
			var chatUIManager = (ChatUIManager)FindObjectOfType<ChatUIManager>();
			chatUIManager.setInput(guid);
		}
	}
	void OnDrag()
	{
		Debug.Log("----  drag ");
	}
	public void setNum(int n)
	{
		num = n;
//		Debug.Log ("have num: " + num);
		if(num == 1)
		{
			num_label.gameObject.SetActive(false);
		}
		else if(num > 1)
		{
			num_label.gameObject.SetActive(true);
			num_label.text = "" + num;
		}
	}
	public void setIcon(string icon)
	{
		Icon.gameObject.SetActive(true);
		Icon.spriteName = icon;
		string quality = ConfigManager.getInstance().getData(templateID, "quality");
		if(string.Empty == quality || string.Compare(quality, "-1") == 0)
		{
			setQuality((int)GlobalDef.EquipQuality.Q_NORMAL);
		}
		else
		{
			int qua = System.Int32.Parse(quality);
			setQuality(qua);
		}
	}
	public void setQuality(int qua)
	{
		if(MaskBack == null)
		{
			Debug.LogError("Items maskBack is null");
			return;
		}
		MaskBack.gameObject.SetActive(true);
		switch(qua)
		{
		case (int)GlobalDef.EquipQuality.Q_NORMAL://     = 1,//普通
			MaskBack.spriteName = "hb-01";
			break;
		case (int)GlobalDef.EquipQuality.Q_EXCELLENCE:// = 2,//优秀
			MaskBack.spriteName = "hb-02";
			break;
		case (int)GlobalDef.EquipQuality.Q_EXCELLENT://  = 3,//精良
			MaskBack.spriteName = "hb-03";
			break;
		case (int)GlobalDef.EquipQuality.Q_EPIC://       = 4,//史诗
			MaskBack.spriteName = "hb-04";
			break;
		case (int)GlobalDef.EquipQuality.Q_STORY://      = 5,//传说
			MaskBack.spriteName = "hb-05";
			break;
		case (int)GlobalDef.EquipQuality.Q_IMMORTAL://   = 6,//不朽
			MaskBack.spriteName = "hb-05";
			break;
		case (int)GlobalDef.EquipQuality.Q_ARTIFACT://   = 7,//神器
			MaskBack.spriteName = "hb-05";
			break;
		case (int)GlobalDef.EquipQuality.Q_GOD://        = 8,//逆天
			MaskBack.spriteName = "hb-05";
			break;
		}
	}
}
