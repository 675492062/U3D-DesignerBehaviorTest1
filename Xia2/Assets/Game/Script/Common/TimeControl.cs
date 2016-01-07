using UnityEngine;
using System.Collections;
using System;

public static class TimeControl
{
	const int MAXWORK = 2;
	
	public static DateTime[] work_starttime = new DateTime[MAXWORK];
	public static string[] string_starttime = new string[MAXWORK];
	
	public static TimeSpan difference;
	public static DateTime servertime;

    public static void InitStart()
    {
		string_starttime = PlayerPrefsX.GetStringArray("n60");

		long[] long_work = new long[MAXWORK];
		for (int i = 0; i<MAXWORK; ++i)
		{
			try
			{
	 			long_work[i] = Convert.ToInt64(string_starttime[i]);
				work_starttime[i] = DateTime.FromBinary(long_work[i]);
			}
			catch (IndexOutOfRangeException e)
			{
				work_starttime[i] = DateTime.Now;
				//Debug.Log(e);
			}
		}
    }
	
	public static void SetDelay(int _index)
	{
		if (servertime == new DateTime())	return;
		//string_starttime = PlayerPrefsX.GetStringArray("n60");
		work_starttime[_index] = servertime;
		string_starttime[_index] = work_starttime[_index].ToBinary().ToString();
        PlayerPrefsX.SetStringArray("n60", string_starttime);
		//Debug.Log(servertime);
		//Debug.Log(string_starttime[0]);
	}
	
	public static void SetRemain(int _index)
	{
		PlayerPrefsX.SetIntArray ("n51", _index);
	}
	
	public static void EraseAll()
	{
		string_starttime = new string[MAXWORK];
		work_starttime = new DateTime[MAXWORK];
		for (int i =0 ; i<MAXWORK; ++i)
		{
			if (servertime ==  new DateTime())
				work_starttime[i] = DateTime.UtcNow;	
			else
				work_starttime[i] = servertime;
			string_starttime[i] = work_starttime[i].ToBinary().ToString();
		}
        PlayerPrefsX.SetStringArray("n60", string_starttime);
	}
	
	public static void RequestServerTime()
	{
		servertime = DateTime.Now;
	}
	
	
	public static int SubtractDelay(int _index)
	{
		if (servertime == new DateTime())	return 0;
		//difference = DateTime.Now.Subtract(work_starttime[_index]);
		difference = servertime.Subtract(work_starttime[_index]);
		int _span = 0;
		
		_span = (int)difference.TotalMinutes;
		_span = Mathf.Clamp(_span,0,10000);
		
		return _span;
	}
	
   	static void GameQuit()
    {
		for (int i =0 ; i<MAXWORK; ++i)
		{
			string_starttime[i] = work_starttime[i].ToBinary().ToString();
		}
		PlayerPrefsX.SetStringArray("n60", string_starttime);
    }
}