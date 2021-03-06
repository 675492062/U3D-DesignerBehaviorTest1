using UnityEngine;
using System.Collections;
using LitJson;
using System.Collections.Generic;

public class csvDataParent{
//	public  abstract void print();
//	public  abstract string[] getKeyArray();
//	public  abstract string[,] getDataArray();
//	public  abstract int num();
//	public  abstract int keynum();
//	private int getTypeNum(string typeName)
//	{
//		return -1;
//	}
//	public  abstract string getStr(int num,string typeName);
//	public  abstract int getInt(int num,string typeName);
//	public  abstract float getFloat(int num,string typeName);

	public  Dictionary<int, int> dict = new  Dictionary<int, int>();

    public int[] allID;

	public virtual void initDict()
	{
		int length = num ();
        allID = new int[length];
		dict.Clear ();
		for (int i = 0; i < length; i++) 
		{
			int id = System.Int32.Parse(_DataArray[i, 0]);
            allID[i] = id;
			dict.Add(id, i);
		}
	}

	public virtual int getIdxByTemplateID(int templateID)
	{
		if (dict.ContainsKey(templateID)) 
		{
			return dict[templateID];		
		}
		return -1;
	}

	//通过类型和行数获取内容 num 0 start
	public virtual string getStrByIdx(int num,string typeName)
	{
		int typenum = getTypeNum(typeName);
		if(typenum==-1)
		{
			Debug.Log(typeName+"   "+num+"  error");
			return "-1";
		}
		return _DataArray[num,typenum];
	}
	
	public virtual string getStr(int id, string title)
	{
		int idx = getIdxByTemplateID(id);
		if(idx == -1)
		{
			Debug.Log("getTemplate  " + idx+"  error" + " id : " + id);
			return "-1";
		}
		int num = getTypeNum (title);
//		Debug.Log ( "name" + this.ToString() + "idx " + idx + " num " + num + " title " + title);
		return _DataArray[idx,num];
	}
	
	//转换get的类型为int返回
	public virtual int getInt(int id,string title)
	{
		int idx = getIdxByTemplateID (id);
		if (idx == -1) 
		{
			Debug.Log("getTemplate  " + id + " title " + title + "  error!");
			return -1;		
		}
		int num = getTypeNum (title);
        //Debug.Log ("file " +this.ToString() +  " title " + title + " idx " + idx + " id " + id);
		return int.Parse(_DataArray[idx,num]);
	}

	//转换get的类型为int返回
	public virtual int getIntByIdx(int idx,string title)
	{
		if (idx == -1) 
		{
			Debug.Log("getTemplate  " + idx );
			return -1;		
		}
		int num = getTypeNum (title);
		//Debug.Log ("file " +this.ToString() +  " title " + title + " idx " + idx + " id " + id);
		return int.Parse(_DataArray[idx,num]);
	}
	
	//转换get的类型为float返回
	public virtual float getFloat(int id,string title)
	{
		int idx = getIdxByTemplateID (id);
		if (idx == -1) 
		{
			Debug.Log("getTemplate  " + idx+"  error");
			return -1f;		
		}
//		Debug.Log ("file " +this.ToString() +  " title " + title + " idx " + idx + " id " + id);
		int num = getTypeNum (title);
		return float.Parse(_DataArray[idx,num]);
	}

	// "key1","key2","key3"
	private string[] _AllKey = {};
	// {"10","12","11"}

	public string[,] _DataArray= {{}};

	public Dictionary<int, string> data = new Dictionary<int, string>();
	
	public virtual void readData()
	{
		string file = "Json/" + this.ToString ();
		TextAsset textObj =  Resources.Load(file, typeof(TextAsset)) as TextAsset;  
		JSONNode data = JSON.Parse(textObj.text);
//		Debug.Log ("read fileName = " + file);

		JSONClass obj =  data.AsObject;
		JSONClass sub = obj[0] as JSONClass;
		if(obj == null || sub == null)
		{
			return;
		}
		int l = obj.Count;
		int h = sub.Count;
		_DataArray = null;
		_DataArray = new string[l-1, h+1];
		_AllKey = new string[h + 1];
		_AllKey[0] = "templateID";
		
		for(int j = 0; j < sub.Count; j++)
		{
			_AllKey[j+1] = sub.AsObject.key(j);
		}
		
		
		for(int i = 0; i < obj.Count-1; i++)
		{
			if(obj.key(i) == "-1")
			{
				continue;
			}
			_DataArray[i,0] = obj.key(i);
			
			JSONClass subObj = obj[i] as JSONClass;
			for(int j = 0; j < subObj.Count; j++)
			{
				_DataArray[i,j+1] = subObj[j].ToString();
			}
		}
		
		initDict ();
		//		print ();
	}

	public virtual void readData(string filePath)
	{
		string file = filePath;
		TextAsset textObj =  Resources.Load(file, typeof(TextAsset)) as TextAsset;  
		JSONNode data = JSON.Parse(textObj.text);
		
		JSONClass obj =  data.AsObject;
		JSONClass sub = obj[0] as JSONClass;
		if(obj == null || sub == null)
		{
			return;
		}
		int l = obj.Count;
		int h = sub.Count;
		_DataArray = null;
		_DataArray = new string[l-1, h+1];
		_AllKey = new string[h + 1];
		_AllKey[0] = "templateID";
		
		for(int j = 0; j < sub.Count; j++)
		{
			_AllKey[j+1] = sub.AsObject.key(j);
		}
		
		
		for(int i = 0; i < obj.Count-1; i++)
		{
			_DataArray[i,0] = obj.key(i);
			
			JSONClass subObj = obj[i] as JSONClass;
			for(int j = 0; j < subObj.Count; j++)
			{
				_DataArray[i,j+1] = subObj[j].ToString();
			}
		}
		
		initDict ();
		//		print ();
	}

	//打印
	public virtual void print()
	{
		
		int row = _DataArray.GetLength(0);
		int column = _DataArray.GetLength(1);
		
		string key = "";
		for(int i  = 0; i < column; i++)
		{
			key += _AllKey[i] + " "; 
		}
		Debug.Log (key);
		for(int i=0; i<row; i++)
		{
			string printData = i+"row: ";
			for(int j=0; j<column; j++)
			{
				printData+=(_DataArray[i,j]+" ");
			}
			Debug.Log(printData);
		}
		
	}
	
	//获取所有的Key
	public string[] getKeyArray()
	{
		return _AllKey;
	}
	
	//获取所有的Data
	public string[,] getDataArray()
	{
		return _DataArray;
	}
	
	public  virtual int num()
	{
		return _DataArray.GetLength(0);
	}
	
	public  virtual int keynum()
	{
		return _AllKey.Length;
	}
	
	//通过type获取num标识 
	public virtual int getTypeNum(string typeName)
	{
		for(int i=0; i<keynum(); i++)
		{
			if(_AllKey[i] == typeName)
			{
				return i;
			}
		}
		return -1;
	}
	
	public virtual bool hasKey(string key)
	{
		for(int i=0; i<keynum(); i++)
		{
			if(_AllKey[i] == key)
			{
				return true;
			}
		}
		return false;
	}

}