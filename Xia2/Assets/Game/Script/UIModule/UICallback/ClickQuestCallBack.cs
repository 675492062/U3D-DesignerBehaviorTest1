using UnityEngine;
using System.Collections;

public class ClickQuestCallBack : MonoBehaviour {
    public UILabel Label;
    public UISprite Sprite;
    public UILabel Title;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClick()
    {
        Debug.Log("hehe");
    }
}
