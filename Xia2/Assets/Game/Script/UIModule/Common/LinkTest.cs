using UnityEngine;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;
using System;


public class LinkTest : MonoBehaviour {
	public UISprite sprite;
    int fontHeight = 30;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

    public void loadText(string showText, int uid, string name, ulong guid)
    {
        UILabel label = GetComponentInChildren<UILabel>();
        //string showText = "我你好[ff0000][我你][-]程[ff0000][我你][-]序[ff0000][我你][-]好程[ff0000][我你][-]序我[ff0000][我你][-]你好程序我你好程序";
        label.text = showText;
        string temp = NGUIText.StripSymbols(showText);
        int w = 0;

		string[] arr = System.Text.RegularExpressions.Regex.Split(temp, @"(\Ψ.*?\])");
        DebugPrint("arr ", arr);

        Vector3 origin = new Vector3(0, 0, 0);
        origin.x -= label.width / 2;
        origin.y += label.height / 2;
        string str = "";
        int more_offset = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (i >= arr.Length - 2)
            {
                break;

            }

            UISprite sp = Instantiate(sprite) as UISprite;
            sp.transform.parent = this.transform;
            sp.transform.localScale = Vector3.one;

            str += arr[i];
            int width_offset = GetTextWidth(1, 1, label, str);

            i++;
            str += arr[i];
            Infomation info = sp.GetComponentInChildren<Infomation>();
            info.setWidth(GetTextWidth(1, 1, label, arr[i]));
            info.setHeight(fontHeight);
            info.uid = uid;
            info.name = name;
			info.guid = guid;
			if(arr.Length == 3){   //此时聊天记录中只有一个可点击对象
				if(String.IsNullOrEmpty(arr[0])){
					info.type = 0;   //此时是人名
				}else{
					if(arr[0].Contains(":")){
						info.type = 1;		//此时是道具
					}else{
						info.type = 0;   //此时是人名
					}
				}
			}
			if(arr.Length == 5){	//此时聊天记录中有两个可点击对象
				if(i == 1)
				{				
					if(arr[0].Contains(":")){
						info.type = 1;		//此时是道具
					}else{
						info.type = 0;   //此时是人名
					}
				}else if(i == 3){		//数组下标为3的对象为道具连接
					info.type = 1;
				}
			}
            Vector3 pos = origin;
            pos.x += sp.width / 2;
            pos.y -= sp.height / 2;

            pos.x += width_offset;

            pos.x += more_offset;
            while (true)
            {
                if (pos.x < label.lineWidth / 2 && (pos.x + sp.width) < label.lineWidth / 2)
                {
                    sp.transform.localPosition = pos;
                    break;
                }
                if (pos.x < label.lineWidth / 2 && (pos.x + sp.width) > label.lineWidth / 2)
                {
                    //					float c = GetTextWidth(1, 1, label, "[");
                    float more = pos.x + sp.width - label.lineWidth / 2;
                    sp.transform.localPosition = pos;
                    if (more <= 32)
                    {
                        more_offset += (int)more / 2;
                        break;
                    }
                    pos.x -= (int)more / 2;
                    info.setWidth(sp.width - (int)more);
                    more_offset += (int)more / 2;
                    //add new
                    UISprite new_sp = Instantiate(sprite) as UISprite;
                    new_sp.transform.parent = this.transform;
                    new_sp.transform.localScale = Vector3.one;

                    Infomation new_info = new_sp.GetComponentInChildren<Infomation>();
                    new_info.setWidth((int)more / 2);
                    new_info.setHeight(fontHeight);
                    Vector3 new_pos = pos;
                    new_pos.x = origin.x + new_sp.width / 2;
                    new_pos.y = pos.y - 20;
                    new_sp.transform.localPosition = new_pos;
                    break;
                }
                pos.x -= label.lineWidth;
                pos.y -= fontHeight;
                sp.transform.localPosition = pos;
            }
        }
    }

	public static string getFirstString(string stringToSub, int length) 
	{
		RegexOptions opt = (RegexOptions)8;
		Regex regex = new Regex("[\u4e00-\u9fa5]+", opt);
		char[] stringChar = stringToSub.ToCharArray();
		StringBuilder sb = new StringBuilder();
		int nLength = 0;
		bool isCut=false;
		for(int i = 0; i < stringChar.Length; i++) 
		{
			if (regex.IsMatch((stringChar[i]).ToString())) 
			{
				sb.Append(stringChar[i]);
				nLength += 2;
			}
			else 
			{
				sb.Append(stringChar[i]);
				nLength = nLength + 1;
			}
			
			if (nLength > length)
			{
				isCut=true;
				break;
			}
		}
		if(isCut)
			return sb.ToString()+"..";
		else
			return sb.ToString();
	}
	public static int getStringLength(string stringToSub) 
	{
		RegexOptions opt = (RegexOptions)8;
		Regex regex = new Regex("[\u4e00-\u9fa5]+", opt);
		char[] stringChar = stringToSub.ToCharArray();
		StringBuilder sb = new StringBuilder();
		int nLength = 0;
		bool isCut=false;
		for(int i = 0; i < stringChar.Length; i++) 
		{
			if (regex.IsMatch((stringChar[i]).ToString())) 
			{
				sb.Append(stringChar[i]);
				nLength += 2;
			}
			else 
			{
				sb.Append(stringChar[i]);
				nLength = nLength + 1;
			}
		}
		return nLength;
	}
	int GetTextWidth(int nowScaleX,int nowScaleY,UILabel label,string str)
	{
		float labelTextLength = 0;
		int labelCount = str.Length;
		float defaultSize = 27;
		for( int ii = 0 ; ii < labelCount; ii++ )
		{
			char c = str[ii];
			BMGlyph glyph = label.font.bmFont.GetGlyph(c);
			if( glyph != null)
			{
				float width = ((float)glyph.width*((float)label.fontSize/defaultSize));
				labelTextLength += width;
			}
		}
		return (int)labelTextLength;
	}
	void DebugPrint(string temp, string [] str)
	{
		for(int i = 0; i < str.Length; i++)
		{
			Debug.Log(temp + i + " " + str[i]);
		}
	}
}
