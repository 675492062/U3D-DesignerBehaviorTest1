using UnityEngine;
using System.Collections;

/// <summary>
/// 进入竞技场的测试通道
/// 
/// Maintaince Logs: 
/// 2014-11-26   WP      Initial version.
/// 
/// </summary>
public class BtnToJJC : MonoBehaviour
{

    void OnClick()
    {
        LevelData.SetData(360000, 400000, 1);

        SceneCtrl.ToGame();
    }
}
