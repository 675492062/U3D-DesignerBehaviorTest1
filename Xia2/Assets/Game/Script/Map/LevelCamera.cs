/****************************************************************************** 
 * 
 * Maintaince Logs: 
 * 2014-21-11   WP      Initial version: Added member
 * 
 * *****************************************************************************/

using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Camera Path parnet
/// </summary>
public class LevelCamera : MonoBehaviour
{
    const string opParnetName = "open_Anims";
    const string edParnetName = "end_Anims";

    public float waitTimeToPlay = .5f;

    private Transform mOpParnet;
    private Transform opParnet
    {
        get
        {
            if (mOpParnet == null)
            {
                mOpParnet = transform.FindChild(opParnetName);
                if (mOpParnet == null)
                {
                    mOpParnet = KMTools.AddGameObj(gameObject).transform;
                    mOpParnet.name = opParnetName;
                }
            }
            return mOpParnet;
        }
    }
    private List<CameraPathBezierAnimator> mOP = new List<CameraPathBezierAnimator>();
    public List<CameraPathBezierAnimator> open
    {
        get
        {
            if (mOP.Count != opParnet.childCount)
            {
                mOP.Clear();
                CameraPathBezierAnimator cpa;
                int i = 1;
                foreach (Transform t in opParnet)
                {
                    cpa = t.GetComponent<CameraPathBezierAnimator>();
                    t.name = "CameraPath_" + i;
                    if (cpa)
                    {
                        mOP.Add(cpa);
                    }
                    else
                    {
                        Debug.Log(" Destory object ", t.gameObject);
                        //DestroyImmediate(t.gameObject);
                    }
                    i++;
                }
                SetAnims(mOP);
            }
            return mOP;
        }
    }

    private Transform mEdParnet;
    private Transform edParnet
    {
        get
        {
            if (mEdParnet == null)
            {
                mEdParnet = transform.FindChild(edParnetName);
                if (mEdParnet == null)
                {
                    mEdParnet = KMTools.AddGameObj(gameObject).transform;
                    mEdParnet.name = edParnetName;
                }
            }
            return mEdParnet;
        }
    }
    private List<CameraPathBezierAnimator> mNd = new List<CameraPathBezierAnimator>();
    public List<CameraPathBezierAnimator> end
    {
        get
        {
            if (mNd.Count != edParnet.childCount)
            {
                mNd.Clear();
                CameraPathBezierAnimator cpa;
                int i = 1;
                foreach (Transform t in edParnet)
                {
                    cpa = t.GetComponent<CameraPathBezierAnimator>();
                    t.name = "CameraPath_" + i;
                    if (cpa)
                    {
                        mNd.Add(cpa);
                    }
                    else
                    {
                        Debug.Log(" Destory object ", t.gameObject);
                        //DestroyImmediate(t.gameObject);
                    }
                    i++;
                }
                SetAnims(mNd);
            }
            return mNd;
        }
    }
	
	
	private void SetAnims(List<CameraPathBezierAnimator> anims)
	{
		for (int i = 0; i < anims.Count; i++)
		{
			if (i == anims.Count - 1) return;
			//if (anims[i].cameraPath.nextPath == null)
			{
				anims[i].nextAnimation = anims[i + 1];
			}
		}
	}


#if UNITY_EDITOR

    private Object mModelCameraAnim;
    private Object prbModelCameraAnim
    {
        get
        {
            if (mModelCameraAnim == null) mModelCameraAnim = Resources.Load(AllStrings.PATH_LEVEL_CAMERA + "Model");
            return mModelCameraAnim;
        }
    }

    public void AddOPAnim()
    {
        AddAnim(opParnet);
    }

    public void AddEDAnim()
    {
        AddAnim(edParnet);
    }

    private void AddAnim(Transform parent)
    {
        GameObject go = KMTools.AddGameObj(parent.gameObject, prbModelCameraAnim as GameObject, false);
        CameraPathBezierAnimator cpa = go.GetComponent<CameraPathBezierAnimator>();
        if (cpa)
        {
            //Debug.Log("---------------", LevelFlowCtrl.instance);
            Camera c = LevelFlowCtrl.instance.GetCamera();
            if (c)
            {
                cpa.animationTarget = c.transform;
            }
            else
            {
                Debug.Log("Fuck ---------------");
            }
        }
        go.name = "CameraPath_" + edParnet.childCount;
    }

#endif
}
