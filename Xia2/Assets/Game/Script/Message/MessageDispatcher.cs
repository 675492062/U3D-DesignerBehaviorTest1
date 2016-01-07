using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using ProtoBuf;
using System;
using System.Text;

[System.Serializable]
public class MessageDispatcher : MonoBehaviour
{

    void Awake()
    {
        Application.targetFrameRate = 60;
        //test
        DontDestroyOnLoad(this.gameObject);
        //		MonoInstancePool.getInstance<UserData>().setConnectNetWork (false);

    }

    void Update()
    {
        //每帧判断消息队列是否有消息
        List<SocketModel> messages =
            MonoInstancePool.getInstance<NetWorkScript>().getMessages();
        //Debug.Log(messages.Count);

        if (messages.Count > 0)
        {
            //队列有消息的时候 循环读取消息进行处理 读取完当前消息后 清空消息队列 等待下帧的使用
            //Debug.Log("有消息");
            for (int i = 0; i < messages.Count; i++)
            {
                SocketModel model = messages[i];
                messages.Remove(messages[i]);
                Received(model);
            }
            GlobalDef.startReciveMsg = 0;
            GlobalDef.endParseAllMsg = 0;
        }
    }

    void OnApplicationQuit()
    {
        Debug.Log("应用退出");
        MonoInstancePool.destroy();
        MonoInstancePool.getInstance<NetWorkScript>().close();  //断开连接
    }

    //消息分派函数 有消息到达的时候 通过此函数判断消息类别分派到各自的模块
    public void Received(SocketModel model)
    {
        Debug.Log("recive msg id: " + model.messageID + " len " + model.message.Length);

        int moduleType = model.messageID / 10000;
        int res = -1;

        switch (moduleType)
        {
            case (int)Property.MSG_MODULE_TYPE.ENUM_MODULE_LOGIN:
                res = MonoInstancePool.getInstance<LoginModuleMsg>().parse(model);
                break;

            case (int)Property.MSG_MODULE_TYPE.ENUM_MODULE_DATA:
                res = MonoInstancePool.getInstance<UserDataModuleMsg>().parse(model);
                break;

            case (int)Property.MSG_MODULE_TYPE.ENUM_MODULE_NOTICE:
                res = MonoInstancePool.getInstance<NoticeModuleMsg>().parse(model);
                break;

            case (int)Property.MSG_MODULE_TYPE.ENUM_MODULE_ITEM:
                res = MonoInstancePool.getInstance<ItemSystemModuleMsg>().parse(model);
                break;

            case (int)Property.MSG_MODULE_TYPE.ENUM_MODULE_FRIEND:
                res = MonoInstancePool.getInstance<FriendModulMsg>().parse(model);
                break;

            case (int)Property.MSG_MODULE_TYPE.ENUM_MODULE_MAIL:
                res = MonoInstancePool.getInstance<NoticeModuleMsg>().parse(model);
                break;

            case (int)Property.MSG_MODULE_TYPE.ENUM_MODULE_TASK:
                res = MonoInstancePool.getInstance<TaskModuleMsg>().parse(model);
                break;

            case (int)Property.MSG_MODULE_TYPE.ENUM_MODULE_FIGHT:
                res = MonoInstancePool.getInstance<FightModuleMsg>().parse(model);
                break;
            //........
            default:
                switch (model.messageID)
                {
                    case (int)NoticeMessage.NOTICE_MSG_ID.ID_S2C_ERROR:
                        res = onError(model);
                        break;
                    case (int)NoticeMessage.NOTICE_MSG_ID.ID_S2C_HEARTBEAT:
                        res = onHeartBeatMsg(model);
                        break;
                }
                break;
        }
        if (res == -1)
        {
            string err_str = "没有被处理得消息:" + model.messageID;
            ErrorParse err = (ErrorParse)FindObjectOfType(typeof(ErrorParse));
            if (err != null)
            {
                err.showErrorWindow();
                err.setErrorText(err_str);
            }
        }

    }

    public int onError(SocketModel model)
    {
        NoticeMessage.MsgErrorCode msg = MsgSerializer.Deserialize<NoticeMessage.MsgErrorCode>(model);
        int errorCode = msg.errorCode;
        string err_str = StaticError.Instance().getStr(errorCode, "text");
        ErrorParse err = (ErrorParse)FindObjectOfType(typeof(ErrorParse));
        if (err != null)
        {
            err.showErrorWindow();
            string str_err = errorCode.ToString() + err_str;
            err.setErrorText(str_err);
        }
        return 0;
    }

    public int onHeartBeatMsg(SocketModel module)
    {
        long now = MonoInstancePool.getInstance<NetWorkScript>().getNowTime();
        MonoInstancePool.getInstance<UserData>().heartBeatTime = now;
        return 0;
    }

    public long getNowTime()
    {
        DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0));
        DateTime nowTime = DateTime.Now;
        long unixTime = (long)Math.Round((nowTime - startTime).TotalMilliseconds, MidpointRounding.AwayFromZero);
        return unixTime;
    }
}
