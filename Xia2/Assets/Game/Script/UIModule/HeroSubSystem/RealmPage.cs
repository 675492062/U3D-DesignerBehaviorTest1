using UnityEngine;
using System.Collections;

public class RealmPage : MonoBehaviour {

	public UILabel PropertyAdd; 
	public UISprite NeedSoulPoint;

	public RealmStar[] ReamlStars;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	public void refreh(int curIdx)
	{
		for(int i = 0; i < ReamlStars.Length; i++)
		{
			if(i >= curIdx)
			{
				ReamlStars[i].showEmpty();
				if(i > 0 && ReamlStars[i-1].barEffect != null)
				{
					ReamlStars[i-1].barEffect.setBarValue(0);
				}
			}
			else
			{
				ReamlStars[i].showLight();
				if(i > 0 && ReamlStars[i-1].barEffect != null)
				{
					ReamlStars[i-1].barEffect.setBarValue(1);
				}
			}
		}
	}
	public void refreshProAndCostPos(int curIdx)
	{
		Vector3 proVec = PropertyAdd.transform.localPosition;
		Vector3 costVec = NeedSoulPoint.transform.localPosition;
		proVec = ReamlStars [curIdx].transform.localPosition;
		costVec = ReamlStars [curIdx].transform.localPosition;
		proVec.y += 40;
//		proVec.x -= 10;
		costVec.y -= 40;
		costVec.x -= 20;
		PropertyAdd.transform.localPosition = proVec;
		NeedSoulPoint.transform.localPosition = costVec;
	}
	public void refreshProperty(int templateID ,int curLevel)
	{
		int cost = StaticRealmframe.Instance().getInt(curLevel, "cost");
		UILabel LabelCost = NeedSoulPoint.GetComponentInChildren<UILabel> ();
		LabelCost.text = "" + cost;

		string id = "" + templateID + "_" + curLevel;

		int []pro = new int[7];
		string [] proName = {"生命", "攻击力", "防御", "命中", "爆击", "闪避", "韧性"};
		pro[0] 	= StaticRealmpoint.Instance ().getInt(id,"life");
		pro[1]  = StaticRealmpoint.Instance ().getInt(id,"attack");
		pro[2]  = StaticRealmpoint.Instance ().getInt(id,"defence");
		pro[3] 	= StaticRealmpoint.Instance ().getInt(id,"hit");
		pro[4]  = StaticRealmpoint.Instance ().getInt(id,"critical");
		pro[5]  = StaticRealmpoint.Instance ().getInt(id,"dodge");
		pro[6]  = StaticRealmpoint.Instance ().getInt(id,"tenacity");
			
		int i = 0;
		do
		{
			if(pro[i] > 0)
			{
				PropertyAdd.text = proName[i] +" [85ff16]+"+ pro[i]+"[-]";
				break;
			}

			i++;
			if(i >= pro.Length)
			{
				break;
			}
		}while(true);

	}
}
