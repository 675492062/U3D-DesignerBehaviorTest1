using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ProtoBuf;
using UnityEngine;
   
 public   class SocketModel
{
	public int bodyLength;//
	public int messageID;//消息类型
	public byte[] message;//消息体
	public string strData;//消息体

	public SocketModel() { 

	}
	public SocketModel(int bodyLength, int messageID, string data) 
	{
	    this.bodyLength = bodyLength;
	    this.messageID = messageID;
		this.strData = data;	
	}
	public string toString() 
	{
	    return "bodyLength  " + this.bodyLength + "   msgID  " + this.messageID + "   msg  " + this.strData;
	}
	public void setBytesMessage(byte[] msg)
	{
		message = msg;
	}
}
