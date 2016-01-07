using UnityEngine;
using System.Collections;

public class Ef_swordwind : Ef_base {
	
	public float m_speed = 0.2f;

	void Awake()
	{
		base.Awake ();
		m_transform = transform;
		m_collider = GetComponent<Collider>();
	}
	
	void Start () 
	{
		m_localScale = m_transform.localScale;
		if( m_collider )
			m_collider.enabled = false;
	}
	
	void OnEnable()
	{
	}
	
	void Update () 
	{
		m_delay += Time.deltaTime;

		if( m_startTrigger !=- 1 && m_delay >= m_startTrigger )
		{
			if( m_collider )
				m_collider.enabled = true;
		}

		if (m_delay >= m_endTrigger) {
			if( m_collider )
				m_collider.enabled = false;
		}


		if( m_delay > m_endDelay  )
		{
			Destroy(gameObject);
		}else
		{
			m_transform.position += m_transform.forward * Time.deltaTime * m_speed;	
		}
	}
}
