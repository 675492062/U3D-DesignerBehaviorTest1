using UnityEngine;
using System.Collections;
using System;

public class CliclCreateRoleCallback : MonoBehaviour {
    //public string sceneName = "Game_NetNewScene";
    //public UIInput Input;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClick()
    {
        foreach (GameObject obj in MonoInstancePool.getInstance<UserData>().TeamImageObject)
        {
            Destroy(obj);
        }
        foreach (GameObject obj2 in MonoInstancePool.getInstance<UserData>().TeamHeroObject)
        {
            Destroy(obj2);
        }
        //string TeamName = Input.value;
//         var TeamImage = MonoInstancePool.getInstance<UserData>().getImage();
        string ImageID = MonoInstancePool.getInstance<UserData>().getImage();
        //Debug.Log(TeamName);
        //Debug.Log(Convert.ToInt32(ImageID));

        //发送创建战队消息
		MonoInstancePool.getInstance<SendMessageHander>().SendCreateTeamRequest(Convert.ToInt32(ImageID), MonoInstancePool.getInstance<UserData>().teamName);
        //TODO 如果成功，则切换场景，如果不成功则停留在此场景并弹出提示框
        //Application.LoadLevel(sceneName);
    }
}
