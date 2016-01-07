using UnityEngine;
using System.Collections;

public class ClickCloseFriendWindow : MonoBehaviour {

    public UIPanel FriendWindow;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
        if (FriendWindow.gameObject.activeSelf)
        {
            FriendWindow.gameObject.SetActive(false);
        }
        else
        {
            FriendWindow.gameObject.SetActive(true);
        }
    }
}
