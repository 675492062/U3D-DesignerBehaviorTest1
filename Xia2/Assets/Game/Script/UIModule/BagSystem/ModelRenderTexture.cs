using UnityEngine;
using System.Collections;

public class ModelRenderTexture : MonoBehaviour
{
	public int type;//0 bag; 1 menuCenter; 2 menuLeft; 3 menuRight;
	public GameObject parent;
	// Use this for initialization
	void Start () 
	{
//		GameObject role = ModelRenderTextureManager.getInstance().CreatModelRenderTexture("Prefab/Player/Preview/m_zhangfei", gameObject, parent, new Rect(0, 0, 550, 350));
//       
//		GameObject role = ModelRenderTextureManager.getInstance().CreatModelRenderTexture("Prefab/Player/Preview/m_xiahoudun", gameObject, parent, new Rect(0, 0, 550, 350));
//		setAnimation (100001, role);
//		refresh (100001);
	}
	
	// Update is called once per frame
	void Update () 
	{
		//-9.58
	}
	public void clear()
	{
		EquipmentChange equip = parent.GetComponentInChildren<EquipmentChange> ();
		if(equip != null)
		{
			Destroy(equip.gameObject);
		}
//		foreach (Transform child in parent.transform)
//		{
//			MonoBehaviour.Destroy(child.gameObject);
//		}
	}
	public void refresh(int templateID)
	{
		string res = StaticHero.Instance().getStr(templateID, "resname");
		string prefab = "Prefab/Player/Preview/" + res;


		GameObject role = ModelRenderTextureManager.getInstance().CreatModelRenderTexture(prefab, gameObject, parent, new Rect(0, 0, 500, 350f));
		if(role == null)
		{
			return;
		}
		EquipmentChange equip = role.GetComponentInChildren<EquipmentChange> ();
		if(equip != null)
		{
			equip.type = type;
		}
		//设置动作
		setAnimation (templateID, role);

		DragModerRender drag = role.GetComponentInChildren<DragModerRender> ();
		if(drag != null)
		{
			drag.idx = type;
		}

		float percent = 960f / 640f;
		float mobile_percent = (float)((float)Screen.width / (float)Screen.height);
		if(mobile_percent <= percent)
		{
			return;
		}
		float offset = mobile_percent - percent;
		float offset_width = 500f * offset;
		UITexture tex = this.GetComponent<UITexture> ();
		if(tex)
		{
			tex.width = 500+ (int)offset_width;
		}

	}
	public void setAnimation(int templateID, GameObject role)
	{
		int type = StaticHero.Instance ().getInt (templateID, "modelsize");
		Animation ani = role.GetComponent<Animation>();// GetComponentInChildren<Animation> ();

		string heroName = StaticHero.Instance ().getStr(templateID, "resname");
		string attack_name = heroName + "_stand01";
		if(ani.GetClip(attack_name) == null)
		{
			Animation pool = null;
			BagUIManager manager = (BagUIManager)FindObjectOfType(typeof(BagUIManager));
			MainMenuManager mainMenu = (MainMenuManager)FindObjectOfType(typeof(MainMenuManager));

			switch(type)
			{
			case 1:
				pool = manager != null ?  manager.m_aniManMBasic.GetComponent<Animation>() : mainMenu.m_aniManMBasic.GetComponent<Animation>();
				break;
			case 2:
				pool = manager != null ?   manager.m_aniWomenWBasic.GetComponent<Animation>() : mainMenu.m_aniWomenWBasic.GetComponent<Animation>();
				break;
			case 3:
				pool = manager != null ?  manager.m_aniBigMLBasic.GetComponent<Animation>() : mainMenu.m_aniBigMLBasic.GetComponent<Animation>();
				break;
			default:
				return;
				break;
			}
			AnimationClip free = pool.GetClip(attack_name);
			if(null == free)
			{
				return;
			}
			ani.AddClip(pool.GetClip(attack_name), attack_name);
		}
		ani.Play (attack_name);
	}
}
