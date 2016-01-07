using UnityEngine;
using System.Collections;

public class FaceOnclick : MonoBehaviour {

    public UIInput mInput;
    //public UILabel mLabel;
    //public UIButton mButton;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
        var label = GetComponentInChildren<UILabel>();
        mInput.value = mInput.value + label.text;
    }
}
