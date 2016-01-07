#define GAME

using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class Skill : MonoBehaviour {

	Transform m_transform;
	Rigidbody m_rigidbody;
	Unit	  m_scriptUnit;

	public Transform directionArrow;
	Transform m_directionArrow = null;
	Transform		m_fx1;
	SkillConfigs	m_skillConfigs;

	void Awake()
	{
		m_transform = transform;
		m_rigidbody = GetComponent<Rigidbody>();
	}
	
	void Start () {
		m_skillConfigs = GameObject.FindObjectOfType(typeof(SkillConfigs)) as SkillConfigs;
		if (m_skillConfigs == null) {
			Debug.LogError ("Error SkillConfigs Gameobject is not have");
		}
		m_scriptUnit = GetComponent<Unit> ();
		if (directionArrow) {
			m_directionArrow = (Transform)Instantiate (directionArrow , m_transform.position, m_transform.rotation);
			m_directionArrow.parent = m_transform;
			m_directionArrow.localPosition = new Vector3 (0, 0.02f, 0.12f);		
		}
	}

	public void SetDirArrow( bool b )
	{
		if( m_directionArrow )
			m_directionArrow.GetComponent<Renderer>().enabled = b;
	}

	public void PlaySkillMainFx(Transform fx,int skillId,Vector3 targetPos )
	{
		Transform fx2 = null;
		if (fx != null) {
			int posType     = fx.GetComponent<Ef_base> ().m_posType;
			bool isrotation = fx.GetComponent<Ef_base> ().m_rotationWithTarget;
			if( isrotation )
				fx2 = (Transform)Instantiate (fx, Vector3.zero, m_transform.rotation);			
			else
				fx2 = (Transform)Instantiate (fx, Vector3.zero, Quaternion.identity);		

			Config skillConfig =  m_skillConfigs.GetConfigByID(skillId);
			if( skillConfig == null )
			{
				Debug.LogError("skill Id is not have in skill tool configs skillID = " + skillId);
				return;
			}
			int objType = skillConfig.m_objType;
			if (objType == 0)   				Ef_base.GetPosByType (fx2,m_transform,posType,isrotation);
			else               			fx2.position = targetPos;

			Ef_base ef = fx2.GetComponent<Ef_base> ();
			ef.m_user = m_transform;
			ef.m_skillId = skillId;
			ef.m_param[0] = -1;
		}

#if GAME
		SkillItem skill = SkillItem.GetStaticData (skillId); //skill obj
		if( skill == null )
			return;

		for (int i = 0; i < 5; i++) {
			int type = skill.m_effects[i].type;
			int obj  = skill.m_effects[i].obj;
			int buffID = (int)skill.m_effects[i].parameter1;
			if( type == 0 ) 
				break;
			if( type == (int)GlobalDef.SkillType.SKILL_TYPE_BUFF )
			{
				if( obj == (int)GlobalDef.SkillObject.SKILL_OBJ_MINE ||  obj == (int)GlobalDef.SkillObject.SKILL_OBJ_FRIEND  )
				{
					m_scriptUnit.m_curHeroData.bufferController.AddOneBufferById(buffID,fx2,null);
				}
			}
		}
#endif
	}


	public void PlaySkillFx( Transform fx)
	{
		if (fx != null) {
			int posType = fx.GetComponent<Ef_base> ().m_posType;
			Transform fx2 = (Transform)Instantiate (fx, Vector3.zero, m_transform.rotation);			
			Ef_base.GetPosByType (fx2,m_transform,posType,true);
			fx2.GetComponent<Ef_base> ().m_user = m_transform;
		}
	}

	void Update () {
		
	}
}
