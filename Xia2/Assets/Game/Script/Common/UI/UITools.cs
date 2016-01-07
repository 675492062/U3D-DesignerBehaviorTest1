/****************************************************************************** 
 * 
 * Maintaince Logs: 
 * 2014-10-15   WP      Initial version
 * 
 * *****************************************************************************/

using UnityEngine;
using System.Collections;

public static class UITools
{
    static public string AddColorToText(Color color, string text)
    {
        string eText = "[";
        eText += NGUIText.EncodeColor(color);
        eText += "]" + text + "[-]";
        return eText;
    }
    
    static public string ColorTxt(string text , int r , int g ,int b ,int a){
		float t = 1f/255f;
		Color color = new Color(t * r ,t * g ,t * b , a * t);
		return AddColorToText(color , text);
    }
}