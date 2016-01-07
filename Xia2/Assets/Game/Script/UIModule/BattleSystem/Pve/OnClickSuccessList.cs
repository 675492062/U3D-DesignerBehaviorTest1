using UnityEngine;
using System.Collections;

public class OnClickSuccessList : MonoBehaviour {

    public UISprite m_icon;
    public UISprite m_mask;
    public long guid;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
        if (guid <= 0)
            return;

        Debug.Log("This Onclick!!!!");
    }
}
