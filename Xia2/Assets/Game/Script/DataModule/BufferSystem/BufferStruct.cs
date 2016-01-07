using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BufferStruct : BaseItem {

	public int id{
		get{
			return templateID;
		}
		
		set{
			templateID = value;
		}
	}
	
	public string name{get{return StaticBuff.Instance().getStr(templateID , "name");}}
	
	public string describe{get{return StaticBuff.Instance().getStr(templateID , "describe");}}
	
	public int interval{get{return StaticBuff.Instance().getInt(templateID , "interval");}}
	
	public float duration{get{return StaticBuff.Instance().getFloat(templateID , "time");}}
	
	public int effectid{get{return StaticBuff.Instance().getInt(templateID , "effectid");}}
	
	public int GetBufferType(string typeId){return StaticBuff.Instance().getInt(templateID , typeId);}
	
	public float GetBufferParameter1(string paramId){return StaticBuff.Instance().getFloat(templateID , paramId);}
	
	public int GetBufferParameter2(string paramId){return StaticBuff.Instance().getInt(templateID , paramId);}
	
	public DBaseBuffer DBaseBuffer;
	
	public BufferStruct(int id){
		this.id = id;
		InitBuffer();
	}
	
	public void Reset(){
		InitBuffer();
	}
		
	void InitBuffer(){
		string typeId = "attribute1_type";
		string param1Id = "parameter1";
		string param2Id = "parameter2";
		int bufferType = GetBufferType(typeId);
		float param1 = GetBufferParameter1(param1Id) * 100;
		int param2 = GetBufferParameter2(param2Id);
		DBaseBuffer = BufferFactory.CreateOneBuffer(bufferType , interval , duration , param1 ,param2);
	}
}