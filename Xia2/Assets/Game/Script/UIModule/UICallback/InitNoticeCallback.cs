using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InitNoticeCallback : MonoBehaviour {
    public GameObject Table;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void addInfo()
    {
        foreach (GameObject obj in MonoInstancePool.getInstance<UserData>().getNotice())
        {
            Destroy(obj);
        }
        List<string> titles = new List<string>();
        List<string> texts = new List<string>();
        List<int> imageIds = new List<int>();
        List<noticeInfo> noticeList = MonoInstancePool.getInstance<UserData>().getNoticeList();
        foreach (noticeInfo notice in noticeList)
        {
            titles.Add(notice.title + "     " + notice.time);
            texts.Add(notice.notice);
            imageIds.Add(notice.image);
        }

        for (int i = 0; i < titles.Count; i++)
        {
            Load(titles[i], texts[i], "NGUI");
        }
    }

    void Load(string title, string text, string spritName)
    {
		GameObject instance = Instantiate(Resources.Load("Prefab/Announcement/TableItemAnnouncement", typeof(GameObject))) as GameObject;
        instance.gameObject.SetActive(true);
        instance.transform.parent = Table.transform;
        instance.transform.localScale = Vector3.one;
        instance.transform.localPosition = new Vector3(instance.transform.position.x, instance.transform.position.y, 0);
        ClickQuestCallBack s = instance.GetComponent<ClickQuestCallBack>();
        s.Label.text = text;
//        s.Sprite.name = spritName;
        s.Title.text = title;
        MonoInstancePool.getInstance<UserData>().setNotice(instance);
    }

}
