using UnityEngine;
using System.Collections;

public class Damege : MonoBehaviour {

	Camera uiCamera;
	GameObject target;

	float maxDis = 0.25f;
	float speed = 0.005f;
	float curDis = 0.0f;
	bool first = true;
	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void LateUpdate()
	{
		curDis += speed;
		if(curDis < maxDis)
		{
			Vector3 p = transform.position;
			p.y += speed;
			transform.position = p;
		}
		else 
		{
			Destroy(this.gameObject);
		}
	}
	public void setInitPosition(Camera ca, GameObject go, int num)
	{
		uiCamera = ca;
		target = go;

		curDis = 0;
		first = true;
		Vector3 pos = target.transform.position;
		Vector2 view = Camera.main.WorldToScreenPoint (pos);
		Vector3 screenPos = uiCamera.ScreenToWorldPoint (view);
		transform.position = screenPos;

		UILabel label = GetComponentInChildren<UILabel> ();
		label.text = "" + num;
	}
}
