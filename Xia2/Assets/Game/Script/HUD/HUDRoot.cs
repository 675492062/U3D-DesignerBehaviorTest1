/****************************************************************************** 
 * 
 * Maintaince Logs: 
 * 2014-10-30   WP      Initial version
 * 
 * *****************************************************************************/

using UnityEngine;
using System.Collections.Generic;

[ExecuteInEditMode]
/// <summary>
/// 用于Text的存放
/// </summary>
public class HUDRoot : MonoBehaviour
{
    /// <summary>
    /// Game camera to use.
    /// </summary>

    public Camera gameCamera;

    /// <summary>
    /// UI camera to use.
    /// </summary>

    public Camera uiCamera;

    [SerializeField]
    HUDText normalHarm;
    [SerializeField]
    HUDText critHarm;

    public static GameObject go;
    public static HUDRoot instance;

    private List<UIFollowTarget> followList = new List<UIFollowTarget>();

    void Awake() { go = gameObject; instance = this; }

    void Start()
    {
        if (gameCamera == null) gameCamera = Camera.main;
        if (uiCamera == null) uiCamera = UICamera.currentCamera;
        if (normalHarm == null)
        {
            foreach (Transform t in transform) { if (t.name == "HUDNormal") { normalHarm = t.GetComponent<HUDText>(); break; } }
        }
        if (critHarm == null)
        {
            foreach (Transform t in transform) { if (t.name == "HUDCrit") { critHarm = t.GetComponent<HUDText>(); break; } }
        }
    }

    public Vector3 GamePosConvertUIPos(Vector3 pos)
    {
        Vector3 uiPos = gameCamera.WorldToViewportPoint(pos);
        //Debug.Log("pos is " + pos + "    view pos : " + uiPos);


        uiPos = uiCamera.ViewportToWorldPoint(uiPos);

        //Debug.Log( "   ui  pos : " + uiPos);
        //uiPos.x = Mathf.FloorToInt(pos.x);
        //uiPos.y = Mathf.FloorToInt(pos.y);
        uiPos.z = 0f;

        return uiPos;
    }

    public static void AddNormalHarm(string harm, Vector3 pos)
    {
        if (instance)
            instance.normalHarm.Add(harm, pos);
    }

    public static void AddCritHarm(string harm, Vector3 pos)
    {
        if (instance) instance.critHarm.Add(harm, pos);
    }

    public static HUDText AddNormalHarmNFollow(Transform target)
    {
        if (instance)
        {
            UIFollowTarget follow = GetFollow(target);

            HUDText hud = KMTools.AddChild<HUDText>(follow.gameObject, instance.normalHarm);
            return hud;
        }
        return null;
    }

    public static HUDText AddCritHarmNFollow(Transform target)
    {
        if (instance)
        {
            UIFollowTarget follow = GetFollow(target);

            HUDText hud = KMTools.AddChild<HUDText>(follow.gameObject, instance.critHarm);
            return hud;
        }
        return null;
    }

    public static UIFollowTarget GetFollow(Transform target)
    {
        UIFollowTarget follow = null;
        if (instance)
        {
            for (int i = 0; i < instance.followList.Count; )
            {
                if (instance.followList[i] == null)
                {
                    instance.followList.RemoveAt(i);
                    continue;
                }
                else if (instance.followList[i].target == target)
                {
                    follow = instance.followList[i];
                    break;
                }
                i++;
            }
        }

        if (follow == null)
        {
            follow = KMTools.AddGameObj(instance.gameObject).AddComponent<UIFollowTarget>();
            follow.target = target;
            instance.followList.Add(follow);
        }

        return follow;
    }
}
