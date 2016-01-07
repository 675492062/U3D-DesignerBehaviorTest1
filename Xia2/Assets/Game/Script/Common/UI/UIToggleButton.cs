/****************************************************************************** 
 * 
 * Maintaince Logs: 
 * 2014-10-24   WP      Initial version
 * 
 * *****************************************************************************/

using UnityEngine;
using System.Collections;


public class UIToggleButton : MonoBehaviour
{
    public UISprite spr;

    public string key = "";

    public string nameOn;

    public string nameOff;

    private string curName;

    void OnEnable()
    {
        if (spr == null) return;
        if (!string.IsNullOrEmpty(key))
        {
            curName = PlayerPrefs.GetString(key, nameOn);
            spr.spriteName = curName;
        }
    }

    void OnClick()
    {
        if (spr == null) return;
        if (curName == nameOn)
        {
            curName = nameOff;
        }
        else
        {
            curName = nameOn;
        }
        spr.spriteName = curName;

        if (!string.IsNullOrEmpty(key))
        {
            PlayerPrefs.SetString(key, curName);
        }
    }
}
