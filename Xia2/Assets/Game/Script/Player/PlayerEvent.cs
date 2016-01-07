using UnityEngine;
using System.Collections;

public partial class Player {

	void OnTriggerEnter(Collider other)
	{
		if(m_isDead)
		{
			return;
		}

		string aniName = ProcessHit ( other.transform );

	}
	
	public override void OnHp( int hp )
	{
		if (hp < 0) {
			bool b = GetCurCharData().bufferController.AbsorbDamage((float)hp);
			if(!b){
				return;
			}
		}
		base.OnHp (hp);
		GetCurCharData ().bufferController.AddAttackByHp ();

        m_ui.SetRivalHP();
	}

	public override void OnMp( int mp )
	{
		base.OnMp (mp);
		
		m_ui.SetRivalMP();
	}

	public override void OnEnergy( int energy )
	{
		base.OnEnergy (energy);

        m_ui.SetRivalEnergy();
	}

	public override void OnHardStraight( int damage )
	{
		base.OnHardStraight (damage);

        m_ui.SetRivalHardStraight();
	}

	public string OnWaitFight( float angle,Vector3 pos )
	{
		m_transform.rotation = Quaternion.AngleAxis (angle, new Vector3 (0, 1, 0));
		m_animation.Play ("change_in");
		return "change_in";
	}

	public bool OnSkill( int skillId )
	{
		if (!OnCheckFireSkill ())
			return false;

		m_bSkilling = true;
		m_animation.Stop ();
		m_curStat = 110;
		m_rigidbody.drag = 100;
		m_rigidbody.AddForce (Vector3.zero);
		m_audio.PlayOneShot(m_skillYell[0]);
		CancelAtk();

		//m_skillStateMgr.Start (skillId);
		return true;
	}

	public bool OnCheckFireSkill()
	{
		if (m_bSkilling)
			return false;

		if (m_changing)
			return false;

		if (getCurProperty((int)GlobalDef.NewHeroProperty.PRO_LIFEPOINT) <= 0)
			return false;

		if (getCurProperty((int)GlobalDef.NewHeroProperty.PRO_MANAPOINT) <= 0)
			return false;

		//< 沉默
		if (hasState ((int)GlobalDef.UnitState.State_Silent))
			return false;

		return true;
	}

	public float OnAttack( Transform targetTrans )
	{
//		if (m_curStat > 10 || m_curStat < 0)
//			return 0f;

		if (m_isDead)
			return 0f;

		float waitTime = 0f;
		m_curTarget = targetTrans;
		m_atkCollider.enabled =false;
		float mp = getProperty ((int)GlobalDef.NewHeroProperty.PRO_MP_GETSEL);
		OnMp ((int)mp);
		float atkSpeed = GetCurCharData ().getAttackSpeed ();
		m_attackRising = false;
		Vector3 attackVector = m_curTarget.position - m_transform.position;
		attackVector[1] = 0;
		float magnitude_attackdir = attackVector.magnitude;
		attackVector = attackVector/magnitude_attackdir;
		
		float attackDot = Vector3.Dot (attackVector, m_directionVector);
		if (magnitude_attackdir >0.2f)
		{
			if(attackDot <0.5f)
			{
				m_curStat = 17;
				m_atkCollider.enabled =true;
				return 0f;
			}
		}
		else
		{
			if(attackDot < -0.2f)
			{
				m_curStat = 17;
				m_atkCollider.enabled =true;
				return 0f;
			}
		}
		
		m_curAttackStat = (m_curAttackStat + 1 - m_weaponTypeFactor)% 5 + m_weaponTypeFactor;
		
		int rndyell = Random.Range (0,4);
		if (rndyell<2)
		{
			m_audio.clip = m_yell[rndyell];
			m_audio.Play();
		}
		
		//RndAtk(true);
		m_speedFactor = 5.2f;
		
		m_transform.rotation = Quaternion.LookRotation(attackVector); 
		OnFog(0);

		//< 每第3次攻击造成大量伤害 累积计算攻击次数
		GetCurCharData ().bufferController.AddThreeAtkBuffCount ();

		int  force = 0;
		bool bHaveForce = false; 
		string attackAniName1 = "";
		string attackAniName2 = "";

		switch(m_curAttackStat)
		{
		case 0:
			m_curStat = 11;
			m_animation.Play("attack1");

			m_tmpAttack = m_animation.PlayQueued("1t",QueueMode.CompleteOthers);
			m_tmpAttack.speed =  0.24f;
			m_tmpAttack.layer = 1;

			m_efSwing1.localRotation = Quaternion.Euler (0,0,180);
			m_efSwing1.position = m_transform.position+ Vector3.up * 0.055f;
			m_swingScript.m_attackRising = false;
			m_swingScript.SwingOn(0.15f - atkSpeed,2,2,20,1,0);

			attackAniName1 = "attack1";
			attackAniName2 = "1t";
			break;
		case 1:
			m_attackRising = true;
			m_curStat = 11;
			m_animation.Play("attack2");
			m_tmpAttack = m_animation.PlayQueued("2t",QueueMode.CompleteOthers);
			m_tmpAttack.speed =  0.24f;
			m_tmpAttack.layer = 1;
			m_efSwing1.localRotation = Quaternion.Euler (0,0,40);
			m_efSwing1.position = m_transform.position+ Vector3.up * 0.12f;
			m_swingScript.m_attackRising = true;
			m_swingScript.SwingOn(0.15f - atkSpeed,2,2,20,1,0);

			attackAniName1 = "attack2";
			attackAniName2 = "2t";
			break;
		case 2:
			m_curStat = 11;
			m_animation.Play("attack3");
			m_tmpAttack = m_animation.PlayQueued("3t",QueueMode.CompleteOthers);
			m_tmpAttack.speed =  0.24f;
			m_tmpAttack.layer = 1;
			m_efSwing1.localRotation = Quaternion.Euler (0,0,330);
			m_efSwing1.position = m_transform.position+ Vector3.up*0.1f;
			m_swingScript.m_attackRising = false;
			m_swingScript.SwingOn(0.2f - atkSpeed,2,2,20,1,0);

			attackAniName1 = "attack3";
			attackAniName2 = "3t";
			break;
		case 3:
			m_curStat = 11;
			m_animation.Play("attack4");
			m_tmpAttack = m_animation.PlayQueued("4t",QueueMode.CompleteOthers);
			m_tmpAttack.speed =  0.24f;
			m_tmpAttack.layer = 1;
			if( bHaveForce )
				force = 100;
			m_thrustScript.m_attackRising = false;
			m_thrustScript.SwingOn(0.28f - atkSpeed,4,1,20,1,force);

			attackAniName1 = "attack4";
			attackAniName2 = "4t";
			break;

		case 4:
			m_attackRising = true;
			m_curStat = 11;
			m_animation.Play("attack5");
			m_efSwing1.localRotation = Quaternion.identity;
			m_efSwing1.position = m_transform.position+ Vector3.up * 0.055f;
			if( bHaveForce )
				force = 150;
			m_swingScript.m_attackRising = true;
			m_swingScript.SwingOn(0.21f - atkSpeed,2,2,20,1,force);

			attackAniName1 = "attack5";
			attackAniName2 = "";
			break;

		case 10:
			m_curStat = 11;
			m_animation.Play("attack1");
			m_tmpAttack = m_animation.PlayQueued("1t",QueueMode.CompleteOthers);
			m_tmpAttack.speed =  0.24f;
			m_tmpAttack.layer = 1;
			m_efSwing1.localRotation = Quaternion.Euler (0,0,180);
			m_efSwing1.position = m_transform.position+ Vector3.up * 0.06f;
			m_swingScript.SwingOn(0.15f - atkSpeed,2,2,20,1,0);
			
			m_efSwing2.localRotation = Quaternion.Euler (-0,0,-40);
			m_efSwing2.position = m_transform.position+ Vector3.up * 0.08f;
			if( bHaveForce )
				force = 100;
			m_swingScript2.SwingOn(0.4f - atkSpeed,2,2,20,1,force);
			if( bHaveForce )
				m_rigidbody.AddForce (attackVector * 120);

			attackAniName1 = "attack1";
			attackAniName2 = "1t";
			break;

		case 11:
			m_curStat = 11;
			m_animation.Play("attack2");
			m_tmpAttack = m_animation.PlayQueued("2t",QueueMode.CompleteOthers);
			m_tmpAttack.speed =  0.24f;
			m_tmpAttack.layer = 1;
			m_efSwing1.localRotation = Quaternion.Euler (0,0,340);
			m_efSwing1.position = m_transform.position+ Vector3.up*0.06f;
			m_swingScript.SwingOn(0.2f - atkSpeed,2,2,20,1,0);
			
			m_efSwing2.localRotation = Quaternion.Euler (0,0,10);
			m_efSwing2.position = m_transform.position+ Vector3.up*0.06f;
			if( bHaveForce )
				force = 100;
			m_swingScript2.SwingOn(0.4f - atkSpeed,2,2,20,1,force);
			if( bHaveForce )
				m_rigidbody.AddForce (attackVector * 120);

			attackAniName1 = "attack2";
			attackAniName2 = "2t";
			break;

		case 12:
			m_attackRising = true;
			m_curStat = 11;
			m_animation.Play("attack3");
			m_tmpAttack = m_animation.PlayQueued("3t",QueueMode.CompleteOthers);
			m_tmpAttack.speed =  0.24f;
			m_tmpAttack.layer = 1;
			m_efSwing1.localRotation = Quaternion.Euler (0,0,90);
			m_efSwing1.position = m_transform.position+ Vector3.up * 0.14f;
			if( bHaveForce )
				force = 140;
			m_swingScript.SwingOn(0.15f - atkSpeed,2,2,20,1,force);
			
			m_efSwing2.localRotation = Quaternion.Euler (0,0,90);
			m_efSwing2.position = m_transform.position+ Vector3.up * 0.16f;
			if( bHaveForce )
				force = 80;
			else 
				force = 0;
			m_swingScript2.SwingOn(0.31f - atkSpeed,2,2,20,1,force);
			//script_cam.LookTarget(bip01,30,1.5f);
			//m_rigidbody.AddForce (attackVector * 80);
			attackAniName1 = "attack3";
			attackAniName2 = "3t";
			break;

		case 13:
			m_curStat = 11;
			m_animation.Play("attack4");
			m_tmpAttack = m_animation.PlayQueued("4t",QueueMode.CompleteOthers);
			m_tmpAttack.speed =  0.24f;
			m_tmpAttack.layer = 1;
			m_efSwing1.localRotation = Quaternion.Euler (-20,0,-90);
			m_efSwing1.position = m_transform.position+ Vector3.up * 0.06f;
			m_swingScript.SwingOn(0.11f - atkSpeed,2,2,20,1,0);
			if( bHaveForce )
				m_rigidbody.AddForce (attackVector * 150);

			attackAniName1 = "attack4";
			attackAniName2 = "4t";
			break;

		case 14:
			m_attackRising = true;
			m_curStat = 11;
			m_animation.Play("attack5");
			m_efSwing1.localRotation = Quaternion.Euler (0,0,170);
			m_efSwing1.position = m_transform.position- m_transform.right * 0.07f  + Vector3.up *0.06f;
			m_efSwing2.localRotation = Quaternion.Euler (0,0,10);
			m_efSwing2.position = m_transform.position+ m_transform.right * 0.07f + Vector3.up *0.055f;
			if( bHaveForce )
			{
				m_swingScript.SwingOn(0.3f - atkSpeed,2,2,20,1,180);
				m_swingScript2.SwingOn(0.3f - atkSpeed,2,2,20,1,0);
				m_rigidbody.AddForce (attackVector * 150);
			}else
			{
				m_swingScript.SwingOn(0.5f - atkSpeed,2,2,20,1,0);
				m_swingScript2.SwingOn(0.5f - atkSpeed,2,2,20,1,0);
			}
			attackAniName1 = "attack5";
			attackAniName2 = "";
			break;

		case 30:
			m_attackRising = true;
			m_curStat = 11;
			m_animation.Play("attack1");
			m_tmpAttack = m_animation.PlayQueued("1t",QueueMode.CompleteOthers);
			m_tmpAttack.speed =  0.24f;
			m_tmpAttack.layer = 1;
			m_efSwing1.localRotation = Quaternion.identity;
			m_efSwing1.position = m_transform.position+ Vector3.up * 0.06f;
			m_swingScript.SwingOn(0.15f - atkSpeed,2,2,20,1,0);
			if( bHaveForce )
				m_rigidbody.AddForce (attackVector * 160);
			attackAniName1 = "attack1";
			attackAniName2 = "1t";
			break;

		case 31:
			m_attackRising = true;
			m_curStat = 11;
			m_animation.Play("attack2");
			m_tmpAttack = m_animation.PlayQueued("2t",QueueMode.CompleteOthers);
			m_tmpAttack.speed =  0.24f;
			m_tmpAttack.layer = 1;
			m_efSwing1.localRotation = Quaternion.Euler (0,0,-90);
			m_efSwing1.position = m_transform.position+ Vector3.up*0.1f;
			m_swingScript.SwingOn(0.42f - atkSpeed,2,2,20,1,0);
			m_splashScript.SplashOn(true, 0.1f,0.5f - atkSpeed);
			if( bHaveForce )
				m_rigidbody.AddForce (attackVector * 130);
			attackAniName1 = "attack2";
			attackAniName2 = "2t";
			break;

		case 32:
			m_curStat = 12;
			m_animation.Play("attack3");
			m_tmpAttack = m_animation.PlayQueued("3t",QueueMode.CompleteOthers);
			m_tmpAttack.speed =  0.24f;
			m_tmpAttack.layer = 1;
			m_efSwing1.localRotation = Quaternion.Euler (0,0,180);
			m_efSwing1.position = m_transform.position+ Vector3.up * 0.1f;
			if( bHaveForce )
			{
				m_swingScript.SwingOn(0.5f - atkSpeed,2,2,20,1,90);
				m_rigidbody.AddForce (attackVector * 90);
			}else
			{
				m_swingScript.SwingOn(0.5f - atkSpeed,2,2,20,1,0);
			}
			attackAniName1 = "attack3";
			attackAniName2 = "3t";
			break;

		case 33:
			m_attackRising = true;
			m_curStat = 11;
			m_animation.Play("attack4");
			m_tmpAttack = m_animation.PlayQueued("4t",QueueMode.CompleteOthers);
			m_tmpAttack.speed =  0.24f;
			m_tmpAttack.layer = 1;
			m_efSwingEx1.localRotation = Quaternion.Euler (0,0,160);
			m_efSwingEx1.localScale =  Vector3.one * 2.4f;
			m_efSwingEx1.position = m_transform.position+ Vector3.up * 0.1f;
			if( bHaveForce )
				force = 120;
			m_swingEx1Script.SwingOn(0.36f - atkSpeed,2,2,20,1,force);
			//myrigidbody.AddForce (attackVector * 90);
			attackAniName1 = "attack4";
			attackAniName2 = "4t";
			break;

		case 34:
			m_attackRising = true;
			m_curStat = 11;
			m_animation.Play("attack5");
			m_efSwing1.localRotation = Quaternion.Euler (0,0,-20);
			m_efSwing1.position = m_transform.position+ Vector3.up * 0.1f;
			if( bHaveForce )
				force = 200;
			m_swingScript.SwingOn(0.4f - atkSpeed,2,2,20,1,force);
			//myrigidbody.AddForce (attackVector * 125);
			attackAniName1 = "attack5";
			attackAniName2 = "";
			break;

		case 40:
			m_curStat = 11;
			m_animation.Play("attack1");
			m_tmpAttack = m_animation.PlayQueued("1t",QueueMode.CompleteOthers);
			m_tmpAttack.speed =  0.24f;
			m_tmpAttack.layer = 1;
			if( bHaveForce )
				force = 30;
			m_thrustScript.SwingOn(0.1f - atkSpeed,4,1,20,1,force);
			m_punchScript.PunchShoot(0.3f - atkSpeed,0 , m_curTarget ,0,0,0.06f,false);

			attackAniName1 = "attack1";
			attackAniName2 = "1t";
			break;

		case 41:
			m_attackRising = true;
			m_curStat = 11;
			m_animation.Play("attack2");
			m_tmpAttack = m_animation.PlayQueued("2t",QueueMode.CompleteOthers);
			m_tmpAttack.speed =  0.24f;
			m_tmpAttack.layer = 1;
			m_punchScript.PunchShoot(0.3f - atkSpeed,40, m_curTarget ,0,0.8f,0.1f,false);

			attackAniName1 = "attack2";
			attackAniName2 = "2t";
			break;

		case 42:
			m_curStat = 11;
			m_animation.Play("attack3");
			m_tmpAttack = m_animation.PlayQueued("3t",QueueMode.CompleteOthers);
			m_tmpAttack.speed =  0.24f;
			m_tmpAttack.layer = 1;
			if( bHaveForce )
				force = 30;
			m_thrustScript.SwingOn(0.24f - atkSpeed,4,1,20,1,force);
			m_punchScript.PunchShoot(0.1f - atkSpeed,0, m_curTarget, 0,0,0.06f,false);

			attackAniName1 = "attack3";
			attackAniName2 = "3t";
			break;

		case 43:
			m_attackRising = true;
			m_curStat = 12;
			m_animation.Play("attack4");
			m_tmpAttack = m_animation.PlayQueued("4t",QueueMode.CompleteOthers);
			m_tmpAttack.speed =  0.24f;
			m_tmpAttack.layer = 1;
			//script_thrust.SwingOn(0.2f - atkspd,4,1,20,1,0);
			m_punchScript.PunchShoot(0.4f - atkSpeed,0, m_curTarget,0,0,0.15f,true);
			//script_thrust.SwingOn(1.2f - atkspd,4,1,20,1,150);
			//script_splash.SplashOn(true, 0.1f,0.5f);
			//		Invincibility (1.5f -atkSpeed);
			//myrigidbody.AddForce (attackVector * 140);
			attackAniName1 = "attack4";
			attackAniName2 = "4t";
			break;

		case 44:
			m_curStat = 11;
			m_animation.Play("attack5");
			if( bHaveForce )
				force = 70;
			m_thrustScript.SwingOn(0.2f - atkSpeed,4,1,20,1,force);
			
			m_splashScript.SplashOn(true, 0.05f,0.6f -atkSpeed);
			if( bHaveForce )
				m_rigidbody.AddForce (attackVector * 120);

			attackAniName1 = "attack5";
			attackAniName2 = "";
            break;

		case 50:
			m_attackRising = true;
			m_curStat = 11;
			m_animation.Play("attack1");
			m_tmpAttack = m_animation.PlayQueued("1t",QueueMode.CompleteOthers);
			m_tmpAttack.speed =  0.24f;
			m_tmpAttack.layer = 1;
			
			//			Invoke("Arrow_shoot",0.3f -atkspd);
			if( bHaveForce )
				m_rigidbody.AddForce (attackVector * -30);

			attackAniName1 = "attack1";
			attackAniName2 = "1t";
			break;

		case 51:
			m_curStat = 11;
			m_animation.Play("attack2");
			m_tmpAttack = m_animation.PlayQueued("2t",QueueMode.CompleteOthers);
			m_tmpAttack.speed =  0.24f;
			m_tmpAttack.layer = 1;
			//			Invoke("Arrow_shoot",0.3f -atkspd);
			if( bHaveForce )
				m_rigidbody.AddForce (attackVector * -30);

			attackAniName1 = "attack2";
			attackAniName2 = "2t";
			break;

		case 52:
			m_attackRising = true;
			m_curStat = 12;
			m_animation.Play("attack3");
			m_tmpAttack = m_animation.PlayQueued("3t",QueueMode.CompleteOthers);
			m_tmpAttack.speed =  0.24f;
			m_tmpAttack.layer = 1;
			//			Invoke("Arrow_shoot",0.3f -atkspd);
			if( bHaveForce )
				m_rigidbody.AddForce (attackVector * -30);

			attackAniName1 = "attack3";
			attackAniName2 = "3t";
			break;

		case 53:
			m_attackRising = true;
			m_curStat = 11;
			m_animation.Play("attack4");
			m_tmpAttack = m_animation.PlayQueued("4t",QueueMode.CompleteOthers);
			m_tmpAttack.speed =  0.24f;
			m_tmpAttack.layer = 1;
			
			//			Invoke("Arrow_shoot",0.8f -atkspd);
			if( bHaveForce )
				m_rigidbody.AddForce (attackVector * -30);

			attackAniName1 = "attack4";
			attackAniName2 = "4t";
			break;

		case 54:
			m_attackRising = true;
			m_curStat = 11;
			m_animation.Play("attack5");
			
			//			Invoke("Arrow_shoot",0.8f -atkspd);
			if( bHaveForce )
				m_rigidbody.AddForce (attackVector * -30);

			attackAniName1 = "attack5";
			attackAniName2 = "";
			break;

		case 60:
			m_curStat = 11;
			m_animation.Play("attack1");
			m_tmpAttack = m_animation.PlayQueued("1t",QueueMode.CompleteOthers);
			m_tmpAttack.speed =  0.24f;
			m_tmpAttack.layer = 1;
			Invoke("OnMagicShoot2",0.2f -atkSpeed);
			if( bHaveForce  )
				m_rigidbody.AddForce (attackVector * 10);
			break;

		case 61:
			m_curStat = 11;
			m_animation.Play("attack2");
			m_tmpAttack = m_animation.PlayQueued("2t",QueueMode.CompleteOthers);
			m_tmpAttack.speed =  0.24f;
			m_tmpAttack.layer = 1;
			Invoke("OnMagicShoot1",0.4f -atkSpeed);
			if( bHaveForce  )
				m_rigidbody.AddForce (attackVector * 10);
			break;

		case 62:
			m_curStat = 11;
			m_animation.Play("attack3");
			m_tmpAttack = m_animation.PlayQueued("3t",QueueMode.CompleteOthers);
			m_tmpAttack.speed =  0.24f;
			m_tmpAttack.layer = 1;
			Invoke("OnMagicShoot1",0.5f -atkSpeed);
			if( bHaveForce  )
				m_rigidbody.AddForce (attackVector * 10);
			break;

		case 63:
			m_curStat = 12;
			m_animation.Play("attack4");
			m_tmpAttack = m_animation.PlayQueued("4t",QueueMode.CompleteOthers);
			m_tmpAttack.speed =  0.4f;
			m_tmpAttack.layer = 1;
			Invoke("OnMagicShoot3",0.6f -atkSpeed);
			if( bHaveForce  )
				m_rigidbody.AddForce (attackVector * -60);
			break;

		case 64:
			m_curStat = 11;
			m_animation.Play("attack5");
			Invoke("OnMagicShoot1",0.3f -atkSpeed);
			if( bHaveForce  )
				m_rigidbody.AddForce (attackVector * 80);
			
			break;
		}
		m_directionVector = attackVector;

		if(!string.IsNullOrEmpty(attackAniName1))
		{
			waitTime += m_animation[attackAniName1].length / m_animation[attackAniName1].speed;
		}
		if(!string.IsNullOrEmpty(attackAniName2))
		{
			waitTime += m_animation[attackAniName2].length / m_animation[attackAniName2].speed;
		}

		if(waitTime <= 0)
		{
			int a = 0;
		}
		return waitTime;
	}

	public void OnMagicShoot1()
	{
		m_efAtkMagic1.position= m_transform.position; // + Vector3.up *0.05f;
		m_efAtkMagic1.rotation = m_transform.rotation;
		m_efAtkMagic1.gameObject.active = true;
	}
	public void OnMagicShoot2()
	{
		m_attackRising = true;
		m_efAtkMagic2.position= m_transform.position;// + Vector3.up *0.05f;
		m_efAtkMagic2.rotation = m_transform.rotation;
		m_efAtkMagic2.gameObject.active = true;
	}
	public void OnMagicShoot3()
	{
		Transform fx = PrefabManager.Instance ().GetFx ( "attack_magic_3",PrefabManager.enEfPathType.EF_ATK );
		m_efAtkMagic3  = (Transform) Instantiate (fx, m_transform.position, m_transform.rotation);
		m_efAtkMagic3.position = m_transform.position + m_transform.forward * 0.4f;
		m_atkmagicScript3= m_efAtkMagic3.GetComponent<Ef_atkMagic> ();
		m_atkmagicScript3.m_attker = m_transform;
	}
	
	public override bool OnChangeChar(HeroData data,bool isDead)
	{
		bool b = base.OnChangeChar (data,isDead);
		if (!b) return false;
		StartCoroutine (OnChangeIn (300));

        m_ui.SwitchRivalChar(data);
		return true;
	}

	public override void OnDamaged( int damage,bool isSkillDamage,int type )
	{
		if (m_invincible || m_changing)
			return;

		OnHp (-damage);
		float mp = getProperty ((int)GlobalDef.NewHeroProperty.PRO_MP_GETHIT);
		OnMp ((int)mp);
		if( !isSkillDamage )
			OnHardStraight (-damage);
		m_rigidbody.mass = 2;

		Vector3 pos = transform.position;
		pos.y += .16f;
		//生成被击数字
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
			if( type == 1 )
				critHUD.Add(damage.ToString(), pos);
			else if( type == 3 )
				normalHUD.Add(damage.ToString()); 
		}

		if( getCurProperty((int)GlobalDef.NewHeroProperty.PRO_LIFEPOINT) <= 0 )
		{
			GetCurCharData().bufferController.RemoveAllBuffer();
			//< 处理死亡后召唤其他英雄
			bool notHaveHero = false;
			HeroData data = null;
			for( int i = 0; i < GlobalDef.MAX_HERO; i++ )
			{
				data = GetFightHeroData(i);
				if( data == null || data.getCurPro((int)GlobalDef.NewHeroProperty.PRO_LIFEPOINT) <= 0 )
					continue;
				notHaveHero = true;
				break;
			}
			
			if( !notHaveHero )
			{
				m_isDead = true;
				m_animation.Play("dead");
				LevelFlowCtrl.instance.Success();
			}else
			{
				data.refreshProperty();
				OnChangeChar(data,true);
			}
		}else
		{

		}
	}
}
