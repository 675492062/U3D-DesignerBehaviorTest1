
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

abstract public class MonoInstancePool
{
	private static Dictionary<string, Component> sInstancePool = new Dictionary<string, Component>();
	private static GameObject parent = null;
	
	public static T getInstance<T>(bool bDestroy = true, string sGameObjectName = null)
		where T : Component
	{
		if(parent == null)
		{
			parent = new GameObject();
			parent.name = "InstancePool";
			GameObject.DontDestroyOnLoad(parent);
		}
		string sFullName;
		if (sGameObjectName != null)
		{
			sFullName = sGameObjectName;
		}
		else
		{
			sFullName = typeof(T).FullName;
		}
//		Debug.Log("instance name " + sFullName);
		if (sInstancePool.ContainsKey(sFullName) && sInstancePool[sFullName] == null)
		{
			sInstancePool.Remove(sFullName);
		}
		
		if (!sInstancePool.ContainsKey(sFullName))
		{
			GameObject go = new GameObject();
			go.transform.parent = parent.transform;
			go.name = sFullName;
			sInstancePool.Add(sFullName,go.AddComponent<T>() as T);
			
			if (bDestroy)
			{
				GameObject.DontDestroyOnLoad(go);
			}
		}
		return sInstancePool[sFullName] as T;
	}


	public static void destroy()
	{
//		for(int i = 0; i < sInstancePool.Count; i++)
//		{
//			Component com = sInstancePool.ElementAt(i).Value;
//			MonoBehaviour.Destroy(com.gameObject);
//		}
		sInstancePool.Clear();
		if(null != parent)
		{
			MonoBehaviour.Destroy(parent.gameObject);
		}

	}
}