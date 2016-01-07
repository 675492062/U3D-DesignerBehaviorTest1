using UnityEngine;
using System.Collections;

public class offset : MonoBehaviour {

    public UILabel label;
    public UISprite sprite;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick()
    {
        MonoInstancePool.getInstance<UserData>().image = label.text;
    }
}
