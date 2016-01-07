using UnityEngine;
using System.Collections;

public class HJinjieTableItem : MonoBehaviour
{

    public UIPlayTween playTwn;
    private bool isCollapse = true;

    public Transform sprCollapse;
    // Use this for initialization

    public void ToggleCollapse()
    {
        SetCollapse(isCollapse);
    }
    /// <summary>
    /// 设置折叠
    /// </summary>
    private void SetCollapse(bool isCollapse)
    {
        if (isCollapse)
        {
            //Debug.Log("open");
            //			EqptPnlHero.instance.CollapseHeros(this);
        }
        if (sprCollapse) sprCollapse.localEulerAngles = new Vector3(0, 0, isCollapse ? 90 : -90);
        //		playTwn.enabled = true;
        playTwn.Play(isCollapse);
        this.isCollapse = !isCollapse;
    }
}
