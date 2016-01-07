using UnityEngine;
using System.Collections;

//< 貂蝉技能2 回旋扇
public class Ef_diaochan4: Ef_base {

	public Transform	fx;
	Transform	m_fly1;
	Transform	m_fly2;

	void OnDestroy()
	{
		if( m_fly1 && m_fly1.gameObject )
			Destroy (m_fly1.gameObject);
		if( m_fly2 && m_fly2.gameObject )
			Destroy (m_fly2.gameObject);
	}

	public void Awake()
	{
		base.Awake ();
	}

	void Start () {

		m_transform = transform;
		m_collider = GetComponent<Collider>();


		m_scriptUser = m_user.GetComponent<Unit>();
		fx.GetComponent<Ef_diaochan41> ().m_angle = 0;
		m_fly1 = (Transform)Instantiate (fx, m_transform.position, m_transform.rotation);
		m_fly1.GetComponent<Ef_diaochan41> ().m_user = m_user;
		m_fly1.GetComponent<Ef_diaochan41> ().m_skillId = m_skillId;
		m_fly1.GetComponent<Ef_diaochan41> ().m_param[0] = m_param[0];
		fx.GetComponent<Ef_diaochan41> ().m_angle = 1;
		m_fly2 = (Transform)Instantiate (fx,m_transform.position, m_transform.rotation);
		m_fly2.GetComponent<Ef_diaochan41> ().m_user = m_user;
		m_fly2.GetComponent<Ef_diaochan41> ().m_skillId = m_skillId;
		m_fly2.GetComponent<Ef_diaochan41> ().m_param[0] = m_param[0];
	}

	void Update () {
		if (m_fly1 == null && m_fly2 == null) {
			Destroy(gameObject);		
		}
	}

}

