using UnityEngine;
using System.Collections;

/// <summary>
/// UI 指路标
/// 
/// Maintaince Logs: 
/// 2014-12-08  WP      Initial version
/// </summary>
public class UISign : MonoBehaviour
{
    private Transform mForm;
    /// <summary>
    /// 玩家的坐标
    /// </summary>
    private Transform form
    {
        get
        {
            if (mForm == null)
            {
                mForm = ObjectManager.instance.myPlayer.transform;
            }
            return mForm;
        }
    }

    /// <summary>
    /// 指向对象
    /// </summary>
    private Transform target;

    public GameObject showGo;

//    public UIFollow follow;

    public void Show(Transform t)
    {
//        follow.target = t;
        target = t;
        showGo.gameObject.SetActive(true);
    }

    public void Hide()
    {
        target = null;
        showGo.gameObject.SetActive(false);
    }

    void LateUpdate()
    {
        if (target && Camera.main)
        {
            Vector3 formPos = new Vector2(form.position.x, form.position.z);
            Vector2 toPos = new Vector2(target.position.x, target.position.z);

			//计算角度
            float angle = Angle(formPos, toPos);

			transform.localEulerAngles = new Vector3(0,0,angle);
        }
    }

    /// <summary>  
    /// 取两个向量之间的角度 与X轴  
    /// </summary>  
    /// <param name="pos1"></param>  
    /// <param name="pos2"></param>  
    /// <returns></returns>  
    static private float Angle(Vector2 pos1, Vector2 pos2)
    {
        //取两个向量相减  
        Vector2 from = pos2 - pos1;

        //X轴  
        Vector2 to = new Vector2(1, 0);

        //与X轴夹角  
        float result = Vector2.Angle(from, to);

        //向量的叉乘  
        Vector3 cross = Vector3.Cross(from, to);
        //如果超出360度  
        if (cross.z > 0)
        {
            //用360来减这个角度  
            result = 360f - result;
        }

        return result;
    }  

}
