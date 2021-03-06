using UnityEngine;
using System.Collections;

public class BomboEffect : MonoBehaviour
{
    public UISprite Level;        // 等级 D C B A S SS

    public UIPlayTween twnLevel;        // 数字效果
    public UIPlayTween TwnShadow;       // 效果虚影 added by wp

    public UIProgressBar Bar;     // 进度条
    public UISprite BarBackGround;//进度条背景
    public UISprite Star;         // 进度条上的星星
    public UILabel AddEffect;    // 增益效果Lable

    private ParticleSystem mPrbEffc;
    private ParticleSystem prbEffc
    {
        get
        {
            if (!mPrbEffc)
            {
                mPrbEffc = PrefabPool.prbUIEffComboC.GetComponent<ParticleSystem>();
            }
            return mPrbEffc;
        }
    }
    private ParticleSystem mPrbEffs;
    private ParticleSystem prbEffs
    {
        get
        {
            if (!mPrbEffs)
            {
                mPrbEffs = PrefabPool.prbUIEffComboS.GetComponent<ParticleSystem>();
            }
            return mPrbEffs;
        }
    }

    private ParticleSystem mEffc;
    public ParticleSystem effC
    {
        get
        {
            if (mEffc == null)
            {
                mEffc = KMTools.AddChild<ParticleSystem>(gameObject, prbEffc, true);
            }
            return mEffc;
        }
    }
    private ParticleSystem mEffs;
    public ParticleSystem effS
    {
        get
        {
            if (mEffs == null)
            {
                mEffs = KMTools.AddChild<ParticleSystem>(gameObject, prbEffs, true);
            }
            return mEffs;
        }
    }

    float barMaxNum = 100f;       //进度条最大数值
    float barCurNum = 0f;         //当前数值
    float intervalAttenuation = 0.05f; //衰减单位
    float tempCurTime = 0f;            //临时记录时间
    int startTemplateID = 880000;      //开始模板ID
    int startLevel = 1;                //起始连击等级
    int addEffect = 0;                 //增益效果数值
    float levelUPStopAttenuationTime;    //升级后停止衰减的等待时间
    float tempLevelUPStopAttenuationTime;//临时记录时间  
    bool StopAttenuationTime = false;  //停止衰减  
    //bool resetScale = false;           //重置缩放
    //float resetWaitTime = 0.2f;        //重置缩放等待时间
    float tempResetWaitTime = 0f;      //临时记录时间

    float hideTime = 1.0f;   //隐藏界面的时间
    float tempHideTime = 0f;

    float BombEffectTime = 10f;
    float tempBombEffectTime = 0f;
    bool startBombEffect = false;
    float timeParamByS = 0; //added by wp :重置S的时间参数

    // Use this for initialization
    void Start()
    {
        if (!prbEffc || !prbEffs) Debug.LogError("-------------ERROR");
        else
        {
            effC.gameObject.SetActive(false);
            effS.gameObject.SetActive(false);
        }
        init();
        updateLevelInfo(true);
    }
    public void init()
    {
        int vipLevel = MonoInstancePool.getInstance<UserData>().vipLevel;
        startLevel = StaticVip.Instance().getInt(vipLevel, "combo");
        barMaxNum = StaticCombo.Instance().getInt(startTemplateID + startLevel, "sum_combo");
        barCurNum = 0f;
        tempCurTime = 0f;
        tempLevelUPStopAttenuationTime = 0f;
        tempResetWaitTime = 0f;
        tempHideTime = 0f;
        updateProcessBar();
        updateLevelInfo(true);


    }
    // Update is called once per frame
    void Update()
    {
        //if(resetScale)
        //{
        //    tempResetWaitTime += Time.deltaTime;
        //    if(tempResetWaitTime >= resetWaitTime)
        //    {
        //        resetScale = false;
        //        tempResetWaitTime = 0f;
        //        Vector3 scale = Vector3.one;
        //        Debug.Log("---------is Reset");
        //        setLevelIcon(); 
        //        //TweenScale.Begin (Level.gameObject, resetWaitTime, scale);
        //    }
        //}
        bool isS = startLevel == (int)GlobalDef.BomboLevel.BOMBO_S;
        if (startBombEffect)
        {
            tempBombEffectTime += Time.deltaTime;
            if (tempBombEffectTime >= BombEffectTime)
            {
                tempBombEffectTime = 0f;
                startBombEffect = false;
                effC.Stop();
                effS.Stop();
                effC.gameObject.SetActive(false);
                effS.gameObject.SetActive(false);
                init();
                timeParamByS = 0;
                gameObject.SetActive(false);
                gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
            }
            //Debug.Log(" ----------------------------------hide");
            if (isS)
            {
                timeParamByS += Time.deltaTime * 0.1f;
                //Debug.Log("----------------------" + timeParamByS);
                Bar.value = Mathf.Lerp(1, 0, timeParamByS);
            }
            return;
        }



        if (StopAttenuationTime)
        {
            tempLevelUPStopAttenuationTime += Time.deltaTime;

            //Debug.Log("startLevel -----------------------------" + startLevel);

            if (tempLevelUPStopAttenuationTime >= levelUPStopAttenuationTime)
            {
                tempLevelUPStopAttenuationTime = 0f;
                StopAttenuationTime = false;

                if (isS) { return; }

                int nextLevel = startLevel - 1;
                if (nextLevel < (int)GlobalDef.BomboLevel.BOMBO_D) nextLevel = (int)GlobalDef.BomboLevel.BOMBO_D;
                barMaxNum = StaticCombo.Instance().getInt(startTemplateID + nextLevel, "sum_combo");

                if (startLevel <= (int)GlobalDef.BomboLevel.BOMBO_D)
                {
                    barCurNum = 0;
                }
                else
                {
                    barCurNum = barMaxNum;
                }
                startLevel--;
                updateLevelInfo(true);
            }
            return;
        }


        if (barCurNum <= 0 && startLevel == (int)GlobalDef.BomboLevel.BOMBO_D)
        {
            tempHideTime += Time.deltaTime;
            if (tempHideTime >= hideTime)
            {
                tempHideTime = 0f;
                this.gameObject.SetActive(false);
            }
            return;
        }
        tempCurTime += Time.deltaTime;
        if (tempCurTime >= intervalAttenuation)
        {
            tempCurTime = 0f;
            int num = StaticCombo.Instance().getInt(startTemplateID + startLevel, "damp");
            if (startLevel != (int)GlobalDef.BomboLevel.BOMBO_S)
                barCurNum -= num;
            if (barCurNum <= 0)
            {
                //停止衰减
                StopAttenuationTime = true;
                levelUPStopAttenuationTime = StaticCombo.Instance().getInt(startTemplateID + startLevel, "buffer");
            }

            updateProcessBar();
        }
    }

    public void addBomboNum()
    {
        if (startBombEffect)
        {
            return;
        }

        int num = StaticCombo.Instance().getInt(startTemplateID + startLevel, "per_combo");

        barCurNum += num;
        //升级
        if (barCurNum >= barMaxNum && startLevel < (int)GlobalDef.BomboLevel.BOMBO_S)
        {
            startLevel++;
            barCurNum -= barMaxNum;
            barMaxNum = StaticCombo.Instance().getInt(startTemplateID + startLevel, "sum_combo");
            runScaleAction();
            updateLevelInfo();
        }
        //满级
        else if (startLevel >= (int)GlobalDef.BomboLevel.BOMBO_S)
        {
            barCurNum = barMaxNum;
            startBombEffect = true;
            runScaleAction();

            //			TweenScale.Begin(gameObject, 0.5f, new Vector3(0.8f,0.8f,0.8f));
            gameObject.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        }
        updateProcessBar();


    }
    public void runScaleAction()
    {
        //Vector3 scale = transform.localScale;
        //scale *= 1.3f;
        //TweenScale.Begin (Level.gameObject, resetWaitTime, scale);

        //resetScale = true;
        // added by wp:
        twnLevel.Play(true);
        TwnShadow.Play(true);
        //Debug.Log("--------------play");
    }

    const string BOMB_D = "bs-16-9";
    const string BOMB_C = "bs-16-8";
    const string BOMB_B = "bs-16-7";
    const string BOMB_A = "bs-16-6";
    const string BOMB_S = "bs-16-10";

    public void setLevelIcon()
    {
        switch (startLevel)
        {
            case (int)GlobalDef.BomboLevel.BOMBO_D:
                Level.spriteName = BOMB_D;
                break;
            case (int)GlobalDef.BomboLevel.BOMBO_C:
                Level.spriteName = BOMB_C;
                break;
            case (int)GlobalDef.BomboLevel.BOMBO_B:
                Level.spriteName = BOMB_B;
                break;
            case (int)GlobalDef.BomboLevel.BOMBO_A:
                Level.spriteName = BOMB_A;
                break;
            case (int)GlobalDef.BomboLevel.BOMBO_S:
                Level.spriteName = BOMB_S;
                break;
            case (int)GlobalDef.BomboLevel.BOMBO_SS:
                break;
        }
    }

    public void updateLevelInfo(bool updateIcon = false)
    {
        if (updateIcon) setLevelIcon();

        //effect added by wp:
        if (startLevel > (int)GlobalDef.BomboLevel.BOMBO_D)
        {
            if (!effC.gameObject.activeSelf) effC.gameObject.SetActive(true);
            effC.Play();
            if (startLevel > (int)GlobalDef.BomboLevel.BOMBO_A)
            {
                //Debug.Log("S--------------------");
                if (!effS.gameObject.activeSelf) effS.gameObject.SetActive(true);
                effS.Play();
            }
            else effS.gameObject.SetActive(false);
        }
        else
        {
            //Debug.Log(" --------------------stop");
            effC.Stop();
            effS.Stop();
        }

        //Debug.Log("---------starLevel is " + startLevel);

        addEffect = StaticCombo.Instance().getInt(startTemplateID + startLevel, "buff");
        if (addEffect > 0)
        {
            AddEffect.gameObject.SetActive(true);
            AddEffect.text = "+" + addEffect + "%攻击";
        }
        else
        {
            AddEffect.gameObject.SetActive(false);
        }
    }
    public void updateProcessBar()
    {
        float percent = (float)barCurNum / (float)barMaxNum;
        if (percent >= 1)
        {
            percent = 1;
        }
        Bar.value = percent;
        //		Debug.Log ("percent " + percent);
        //update star position
        //int x = (int)(BarBackGround.width * percent);
        //Vector3 pos = Star.transform.localPosition;
        //pos.x = x;
        //Star.transform.localPosition = pos;
    }
}
