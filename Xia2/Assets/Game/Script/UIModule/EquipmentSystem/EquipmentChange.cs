using UnityEngine;
using System.Collections;

public class EquipmentChange : MonoBehaviour {

    public float m_Degrees = 35.0f;
	public Transform m_RightHand;                 //主武器位置点
	public Transform m_LeftHand;                  //副武器位置点
	public Transform m_Back;                      //背后挂载点
	public int type; //0 bag; 1 menuCenter; 2 menuLeft; 3 menuRight;
    private string m_cloneWeapon = null;                        //武器
	void Start()
	{
	}
	void Update()
	{

		HeroData data = null;
		switch(type)
		{
		case 0:
			data = MonoInstancePool.getInstance<HeroManager>().getCurShowHero();
			if(data!=null && data.equipmentList.isDirty)
			{
				data.equipmentList.isDirty = false;
				EquipmentItem weapon = data.equipmentList.getItemByType((int)GlobalDef.EquipmentTpye.E_WEAPON);
				if(null != weapon)
				{
					string weaponName = weapon.resname;
					setMainWeapon(weaponName);	
					if(weapon.needrole == (int)GlobalDef.EquipNeedRoleType.E_TWOKNIFE)
					{
						setSubWeapon(weaponName);	
					}
				}
			}
			break;
		case 1:
		case 2:
		case 3:
			int modelIdx = type - 1;
			data = MonoInstancePool.getInstance<HeroManager>().getFightHeroByIdx(modelIdx);
			if(data!=null && MonoInstancePool.getInstance<HeroManager>().fightHeroList.isDirtyModel[modelIdx])
			{
				MonoInstancePool.getInstance<HeroManager>().fightHeroList.isDirtyModel[modelIdx] = false;
//				EquipmentItem weapon = data.equipmentList.getItemByType((int)GlobalDef.EquipmentTpye.E_WEAPON);
//				if(null != weapon)
//				{
//					string weaponName = weapon.resname;
//
//					if(weapon.needrole == (int)GlobalDef.EquipNeedRoleType.E_TWOKNIFE)
//					{
//						setTwoBackWeapon(weaponName);
//					}
//					else 
//					{
//						setOneBackWeapon(weaponName);	
//					}
//				}
				EquipmentItem weapon = data.equipmentList.getItemByType((int)GlobalDef.EquipmentTpye.E_WEAPON);
				if(null != weapon)
				{
					string weaponName = weapon.resname;
					setMainWeapon(weaponName);	
					if(weapon.needrole == (int)GlobalDef.EquipNeedRoleType.E_TWOKNIFE)
					{
						setSubWeapon(weaponName);	
					}
				}
			}
			break;
		}


	}
	private GameObject weaponObj(Transform objBinding, string weaponName, bool destroy = true)
    {
        if (objBinding == null)
        {
            Debug.LogError("BindingGameObject is null !!!");
            return null;
        }
		string matName = weaponName;
		string [] subStr = matName.Split ('_');
		string modeName = "Prefab/Weapon/" + subStr[0];
		GameObject cloneWeapon = Resources.Load(modeName) as GameObject;
        if (cloneWeapon == null)
        {
			Debug.LogError("CloneWeaponGameObject is null !!! " + modeName);
            return null;
        }

        if (destroy)
        {
            foreach (Transform child in objBinding.transform)
            {
                Destroy(child.gameObject);
            }
        }        
		Material mat = new Material (Resources.Load("Png/Weapon/Materials/" + matName ) as Material);
		cloneWeapon.GetComponent<MeshRenderer> ().material = mat;

        GameObject weaponObj = Instantiate(cloneWeapon, objBinding.transform.position,
         objBinding.transform.rotation) as GameObject;
		weaponObj.layer = 9;//"modleview";
		Transform[] subObj = weaponObj.GetComponentsInChildren<Transform>();
		for(int i = 0; i < subObj.Length; i++)
		{
			subObj[i].gameObject.layer = 9;
		}

        weaponObj.transform.parent = objBinding.transform;
//		weaponObj.transform.localRotation = cloneWeapon.transform.localRotation;
//		Quaternion rot = weaponObj.transform.localRotation;
//		rot.x = 0;
//		rot.y = 0;
//		rot.z = 0;
//		weaponObj.transform.localRotation = objBinding.transform.localRotation;
//        weaponObj.transform.localPosition = Vector3.zero;
		Vector3 scale = weaponObj.transform.localScale;
		scale = Vector3.one;scale *= 0.9f;
		weaponObj.transform.localScale = scale;//Vector3.one;
		weaponObj.GetComponentInChildren<MeshRenderer>().material.shader = Shader.Find("Mobile/Unlit (Supports Lightmap)");

        return weaponObj;
    }
	public void setMainWeapon(string weaponName)
	{
		weaponObj(m_RightHand, weaponName);
	}
	public void setSubWeapon(string weaponName)
	{
		GameObject rowClone = weaponObj(m_LeftHand, weaponName);
		rowClone.transform.localRotation = Quaternion.Euler(0f, 180f, 180f);
	}
	public void setOneBackWeapon(string weaponName)
	{
		GameObject rowMan = weaponObj(m_Back, weaponName);
		rowMan.transform.localRotation = Quaternion.Euler(-12f, -68f, -87f);
		Vector3 pos = rowMan.transform.localPosition;
		pos.z = 0.05f;
		pos.x = 0.02f;
		rowMan.transform.localPosition = pos;
	}
	public void setTwoBackWeapon(string weaponName)
	{
		GameObject weapon = Resources.Load(weaponName) as GameObject;
		foreach (Transform child in m_Back.transform)
		{
		    Destroy(child.gameObject);
		}
		//双手武器第一件
		GameObject rowMan = weaponObj(m_Back, weaponName);
//		rowMan.transform.localRotation = m_Back.
//		rowMan.transform.localRotation = Quaternion.Euler(m_Degrees, 0f, 0f);
		//双手武器第二件
		GameObject rowClone = weaponObj(m_Back, weaponName, false);
//        rowClone.transform.localRotation = Quaternion.Euler(m_Degrees, 180f, 0f);
	}
    //销毁武器
	public void destroy(Transform obj)
    {
        foreach (Transform child in obj.transform)
        {
            Destroy(child.gameObject);
        }
    }
    //播放动作
    public void setAction()
    { 
        
    }
	public void clear()
	{
		destroy(m_RightHand);
		destroy(m_LeftHand);
		destroy(m_Back);
	}
	public void updateHeroSystemModel()
	{
//		clear ();
//		HeroData data = MonoInstancePool.getInstance<HeroManager>().getCurShowHero();
//		if(data!=null )
//		{
//			EquipmentItem weapon = data.equipmentList.getItemByType((int)GlobalDef.EquipmentTpye.E_WEAPON);
//			if(null != weapon)
//			{
//				string weaponName = weapon.resname;
//				setMainWeapon(weaponName);	
//				if(weapon.needrole == (int)GlobalDef.EquipNeedRoleType.E_TWOKNIFE)
//				{
//					setSubWeapon(weaponName);	
//				}
//			}
//		}
	}
	public void updateMainMenuHeroModel()
	{

	}
}
