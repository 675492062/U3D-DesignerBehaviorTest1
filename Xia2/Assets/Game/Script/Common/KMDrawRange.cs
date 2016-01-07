/******************************************************************************
 *
 * Maintaince Logs:
 * 2012-11-20   WP      Initial version. 
 *
 * *****************************************************************************/

using UnityEngine;
using System.Collections;
#if UNITY_EDITOR

using UnityEditor;
#endif


/// <summary>
/// 绘制一个范围到当前对象
/// </summary>
public class KMDrawRange : MonoBehaviour
{
#if UNITY_EDITOR

    public enum RefrenceTarget
    { 
        None,
        Scale,
        Collider,
    }

    public RefrenceTarget refrence = RefrenceTarget.None;

    public enum DrawType
    {
        WireSphere,
        Cube,
        Sphere,
        WireCube,

    }

    public DrawType dType = DrawType.WireSphere;

    public float radius = 2f;

    public Color color = Color.yellow;

    public bool isSelectedDraw = true;

    void Start() { }

    protected void OnDrawGizmos()
    {
        if (!isSelectedDraw)
        {
            Gizmos.color = color;
            DrawByDrawType();
        }
    }

    protected void OnDrawGizmosSelected()
    {
        if (isSelectedDraw)
        {
            Gizmos.color = color;
            DrawByDrawType();
        }
    }

    protected virtual void DrawByDrawType()
    {
        Vector3 pos = transform.position;
        pos.y += radius / 2;

        Vector3 drawPos = new Vector3(radius * 2, radius * 2, radius * 2);

        switch (refrence)
        { 
            case RefrenceTarget.Scale:
                drawPos = transform.lossyScale;
                radius = Mathf.Max(drawPos.x, drawPos.y, drawPos.z);
                pos = transform.position;
                break;
            case RefrenceTarget.Collider:
                if (GetComponent<Collider>())
                {
                    pos = GetComponent<Collider>().bounds.center;
                    drawPos = GetComponent<Collider>().bounds.size;
                }
                break;
        }

        switch (dType)
        {
            case DrawType.WireSphere:
                Gizmos.DrawWireSphere(pos, radius);
                break;
            case DrawType.Cube:
                Gizmos.DrawCube(pos, drawPos);
                break;
            case DrawType.Sphere:
                Gizmos.DrawSphere(pos, radius);
                break;
            case DrawType.WireCube:
                Gizmos.DrawWireCube(pos, drawPos);
                break;
        }

        Handles.color = color;
        Handles.Label(pos, name);
    }

#endif
}
