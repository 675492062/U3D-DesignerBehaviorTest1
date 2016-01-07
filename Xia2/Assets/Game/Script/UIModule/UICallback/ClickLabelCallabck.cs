using UnityEngine;
using System.Collections;

public class ClickLabelCallabck : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
        UILabel lbl = GetComponent<UILabel>();

        if (lbl != null)
        {
            string url = lbl.GetUrlAtPosition(UICamera.lastHit.point);
            if (!string.IsNullOrEmpty(url)) Application.OpenURL(url);
        }  
    }
}
