using UnityEngine;
using System.Collections;

public class ClickCloseNoticeCallback : MonoBehaviour {
    public GameObject AnnouncementWindow;
    public UIPanel ServerListWindow;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClick()
    {
        //关闭公告窗口
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
