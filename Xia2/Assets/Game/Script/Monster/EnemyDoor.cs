using UnityEngine;
using System.Collections;

public class EnemyDoor : Enemy {

	void Awake()
	{
		m_transform = transform;
		m_animation = GetComponent<Animation>();
		m_audio = GetComponent<AudioSource>();
		m_rigidbody = GetComponent<Rigidbody>();

		m_unitType = GlobalDef.UnitType.UNIT_TYPE_DOOR;
	}

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void setTemplateID(int templateID)
	{
		m_TemplateID = templateID;
		property.parseData (m_TemplateID);
		// 设置属性
		setProperty ();
	}

	/// <summary>
	/// 被击部分
	/// </summary>
	void OnTriggerEnter(Collider other)
	{
		int attack_obj_layer = other.gameObject.layer;
		switch (attack_obj_layer) {
		case 20: // normal atk
		case 21: // power atk
		case 28: // push atk
		{
		}
			break;
		case 22: // skill atk
		{
			Transform atker = other.GetComponent<Ef_base>().m_user;
			int unitType = (int)atker.GetComponent<Unit>().m_unitType;
			if( unitType == (int)m_unitType )
			{
				// 目前这里只判断是不是敌人是敌人就退出
				return ;
			}
		}break;
		default:
			return;
		}
		//处理被击
		string  aniName = ProcessHit (other.transform);
		//
		Dead ();		
	}

	public override void SetHitStat( string name )
	{
		if (m_animation != null) {
			m_animation.Stop ();
			m_animation.Play ("hit");
		}
	}

	public void Dead()
	{
		if (!m_isDead)
			return;

		if (m_animation != null) {
			m_animation.Stop ();
			m_animation.Play ("die");
			GetComponent<BoxCollider>().enabled = false;
		}
//		Destroy (gameObject);
		OnDeadEvent();
	}
}
