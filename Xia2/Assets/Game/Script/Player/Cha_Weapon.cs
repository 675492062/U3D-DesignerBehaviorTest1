using UnityEngine;
using System.Collections;

public class Cha_Weapon : MonoBehaviour {
	
	
	GameObject blade;//刀身
	Transform mytransform;
	//public Transform bowgun;
	//public Transform spear;
	public Transform dummy_spine;//脊柱
	public Transform sub_hand;//手
	
	public Transform current_blade{ set; get;}
	public Transform current_blade2{ set; get;}
	
	Transform general_blade;	
	Transform general_blade2;
	Transform current_weapon;

	float showdelay = 0;
	bool changestart = false;
	
	//Transform c_bowgun;
	//Transform c_spear;
	float finishtime = 0;
	short changespd = 1;
	
	public int dock = 0;

	void Awake()
	{
		mytransform = transform;
	}

	void Start () 
	{
        //
	}

	public void Init( string wpName,int wpType )
	{
		SetStageWeapon(wpName,wpType);
	}
	
	public void SetStoryBlade()
	{
		blade = Resources.Load("wp_0") as  GameObject;
		current_blade = (Transform)Instantiate (blade.transform, dummy_spine.position, dummy_spine.rotation);
	}

	public void SetWeaponLayer( int num )
	{
		if( current_blade!= null )
			current_blade.gameObject.layer = num; 
		if( current_blade2!= null )
			current_blade2.gameObject.layer = num; 

	}
	
    //设置武器
	public void SetStageWeapon(string wpName, int type)
	{
		if (current_blade != null)
			Destroy (current_blade.gameObject);
		if (current_blade2 != null)
			Destroy (current_blade2.gameObject);

		int weapon_kind = type;//(int)(weapon_index * 0.01f);   //武器类型

		string matName = wpName; //武器名称
		string[] modeName = wpName.Split('_');

		blade = Resources.Load("Prefab/Weapon/" + modeName[0] ) as  GameObject;//加载预设

        //材质
		Material mat = new Material (Resources.Load("Png/Weapon/Materials/" + matName ) as Material);
		mat.shader = Shader.Find ("Mobile/VertexLit (Only Directional Lights)");
		blade.GetComponent<MeshRenderer> ().material = mat;

		blade.layer = 11;

        //实例化武器
		current_blade = (Transform)Instantiate (blade.transform, dummy_spine.position, dummy_spine.rotation);
		current_blade.name = "wp";
	//	current_blade.parent = dummy_spine;

		current_blade.gameObject.SetActive (false);

		if (weapon_kind == 2) // 鍙屽墤
		{
			current_blade.position +=    dummy_spine.forward *0.01f;
			current_blade2 =	(Transform)Instantiate (blade.transform,dummy_spine.position  - dummy_spine.up *0.03f + dummy_spine.forward *0.04f +dummy_spine.right *0.01f,  dummy_spine.rotation);
			current_blade2.parent = dummy_spine;
			current_blade2.localRotation = Quaternion.Euler (260,180,0);
			current_blade2.name = "wp";
			current_blade2.gameObject.SetActive (false);
		}
		
		if (dock == 1)
		{
			current_blade.localScale = current_blade.localScale *0.8f;
			if (weapon_kind == 1)
				current_blade2.localScale = current_blade2.localScale *0.8f;
		}
	}
	
	public void GeneralWeaponOn(int _generalkind, int _weaponindex)
	{
		current_blade.gameObject.active = false;
		if (current_blade2 != null)
			current_blade2.gameObject.active = false;
		
		if (general_blade == null)
		{
			blade = Resources.Load("wp_general"+ _weaponindex.ToString()) as  GameObject;
			general_blade = (Transform)Instantiate (blade.transform, mytransform.position, mytransform.rotation);
			general_blade.parent = mytransform;
			if (_generalkind == 1)
			{
				general_blade2 =(Transform)Instantiate (blade.transform,sub_hand.position, sub_hand.rotation);
				general_blade2.parent = sub_hand;
			}
		}
		else
		{
			general_blade.gameObject.active = true;
			if (_generalkind == 1)
				general_blade2.gameObject.active = true;
		}
	}
	
	public void GeneralWeaponOff()
	{
		if (general_blade != null)
			general_blade.gameObject.active = false;
		if (general_blade2 != null)
			general_blade2.gameObject.active = false;
		current_blade.gameObject.active = true;
		if (current_blade2 != null)
			current_blade2.gameObject.active = true;
	}
	
	public void SetWeapon(int _meshkind , int _weapon_kind)			//STATUS SCEAN
	{
		if (current_blade != null)
		{
			Destroy (current_blade.gameObject);
		}
		if (current_blade2 != null)
		{
			Destroy (current_blade2.gameObject);
		}
		
		blade = Resources.Load("wp_"+_meshkind.ToString()) as GameObject;
		current_blade = (Transform)Instantiate (blade.transform, dummy_spine.position, dummy_spine.rotation);
		//if (dock == 2)
		current_blade.localScale = current_blade.localScale *4.5f;
		/*else if (dock == 1)
			current_blade.localScale = current_blade.localScale *0.8f;*/
		current_blade.parent = dummy_spine;
		
		if (_weapon_kind == 1)
		{
			current_blade.position +=    dummy_spine.forward *0.1f;
			current_blade2 =	(Transform)Instantiate (blade.transform,dummy_spine.position  - dummy_spine.up *0.18f + dummy_spine.forward *0.26f +dummy_spine.right *0.04f,  dummy_spine.rotation);
			//current_blade2 =	(Transform)Instantiate (blade.transform,dummy_spine.position  - dummy_spine.up *0.28f + dummy_spine.forward *0.24f +dummy_spine.right *0.04f,  dummy_spine.rotation);
			//if (dock == 2)
			current_blade2.localScale = current_blade2.localScale *4.5f;
			/*else if (dock == 1)
				current_blade2.localScale = current_blade2.localScale *0.8f;*/
			
			current_blade2.parent = dummy_spine;
			current_blade2.localRotation = Quaternion.Euler (260,180,0);
		}
	}
	
	public void SwitchWepon(int kind, short _changespd ,float _finishtime, float _showdelay)
	{
		/*if (current_weapon != null)
			Destroy (current_weapon.gameObject);*/
		changespd = _changespd;
		finishtime = _finishtime;
		showdelay = _showdelay;
		
		if (kind == 0)
		{
			//Todo Lee
			//			if ( c_spear == null)
			//			{
			//				c_spear = (Transform)Instantiate (spear, mytransform.position, mytransform.rotation);
			//			}
			//			else
			//			{
			//				c_spear.position = mytransform.position;
			//				c_spear.rotation = mytransform.rotation;
			//				c_spear.GetComponent<WeaponDrop>().DropCancel();
			//				c_spear.gameObject.active = true;
			//			}
			//			current_weapon =	c_spear;
		}
		else if(kind == 1)
		{
			//Todo Lee
			//			if ( c_bowgun == null)
			//			{
			//				c_bowgun = (Transform)Instantiate (bowgun, mytransform.position, mytransform.rotation);
			//			}
			//			else
			//			{
			//				c_bowgun.position = mytransform.position;
			//				c_bowgun.rotation = mytransform.rotation;
			//				c_bowgun.GetComponent<WeaponDrop>().DropCancel();
			//				c_bowgun.gameObject.active = true;
			//			}
			//			current_weapon =	c_bowgun;
		}
		else
		{
			current_weapon = null;
		}
		
		if (current_weapon != null)
		{
			current_weapon.localScale = Vector3.zero;
			//current_weapon.position = mytransform.position;
			//current_weapon.rotation = mytransform.rotation;
			current_weapon.parent = mytransform;
			changestart = true;
		}
		
		
		current_blade.position = dummy_spine.position;
		current_blade.rotation =  dummy_spine.rotation;
		current_blade.parent = dummy_spine;
		
		if (current_blade2 != null)
		{
			current_blade.position +=    dummy_spine.forward *0.01f;
			current_blade2.position =	dummy_spine.position  - dummy_spine.up *0.03f + dummy_spine.forward *0.04f +dummy_spine.right *0.01f;
			current_blade2.parent = dummy_spine;
			current_blade2.localRotation = Quaternion.Euler (260,180,0);
		}
	}
	
	public void ReturnBlade()
	{
		if (current_weapon != null)
		{
			current_weapon.parent = null;
			current_weapon.GetComponent<WeaponDrop>().Drop(false);
		}
		if(current_blade != null)
		{
			current_blade.position = mytransform.position;
			current_blade.rotation = mytransform.rotation;
			current_blade.parent = mytransform;
			current_blade.gameObject.SetActive(true);
		}
		if (current_blade2 != null)
		{
			current_blade2.position = sub_hand.position;
			current_blade2.rotation = sub_hand.rotation;
			current_blade2.parent = sub_hand;
			current_blade2.gameObject.SetActive(true);
		}
	}
	
	public void HideBlade()
	{
		current_blade.GetComponent<Renderer>().enabled = false;
		if (current_blade2 != null)
			current_blade2.GetComponent<Renderer>().enabled = false;
		if (general_blade != null)
			general_blade.GetComponent<Renderer>().enabled = false;
		if (general_blade2 != null)
			general_blade2.GetComponent<Renderer>().enabled = false;
	}
	
	public void ShowBlade()
	{
		current_blade.GetComponent<Renderer>().enabled = true;
		if (current_blade2 != null)
			current_blade2.GetComponent<Renderer>().enabled = true;
		if (general_blade != null)
			general_blade.GetComponent<Renderer>().enabled = true;
		if (general_blade2 != null)
			general_blade2.GetComponent<Renderer>().enabled = true;
	}
	
	void Update () 
	{
		if (changestart)
		{
			if (current_weapon.localScale.x >= 1)
			{
				current_weapon.localScale = Vector3.one;
				changestart = false;
				showdelay = 0;
			}
			else if (showdelay >1)
			{
				current_weapon.localScale +=  Vector3.one*changespd*Time.deltaTime;
			}
			else
			{
				showdelay += Time.deltaTime;
			}
		}
		else if (finishtime >0)
		{
			finishtime -= Time.deltaTime;
			if (finishtime<0)
				ReturnBlade();
		}
	}
}
