using UnityEngine;
using System.Collections;

public  struct generalset
{
	public short _voice;
	public short _kind;
	public short _weapon;
	public short _skillname;
	public short _skillindex;
	public short _skillkind;
	public short _skillatk;
	public float _cooltime;
	public short _soulcost;
}

public class DB_General : MonoBehaviour {
	

	public generalset[] gs = new generalset[30];
	
	void Awake()
	{
		//"0"
		gs[0]._voice = 5;
		gs[0]._kind = 0;
		gs[0]._weapon = 7;
		gs[0]._skillname = 1;
		gs[0]._skillindex = 21;
		gs[0]._skillkind = 2;
		gs[0]._skillatk = 40;
		gs[0]._cooltime = 30;
		gs[0]._soulcost = 1;

		//"1"
		gs[1]._voice = 2;
		gs[1]._kind = 1;
		gs[1]._weapon = 2;
		gs[1]._skillname = 2;
		gs[1]._skillindex = 22;
		gs[1]._skillkind = 1;
		gs[1]._skillatk = 150;
		gs[1]._cooltime = 30;
		gs[1]._soulcost = 1;

		//"2"
		gs[2]._voice = 4;
		gs[2]._kind = 2;
		gs[2]._weapon = 3;
		gs[2]._skillname = 3;
		gs[2]._skillindex = 23;
		gs[2]._skillkind = 2;
		gs[2]._skillatk = 40;
		gs[2]._cooltime = 30;
		gs[2]._soulcost = 1;

		//"3"
		gs[3]._voice = 1;
		gs[3]._kind = 3;
		gs[3]._weapon = 8;
		gs[3]._skillname = 4;
		gs[3]._skillindex = 24;
		gs[3]._skillkind = 2;
		gs[3]._skillatk = 30;
		gs[3]._cooltime = 30;
		gs[3]._soulcost = 1;

		//"4"
		gs[4]._voice = 5;
		gs[4]._kind = 4;
		gs[4]._weapon = 5;
		gs[4]._skillname = 5;
		gs[4]._skillindex = 25;
		gs[4]._skillkind = 4;
		gs[4]._skillatk = 110;
		gs[4]._cooltime = 30;
		gs[4]._soulcost = 1;

		//"5"
		gs[5]._voice = 3;
		gs[5]._kind = 0;
		gs[5]._weapon = 1;
		gs[5]._skillname = 6;
		gs[5]._skillindex = 26;
		gs[5]._skillkind = 4;
		gs[5]._skillatk = 120;
		gs[5]._cooltime = 30;
		gs[5]._soulcost = 1;

		//"6"
		gs[6]._voice = 1;
		gs[6]._kind = 1;
		gs[6]._weapon = 2;
		gs[6]._skillname = 7;
		gs[6]._skillindex = 27;
		gs[6]._skillkind = 1;
		gs[6]._skillatk = 70;
		gs[6]._cooltime = 30;
		gs[6]._soulcost = 1;

		//"7"
		gs[7]._voice = 1;
		gs[7]._kind = 2;
		gs[7]._weapon = 3;
		gs[7]._skillname = 8;
		gs[7]._skillindex = 28;
		gs[7]._skillkind = 3;
		gs[7]._skillatk = 40;
		gs[7]._cooltime = 30;
		gs[7]._soulcost = 1;

		//"8"
		gs[8]._voice = 4;
		gs[8]._kind = 3;
		gs[8]._weapon = 4;
		gs[8]._skillname = 9;
		gs[8]._skillindex = 29;
		gs[8]._skillkind = 4;
		gs[8]._skillatk = 100;
		gs[8]._cooltime = 30;
		gs[8]._soulcost = 1;

		//"9"
		gs[9]._voice = 0;
		gs[9]._kind = 4;
		gs[9]._weapon = 5;
		gs[9]._skillname = 10;
		gs[9]._skillindex = 30;
		gs[9]._skillkind = 3;
		gs[9]._skillatk = 200;
		gs[9]._cooltime = 30;
		gs[9]._soulcost = 1;

		//"10"
		gs[10]._voice = 0;
		gs[10]._kind = 0;
		gs[10]._weapon = 7;
		gs[10]._skillname = 11;
		gs[10]._skillindex = 31;
		gs[10]._skillkind = 4;
		gs[10]._skillatk = 120;
		gs[10]._cooltime = 30;
		gs[10]._soulcost = 1;

		//"11"
		gs[11]._voice = 2;
		gs[11]._kind = 1;
		gs[11]._weapon = 2;
		gs[11]._skillname = 12;
		gs[11]._skillindex = 32;
		gs[11]._skillkind = 1;
		gs[11]._skillatk = 100;
		gs[11]._cooltime = 30;
		gs[11]._soulcost = 1;

		//"12"
		gs[12]._voice = 4;
		gs[12]._kind = 2;
		gs[12]._weapon = 3;
		gs[12]._skillname = 13;
		gs[12]._skillindex = 33;
		gs[12]._skillkind = 3;
		gs[12]._skillatk = 60;
		gs[12]._cooltime = 30;
		gs[12]._soulcost = 1;

		//"13"
		gs[13]._voice = 4;
		gs[13]._kind = 3;
		gs[13]._weapon = 4;
		gs[13]._skillname = 14;
		gs[13]._skillindex = 34;
		gs[13]._skillkind = 1;
		gs[13]._skillatk = 120;
		gs[13]._cooltime = 30;
		gs[13]._soulcost = 1;

		//"14"
		gs[14]._voice = 0;
		gs[14]._kind = 4;
		gs[14]._weapon = 5;
		gs[14]._skillname = 15;
		gs[14]._skillindex = 35;
		gs[14]._skillkind = 4;
		gs[14]._skillatk = 70;
		gs[14]._cooltime = 30;
		gs[14]._soulcost = 1;

		//"15"
		gs[15]._voice = 5;
		gs[15]._kind = 0;
		gs[15]._weapon = 6;
		gs[15]._skillname = 16;
		gs[15]._skillindex = 36;
		gs[15]._skillkind = 1;
		gs[15]._skillatk = 50;
		gs[15]._cooltime = 30;
		gs[15]._soulcost = 1;

		//"16"
		gs[16]._voice = 1;
		gs[16]._kind = 1;
		gs[16]._weapon = 2;
		gs[16]._skillname = 17;
		gs[16]._skillindex = 37;
		gs[16]._skillkind = 2;
		gs[16]._skillatk = 50;
		gs[16]._cooltime = 30;
		gs[16]._soulcost = 1;

		//"17"
		gs[17]._voice = 3;
		gs[17]._kind = 2;
		gs[17]._weapon = 3;
		gs[17]._skillname = 18;
		gs[17]._skillindex = 38;
		gs[17]._skillkind = 1;
		gs[17]._skillatk = 6;
		gs[17]._cooltime = 30;
		gs[17]._soulcost = 1;

		//"18"
		gs[18]._voice = 1;
		gs[18]._kind = 3;
		gs[18]._weapon = 4;
		gs[18]._skillname = 19;
		gs[18]._skillindex = 39;
		gs[18]._skillkind = 1;
		gs[18]._skillatk = 40;
		gs[18]._cooltime = 30;
		gs[18]._soulcost = 1;

		//"19"
		gs[19]._voice = 1;
		gs[19]._kind = 4;
		gs[19]._weapon = 5;
		gs[19]._skillname = 20;
		gs[19]._skillindex = 40;
		gs[19]._skillkind = 3;
		gs[19]._skillatk = 40;
		gs[19]._cooltime = 30;
		gs[19]._soulcost = 1;

		//"20"
		gs[20]._voice = 3;
		gs[20]._kind = 0;
		gs[20]._weapon = 7;
		gs[20]._skillname = 0;
		gs[20]._skillindex = -1;
		gs[20]._skillkind = 0;
		gs[20]._skillatk = 0;
		gs[20]._cooltime = 0;
		gs[20]._soulcost = 0;

		//"21"
		gs[21]._voice = 2;
		gs[21]._kind = 1;
		gs[21]._weapon = 2;
		gs[21]._skillname = 0;
		gs[21]._skillindex = -2;
		gs[21]._skillkind = 0;
		gs[21]._skillatk = 0;
		gs[21]._cooltime = 0;
		gs[21]._soulcost = 0;

		//"22"
		gs[22]._voice = 0;
		gs[22]._kind = 2;
		gs[22]._weapon = 3;
		gs[22]._skillname = 0;
		gs[22]._skillindex = -3;
		gs[22]._skillkind = 0;
		gs[22]._skillatk = 0;
		gs[22]._cooltime = 0;
		gs[22]._soulcost = 0;

		//"23"
		gs[23]._voice = 1;
		gs[23]._kind = 3;
		gs[23]._weapon = 4;
		gs[23]._skillname = 0;
		gs[23]._skillindex = -4;
		gs[23]._skillkind = 0;
		gs[23]._skillatk = 0;
		gs[23]._cooltime = 0;
		gs[23]._soulcost = 0;

		//"24"
		gs[24]._voice = 0;
		gs[24]._kind = 4;
		gs[24]._weapon = 5;
		gs[24]._skillname = 0;
		gs[24]._skillindex = -5;
		gs[24]._skillkind = 0;
		gs[24]._skillatk = 0;
		gs[24]._cooltime = 0;
		gs[24]._soulcost = 0;

		//"25"
		gs[25]._voice = 5;
		gs[25]._kind = 0;
		gs[25]._weapon = 7;
		gs[25]._skillname = 0;
		gs[25]._skillindex = -6;
		gs[25]._skillkind = 0;
		gs[25]._skillatk = 0;
		gs[25]._cooltime = 0;
		gs[25]._soulcost = 0;

		//"26"
		gs[26]._voice = 2;
		gs[26]._kind = 1;
		gs[26]._weapon = 2;
		gs[26]._skillname = 0;
		gs[26]._skillindex = -7;
		gs[26]._skillkind = 0;
		gs[26]._skillatk = 0;
		gs[26]._cooltime = 0;
		gs[26]._soulcost = 0;

		//"27"
		gs[27]._voice = 1;
		gs[27]._kind = 2;
		gs[27]._weapon = 3;
		gs[27]._skillname = 0;
		gs[27]._skillindex = -8;
		gs[27]._skillkind = 0;
		gs[27]._skillatk = 0;
		gs[27]._cooltime = 0;
		gs[27]._soulcost = 0;

		//"28"
		gs[28]._voice = 1;
		gs[28]._kind = 3;
		gs[28]._weapon = 4;
		gs[28]._skillname = 0;
		gs[28]._skillindex = -9;
		gs[28]._skillkind = 0;
		gs[28]._skillatk = 0;
		gs[28]._cooltime = 0;
		gs[28]._soulcost = 0;

		//"29"
		gs[29]._voice = 0;
		gs[29]._kind = 4;
		gs[29]._weapon = 5;
		gs[29]._skillname = 0;
		gs[29]._skillindex = -10;
		gs[29]._skillkind = 0;
		gs[29]._skillatk = 0;
		gs[29]._cooltime = 0;
		gs[29]._soulcost = 0;
	}
}
