using UnityEngine;
using System.Collections;
using LoginMessage;

public class LoginModuleMsg : MonoBehaviour {
	
	public int parse(SocketModel module)
	{
		switch(module.messageID)
		{
		case (int)LoginMessage.LOGIN_MSG_ID.ID_S2C_LOGIN:
			onLogin(module);
			break;
		case (int)LoginMessage.LOGIN_MSG_ID.ID_S2C_RECONNECT:
			onReconnect(module);
			break;
		default:
			return -1;
		}
		return 0;
	}
	public void onLogin(SocketModel module)
	{
		MsgLoginRep msg = MsgSerializer.Deserialize<MsgLoginRep>(module);
		int result = msg.result;
		if(result == (int)enResult.EN_SUCCEED)  //获取基础数据
		{
			MonoInstancePool.getInstance<SendUserDataMsgHander>().SendGetPlayerBaseReq();
			//心跳定时
			InvokeRepeating ("sendHeartBeatMsg", 2f, GlobalDef.SEND_HEARTBEAT_TIME);
		}
		else if(result == (int)enResult.EN_ERROR)
		{
			reLogin();
		}

	}
	public void onReconnect(SocketModel module)
	{
		MsgReconnectRep msg = MsgSerializer.Deserialize<MsgReconnectRep>(module);

		int result = msg.result;
		if(result == (int)enResult.EN_SUCCEED)  //获取基础数据
		{
			//reset time
			MonoInstancePool.getInstance<UserData> ().heartBeatTime = 0;
			//心跳定时
			InvokeRepeating ("sendHeartBeatMsg", 0f, GlobalDef.SEND_HEARTBEAT_TIME);
		}
		else if(result == (int)enResult.EN_ERROR)
		{
			reLogin();
		}

		UIManager manager = (UIManager)FindObjectOfType (typeof(UIManager));
		if(manager != null)
		{
			manager.hide("Processing");
		}
	}
	
	//心跳消息  
	void sendHeartBeatMsg()
	{
		long time = MonoInstancePool.getInstance<UserData> ().heartBeatTime;
		long now = MonoInstancePool.getInstance<NetWorkScript> ().getNowTime ();
		if(time == 0)
		{
			time = now;
			MonoInstancePool.getInstance<UserData> ().heartBeatTime = now;
		}

		long offset = (now - time)/1000;
		if(offset >= GlobalDef.MAX_DISCONNECT_TIME)
		{
			stopHeartBeat();

			MonoInstancePool.getInstance<NetWorkScript>().needReconnect = true;
//			UIManager manager = (UIManager)FindObjectOfType(typeof(UIManager));
//			if(manager != null)
//			{
//				manager.show("Reconnect");
//			}
//			ReconnectWindow window = (ReconnectWindow)FindObjectOfType(typeof(ReconnectWindow));
//			if(null != window)
//			{
//				window.reconnect = true;
//				window.showErrorWindow("网络状况不太好");
//			}
			return;
		}
		MonoInstancePool.getInstance<SendMessageHander> ().SendHeartBeat ();  //发送心跳消息
	}
	// 停止心跳计时
	public void stopHeartBeat()
	{
		CancelInvoke("sendHeartBeatMsg");
	}
	public void reLogin()
	{
		ErrorParse error = (ErrorParse)FindObjectOfType(typeof(ErrorParse));
		if(error != null)
		{
			error.showErrorWindow("您的账号在其它地点登录，请退出，然后从新登录");
			error.relogin = true;
		}
	}
}
