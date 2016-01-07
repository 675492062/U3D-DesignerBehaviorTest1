using UnityEngine;
using System.Collections;

public class ClickBackInCreateCallback : MonoBehaviour {
    public GameObject TeamNameWindow;
    public GameObject TeamImageWindow;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
        foreach (GameObject obj in MonoInstancePool.getInstance<UserData>().TeamImageObject)
        {
            Destroy(obj);
        }
        if (TeamImageWindow != null)
        {
            TeamImageWindow.gameObject.SetActive(false);
        }

        if (TeamNameWindow != null)
        {
            TeamNameWindow.gameObject.SetActive(true);
        }
    }
    
}
