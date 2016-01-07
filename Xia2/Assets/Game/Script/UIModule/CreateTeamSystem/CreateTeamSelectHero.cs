using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateTeamSelectHero : MonoBehaviour {

	public CreateTeamSystemUIManager m_uiMng;

    public bool m_default = false;

	public int m_heroID = 0;

	public string m_TextureName;

	public UISprite m_heroImg;

	public List<Transform> m_other;

	public UISprite m_contryIcon;

	public UISprite m_contryFrameIcon;

	public UISprite m_bg;

	public UISprite m_headImg;

	public UISprite m_nameImgSel;

	public UISprite m_nameImgNor;

	public UISprite m_weaponIcon;

	public Transform m_container;

	Transform m_transform;

	Vector3 m_pos = new Vector3(0, 0, 0);

    bool m_bCallDefault = false;

	// Use this for initialization
	void Start ()
	{
		m_transform = this.transform;
		Vector3 pos = m_container.localPosition;
		m_pos.x = pos.x;
		m_pos.y = pos.y;
		m_pos.z = pos.z;

	}
	
	// Update is called once per frame
	void Update ()
	{
        if (m_default && !m_bCallDefault)
	    {
            m_bCallDefault = true;
            ShowSelect(true);
	    }
	    
	}

	void OnClick()
	{
		m_heroImg.spriteName = m_TextureName;
		
		var tweenObj = m_transform.GetComponent<UIPlayTween>();
		if (NGUITools.GetActive(tweenObj.tweenTarget))
		{
			ShowNormal(false);
		}
		else
		{
			foreach (Transform other in m_other)
			{
				other.GetComponent<CreateTeamSelectHero>().ShowNormal(true);
			}

			ShowSelect(false);
		}

	}

    public void ShowSelect(bool bPlay)
	{
		m_contryIcon.color = new Color(1.0f, 1.0f, 1.0f);
		m_bg.spriteName = "create_team_06";
		m_headImg.color = new Color(1.0f, 1.0f, 1.0f);
		m_weaponIcon.color = new Color(1.0f, 1.0f, 1.0f);
		m_nameImgSel.gameObject.SetActive(true);
		m_nameImgNor.gameObject.SetActive(false);
		m_contryFrameIcon.alpha = 1;


		m_container.localPosition = new Vector3(m_pos.x - 80, m_pos.y, m_pos.z);
		//m_container.Translate(new Vector3(-0.2f, 0, 0));

		m_uiMng.SetHeroID(m_heroID);

        if (bPlay)
        {
            var tweenObjs = m_transform.GetComponents<UIPlayTween>();
            foreach (UIPlayTween tweenObj in tweenObjs)
            {
                tweenObj.Play(true);
            }
        }
	}

	public void ShowNormal(bool bPlay)
	{
		var tweenObjs = m_transform.GetComponents<UIPlayTween>();

		if (tweenObjs.Length > 0 && NGUITools.GetActive(tweenObjs[0].tweenTarget))
		{
			m_contryIcon.color = new Color(0.5f, 0.5f, 0.5f);
			m_bg.spriteName = "create_team_07";
			m_headImg.color = new Color(0.5f, 0.5f, 0.5f);
			m_weaponIcon.color = new Color(0.5f, 0.5f, 0.5f);
			m_nameImgSel.gameObject.SetActive(false);
			m_nameImgNor.gameObject.SetActive(true);
			m_contryFrameIcon.alpha = 0;

			if (bPlay)
			{
				foreach(UIPlayTween tweenObj in tweenObjs)
				{
					tweenObj.Play(true);
				}
			}

			//m_container.localPosition = m_pos;
			m_container.localPosition = new Vector3(m_pos.x, m_pos.y, m_pos.z);
		}
	}

}
