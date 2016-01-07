using UnityEngine;
using System.Collections;

public class Tower_base : MonoBehaviour {
	
	///Hp_bar_fixed script_hpbar;
	//CharControl script_cha;
	//CamMove script_cam;
	
	//Transform hpbar;
	Transform mytransform;
	Vector3 attackdir;
	float damage = 0;
	bool life = true;
	short maxhp = 0;
	short hp = 0;
	short cur_stage_index  = 0;
	public bool iscastle = false;
	public Transform mydestroy;
	bool istower = false;
	
	void Awake()
	{
		mytransform = transform;
		if (mytransform.childCount !=0)
			istower = true;
	}

	
	void Start () 
	{
		cur_stage_index = (short)Crypto.Load_int_key("cur_stage_index");
		if (iscastle)
		{
			maxhp += (short)(( 0.1445f * cur_stage_index *cur_stage_index + 6.3873f * cur_stage_index -5)*20);
			//maxhp = (short)(1500 + 10 * (cur_stage_index +1));
		}
		else
		{
			maxhp += (short)(( 0.1445f * cur_stage_index *cur_stage_index + 6.3873f * cur_stage_index -5)*3);
			//power += (short)(0.0058f * level*level +1.008f * level -5); 
			//maxhp = (short)(100 +  10 * (cur_stage_index +1));
		}
		maxhp = 4;
		hp = maxhp;
		
		//hpbar = GameObject.FindWithTag("efs_mon").GetComponent<Monster_efs>().CreatHpbar(new Vector2(0.1f,0.02f),true,false);
		//hpbar.parent = mytransform;
		//script_hpbar = hpbar.GetComponent<Hp_bar_fixed>();
		//script_cha = GameObject.FindWithTag("Player").transform.gameObject.GetComponent<CharControl>();
		//script_cam = Camera.main.GetComponent<CamMove>();
		//hpbar.position = mytransform.position+ Vector3.forward* (-0.08f) + Vector3.up *0.2f;
		//script_hpbar.Damaged(maxhp,hp,mytransform,0.2f,-1);
		//gameObject.AddComponent<Rigidbody>();
	}
	
	public void Grabed()
	{
	}
	
	public void CastleBreak()
	{
		life = false;
		GetComponent<Collider>().enabled = false;
		//Destroy(hpbar.gameObject);
		Destroy(mytransform.GetChild(0).gameObject);
//		if (iscastle)
//			GameObject.FindWithTag("ui").GetComponent<UI_Ingame>().WaveSet(100);
	}
	
	public bool TankDamage()
	{
		hp = (short)(hp - (maxhp*0.1f));
		//script_hpbar.Damaged(maxhp,hp,mytransform,0.2f,-1);
		GetComponent<AudioSource>().Play();

		////////////////dead
		if (hp <=0 && life)
		{
			 CastleBreak();
		}
		return life;
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer >=20)
		{
			int atk = 1;
			switch(other.gameObject.layer)
			{
			case 20:	// normal attack
				attackdir = mytransform.position - other.transform.position;
				attackdir[1] = 0;
				attackdir = Vector3.Normalize (attackdir);
				other.transform.root.GetComponent<Rigidbody>().AddForce (attackdir *(-90));
				damage = atk;
			//	script_cam.Hitcam();
				break;
			case 21:	// power attack
				damage = atk;
			//	script_cam.Hitcam2(1);
				break;
			case 22:	// skill attack
				damage = other.GetComponent<Rigidbody>().mass ;
			//	script_cam.Hitcam();
				break;
			case 23:	// poison attack
				damage = atk;
			//	script_cam.Hitcam();
				break;
			case 24:	// death attack
				damage = other.GetComponent<Rigidbody>().mass;
				//script_cam.Hitcam();
				break;
			case 25:	// arrow attack
				damage = atk;
				break;
			case 26:	// pierce attack
				damage = atk;
				break;
			case 27:	// crowd attack
				damage = atk;
				break;
			case 28:	// push attack
				damage = atk;
				break;
			case 29:   //riseup attack
				damage =atk;
				break;	
			case 30:	// freeze attack
				damage = atk;
				break;	
			case 31:	// burn attack
				damage = atk;
				break;
			case 18:	// shock attack
				damage = atk;
				break;
			case 19:	// darken attack
				damage = atk;
				break;
			}

			hp -= (short)damage;
			//script_hpbar.Damaged(maxhp,hp,mytransform,0.2f,-1);
			GetComponent<AudioSource>().Play();
			//Debug.Log(hp);
			////////////////dead
			if (hp <=0 && life)
			{
				life = false;
				GetComponent<Collider>().enabled = false;
				
//				if (iscastle)
//				{
//					CastleBreak();
//				}
//				else
//				{
					///GameObject.FindWithTag("Respawn").GetComponent<Spawn>().TowerBreak(istower);
					Transform c_destroy = (Transform)Instantiate(mydestroy,mytransform.position, mytransform.rotation);
					Destroy(gameObject);
					//c_destroy.animation["destroy_tower"].speed = 0.3f;
					Destroy(c_destroy.gameObject,3.0f);
					//Destroy(hpbar.gameObject);
					
				//}
			}
		}
	}

}
