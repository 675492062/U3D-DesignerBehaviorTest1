/****************************************************************************** 
 * 
 * Maintaince Logs: 
 * 2014-10-23   WP      Initial version
 * 
 * *****************************************************************************/

using UnityEngine;
using System.Collections;

/// <summary>
/// 用于所有的曹
/// </summary>
public class CommonSlot : MonoBehaviour
{

    public UILabel labName;
    public UILabel labNum;
    public UISprite sprIcon;
    public UILabel labLevel;

    public UISlider sldOther;
    public UILabel labOther;

    public void SetName(string name)
    {
        if (labName == null) return;
        if (name == null) labName.enabled = false;
        else
        {
            labName.text = name;
            labName.enabled = true;
        }

    }
    public void SetNum(string num)
    {
        if (labNum == null) return;
        if (num == null) labNum.enabled = false;
        else
        {
            labNum.text = num;
            labNum.enabled = true;
        }
    }
    public void SetIcon(string name , bool isSnap = false)
    {
        if (sprIcon == null) return;
        if (name == null) sprIcon.enabled = false;
        else
        {
            sprIcon.enabled = true;
            sprIcon.spriteName = name;
            if (isSnap) sprIcon.MakePixelPerfect();
        }
    }
    public void SetLevel(string text)
    {
        if (labLevel == null) return;
        if (text == null) labLevel.enabled = false;
        else
        {
            labLevel.text = text;
            labLevel.enabled = true;
        }
    }

    public void SetLabOther(string text)
    {
        if (labOther == null) return;
        if (text == null) labOther.enabled = false;
        else
        {
            labOther.enabled = true;
            labOther.text = text;
        }
    }

    public void SetSldOther(float percent)
    {
        if (sldOther == null) return;
        sldOther.value = percent;
    }

    
    public void SetNormal(string name, string num, string icon, string level)
    {
        SetName(name); SetNum(num); SetIcon(icon); SetLevel(level);
    }

    public void SetOther(string text, float percent) { SetLabOther(text); SetSldOther(percent); }
}
