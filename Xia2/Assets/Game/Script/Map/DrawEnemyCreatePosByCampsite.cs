/****************************************************************************** 
 * 
 * Maintaince Logs: 
 * 2014-11-18   WP      Initial version: Added member
 * 
 * *****************************************************************************/

using UnityEngine;
using System.Collections;

public class DrawEnemyCreatePosByCampsite : KMDrawRange
{
#if UNITY_EDITOR



    protected override void DrawByDrawType()
    {
        if (color != Color.red ||
        isSelectedDraw != false ||
        radius != .1f ||
        dType != KMDrawRange.DrawType.WireCube)
        {
            color = Color.red;
            isSelectedDraw = false;
            radius = 0.1f;
            dType = KMDrawRange.DrawType.WireSphere;
        }

        base.DrawByDrawType();
    }

#endif
}
