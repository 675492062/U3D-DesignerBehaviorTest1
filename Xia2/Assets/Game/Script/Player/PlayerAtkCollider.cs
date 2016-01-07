using UnityEngine;
using System.Collections;

public class PlayerAtkCollider : MonoBehaviour {

	public bool m_myPlayer = true;
	Transform m_transfom;
	public Player m_player{ set; get;}
	
	void Awake(){
		m_transfom = transform;
		m_player = GetComponentInParent<Player> ();
	}
	
	void Start () {
		
	}

	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		//< 玩家的时候
		if (m_myPlayer) {
			if (other.gameObject.layer == 8) {
					GetComponentInParent<BasePlayer> ().SendMessage ("OnAttack", other.transform);
			}			
		} else {
			if (other.gameObject.layer == 15) {
				GetComponentInParent<BasePlayer> ().SendMessage ("OnAttack", other.transform);
			}				
		}

	}
}
