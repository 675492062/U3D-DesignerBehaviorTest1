using UnityEngine;
using System.Collections;
using System.Linq;

public class EquipmentInfoWindow : MonoBehaviour 
{
	public EquipBagItemProperty ItemProperty;
	public UISprite QualityIcon;
	public UILabel EquipDamageNum;
	public UILabel []ProName;
	public UILabel []ProNum;

	public Transform BtnGroup;
	public UIButton Change;
	public UIButton Duanzao;
	public UIButton Qianghua;

	public UIButton PutOn;

	public int enterType{ get; set;}
	public long guid{get; set;}
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void refresh(EquipmentItem item)
	{
		guid = item.guid;
		ItemProperty.refresh (item);
		int min = item.mindamage;
		int max = item.maxdamage;
		EquipDamageNum.text = min + "-" + max;

		QualityIcon.spriteName = item.getQualityIconImgName ();
		setQulatiProperty (item);
	}
	public void setQulatiProperty(EquipmentItem item)
	{
		for(int i = 0; i < ProName.Length; i++)
		{
			ProName[i].gameObject.SetActive(false);
		}

		int curIdx = 0;
		for (int i = 0; i < item.proptys.dictProperty.Count; i++) 
		{
			int num = item.proptys.dictProperty.ElementAt(i).Value;
			if(num != 0)
			{
				string name = GlobalDef.NewHeroPropertyName[item.proptys.dictProperty.ElementAt(i).Key];
				int res = item.proptys.dictProperty.ElementAt(i).Value;

				ProName[curIdx].gameObject.SetActive(true);
				ProName[curIdx].text = name;
				ProNum[curIdx].text = "+"+res;
				curIdx++;
				if(curIdx >= ProName.Length)
					return;
			}
		}
	}
	public void clickPutOnBtn()
	{
//		if(item.needrole != data.heroType)
//		{
//			ErrorParse error = (ErrorParse)FindObjectOfType(typeof(ErrorParse));
//			if(error != null)
//			{
//				error.showErrorWindow("type error! heroType: " + data.heroType + " itemNeedType: " + item.needrole);
//			}
//			UI_manager.hide("EquipmentInfoUI");
//			return;
//		}

		HeroData data = MonoInstancePool.getInstance<HeroManager> ().getCurShowHero ();
		MonoInstancePool.getInstance<SendItemSystemMsgHander> ().SendPutOnEquipment(guid, data.guid);
	}
}
