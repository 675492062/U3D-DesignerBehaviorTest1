using UnityEngine;
using System.Collections;

public class ModelRenderTextureManager{

    private static ModelRenderTextureManager manager;
    private Rect m_Size;                                      //生成大小

	private GameObject RolePrefab;    //角色模型预制
//    Instance
    public static ModelRenderTextureManager getInstance()
    {
        if (manager == null)
        {
            manager = new ModelRenderTextureManager();
        }

        return manager;
    }

    

    
    public GameObject CreatModelRenderTexture(string path, GameObject obj,GameObject parent, Rect size)
    {
		clear (parent.transform);
        m_Size = size;
		//创建texture 和摄影机
		RenderTexture tex = new RenderTexture(1024, 1024, 24, RenderTextureFormat.ARGB32);
		Camera gos = createCamera(tex);
		gos.transform.parent = parent.transform;
		gos.transform.localPosition = new Vector3(0, 0, 0);
	
		//创建角色模型
		RolePrefab = createHeroObj(path, obj);
		if(RolePrefab == null)
		{
			return null;
		}
		RolePrefab.gameObject.SetActive (true);
		RolePrefab.transform.parent = gos.transform;
		Quaternion rot = RolePrefab.transform.localRotation;
		rot.x = 17f; rot.y = -180f; rot.z = 1.53f;
		RolePrefab.transform.localPosition = new Vector3 (0.008f,-0.061f,0.865f);
		Material material = new Material(Shader.Find("Unlit/Transparent Colored"));
		material.mainTexture = tex;

        UITexture uiTex = obj.GetComponent<UITexture>();
		uiTex.material = material;
        uiTex.SetDimensions((int)m_Size.width, (int)m_Size.height);

//		if(obj.GetComponent<BoxCollider>() == null)
//		{
	        obj.AddComponent<BoxCollider>();
	        obj.GetComponent<BoxCollider>().size = new Vector3(200, 300, 0);
			obj.GetComponent<BoxCollider> ().isTrigger = true;
//		}
//		if(obj.GetComponent<DragModerRender>() == null)
//		{
        	obj.AddComponent<DragModerRender>();
			obj.GetComponent<DragModerRender>().target = RolePrefab;
//		}

		return RolePrefab;
    }
	private GameObject createHeroObj(string path, GameObject objBinding)
	{
		if (objBinding == null)
		{
			Debug.LogError("BindingGameObject is null !!!");
			return null;
		}
		
		GameObject cloneHero = Resources.Load(path) as GameObject;
		if (cloneHero == null)
		{
			Debug.LogError("CloneHeroGameObject is null !!!  " + path);
			return null;
		}

		GameObject HeroObj = MonoBehaviour.Instantiate(cloneHero, objBinding.transform.localPosition,
		                                               objBinding.transform.localRotation) as GameObject;
		
		HeroObj.transform.localRotation = cloneHero.transform.localRotation;
		HeroObj.transform.localPosition = cloneHero.transform.localPosition;
		HeroObj.transform.localScale = cloneHero.transform.localScale;
		
		
		HeroObj.layer = 9;
		foreach (Transform t in HeroObj.GetComponentsInChildren<Transform>())
		{
			t.gameObject.layer = 9;
		}
		if( string.Compare(path, "Prefab/Player/Preview/m_xiahoudun") == 0)
		{
			HeroObj.transform.localRotation = Quaternion.Euler(0, 155f, 0);
		}
		else 
		{
			HeroObj.transform.localRotation = Quaternion.Euler(0, 180f, 0);
		}
		HeroObj.name = "ModelPreview";
		
		//		HeroModelInfo info = cloneHero.GetComponentInChildren<HeroModelInfo>();
		//		info.showModelByIdx(2);
		
		return HeroObj;
	}
	private Camera createCamera(RenderTexture targetTex)
	{
//		GameObject gos = new GameObject("CameraModelView", typeof(Camera));
//		Camera camera = gos.GetComponent<Camera>();
//		camera.depth = 30;
//		camera.targetTexture = targetTex;
//		camera.fieldOfView = 5;
//		camera.farClipPlane = 50;
//		camera.cullingMask = 1 << 9;
//		return camera;

		GameObject gos = new GameObject("CameraModelView", typeof(Camera));
		Camera camera = gos.GetComponent<Camera>();
		camera.orthographic = false;
		camera.nearClipPlane = 0.3f;
		camera.farClipPlane = 1f;
		camera.targetTexture = targetTex;
		camera.fieldOfView = 13f;
		camera.cullingMask = 1 << 9;
		return camera;
	}
	public void clear(Transform obj)
	{
		foreach (Transform child in obj)
		{
			Debug.Log("del--------------------------------------------- " + child.name);
			MonoBehaviour.Destroy(child.gameObject);
		}
	}
}
