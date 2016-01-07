/****************************************************************************** 
 * 
 * Maintaince Logs: 
 * 2014-10-24   WP      Initial version
 * 
 * *****************************************************************************/

using UnityEngine;
using System.Collections;

public class SceneCtrl
{

    public static void ToScene(string sceneName)
    {
        Time.timeScale = 1;
        MonoInstancePool.getInstance<UserData>().redirectSceneName = sceneName;
        Application.LoadLevel("LoadingBar");
    }

    public static void ToMenu()
    {
        //TODO
		ToScene("DemoMainScene");
    }

    public static void ToGame()
    {
        ToScene("Game");
    }
	public static void ToLogin()
	{
		ToScene("Menu");
	}
}
