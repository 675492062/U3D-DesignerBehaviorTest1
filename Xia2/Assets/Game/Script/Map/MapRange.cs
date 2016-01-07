using UnityEngine;
using System.Collections;

/// <summary>
/// 地图区域绘制脚本
/// 
/// Maintaince Logs:
/// 2014-12-16  SQ      Initial version. 
///         16  WP      增加参数左右中心点功能
/// </summary>
[RequireComponent(typeof(BoxCollider))]
public class MapRange : MonoBehaviour
{

    const float charX = 0.25f;
    const float charUp = 0.32f;
    const float charDown = 0.08f;

    const float camX = 0.68f;
    const float camUp = 1.72f;
    const float camDown = 0.61f;

    public BoxCollider col
    {
        get
        {
            return GetComponent<Collider>() as BoxCollider;
        }
    }

    /// <summary>
    /// 区域左右中心点
    /// </summary>
    private float centerLR
    {
        get
        {
            return col.center.x + gameObject.transform.position.x;
        }
    }

    /// <summary>
    /// 区域上下中心点
    /// </summary>
    private float centerFB
    {
        get
        {
            return col.center.z + gameObject.transform.position.z;
        }
    }

    private float sizeLR
    {
        get
        {
            return col.size.x * transform.localScale.x / 2;
        }
    }

    private float sizeFB
    {
        get
        {
            return col.size.z * transform.localScale.z / 2;
        }
    }

    public void Init()
    {
        MyPlayer charMain = ObjectManager.instance.myPlayer;

        CamMove camMain = Camera.main.GetComponent<CamMove>();

        charMain.m_limit_x_l = -(sizeLR - charX) + centerLR;
        charMain.m_limit_x_r = sizeLR - charX + centerLR;
        charMain.m_limit_y_b = -sizeFB + centerFB + charDown;
        charMain.m_limit_y_f = sizeFB + centerFB - charUp;

        camMain.limit_x_l = -(sizeLR - camX) + centerLR;
        camMain.limit_x_r = sizeLR - camX + centerLR;
        camMain.limit_y_b = -sizeFB + centerFB - camDown;
        camMain.limit_y_f = sizeFB + centerFB - camUp;

        BoxCollider target = GameObject.Find("ground").GetComponent<Collider>() as BoxCollider;

        target.center = col.center;
        target.size = col.size;
        target.transform.position = transform.position;
        target.transform.localScale = transform.localScale;
    }

    public void Reset()
    {
        transform.position = new Vector3(0, -0.1f, 0);
        transform.localScale = new Vector3(4, 1, 4);
        col.size = new Vector3(1, .2f, 1);
        col.center = new Vector3(0, -0.1f, 0);
    }

    //public bool isUpdate = false;

    //void Update()
    //{
    //    if (isUpdate) { Awake(); isUpdate = false; }
    //}

    //protected void OnDrawGizmos()
    //{
    //    //player
    //    BoxCollider col = collider as BoxCollider;
    //    Vector3 center = gameObject.transform.position + col.center;
    //    Vector3 charSize = col.size;
    //    charSize.x -= charX;

    //    Gizmos.color = Color.red;

    //    Gizmos.DrawWireCube(center, charSize);

    //    //

    //}
}
