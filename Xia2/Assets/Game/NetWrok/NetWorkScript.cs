using UnityEngine;
using System.Collections;
using System.Net.Sockets;
using System.IO;
using System;
using System.Text;
using LitJson;
using System.Threading;
using System.Collections.Generic;
using ProtoBuf;
using System.Net;
using System.Runtime.Remoting.Messaging;

public  class NetWorkScript : MonoBehaviour
{
    private Socket socket;
//	public string host = "211.151.21.121";//服务器IP地址
//	public int port = 21700;//服务器端口
	public string host = "192.168.1.72";//服务器IP地址
	public int port = 4010;//服务器端口
	private const int ReciveBufferLength = 1024;
	private const int MsgHeadSize = 8;
	private byte[] readM = new byte[ReciveBufferLength];
	int timeOut = 2000;
	byte [] Middle = null;

    private List<SocketModel> messages = new List<SocketModel>();

	private int allCount = 0;
	
	public bool needReconnect = false;
	bool sendReconnectMsg = false;
	bool needExit = false;
	bool startReconnectNow = false;
	int  reConnectTimes = 0;
	int  maxReConnectTimes = 3;
	void Update()
	{
		if(needExit == true)
		{
			needExit = false;
			showTimeOut();
		}
//		if (needReconnect == true) //显示提示重连的窗口
//		{
//			needReconnect = false;
//			ReconnectWindow window = (ReconnectWindow)FindObjectOfType(typeof(ReconnectWindow));
//			if(null != window)
//				window.reconnect = true;
//		}
		if (needReconnect == true) //显示提示重连的窗口
		{
			needReconnect = false;
			MonoInstancePool.getInstance<LoginModuleMsg>().stopHeartBeat();//停止计时
			InvokeRepeating("reConnect",0,10);
		}
		if(sendReconnectMsg == true)  //重连成功 发送重连的消息
		{
			sendReconnectMsg = false;
			CancelInvoke("reConnect");
			MonoInstancePool.getInstance<SendMessageHander> ().SendReconnectMsg(MonoInstancePool.getInstance<UserData>().token);
		}
		if(startReconnectNow == true) //现在就开始重连
		{
			startReconnectNow = false;
			reConnect();//重连
			MonoInstancePool.getInstance<LoginModuleMsg>().stopHeartBeat();//停止计时
		}
	}
    public void init() 
	{
        try
        {
            //创建socket连接对象
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //连接到服务器
//            socket.Connect(host, port);

			//服务器IP地址
			IPAddress ipAddress = IPAddress.Parse (host);
			//这是一个异步的建立连接，当连接建立成功时调用connectCallback方法
			IAsyncResult result = socket.BeginConnect (ipAddress, port, new AsyncCallback (connectCallback), socket);

			//超时
			bool succ = result.AsyncWaitHandle.WaitOne (timeOut,false);
			if (!succ) {

				showTimeOut();
				close();
			} 
        }
        catch (Exception e) {
            //连接失败 打印异常
            Debug.Log("socket connect error: "+e.Message);

        }
    }
	public void reConnect()
	{
		Debug.LogError ("reConnect");
		try
		{
			reConnectTimes++;
			if(reConnectTimes > maxReConnectTimes) //重连三次失败就退出
			{
				needExit = true;
				return;
			}
			//创建socket连接对象
			socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			//连接到服务器
			//            socket.Connect(host, port);
			
			//服务器IP地址
			IPAddress ipAddress = IPAddress.Parse (host);
			//这是一个异步的建立连接，当连接建立成功时调用connectCallback方法
			IAsyncResult result = socket.BeginConnect (ipAddress, port, new AsyncCallback (reConnectCallback), socket);
			
			//超时
			bool succ = result.AsyncWaitHandle.WaitOne (timeOut,false);
			if (!succ) {
				
				showTimeOut();//
				close();
			} 
		}
		catch (Exception e) {
			//连接失败 打印异常
			Debug.Log("socket connect error: "+e.Message);
			
		}
	}
	public void close()
	{
		if(socket == null)
			return;

		socket.Close ();
	}
	/// 首次登录连接回调
	private void connectCallback (IAsyncResult asyncConnect)
	{
		Debug.Log("socket connect success!");
		bool connected = ((Socket)asyncConnect.AsyncState).Connected;
		if(connected)
		{
			socket.EndConnect (asyncConnect);
			//连接后开始从服务器读取网络消息
			socket.BeginReceive(readM, 0, ReciveBufferLength, SocketFlags.None, ReceiveCallBack,readM);
		}
		else 
		{
			needExit = true;
		}

	}
	/// 重连回调
	private void reConnectCallback (IAsyncResult asyncConnect)
	{
		bool connected = ((Socket)asyncConnect.AsyncState).Connected;
		if(connected)
		{
			reConnectTimes = 0;

			sendReconnectMsg = true;
			socket.EndConnect (asyncConnect);
			//连接后开始从服务器读取网络消息
			socket.BeginReceive(readM, 0, ReciveBufferLength, SocketFlags.None, ReceiveCallBack,readM);
		}
//		else 
//		{
//			needExit = true;
//		}
	}
	public void sendMessage<T>(int messageID, T msg) where T : class
		{
		if (!MonoInstancePool.getInstance<UserData>().getConnectNetWork ()) 
		{
			return;
		}
		if (!socket.Connected)
			return;
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
			var res = socket.Send(arr.Buffer);
			Debug.Log("sendRes " + res);
		}
		catch(SocketException e)
		{
			Debug.LogError(" " + e.ErrorCode + " " + e.Message);
		}
		
	}
	public void readMessage(byte[] bytes)
	{
		//消息读取完成后开始解析 
		MemoryStream ms = new MemoryStream(bytes, 0, bytes.Length);
		ByteArray arr = new ByteArray(ms);
//        Debug.Log("read message!");
		while (arr.Postion < bytes.Length) 
		{
			int messageLength = arr.ReadInt ();
			if((arr.Postion + messageLength - 4 + MsgHeadSize) > bytes.Length)
			{
				int lastCount = arr.Length - arr.Postion + 4;
				allCount -= lastCount;
				Middle = new Byte[lastCount];
				Buffer.BlockCopy(bytes,arr.Postion - 4,Middle,0,lastCount);
				break;
			}
			int messageID = arr.ReadInt ();
			//转换为Socket消息模型
			SocketModel model = new SocketModel ();
			model.bodyLength = messageLength;
			model.messageID = messageID;
			byte[] data = new byte[messageLength];
			arr.ReadBytes (data, 0, (uint)messageLength);
			model.message = data;
			messages.Add (model);
		}

	}
    //这是读取服务器消息的回调--当有消息过来的时候BgenReceive方法会回调此函数
    private void ReceiveCallBack(IAsyncResult ar)
    {
        int readCount = 0;
        try
        {
            //读取消息长度
            readCount = socket.EndReceive(ar);//调用这个函数来结束本次接收并返回接收到的数据长度。 
			byte[] bytes;
			if(Middle != null)
			{
				allCount += Middle.Length;
				readCount += Middle.Length;
				bytes = new byte[readCount];//创建长度对等的bytearray用于接收
				Buffer.BlockCopy(Middle, 0, bytes, 0, Middle.Length);//拷贝读取的消息到 消息接收数组
				Buffer.BlockCopy(readM, 0, bytes, Middle.Length, readCount - Middle.Length);//拷贝读取的消息到 消息接收数组
				Middle = null;
			}
			else 
			{
				bytes = new byte[readCount];//创建长度对等的bytearray用于接收
				Buffer.BlockCopy(readM, 0, bytes, 0, readCount);//拷贝读取的消息到 消息接收数组
			}
			readMessage(bytes);//消息读取完成
        }
        catch (SocketException)//出现Socket异常就关闭连接 
        {
			Debug.Log("close socket");

			startReconnectNow = true;
			socket.Close();//这个函数用来关闭客户端连接 
            return;
        }
		socket.BeginReceive(readM, 0, ReciveBufferLength, SocketFlags.None, ReceiveCallBack,readM);        
    }
	public void showTimeOut()
	{
		ErrorParse error = (ErrorParse)FindObjectOfType(typeof(ErrorParse));
		if(null != error)
		{
			error.showErrorWindow("无法连接服务器,麻烦检查下网络,然后从新登录!");
			error.timeOut = true;
		}
		UIManager manager = (UIManager)FindObjectOfType (typeof(UIManager));
		if(manager != null)
		{
			manager.hide("Processing");
		}
	}
    public List<SocketModel> getMessages() {
        return messages;
    }
	public long getNowTime()
	{
		DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0));
		DateTime nowTime = DateTime.Now;
		long unixTime = (long)Math.Round((nowTime - startTime).TotalMilliseconds, MidpointRounding.AwayFromZero);
		return unixTime;
	}
	//将主机顺序转换为网络顺序
	public static byte[] LittleToBig(string  str)
	{ return Encoding.BigEndianUnicode.GetBytes(str); }
	
	//将网络顺序转换为主机顺序
	public static string BigToLittle(byte[] bt, int index, int len)
	{ return Encoding.Unicode.GetString(bt, index, len); }
	
	//将从index个字节开始的bytes转换成32位有符号整型数 
	public static Int32 byteToint(byte[] bt, int index) 
	{    //将网络顺序先转换为主机顺序再输出为整型 
		string s; 
		s = BigToLittle(bt, index, 4); 
		return Convert.ToInt32(s); 
	} 
	
	//将从index个字节开始的bytes转换成16位有符号整型数 
	public static Int16 byteToshort(byte[] bt, int index) 
	{    //将网络顺序先转换为主机顺序再输出为整型 
		string s; 
		s = BigToLittle(bt, index, 2); 
		return (Int16)Convert.ToInt32(s); 
	}
	
	//将32位有符号整型数转化成bytes流
	public static byte[] intTobyte(int x)
	{   //转换为网络顺序输出
		string s;
		s = Convert.ToString(x);
		return LittleToBig(s);
	}
	
	//将16位有符号整型数转化成bytes流
	public static byte[] shortTobyte(short y)
	{   //转换为网络顺序输出
		string s;
		s = Convert.ToString(y);
		return LittleToBig(s);
	}
}
