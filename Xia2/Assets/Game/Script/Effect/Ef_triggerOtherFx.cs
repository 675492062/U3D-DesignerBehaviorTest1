using UnityEngine;
using System.Collections;

public class Ef_triggerOtherFx : Ef_base {
	
	public bool  m_followMe = false;
	public Transform m_oterFx;
	
	void Awake()
	{
		base.Awake ();
		m_transform = transform;
	}
	
	void Start () 
	{
		m_localScale = m_transform.localScale;
	}

	public void FireBoom()
	{
		Transform fx = (Transform)Instantiate (m_oterFx, m_transform.position, m_transform.rotation);		
		fx.GetComponent<Ef_base> ().m_skillId = m_transform.GetComponent<Ef_base> ().m_skillId;
		fx.GetComponent<Ef_base> ().m_param[0] = m_transform.GetComponent<Ef_base> ().m_param[0];
		fx.GetComponent<Ef_base> ().m_user = m_user;

		Destroy (gameObject);
	}
	
	void Update () 
	{
		m_delay += Time.deltaTime;
		if (m_followMe) {
			Ef_base.GetPosByType(m_transform,this.m_user,m_posType,m_rotationWithTarget);
		}
		m_transform.localScale = m_localScale;

		if (m_endDelay != -1 && m_delay >= m_endDelay) {
			FireBoom();
		}

	}
}
