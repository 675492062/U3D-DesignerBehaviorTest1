using UnityEngine;
using System;
using System.Text;
using System.IO;
using System.Collections;
using System.Security.Cryptography;


public static class Crypto  
{
	static string KEY = "anjueolh";
	static string IV = "45287112549354892144548565456541";
	static string deviceid  ="abcdefgh";
	//public static short islogin = 0;
	public static long memberNo  = 0;
	public static string usimsIndex ="CT";
	public static int telecomPayCode = 0;
	
	//public string message;
	
	// Use this for initialization
	public static void Init () 
	{
		deviceid  = SystemInfo.deviceUniqueIdentifier;
		//Debug.Log("deviceid");
		deviceid = deviceid +"somissu2";
		KEY = deviceid.Substring(0,8);
	}
	
	public static void SetUsim (string index) 
	{
		usimsIndex = index;
		Debug.Log("SetUsi : "+ index);
	}

	public static void SetTelecomPayCode(int _code)
	{
		telecomPayCode = _code;
	}
	
	public static Rect Rect2(float _posx,float _posy,float _width,float _height ) 
	{
		Rect dubblesize = new Rect(_posx*2, _posy*2, _width*2, _height*2);
		return dubblesize;
	}
	
	
	
	public static bool Property_change (int _value , bool _jade)
	{
		//bool deal = false;
		int property = 0;
		if (_jade)
			property =Crypto.Load_int_key("n24");
		else
			property =Crypto.Load_int_key ("n17");
		
		if (_value <0)
		{
			if (property < _value * (-1))
				return false;
		}
		
		if (_jade)
			Crypto.Save_int_key("n24",property + _value);
		else
			Crypto.Save_int_key ("n17",property + _value);
		
		return true;
	}
	
	
	public static void Save_int_key(string _kind, int _key_int)
	{
		string temp_kind = _kind ;//+ "hideahidea";
		string key_string = _key_int.ToString();//EncryptString(_key_int.ToString(), KEY+ temp_kind.Substring(0,8), IV);
		PlayerPrefs.SetString(_kind,key_string);
		//Debug.Log(key_string);
	}
	
	public static int Load_int_key(string _kind)
	{
		string temp_kind = _kind ;//+ "hideahidea";
		string key_string = PlayerPrefs.GetString(_kind);
//		key_string = DecryptRJ256(Decode(key_string), KEY+ temp_kind.Substring(0,8), IV);
//		Debug.Log(_kind + " = " + key_string);
		int key_int = Convert.ToInt32(key_string);

		return key_int;
	}
	
	public static void Save_string_key(string _kind, string _key_string)
	{
//		Debug.Log("key  " + _kind + " = " + _key_string);
		string temp_kind = _kind ;//+ "hideahidea";
		string key_string = _key_string;//EncryptString(_key_string, KEY+ temp_kind.Substring(0,8), IV);
		PlayerPrefs.SetString(_kind,key_string);
		//Debug.Log(key_string);
	}
	
	public static string Load_string_key(string _kind)
	{
		string temp_kind = _kind ;//+ "hideahidea";
		string key_string = PlayerPrefs.GetString(_kind);
//		key_string = DecryptRJ256(Decode(key_string), KEY+ temp_kind.Substring(0,8), IV);
		return key_string;
	}
	
	public static byte[] Decode(string str)
	{
		//byte[] decbuff =  Convert. (str);
    	byte[] decbuff = Convert.FromBase64String(str);
    	return decbuff;
	}
	
	public static String DecryptRJ256(byte[] cypher, string KeyString, string IVString)
	{
		UTF8Encoding encoding = new UTF8Encoding();
		
		byte[] Key = encoding.GetBytes(KeyString);
        byte[] IV = encoding.GetBytes(IVString);
	
	    string sRet = "";
	    RijndaelManaged rj = new RijndaelManaged();

      // rj.Padding = PaddingMode.Zeros;
        rj.Mode = CipherMode.CBC;
        rj.KeySize = 256;
        rj.BlockSize = 256;
        rj.Key = Key;
        rj.IV = IV;
		
	    try
	    {
	        
	        MemoryStream ms = new MemoryStream(cypher);
	
	        using (CryptoStream cs = new CryptoStream(ms, rj.CreateDecryptor(Key, IV), CryptoStreamMode.Read))
            {
                using (StreamReader sr = new StreamReader(cs))
                {
                    sRet = sr.ReadLine();
                }
                cs.Close();
            }
	
	    }
	    finally
	    {
	        rj.Clear();
	    }
	
	    return sRet;
	}
	
	 public static string EncryptString(string message, string KeyString, string IVString)
    {
        byte[] Key = ASCIIEncoding.UTF8.GetBytes(KeyString);
        byte[] IV = ASCIIEncoding.UTF8.GetBytes(IVString);

        string encrypted = null;
        RijndaelManaged rj = new RijndaelManaged();
		
		rj.BlockSize = 256;
        rj.Key = Key;
        rj.IV = IV;
        rj.Mode = CipherMode.CBC;

        try
        {
            MemoryStream ms = new MemoryStream();

            using (CryptoStream cs = new CryptoStream(ms, rj.CreateEncryptor(Key, IV), CryptoStreamMode.Write))
            {
                using (StreamWriter sw = new StreamWriter(cs))
                {
                    sw.Write(message);
                    sw.Close();
                }
                cs.Close();
            }
            byte[] encoded = ms.ToArray();
            encrypted = Convert.ToBase64String(encoded);

            ms.Close();
        }
        catch (CryptographicException e)
        {
            Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
            return null;
        }
        catch (UnauthorizedAccessException e)
        {
            Console.WriteLine("A file error occurred: {0}", e.Message);
            return null;
        }
        catch (Exception e)
        {
            Console.WriteLine("An error occurred: {0}", e.Message);
        }
        finally
        {
            rj.Clear();
        }

        return encrypted;
    }

}
