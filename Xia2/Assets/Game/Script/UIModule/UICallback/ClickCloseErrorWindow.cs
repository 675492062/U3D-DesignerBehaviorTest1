using UnityEngine;
using System.Collections;

public class ClickCloseErrorWindow : MonoBehaviour {
    public GameObject TeamNameWindow;
    public GameObject GeneralWindow;
    public UIPanel panel;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
        
		if(panel != null)
		{
			panel.gameObject.SetActive(false);
		}
        if (GeneralWindow != null)
        {
            GeneralWindow.gameObject.SetActive(false);
        }

        if (TeamNameWindow != null)
        {
            TeamNameWindow.gameObject.SetActive(true);
        }
    }
}
