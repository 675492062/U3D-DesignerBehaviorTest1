using UnityEngine;
using System.Collections;

public class Ef_trackSword : Ef_base {

	TrailRenderer mytrail;
	bool fireon = false;
	Transform target;
	float dt = 0;
	Vector3 targetpos;
	Vector3 directionVector;
	bool test = false;

	void Awake()
	{
		base.Awake ();
		m_transform = transform;
		m_collider = GetComponent<Collider>();
		mytrail = GetComponent<TrailRenderer>();
	}

	void OnEnable()
	{
		m_transform.localScale = Vector3.right + Vector3.up;
		m_collider.enabled = false;
		dt =0;
	}
	
	public void Fire( Transform enemy )
	{
		m_transform.parent = null;
		m_collider.enabled = true;
		fireon = true;
		target = enemy;
		mytrail.enabled = true;
	}
	
	void Update () 
	{
		if (fireon) {
			if(m_transform.position.y>0)
			{
				if (dt<10)
					dt +=  Time.deltaTime*5;
				if (target)
					targetpos = target.position;
				directionVector = targetpos - m_transform.position;
				if (directionVector != Vector3.zero)
					m_transform.rotation = Quaternion.Lerp(m_transform.rotation,Quaternion.LookRotation(directionVector), 4* dt *Time.deltaTime);
				m_transform.position += m_transform.forward * Time.deltaTime*1.8f ;
			}
			else
			{
				mytrail.enabled = false;
				Destroy(gameObject);
			}
		}
		else if (m_transform.localScale.z<1)
		{
			m_transform.localScale += Vector3.forward * Time.deltaTime *6;
		}
		else
			m_transform.localScale = Vector3.one;

	}
}
