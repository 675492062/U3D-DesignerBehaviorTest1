using UnityEngine;
using System.Collections;

public class ClickSearchCallback : MonoBehaviour {
    public GameObject SearchListWindow;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
        if (SearchListWindow != null)
        {
            SearchListWindow.gameObject.SetActive(true);
        }
        var manager = (SearchListUImanager)FindObjectOfType<SearchListUImanager>();
        //Debug.Log(manager);
        manager.setMyUID();
        manager.hideFriendListWindow();
        manager.hideInviteListWindow();
        manager.hideSearchedFriendWindow();
        manager.hideAddButtonWindow();
        manager.hideAgreeButtonWindow();
        manager.hideDisagreeButtonWindow();
    }
}
