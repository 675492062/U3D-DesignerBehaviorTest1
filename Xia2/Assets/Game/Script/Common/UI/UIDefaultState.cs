/****************************************************************************** 
 * 
 * Maintaince Logs: 
 * 2014-11-10   WP      Initial version
 * 
 * *****************************************************************************/

using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
/// <summary>
/// 设置默认面板的专用
/// </summary>
public class UIDefaultState : MonoBehaviour
{

    private UIToggle mToggle;
    private UIToggledObjects mToggleObjects;
    private bool isStart = false;
    private UIButtonActivate mBtnActivate;

    private UIPlaySound mPlaySound;
    private float volume = 0;

    void Awake()
    {
        if (mToggle == null) mToggle = GetComponent<UIToggle>();
        if (mToggleObjects == null) mToggleObjects = GetComponent<UIToggledObjects>();
        if (mPlaySound == null) mPlaySound = GetComponent<UIPlaySound>();
        if (mBtnActivate == null) mBtnActivate = GetComponent<UIButtonActivate>();
    }

    void OnEnable()
    {
        if (!Application.isPlaying) return;

        if (mToggle)
        {
            if (isStart)
            {
                //if (mToggleObjects) mToggleObjects.Toggle();
                Invoke("InvokeDefault", 0.03f);
            }
            else
                isStart = true;
        }
        else if (mPlaySound)
        {
            volume = mPlaySound.volume;
            mPlaySound.volume = 0;
            gameObject.SendMessage("OnClick", SendMessageOptions.DontRequireReceiver);
            Invoke("InvokeRevert", 0.1f);
        }
    }

    void InvokeDefault()
    {
        if (mBtnActivate) NGUITools.SetActive(mBtnActivate.target, mBtnActivate.state);
        mToggle.value = true;
    }

    void InvokeRevert()
    {
        mPlaySound.volume = volume;
    }
}
