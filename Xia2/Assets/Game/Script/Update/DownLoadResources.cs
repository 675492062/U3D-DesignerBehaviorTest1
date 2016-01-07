using UnityEngine;
using System.Collections;
using System.IO;
using LitJson;

public class DownLoadResources : MonoBehaviour {
	int count = 0;
	JSONNode data = null;
	JSONClass obj = null;
	public UILabel label;
	public UILabel label_path;

	WWW download;
	string url = "http://192.168.21.83/Game/Json/";
	string resourcePath = "";
	int guiOffset = 20;
	AssetBundle assetBundle;
	Object instanced;

	// Use this for initialization
	void Start () 
	{
		resourcePath = getWriteablePath ();

		string file = "Json/fileList";
		TextAsset textObj =  Resources.Load(file, typeof(TextAsset)) as TextAsset;  
		data = JSON.Parse(textObj.text);
		obj =  data.AsObject;
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
	void OnClick()
	{
		startDownloadByIdx (count);
	}
	void startDownloadByIdx(int idx)
	{
		if(idx >= data.Count)
		{
			ConfigManager.getInstance().refreshTemplateData();
			return;
		}

		string realPath = url + obj.key(count) + ".unity3d";
		label.text = obj.key (count);
		//开始下载
		StartCoroutine(StartDownload (realPath));
	}
	IEnumerator StartDownload (string path) 
	{
		download = new WWW (path);
		yield return download;
		
		assetBundle = download.assetBundle;

		Debug.Log ("down load: " + download.assetBundle.mainAsset.name);

		label_path.text = resourcePath + download.assetBundle.mainAsset.name + ".json";
		System.IO.File.WriteAllText(resourcePath + download.assetBundle.mainAsset.name + ".json", download.assetBundle.mainAsset.ToString());  
		count++;
		startDownloadByIdx(count);
	}
	public string getWriteablePath()
	{
		string path = "";
//		if (Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.WindowsEditor)
//			path = Application.persistentDataPath + "/Json/";
//		else if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
//			path = Application.persistentDataPath + "/Json/";
//		else 
//			path = Application.persistentDataPath + "/Json/";

		path = Application.persistentDataPath + "/Json/";
		if(!Directory.Exists (path))
		{
			Directory.CreateDirectory(path);
		}
		return path;
	}
}



