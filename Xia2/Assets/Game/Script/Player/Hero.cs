using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour {

	public Transform m_rightHand;
	public Transform m_leftHand;
	public Transform m_back;
	public string    m_wpName{ set; get;}
	public int 	 	 m_wpType{ set; get;}

	public Cha_Weapon m_weapon{ set; get;}

	// Use this for initialization
	void Awake(){

	}

	public bool AddWeaponToHero( HeroData hero )
	{
		m_weapon = m_rightHand.gameObject.AddComponent<Cha_Weapon>();	
		m_weapon.dummy_spine = m_back;
		m_weapon.sub_hand = m_leftHand;

		EquipmentItem wp = hero.equipmentList.getItemByType((int)GlobalDef.EquipmentTpye.E_WEAPON);
		if (null == wp) {
			Debug.LogError("weapon is error name=>" + wp.resname );
			return false;
		}
		int weaponType = hero.heroType;
		string weaponName = wp.resname;
		m_weapon.Init (weaponName, weaponType);

		if(GetComponentInParent<Unit>().m_unitType == GlobalDef.UnitType.UNIT_TYPE_ENEMY_HERO)
		{
			int a;
			a = 0;
		}
		return true;
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
