using UnityEngine;
using System.Collections;

public class CamMove : MonoBehaviour {
	
	int dx =1;
	
	bool zoom = false;
	bool iconmove = false;
	
	int z_speed=0;
	float z_time=0;
	
	float zoomdelay= 0;
	float fov = 30;
	float originfov = 30;

	Transform cha1;
	Transform target;
	Transform mytransform;

	Vector3 distancetarget;
	Vector3 chaposition;
	float boundfactor = 1;

	Vector3 hit_shake1 = new Vector3 (0.06f  ,0,0.03f);
	Vector3 hit_shake2 = new Vector3 (0, 0.03f,0.02f);
	Vector3 hit_shake3 = new Vector3 (0, 0.04f,0.02f);

	float resetcam_delay = 0;
	bool resetstart = false;
	bool fovchange = false;

	Camera mycamera;
	public Vector3 limitpos;

	//Todo Lee
	//Icon_Skill script_skillicon;
	float fovbk_delay = 0;

    internal float limit_x_l = 2.1f;
    internal float limit_x_r = 2.1f;
    internal float limit_y_b = -3.3f;
    internal float limit_y_f = 0.85f;

	bool hidestop = false;
	short topviewon= 0;
	float topviewdelay = 3;
	//float camrotX = 50;
	short movespeed = 10;
	//Todo Lee
	//UI_Ingame script_ui;
	bool story_scene = false;
	
	void Awake()
	{
		mytransform = transform;
		mycamera = GetComponent<Camera>();
		/*GameObject loading =GameObject.Find("Loading_f");
		if (loading!= null)	
		    Destroy (loading);*/
		//GameObject pet_horse_riding =GameObject.Find("pet_horse_riding");
		//GameObject skydome =GameObject.Find("skydome");
		/*if (pet_horse_riding!= null)	
		    Destroy (pet_horse_riding);
		if (skydome!= null)	
		    Destroy (skydome);*/
		
		
		cha1 = GameObject.FindWithTag("Player").transform;
		transform.localEulerAngles = new Vector3(50,0,0);
		//script_skillicon = GameObject.FindWithTag("icon_skill").GetComponent<Icon_Skill>();
		ResetCam();
		//script_ui = GameObject.FindWithTag("ui").GetComponent<UI_Ingame>();
	}
	void Start () 
	{
		//Todo Lee
//		int play_kind = Crypto.Load_int_key("play_kind");
//		if (play_kind > 5)
//		{
//			limit_x = 0.5f;
//			limit_y_b = -1.0f;
//			limit_y_f = 15.5f;
//		}
		distancetarget = new Vector3(0,1.3f,-1.04f);
		transform.localEulerAngles = new Vector3(50,0,0);
		//AudioListener.volume = PlayerPrefs.GetFloat("vol_master");
	}
	
	public void Topview()
	{
		distancetarget = new Vector3(0,1.3f,-0.1f);
		topviewon = 1;
		topviewdelay = 3;
		movespeed = 5;
	}
	
	public void LookTarget(Transform _target, int _fov ,float _delay)
	{
		target = _target;
		
		if (_delay>0)
		{
			resetstart = true;
			resetcam_delay = _delay;
		}
		if (_fov != 0)
		{
			ZoomIn(-1,_fov,_delay);
		}
	}
	
	public void ThisIsStory()
	{
		story_scene = true;
	}
	
	public void IconHideStop(bool _hidestop)
	{
		hidestop = _hidestop;
	}

	public void setChar()
	{
//		if( GameObject.FindWithTag ("Player") )
//			cha1 = GameObject.FindWithTag ("Player").transform;
//		else
//			cha1 = GameObject.FindWithTag ("Player2").transform;
		
		ResetCam ();
	}

	public void ResetCam()
	{
		target =  cha1;
		fov = originfov;
		fovchange = true;
		resetstart = false;
		zoom = false;
		zoomdelay = 0;
	}

	public void FovTest(float _tempfov)
	{
		originfov = _tempfov;
		fov = originfov;
		mycamera.fieldOfView = originfov;
	}
	
	void Update () 
	{
		if (resetstart)
		{
			if(resetcam_delay>0)
				resetcam_delay -= Time.deltaTime;
			else
			{
				resetcam_delay =0;
				resetstart = false;
				ResetCam();
				///cha1.GetComponent<CharControl>().StartControl();
			}
		}
		
		chaposition = target.position + distancetarget;
		
		mytransform.position = Vector3.Lerp (mytransform.position,chaposition,Time.deltaTime*movespeed);
		
		limitpos = mytransform.position;

		if (topviewon != 1)
		{
			limitpos[2] = Mathf.Clamp(limitpos[2], limit_y_b * boundfactor, limit_y_f * boundfactor );
		}

        limitpos[0] = Mathf.Clamp(limitpos[0], limit_x_l * boundfactor, limit_x_r * boundfactor);	
		
		if (topviewon ==2)
			mytransform.position = Vector3.MoveTowards (mytransform.position, limitpos,Time.deltaTime*3);
		else
			mytransform.position = limitpos;
		
		if (!hidestop)
		{
			if (chaposition[0] > 2.4f)
			{
				if (!iconmove)
				{
					iconmove = true;
					//Todo Lee
					//script_skillicon.SkillIcon_Move(true);
				}
			}
			else if (chaposition[0] < -2.4f)
			{
				if (!iconmove)
				{
					iconmove = true;
					//Todo Lee
					//script_skillicon.PetIcon_Move(true);
				}
			}
			else if(iconmove)
			{
				iconmove = false;
				//Todo Lee
				//script_skillicon.SkillIcon_Move(false);
				//script_skillicon.PetIcon_Move(false);
			}
		}
		
		if (fovchange)
		{
			boundfactor = 0.8f + 0.2f * originfov/mycamera.fieldOfView;
			
			if (zoom)
			{
				if (z_speed == -1)
					mycamera.fieldOfView = fov;
				else
				{
					mycamera.fieldOfView = Mathf.Lerp (mycamera.fieldOfView,fov,Time.deltaTime*z_speed);
				}
				
				if (zoomdelay <z_time)
				{
					zoomdelay += Time.deltaTime;
				}
				else 
				{
					zoom = false;
					zoomdelay = 0;
					fovbk_delay = 0;
				}
			}
			else if (fovbk_delay <2)
			{
				fovbk_delay += Time.deltaTime;
				mycamera.fieldOfView = Mathf.Lerp (mycamera.fieldOfView,originfov,Time.deltaTime*3.0f);
			}
			else
			{
				fovbk_delay = 0;
				fovchange = false;
				mycamera.fieldOfView = originfov;
			}
		}

		if (topviewon>0)
		{
			topviewdelay -= Time.deltaTime;
			if (topviewon==1)
			{
				mytransform.rotation = Quaternion.Lerp (mytransform.rotation,Quaternion.Euler(80,0,0),Time.deltaTime*5);
				mycamera.fieldOfView = Mathf.Lerp (mycamera.fieldOfView,40,Time.deltaTime*3.0f);
				//camrotX = Mathf.MoveTowards(camrotX,70,Time.deltaTime*70);
				//mytransform.rotation = Quaternion.Euler(camrotX,0,0);
				if (topviewdelay <1.5f)
				{
					distancetarget = new Vector3(0,1.3f,-1.04f);
					topviewon = 2;
					movespeed = 5;
				}
			}
			else if (topviewon ==2)
			{
				//camrotX = Mathf.MoveTowards(camrotX,50,Time.deltaTime*70);
				//mytransform.rotation = Quaternion.Euler(camrotX,0,0);
				mytransform.rotation = Quaternion.Lerp(mytransform.rotation,Quaternion.Euler(50,0,0),Time.deltaTime*5);
				mycamera.fieldOfView = Mathf.Lerp (mycamera.fieldOfView,originfov,Time.deltaTime*3.0f);
				if (topviewdelay<0)
				{
					topviewon = 0;
					mytransform.rotation = Quaternion.Euler(50,0,0);
					movespeed = 10;
				}
			}
		}
	}
	
	
	/*public void ShakeCam()
	{
		//temp -= fov*Time.deltaTime;
		float dy = 1 * Mathf.Sin(40*Time.time);
		mytransform.position += Vector3.up *dy*Time.deltaTime;
		
	}*/
	
	public void ZoomIn(int _zoomspeed, int _fov, float _delay)
	{
		zoom = true;
		z_speed = _zoomspeed;
		fov =_fov; 
		z_time = _delay;
		fovchange = true;
		
	}
	
	public void Hitcam()
	{
		if (!story_scene)
		{
			//Todo Lee
			//script_ui.ComboPlus(0.01f);
		}
		
		dx = -dx;
		mytransform.position += hit_shake1 * dx;
		/*if  (mycamera.fieldOfView>23)
		{
			mycamera.fieldOfView -= 1;
		}*/
		//fovchange = true;
	}
	
	public void Hitcam2(float _factor)
	{
		/*if (!story_scene)
		{
			script_ui.ComboPlus();
		}*/
		mytransform.position += hit_shake3 * _factor;
		//camera.fieldOfView -= 1;
	}
	
}
