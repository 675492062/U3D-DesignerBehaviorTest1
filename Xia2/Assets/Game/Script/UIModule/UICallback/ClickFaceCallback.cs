using UnityEngine;
using System.Collections;

public class ClickFaceCallback : MonoBehaviour {

    public GameObject faceWindow;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
        if (faceWindow.gameObject.activeSelf)
        {
            faceWindow.gameObject.SetActive(false);
        }
        else
        {
            faceWindow.gameObject.SetActive(true);
        }
    }
}
