using UnityEngine;
using System.Collections;

public class ResizeFullScreen : MonoBehaviour {
	
	public const float standard_width = 1280;
	
	public const float standard_height = 720;

	public bool beResizeWidth = true;
	public bool beResizeHeight = true;
	// Use this for initialization
	void Start () {
		ResizeScreen();
	}
	
	[ContextMenu("Execute")]
	public void ResizeScreen(){
		Camera camera = (Camera)this.GetComponentInParent(typeof(Camera));
		float size = camera.orthographicSize;
		
		float device_height = Screen.height;
		float device_width = Screen.width;
		
		float standard_aspect = standard_width / standard_height;
		float device_aspect = device_width / device_height;
		
		float resizeHeight = standard_height * size;
		float resizeWidth = standard_height * device_aspect * size;
		
		UISprite bg = (UISprite)GetComponent(typeof(UISprite));
		if(beResizeWidth)
			bg.width = (int)resizeWidth;
		if(beResizeHeight)
			bg.height = (int)resizeHeight;
	}
}
