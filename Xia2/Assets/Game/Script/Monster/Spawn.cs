using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightMessage;

public class Spawn : MonoBehaviour {
	
	const int ENEMY_POOL = 16;
	const int BOSS_POOL = 11;
	//const int MAXDUNMAP = 6;
	

	public Transform[] stage = new Transform[10];
	float[] restrictArea = new float[8]{0.9f,0.9f,0.9f,0.8f,0.9f,0.9f,0.9f,0.9f};
	//float restrictArea = 1;
	
	public Transform[] mon_destroy = new Transform[4];
	public Transform[] enemy_source = new Transform[ENEMY_POOL];
	public Transform[] boss = new Transform[BOSS_POOL];
	//public Transform[] general = new Transform[GENERALKIND+1];
	public Transform general_portrait;
	public Transform collider_ground;
	public Transform cart;
	public Transform tower;
	public Transform barrack;
	public Transform basecamp;
	public Transform tank;
	public Transform plane_staff;
	public Transform pt_soul;
	Texture prt_general;
	Texture prt_cha;
	
	Transform c_basecamp;
	Transform[] c_tower = new Transform[6];
	Transform[] c_barrack = new Transform[6];
	Transform c_tank;
	
	Transform spawnenemy;
	Transform clone_enemy;
	Transform clone_Boss;
	Transform c_stage;
	Transform c_extraunit;
	
	Transform[] enemyset = new Transform[4];
	Transform[] clone_destroy = new Transform[6];
	Transform[] clone_soul = new Transform[3];
	//Itemdrop script_item;
	
	public Transform cut_boss;
	public int monnum;
	public short rewardkind = 0;
	public Transform pt_summonfog;
	Transform c_dun_door;
	
	int WAVEEMEMYNUM = 40;
	int totalEnemyNum;			/// total count for stage clear
	int maxEnemyNum= 15;					/// show count	
	
	int regen = -1;
	public int wave = 1;
	public int finalstage = 3;
	
	float spawndelay = 1;
	float set_spawndelay = 1;
	float g_hp_length = 0;
		
	bool countdown = false;
	bool stagefinish = false;
	//int current_costume = 0;

	int play_kind = 0;
	int bosscount = 0;
	short cur_stage_index = 1;
	short infinity_stage_index = 0;
	
	int destroy_human_kind = 0;
	int destroy_beast_kind = 3;
	int destroy_last_kind = 0;
	//int enemysource_idx = 0;
	int enemykind = 0;
	int cur_difficulty = 0;
	int oldstageindex = -1;
	int summon_amount = 0;
	
	public int enemykill = 0;
	public int grappling = 0;
	
	Vector3 summonpos = Vector3.zero;
	Vector3 rndpos;
	Vector3 temprndpos;
	int rndpoint = 0;
	int rndoldpoint = -1;
	short allycount = 0;
	short general_index = 0;
	short g_grade = 0;
	int soulcount = 0;
	short barrack_count = 6;
	short tower_count = 6;
	GameObject last_mon;
	public bool infinitymode = false;
	
	DB_Stage script_stageDB;
	//Todo Lee
	///UI_Ingame script_IngameUI; 
	//General_Stat script_generalstat;
	///Gauge_UV script_g_hpgauge;
	DB_General script_DBgeneral;
	///Icon_Skill script_iconskill;
	MyPlayer script_cha;
	
	Transform g_hpgauge;
	public Transform icon_dead;
		
	Vector3[] spawpoint = new Vector3[8];
	int[] general_hp = new int[12];
	short[] bossindex = new short[3];
	short negativefactor= 1;
	public Texture lightmap_tank;
	int[] bosskill = new int[12];
	public int cur_general = -1;
	short bossremain = 0;
	//int cur_stage_kind = 0;
	float restrict_Factor = 100;

	public int   killMonCount = 0;
	//public Dictionary<int,int> monKilllers;   //鍑绘潃缁熻? 
	public int   m_curStageIdx = 0;

	
	void Awake()
	{
		m_curStageIdx = LevelData.curDungeonId % 3;

		//current_costume = Crypto.Load_int_key("n05");
		bosskill = PlayerPrefsX.GetIntArray ("bosskill");
		cur_difficulty = Crypto.Load_int_key("n14");
		//Debug.Log(cur_difficulty);
		script_stageDB = GetComponent<DB_Stage>();
		int cur_stage_kind =Crypto.Load_int_key("cur_stage_kind");
		cur_stage_index  = (short)Crypto.Load_int_key("cur_stage_index");
		infinity_stage_index = (short)(cur_stage_index%90);
		play_kind = Crypto.Load_int_key("play_kind");
		cur_general = Crypto.Load_int_key("cur_general");
		
		GameObject cha1 = GameObject.FindWithTag("Player");
		script_cha = cha1.GetComponent<MyPlayer>();
		
		//script_generalstat = GetComponent<General_Stat>();
		///script_iconskill = GameObject.FindWithTag("icon_skill").GetComponent<Icon_Skill>();

		if (cur_stage_kind == 11)
		{
			cur_difficulty = 0;
			infinitymode = true;
			wave = Crypto.Load_int_key("n49");
			//wave = 26;
			cur_stage_index = (short)( 2 + 3*(wave-1));
			infinity_stage_index = (short)(cur_stage_index%90);
			
			GameObject gate = Resources.Load("dun_gate") as GameObject;
			c_dun_door = (Transform)Instantiate(gate.transform, Vector3.up*55 ,Quaternion.identity);
			
			set_spawndelay = 0.4f;
			finalstage = 1000;
			WAVEEMEMYNUM = 80;
		}
		else
		{
			if (play_kind == 5)			//boss
			{
				SetMapStory(cur_stage_kind,false);
				bossremain = script_stageDB.st[cur_stage_index]._bosscount;
				finalstage = 1;
				WAVEEMEMYNUM = 120;
			}
			if (play_kind == 6)			//cart
			{
				SetMapStory(cur_stage_kind,true);
				collider_ground.position = new Vector3 (0,-0.01f,3);
				collider_ground.localScale = new Vector3 (1,0,6);
				cur_general = -1;
				c_extraunit = (Transform)Instantiate(cart,Vector3.forward *0.5f,Quaternion.identity);
				general_portrait.gameObject.active = true;
				general_portrait.GetComponent<Renderer>().material.mainTexture = Resources.Load("prt_cart") as Texture;
				set_spawndelay = 6.5f - (cur_stage_index *0.03f);
				finalstage = 1;
				WAVEEMEMYNUM = 250;
			}
			else if (play_kind == 7)			//castle
			{
				SetMapStory(cur_stage_kind,true);
				
				collider_ground.position = new Vector3 (0,-0.01f,3);
				collider_ground.localScale = new Vector3 (1,0,6);
				//cur_general = -1;
				for (int i = 0; i<3; ++i)
				{
					c_tower[2*i] = (Transform)Instantiate(tower,Vector3.forward *(i*3)+Vector3.forward*3 - Vector3.right*0.5f,Quaternion.Euler(0,45,0));
					c_tower[2*i+1] = (Transform)Instantiate(tower,Vector3.forward *(i*3)+Vector3.forward*3 + Vector3.right*0.5f,Quaternion.Euler(0,45,0));
					c_barrack[2*i] = (Transform)Instantiate(barrack,Vector3.forward *(i*3)+Vector3.forward*2+Vector3.right*0.4f ,Quaternion.Euler(0,225,0));
					c_barrack[2*i+1] = (Transform)Instantiate(barrack,Vector3.forward *(i*3)+Vector3.forward*1-Vector3.right*0.4f ,Quaternion.Euler(0,-225,0));
				}
				c_basecamp = (Transform)Instantiate (basecamp,Vector3.forward *10 ,Quaternion.identity);
				c_tank = (Transform)Instantiate (tank, Vector3.forward *(-0.5f), Quaternion.Euler(0,180,0));

				set_spawndelay = 3;
				c_stage.Find("amap").GetComponent<Renderer>().material.SetTexture("_LightMap",lightmap_tank);
				InvokeRepeating ("RegenAlly",2,2f);
				finalstage = 1;
				WAVEEMEMYNUM = 250;
			}
			else
			{
				SetMapStory(cur_stage_kind,false);
				finalstage = 3;//script_stageDB.st[cur_stage_index]._stagenum;
				WAVEEMEMYNUM = 60;
//				if(cur_stage_index ==0 )
//				{
//					WAVEEMEMYNUM = 40;
//				}
			}
			rewardkind = script_stageDB.st[infinity_stage_index]._reward;
			//Debug.Log(rewardkind);
		}

//		if (cur_general != -1)
//		{
//			script_DBgeneral = GetComponent<DB_General>();
//			int[] general_seed = new int[6];
//			general_seed = PlayerPrefsX.GetIntArray("n13");
//			general_hp = PlayerPrefsX.GetIntArray("n33");
//			GeneralHP(true);
//			
//			int cur_seed = general_seed[cur_general];
//			
//		//	script_generalstat.SetGeneral(cur_seed);
//			short general_kind = script_generalstat.general_kind;
//			short g_maxhp = script_generalstat.g_maxhp;
//			g_grade = script_generalstat.g_grade;
//			int g_hp = general_hp[cur_general];
//			if (g_hp> g_maxhp)
//				g_hp= g_maxhp;
//			general_index = script_generalstat.general_index;
//			////////test
//			//general_index = 16;
//			//general_kind = (short)(general_index%5);
//			////////
//			short g_maxatk =  script_generalstat.g_maxatk;
//			float g_atkspd =  script_generalstat.g_atkspd;
//			
//			float g_skillcooltime = script_DBgeneral.gs[general_index]._cooltime - g_atkspd * 40;
//			short g_soulcost = script_DBgeneral.gs[general_index]._soulcost;
//			if (infinitymode)
//				g_soulcost = 0;
//			short g_voice = script_DBgeneral.gs[general_index]._voice;
//			
//			//////////////////////////////////////
//			
////			script_cha.Set_General(
////				            script_DBgeneral.gs[general_index]._weapon,
////				          	general_kind,
////				            g_maxhp,
////				            g_maxatk,
////				            script_generalstat.g_def,
////				            g_atkspd,
////				            script_generalstat.g_unique,
////				            g_hp,
////							g_voice
////					);
////			
//			if (g_grade < 2)
//			{
//				//Todo Lee
//				///Destroy(general_portrait.GetChild(0).gameObject);
//			}
//			else
//			{
//				///cha1.GetComponent<Char_Skill>().Set_General_Skill(g_maxatk,script_DBgeneral.gs[general_index]._skillatk ,script_DBgeneral.gs[general_index]._skillkind);
//				///script_iconskill.Set_General(g_soulcost,g_skillcooltime,general_kind,infinitymode);
//			}
//			//Debug.Log(script_DBgeneral.gs[general_index]._skillatk);
//			//////////////////////////////////////
//			///general_portrait.gameObject.active = true;
//			prt_general = Resources.Load("prt_general" +(general_index+1).ToString()) as Texture;
//			prt_cha = Resources.Load("prt_cha") as Texture;
//			///general_portrait.renderer.material.mainTexture = prt_general;
//			
//			//if (current_costume == general_kind+11)
//				//g_soulcost = 0;
//
//			///general_portrait.GetChild(0).GetComponent<Icon_Skill_p>().SkillKind(0,general_index,0,g_soulcost);
//			
//			if (cur_difficulty !=2)
//			{
//				///g_hpgauge = GameObject.FindWithTag("p_plan").GetComponent<MakeUI>().
//				///CreatCustomPlane(new Vector2(0.24f,0.08f),0,new Vector3 (-1.39f,2.36f,1.8f),new Vector2(0.75f,0.625f),new Vector2(0.875f,0.6875f),"general_hp","Gauge_UV",0.1f ,0);
//				///script_g_hpgauge = g_hpgauge.GetComponent<Gauge_UV>();
//				///g_hp_length = (1-(float)g_hp/(float)g_maxhp)*0.125f;
//				///script_g_hpgauge.UvMove(Vector2.right * g_hp_length);
//			}
//		}
		//cur_stage_index  = (short)(cur_stage_index/3);
	}
	
	void Start () 
	{
		int bgmindex = Random.Range (1,4);
		GetComponent<AudioSource>().clip = Resources.Load("Sound/bgm_stage2") as AudioClip;
		GetComponent<AudioSource>().Play();
		GetComponent<AudioSource>().volume = 10;
		
		for (int i= 0; i<3; ++i)
		{
			clone_destroy[i] = (Transform)Instantiate(mon_destroy[i], Vector3.one*6, Quaternion.identity);
			clone_destroy[i+3] = (Transform)Instantiate(mon_destroy[3], Vector3.one*6, Quaternion.identity);
			///clone_soul[i] = (Transform) Instantiate(pt_soul,Vector3.one*31,Quaternion.identity);
		}
		
		//daytime = Random.Range (0,80);
		if (infinitymode)
			SetMapExtreme(false);
		
		monnum = 0;
		totalEnemyNum = WAVEEMEMYNUM;
		
		///script_IngameUI = GameObject.FindWithTag("ui").GetComponent<UI_Ingame>();
		
		enemykill = Crypto.Load_int_key("enemykill");
		grappling = Crypto.Load_int_key("grappling");

		MonoInstancePool.getInstance<FightManager> ().reset(WAVEEMEMYNUM);
	}
	
	public void SetMapStory(int _cur_stage_kind, bool _islinemap)
	{
		int mapline = 0;
		if (_islinemap)
			mapline = 5;
		c_stage = (Transform)Instantiate (stage[m_curStageIdx] ,Vector3.zero, Quaternion.identity);
		c_stage.name = "stage";


		//Transform pos = c_stage.FindChild ("startPosition").transform;
		//GameObject.Find ("cam_ani").transform.position = pos.position;
		
		if (!_islinemap)
		{
			for (int i=0; i<8; ++i)
			{
				Transform t = c_stage.FindChild("aaapoint");
				Transform t1 = t.GetChild(i); 
				spawpoint[i]= t1.position;
			}
		}
	}

	//< 鏋侀檺妯″紡
	public void SetMapExtreme(bool _clear)
	{
//Todo Lee
//		//Debug.Log("tt");
//		if (_clear)
//		{
//			for (int i= 0; i<6; ++i)
//			{
//				clone_destroy[i].GetComponent<Mon_Destroy>().FinishNow();
//			}
//			GameObject.FindWithTag("efs_mon").GetComponent<Monster_efs>().FinishEfs();
//		}
//		int rndindex = 0;
//		
//		rndindex = (wave-1)/8;
//		if (rndindex == oldstageindex)
//		{
//			c_stage.GetComponent<Map_extreme>().SetWave(wave);
//			return;
//		}
//		else if (rndindex >= 8)
//		{
//			return;
//		}
//		
//		/*if (rndindex == 6)
//			script_cha.MoveSpeedUp(0.24f);
//		else
//			script_cha.MoveSpeedUp(0.48f);*/
//		if (c_stage != null)
//			Destroy (c_stage.gameObject);
//		GameObject tempmap = Resources.Load("Stage_dun"+(rndindex+1).ToString()) as GameObject;
//		c_stage = (Transform)Instantiate (tempmap.transform ,Vector3.zero, Quaternion.Euler(0,Random.Range(0,360),0));
//		c_stage.name = "stage";
//		c_stage.GetComponent<Map_extreme>().SetWave(wave);
//		//c_stage.localScale = Vector3.one * rndScale;
//		float rndScale = c_stage.localScale.x;
//		restrict_Factor = restrictArea[rndindex] * rndScale;
//		
//		c_dun_door.position = -c_stage.forward * restrict_Factor;
//		c_dun_door.rotation = Quaternion.LookRotation(-c_dun_door.position);
//		c_dun_door.gameObject.active = false;
//		
//		c_stage.Find("light_dun1").rotation = Quaternion.Euler (0,120,0);
//		//Debug.Log(restrict_Factor);
//		oldstageindex = rndindex;
//		script_cha.SetRestrictArea(restrict_Factor);
//		//script_IngameUI.SetRestrictArea(restrict_Factor);
//		
//		for (int i=0; i<8; ++i)
//		{
//			spawpoint[i]= c_stage.GetChild(0).GetChild(i).position;
//		}
	}
	
	public Vector3 SetRndPoint()
	{
		//Debug.Log(play_kind);
		if (play_kind == 6)
		{
			temprndpos = c_extraunit.position + Vector3.forward * Random.Range(-1.5f,1.5f) + Vector3.right * (Random.Range(-1,1)+0.5f)*3 ;
		}
		else if (play_kind == 7)
		{
			int temp_barrack_count = 0;
			
			for (int i =0; i<6; ++i)
			{
				rndpoint = (rndpoint+1)%6;
				if (c_barrack[rndpoint] != null)
				{
					temprndpos = c_barrack[rndpoint].position;
					++ temp_barrack_count;
					break;
				}
			}
			if (temp_barrack_count ==0 )
			{
				regen = -1;
			}
			
		}
		else if(infinitymode)
		{
			rndpoint = (rndpoint+1)%8;
			temprndpos = spawpoint[rndpoint];
		}
		else
		{
			rndpoint = Random.Range(0,8);
			if (rndpoint == rndoldpoint)
				rndpoint = (rndpoint+1)%8;
			rndoldpoint = rndpoint;
			temprndpos = spawpoint[rndpoint];
		}
		return temprndpos;
	}
	
	public void OpenDundoor()
	{
		c_dun_door.gameObject.active = true;
	}

    [System.Obsolete("Use EnemyCtrl.instance.EnemyDead")]
    public void EnemyDead(int _destroy, Vector3 _pos, Texture _tex, Vector3 _scale, Vector3 _forcedir, int enemyId) { }
	
	public void CallGeneral(bool _general, int _hp, int _maxhp)
	{
		//Todo Lee
//		if (!_general)
//		{
//			general_portrait.renderer.material.mainTexture = prt_general;
//			if (g_grade >= 2)
//				general_portrait.GetChild(0).gameObject.active = false;
//		}
//		else
//		{
//			general_portrait.renderer.material.mainTexture = prt_cha;
//			if (g_grade >= 2)
//				general_portrait.GetChild(0).gameObject.active = true;
//		}
//		if (cur_difficulty !=2)
//		{
//			g_hp_length = (1-(float)_hp/(float)_maxhp)*0.125f;
//			///script_g_hpgauge.UvMove(Vector2.right * g_hp_length);
//		}
	}
	
	public void SetBGM(float _vol)
	{
		GetComponent<AudioSource>().volume = _vol;
		PlayerPrefs.SetFloat ("vol_bgm",_vol);
	}
	
	public void ChangeBGM(bool _boss)
	{
		if (_boss)
			GetComponent<AudioSource>().clip = Resources.Load("bgm_boss") as AudioClip;
		else
		{
			int bgmindex = Random.Range (1,4);
			GetComponent<AudioSource>().clip = Resources.Load("bgm_stage"+bgmindex.ToString()) as AudioClip;
		}
		GetComponent<AudioSource>().Play();
	}
	
	
	public void RegenStart()
	{
		monnum = 0;
		stagefinish = false;
		//return;
		//Debug.Log(infinity_stage_index);
		bosscount = script_stageDB.st[infinity_stage_index]._bosscount;
		//Debug.Log(cur_stage_index +" count = " + bosscount);
		if (bosscount>0)
		{
			bossindex[0] = script_stageDB.st[infinity_stage_index]._boss1;
			bossindex[1] = script_stageDB.st[infinity_stage_index]._boss2;
			bossindex[2] = script_stageDB.st[infinity_stage_index]._boss3;
		}
		totalEnemyNum = WAVEEMEMYNUM;
		regen = 0;
		
		enemyset[0] = enemy_source[0];
		enemyset[1] = enemy_source[1];
		enemyset[2] = enemy_source[2];
	}
	
	public void EnemyChange()
	{
		if (set_spawndelay >0.5f)
			set_spawndelay -= 0.3f;
		if (wave <5)
			++wave;
		for (int i=0; i<3; ++i)
		{
			int enemysource_idx = (wave + i  + (cur_stage_index%10) -1);
			enemyset[i] = enemy_source[enemysource_idx];
		}
	}

	public void ChangeBoss(Vector3 _pos,Quaternion _rot)
	{
//Todo Lee
//		clone_Boss = (Transform) Instantiate (boss[0],_pos,_rot);
//		clone_Boss.GetComponent<AI_Boss01>().SetLevel( (short)cur_stage_index,restrict_Factor);
	}
	
	public void BossAppear(short _kind)
	{
//Todo Lee
//		rndpos = SetRndPoint();
//		clone_Boss = (Transform)Instantiate (boss[_kind],rndpos,Quaternion.identity);
//		clone_Boss.GetComponent<AI_Boss01>().SetLevel((short)cur_stage_index,restrict_Factor);
//		++ monnum;
//		countdown = true;
	}
	
	public void BossCutin(int _enemykind)
	{
//Todo Lee
//		cut_boss.gameObject.active = true;
//		cut_boss.GetComponent<Cutin_BossTexture>().SetCutinTexture(_enemykind);
//		cut_boss.gameObject.active = true;
//		cut_boss.GetComponent<Cutin01>().CutinOn(new Vector3 (3,2,1),new Vector3 (0.5f,2,1), new Vector3 (7,7,0), 0.1f , 2.4f, 2.5f ,true);
//		ChangeBGM(true);
	}
	
	public void BossKill_Cheat()
	{
		if (clone_Boss != null)
		{
			Destroy (clone_Boss.gameObject);
			-- monnum;
		}
	}

	public void Summon(int _amount , Vector3 _summonpos)
	{
		
		//CancelInvoke("Summon_p");
		if (summon_amount <= 0)
		{
			//monnum += _amount;
			summon_amount = _amount;
			summonpos = _summonpos;
			InvokeRepeating("Summon_p",0.1f, 0.5f);
		}
	}
		
	void Summon_p()
	{
		//if (monnum < maxEnemyNum)
		if (monnum >0)
		{
			Vector3 rndsummonpos = summonpos + Random.onUnitSphere*0.3f;
			rndsummonpos[1] =0;
			pt_summonfog.position = rndsummonpos;
			pt_summonfog.GetComponent<ParticleSystem>().Play();
			spawnenemy = enemyset[Random.Range(0,2)];
			clone_enemy =(Transform) Instantiate (spawnenemy,rndsummonpos ,Quaternion.Euler(0,Random.Range(0,360),0));
			clone_enemy.name = "enemy";
			clone_enemy.GetComponent<Enemy>().SetLevel((short)cur_stage_index,play_kind ,true,restrict_Factor);
			//clone_enemy.GetComponent<AI_Enemy01>().
			++ monnum;
			--summon_amount;
		}
		else 
		{
			summon_amount = 0;
			CancelInvoke("Summon_p");
		}

		if (summon_amount <=0)
		{
			summon_amount = 0;
			CancelInvoke("Summon_p");
		}
	}
			
			
	
	public void BossKill(int _enemykind)
	{
		if(_enemykind ==0)
			bosskill[9] ++;
		else
			bosskill[_enemykind] ++;
		PlayerPrefsX.SetIntArray("bosskill",bosskill);
		
		if (infinitymode)
		{
			
		}
		else if (bosscount<=0)
		{
			--bossremain;
//Todo Lee
//			if (bossremain <=0)
//				script_IngameUI.WaveSet(100);
		}
		ChangeBGM(false);
	}
	
	public void FinalWave()
	{
		///script_IngameUI.WaveSet(finalstage-1);
		wave =finalstage;
	}
	
	public void GeneralHP(bool _isstart)
	{
//Todo Lee
		if (cur_general != -1)
		{
			int _span = TimeControl.SubtractDelay(1);
			for (int i = 0; i<12; ++i)
			{
				general_hp[i] = general_hp[i] + (int)(_span *0.2f);
			}
			if (!_isstart)
				general_hp[cur_general] = 150; // script_cha.g_hp;
			PlayerPrefsX.SetIntArray ("n33",general_hp);
			TimeControl.SetDelay(1);
		}
	}
	
	public void GeneralDead()
	{
		//generaldead = true;
		//general_portrait.gameObject.active = false;
		//general_portrait.collider.enabled = false;
//Todo Lee
//		if (g_grade >= 2)
//			general_portrait.GetChild(0).gameObject.active = false;
//		GeneralHP(false);
//		if (cur_difficulty != 2)
//			g_hpgauge.gameObject.active = false;
//		icon_dead.gameObject.active = true;
	}
	
	/*public void CharacterDead()
	{
		g_hpgauge.gameObject.active = false;
		icon_dead.gameObject.active = true;
	}*/

	
	public void RegenAlly()
	{
		if (allycount == 0)
		{
			if (c_tank.position.y >= 10)
			{
				c_tank.position = Vector3.forward *(-0.5f);
				c_tank.gameObject.active = true;
			}
		}
		else if (allycount <8)
		{
			negativefactor *= -1;
			Instantiate (plane_staff, Vector3.right*( Random.Range (0.1f,0.3f))*negativefactor -Vector3.forward *0.5f, Quaternion.identity);
		}
		else if (allycount >12)
			allycount = -1;
		
		++allycount;
	}
	
	void Update () 
	{
//		return;
		//Debug.Log(monnum);
		/*if(Input.GetKeyDown("q"))
		{
			c_stage.GetComponent<Map_extreme>().TrapStop();
			script_IngameUI.WaveSet(wave);
			wave ++;
		}*/
		if (regen == 0)	//start regen monster 1,2,3
		{	
//			for ( int i = 0; i<3; ++i)
//			{
//				rndpos = SetRndPoint();
//				spawnenemy = enemyset[0];
//				clone_enemy =(Transform)Instantiate (spawnenemy,rndpos,Quaternion.identity);
//				clone_enemy.name = "enemy";
//				clone_enemy.GetComponent<Enemy>().SetLevel((short)cur_stage_index,play_kind ,infinitymode,restrict_Factor);
//				clone_enemy.GetComponent<Enemy>().SetDropItems ();
//				if (infinitymode)
//				{
//					pt_summonfog.position = rndpos;
//					pt_summonfog.particleSystem.Play();
//				}
//				monnum ++;
//				totalEnemyNum --;
//			}
			regen = 1;
			countdown = false;
		}
		
		else if (regen >0)  //random regen monsters
		{
			if (spawndelay >0)
			{
				spawndelay -= Time.deltaTime;
			}
			else if (totalEnemyNum>0)
			{
				if (monnum < maxEnemyNum)
				{
					rndpos = SetRndPoint();
					
					enemykind = Random.Range (0,100);
					
					if( totalEnemyNum > 35 )
						enemykind = 0;
					else if( totalEnemyNum > 15 )
					{
						enemykind = Random.Range (0,100);
						if (enemykind<60)
							enemykind = 0;
						else 
							enemykind = 1;
					}else 
					{
						if (enemykind<45)	enemykind = 0;
						else if (enemykind<80)	enemykind = 1;
						else 	enemykind =2;
					}
					
					int a;
					a = 0;
					
//					spawnenemy = enemyset[enemykind];
//					clone_enemy =(Transform) Instantiate (spawnenemy,rndpos,Quaternion.identity);
//					clone_enemy.name = "enemy";
//					clone_enemy.GetComponent<Enemy>().SetLevel((short)cur_stage_index,play_kind ,infinitymode,restrict_Factor);
//					clone_enemy.GetComponent<Enemy>().SetDropItems ();

					//clone_enemy.GetComponent<AI_Enemy01>().CountDown();

					if (infinitymode)
					{
						pt_summonfog.position = rndpos;
						pt_summonfog.GetComponent<ParticleSystem>().Play();
					}
					monnum ++;
					totalEnemyNum --;
					spawndelay = set_spawndelay;
				}
			}
			else if (totalEnemyNum <=0)
			{
				if (wave >= finalstage)
				{
					if (bosscount > 0 )
					{
						spawndelay = 1;
						BossAppear(bossindex[script_stageDB.st[infinity_stage_index]._bosscount -bosscount]);
						--bosscount;
						if (bosscount<=0)
							regen = -2;
					}
					else
						regen = -2;
				}
				else if (infinitymode)
				{
					if (bosscount > 0)
					{
						BossAppear(bossindex[script_stageDB.st[infinity_stage_index]._bosscount-bosscount]);
						--bosscount;
						if (bosscount<=0)
						{
							cur_stage_index= (short)(cur_stage_index+3);
							infinity_stage_index = (short)(cur_stage_index %90);
							regen = -2;
						}
					}
					else
					{
						cur_stage_index= (short)(cur_stage_index+3);
						infinity_stage_index = (short)(cur_stage_index %90);
						regen = -2;
					}
				}
				else
					regen = -2;
			}
		}
//		else if ( monnum<=80 &&!countdown )
//		{
//		for (int i = 0; i<monnum; ++i)
//		{
//			last_mon = GameObject.Find("enemy");
//			last_mon.GetComponent<AI_Enemy01>().CountDown();
//			last_mon.name  = "enemy_confirm";
//		}
//			countdown = true;
//		}

//		for (int i = 0; i<monnum; ++i)
//		{
//			last_mon = GameObject.Find("enemy");
//			last_mon.GetComponent<AI_Enemy01>().CountDown();
//			last_mon.name  = "enemy_confirm";
//		}
	}
	

	//鎴樻枟缁熻?
	public void fightStatistics( bool result)
	{
        //Debug.Log("    fail");
        //FightScenePanelManager manager = (FightScenePanelManager)FindObjectOfType(typeof(FightScenePanelManager));
        //if(manager != null)
        //{
        //    manager.showFightResultUI(result);
        //    //Debug.Log("    fail");
        //}
	}

	public void GameOver()
	{
		Camera.main.GetComponent<CamMove>().ZoomIn(9,16,12f);
		Time.timeScale = 0.25f;
		Camera.main.GetComponent<MotionBlur>().blurAmount = 0.8f;
		Camera.main.GetComponent<MotionBlur>().enabled = true;
		InvokeRepeating ("OnGameOver", 0.6f, 0.1f);
	}

	public void OnGameOver(  )
	{
		script_cha.m_curStat = 0;
		CancelInvoke("OnGameOver");
		Camera.main.GetComponent<MotionBlur> ().enabled = false;
		Time.timeScale = 1;
		fightStatistics (true);
	}
}
