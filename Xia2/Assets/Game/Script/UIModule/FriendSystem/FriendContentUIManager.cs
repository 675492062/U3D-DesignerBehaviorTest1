using UnityEngine;
using System.Collections;

public class FriendContentUIManager : MonoBehaviour {
    public UIButton AgreeButton;
    public UIButton DisagreeButton;
    public UIButton AddButton;
    public UIButton DeleteButton;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    

    public void hideFriendContentWindow() 
    {
        this.gameObject.SetActive(false);
    }

    public void showDeleteButton()
    {
        if (DeleteButton != null)
        {
            DeleteButton.gameObject.SetActive(true);
        }
    }

    public void hideDeleteButton()
    {
        if (DeleteButton != null)
        {
            DeleteButton.gameObject.SetActive(false);
        }
    }

    public void showAddButton()
    {
        if (AddButton != null)
        {
            AddButton.gameObject.SetActive(true);
        }
    }

    public void hideAddButton()
    {
        if (AddButton != null)
        {
            AddButton.gameObject.SetActive(false);
        }
    }

    public void showAgreeButton()
    {
        if (AgreeButton != null)
        {
            AgreeButton.gameObject.SetActive(true);
        }
    }

    public void hideAgreeButton()
    {
        if (AgreeButton != null)
        {
            AgreeButton.gameObject.SetActive(false);
        }
    }

    public void showDisagreeButton()
    {
        if (DisagreeButton != null)
        {
            DisagreeButton.gameObject.SetActive(true);
        }
    }

    public void hideDisagreeButton()
    {
        if (DisagreeButton != null)
        {
            DisagreeButton.gameObject.SetActive(false);
        }
    }
}
