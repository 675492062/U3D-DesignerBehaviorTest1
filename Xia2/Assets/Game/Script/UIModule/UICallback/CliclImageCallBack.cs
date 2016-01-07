using UnityEngine;
using System.Collections;

public class CliclImageCallBack : MonoBehaviour {
    public UILabel Label;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClick()
    {
        //点击头像 初始化头像ID
        MonoInstancePool.getInstance<UserData>().image = Label.text;
    }
}
