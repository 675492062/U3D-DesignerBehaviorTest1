using UnityEngine;
using System.Collections;

public class TestData : MonoBehaviour {

	public TestData()
	{
	//	initData();
	}
	// Use this for initialization
	void Start () 
	{
		initData ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void initData()
	{
		PlayerPrefs.SetString("camfov", "0");
		PlayerPrefs.SetString("cashshopkind", "0");
		PlayerPrefs.SetString("n47", "81");
		PlayerPrefs.SetString("n11", "0");
		PlayerPrefs.SetString("n17", "1200");
		PlayerPrefs.SetString("n24", "15005");
		PlayerPrefs.SetString("n09", "4");
		PlayerPrefs.SetString("n03", "3");
		PlayerPrefs.SetString("n42", "3");
		PlayerPrefs.SetString("n06", "86");
		PlayerPrefs.SetString("n10", "5");
		PlayerPrefs.SetString("n12", "1");
		PlayerPrefs.SetString("n16", "3");
		PlayerPrefs.SetString("n14", "0");
		PlayerPrefs.SetString("n08", "1");
		PlayerPrefs.SetString("n21", "1");
		PlayerPrefs.SetString("n28", "1");
		PlayerPrefs.SetString("n26", "100");
		PlayerPrefs.SetString("n30", "1");
		PlayerPrefs.SetString("n32", "5");
		PlayerPrefs.SetString("n05", "0");
		PlayerPrefs.SetString("n44", "0");
		PlayerPrefs.SetString("n43", "0");
		PlayerPrefs.SetString("cur_general", "0");
		PlayerPrefs.SetString("n34", "0");
		PlayerPrefs.SetString("n31", "10");
		PlayerPrefs.SetString("n04", "8");
		PlayerPrefs.SetString("n35", "2");
		PlayerPrefs.SetString("n38", "0");
		PlayerPrefs.SetString("cur_stage_index", "0");
		PlayerPrefs.SetString("play_kind", "0");
		PlayerPrefs.SetString("n37", "-1");
		PlayerPrefs.SetString("n46", "3");
		PlayerPrefs.SetString("n48", "1");
		PlayerPrefs.SetString("n49", "1");
		PlayerPrefs.SetString("n54", "0");
		PlayerPrefs.SetString("n55", "0");
		PlayerPrefs.SetString("n56", "0");
		PlayerPrefs.SetString("n58", "0");
		PlayerPrefs.SetString("n59", "0");
		PlayerPrefs.SetString("n61", "0");
		PlayerPrefs.SetString("generalsearch", "0");
		PlayerPrefs.SetString("caveplay", "0");
		PlayerPrefs.SetString("perfectplay", "0");
		PlayerPrefs.SetString("enemykill", "0");
		PlayerPrefs.SetString("grappling", "0");
		PlayerPrefs.SetString("exattack", "0");
		PlayerPrefs.SetString("death", "0");
		PlayerPrefs.SetString("resurrection", "0");
		PlayerPrefs.SetString("changelevel", "0");
		PlayerPrefs.SetString("storycutin", "0");
		PlayerPrefs.SetString("tutorial", "-1");
		PlayerPrefs.SetString("cashing", "0");
		PlayerPrefs.SetString("cur_stage_kind", "2");

		int []temp_1 = {-1,-1,-1,-1,-1,}; 
		PlayerPrefsX.SetIntArray("skill_slot",temp_1);
		int []temp_2 = {10540,0,0,0,0,0,16040599,17042599,18041599,19041599,20040599,21043599,22042599,23043599,24040599,25046599,0,0,0,0,0,0,0,0,0,0}; 
		PlayerPrefsX.SetIntArray("n41",temp_2);
		int []temp_3 ={10000,0,0,0,0,0,151407,202408,253409,301410,352411,403412,501413,552414,603415,704416,0,0,0,0,0,0,0,0,0,0}; 
		PlayerPrefsX.SetIntArray("n45",temp_3);
		int []temp_4 ={0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
		PlayerPrefsX.SetIntArray("n19",temp_4);
		int []temp_5 ={1,0,0,0,0};
		PlayerPrefsX.SetIntArray("n39",temp_5);
		int []temp_6 ={0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
		PlayerPrefsX.SetIntArray("treasure",temp_6);
		int []temp_7 ={0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0};
		PlayerPrefsX.SetIntArray("staff",temp_7);
		int []temp_8 ={0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
		PlayerPrefsX.SetIntArray("archive",temp_8);
		int []temp_9 ={0,0,0,0,0,0,0,0,0,0,0,0};
		PlayerPrefsX.SetIntArray("bosskill",temp_9);
		int []temp_10 ={0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
		PlayerPrefsX.SetIntArray("skill_use",temp_10);
		int []temp_11 ={0,0};  
		PlayerPrefsX.SetIntArray("pet_skill_use",temp_11);
		int []temp_12 ={1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0}; 
		PlayerPrefsX.SetIntArray("n15",temp_12);
		int []temp_13 ={0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
		PlayerPrefsX.SetIntArray("n18",temp_12);
		int []temp_14 ={0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
		PlayerPrefsX.SetIntArray("n40",temp_14);
		int []temp_15 ={0,0,0,0,0,0};
		PlayerPrefsX.SetIntArray("n20",temp_15);
		int []temp_16 ={-2,-2,-2,-2,-2,-2,-2,-2,-2,-2,-2,-2,-2,-2,-2,-2,-2,-2,-2,-2};
		PlayerPrefsX.SetIntArray("n22",temp_16);
		int []temp_17 ={0,0};
		PlayerPrefsX.SetIntArray("n23",temp_17);
		int []temp_18 ={0,0};
		PlayerPrefsX.SetIntArray("n27",temp_18);
		int []temp_19 ={0,0};
		PlayerPrefsX.SetIntArray("n25",temp_19);
		int []temp_20 ={12707979,0,0,0,0,0,0,0,0,0,0,0};
		PlayerPrefsX.SetIntArray("n13",temp_20);
		int []temp_21 ={100,0,0,0,0,0,0,0,0,0,0,0};
		PlayerPrefsX.SetIntArray("n33",temp_21);
		int []temp_22 ={0,0,0,0,0,0,0,0,0,0,0,0};
		PlayerPrefsX.SetIntArray("n29",temp_22);
		int []temp_23 ={0,0,0,0,0,0};
		PlayerPrefsX.SetIntArray("n36",temp_23);
		int []temp_24 ={0,0,0};
		PlayerPrefsX.SetIntArray("n50",temp_24);
		int []temp_25 ={0,0};
		PlayerPrefsX.SetIntArray("n51",temp_25);
		int []temp_26 ={0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
		PlayerPrefsX.SetIntArray("n52",temp_26);
		int []temp_27 ={0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 };
		PlayerPrefsX.SetIntArray("n53",temp_27);


	}
}
