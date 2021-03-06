using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[System.Serializable]
public struct UIUseSkillItem
{
	public UISprite Icon;
	public UISprite Empty;
	public UISprite Lock;
	public void refresh (SkillItem item)
	{
		showIcon();
		Icon.spriteName = item.icon;
	}
	public void showEmpty()
	{
		Icon.gameObject.SetActive (false);
		Empty.gameObject.SetActive (true);
		Lock.gameObject.SetActive (false);
	}
	public void showLock()
	{
		Icon.gameObject.SetActive (false);
		Empty.gameObject.SetActive (false);
		Lock.gameObject.SetActive (true);
	}
	public void showIcon()
	{
		Icon.gameObject.SetActive (true);
		Empty.gameObject.SetActive (false);
		Lock.gameObject.SetActive (false);
	}
}
public class HeroUISkillList : MonoBehaviour 
{
	public UISkillItem[] skillItems = new UISkillItem[4]; 	      //skill list
	public UIUseSkillItem[] useSkillItems = new UIUseSkillItem[3];// useSkillList

	public int curDragIdx = -1;
	public int recordZ = 0;
	UISprite tempIcon = null; 
	public Vector3 beganPos{ get; set;}
	float  Y_Add = 50;
	public Transform useSkillParent;//
	// Use this for initialization
	void Start () 
	{

	}
	public void MoveDelegate(Vector2 d)
	{

	}
	// Update is called once per frame
	void Update () 
	{

		if(Input.GetMouseButton(0))
		{
			if(curDragIdx == -1)
			{
				return;
			}
			if(tempIcon == null)
			{
				Vector3 pos = skillItems [curDragIdx].Icon.transform.position;
				Quaternion rot = skillItems [curDragIdx].Icon.transform.rotation;
				Transform t = (Transform)Instantiate (skillItems [curDragIdx].Icon.transform, pos, rot);
				tempIcon =  t.GetComponentInChildren<UISprite>();
				tempIcon.transform.parent =   skillItems [curDragIdx].Icon.transform.parent;
				tempIcon.transform.parent =  NGUITools.FindInParents<UIPanel>(gameObject).transform;
				tempIcon.transform.localScale = Vector3.one;

			}
#if UNITY_EDITOR
			UICamera.MouseOrTouch mouse = UICamera.GetMouse(0);
#else
			UICamera.MouseOrTouch mouse = UICamera.GetTouch(0);
#endif
	
			Vector2 p = mouse.pos;
			Vector3 newPos = tempIcon.transform.localPosition;
			newPos.x = p.x - Screen.width/2;
			newPos.y = p.y - Screen.height/2 + Y_Add;
			tempIcon.transform.localPosition = newPos;

		}
	}
	
	public void refresh(HeroData data)
	{
		List<SkillItem> skills = data.skillList.skills;
		for(int i = 0; i < skills.Count; i++)
		{
			SkillItem item = skills[i];
			skillItems[i].refresh(item, i+1);
		}
		refreshUseSkill (data);
	}
	public void refreshSkillbyItem(SkillItem Item, int pos)
	{
		if(pos < 0 || pos >= skillItems.Length)
		{
			return;
		}
		skillItems [pos].refresh (Item,pos);
	}
	public void refreshUseSkill(HeroData data)
	{
		List<SkillItem> skills = data.skillList.skills;
		for(int i = 0; i < data.skillList.useSkills.Length; i++)
		{
			if(data.skillList.useSkills[i] == -1)
			{
				useSkillItems[i].showEmpty();
			}
			else 
			{
				SkillItem item = skills[data.skillList.useSkills[i]];
				useSkillItems[i].refresh(item);
			}
		}
	}
	public void stopDrag()
	{
		tempIcon.transform.parent = useSkillParent;
		for(int i = 0; i < useSkillItems.Length; i++)
		{
			Vector3 src = tempIcon.transform.localPosition;
			src.y -= Y_Add;
			Vector3 dst = useSkillItems[i].Icon.transform.parent.localPosition;
			float distance = Vector3.Distance(src, dst);
			Debug.Log("--------dis: " + distance);
			if(distance < 100)
			{
			 	HeroData data =	MonoInstancePool.getInstance<HeroManager>().getCurShowHero();
				if(data != null)
				{
//					data.useSkills[i] = curDragIdx;
//					useSkillItems[i].Icon.spriteName = skillItems [curDragIdx].Icon.spriteName;

					MonoInstancePool.getInstance<SendHeroSysMsgHander> ().sendSetUseSkillReq (data.guid, curDragIdx, i);
				}
			}
		}
		Destroy (tempIcon.gameObject);
		tempIcon = null;

		//skillItems [curDragIdx].Icon.transform.localPosition = Vector3.zero;
		//skillItems [curDragIdx].Icon.depth = recordZ;
		curDragIdx = -1;
	}
}
