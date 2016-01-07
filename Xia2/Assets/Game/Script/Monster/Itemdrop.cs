using UnityEngine;
using System.Collections;
using FightMessage;
public class Itemdrop : MonoBehaviour {
	
	MyPlayer script_cha;
	
	//Transform maincamera;
	int itemindex = 0;
	int itemlevel = 0;
	
	Transform mytransform;
	Renderer myrenderer;
	
	Transform cha1;
	float maxy = 1.4f;
	float maxx = 1.4f;
	float distime = 0;
	bool drop = false;
	DropItem m_item ;
	Vector3 m_dir;
	bool m_flying = false;
	Vector3 tragetPos = new Vector3(300,300);
	void Awake()
	{
		mytransform = transform;
		myrenderer = GetComponent<Renderer>();
		//maincamera = Camera.main.transform;
		GetComponent<Renderer>().sharedMaterial.renderQueue = 4003;
		cha1 = GameObject.FindWithTag("Player").transform;
		script_cha = cha1.GetComponent<MyPlayer>();
	
		m_dir = new Vector3();
	}
	
	void Start()
	{
		gameObject.active = false;
	}
	
	void OnTriggerEnter(Collider other)
	{
		//if (other.transform.IsChildOf(cha1))
		//if (other.gameObject.layer == 12)
		if (other.gameObject.layer == 15)
		{
			script_cha.GetItem(itemindex,itemlevel,m_item);
			Disappear();
			//m_flying = true;
		}
	}
	
	public void Disappear()
	{
		mytransform.position = Vector3.one *5;
		GetComponent<Collider>().enabled = false;
		gameObject.active = false;
		maxy = 1.4f;
		maxx = 1.4f;
		distime = 0;
		drop = false;
		m_flying = false;
	}

	public void Whatsindex(int _index,int _level,DropItem item)
	{
		itemindex= _index;
		itemlevel = _level;
		m_item = item;
		
		float x = Random.Range(-30,30);
		float z = Random.Range(-30,30);
		m_dir.y = 0;
		m_dir.x = x;
		m_dir.z = z;
		m_dir.Normalize();
		
		m_flying = false;
	}

	public void flying()
	{
		Vector3 v2d =  Camera.main.WorldToScreenPoint (mytransform.position);
		//tragetPos
		mytransform.position = Camera.main.ScreenToWorldPoint ( v2d );
		//ovp.BezierSpline.GetCurveControlPoints ();
	}
	
	void Update () 
	{
		distime += Time.deltaTime;
		if (distime>14)
			Disappear();
		if (m_flying) {
			flying();
			return;		
		}
		else if (distime>10)
		{
			if ((distime*10)%4>2)
				myrenderer.enabled = true;
			else
				myrenderer.enabled = false;
		}
		//mytransform.LookAt (maincamera);
		if (!drop)
		{
			if (mytransform.position.y >= 0.05f)
			{
				maxy -= 4.5f * Time.deltaTime;
				maxx += 0.15f * Time.deltaTime;

				mytransform.position += Vector3.up*maxy * Time.deltaTime;
				//mytransform.position += Vector3.left* maxx * Time.deltaTime* 0.2f;

				mytransform.position += m_dir* maxx * Time.deltaTime * 0.2f;
			}
			else
			{
				drop = true;
				script_cha.FindItem(mytransform);
				GetComponent<Collider>().enabled = true;
				mytransform.position = Vector3.right*mytransform.position.x+Vector3.forward*mytransform.position.z;
			}
		}
	}
}
