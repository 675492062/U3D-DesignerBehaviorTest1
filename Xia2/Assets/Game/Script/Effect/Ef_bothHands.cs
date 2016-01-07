using UnityEngine;
using System.Collections;

public class Ef_bothHands : Ef_base {

	public Transform	fx;

	Transform	m_leftFx;
	Transform	m_rightFx;

	void Awake()
	{
		base.Awake ();
		m_transform = transform;
	}

	void OnDestroy()
	{
		if( m_leftFx && m_leftFx.gameObject )
			Destroy (m_leftFx.gameObject);
		if( m_rightFx && m_rightFx.gameObject )
		Destroy (m_rightFx.gameObject);
	}

	
	void Start () 
	{
		m_scriptUser = m_user.GetComponent<Unit>();
		m_leftFx = (Transform)Instantiate (fx, Vector3.zero, fx.rotation);
		m_leftFx.parent = m_scriptUser.GetLeftHand ();
		m_leftFx.localPosition = Vector3.zero;
		m_rightFx = (Transform)Instantiate (fx,Vector3.zero, fx.rotation);
		m_rightFx.parent = m_scriptUser.GetRightHand (); 
		m_rightFx.localPosition = Vector3.zero;
	}
	
	void Update () 
	{
		m_delay += Time.deltaTime;
		m_transform.localScale = m_localScale;

		if( m_endDelay!= -1 && m_delay >= m_endDelay )
			Destroy(gameObject);	
	}
}
