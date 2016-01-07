using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;

[System.Serializable]
public class serverInfo
{
    public serverInfo() { }
    public string serverName = "";
    public string serverHost = "";
    public string serverPort = "";
    public string serverStatus = "";
}

public class noticeInfo
{
    public noticeInfo() { }
    public string time { get; set; }
    public string title { get; set; }
    public int image { get; set; }
    public string notice { get; set; }
}
//体力属性
public struct StaminaInfo{

	public float durationTime;					
	
	public int boughtCount;						//已经购买的次数    
	
	public int boughtCountLimit;				//可以购买次数上限   vip
	
	public int maxLimit;						//上限			  lv
	
	public int price{get{return StaticTime_price.Instance().getInt(boughtCount , "energy");}}
}
//金币属性
public struct GoldInfo{
	public int boughtCount;						//已经购买的次数   
	
	public int price{get{return StaticTime_price.Instance().getInt(boughtCount , "money");}}
}

public class UserData : MonoBehaviour
{
    public bool exit = false;
    public long guid { get; set; }
    public string userName { get; set; }
    public string passWord { get; set; }
    public string token { get; set; }
    public int vipLevel { get; set; }
    public int vipExp { get; set; }
    //战队属性
    public int headID { get; set; }
    public int imageID { get; set; }
    public string teamName { get; set; }
    public int level { get; set; }
    public int exp { get; set; }

    public int expFull { get { return StaticLead_level.Instance().getInt(level, "exp"); } } //到下一级经验

    public long fighting { get; set; }
    public int gold { get; set; }
    public int diamond { get; set; }
    public int soulPoint { get; set; }  // 灵魂点  升级境界所需要的
    public int stamina { get; set; }
	public StaminaInfo staminaInfo = new StaminaInfo();			//体力属性
	public GoldInfo goldInfo = new GoldInfo();
	public long lastChageStaminaTime { get; set; }

    public int todayShopRefreshCount { get; set; }

    public Vector3 initPos { get; set; }
    public int selectedServerIdx { get; set; }
    public bool localOrNetWork { get; set; }
    public int chat_channel { get; set; }
    public string image { get; set; }
    public string redirectSceneName { get; set; }

    public bool stroyPlayed { get; set; }

    public List<GameObject> notice = new List<GameObject>();
    public List<serverInfo> serverList = new List<serverInfo>();
    public List<noticeInfo> noticeList = new List<noticeInfo>();
    public List<GameObject> serverObject = new List<GameObject>();
    public List<GameObject> TeamImageObject = new List<GameObject>();
    public List<GameObject> TeamHeroObject = new List<GameObject>();
    //chat
    public List<string> chatCache = new List<string>();

	public long heartBeatTime = 0;

    public UserData()
    {
        userName = "bbbb";
        passWord = "";
        guid = 0;
        token = "";
        selectedServerIdx = 0;
        localOrNetWork = false;
        image = "1";
        headID = 0;
        imageID = 1;
        teamName = "";
        level = 1;
        exp = 0;
        gold = 10000;
        stroyPlayed = true;

    }
    public void addServerListData(JSONArray infoArr)
    {
        if (infoArr == null)
        {
            return;
        }
        serverList.Clear();

        for (int i = 0; i < infoArr.Count; i++)
        {
            string serverName = infoArr[i]["serverName"].ToString();
            string serverHost = infoArr[i]["serverHost"].ToString();
            string serverPort = infoArr[i]["serverPort"].ToString();
            string serverStatus = infoArr[i]["serverStatus"].ToString();

            serverInfo info = new serverInfo();

            info.serverName = serverName;
            info.serverHost = serverHost;
            info.serverPort = serverPort;
            info.serverStatus = serverStatus;

            serverList.Add(info);
        }
    }
    public List<serverInfo> getServerList() { return serverList; }

    public void addNoticeListData(JSONArray infoArr)
    {
        //        if (!infoArr.IsArray)
        //        {
        //            return;
        //        }
        noticeList.Clear();

        for (int i = 0; i < infoArr.Count; i++)
        {
            string time = infoArr[i]["time"].ToString();
            string title = infoArr[i]["title"].ToString();
            int image = System.Int32.Parse(infoArr[i]["image"].ToString());
            string notice = infoArr[i]["notice"].ToString();

            noticeInfo info = new noticeInfo();

            info.time = time;
            info.title = title;
            info.image = image;
            info.notice = notice;

            noticeList.Add(info);
        }
    }
    public List<noticeInfo> getNoticeList() { return noticeList; }

    public serverInfo getCurSelectedServer()
    {
        if (serverList.Count > selectedServerIdx)
        {
            return serverList[selectedServerIdx];
        }
        return null;
    }

    public void setServerIdx(int idx)
    {
        selectedServerIdx = idx;
        serverInfo info = getCurSelectedServer();

        if (info != null)
        {
            MonoInstancePool.getInstance<NetWorkScript>().host = info.serverHost;
            MonoInstancePool.getInstance<NetWorkScript>().port = System.Int32.Parse(info.serverPort);
        }
    }

    public void setInitPosition(Vector3 pos)
    {
        initPos = pos;
    }

    public void setConnectNetWork(bool c)
    {
        localOrNetWork = c;
    }

    public bool getConnectNetWork()
    {
        return localOrNetWork;
    }

    public void addChatCache(string msg)
    {
        chatCache.Add(msg);
    }

    public List<string> getChatCacheList()
    {
        return chatCache;
    }

    public void setImage(string image)
    {
        this.image = image;
    }

    public string getImage()
    {
        return image;
    }

    public void setNotice(GameObject obj)
    {
        this.notice.Add(obj);
    }

    public List<GameObject> getNotice()
    {
        return this.notice;
    }

    public void addMoney(int type, int value)
    {
        switch (type)
        {
            case (int)GlobalDef.MoneyType.MONEY_GOLD:
                gold += value;
                break;
            default:
                Debug.Log("Have not this money! type: " + type);
                break;
        }
    }

    public void subMoney(int type, int value)
    {
        switch (type)
        {
            case (int)GlobalDef.MoneyType.MONEY_GOLD:
                gold -= value;
                if (gold <= 0)
                {
                    gold = 0;
                }
                break;
            case (int)GlobalDef.MoneyType.MONEY_DIAMOND:
                diamond -= value;
                if (diamond <= 0) diamond = 0;
                break;
            default:
                Debug.Log("Have not this money! type: " + type);
                break;
        }
    }

    public int getMoney(int type)
    {
        switch (type)
        {
            case (int)GlobalDef.MoneyType.MONEY_GOLD:     //
                return gold;

            case (int)GlobalDef.MoneyType.MONEY_DIAMOND:  //宝石
                return diamond;

            case (int)GlobalDef.MoneyType.MONEY_SOULSTONE://魂石
                return soulPoint;

            default:
                Debug.Log("Have not this money! type: " + type);
                break;
        }
        return 0;
    }

    public void ChangeScene(string sceneName)
    {
        //		if(string.Compare(Application.loadedLevelName,sceneName) == 0)
        //		{
        //			return;
        //		}
        redirectSceneName = sceneName;
        Application.LoadLevel("LoadingBar");
    }

    public float getPercentByEXP()
    {
        int max = expFull;
        return exp * 1.0f / max;
    }
    
    //lv or vip change ,the stamina info will change
    public void UpdateStaminaInfo(){
   	 //test
		staminaInfo.maxLimit = StaticLead_level.Instance().getInt(level , "max_energy");
		staminaInfo.boughtCountLimit = StaticVip.Instance().getInt(vipLevel , "buy_stamina_num");
    }
    
    void Update(){
    	if(stamina >= staminaInfo.maxLimit || staminaInfo.durationTime <= 0)return;
    	staminaInfo.durationTime -= Time.deltaTime;
    }
}

public static class LevelData
{
    static public int curChapterId = 350001;
    static public int curDungeonId = 360001;

    /// <summary>
    /// 关卡难度
    /// </summary>
    static public int levelDifficulty = 1;
    /// <summary>
    /// 难度配置表ID
    /// </summary>
    static public int curConfigID = 370501;
    /// <summary>
    /// 关卡类型
    /// </summary>
    static public int levelType = 1;

    

    static public void SetData(int chapterId, int dungeonId, int level)
    {
        curChapterId = chapterId;
        curDungeonId = dungeonId;
        levelDifficulty = level;

        curConfigID = StaticDungeon.Instance().getInt(curDungeonId, "tablefile" + (levelDifficulty));
        Debug.Log(" current ------------" + curConfigID + "    ---------curDungeonId : " + curDungeonId);
        levelType = StaticDungeon.Instance().getInt(curDungeonId, "type");
    }
}
