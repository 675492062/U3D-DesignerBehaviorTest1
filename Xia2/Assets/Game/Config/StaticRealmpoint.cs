using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
public class StaticRealmpoint : csvDataParent{

	private volatile static StaticRealmpoint _instance = null;
    private static readonly object lockHelper = new object();
    private StaticRealmpoint(){}
	private  Dictionary<string, int> dict = new  Dictionary<string, int>();
	public static StaticRealmpoint Instance()
	{
        if(_instance == null)
        {
            lock(lockHelper)
            {
                if(_instance == null)
				{
                     _instance = new StaticRealmpoint();
//					#if UNITY_EDITOR
					_instance.readData();
//					#endif
				}
            }
        }
        return _instance;
    }
	public  override string getStr(int num,string typeName)
	{
		string key = "" + num;
		return getStr (key, typeName);
	}

	public  override int getInt(int num,string typeName)
	{
		string key = "" + num;
		return getInt (key, typeName);
	}
	public  override float getFloat(int num,string typeName)
	{
		string key = "" + num;
		return getFloat (key, typeName);
	}
	public override void initDict()
	{
		int length = num ();
		dict.Clear ();
		for (int i = 0; i < length; i++) 
		{
			string id = _DataArray[i, 0];
			dict.Add(id, i);
		}
	}
	public int getIdxByTemplateID(string templateID)
	{
		if (dict.ContainsKey(templateID)) 
		{
			return dict[templateID];		
		}
		return -1;
	}
//	//通过类型和行数获取内容 num 0 start
//	public string getStrByIdx(int num,string typeName)
//	{
//		int typenum = getTypeNum(typeName);
//		if(typenum==-1)
//		{
//			Debug.Log(typeName+"   "+num+"  error");
//			return "-1";
//		}
//		return _DataArray[num,typenum];
//	}

	public  string getStr(string id, string title)
	{
		int idx = getIdxByTemplateID(id);
		if(idx == -1)
		{
			Debug.Log("getTemplate  " + idx+"  error");
			return "-1";
		}
		int num = getTypeNum (title);
		return _DataArray[idx,num];
	}

	//转换get的类型为int返回
	public  int getInt(string id,string title)
	{
		int idx = getIdxByTemplateID (id);
		if (idx == -1) 
		{
			Debug.Log("getTemplate  " + idx+"  error");
			return -1;		
		}
		int num = getTypeNum (title);
		return int.Parse(_DataArray[idx,num]);
	}
	
	//转换get的类型为float返回
	public  float getFloat(string id,string title)
	{
		int idx = getIdxByTemplateID (id);
		if (idx == -1) 
		{
			Debug.Log("getTemplate  " + idx+"  error");
			return -1f;		
		}
		int num = getTypeNum (title);
		return float.Parse(_DataArray[idx,num]);
	}
}