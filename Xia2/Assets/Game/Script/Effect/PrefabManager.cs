using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PrefabManager{

	public enum enEfPathType
	{
		EF_NONE = 0,
		EF_SKILL = 1,
		EF_UI = 2,
		EF_ATK = 3,
		EF_OTHER = 4,
		EF_ENEMY = 5,
	};

	Dictionary<string,Transform> m_mapPrefab = new Dictionary<string, Transform>();

	public PrefabManager() { }

	private void AddPrefab( string name,Transform obj )
	{
		if (!obj)
			return;
		m_mapPrefab.Add (name, obj);
	}

	public void DestoryByName( string name )
	{
		bool b = m_mapPrefab.ContainsKey (name);
		if (!b)
			return;
		GameObject.Destroy( m_mapPrefab[name].gameObject );
	}

	public Transform GetPrefab( string name,string path )
	{
		bool b = m_mapPrefab.ContainsKey (name);
		if (!b) {
			GameObject obj = Resources.Load (path + "/" + name) as  GameObject;
			if( !obj )
			{
				Debug.LogError("resource not have name =" + path + name);
				return null;
			}
			m_mapPrefab.Add(name,obj.transform);
			return obj.transform;
		}
		return m_mapPrefab[name];
	}
	

	//==FX==
	public Transform GetFx( string name,enEfPathType type )
	{
		string path = FxTypeToPath (type);
		return GetPrefab ( name,path );
	}

	//==path_name 路径和名字
	public Transform GetFx( string path_name,string name )
	{
		bool b = m_mapPrefab.ContainsKey (name);
		if (!b) {
			GameObject obj = Resources.Load (path_name) as  GameObject;
			if( !obj )
			{
				Debug.LogError("resource not have name =" + path_name);
				return null;
			}
			m_mapPrefab.Add(name,obj.transform);
			return obj.transform;
		}
		return m_mapPrefab[name];
	}

	private string FxTypeToPath( enEfPathType type )
	{
		switch (type) {
			case enEfPathType.EF_ATK:
				return "Prefab/Effect/Atk";
			case enEfPathType.EF_SKILL:
				return "Prefab/Effect/Skill";
			case enEfPathType.EF_UI:
				return "Prefab/Effect/UI";
			case enEfPathType.EF_OTHER:
				return "Prefab/Effect/Other";
//			case enEfPathType.EF_ENEMY:
//				return "Prefab/Effect/enemy";
		};
		return null;
	}

	public System.Object GetAudio( string path, string name )
	{
		System.Object obj = Resources.Load (path + "/" + name);
		return obj;
	}

	//==Animation Pool==
	public Transform GetAnimationPool( string name )
	{
		return GetPrefab ( name,"Model/Player/AnimationPool" );
	}

	//==Hero Prefab==
	public Transform GetHeroPrefab( string name )
	{
		return GetPrefab ( name,"Prefab/Player" );
	}

	private static PrefabManager _instance = null;
	public static PrefabManager Instance()
	{
		if (_instance == null) {
			_instance = new PrefabManager();
		}
		return _instance;
	}
}
