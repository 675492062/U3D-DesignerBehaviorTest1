using UnityEngine;
using System.Collections;

public class AutoSetScreenWidh : MonoBehaviour {

	public const float standard_width = 960;
	
	public const float standard_height = 640;
	// Use this for initialization
	void Start () 
	{
		Camera camera = (Camera)this.GetComponentInParent(typeof(Camera));
		float size = camera.orthographicSize;
		
		float device_height = Screen.height;
		float device_width = Screen.width;
		
		float standard_aspect = standard_width / standard_height;
		float device_aspect = device_width / device_height;
		
		float resizeHeight = standard_height * size;
		float resizeWidth = standard_height * device_aspect * size;
		
		UISprite bg = (UISprite)GetComponent(typeof(UISprite));
		bg.width = (int)resizeWidth;
//		bg.height = (int)resizeHeight;

	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}