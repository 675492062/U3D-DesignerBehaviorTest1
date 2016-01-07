using UnityEngine;
using System.Collections;
using ProtoBuf;
using System.IO;

public class MsgSerializer
{
	public static T Deserialize<T>(SocketModel module) where T : class,new()
	{
		ProtoModelSerializer serializer = new ProtoModelSerializer();  
		System.IO.MemoryStream memStream = new System.IO.MemoryStream (module.message);  
		T data = new T();
		data = (T)serializer.Deserialize(memStream, data, data.GetType());
		return data;
	}
	public static byte[] Serializer<T>(T msg) where T : class
	{
		byte []data;
		using (MemoryStream ms = new MemoryStream())
		{ 
			ProtoModelSerializer serializer = new ProtoModelSerializer(); 
			serializer.Serialize(ms, msg);
			data = new byte[ms.Length];
			ms.Position= 0;
			ms.Read(data, 0, data.Length);
		}
		return data;
	}

}
