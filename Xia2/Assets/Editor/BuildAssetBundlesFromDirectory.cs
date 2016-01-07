using UnityEngine;  
using UnityEditor;  
using System.IO;  
public class BuildAssetBundlesFromDirectory {  
	
	[@MenuItem("Asset/Build AssetBundles From Directory of Files %e")]  
	static void ExportAssetBundles () {  
		// Get the selected directory  
		//获取选择的目录  
		
		string path = AssetDatabase.GetAssetPath(Selection.activeObject);  
		Debug.Log("Selected Folder: " + path);  
		if (path.Length != 0) 
		{  
			path = path.Replace("Assets/", "");  	
			string [] fileEntries = Directory.GetFiles(Application.dataPath+"/"+path);  
			foreach(string fileName in fileEntries) 
			{  
				string filePath = fileName.Replace("\\","/");  	
				int index = filePath.LastIndexOf("/");  
				filePath = filePath.Substring(index+1);  
				Debug.Log("filePath:"+filePath);  
				string localPath = "Assets/" + path;  
//				if (index > 0)  
//					localPath += filePath;  
				Object t = AssetDatabase.LoadMainAssetAtPath(localPath);  
				if (t != null) 
				{  	
					Debug.Log(t.name);  	
					string bundlePath = "Assets/package/json/" + t.name + ".unity3d";  
					Debug.Log("Building bundle at: " + bundlePath);  
					// Build the resource file from the active selection.  
					//从激活的选择编译资源文件  
					Debug.Log("build target: " + BuildTarget.iOS + " default: " + EditorUserBuildSettings.activeBuildTarget);
					BuildPipeline.BuildAssetBundle  (t, null, bundlePath, BuildAssetBundleOptions.CompleteAssets | BuildAssetBundleOptions.CollectDependencies,EditorUserBuildSettings.activeBuildTarget);  
				}  
			}  
		}  
	}  
	
}  