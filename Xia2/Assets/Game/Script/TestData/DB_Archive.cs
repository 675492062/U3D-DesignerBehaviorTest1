using UnityEngine;
using System.Collections;

public  struct archive
{
	public short _name;
	public short _info;
	public short _reward_kind;
	public short _reward_amount;
	public short _require_kind;
	public short _require_kind_sub;
	public short _require_amount;
}

public class DB_Archive : MonoBehaviour {

	
	public archive[] aci = new archive[76];
	void Awake()
	{
		//stage1clear
		aci[0]._name = 1;
		aci[0]._info = 81;
		aci[0]._reward_kind = 1;
		aci[0]._reward_amount = 10;
		aci[0]._require_kind = 7;
		aci[0]._require_kind_sub = -1;
		aci[0]._require_amount = 1;

		//stage10clear
		aci[1]._name = 2;
		aci[1]._info = 82;
		aci[1]._reward_kind = 1;
		aci[1]._reward_amount = 100;
		aci[1]._require_kind = 7;
		aci[1]._require_kind_sub = -1;
		aci[1]._require_amount = 10;

		//stage30clear
		aci[2]._name = 3;
		aci[2]._info = 83;
		aci[2]._reward_kind = 1;
		aci[2]._reward_amount = 300;
		aci[2]._require_kind = 7;
		aci[2]._require_kind_sub = -1;
		aci[2]._require_amount = 30;

		//stage90clear
		aci[3]._name = 4;
		aci[3]._info = 84;
		aci[3]._reward_kind = 1;
		aci[3]._reward_amount = 1000;
		aci[3]._require_kind = 7;
		aci[3]._require_kind_sub = -1;
		aci[3]._require_amount = 90;

		//slash500
		aci[4]._name = 5;
		aci[4]._info = 85;
		aci[4]._reward_kind = 1;
		aci[4]._reward_amount = 50;
		aci[4]._require_kind = 1;
		aci[4]._require_kind_sub = -1;
		aci[4]._require_amount = 500;

		//slash2000
		aci[5]._name = 6;
		aci[5]._info = 86;
		aci[5]._reward_kind = 1;
		aci[5]._reward_amount = 200;
		aci[5]._require_kind = 1;
		aci[5]._require_kind_sub = -1;
		aci[5]._require_amount = 2000;

		//slash5000
		aci[6]._name = 7;
		aci[6]._info = 87;
		aci[6]._reward_kind = 1;
		aci[6]._reward_amount = 500;
		aci[6]._require_kind = 1;
		aci[6]._require_kind_sub = -1;
		aci[6]._require_amount = 5000;

		//slash10000
		aci[7]._name = 8;
		aci[7]._info = 88;
		aci[7]._reward_kind = 1;
		aci[7]._reward_amount = 1000;
		aci[7]._require_kind = 1;
		aci[7]._require_kind_sub = -1;
		aci[7]._require_amount = 10000;

		//grab50
		aci[8]._name = 9;
		aci[8]._info = 89;
		aci[8]._reward_kind = 1;
		aci[8]._reward_amount = 50;
		aci[8]._require_kind = 2;
		aci[8]._require_kind_sub = -1;
		aci[8]._require_amount = 50;

		//grab200
		aci[9]._name = 10;
		aci[9]._info = 90;
		aci[9]._reward_kind = 1;
		aci[9]._reward_amount = 200;
		aci[9]._require_kind = 2;
		aci[9]._require_kind_sub = -1;
		aci[9]._require_amount = 200;

		//grab500
		aci[10]._name = 11;
		aci[10]._info = 91;
		aci[10]._reward_kind = 1;
		aci[10]._reward_amount = 500;
		aci[10]._require_kind = 2;
		aci[10]._require_kind_sub = -1;
		aci[10]._require_amount = 500;

		//grab1000
		aci[11]._name = 12;
		aci[11]._info = 92;
		aci[11]._reward_kind = 1;
		aci[11]._reward_amount = 1000;
		aci[11]._require_kind = 2;
		aci[11]._require_kind_sub = -1;
		aci[11]._require_amount = 1000;

		//die50
		aci[12]._name = 13;
		aci[12]._info = 93;
		aci[12]._reward_kind = 1;
		aci[12]._reward_amount = 100;
		aci[12]._require_kind = 3;
		aci[12]._require_kind_sub = -1;
		aci[12]._require_amount = 10;

		//die100
		aci[13]._name = 14;
		aci[13]._info = 94;
		aci[13]._reward_kind = 1;
		aci[13]._reward_amount = 1000;
		aci[13]._require_kind = 3;
		aci[13]._require_kind_sub = -1;
		aci[13]._require_amount = 100;

		//resurrection50
		aci[14]._name = 15;
		aci[14]._info = 95;
		aci[14]._reward_kind = 1;
		aci[14]._reward_amount = 10;
		aci[14]._require_kind = 4;
		aci[14]._require_kind_sub = -1;
		aci[14]._require_amount = 10;

		//resurrection100
		aci[15]._name = 16;
		aci[15]._info = 96;
		aci[15]._reward_kind = 1;
		aci[15]._reward_amount = 50;
		aci[15]._require_kind = 4;
		aci[15]._require_kind_sub = -1;
		aci[15]._require_amount = 50;

		//resurrection200
		aci[16]._name = 17;
		aci[16]._info = 97;
		aci[16]._reward_kind = 1;
		aci[16]._reward_amount = 100;
		aci[16]._require_kind = 4;
		aci[16]._require_kind_sub = -1;
		aci[16]._require_amount = 100;

		//ex100
		aci[17]._name = 18;
		aci[17]._info = 98;
		aci[17]._reward_kind = 2;
		aci[17]._reward_amount = 1;
		aci[17]._require_kind = 5;
		aci[17]._require_kind_sub = -1;
		aci[17]._require_amount = 100;

		//ex500
		aci[18]._name = 19;
		aci[18]._info = 99;
		aci[18]._reward_kind = 2;
		aci[18]._reward_amount = 1;
		aci[18]._require_kind = 5;
		aci[18]._require_kind_sub = -1;
		aci[18]._require_amount = 500;

		//ex1000
		aci[19]._name = 20;
		aci[19]._info = 100;
		aci[19]._reward_kind = 2;
		aci[19]._reward_amount = 2;
		aci[19]._require_kind = 5;
		aci[19]._require_kind_sub = -1;
		aci[19]._require_amount = 1000;

		//boss1
		aci[20]._name = 21;
		aci[20]._info = 101;
		aci[20]._reward_kind = 1;
		aci[20]._reward_amount = 100;
		aci[20]._require_kind = 8;
		aci[20]._require_kind_sub = 1;
		aci[20]._require_amount = 5;

		//boss2
		aci[21]._name = 22;
		aci[21]._info = 102;
		aci[21]._reward_kind = 1;
		aci[21]._reward_amount = 100;
		aci[21]._require_kind = 8;
		aci[21]._require_kind_sub = 2;
		aci[21]._require_amount = 5;

		//boss3
		aci[22]._name = 23;
		aci[22]._info = 103;
		aci[22]._reward_kind = 1;
		aci[22]._reward_amount = 100;
		aci[22]._require_kind = 8;
		aci[22]._require_kind_sub = 3;
		aci[22]._require_amount = 5;

		//boss4
		aci[23]._name = 24;
		aci[23]._info = 104;
		aci[23]._reward_kind = 1;
		aci[23]._reward_amount = 150;
		aci[23]._require_kind = 8;
		aci[23]._require_kind_sub = 4;
		aci[23]._require_amount = 5;

		//boss5
		aci[24]._name = 25;
		aci[24]._info = 105;
		aci[24]._reward_kind = 1;
		aci[24]._reward_amount = 150;
		aci[24]._require_kind = 8;
		aci[24]._require_kind_sub = 5;
		aci[24]._require_amount = 5;

		//boss6
		aci[25]._name = 26;
		aci[25]._info = 106;
		aci[25]._reward_kind = 1;
		aci[25]._reward_amount = 150;
		aci[25]._require_kind = 8;
		aci[25]._require_kind_sub = 6;
		aci[25]._require_amount = 5;

		//boss7
		aci[26]._name = 27;
		aci[26]._info = 107;
		aci[26]._reward_kind = 1;
		aci[26]._reward_amount = 200;
		aci[26]._require_kind = 8;
		aci[26]._require_kind_sub = 7;
		aci[26]._require_amount = 5;

		//boss8
		aci[27]._name = 28;
		aci[27]._info = 108;
		aci[27]._reward_kind = 1;
		aci[27]._reward_amount = 200;
		aci[27]._require_kind = 8;
		aci[27]._require_kind_sub = 8;
		aci[27]._require_amount = 5;

		//boss9
		aci[28]._name = 29;
		aci[28]._info = 109;
		aci[28]._reward_kind = 1;
		aci[28]._reward_amount = 200;
		aci[28]._require_kind = 8;
		aci[28]._require_kind_sub = 9;
		aci[28]._require_amount = 5;

		//boss10
		aci[29]._name = 30;
		aci[29]._info = 110;
		aci[29]._reward_kind = 1;
		aci[29]._reward_amount = 300;
		aci[29]._require_kind = 8;
		aci[29]._require_kind_sub = 10;
		aci[29]._require_amount = 5;

		//pet_horse50
		aci[30]._name = 31;
		aci[30]._info = 111;
		aci[30]._reward_kind = 1;
		aci[30]._reward_amount = 50;
		aci[30]._require_kind = 9;
		aci[30]._require_kind_sub = 0;
		aci[30]._require_amount = 50;

		//pet_eagle50
		aci[31]._name = 32;
		aci[31]._info = 112;
		aci[31]._reward_kind = 1;
		aci[31]._reward_amount = 50;
		aci[31]._require_kind = 9;
		aci[31]._require_kind_sub = 1;
		aci[31]._require_amount = 50;

		//cosutume3
		aci[32]._name = 33;
		aci[32]._info = 113;
		aci[32]._reward_kind = 2;
		aci[32]._reward_amount = 1;
		aci[32]._require_kind = 19;
		aci[32]._require_kind_sub = -1;
		aci[32]._require_amount = 3;

		//cosutume5
		aci[33]._name = 34;
		aci[33]._info = 114;
		aci[33]._reward_kind = 2;
		aci[33]._reward_amount = 2;
		aci[33]._require_kind = 19;
		aci[33]._require_kind_sub = -1;
		aci[33]._require_amount = 5;

		//cosutume10
		aci[34]._name = 35;
		aci[34]._info = 115;
		aci[34]._reward_kind = 2;
		aci[34]._reward_amount = 3;
		aci[34]._require_kind = 19;
		aci[34]._require_kind_sub = -1;
		aci[34]._require_amount = 10;

		//explore5
		aci[35]._name = 36;
		aci[35]._info = 116;
		aci[35]._reward_kind = 2;
		aci[35]._reward_amount = 1;
		aci[35]._require_kind = 11;
		aci[35]._require_kind_sub = -1;
		aci[35]._require_amount = 5;

		//explore20
		aci[36]._name = 37;
		aci[36]._info = 117;
		aci[36]._reward_kind = 2;
		aci[36]._reward_amount = 2;
		aci[36]._require_kind = 11;
		aci[36]._require_kind_sub = -1;
		aci[36]._require_amount = 20;

		//explore100
		aci[37]._name = 38;
		aci[37]._info = 118;
		aci[37]._reward_kind = 2;
		aci[37]._reward_amount = 3;
		aci[37]._require_kind = 11;
		aci[37]._require_kind_sub = -1;
		aci[37]._require_amount = 100;

		//general_grade5
		aci[38]._name = 39;
		aci[38]._info = 119;
		aci[38]._reward_kind = 2;
		aci[38]._reward_amount = 5;
		aci[38]._require_kind = 6;
		aci[38]._require_kind_sub = -1;
		aci[38]._require_amount = 1;

		//general_grade4
		aci[39]._name = 40;
		aci[39]._info = 120;
		aci[39]._reward_kind = 2;
		aci[39]._reward_amount = 5;
		aci[39]._require_kind = 12;
		aci[39]._require_kind_sub = -1;
		aci[39]._require_amount = 5;

		//learn_skill3
		aci[40]._name = 41;
		aci[40]._info = 121;
		aci[40]._reward_kind = 1;
		aci[40]._reward_amount = 10;
		aci[40]._require_kind = 13;
		aci[40]._require_kind_sub = -1;
		aci[40]._require_amount = 3;

		//learn_skill5
		aci[41]._name = 42;
		aci[41]._info = 122;
		aci[41]._reward_kind = 1;
		aci[41]._reward_amount = 30;
		aci[41]._require_kind = 13;
		aci[41]._require_kind_sub = -1;
		aci[41]._require_amount = 5;

		//learn_skill10
		aci[42]._name = 43;
		aci[42]._info = 123;
		aci[42]._reward_kind = 2;
		aci[42]._reward_amount = 1;
		aci[42]._require_kind = 13;
		aci[42]._require_kind_sub = -1;
		aci[42]._require_amount = 10;

		//learn_skill20
		aci[43]._name = 44;
		aci[43]._info = 124;
		aci[43]._reward_kind = 2;
		aci[43]._reward_amount = 2;
		aci[43]._require_kind = 13;
		aci[43]._require_kind_sub = -1;
		aci[43]._require_amount = 20;

		//skillmax5
		aci[44]._name = 45;
		aci[44]._info = 125;
		aci[44]._reward_kind = 2;
		aci[44]._reward_amount = 2;
		aci[44]._require_kind = 14;
		aci[44]._require_kind_sub = -1;
		aci[44]._require_amount = 5;

		//skillmax10
		aci[45]._name = 46;
		aci[45]._info = 126;
		aci[45]._reward_kind = 2;
		aci[45]._reward_amount = 3;
		aci[45]._require_kind = 14;
		aci[45]._require_kind_sub = -1;
		aci[45]._require_amount = 10;

		//skill1
		aci[46]._name = 47;
		aci[46]._info = 127;
		aci[46]._reward_kind = 1;
		aci[46]._reward_amount = 100;
		aci[46]._require_kind = 10;
		aci[46]._require_kind_sub = 0;
		aci[46]._require_amount = 100;

		//skill2
		aci[47]._name = 48;
		aci[47]._info = 128;
		aci[47]._reward_kind = 1;
		aci[47]._reward_amount = 100;
		aci[47]._require_kind = 10;
		aci[47]._require_kind_sub = 1;
		aci[47]._require_amount = 100;

		//skill3
		aci[48]._name = 49;
		aci[48]._info = 129;
		aci[48]._reward_kind = 1;
		aci[48]._reward_amount = 100;
		aci[48]._require_kind = 10;
		aci[48]._require_kind_sub = 2;
		aci[48]._require_amount = 100;

		//skill4
		aci[49]._name = 50;
		aci[49]._info = 130;
		aci[49]._reward_kind = 1;
		aci[49]._reward_amount = 100;
		aci[49]._require_kind = 10;
		aci[49]._require_kind_sub = 3;
		aci[49]._require_amount = 100;

		//skill5
		aci[50]._name = 51;
		aci[50]._info = 131;
		aci[50]._reward_kind = 1;
		aci[50]._reward_amount = 100;
		aci[50]._require_kind = 10;
		aci[50]._require_kind_sub = 4;
		aci[50]._require_amount = 100;

		//skill6
		aci[51]._name = 52;
		aci[51]._info = 132;
		aci[51]._reward_kind = 1;
		aci[51]._reward_amount = 100;
		aci[51]._require_kind = 10;
		aci[51]._require_kind_sub = 5;
		aci[51]._require_amount = 100;

		//skill7
		aci[52]._name = 53;
		aci[52]._info = 133;
		aci[52]._reward_kind = 1;
		aci[52]._reward_amount = 100;
		aci[52]._require_kind = 10;
		aci[52]._require_kind_sub = 6;
		aci[52]._require_amount = 100;

		//skill8
		aci[53]._name = 54;
		aci[53]._info = 134;
		aci[53]._reward_kind = 1;
		aci[53]._reward_amount = 100;
		aci[53]._require_kind = 10;
		aci[53]._require_kind_sub = 7;
		aci[53]._require_amount = 100;

		//skill9
		aci[54]._name = 55;
		aci[54]._info = 135;
		aci[54]._reward_kind = 1;
		aci[54]._reward_amount = 100;
		aci[54]._require_kind = 10;
		aci[54]._require_kind_sub = 8;
		aci[54]._require_amount = 100;

		//skill10
		aci[55]._name = 56;
		aci[55]._info = 136;
		aci[55]._reward_kind = 1;
		aci[55]._reward_amount = 100;
		aci[55]._require_kind = 10;
		aci[55]._require_kind_sub = 9;
		aci[55]._require_amount = 100;

		//skill11
		aci[56]._name = 57;
		aci[56]._info = 137;
		aci[56]._reward_kind = 1;
		aci[56]._reward_amount = 100;
		aci[56]._require_kind = 10;
		aci[56]._require_kind_sub = 10;
		aci[56]._require_amount = 100;

		//skill12
		aci[57]._name = 58;
		aci[57]._info = 138;
		aci[57]._reward_kind = 1;
		aci[57]._reward_amount = 100;
		aci[57]._require_kind = 10;
		aci[57]._require_kind_sub = 11;
		aci[57]._require_amount = 100;

		//skill13
		aci[58]._name = 59;
		aci[58]._info = 139;
		aci[58]._reward_kind = 1;
		aci[58]._reward_amount = 100;
		aci[58]._require_kind = 10;
		aci[58]._require_kind_sub = 12;
		aci[58]._require_amount = 100;

		//skill14
		aci[59]._name = 60;
		aci[59]._info = 140;
		aci[59]._reward_kind = 1;
		aci[59]._reward_amount = 100;
		aci[59]._require_kind = 10;
		aci[59]._require_kind_sub = 13;
		aci[59]._require_amount = 100;

		//skill15
		aci[60]._name = 61;
		aci[60]._info = 141;
		aci[60]._reward_kind = 1;
		aci[60]._reward_amount = 100;
		aci[60]._require_kind = 10;
		aci[60]._require_kind_sub = 14;
		aci[60]._require_amount = 100;

		//skill16
		aci[61]._name = 62;
		aci[61]._info = 142;
		aci[61]._reward_kind = 1;
		aci[61]._reward_amount = 100;
		aci[61]._require_kind = 10;
		aci[61]._require_kind_sub = 15;
		aci[61]._require_amount = 100;

		//skill17
		aci[62]._name = 63;
		aci[62]._info = 143;
		aci[62]._reward_kind = 1;
		aci[62]._reward_amount = 100;
		aci[62]._require_kind = 10;
		aci[62]._require_kind_sub = 16;
		aci[62]._require_amount = 100;

		//skill18
		aci[63]._name = 64;
		aci[63]._info = 144;
		aci[63]._reward_kind = 1;
		aci[63]._reward_amount = 100;
		aci[63]._require_kind = 10;
		aci[63]._require_kind_sub = 17;
		aci[63]._require_amount = 100;

		//skill19
		aci[64]._name = 65;
		aci[64]._info = 145;
		aci[64]._reward_kind = 1;
		aci[64]._reward_amount = 100;
		aci[64]._require_kind = 10;
		aci[64]._require_kind_sub = 18;
		aci[64]._require_amount = 100;

		//skill20
		aci[65]._name = 66;
		aci[65]._info = 146;
		aci[65]._reward_kind = 1;
		aci[65]._reward_amount = 100;
		aci[65]._require_kind = 10;
		aci[65]._require_kind_sub = 19;
		aci[65]._require_amount = 100;

		//cash_1
		aci[66]._name = 67;
		aci[66]._info = 147;
		aci[66]._reward_kind = 1;
		aci[66]._reward_amount = 50;
		aci[66]._require_kind = 18;
		aci[66]._require_kind_sub = -1;
		aci[66]._require_amount = 1;

		//cash_30
		aci[67]._name = 68;
		aci[67]._info = 148;
		aci[67]._reward_kind = 1;
		aci[67]._reward_amount = 100;
		aci[67]._require_kind = 18;
		aci[67]._require_kind_sub = -1;
		aci[67]._require_amount = 30;

		//allarchive
		aci[68]._name = 69;
		aci[68]._info = 149;
		aci[68]._reward_kind = 2;
		aci[68]._reward_amount = 10;
		aci[68]._require_kind = 20;
		aci[68]._require_kind_sub = -1;
		aci[68]._require_amount = 1;

		//dun1
		aci[69]._name = 70;
		aci[69]._info = 150;
		aci[69]._reward_kind = 1;
		aci[69]._reward_amount = 50;
		aci[69]._require_kind = 15;
		aci[69]._require_kind_sub = -1;
		aci[69]._require_amount = 1;

		//dun10
		aci[70]._name = 71;
		aci[70]._info = 151;
		aci[70]._reward_kind = 1;
		aci[70]._reward_amount = 100;
		aci[70]._require_kind = 15;
		aci[70]._require_kind_sub = -1;
		aci[70]._require_amount = 10;

		//dun50
		aci[71]._name = 72;
		aci[71]._info = 152;
		aci[71]._reward_kind = 1;
		aci[71]._reward_amount = 500;
		aci[71]._require_kind = 15;
		aci[71]._require_kind_sub = -1;
		aci[71]._require_amount = 50;

		//perfect1
		aci[72]._name = 73;
		aci[72]._info = 153;
		aci[72]._reward_kind = 1;
		aci[72]._reward_amount = 100;
		aci[72]._require_kind = 16;
		aci[72]._require_kind_sub = -1;
		aci[72]._require_amount = 1;

		//perfect10
		aci[73]._name = 74;
		aci[73]._info = 154;
		aci[73]._reward_kind = 2;
		aci[73]._reward_amount = 1;
		aci[73]._require_kind = 16;
		aci[73]._require_kind_sub = -1;
		aci[73]._require_amount = 10;

		//perfect30
		aci[74]._name = 75;
		aci[74]._info = 155;
		aci[74]._reward_kind = 2;
		aci[74]._reward_amount = 2;
		aci[74]._require_kind = 16;
		aci[74]._require_kind_sub = -1;
		aci[74]._require_amount = 30;

		//perfect90
		aci[75]._name = 76;
		aci[75]._info = 156;
		aci[75]._reward_kind = 2;
		aci[75]._reward_amount = 3;
		aci[75]._require_kind = 16;
		aci[75]._require_kind_sub = -1;
		aci[75]._require_amount = 90;
	}

}
