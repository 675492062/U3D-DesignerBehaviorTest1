/****************************************************************************** 
 * 
 * Maintaince Logs: 
 * 2014-10-10   WP      Initial version: Added member
 * 2014-11-13   WP      Fixed Method params
 * 2014-11-26   WP      Added debug mode 
 * 
 * *****************************************************************************/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//[ExecuteInEditMode]
/// <summary>
/// 用于管理一个关卡的进度
/// </summary>
public partial class LevelFlowCtrl : MonoBehaviour
{
    const string STR_SENDMSG_HEAD = "SendMsg";

    private static LevelFlowCtrl mInstance;
    public static LevelFlowCtrl instance
    {
        get
        {
            if (mInstance == null)
            {
                mInstance = GameObject.FindObjectOfType(typeof(LevelFlowCtrl)) as LevelFlowCtrl;
                if (mInstance == null)
                {
                    GameObject go = new GameObject("LevelFlowCtrl");
                    mInstance = go.AddComponent<LevelFlowCtrl>();
                }
            }
            return mInstance;
        }
    }

    #region dynamic rember

    private Object mConfig;
    public Object prbLevelConfig
    {
        get
        {
            if (mConfig == null)
            {

                mConfig = Resources.Load(AllStrings.PATH_LEVEL_CONFIG + AllStrings.FILE_HEAD_CONFIG + LevelData.curConfigID);
            }
            return mConfig;
        }
    }

    private Object mMapRes;
    public Object prbLevelRes
    {
        get
        {
            if (mMapRes == null)
            {
                mMapRes = Resources.Load(AllStrings.PATH_MAP_RES + StaticDungeon.Instance().getStr(LevelData.curDungeonId, "resname"));
            }
            return mMapRes;
        }
    }

    private Object mCameraPath;
    public Object prbLevelCamera
    {
        get
        {
            if (mCameraPath == null) mCameraPath =
                 Resources.Load(AllStrings.PATH_LEVEL_CAMERA + AllStrings.FILE_HEAD_CAMERA + prbLevelRes.name);
            return mCameraPath;
        }
    }

    private LevelFlowExecutor mExecutor;
    public LevelFlowExecutor executor
    {
        get
        {
            if (mExecutor == null)
            {
                mExecutor = KMTools.AddGameObj(gameObject).AddComponent<LevelFlowExecutor>();
                mExecutor.name = "_Executor";
            }
            return mExecutor;
        }
    }

    #endregion

    #region init rember

    private List<LevelAction> actions;

    private int curActionIndex = 0;

    private LevelConfig curConfig;
    private LevelCamera curLevelCamera;

    //todo: the params count fix
    private struct CamParam
    {
        //public Vector3 pos;
        public Vector3 rot;
        public float field;
        public CamParam(Vector3 r, float f)
        {
            //pos = p;
            rot = r; field = f;
        }
    }

    public enum FlowType
    {
        PVE = 1,
        PVP = 8,
    }

    /// <summary>
    /// 关卡类型
    /// </summary>
    private FlowType flowType = FlowType.PVE;

    private CamParam camParam;

    #endregion

    [SerializeField]
    private Camera heroCamera;

    [SerializeField]
    private bool isDebug = false;

    [SerializeField]
    private bool isDebugPvp = true;

    /// <summary>
    /// 等待外部事件触发：继续下一行动
    /// </summary>
    private bool isWaitExternal = false;

    /// <summary>
    /// 成功事件是否外部设置，此设置如果启用，关卡编辑器里面就算敌人死完，也不会触发胜利
    /// </summary>
    private bool isSetSuccess = false;

    /// <summary>
    /// 杀兵营条件:杀一个兵营这个值减少1.当为0的时候会触发成功事件。
    /// </summary>
    private int killBarracks = 0;

    /// <summary>
    /// 杀城门条件，杀一个城门这个值减少1.当为0的时候会触发成功事件。
    /// </summary>
    private int killGates = 0;

    private MyPlayer myPlayer { get { return ObjectManager.instance.myPlayer; } }

    private Player otherPlayer { get { return ObjectManager.instance.otherPlayer; } }

    #region instantiation

    void Awake()
    {
        if (!Application.isPlaying) return;

        if (isDebug)
        {
            return;
        }
        //level type to flow type
        flowType = (FlowType)LevelData.levelType;

        CreateRes();

    }

    //创建资源
    void CreateRes()
    {
        camParam = new CamParam(new Vector3(50, 0, 0), heroCamera.fieldOfView);

        //level resources
        GameObject go = (GameObject)Instantiate(prbLevelRes);
        go.transform.parent = transform;

        //level config
        go = (GameObject)Instantiate(prbLevelConfig, Vector3.zero, Quaternion.identity);
        curConfig = go.GetComponent<LevelConfig>();
        go.transform.parent = transform;

        if (prbLevelCamera)
        {
            //level camera path animation
            go = (GameObject)Instantiate(prbLevelCamera);

            curLevelCamera = go.GetComponent<LevelCamera>();
            go.transform.parent = transform;
        }

        //开始
        StartCoroutine(Init());
        InitRes();
    }

    bool isInit = false;
    void InitRes()
    {
        actions = curConfig.actions;

        Debug.Log("init finish ===================");
        //set camera position and rotation
        if (curLevelCamera && curLevelCamera.open.Count > 0)
        {
            CameraPathBezierAnimator cp = curLevelCamera.open[0];
            heroCamera.transform.position = cp._bezier.GetPoints()[0].transform.position;
            heroCamera.transform.rotation = cp._bezier.GetPoints()[0].transform.rotation;
        }

        isInit = true;
    }

    void Start() { if (!heroCamera) heroCamera = Camera.main; }

    public IEnumerator Init()
    {
        #region debug
        if (isDebug)
        {
            // record params of camera
            camParam = new CamParam(new Vector3(50, 0, 0), heroCamera.fieldOfView);
            curConfig = GameObject.FindObjectOfType(typeof(LevelConfig)) as LevelConfig;
            curLevelCamera = GameObject.FindObjectOfType(typeof(LevelCamera)) as LevelCamera;

            InitRes();

            if (isDebugPvp)
            {
                flowType = FlowType.PVP;
                LevelData.levelType = 8;
            }
        }
        #endregion

        curConfig.Init();

        while (!isInit) yield return null;

        //my heros init :
        myPlayer.ExternalInit();

        switch (flowType)
        {
            case FlowType.PVP:
                InitPVP();
                break;
            default:
                InitPVE();
                break;
        }

        //顺计时开始
        StartCoroutine(BeginTimer());
        //默认计时显示
        UIBattleManager.instance.LoginCountUpTimer();
        InvokeRepeating("CountUpTimer", 0f, 1f);

        ExecuteAction();

        //Debug.Log(" wait time----------------------" + curLevelCamera.waitTimeToPlay);
        if (curLevelCamera)
        {
            if (curLevelCamera.waitTimeToPlay > 0)
                yield return new WaitForSeconds(curLevelCamera.waitTimeToPlay);

            if (curLevelCamera.open.Count > 0)
            {
                int endIndex = curLevelCamera.open.Count - 1;
                foreach (CameraPathBezierAnimator cpa in curLevelCamera.open)
                {
                    cpa.animationTarget = heroCamera.transform;
                }

                curLevelCamera.open[endIndex].AnimationFinished += CameraFinish;
                curLevelCamera.open[0].Play();
                Debug.Log("Camera Play --------------");
            }
            else CameraFinish();
        }
        else
        {
            Debug.Log("LevelCamera is Null --------------");
            CameraFinish();
        }
    }

    void CameraFinish()
    {
        Debug.Log("Camera Finish --------------");
        Camera.main.GetComponent<Ef_MotionBlurWeaken>().Stop();
        Camera.main.GetComponent<MotionBlur>().enabled = true;

        //TODO : EFFECT:
        heroCamera.transform.localEulerAngles = camParam.rot;
        heroCamera.fieldOfView = camParam.field;

        Camera.main.GetComponent<CamMove>().enabled = true;

        // enable to input of player
        UIBattleManager.instance.FightBegin();

        //start
        //
        if (flowType == FlowType.PVP) //enable to other player
            ObjectManager.instance.otherPlayer.StartAI();
    }

    void InitPVE()
    {
        //设置击杀兵营 or 城门胜利 or  城堡
        if (curConfig.barrackKills > 0 || curConfig.gateKills > 0 || curConfig.castles.Count > 0)
        {
            killGates = curConfig.gateKills;
            killBarracks = curConfig.barrackKills;
            isSetSuccess = true;
        }

        //Hero position:
        if (otherPlayer) otherPlayer.gameObject.SetActive(false);
        if (myPlayer) myPlayer.Begin(100, curConfig.heroStartPos.position);
        else Debug.Log("Error-------------");

        //关卡成就（评星） 实例
        LevelAchievemCtrl.instance.Init();

    }

    void InitPVP()
    {
        //Debug.Log("InvokePvP  --------------", gameObject);
        if (otherPlayer)
        {
            otherPlayer.externalInit();
            otherPlayer.Begin(-100, curConfig.enemyPos[0].position);
        }
        else Debug.Log("Error-------------");
        if (myPlayer) myPlayer.Begin(100, curConfig.heroStartPos.position);
        else Debug.Log("Error-------------");
        //Debug.Log(curConfig.enemyPos[0].position, curConfig.enemyPos[0]);
        isSetSuccess = true;
    }

    #endregion

    #region Method With out

    public bool ExternalContinue()
    {
        if (isWaitExternal)
        {
            Debug.Log(" ----------------------execute coutinue");
            isWaitExternal = false;
            ExecuteAction();
        }
        else
        {
            return false;
            Debug.Log(" Don't set external but is execute");
        }
        return true;
    }

    /// <summary>
    /// 成功事件，这事函数将会直接
    /// </summary>
    public void Success()
    {
        if (EventTimeByFinishedLevel != null)
            EventTimeByFinishedLevel(curTime);

        executor.Success();
        LevelFinish();
    }

    public void Failed()
    {
        executor.Failed();
        LevelFinish();
    }

    void LevelFinish()
    {
        isFinish = true;
        CancelInvoke("CountUpTimer");
        CancelInvoke("CountDownTimer");
    }

    #endregion

}