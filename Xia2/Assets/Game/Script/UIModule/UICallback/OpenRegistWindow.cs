using UnityEngine;
using System.Collections;

public class OpenRegistWindow : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
        var manager = (UIManager)FindObjectOfType(typeof(UIManager));
        if (manager)
        {
			manager.hide("Login");       //hideLoginWindow();
			manager.show("RegistPanel"); //showRegistWindow();
        }
    }
}
