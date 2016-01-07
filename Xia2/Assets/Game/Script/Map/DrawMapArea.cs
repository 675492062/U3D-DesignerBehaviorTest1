using UnityEngine;
using System.Collections;

/// <summary>
/// 画地图区域
/// 
/// Maintaince Logs:
/// 2014-12-16  WP      Initial version. 
/// </summary>
public class DrawMapArea : KMDrawRange
{
#if UNITY_EDITOR


    protected override void DrawByDrawType()
    {
        if (isSelectedDraw != false) isSelectedDraw = false;
        Gizmos.color = Color.yellow;
        Vector3 drawPos = GetComponent<Collider>().bounds.size;
        Vector3 pos = GetComponent<Collider>().bounds.center;
        drawPos.y += 1f;
        Gizmos.DrawWireCube(pos, drawPos);
    }
#endif


}
