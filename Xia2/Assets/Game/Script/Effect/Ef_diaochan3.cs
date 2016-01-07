using UnityEngine;
using System.Collections;

//< 貂蝉魅惑技能
public class Ef_diaochan3: Ef_base {

	public float		m_spaceTrigger = 0;
	BasePlayer 			m_player;
	public string 		m_modeName;
	public string 		m_aniName;
	float 				m_spaceCount = 0;
	Transform 			m_hero;
	public Transform	m_endFx;
	void OnDestroy()
	{
		if( m_hero != null )
			Destroy (m_hero.gameObject);
	}
	
	public void Awake()
	{
		base.Awake ();
		m_transform = transform;
		m_collider = GetComponent<Collider>();
		m_localScale = m_transform.localScale;

		if( m_collider )
			m_collider.enabled = false;
		if( m_spaceTrigger > 0 )
			m_spaceTrigger = 0.5f;
	}
	
	void Start () {
		m_player = m_user.GetComponent<BasePlayer> ();
		Transform hero = m_player.m_transform.Find (m_modeName);
		m_hero = (Transform)Instantiate (hero, transform.position, hero.rotation);
		m_hero.gameObject.SetActive (true);
		m_hero.GetComponent<Animation>().Play (m_aniName);
	}
	
	void Update () {
		m_delay += Time.deltaTime;

		m_transform.localScale = m_localScale;
		
		if (m_endDelay != -1 && m_delay >= m_endDelay) {
			Destroy (gameObject);	
			Instantiate (m_endFx, m_transform.position, Quaternion.identity);
		}
		
		if (m_delay >= m_endTrigger && m_endTrigger != -1) {
			if( m_collider )
				m_collider.enabled = false;
			return;
		}
		
		if (m_spaceTrigger == 0) {
			if( m_collider )
				m_collider.enabled = true;
		} else {
			m_spaceCount += Time.deltaTime;
			
			if( m_spaceCount <= m_spaceTrigger-0.05f )
			{
				m_collider.enabled = true;
			}else if( m_spaceCount >= m_spaceTrigger )
			{
				m_collider.enabled = false;
				m_spaceCount = 0;
			}
		}
	}
}

