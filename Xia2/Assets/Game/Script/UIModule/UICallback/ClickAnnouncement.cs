using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClickAnnouncement : MonoBehaviour {
    public GameObject AnnouncementWindow;

    public GameObject Table;
	// Use this for initialization
	void Start () {
        foreach (GameObject obj in MonoInstancePool.getInstance<UserData>().getNotice())
        {
            Destroy(obj);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClick()
    {
        
        
    }

    

}
