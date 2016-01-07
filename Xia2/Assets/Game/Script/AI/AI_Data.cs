using UnityEngine;
using System.Collections;


public class AI_Data {

	int id;	
	public float search_time;
	public float idle_time;	
	public float eyeangle;
	public int idle_pro;
	public int idle_num;	
	public int skill_attack;	
	public float walk_back;	
	public float wait_time;	
	public float eyedis;	
	public float rundis;	
	public float max_startwalkdis;	
	public float min_startwalkdis;	
	public float dodskill1;
	public float dodskill2;
	public float runAwayHp1;
	public float runAwayHp2;

	public void parseData(int templateID)
	{
		id = templateID;
		search_time = StaticAi.Instance ().getFloat (id, "search_time");
		idle_time   = StaticAi.Instance ().getFloat (id, "idle_time");
		idle_pro    = StaticAi.Instance ().getInt (id, "idle_pro");
		idle_num    = StaticAi.Instance ().getInt (id, "idle_num");
		walk_back   = StaticAi.Instance ().getFloat (id, "walk_back");
		eyeangle    = StaticAi.Instance ().getFloat (id, "eyeangle");
		wait_time   = StaticAi.Instance ().getFloat (id, "wait_time");	
		eyedis      = StaticAi.Instance ().getFloat (id, "eyedis");
		rundis      = StaticAi.Instance ().getFloat (id, "rundis");
		max_startwalkdis= StaticAi.Instance ().getFloat (id, "max_startwalkdis");
		min_startwalkdis= StaticAi.Instance ().getFloat (id, "min_startwalkdis");
		dodskill1  =  StaticAi.Instance ().getFloat (id, "dodskill1");
		dodskill2  =  StaticAi.Instance ().getFloat (id, "dodskill2");
		runAwayHp1 =  StaticAi.Instance ().getFloat (id, "escape_hp1");
		runAwayHp2 =  StaticAi.Instance ().getFloat (id, "escape_hp2");
	}
}
