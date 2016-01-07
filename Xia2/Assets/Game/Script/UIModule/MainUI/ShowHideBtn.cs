using UnityEngine;
using System.Collections;

public class ShowHideBtn : MonoBehaviour {
	public UIWidget H_Btns;
	public UIWidget V_Btns;
	bool isShowH = false;
	bool isShowV = false;
	bool isRota = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnClick()
	{
		changeState();
	}
	public void changeState()
	{
		if(H_Btns != null)
		{
			if(isShowH)
			{
				isShowH = false;
				Vector3 pos = transform.localPosition;
				int num = H_Btns.GetComponentsInChildren<UIButton>().Length;
				pos.x += (num-1)*45;//120;
				SpringPosition.Begin(H_Btns.gameObject, pos, 30);
			}
			else 
			{
				isShowH = true;
				Vector3 pos = transform.localPosition;
				int num = H_Btns.GetComponentsInChildren<UIButton>().Length;
				pos.x -= (num-1)*45;//120;
				SpringPosition.Begin(H_Btns.gameObject, pos, 30);
			}
		}
		if(V_Btns != null)
		{
			if(isShowV)
			{
				isShowV = false;
				Vector3 pos = transform.localPosition;
				SpringPosition.Begin(V_Btns.gameObject, pos, 30);
			}
			else 
			{
				isShowV = true;
				Vector3 pos = transform.localPosition;
				int num = H_Btns.GetComponentsInChildren<UIButton>().Length;
				pos.y += num * 50;
				SpringPosition.Begin(V_Btns.gameObject, pos, 30);
			}
		}
		
		if(isRota)
		{
			isRota = false;
			Quaternion rota = new Quaternion();
			rota.z = 0;
			TweenRotation.Begin(this.gameObject, 0.1f, rota);
		}
		else 
		{
			isRota = true;
			Quaternion rota = new Quaternion();
			rota.z = 45;				
			TweenRotation.Begin(this.gameObject, 0.1f, rota);
		}
	}
	public bool isShow()
	{
		return isRota;
	}
}
