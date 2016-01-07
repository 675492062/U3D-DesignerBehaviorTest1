using UnityEngine;
using System.Collections;

public class General_Stat2 : MonoBehaviour {
	
	const int GENERALKIND = 5;
	
	public short general_index = 0;
	public short general_kind = 0;
	public short g_maxhp = 0;
	//public int g_hp = 0;
	public short g_maxatk = 0;
	public short g_def = 0;
	public float g_atkspd = 0;
	public short g_unique = -1;
	public short g_level = 0;
	public short g_grade = 0;
	
	int[] rndkey = new int[8];
	int[] rndkey_og = new int[8];
	
	public void SetGeneral(int _seed)
	{
		//general_hp = PlayerPrefsX.GetIntArray("n33");
		general_index = (short)((_seed%10000000)  /100000);
		general_kind = (short)(general_index % GENERALKIND);
		g_level = (short)((float)_seed/(float)10000000);
		
		if (general_index<10)
			g_unique = (short)general_index;
		else
			g_unique = -1;

		for (int i= 0; i<8; ++i)
		{
			rndkey_og[i] = _seed%10;
			_seed = (int)(_seed/10);
			rndkey[i] =  rndkey_og[i];
		}
		
		g_grade = (short)rndkey_og[4];
		
		
		for (int j = 0; j<g_level-1; ++j)
		{
			++ rndkey[j%4];
			if (j!=0 && j%(4/*-g_grade*/) == 0)
				++ rndkey[(rndkey_og[j%4]+general_index)%4];
		}
		g_maxatk = (short)(rndkey_og[0]*0.5f + (rndkey[0]-rndkey_og[0])+ g_level +3 + g_grade*2);
		g_def = (short)(rndkey_og[1]*0.5f  +1+ (rndkey[1]-rndkey_og[1]) +g_grade*2);
		g_maxhp = (short)(rndkey[2]*10 + 60 +g_grade*10);
		//g_hp = general_hp[cur_general];
		g_atkspd = 0.01f + rndkey[3]*0.002f +g_grade*0.004f;
		//Debug.Log( (rndkey[1]-rndkey_og[1]));
		
		/*if(general_kind == 0)
		{
			//g_maxatk = (int)(g_maxatk *1.4f);
			//g_def =  (short)(g_def *1.4f);
			//g_maxhp = (int)(g_maxhp *1.2f);
			transform.root.localScale = Vector3.one;
		}
		else if (general_kind == 1)
		{
			transform.root.localScale = Vector3.one * 1.3f;
		}*/
	}
}
