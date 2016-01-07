using UnityEngine;
using System.Collections;

public class Ef_trackSwordTrigger : Ef_base 
{
    [SerializeField]
	public Transform sword;
    [SerializeField]
	Collider mycollider;
    [SerializeField]
	Transform[] c_sword = new Transform[7];
    [SerializeField]
	int swordindex =0;
    [SerializeField]
	int creatindex = 0;
    [SerializeField]
	float power = 0;
    [SerializeField]
	float start_delay = 0;
    [SerializeField]
	Transform user;
	bool homing = true;
	bool creatfinish = false;
	Transform oldtarget;
	
	
	void Awake()
	{
		base.Awake ();
		m_transform = transform;
		mycollider = GetComponent<Collider>();
	}
	
	void Start ()
	{
		power = GetComponent<Rigidbody>().mass;
	}

	void OnEnable()
	{
		mycollider.enabled = false;
		start_delay = 0;
		creatindex = 0;
		swordindex = 0;
		creatfinish = false;
		homing = false;
	}

	public void Init()
	{
		mycollider.enabled = false;
		start_delay = 0;
		creatindex = 0;
		swordindex = 0;
		creatfinish = false;
		homing = false;
	}
	
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 8 || other.gameObject.layer == 15 )
		{
			if( other.gameObject.layer == 15 )
			{
				GlobalDef.UnitType otherType = other.gameObject.GetComponent<Unit>().m_unitType;
				GlobalDef.UnitType atkerType = m_user.GetComponent<Unit>().m_unitType;
				bool b = other.gameObject.GetComponent<Unit>().CheckIsEnemy(atkerType,otherType);
				if( !b )
					return;
			}

			if ( !homing)
			{
				if (oldtarget == other.transform)
					return;
				else
				{
					c_sword[swordindex].GetComponent<Ef_trackSword>().Fire(other.transform);
					oldtarget = other.transform;
					++swordindex;
					mycollider.enabled = false;
					start_delay = 0;
					homing = true;
					if (swordindex >=7)
					{
						gameObject.active = false;
						m_transform.position = Vector3.up *31;
					}
					//Destroy(gameObject);
				}
			}
		}
	}
	
	void Update()
	{
		if (!creatfinish)
		{
			if (start_delay >0.1f)
			{
				start_delay = 0;
				if (c_sword[creatindex] == null)
				{
					c_sword[creatindex] = (Transform)Instantiate (sword,m_transform.position , Quaternion.Euler(0,30*creatindex+m_transform.eulerAngles.y-270,0));
					c_sword[creatindex].GetComponent<Rigidbody>().mass = power;
					c_sword[creatindex].position += c_sword[creatindex].forward*0.1f;
					c_sword[creatindex].forward = Vector3.up + m_transform.forward *0.6f;
					c_sword[creatindex].GetComponent<Ef_base> ().m_user = m_user;
					c_sword[creatindex].GetComponent<Ef_base> ().m_skillId = m_skillId;
					c_sword[creatindex].GetComponent<Ef_base> ().m_param[0] = m_param[0];
				}
				else
				{
					c_sword[creatindex].position = m_transform.position;
					c_sword[creatindex].rotation = Quaternion.Euler(0,30*creatindex+m_transform.eulerAngles.y-270,0);
					c_sword[creatindex].gameObject.active = true;
					c_sword[creatindex].position += c_sword[creatindex].forward*0.1f;
					c_sword[creatindex].forward = Vector3.up + m_transform.forward *0.6f;
				}
				c_sword[creatindex].parent = m_transform;
				
				if (creatindex <6)
					++ creatindex;
				else
					creatfinish = true;
			}
			else
				start_delay += Time.deltaTime;
		}
		else
		{
			if (start_delay >0.4f)
			{
				homing = false;
				mycollider.enabled = true;
				start_delay = -1;
			}
			else if (start_delay > -1)
				start_delay += Time.deltaTime;
			else
			{
				start_delay -= Time.deltaTime;
				if (start_delay<-2)
				{
					mycollider.enabled = false;
					mycollider.enabled = true;
					oldtarget= null;
				}
			}
		}


		m_transform.position  =m_transform.GetComponent<Ef_base> ().m_user.position+Vector3.up *0.2f;
		m_transform.rotation = Quaternion.Lerp(m_transform.rotation,m_transform.GetComponent<Ef_base> ().m_user.rotation,Time.deltaTime*3);
	}
}
