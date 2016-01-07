using UnityEngine;
using System.Collections;

public class LevelSetting : MonoBehaviour
{
	public Transform playerStartPosition;
	public bool lowLevel = false;
	public Transform offGroupRoot;
	public MatReplacableObject[] replacedMatObjs;

	public Color fogColor, ambColor;
	public float fogDensity, fogStart, fogEnd;
	public FogMode fogType = FogMode.Linear;
	public bool fogOn;

	public Texture2D[] lightMapsFar;

//--------------------------------------------debug view, useless for game----------------------------
	public bool debugButton = false;
	public GameObject[] SpecialObjects;
	private bool debugWindow, debugFog, debugTransparentObj, debugLowMatObj, debugSpObj, debugShowFPS;
	private Rect windowRect = new Rect(250, 100, 200, 300);

	private GUIText gui;	
	private float updateInterval = 0.5f;
	private double lastInterval;
	private int frames = 0;


//--------------------------------------------debug view end----------------------------
	void Start()
	{
		GameObject player = GameObject.FindWithTag("Player");
		if(player != null && playerStartPosition != null)
		{
			player.transform.position = playerStartPosition.position;
			player.transform.rotation = playerStartPosition.rotation;
		}

		if(lowLevel)
			SetRenderLevelLow();

		RenderSettings.ambientLight = this.ambColor;
		RenderSettings.fogColor = this.fogColor;
		RenderSettings.fogMode = this.fogType;
		RenderSettings.fogDensity = this.fogDensity;
		RenderSettings.fogStartDistance = this.fogStart;
		RenderSettings.fogEndDistance = this.fogEnd;
		RenderSettings.fog = !this.lowLevel & this.fogOn;

		if(lightMapsFar.Length > 0)
		{
			LightmapSettings.lightmapsMode = LightmapsMode.NonDirectional;
			LightmapData[] newLightMaps = new LightmapData[lightMapsFar.Length];
			
			for(int i = 0; i < newLightMaps.Length; i++)
			{
				LightmapData newLmap = new LightmapData();
				if(lightMapsFar[i] == null && Application.isEditor)
				{
					Debug.LogError("Lost Lightmap!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!",this.gameObject);
					Debug.Break();
				}
				newLmap.lightmapFar = lightMapsFar[i];
				newLightMaps[i] = newLmap;
			}
			
			LightmapSettings.lightmaps = newLightMaps;
		}
	//	this.enabled = false;

//--------------------------------------------debug view, useless for game----------------------------
		this.enabled = debugButton;
		debugFog = fogOn;
		debugTransparentObj = !lowLevel;
		debugLowMatObj = lowLevel;
		debugShowFPS = false;

		if(SpecialObjects != null && SpecialObjects.Length > 0)
			debugSpObj = SpecialObjects[0].activeSelf;

		lastInterval = Time.realtimeSinceStartup;
		frames = 0;
//--------------------------------------------debug view end----------------------------
	}

	public void SetRenderLevelLow()
	{
		this.fogOn = RenderSettings.fog = false;

		if(offGroupRoot != null)
			offGroupRoot.gameObject.SetActive(false);

		if(replacedMatObjs != null && replacedMatObjs.Length > 0)
		{
			foreach(MatReplacableObject obj in replacedMatObjs)
			{
				obj.ReplaceMat(obj.replacedMat);
			}
		}
	}

//--------------------------------------------debug view, useless for game----------------------------
	void OnDisable()
	{
		if(gui)
			DestroyImmediate(gui.gameObject);
	}

	void Update()
	{
		if(debugShowFPS)
		{
			#if !UNITY_FLASH
			    ++frames;
			    double timeNow = Time.realtimeSinceStartup;
			    if (timeNow > lastInterval + updateInterval)
			    {
					if (!gui)
					{
						GameObject go = new GameObject("FPS Display", typeof(GUIText));
					//	go.hideFlags = HideFlags.HideAndDontSave;
						go.transform.position = Vector3.zero;
						gui = go.GetComponent<GUIText>();
						gui.pixelOffset = new Vector2(5,55);
					}
			        double fps = frames / (timeNow - lastInterval);
					float ms = 1000.0f / Mathf.Max ((float)fps, 0.00001f);
					gui.text = ms.ToString("f1") + "ms " + fps.ToString("f2") + "FPS";
			        frames = 0;
			        lastInterval = timeNow;
			    }
			#endif
		}
	}

	void OnGUI()
	{
		if(GUI.Button(new Rect(0,0,32,32),"| | "))
		{
			debugWindow = !debugWindow;
		}

		if(debugWindow)
		{
			windowRect = GUI.Window(0, windowRect, DebugWindow, "Debug Window");
		}			
	}

	void DebugWindow(int windowID)
	{
		if(GUILayout.Button("Show FPS : "+debugShowFPS))
		{
			debugShowFPS = !debugShowFPS;

			if(gui)
				gui.gameObject.SetActive(debugShowFPS);
		}

		if(GUILayout.Button("Fog : "+debugFog))
		{
			debugFog = !debugFog;
			RenderSettings.fog = debugFog;
		}

		if(GUILayout.Button("Transparent Objs : "+debugTransparentObj))
		{
			debugTransparentObj = !debugTransparentObj;

			if(offGroupRoot != null)
				offGroupRoot.gameObject.SetActive(debugTransparentObj);
		}

		if(GUILayout.Button("Low Material Objs : "+debugLowMatObj))
		{
			debugLowMatObj = !debugLowMatObj;

			if(replacedMatObjs != null && replacedMatObjs.Length > 0)
			{
				foreach(MatReplacableObject obj in replacedMatObjs)
				{
					if(debugLowMatObj)
						obj.ReplaceMat(obj.replacedMat);
					else
						obj.ReplaceMat(obj.originMat);
				}
			}
		}

		if(GUILayout.Button("Special Objs : "+debugSpObj))
		{
			debugSpObj = !debugSpObj;

			if(SpecialObjects != null && SpecialObjects.Length > 0)
			{
				foreach(GameObject sObj in SpecialObjects)
				{
					sObj.SetActive(debugSpObj);
				}
			}
		}

		GUI.DragWindow();
	}
//--------------------------------------------debug view end----------------------------


	[System.Serializable]
	public class MatReplacableObject
	{
		public Material replacedMat,originMat;
		public Transform replacedObjectRoot;

		public void ReplaceMat(Material repMat)
		{
			if(replacedObjectRoot != null && repMat != null)
			{
				foreach(Transform obj in replacedObjectRoot)
				{
					obj.gameObject.GetComponent<Renderer>().material = repMat;
				}
			}
		}
	}
}