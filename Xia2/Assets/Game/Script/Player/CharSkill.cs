//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//
//public class CharSkill : MonoBehaviour {
//
//	Transform m_transform;
//	Rigidbody m_rigidbody;
//	Animation m_animation;
//	Unit	  m_scriptUnit;
//
//	public Transform directionArrow;
//
//	Transform m_directionArrow = null;
//
//	Transform			m_fx1;
//
//	bool				m_bTool = true;
//
//	void Awake()
//	{
//		m_bTool = false;
//		m_transform = transform;
//		m_rigidbody = rigidbody;
//	}
//	
//	void Start () {
//		m_scriptUnit = GetComponent<Unit> ();
//		if (directionArrow) {
//			m_directionArrow = (Transform)Instantiate (directionArrow , m_transform.position, m_transform.rotation);
//			m_directionArrow.parent = m_transform;
//			m_directionArrow.localPosition = new Vector3 (0, 0.02f, 0.12f);		
//		}
//	}
//
//	public void ChangeCharactor( string charName )
//	{
//		m_animation   = m_transform.Find(charName).animation;
//	}
//
//	public void SetDirArrow( bool b )
//	{
//		if( m_directionArrow )
//			m_directionArrow.renderer.enabled = b;
//	}
//	
//	public void SkillCastFx( Transform fx )
//	{
//		if( !fx )
//			return;
//
//		int posType = fx.GetComponent<Ef_base> ().m_posType;
//		Vector3 pos = GetStartPos (posType);
//		m_fx1 = (Transform)Instantiate (fx, pos, m_transform.rotation);
//		m_fx1.GetComponent<Ef_base> ().m_target = m_transform;
//	}
//
//	public void LaunchSkill( Transform fx,int skillId,Vector3 targetPos )
//	{
//		SkillItem skill = SkillItem.Instance (skillId); //skill obj
//		if( !fx )
//			return;
//
//		if (skill.effectid != "0") {
//			Transform fx2;
//			int posType = fx.GetComponent<Ef_base> ().m_posType;
//			if( posType != 8 )
//				fx2 = (Transform)Instantiate (fx, Vector3.zero, m_transform.rotation);			
//			else
//				fx2 = (Transform)Instantiate (fx, Vector3.zero, Quaternion.identity);			
//			Vector3 pos = Vector3.zero;
//			if (skill.object_type == 1)
//				pos = GetStartPos (posType);
//			else
//				pos = targetPos;
//			fx2.position = pos;
//
//			fx2.GetComponent<Ef_base> ().m_target = m_transform;
//			fx2.GetComponent<Ef_base> ().m_attker = m_transform;
//			fx2.GetComponent<Ef_base> ().m_skillId = skillId;
//			fx2.GetComponent<Ef_base> ().m_param[0] = -1;
//
//			for (int i = 0; i < 5; i++) {
//				int type = skill.m_effects[i].type;
//				int obj  = skill.m_effects[i].obj;
//				int buffID = (int)skill.m_effects[i].parameter1;
//				if( type == 0 ) 
//					break;
//				if( type == (int)GlobalDef.SkillType.SKILL_TYPE_BUFF )
//				{
//					if( obj == (int)GlobalDef.SkillObject.SKILL_OBJ_MINE ||  obj == (int)GlobalDef.SkillObject.SKILL_OBJ_FRIEND  )
//					{
//						m_scriptUnit.m_curHeroData.bufferController.AddOneBufferById(buffID,fx2);
//					}
//				}
//			}				
//		} 
//	}
//
////	public void SelectEnemy()
////	{
////		List<Unit> ary = new List<Unit> ();
////		if (m_scriptUnit.m_unitType == GlobalDef.UnitType.UNIT_TYPE_PLAYER) {
////			ary = EnemyCtrl.instance.existEnemies;	
////		} else {
////			MyPlayer player = (MyPlayer)FindObjectOfType(typeof(MyPlayer));
////			ary.Add( player );						
////		}
////	}
//
//	public void DelAllFx()
//	{
//	}
//
//	public Vector3 GetStartPos( int type )
//	{
//		switch( type )
//		{
//		case 0:
//		{
//			return m_transform.position;		
//		}
//		case 1:
//		{
//			float h = m_scriptUnit.GetModeHeight();
//			return m_transform.position + Vector3.up * h; 		
//		}
//		case 2:
//		{
//			float h = m_scriptUnit.GetModeHeight() / 2;
//			return m_transform.position + Vector3.up * h;
//		}
//		case 5: //bip up
//		{
//			Vector3 pos = m_scriptUnit.GetModPos();
//			float h = m_scriptUnit.m_height/2;
//			return pos + Vector3.up * h; 		
//		}break;
//		case 6: //bip down
//		{
//			Vector3 pos = m_scriptUnit.GetModPos();
//			float h = m_scriptUnit.m_height/2;
//			return pos - Vector3.up * h; 		
//		}break;
//		case 7: //bip mid
//		{
//			Vector3 pos = m_scriptUnit.GetModPos();
//			return pos;
//		}break;
//		default:
//			return m_transform.position;
//		}
//	}
//
//	// Update is called once per frame
//	void Update () {
//		
//	}
//
//
//}
