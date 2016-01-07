using UnityEngine;
using System.Collections;

public class ClickAnnCloseButton : MonoBehaviour {
    public GameObject AnnouncementWindow;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClick()
    {
        foreach (GameObject obj in MonoInstancePool.getInstance<UserData>().getNotice())
        {
            Destroy(obj);
        }
        if (AnnouncementWindow.gameObject.activeSelf)
        {
            AnnouncementWindow.gameObject.SetActive(false);
        }
        else
        {
            AnnouncementWindow.gameObject.SetActive(true);
        }
    }
}
