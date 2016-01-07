using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightMessage;

public class AI_Enemy01 : Unit {
	
	public int enemykind;
	public Transform ef_weapon;
	public short monmovestat;
	
	AudioClip snd_move ;
	public AudioClip  snd_attack;
	public Transform direction_arrow;
	Transform clone_weapon;
	Transform clone_arrow;
	Transform cha1;
	Transform target;
	Transform target_onlyone;
	Transform hpbar;
	Texture originTex;
	
	bool life = true;
	bool spawn_ing = false;
	bool pierce = false;
	bool impact = false;
	bool attackstart = false;
	bool attach_weaponEf = false;
	bool showme = false;
	bool lastmon = false;
	bool targetreset = false;
	short kind = 0;
	int shadow_index = 0;
	
	bool target_fix = false;
	bool poison = false;
	float poison_delay = 0;
	float magnitude_behitdir = 0;
	short old_delay = 0;
	float poison_damage = 0;
	int petrify_rate = 0;
	
	float movespeed = 0;
	float behaviour_delay = 2.0f;
	float hpbar_height = 0;
	
	int behaviour=0;
	short hp;
	private short level;
	private short maxhp;
	private short power;
	private float haveExp;
	private short block;
	private short sizekind;
	
	private float runspeed;
	private float backspeed;
	private float firerange;
	private float moving_atk;
	
	int grabstyle = 0;
	bool grabed = false;
	bool downhigh = false;
	bool risedrop = false;
	float f_risefactor = 0;
	//bool downhigh2 = false;
	
	private int chamovestat = 0;
	//int weaponweight = 0;
	//Vector3 currentposition;
	Vector3 directionVector;
	Vector3 attackstartVector;
	Vector3 attackdir;
	private float damage;
//	private int accuracy;
	float speed_idle;
	float attackrange = 5;
	//float behitrange_cha = 5;
	//float behitrange_general = 100;
	short dash = 0;
	
	MyPlayer script_cha;
	//AI_General script_general;
	SoundEf_slash script_sound;
	CamMove script_cam;
	Hp_bar script_hpbar;
	Monster_efs script_monEf;
	
	AnimationState bethrust, bekicked,attack_impact , getup;
	Quaternion lookrotation;
	//float chamondot = 0;
	
	float attackforce = 0;
	//int blockrate = 0;
	int playkind = 0;
	
	Transform mytransform;
	Animation myanimation;
	AudioSource myaudio;
	Renderer monrender;
	short att_status = 0;
	float restrictArea = 100;
	//float restrictArea_sqrt = 0;
	monster enemy;

    HUDText normalHUD;
    HUDText critHUD;

	public List<DropItem> m_dropItems;
	
	void Awake()
	{
		mytransform = transform;
		myanimation = GetComponent<Animation>();
		myaudio = GetComponent<AudioSource>();
		script_monEf = GameObject.FindWithTag("efs_mon").GetComponent<Monster_efs>();
		enemy = GameObject.FindWithTag("Respawn").GetComponent<DB_Monster>().enemy[enemykind];
		//Debug.Log(enemykind);
		cha1 = GameObject.FindWithTag("Player").transform;
		script_cha = cha1.GetComponent<MyPlayer>();
		script_sound = GameObject.FindWithTag("sound").GetComponent<SoundEf_slash>();
		script_cam = Camera.main.GetComponent<CamMove>();
	}

	public override Vector3 GetModPos()
	{
		return mytransform.Find ("mon").position;
	}
	//璁剧疆鍔ㄤ綔
	void setAnimation()
	{
		myanimation["move"].speed = enemy._speed_move;
		myanimation["down"].speed = 0.24f;
		myanimation["down_high"].speed =  0.28f;
		myanimation["m_attack1"].speed = enemy._speed_m_attack1;
		myanimation["m_attack1_i"].speed = enemy._speed_m_attack1_i;
		
		myanimation["idle"].speed = enemy._speed_idle  - 0.05f;
		speed_idle = myanimation["idle"].speed;
		
		/////////////////////////////////////////////
		myanimation["down"].layer = 2;
		myanimation["down_high"].layer = 2;
		myanimation["move"].layer = 0;
		myanimation["m_attack1"].layer = 1;
		myanimation["m_attack1_i"].layer = 1;
		
		myanimation["idle"].layer = 0;
	}
	void Start () 
	{
		//level = 	enemy._level ;
		maxhp += enemy._maxhp;
		power += enemy._power;
		haveExp += enemy._haveExp;
		block += enemy._block;
		sizekind = enemy._sizekind;
		runspeed = enemy._runspeed;
		backspeed = enemy._backspeed;
		firerange = enemy._firerange;
		moving_atk = enemy._moving_atk;
		
		kind = enemy._kind;
		dash = enemy._dash;
		
		attach_weaponEf = enemy._attach_ef;
		//璁剧疆鍔ㄤ綔
		setAnimation ();
		monmovestat = 0;
		
		monrender = mytransform.GetChild(1).GetComponent<Renderer>();
		originTex = monrender.material.mainTexture;
		
		InvokeRepeating("SetDir",0.1f,0.5f);
		
		hp = maxhp;
		/*
		weaponweight = script_cha.weapon_kind;
		if (weaponweight == 0)
			weaponweight = 50;
		else if (weaponweight == 1)
			weaponweight = 30;
		else
			weaponweight = 55;*/
		
		//accuracy = script_cha.GetCurCharData().m_hitrate;	
		
		snd_move = script_monEf.snd_move[Random.Range(0,3)];
		hpbar = script_monEf.SetHpbar();
		hpbar.position = mytransform.position;
		
		hpbar_height = 0.1f+sizekind*0.007f;
		script_hpbar = hpbar.GetComponent<Hp_bar>();
		script_hpbar.Damaged(maxhp,hp,mytransform,hpbar_height,0);
		
		shadow_index = script_monEf.CreatShadow(mytransform.GetChild(0),1);
		//myanimation.Stop();		
	}
	
	/*public void TargetMe(Transform _target)
	{
		target = _target;
	}*/
	/*
	 * 16 stunattack    
	 * 17 riseupattack2
	 * 18 shockattack
	 * 19 darkattack
	 * 20 nomalattack   鏅?氭敾鍑荷	 * 21 powerattack   
	 * 22 skillattack   鎶鑳芥敾鍑荷	 * 23 poisonattack
	 * 24 deathattack
	 * 25 generalattack
	 * 26 pierceattack
	 * 27 crowdattack
	 * 28 pushattack    鏅?氭敾鍑荷	 * 29 dropItem
	 * 30 burnattack
	 * 31 coldattack    鍐板睘鎬ф敾鍑荷	 * */
	void OnTriggerEnter(Collider other)
	{
		int attack_obj_layer = other.gameObject.layer;
		int atk;
		if (grabed || !life) return;
		else if (attack_obj_layer >=16)
		{
			//Debug.Log(block);
			//push = false;
			//accuracy = script_cha.GetCurCharData().m_hitrate;	
			downhigh = script_cha.m_attackRising;

			HeroData hero = script_cha.GetCurCharData();
			atk = MonoInstancePool.getInstance<HeroManager> ().calcAttack(hero);
            atk = Random.Range(2, 6);

            
            Vector3 pos = transform.position;
            pos.y += .16f;

            if (normalHUD == null || critHUD == null)
            {
                GameObject go = KMTools.AddGameObj(gameObject);
                go.transform.parent = transform;
                go.transform.position = pos;
                normalHUD = HUDRoot.AddNormalHarmNFollow(go.transform);
                critHUD = HUDRoot.AddCritHarmNFollow(go.transform);
            }

            if (normalHUD != null && critHUD != null)
            {
                if (atk > 5) critHUD.Add(atk.ToString(), pos);
                else normalHUD.Add(atk.ToString());

            }
            
			if (attack_obj_layer == 28)
			{
				attackdir = mytransform.position - cha1.position;
				attackdir.y = 0;
				attackdir = Vector3.Normalize(attackdir);
			}
			else
			{
				attackdir = mytransform.position - other.transform.position;
				attackdir.y = 0;
				magnitude_behitdir = attackdir.magnitude;
				if (magnitude_behitdir == 0)
				{
				}
				else if (magnitude_behitdir<0.08f)
					attackdir = attackdir/magnitude_behitdir *1.6f;
				else
					attackdir = attackdir/magnitude_behitdir;
			}

			//bomb effect
            //script_cha.m_ui.addBombNum();
//
//			if( GameObject.FindWithTag("Player") )
//				attack_obj_layer = 31;
//			else
//				attack_obj_layer = 30;

			//attack_obj_layer = 28;

			switch(attack_obj_layer)
			{
			case 20:	// normal attack
				attackforce = 40;
				//Todo Lee
				//				int blockrate = Random.Range (0,100);
				//				if (blockrate<block-accuracy && monmovestat>=0)
				//				{
				//					script_cha.Blocked(mytransform.position);
				//					rigidbody.AddForce ( attackdir *10);
				//					//script_sound.SoundOn(0);
				//					return;
				//				}
				damage = atk;
				script_cam.Hitcam();
				//downhigh = false;
				target = cha1;
				script_monEf.CreatBlood (mytransform.position,attackdir);
				break;
			case 21:	// power attack
				attackforce = 30;
				damage = atk;
				script_cam.Hitcam2(1);
				downhigh = true;
				target = cha1;
				script_monEf.CreatHitEffect_Only (mytransform.position,attackdir);
				break;
			case 22:	// skill attack
//				attackforce = 10;
//				damage = other.rigidbody.mass ;
			//	script_cam.Hitcam();
//				downhigh = true;
				target = cha1;
				HitProcess(other.GetComponent<Rigidbody>().mass);
				script_monEf.CreatHitEffect_Only (mytransform.position,attackdir);
				break;
			case 23:	// poison attack
				attackforce = 10;
				float poisonMass = other.GetComponent<Rigidbody>().mass;
				if (poisonMass == 0.1f)
				{
					damage = 0;
					poison = true;
					poison_damage = atk*0.6f ;
					poison_delay = 4;
					downhigh = false;
					target = cha1;
					return;
					//Debug.Log("tt");
				}
				else
				{
					poison = true;
					poison_damage = poisonMass ;
					damage = poison_damage*50;
					script_cam.Hitcam();
					downhigh = true;
					poison_delay = 5;
					target = cha1;
					script_monEf.CreatHitEffect_Only (mytransform.position,attackdir);
				}
				break;
			case 24:	// death attack
				attackforce = 0;
				script_cam.Hitcam();
				life = false;
				petrify_rate = (int)other.GetComponent<Rigidbody>().mass;
				gameObject.layer = 10;
				StartCoroutine(Petrify());
				monrender.material.mainTexture = script_monEf.attribute_tex[1];
				target = cha1;
				script_hpbar.Damaged(maxhp,hp,mytransform,hpbar_height,2);
				break;
			case 25:	// arrow attack
				attackforce = 60;
				damage =  atk;
				target = cha1;
				script_monEf.CreatHitEffect_Only (mytransform.position,attackdir);
				downhigh = false;
				break;
			case 26:	// pierce attack
				myanimation.AddClip(script_monEf.pierce,"pierced");
				myanimation["pierced"].speed = 0.3f;
				StartCoroutine(Pierced());
				attackforce = 0;
				pierce = true;
				life = false;
				GetComponent<Collider>().enabled = false;
				damage = other.GetComponent<Rigidbody>().mass;
				hp -= (short)damage;
				target = cha1;
				script_hpbar.Damaged(maxhp,0,mytransform,9,0);
				script_monEf.CreatHitEffect_Only (mytransform.position,attackdir);
				break;
			case 27:	// crowd attack
				attackforce = 10;
				damage = other.GetComponent<Rigidbody>().mass;
				target =  other.transform;
				script_monEf.CreatHitEffect_Only (mytransform.position,attackdir);
				targetreset = true;
				downhigh = false;
				break;
			case 28:	// push attack
				attackforce = 40;
				damage = atk;
				script_cam.Hitcam();
				//downhigh = false;
				target = cha1;
				script_monEf.CreatBlood (mytransform.position,attackdir);
				break;
			case 29:   //riseup attack
				attackforce = 0;
				damage = atk*0.4f;
				//script_cam.Hitcam();
				downhigh = false;
				if(risedrop)
					f_risefactor = 0.6f;
				else
				{
					mytransform.rotation = Random.rotation;
					f_risefactor = 3.4f;
				}
				risedrop = true;
				target = cha1;
				script_monEf.CreatHitEffect_Only (mytransform.position,attackdir);
				break;
				
			case 30:	// burn attack
				attackforce = 40;
				damage = atk;
				if (other.transform.root == cha1)
					script_cam.Hitcam();
				target = cha1;
				if (att_status != 2)
				{
					monrender.material.mainTexture = script_monEf.attribute_tex[0];
					//script_hpbar.Damaged(maxhp,hp,mytransform,hpbar_height,2);
					script_monEf.CreatBlood (mytransform.position,attackdir);
					//CancelInvoke("BurnDamage");
					InvokeRepeating("BurnDamage",0.5f,1.0f);
					StartCoroutine(Burn());
					att_status = 1;
				}
				break;
				
			case 31:	// cold attack
				attackforce = 40;
				downhigh = false;
				damage = atk;
				if (other.transform.root == cha1)
					script_cam.Hitcam();
				target = cha1;
				if (att_status != 1)
				{
					if (!myanimation.IsPlaying("down_high"))
					{
						myanimation.enabled = false;
						//script_hpbar.Damaged(maxhp,hp,mytransform,hpbar_height,2);
						monrender.material.mainTexture = script_monEf.attribute_tex[1];
						script_monEf.CreatBlood (mytransform.position,attackdir);
						StartCoroutine(Freeze((short)(damage)));
						att_status = 2;
					}
				}
				break;
			case 16:	// stun attack
				attackforce = -10;
				downhigh = false;
				damage = 0;
				//script_cam.Hitcam();
				target = cha1;
				if (att_status != 1)
				{
					myanimation.enabled = false;
					//script_hpbar.Damaged(maxhp,hp,mytransform,hpbar_height,2);
					//script_monEf.CreatBlood (mytransform.position,attackdir);
					StartCoroutine(Freeze((short)(damage)));
					att_status = 2;
				}
				break;
			case 17:   //riseup attack2
				attackforce = 0;
				damage = atk*0.2f;
				//damage = other.rigidbody.mass ;
				script_cam.Hitcam2(0.08f);
				downhigh = false;
				
				if(risedrop)
					f_risefactor = 0.6f;
				else
				{
					mytransform.rotation = Random.rotation;
					f_risefactor = 1.2f;
				}
				risedrop = true;
				target = cha1;
				script_monEf.CreatBlood (mytransform.position,attackdir);
				//script_monEf.CreatBlood_Only (mytransform.position,attackdir);
				break;
				
			case 18:	// shock attack	
				attackforce = 40;
				damage = atk;
				if (other.transform.root == cha1)
					script_cam.Hitcam();
				target = cha1;
				if (att_status != 3)
				{
					monrender.material.mainTexture = script_monEf.attribute_tex[2];
					//script_hpbar.Damaged(maxhp,hp,mytransform,hpbar_height,2);
					script_monEf.CreatBlood (mytransform.position,attackdir);
					//CancelInvoke("BurnDamage");
					InvokeRepeating("ShockDamage",0.5f,0.1f);
					StartCoroutine(Shock((short)(damage)));
					att_status = 3;
				}
				break;
				
			case 19:	// darken attack
				attackforce = 40;
				damage = atk;
				if (other.transform.root == cha1)
					script_cam.Hitcam();
				target = cha1;
				//if (clone_weapon!=null)
				//clone_weapon.gameObject.layer = 20;
				if (att_status != 4)
				{
					monrender.material.mainTexture = script_monEf.attribute_tex[3];
					//script_hpbar.Damaged(maxhp,hp,mytransform,hpbar_height,2);
					script_monEf.CreatBlood (mytransform.position,attackdir);
					//InvokeRepeating("BurnDamage",0.5f,1.0f);
					StartCoroutine(Darken());
					att_status = 4;
				}
				break;	
			}
			
			movespeed = 0;
			script_sound.SoundOn(1);
			if (!life)
			{
				if (pierce)
				{
					myanimation.Play("pierced");
					pierce = false;
				}
				else
					myanimation.Stop();
			}
			else
			{
				myanimation.Stop();
				
				if (downhigh)
				{
					mytransform.Rotate ( 0, Random.Range(0,360),0);
					myanimation.Play("down_high");
				}
				else
				{
					myanimation.Play("down");
				}
				
				GetComponent<Rigidbody>().AddForce (attackdir * attackforce);
				
				if (directionVector == Vector3.zero)
					directionVector = -Vector3.forward;
				
				if (damage >0)
				{
					hp -= (short)damage;
					script_monEf.SetDamageNum(mytransform.position,(short)damage,attackdir);
					script_hpbar.Damaged(maxhp,hp,mytransform,hpbar_height,-1);
				}
				if(Random.Range (0,5) == 0)
				{
					myaudio.clip = script_monEf.ScreamSFX();
					myaudio.Play();
				}
			}
			////////////////dead
			
			if (hp <=0 && life)
			{
				if (!risedrop)	
					Dead(2);
				
			}
			else if(target_fix)
				target = target_onlyone;
		}
	}

	public void HitProcess( float skillId )
	{
		SkillItem skill = SkillItem.GetStaticData ((int)skillId); //skill obj
		int hitMotion = skill.m_effects [0].RT_effect;
		switch (hitMotion) 
		{
			case 1:
				attackforce = 10;
			break;
			case 2:
				attackforce = 40;
			break;
			case 3:
				downhigh = true;
			break;
		}
		damage = 3;//skill.parameter1_0;
	}
	
	public void SummonStart()
	{
		//gameObject.layer = 10;
		float summon_delay = 1.5f;
		if (enemy._kind ==2)
		{
			myanimation.AddClip(script_monEf.summon[0],"summon");
			myanimation["summon"].speed = 0.2f;
		}
		else
		{
			myanimation.AddClip(script_monEf.summon[1],"summon");
			myanimation["summon"].speed = 0.6f;
			summon_delay = 0.4f;
		}
		//life = false;
		spawn_ing = true;
		
		mytransform.rotation = Quaternion.Euler(0,Random.Range(0,360),0);
		myanimation.Stop();
		//myanimation.Play("down");
		//Debug.Log("tt");
		
		myanimation.Play("summon");
		
		Invoke ("SummonFinish",summon_delay);
	}
	public void SummonFinish()
	{
		//gameObject.layer = 8;
		//life = true;
		spawn_ing = false;
	}
	
	
	public void SetLevel(short _level ,int _playkind , bool _issummon , float _restrictArea)
	{
		level = (short) (_level+1);
		restrictArea = _restrictArea;
		//restrictArea_sqrt = Mathf.Sqrt (restrictArea-0.05f);
		//maxhp += (short)(level *10);//4
		maxhp +=(short)( 0.1445f * level *level + 6.3873f * level -5) ;
		power += (short)(0.0058f * level*level +1.008f * level -5); 
		//power += (short)(level);
		block += (short)(level*0.4f);
		hp = maxhp;
		
		haveExp += level *0.1f;
		
		playkind = _playkind;
		if (playkind == 6)
		{
			target_fix = true;
			target_onlyone  = GameObject.FindWithTag("general").transform;
			target = target_onlyone;
		}
		else
			target = cha1;
		
		if (_issummon)
			SummonStart();
		else
			myanimation.Stop();
		//Debug.Log(_issummon);
	}

	public void SetDropItems(  )
	{
		FightManager fightMng =  MonoInstancePool.getInstance<FightManager> ();
		fightMng.getItem ();
		if( fightMng.temp_items.Count <= 0 )
			return;
		m_dropItems = new List<DropItem> (fightMng.temp_items);
	}
	
	void BurnDamage()
	{
		HeroData hero = script_cha.GetCurCharData();
		int atk = MonoInstancePool.getInstance<HeroManager> ().calcAttack(hero);
		short dotdamage = (short)(atk/10);
		if (dotdamage<1)
			dotdamage = 1;
		hp -= dotdamage;
		script_monEf.SetDamageNum(mytransform.position,dotdamage,attackdir);
		script_hpbar.Damaged(maxhp,hp,mytransform,hpbar_height,-1);
		if (hp <=0)
			Dead(0);
	}
	
	void ShockDamage()
	{
		myanimation.Stop();
		myanimation.Play("down");
	}
	
	public IEnumerator Freeze(short _damage)
	{
		yield return new WaitForSeconds(2);		
		att_status = 0;
		myanimation.enabled = true;
		monrender.material.mainTexture =  originTex;
		/*hp -= _damage;
		if (hp <=0)
			Dead(0);
		script_hpbar.Damaged(maxhp,hp,mytransform,hpbar_height,-1);*/
	}
	public IEnumerator Burn()
	{
		yield return new WaitForSeconds(3);		
		att_status = 0;
		monrender.material.mainTexture =  originTex;
		//script_hpbar.Damaged(maxhp,hp,mytransform,hpbar_height,0);
		CancelInvoke("BurnDamage");
	}
	public IEnumerator Shock(short _damage)
	{
		yield return new WaitForSeconds(1.2f);	
		att_status = 0;
		monrender.material.mainTexture =  originTex;
		/*short dotdamage = _damage;
		hp -= dotdamage;
		script_monEf.SetDamageNum(mytransform.position,dotdamage,attackdir);
		script_hpbar.Damaged(maxhp,hp,mytransform,hpbar_height,-1);
		if (hp <=0)
			Dead(0);
		*/
		CancelInvoke("ShockDamage");
	}
	public IEnumerator Darken()
	{
		yield return new WaitForSeconds(2);		
		att_status = 0;
		//if (clone_weapon!=null)
		//clone_weapon.gameObject.layer = 13;
		monrender.material.mainTexture =  originTex;
		//script_hpbar.Damaged(maxhp,hp,mytransform,hpbar_height,0);
		//CancelInvoke("BurnDamage");
	}
	
	public IEnumerator Petrify()
	{
		int _rate = Random.Range (0,100);
		yield return new WaitForSeconds(2.5f);		
		if (petrify_rate > _rate)
		{
			Dead(0);
		}
		else
		{
			gameObject.layer = 8;
			monrender.material.mainTexture =  originTex;
			life = true;
			script_hpbar.Damaged(maxhp,hp,mytransform,hpbar_height,0);
		}
	}
	
	/*public void DotDamage(short _damage)
	{
		hp -= _damage;
	}*/
	
	public IEnumerator Pierced()
	{
		yield return new WaitForSeconds(4.0f);	
		//hp -= (short)(damage *3);
		if (hp<=0)
		{
			Dead(0);
		}
		else
		{
			script_hpbar.Damaged(maxhp,hp,mytransform,hpbar_height,0);
		}
		myanimation.Stop();
		myanimation.Play("down");
		script_cam.Hitcam();
		script_monEf.CreatHitEffect_Only (mytransform.position,attackdir);
		movespeed = 0;
		script_sound.SoundOn(1);
		GetComponent<Collider>().enabled = true;
		life = true;
	}
	
	public void Dead(int _kind)
	{
		monmovestat = -4;
		life = false;
		script_hpbar.FreeSelect();
		lastmon = false;
		hp = 0;
		Vector3 deadpos = mytransform.position;
		//deadpos[1] = 0;
		attackdir[1] = 0;
		
		if (_kind ==2)	//human,beast
		{
			script_sound.SoundOn(4);
			Destroy (gameObject);
			script_monEf.EnemyDead(kind,deadpos, monrender.material.mainTexture ,mytransform.localScale,attackdir,enemykind);
		}
		else if (_kind ==1)	//grab
		{
			//collider.enabled = false;
			Destroy (gameObject,2.0f);
			
			bekicked.wrapMode = WrapMode.ClampForever;

			script_monEf.EnemyDead(0,deadpos, null ,Vector3.zero,Vector3.zero,enemykind);
			script_monEf.DestroyShadow(shadow_index);
		}
		else if (_kind==0) //poison
		{
			script_sound.SoundOn(4);
			Destroy (gameObject);
			script_monEf.EnemyDead(1,deadpos, null ,Vector3.zero,Vector3.zero,enemykind);
		}
		else if (_kind==3) //all
		{
			script_sound.SoundOn(4);
			Destroy (gameObject);
			script_monEf.EnemyDead(3,deadpos, monrender.material.mainTexture ,mytransform.localScale,Vector3.zero,enemykind);
		}
		
		//script_cha.GainExp(haveExp);	
		script_monEf.SetItemBox(level,mytransform.position,m_dropItems);

		if (clone_arrow != null)
		{
			Destroy(clone_arrow.gameObject);
			clone_arrow = null;
		}
		if (clone_weapon != null)
		{
			Destroy (clone_weapon.gameObject);
			clone_weapon = null;
		}
	}
	
	public void Grabed()
	{
		if (att_status >0)
			return;
		if(!grabed)
		{
			attackdir = Vector3.Normalize (mytransform.position - Vector3.right*cha1.position.x - Vector3.forward*cha1.position.z);
			mytransform.forward = -attackdir;
			myanimation.Stop();
			grabstyle = Random.Range (0,3);
			if (sizekind == 20)
				grabstyle += 3;
			else if (kind  !=2)
				grabstyle = 6;
			
			Destroy(GetComponent<Collider>().gameObject);
			//gameObject.layer = 10;
			//gameObject.layer = 15;
			//grabstyle = 5;
			if (grabstyle != 6)
			{
				myanimation.AddClip(script_monEf.begrab[grabstyle],"downforever");
				myanimation.AddClip(script_monEf.bethrust[grabstyle],"bethrust");
				myanimation.AddClip(script_monEf.bekicked[grabstyle],"bekicked");
				myanimation.AddClip(script_monEf.getup[grabstyle],"getup");
			}
			myanimation.Play("downforever");
			myanimation["downforever"].speed = script_monEf.speed_begrab[grabstyle];
			myanimation["downforever"].layer = 3;
			
			bethrust = myanimation.PlayQueued("bethrust");
			bethrust.speed = script_monEf.speed_bethrust[grabstyle];
			bethrust.layer = 3;
			
			bekicked = myanimation.PlayQueued("bekicked");
			bekicked.speed = script_monEf.speed_bekicked[grabstyle];
			bekicked.layer = 3;
			
			GetComponent<Rigidbody>().AddForce ( attackdir * script_monEf.force_grab[grabstyle]);
			
			//script_cha.Grab( grabstyle ,mytransform.position);
			grabed = true;
			poison_delay = -1;
		}
	}
	
	public void CountDown()
	{
		if (life)
		{
			clone_arrow = (Transform)Instantiate (direction_arrow, cha1.position , Quaternion.identity);
			showme = true;
			lastmon = true;
		}
	}
	
	public void SetDir()
	{
		if (!life | spawn_ing) return;
		//chapos = cha1.position;
		chamovestat = script_cha.m_curStat;
		
		if (target ==null)
		{
			target = cha1;
		}
		/*else if (target.position.y >2)
		{
			target = cha1;
		}*/
		
		switch (att_status)
		{
		case 4:
			attackrange = 2;
			directionVector = mytransform.position - target.position;
			directionVector [1] = 0;
			directionVector = Vector3.Normalize(directionVector);
			break;
		case 3:
			directionVector = -mytransform.forward;
			attackrange = 2;
			break;
		case 2:	
			directionVector = Vector3.zero;
			attackrange = 2;
			break;
		default :
			attackrange = Vector3.Distance (mytransform.position,target.position);
			directionVector = (target.position-mytransform.position);
			directionVector [1] = 0;
			directionVector = Vector3.Normalize(directionVector);
			break;
		}
		
		if (directionVector != Vector3.zero)
			lookrotation = Quaternion.LookRotation(directionVector);
		
		
		if (behaviour_delay<0)
		{
			behaviour = Random.Range (0,6);
			if (behaviour == 0)
			{
				myaudio.clip = snd_move;
				myaudio.Play();
			}
			behaviour_delay = 2.0f;
		}
		///////////////////////////////////	Attack!!!
		if (attackrange < firerange )
		{
			if (!attackstart)
			{
				if (chamovestat <110 && monmovestat >=0)
				{
					myanimation.Play("m_attack1");
					attack_impact = myanimation.PlayQueued("m_attack1_i",QueueMode.CompleteOthers);
					attack_impact.speed = myanimation["m_attack1_i"].speed;
					attackstart = true;
					attackstartVector = directionVector;
					if (targetreset)
					{
						target = cha1;
						targetreset = false;
					}
				}	
				else
				{
					movespeed = backspeed;
					myanimation["idle"].speed = speed_idle *(-0.5f);
					myanimation.CrossFade("idle");
					behaviour = -1;
					behaviour_delay = 1;
				}
			}
		}		
		else if (monrender.isVisible)
		{
			if (behaviour == -1)
			{}
			else if (behaviour>=3)
			{
				myanimation["idle"].speed = speed_idle;
				movespeed = runspeed*0.4f;
				myanimation.CrossFade("idle");	
			}
			else
			{
				movespeed = runspeed;
				myanimation.CrossFade("move");
			}
			
			if (lastmon)
			{
				showme = false;
				clone_arrow.GetComponent<Renderer>().enabled = false;
			}
			//monrender.enabled = true;
		}
		else
		{
			movespeed = runspeed * Random.Range(0.7f,1.0f);
			myanimation.Stop();
			//monrender.enabled = false;
			if (directionVector!= Vector3.zero)
				mytransform.rotation = Quaternion.LookRotation(directionVector);
			if (lastmon)
			{
				showme = true;
				clone_arrow.GetComponent<Renderer>().enabled = true;
			}
		}
	}
	
	void Update () 
	{
		bool b = false;
		target = cha1;
		
		if (!life ) return;
		if (risedrop)
		{
			mytransform.position += Vector3.up * f_risefactor * Time.deltaTime;
			f_risefactor -= Time.deltaTime*5;
			if (mytransform.position.y <0)
			{
				myanimation.Play("down");
				mytransform.position= new Vector3(mytransform.position.x,0,mytransform.position.z);
				risedrop = false;
				f_risefactor = 0;
				HeroData hero = script_cha.GetCurCharData();
				int atk = MonoInstancePool.getInstance<HeroManager> ().calcAttack(hero);
				damage = atk;

				hp -= (short)damage;
				if (hp<=0)
					Dead(3);
				else if (attackdir != Vector3.zero)
					mytransform.rotation = Quaternion.LookRotation(attackdir);
				else
					mytransform.rotation = Quaternion.identity;
				//script_sound.SoundOn(2);
			}
			else
				return;
		}
		
		behaviour_delay -= Time.deltaTime;
	
		/*if (attackrange>1)
		{
			monmovestat = 1;
		}*/
		if (grabed)
		{
			if (myanimation.IsPlaying ("downforever"))
			{	
				//script_cha.Grabfinish(mytransform.position , mytransform.forward);
				monmovestat = -2;
				mytransform.position = cha1.position;
			}
			
			else if (myanimation.IsPlaying ("bethrust"))
			{
				//script_cha.Grabfinish(mytransform.position , mytransform.forward);
				
				if (monmovestat != -3)
				{
					/*float chasp = script_cha.sp;
					float grabdamage = (maxhp/50.0f) * chasp;
					float reducesp = Mathf.Min (((float)hp/(float)maxhp* 50.0f ) ,chasp);
					hp = (short)Mathf.Max(hp-(short)grabdamage, 0);
					script_cha.Spcharge(-(int)reducesp);*/
					hp = 0;
					script_hpbar.Damaged(maxhp,hp,mytransform,hpbar_height,0);
					
					//Transform hand = GameObject.Find ("Bip01/Bip01 Pelvis/Bip01 Spine/Bip01 Spine1/Bip01 R Clavicle/Bip01 R UpperArm/Bip01 R Forearm/Bip01 R Hand");
					Transform hand = GameObject.Find ("weapon_dummy").transform;
					Quaternion hand_rotation =  Quaternion.LookRotation(-hand.forward,new Vector3(0,-1.3f,1));
					script_monEf.CreatGrabBlood (hand.position + hand.forward *0.01f,hand_rotation);
					
					script_cam.Hitcam2(1);
					script_sound.SoundOn(3);
				}
				monmovestat = -3;
			}
			
			else if (myanimation.IsPlaying ("bekicked"))
			{
				if (monmovestat != -4)
				{
					GetComponent<Rigidbody>().AddForce ( mytransform.forward * script_monEf.force_kick[grabstyle]);
					
					script_cam. Hitcam2(1);
					script_sound.SoundOn(2);
					
					if (hp <= 0 )
					{
						Dead(1);
					}
					else
					{
						if(grabstyle !=6)
						{
							myanimation.AddClip(script_monEf.getup[grabstyle],"getup");
						}
						getup = myanimation.PlayQueued("getup");
						getup.speed = script_monEf.speed_getup[grabstyle];
					}
				}
				monmovestat = -4;
				grabed = false;
			}
		}
		
		else if (myanimation.IsPlaying ("getup"))
		{
			monmovestat = 0;
		}
		else if (myanimation.IsPlaying ("summon"))
		{
			monmovestat = 0;
		}
		
		else if (myanimation.IsPlaying ("down_high"))
		{
			monmovestat = -1;
		}
		
		else if (myanimation.IsPlaying ("down"))
		{
			monmovestat = -1;
		}
		
		else if (myanimation.IsPlaying ("m_attack1"))
		{
			impact = false;
			monmovestat = 11;
			lookrotation = Quaternion.LookRotation(attackstartVector);
			mytransform.rotation = Quaternion.Lerp (mytransform.rotation, lookrotation, Time.deltaTime *6.0f);
			mytransform.position += attackstartVector * Time.deltaTime * moving_atk;
		}
		else if (myanimation.IsPlaying ("m_attack1_i"))
		{
			monmovestat = 12;
			if(!impact)
			{
				impact = true;
				Vector3 efpos = mytransform.position + Vector3.up* ef_weapon.localPosition.y;//Vector3.up*mytransform.localScale.y*0.05f; //+ directionVector * 0.1f;
				GetComponent<Rigidbody>().AddForce(mytransform.forward * dash);
				
				if (clone_weapon == null)
				{
					clone_weapon = (Transform)Instantiate (ef_weapon,efpos, mytransform.rotation);
					clone_weapon.GetComponent<WeaponDamage>().PressDamage(power);
					if (attach_weaponEf)
					{
						clone_weapon.parent = mytransform;
					}
				}
				else
				{
					clone_weapon.position = efpos;
					clone_weapon.rotation = mytransform.rotation;
					clone_weapon.gameObject.active = true;
				}
				GetComponent<AudioSource>().clip = snd_attack;
				myaudio.Play();
				mytransform.position = Vector3.right* mytransform.position.x + Vector3.forward* mytransform.position.z;
			}
		}
		else if (myanimation.IsPlaying ("move")||myanimation.IsPlaying ("idle") ||!myanimation.isPlaying)
		{
			attackstart = false;
			grabed = false;
			monmovestat = 1;
		}
		else
			monmovestat = 1;
		
		if(monmovestat ==1)
		{
			mytransform.position += directionVector * Time.deltaTime*movespeed;
			if (myanimation.isPlaying)
				mytransform.rotation = Quaternion.Lerp (mytransform.rotation, lookrotation, Time.deltaTime *3.0f);
		}
		
		
		if (lastmon )
		{
			if (showme)
			{
				Vector3 arrowTargetVector = Vector3.Normalize(mytransform.position - cha1.position);
				if (arrowTargetVector!= Vector3.zero)
					clone_arrow.rotation = Quaternion.LookRotation (arrowTargetVector);
				arrowTargetVector = cha1.position + Vector3.up*0.02f +arrowTargetVector *0.3f;
				clone_arrow.position = Vector3.Lerp (clone_arrow.position, arrowTargetVector, Time.deltaTime *4);
				//clone_arrow.renderer.enabled = true;
			}
		}
		
		
		if (poison)
		{
			poison_delay -= Time.deltaTime;
			if (poison_delay<0)
			{
				poison = false;
				script_hpbar.Damaged(maxhp,hp,mytransform,hpbar_height,0);
			}
			else if ((short)poison_delay!= old_delay)
			{
				hp -= (short)poison_damage;
				script_monEf.SetDamageNum(mytransform.position,(short)poison_damage,attackdir);
				script_hpbar.Damaged(maxhp,hp,mytransform,hpbar_height,1);
				old_delay = (short)poison_delay;
				if (hp<=0)
					Dead(0);
			}
		}
		
		Vector2 myposD2 = new Vector2(mytransform.position.x, mytransform.position.z);
		float distanceD2 = Vector2.SqrMagnitude(myposD2);
		
		if (distanceD2>restrictArea)
		{
			//myposD2 = myposD2/ distanceD2*restrictArea;
			//mytransform.position = new Vector3(myposD2.x,mytransform.position.y, myposD2.y);
			GetComponent<Rigidbody>().AddForce (- new Vector3(myposD2.x,0,myposD2.y) *5);
			//mytransform.position -= mytransform.position *Time.deltaTime*10;
		}
	}
	//Vector3 mypos;
}
