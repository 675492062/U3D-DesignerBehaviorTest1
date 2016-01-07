/****************************************************************************** 
 * 
 * Maintaince Logs: 
 * 2014-11-07   WP      Initial version
 * 
 * *****************************************************************************/

using UnityEngine;
using System.Collections;

/// <summary>
/// 货币面板显示
/// </summary>
public class UICurrencyManager : MonoBehaviour
{

    private static UICurrencyManager mInstance;
    public static UICurrencyManager instance
    {
        get
        {
            if (mInstance == null)
                mInstance = GameObject.FindObjectOfType(typeof(UICurrencyManager)) as UICurrencyManager;

            if (mInstance == null)
            {
				GameObject go = (GameObject)Instantiate(Resources.Load("Prefab/Common/pnl_Currency"));
                mInstance = go.GetComponent<UICurrencyManager>();
                UICamera c = GameObject.FindObjectOfType(typeof(UICamera)) as UICamera;

                //Debug.Log(mInstance.name, mInstance);
                mInstance.transform.parent = c.transform;
                mInstance.transform.localScale = Vector3.one;
                mInstance.anchor.enabled = true;
            }
            return mInstance;
        }
    }

    public UIAnchor anchor;

    private UIPanel mPnl;
	//隐藏显示 左边 右边
	public static GameObject right;

	public static void setRightVisible(bool show)
	{
		if (right == null)
			return;
		if (show)
			right.SetActive (true);
		else
			right.SetActive(false);
	}
    public static void Show(Transform parent, int depth = 10)
    {
        if (instance)
        {
            if (!instance.gameObject.activeSelf)
                instance.gameObject.SetActive(true);

            if (!instance.mPnl)
            {
                instance.mPnl = instance.gameObject.GetComponent<UIPanel>();
            }

            if (instance.mPnl)
            {
                instance.mPnl.depth = depth;
            }

            instance.gameObject.layer = parent.gameObject.layer;
            //instance.transform.parent = parent.parent;
            instance.transform.localPosition = Vector3.zero;
            instance.anchor.enabled = true;
        }

    }

    public static void Hide()
    {
        if (instance && instance.gameObject.activeSelf)
        {
            instance.gameObject.SetActive(false);
        }
    }
}
