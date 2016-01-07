using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ProtoBuf;
using System.IO;
using ProtoBuf.Meta;
using FightMessage;

public class SendFightMsgHander : MonoBehaviour
{
    /// <summary>
    /// 战斗开始
    /// </summary>
    /// <param name="dungeon">副本ID</param>
    public void SendEnterFightReq(int dungeon)
    {
        MsgFightStartReq msg = new MsgFightStartReq();
        msg.dungeon = dungeon;
        MonoInstancePool.getInstance<NetWorkScript>().sendMessage((int)FIGHT_MSG_ID.ID_C2S_FIGHT_START, msg);
    }

    public void SendEnterFightReq(int chapterId, int dungeonId, int level)
    {
        MsgFightStartReq msg = new MsgFightStartReq();
        msg.Chaptered = chapterId;
        msg.dungeon = dungeonId;
        msg.type = (int)level;
        MonoInstancePool.getInstance<NetWorkScript>().sendMessage((int)FIGHT_MSG_ID.ID_C2S_FIGHT_START, msg);
    }

    public void SendFightEndReq(bool result, List<int> boxes)
    {
        //
        bool isDebug = true;
        if (isDebug) { Debug.Log(" battle end!----------"); }

        MsgFightEndReq msg = new MsgFightEndReq();
        msg.result = result;

        //成功专有数据
        if (result)
        {
            List<Skada> skadas = MonoInstancePool.getInstance<FightManager>().getKillerList();
            foreach (Skada skada in skadas)
            {
                msg.skada.Add(skada);

                if (isDebug)
                {
                    string debugStr = "{ count : " + skada.killer.Count;
                    foreach (Killer k in skada.killer)
                    {
                        debugStr += "  ---kill enemy: " + k.id + " --- num : " + k.number;
                    }
                    debugStr += " } ";
                    Debug.Log("hero id :" + skada.id + debugStr);
                }
            }
            if (boxes != null)
            {
                for (int i = 0; i < boxes.Count; i++)
                {
                    msg.box.Add(boxes[i]);
                }
            }
        }

        MonoInstancePool.getInstance<NetWorkScript>().sendMessage((int)FIGHT_MSG_ID.ID_C2S_FIGHT_END, msg);
    }

    public void SendAreanFightStartReq(int uid, int rankIndex)
    {
        MsgArenaFightStartReq msg = new MsgArenaFightStartReq();
        msg.uid = uid;
        msg.rank = rankIndex;
        MonoInstancePool.getInstance<NetWorkScript>().sendMessage((int)FIGHT_MSG_ID.ID_C2S_ARENA_FIGHT_START, msg);
    }

    /// <summary>
    /// 竞技C
    /// </summary>
    /// <param name="result"></param>
    public void SendAreanFightEndReq(bool result)
    {
        Debug.Log("Send message JJC Finish ------" + result);
        MsgArenaFightEndReq msg = new MsgArenaFightEndReq();
        msg.result = result;
        MonoInstancePool.getInstance<NetWorkScript>().sendMessage((int)FIGHT_MSG_ID.ID_C2S_ARENA_FIGHT_END, msg);
    }

}
