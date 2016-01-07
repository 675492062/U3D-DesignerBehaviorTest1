using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SelectOneActorEffect : MonoBehaviour {

	public CreateTeamSystemUIManager m_uiMng;

	//public GlobalDef.PlayerGender m_type;
    public int m_playerImgId = 850117;

	public List<UISprite> m_otherSprList;

	public float m_scaleTo;

	public float m_otherScaleTo;

	public int m_highLightZ;

	public int m_normalZ;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnClick()
	{
		foreach (UISprite spr in m_otherSprList)
		{
			spr.transform.localScale = new Vector3(m_otherScaleTo, m_otherScaleTo);
			spr.depth = m_normalZ;
			spr.color = new Color(0.5f, 0.5f, 0.5f);
		}

		UISprite mySpr = this.GetComponent<UISprite>();
		mySpr.transform.localScale = new Vector3(m_scaleTo, m_scaleTo);
		mySpr.depth = m_highLightZ;
		mySpr.color = new Color(1.0f, 1.0f, 1.0f);

		// record gender type: m_type
		//m_uiMng.SetGenderID((int)m_type);
        m_uiMng.SetPlayerImgID(m_playerImgId);
	}
}
