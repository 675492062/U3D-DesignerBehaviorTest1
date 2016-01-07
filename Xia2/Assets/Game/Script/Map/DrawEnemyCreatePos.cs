/****************************************************************************** 
 * 
 * Maintaince Logs: 
 * 2014-11-18   WP      Initial version: Added member
 * 
 * *****************************************************************************/

using UnityEngine;
using System.Collections;

public class DrawEnemyCreatePos : KMDrawRange
{
#if UNITY_EDITOR



    protected override void DrawByDrawType()
    {
        if (color != Color.red ||
        isSelectedDraw != false ||
        radius != LevelFlowExecutor.createRange ||
        dType != KMDrawRange.DrawType.WireCube)
        {
            color = Color.red;
            isSelectedDraw = false;
            radius = LevelFlowExecutor.createRange;
            dType = KMDrawRange.DrawType.WireCube;
        }

        base.DrawByDrawType();
    }

#endif
}
