using UnityEngine;
using System.Collections;
using System;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;
//using mutils;
//using scopely.msgpacksharp;
//using structs;
using System.Collections.Generic;

public class AsyncSocket : MonoBehaviour
{
	
	//单例模式
	private static AsyncSocket instance;
	public Socket clientSocket;
	public string host = "192.168.1.72";
	public int hostPort = 4010;

	private const int ReciveBufferLength = 1024;
	private const int MsgHeadSize = 8;
	private byte[] readM = new byte[ReciveBufferLength];
	byte [] Middle = null;
	private List<SocketModel> messages = new List<SocketModel>();

//	public static AsyncSocket GetInstance ()
//	{
//		if (instance == null) {
//			instance = new AsyncSocket ();
//		}
//		return instance;
//	}
	
	public AsyncSocket ()
	{

	}
	public void init()
	{
		//创建Socket对象
		clientSocket = new Socket (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
		//服务器IP地址
		IPAddress ipAddress = IPAddress.Parse (host);
		
		//这是一个异步的建立连接，当连接建立成功时调用connectCallback方法
		IAsyncResult result = clientSocket.BeginConnect (ipAddress, hostPort, new AsyncCallback (connectCallback), clientSocket);
		
		//当连接超过5秒还没成功表示超时,非必须
		//这段succ变量，偶尔在Mono里报错，实在看不出问题，去掉也没问题
		bool succ = result.AsyncWaitHandle.WaitOne ();
		if (!succ) {
			//超时
			Debug.Log ("time out ");
			closeSocket ();
		}  
	}
	
	private void sendCallback (IAsyncResult asyncConnect)
	{
		int bytesSent = clientSocket.EndSend (asyncConnect);
		Debug.Log ("sendCallback: sent" + bytesSent);
		closeSocket ();
	}
	
	private void connectCallback (IAsyncResult asyncConnect)
	{
		Debug.Log ("EndConnect");
		clientSocket.EndConnect (asyncConnect);
//		businessComm ();
	}
	
//	private void businessComm ()
//	{
//		if (!clientSocket.Connected) {
//			Debug.Log ("businessComm clientSocket.Connected false");
//			closeSocket ();
//		}
//		MemoryStream memStream = new MemoryStream (128);
////		memStream.Write (SocketUtils.Int32ToByte (12345), 0, 4);
////		memStream.Write (SocketUtils.Int32ToByte (78901), 0, 4);
////		
////		MyMessage message = new MyMessage ();
////		message.MyNumber = 99;
////		message.MyString = "abcde";
////		byte[] datas = MsgPackSerializer.SerializeObject (message);
////		
////		memStream.Write (SocketUtils.Int32ToByte (datas.Length), 0, 4);
////		memStream.Write (datas, 0, datas.Length);
//		
//		byte[] byteData = memStream.GetBuffer ();
//		clientSocket.BeginSend (byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback (sendCallback), clientSocket);
//	}
	public void sendMessage<T>(int messageID, T msg) where T : class
	{
		if (!MonoInstancePool.getInstance<UserData>().getConnectNetWork ()) 
		{
			return;		
		}
		byte[] message = MsgSerializer.Serializer (msg);
		ByteArray arr= new ByteArray();
		arr.WriteInt(message.Length);
		arr.WriteInt(messageID);
		if (message != null)
		{
			arr.WriteBytes(message);	
		}
		try
		{
			clientSocket.BeginSend (arr.Buffer, 0, arr.Buffer.Length, SocketFlags.None, new AsyncCallback (sendCallback), clientSocket);
		}
		catch(SocketException e)
		{
			
			Debug.Log(" " + e.ErrorCode + " " + e.Message);
			//ErrorParse error = (ErrorParse)FindObjectOfType(typeof(ErrorParse));
			//if(error != null)
			//{
			//	error.showErrorWindow();
			//	error.setErrorText(e.Message);
			//}
		}
		
	}
	//关闭Socket
	public void closeSocket ()
	{
		Debug.Log ("Socket Closed");
		clientSocket.Close ();
	}
	
}