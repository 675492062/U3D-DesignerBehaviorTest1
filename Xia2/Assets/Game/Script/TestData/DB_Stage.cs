using UnityEngine;
using System.Collections;


public  struct stagestat
{
	public short _index;
	public short _bosscount;
	public short _basemon1;
	public short _basemon2;
	public short _mainmon;
	public short _stagenum;

	public short _boss1;
	public short _boss2;
	public short _boss3;
	public short _extramon;
	public short _reward;
}

public class DB_Stage : MonoBehaviour {
	
	
	const int MAXSTAGE = 90;
	
	public stagestat[] st = new stagestat[MAXSTAGE];
	
	void Awake()
	{
		//stage1
		st[0]._index = 0;
		st[0]._bosscount = 0;
		st[0]._basemon1 = 0;
		st[0]._basemon2 = 1;
		st[0]._mainmon = 1;
		st[0]._stagenum = 3;
		st[0]._boss1 = -1;
		st[0]._boss2 = -1;
		st[0]._boss3 = -1;
		st[0]._extramon = -1;
		st[0]._reward = 1;

		//stage2
		st[1]._index = 1;
		st[1]._bosscount = 0;
		st[1]._basemon1 = 0;
		st[1]._basemon2 = 1;
		st[1]._mainmon = 3;
		st[1]._stagenum = 1;
		st[1]._boss1 = -1;
		st[1]._boss2 = -1;
		st[1]._boss3 = -1;
		st[1]._extramon = -1;
		st[1]._reward = 1;

		//stage3
		st[2]._index = 2;
		st[2]._bosscount = 1;
		st[2]._basemon1 = 0;
		st[2]._basemon2 = 1;
		st[2]._mainmon = 4;
		st[2]._stagenum = 1;
		st[2]._boss1 = 1;
		st[2]._boss2 = -1;
		st[2]._boss3 = -1;
		st[2]._extramon = -1;
		st[2]._reward = 201;

		//stage4
		st[3]._index = 3;
		st[3]._bosscount = 0;
		st[3]._basemon1 = 0;
		st[3]._basemon2 = 1;
		st[3]._mainmon = 2;
		st[3]._stagenum = 1;
		st[3]._boss1 = -1;
		st[3]._boss2 = -1;
		st[3]._boss3 = -1;
		st[3]._extramon = -1;
		st[3]._reward = 1;

		//stage5
		st[4]._index = 4;
		st[4]._bosscount = 0;
		st[4]._basemon1 = 1;
		st[4]._basemon2 = 3;
		st[4]._mainmon = 4;
		st[4]._stagenum = 1;
		st[4]._boss1 = -1;
		st[4]._boss2 = -1;
		st[4]._boss3 = -1;
		st[4]._extramon = -1;
		st[4]._reward = 1;

		//stage6
		st[5]._index = 5;
		st[5]._bosscount = 1;
		st[5]._basemon1 = 1;
		st[5]._basemon2 = 3;
		st[5]._mainmon = 4;
		st[5]._stagenum = 1;
		st[5]._boss1 = 2;
		st[5]._boss2 = -1;
		st[5]._boss3 = -1;
		st[5]._extramon = -1;
		st[5]._reward = 101;

		//stage7
		st[6]._index = 6;
		st[6]._bosscount = 0;
		st[6]._basemon1 = 1;
		st[6]._basemon2 = 3;
		st[6]._mainmon = 2;
		st[6]._stagenum = 1;
		st[6]._boss1 = -1;
		st[6]._boss2 = -1;
		st[6]._boss3 = -1;
		st[6]._extramon = -1;
		st[6]._reward = 1;

		//stage8
		st[7]._index = 7;
		st[7]._bosscount = 0;
		st[7]._basemon1 = 1;
		st[7]._basemon2 = 3;
		st[7]._mainmon = 2;
		st[7]._stagenum = 1;
		st[7]._boss1 = -1;
		st[7]._boss2 = -1;
		st[7]._boss3 = -1;
		st[7]._extramon = -1;
		st[7]._reward = 1;

		//stage9
		st[8]._index = 8;
		st[8]._bosscount = 1;
		st[8]._basemon1 = 1;
		st[8]._basemon2 = 3;
		st[8]._mainmon = 4;
		st[8]._stagenum = 1;
		st[8]._boss1 = 3;
		st[8]._boss2 = -1;
		st[8]._boss3 = -1;
		st[8]._extramon = -1;
		st[8]._reward = 1;

		//stage10
		st[9]._index = 9;
		st[9]._bosscount = 0;
		st[9]._basemon1 = 1;
		st[9]._basemon2 = 3;
		st[9]._mainmon = 2;
		st[9]._stagenum = 1;
		st[9]._boss1 = -1;
		st[9]._boss2 = -1;
		st[9]._boss3 = -1;
		st[9]._extramon = -1;
		st[9]._reward = 1;

		//stage11
		st[10]._index = 10;
		st[10]._bosscount = 0;
		st[10]._basemon1 = 1;
		st[10]._basemon2 = 3;
		st[10]._mainmon = 2;
		st[10]._stagenum = 1;
		st[10]._boss1 = -1;
		st[10]._boss2 = -1;
		st[10]._boss3 = -1;
		st[10]._extramon = -1;
		st[10]._reward = 1;

		//stage12
		st[11]._index = 11;
		st[11]._bosscount = 1;
		st[11]._basemon1 = 3;
		st[11]._basemon2 = 4;
		st[11]._mainmon = 2;
		st[11]._stagenum = 1;
		st[11]._boss1 = 4;
		st[11]._boss2 = -1;
		st[11]._boss3 = -1;
		st[11]._extramon = -1;
		st[11]._reward = 102;

		//stage13
		st[12]._index = 12;
		st[12]._bosscount = 0;
		st[12]._basemon1 = 1;
		st[12]._basemon2 = 2;
		st[12]._mainmon = 6;
		st[12]._stagenum = 1;
		st[12]._boss1 = -1;
		st[12]._boss2 = -1;
		st[12]._boss3 = -1;
		st[12]._extramon = -1;
		st[12]._reward = 1;

		//stage14
		st[13]._index = 13;
		st[13]._bosscount = 0;
		st[13]._basemon1 = 1;
		st[13]._basemon2 = 2;
		st[13]._mainmon = 6;
		st[13]._stagenum = 1;
		st[13]._boss1 = -1;
		st[13]._boss2 = -1;
		st[13]._boss3 = -1;
		st[13]._extramon = -1;
		st[13]._reward = 1;

		//stage15
		st[14]._index = 14;
		st[14]._bosscount = 1;
		st[14]._basemon1 = 1;
		st[14]._basemon2 = 2;
		st[14]._mainmon = 6;
		st[14]._stagenum = 1;
		st[14]._boss1 = 5;
		st[14]._boss2 = -1;
		st[14]._boss3 = -1;
		st[14]._extramon = -1;
		st[14]._reward = 202;

		//stage16
		st[15]._index = 15;
		st[15]._bosscount = 0;
		st[15]._basemon1 = 1;
		st[15]._basemon2 = 3;
		st[15]._mainmon = 8;
		st[15]._stagenum = 1;
		st[15]._boss1 = -1;
		st[15]._boss2 = -1;
		st[15]._boss3 = -1;
		st[15]._extramon = -1;
		st[15]._reward = 1;

		//stage17
		st[16]._index = 16;
		st[16]._bosscount = 0;
		st[16]._basemon1 = 1;
		st[16]._basemon2 = 3;
		st[16]._mainmon = 8;
		st[16]._stagenum = 1;
		st[16]._boss1 = -1;
		st[16]._boss2 = -1;
		st[16]._boss3 = -1;
		st[16]._extramon = -1;
		st[16]._reward = 1;

		//stage18
		st[17]._index = 17;
		st[17]._bosscount = 1;
		st[17]._basemon1 = 1;
		st[17]._basemon2 = 3;
		st[17]._mainmon = 8;
		st[17]._stagenum = 1;
		st[17]._boss1 = 6;
		st[17]._boss2 = -1;
		st[17]._boss3 = -1;
		st[17]._extramon = -1;
		st[17]._reward = 103;

		//stage19
		st[18]._index = 18;
		st[18]._bosscount = 0;
		st[18]._basemon1 = 4;
		st[18]._basemon2 = 2;
		st[18]._mainmon = 7;
		st[18]._stagenum = 1;
		st[18]._boss1 = -1;
		st[18]._boss2 = -1;
		st[18]._boss3 = -1;
		st[18]._extramon = -1;
		st[18]._reward = 1;

		//stage20
		st[19]._index = 19;
		st[19]._bosscount = 0;
		st[19]._basemon1 = 4;
		st[19]._basemon2 = 2;
		st[19]._mainmon = 7;
		st[19]._stagenum = 1;
		st[19]._boss1 = -1;
		st[19]._boss2 = -1;
		st[19]._boss3 = -1;
		st[19]._extramon = -1;
		st[19]._reward = 1;

		//stage21
		st[20]._index = 20;
		st[20]._bosscount = 1;
		st[20]._basemon1 = 4;
		st[20]._basemon2 = 2;
		st[20]._mainmon = 7;
		st[20]._stagenum = 1;
		st[20]._boss1 = 7;
		st[20]._boss2 = -1;
		st[20]._boss3 = -1;
		st[20]._extramon = -1;
		st[20]._reward = 1;

		//stage22
		st[21]._index = 21;
		st[21]._bosscount = 0;
		st[21]._basemon1 = 3;
		st[21]._basemon2 = 2;
		st[21]._mainmon = 5;
		st[21]._stagenum = 1;
		st[21]._boss1 = -1;
		st[21]._boss2 = -1;
		st[21]._boss3 = -1;
		st[21]._extramon = -1;
		st[21]._reward = 1;

		//stage23
		st[22]._index = 22;
		st[22]._bosscount = 0;
		st[22]._basemon1 = 3;
		st[22]._basemon2 = 2;
		st[22]._mainmon = 5;
		st[22]._stagenum = 1;
		st[22]._boss1 = -1;
		st[22]._boss2 = -1;
		st[22]._boss3 = -1;
		st[22]._extramon = -1;
		st[22]._reward = 1;

		//stage24
		st[23]._index = 23;
		st[23]._bosscount = 1;
		st[23]._basemon1 = 3;
		st[23]._basemon2 = 2;
		st[23]._mainmon = 5;
		st[23]._stagenum = 1;
		st[23]._boss1 = 8;
		st[23]._boss2 = -1;
		st[23]._boss3 = -1;
		st[23]._extramon = -1;
		st[23]._reward = 104;

		//stage25
		st[24]._index = 24;
		st[24]._bosscount = 0;
		st[24]._basemon1 = 1;
		st[24]._basemon2 = 4;
		st[24]._mainmon = 11;
		st[24]._stagenum = 1;
		st[24]._boss1 = -1;
		st[24]._boss2 = -1;
		st[24]._boss3 = -1;
		st[24]._extramon = -1;
		st[24]._reward = 1;

		//stage26
		st[25]._index = 25;
		st[25]._bosscount = 0;
		st[25]._basemon1 = 1;
		st[25]._basemon2 = 4;
		st[25]._mainmon = 11;
		st[25]._stagenum = 1;
		st[25]._boss1 = -1;
		st[25]._boss2 = -1;
		st[25]._boss3 = -1;
		st[25]._extramon = -1;
		st[25]._reward = 1;

		//stage27
		st[26]._index = 26;
		st[26]._bosscount = 1;
		st[26]._basemon1 = 4;
		st[26]._basemon2 = 4;
		st[26]._mainmon = 11;
		st[26]._stagenum = 1;
		st[26]._boss1 = 9;
		st[26]._boss2 = -1;
		st[26]._boss3 = -1;
		st[26]._extramon = -1;
		st[26]._reward = 203;

		//stage28
		st[27]._index = 27;
		st[27]._bosscount = 0;
		st[27]._basemon1 = 1;
		st[27]._basemon2 = 8;
		st[27]._mainmon = 12;
		st[27]._stagenum = 1;
		st[27]._boss1 = -1;
		st[27]._boss2 = -1;
		st[27]._boss3 = -1;
		st[27]._extramon = -1;
		st[27]._reward = 1;

		//stage29
		st[28]._index = 28;
		st[28]._bosscount = 0;
		st[28]._basemon1 = 1;
		st[28]._basemon2 = 8;
		st[28]._mainmon = 12;
		st[28]._stagenum = 1;
		st[28]._boss1 = -1;
		st[28]._boss2 = -1;
		st[28]._boss3 = -1;
		st[28]._extramon = -1;
		st[28]._reward = 1;

		//stage30
		st[29]._index = 29;
		st[29]._bosscount = 1;
		st[29]._basemon1 = 1;
		st[29]._basemon2 = 8;
		st[29]._mainmon = 12;
		st[29]._stagenum = 1;
		st[29]._boss1 = 10;
		st[29]._boss2 = -1;
		st[29]._boss3 = -1;
		st[29]._extramon = -1;
		st[29]._reward = 105;

		//stage31_lv2
		st[30]._index = 30;
		st[30]._bosscount = 0;
		st[30]._basemon1 = 3;
		st[30]._basemon2 = 5;
		st[30]._mainmon = 13;
		st[30]._stagenum = 1;
		st[30]._boss1 = -1;
		st[30]._boss2 = -1;
		st[30]._boss3 = -1;
		st[30]._extramon = -1;
		st[30]._reward = 1;

		//stage32
		st[31]._index = 31;
		st[31]._bosscount = 0;
		st[31]._basemon1 = 3;
		st[31]._basemon2 = 5;
		st[31]._mainmon = 13;
		st[31]._stagenum = 1;
		st[31]._boss1 = -1;
		st[31]._boss2 = -1;
		st[31]._boss3 = -1;
		st[31]._extramon = -1;
		st[31]._reward = 1;

		//stage33
		st[32]._index = 32;
		st[32]._bosscount = 2;
		st[32]._basemon1 = 3;
		st[32]._basemon2 = 5;
		st[32]._mainmon = 13;
		st[32]._stagenum = 1;
		st[32]._boss1 = 1;
		st[32]._boss2 = 4;
		st[32]._boss3 = -1;
		st[32]._extramon = -1;
		st[32]._reward = 1;

		//stage34
		st[33]._index = 33;
		st[33]._bosscount = 0;
		st[33]._basemon1 = 2;
		st[33]._basemon2 = 6;
		st[33]._mainmon = 14;
		st[33]._stagenum = 1;
		st[33]._boss1 = -1;
		st[33]._boss2 = -1;
		st[33]._boss3 = -1;
		st[33]._extramon = -1;
		st[33]._reward = 1;

		//stage35
		st[34]._index = 34;
		st[34]._bosscount = 0;
		st[34]._basemon1 = 2;
		st[34]._basemon2 = 6;
		st[34]._mainmon = 14;
		st[34]._stagenum = 1;
		st[34]._boss1 = -1;
		st[34]._boss2 = -1;
		st[34]._boss3 = -1;
		st[34]._extramon = -1;
		st[34]._reward = 1;

		//stage36
		st[35]._index = 35;
		st[35]._bosscount = 2;
		st[35]._basemon1 = 2;
		st[35]._basemon2 = 6;
		st[35]._mainmon = 14;
		st[35]._stagenum = 1;
		st[35]._boss1 = 2;
		st[35]._boss2 = 1;
		st[35]._boss3 = -1;
		st[35]._extramon = -1;
		st[35]._reward = 106;

		//stage37
		st[36]._index = 36;
		st[36]._bosscount = 0;
		st[36]._basemon1 = 1;
		st[36]._basemon2 = 3;
		st[36]._mainmon = 9;
		st[36]._stagenum = 1;
		st[36]._boss1 = -1;
		st[36]._boss2 = -1;
		st[36]._boss3 = -1;
		st[36]._extramon = -1;
		st[36]._reward = 1;

		//stage38
		st[37]._index = 37;
		st[37]._bosscount = 0;
		st[37]._basemon1 = 1;
		st[37]._basemon2 = 3;
		st[37]._mainmon = 9;
		st[37]._stagenum = 1;
		st[37]._boss1 = -1;
		st[37]._boss2 = -1;
		st[37]._boss3 = -1;
		st[37]._extramon = -1;
		st[37]._reward = 1;

		//stage39
		st[38]._index = 38;
		st[38]._bosscount = 2;
		st[38]._basemon1 = 1;
		st[38]._basemon2 = 3;
		st[38]._mainmon = 9;
		st[38]._stagenum = 1;
		st[38]._boss1 = 3;
		st[38]._boss2 = 5;
		st[38]._boss3 = -1;
		st[38]._extramon = -1;
		st[38]._reward = 204;

		//stage40
		st[39]._index = 39;
		st[39]._bosscount = 0;
		st[39]._basemon1 = 0;
		st[39]._basemon2 = 2;
		st[39]._mainmon = 6;
		st[39]._stagenum = 1;
		st[39]._boss1 = -1;
		st[39]._boss2 = -1;
		st[39]._boss3 = -1;
		st[39]._extramon = -1;
		st[39]._reward = 1;

		//stage41
		st[40]._index = 40;
		st[40]._bosscount = 0;
		st[40]._basemon1 = 0;
		st[40]._basemon2 = 2;
		st[40]._mainmon = 6;
		st[40]._stagenum = 1;
		st[40]._boss1 = -1;
		st[40]._boss2 = -1;
		st[40]._boss3 = -1;
		st[40]._extramon = -1;
		st[40]._reward = 1;

		//stage42
		st[41]._index = 41;
		st[41]._bosscount = 2;
		st[41]._basemon1 = 0;
		st[41]._basemon2 = 2;
		st[41]._mainmon = 6;
		st[41]._stagenum = 1;
		st[41]._boss1 = 4;
		st[41]._boss2 = 1;
		st[41]._boss3 = -1;
		st[41]._extramon = -1;
		st[41]._reward = 107;

		//stage43
		st[42]._index = 42;
		st[42]._bosscount = 0;
		st[42]._basemon1 = 1;
		st[42]._basemon2 = 5;
		st[42]._mainmon = 8;
		st[42]._stagenum = 1;
		st[42]._boss1 = -1;
		st[42]._boss2 = -1;
		st[42]._boss3 = -1;
		st[42]._extramon = -1;
		st[42]._reward = 1;

		//stage44
		st[43]._index = 43;
		st[43]._bosscount = 0;
		st[43]._basemon1 = 1;
		st[43]._basemon2 = 5;
		st[43]._mainmon = 8;
		st[43]._stagenum = 1;
		st[43]._boss1 = -1;
		st[43]._boss2 = -1;
		st[43]._boss3 = -1;
		st[43]._extramon = -1;
		st[43]._reward = 1;

		//stage45
		st[44]._index = 44;
		st[44]._bosscount = 2;
		st[44]._basemon1 = 1;
		st[44]._basemon2 = 5;
		st[44]._mainmon = 8;
		st[44]._stagenum = 1;
		st[44]._boss1 = 5;
		st[44]._boss2 = 2;
		st[44]._boss3 = -1;
		st[44]._extramon = -1;
		st[44]._reward = 1;

		//stage46
		st[45]._index = 45;
		st[45]._bosscount = 0;
		st[45]._basemon1 = 1;
		st[45]._basemon2 = 3;
		st[45]._mainmon = 7;
		st[45]._stagenum = 1;
		st[45]._boss1 = -1;
		st[45]._boss2 = -1;
		st[45]._boss3 = -1;
		st[45]._extramon = -1;
		st[45]._reward = 1;

		//stage47
		st[46]._index = 46;
		st[46]._bosscount = 0;
		st[46]._basemon1 = 1;
		st[46]._basemon2 = 3;
		st[46]._mainmon = 7;
		st[46]._stagenum = 1;
		st[46]._boss1 = -1;
		st[46]._boss2 = -1;
		st[46]._boss3 = -1;
		st[46]._extramon = -1;
		st[46]._reward = 1;

		//stage48
		st[47]._index = 47;
		st[47]._bosscount = 2;
		st[47]._basemon1 = 1;
		st[47]._basemon2 = 3;
		st[47]._mainmon = 7;
		st[47]._stagenum = 1;
		st[47]._boss1 = 6;
		st[47]._boss2 = 3;
		st[47]._boss3 = -1;
		st[47]._extramon = -1;
		st[47]._reward = 108;

		//stage49
		st[48]._index = 48;
		st[48]._bosscount = 0;
		st[48]._basemon1 = 1;
		st[48]._basemon2 = 2;
		st[48]._mainmon = 5;
		st[48]._stagenum = 1;
		st[48]._boss1 = -1;
		st[48]._boss2 = -1;
		st[48]._boss3 = -1;
		st[48]._extramon = -1;
		st[48]._reward = 1;

		//stage50
		st[49]._index = 49;
		st[49]._bosscount = 0;
		st[49]._basemon1 = 1;
		st[49]._basemon2 = 2;
		st[49]._mainmon = 5;
		st[49]._stagenum = 1;
		st[49]._boss1 = -1;
		st[49]._boss2 = -1;
		st[49]._boss3 = -1;
		st[49]._extramon = -1;
		st[49]._reward = 1;

		//stage51
		st[50]._index = 50;
		st[50]._bosscount = 2;
		st[50]._basemon1 = 1;
		st[50]._basemon2 = 2;
		st[50]._mainmon = 5;
		st[50]._stagenum = 1;
		st[50]._boss1 = 9;
		st[50]._boss2 = 4;
		st[50]._boss3 = -1;
		st[50]._extramon = -1;
		st[50]._reward = 205;

		//stage52
		st[51]._index = 51;
		st[51]._bosscount = 0;
		st[51]._basemon1 = 1;
		st[51]._basemon2 = 3;
		st[51]._mainmon = 11;
		st[51]._stagenum = 1;
		st[51]._boss1 = -1;
		st[51]._boss2 = -1;
		st[51]._boss3 = -1;
		st[51]._extramon = -1;
		st[51]._reward = 1;

		//stage53
		st[52]._index = 52;
		st[52]._bosscount = 0;
		st[52]._basemon1 = 1;
		st[52]._basemon2 = 3;
		st[52]._mainmon = 11;
		st[52]._stagenum = 1;
		st[52]._boss1 = -1;
		st[52]._boss2 = -1;
		st[52]._boss3 = -1;
		st[52]._extramon = -1;
		st[52]._reward = 1;

		//stage54
		st[53]._index = 53;
		st[53]._bosscount = 2;
		st[53]._basemon1 = 1;
		st[53]._basemon2 = 3;
		st[53]._mainmon = 11;
		st[53]._stagenum = 1;
		st[53]._boss1 = 8;
		st[53]._boss2 = 5;
		st[53]._boss3 = -1;
		st[53]._extramon = -1;
		st[53]._reward = 109;

		//stage55
		st[54]._index = 54;
		st[54]._bosscount = 0;
		st[54]._basemon1 = 2;
		st[54]._basemon2 = 4;
		st[54]._mainmon = 12;
		st[54]._stagenum = 1;
		st[54]._boss1 = -1;
		st[54]._boss2 = -1;
		st[54]._boss3 = -1;
		st[54]._extramon = -1;
		st[54]._reward = 1;

		//stage56
		st[55]._index = 55;
		st[55]._bosscount = 0;
		st[55]._basemon1 = 2;
		st[55]._basemon2 = 4;
		st[55]._mainmon = 12;
		st[55]._stagenum = 1;
		st[55]._boss1 = -1;
		st[55]._boss2 = -1;
		st[55]._boss3 = -1;
		st[55]._extramon = -1;
		st[55]._reward = 1;

		//stage57
		st[56]._index = 56;
		st[56]._bosscount = 2;
		st[56]._basemon1 = 2;
		st[56]._basemon2 = 4;
		st[56]._mainmon = 12;
		st[56]._stagenum = 1;
		st[56]._boss1 = 7;
		st[56]._boss2 = 6;
		st[56]._boss3 = -1;
		st[56]._extramon = -1;
		st[56]._reward = 1;

		//stage58
		st[57]._index = 57;
		st[57]._bosscount = 0;
		st[57]._basemon1 = 3;
		st[57]._basemon2 = 2;
		st[57]._mainmon = 13;
		st[57]._stagenum = 1;
		st[57]._boss1 = -1;
		st[57]._boss2 = -1;
		st[57]._boss3 = -1;
		st[57]._extramon = -1;
		st[57]._reward = 1;

		//stage59
		st[58]._index = 58;
		st[58]._bosscount = 0;
		st[58]._basemon1 = 3;
		st[58]._basemon2 = 2;
		st[58]._mainmon = 13;
		st[58]._stagenum = 1;
		st[58]._boss1 = -1;
		st[58]._boss2 = -1;
		st[58]._boss3 = -1;
		st[58]._extramon = -1;
		st[58]._reward = 1;

		//stage60
		st[59]._index = 59;
		st[59]._bosscount = 2;
		st[59]._basemon1 = 3;
		st[59]._basemon2 = 2;
		st[59]._mainmon = 13;
		st[59]._stagenum = 1;
		st[59]._boss1 = 10;
		st[59]._boss2 = 7;
		st[59]._boss3 = -1;
		st[59]._extramon = -1;
		st[59]._reward = 110;

		//stage61_lv3
		st[60]._index = 60;
		st[60]._bosscount = 0;
		st[60]._basemon1 = 1;
		st[60]._basemon2 = 4;
		st[60]._mainmon = 14;
		st[60]._stagenum = 1;
		st[60]._boss1 = -1;
		st[60]._boss2 = -1;
		st[60]._boss3 = -1;
		st[60]._extramon = -1;
		st[60]._reward = 1;

		//stage62
		st[61]._index = 61;
		st[61]._bosscount = 0;
		st[61]._basemon1 = 1;
		st[61]._basemon2 = 4;
		st[61]._mainmon = 14;
		st[61]._stagenum = 1;
		st[61]._boss1 = -1;
		st[61]._boss2 = -1;
		st[61]._boss3 = -1;
		st[61]._extramon = -1;
		st[61]._reward = 1;

		//stage63
		st[62]._index = 62;
		st[62]._bosscount = 2;
		st[62]._basemon1 = 1;
		st[62]._basemon2 = 4;
		st[62]._mainmon = 14;
		st[62]._stagenum = 1;
		st[62]._boss1 = 1;
		st[62]._boss2 = 8;
		st[62]._boss3 = -1;
		st[62]._extramon = -1;
		st[62]._reward = 206;

		//stage64
		st[63]._index = 63;
		st[63]._bosscount = 0;
		st[63]._basemon1 = 1;
		st[63]._basemon2 = 8;
		st[63]._mainmon = 9;
		st[63]._stagenum = 1;
		st[63]._boss1 = -1;
		st[63]._boss2 = -1;
		st[63]._boss3 = -1;
		st[63]._extramon = -1;
		st[63]._reward = 1;

		//stage65
		st[64]._index = 64;
		st[64]._bosscount = 0;
		st[64]._basemon1 = 1;
		st[64]._basemon2 = 8;
		st[64]._mainmon = 9;
		st[64]._stagenum = 1;
		st[64]._boss1 = -1;
		st[64]._boss2 = -1;
		st[64]._boss3 = -1;
		st[64]._extramon = -1;
		st[64]._reward = 1;

		//stage66
		st[65]._index = 65;
		st[65]._bosscount = 2;
		st[65]._basemon1 = 1;
		st[65]._basemon2 = 8;
		st[65]._mainmon = 9;
		st[65]._stagenum = 1;
		st[65]._boss1 = 2;
		st[65]._boss2 = 9;
		st[65]._boss3 = -1;
		st[65]._extramon = -1;
		st[65]._reward = 111;

		//stage67
		st[66]._index = 66;
		st[66]._bosscount = 0;
		st[66]._basemon1 = 3;
		st[66]._basemon2 = 5;
		st[66]._mainmon = 6;
		st[66]._stagenum = 1;
		st[66]._boss1 = -1;
		st[66]._boss2 = -1;
		st[66]._boss3 = -1;
		st[66]._extramon = -1;
		st[66]._reward = 1;

		//stage68
		st[67]._index = 67;
		st[67]._bosscount = 0;
		st[67]._basemon1 = 3;
		st[67]._basemon2 = 5;
		st[67]._mainmon = 6;
		st[67]._stagenum = 1;
		st[67]._boss1 = -1;
		st[67]._boss2 = -1;
		st[67]._boss3 = -1;
		st[67]._extramon = -1;
		st[67]._reward = 1;

		//stage69_b
		st[68]._index = 68;
		st[68]._bosscount = 3;
		st[68]._basemon1 = 3;
		st[68]._basemon2 = 5;
		st[68]._mainmon = 6;
		st[68]._stagenum = 1;
		st[68]._boss1 = 3;
		st[68]._boss2 = 1;
		st[68]._boss3 = 5;
		st[68]._extramon = -1;
		st[68]._reward = 1;

		//stage70
		st[69]._index = 69;
		st[69]._bosscount = 0;
		st[69]._basemon1 = 2;
		st[69]._basemon2 = 6;
		st[69]._mainmon = 7;
		st[69]._stagenum = 1;
		st[69]._boss1 = -1;
		st[69]._boss2 = -1;
		st[69]._boss3 = -1;
		st[69]._extramon = -1;
		st[69]._reward = 1;

		//stage71
		st[70]._index = 70;
		st[70]._bosscount = 0;
		st[70]._basemon1 = 2;
		st[70]._basemon2 = 6;
		st[70]._mainmon = 7;
		st[70]._stagenum = 1;
		st[70]._boss1 = -1;
		st[70]._boss2 = -1;
		st[70]._boss3 = -1;
		st[70]._extramon = -1;
		st[70]._reward = 1;

		//stage72_b
		st[71]._index = 71;
		st[71]._bosscount = 3;
		st[71]._basemon1 = 2;
		st[71]._basemon2 = 6;
		st[71]._mainmon = 7;
		st[71]._stagenum = 1;
		st[71]._boss1 = 4;
		st[71]._boss2 = 2;
		st[71]._boss3 = 8;
		st[71]._extramon = -1;
		st[71]._reward = 112;

		//stage73
		st[72]._index = 72;
		st[72]._bosscount = 0;
		st[72]._basemon1 = 4;
		st[72]._basemon2 = 6;
		st[72]._mainmon = 5;
		st[72]._stagenum = 1;
		st[72]._boss1 = -1;
		st[72]._boss2 = -1;
		st[72]._boss3 = -1;
		st[72]._extramon = -1;
		st[72]._reward = 1;

		//stage74
		st[73]._index = 73;
		st[73]._bosscount = 0;
		st[73]._basemon1 = 4;
		st[73]._basemon2 = 6;
		st[73]._mainmon = 5;
		st[73]._stagenum = 1;
		st[73]._boss1 = -1;
		st[73]._boss2 = -1;
		st[73]._boss3 = -1;
		st[73]._extramon = -1;
		st[73]._reward = 1;

		//stage75_b
		st[74]._index = 74;
		st[74]._bosscount = 3;
		st[74]._basemon1 = 4;
		st[74]._basemon2 = 6;
		st[74]._mainmon = 5;
		st[74]._stagenum = 1;
		st[74]._boss1 = 5;
		st[74]._boss2 = 3;
		st[74]._boss3 = 2;
		st[74]._extramon = -1;
		st[74]._reward = 207;

		//stage76
		st[75]._index = 75;
		st[75]._bosscount = 0;
		st[75]._basemon1 = 5;
		st[75]._basemon2 = 7;
		st[75]._mainmon = 11;
		st[75]._stagenum = 1;
		st[75]._boss1 = -1;
		st[75]._boss2 = -1;
		st[75]._boss3 = -1;
		st[75]._extramon = -1;
		st[75]._reward = 1;

		//stage77
		st[76]._index = 76;
		st[76]._bosscount = 0;
		st[76]._basemon1 = 5;
		st[76]._basemon2 = 7;
		st[76]._mainmon = 11;
		st[76]._stagenum = 1;
		st[76]._boss1 = -1;
		st[76]._boss2 = -1;
		st[76]._boss3 = -1;
		st[76]._extramon = -1;
		st[76]._reward = 1;

		//stage78_b
		st[77]._index = 77;
		st[77]._bosscount = 3;
		st[77]._basemon1 = 5;
		st[77]._basemon2 = 7;
		st[77]._mainmon = 11;
		st[77]._stagenum = 1;
		st[77]._boss1 = 6;
		st[77]._boss2 = 1;
		st[77]._boss3 = 2;
		st[77]._extramon = -1;
		st[77]._reward = 113;

		//stage79
		st[78]._index = 78;
		st[78]._bosscount = 0;
		st[78]._basemon1 = 7;
		st[78]._basemon2 = 11;
		st[78]._mainmon = 12;
		st[78]._stagenum = 1;
		st[78]._boss1 = -1;
		st[78]._boss2 = -1;
		st[78]._boss3 = -1;
		st[78]._extramon = -1;
		st[78]._reward = 1;

		//stage80
		st[79]._index = 79;
		st[79]._bosscount = 0;
		st[79]._basemon1 = 7;
		st[79]._basemon2 = 11;
		st[79]._mainmon = 12;
		st[79]._stagenum = 1;
		st[79]._boss1 = -1;
		st[79]._boss2 = -1;
		st[79]._boss3 = -1;
		st[79]._extramon = -1;
		st[79]._reward = 1;

		//stage81_b
		st[80]._index = 80;
		st[80]._bosscount = 3;
		st[80]._basemon1 = 7;
		st[80]._basemon2 = 11;
		st[80]._mainmon = 12;
		st[80]._stagenum = 1;
		st[80]._boss1 = 7;
		st[80]._boss2 = 3;
		st[80]._boss3 = 5;
		st[80]._extramon = -1;
		st[80]._reward = 1;

		//stage82
		st[81]._index = 81;
		st[81]._bosscount = 0;
		st[81]._basemon1 = 6;
		st[81]._basemon2 = 12;
		st[81]._mainmon = 13;
		st[81]._stagenum = 1;
		st[81]._boss1 = -1;
		st[81]._boss2 = -1;
		st[81]._boss3 = -1;
		st[81]._extramon = -1;
		st[81]._reward = 1;

		//stage83
		st[82]._index = 82;
		st[82]._bosscount = 0;
		st[82]._basemon1 = 6;
		st[82]._basemon2 = 12;
		st[82]._mainmon = 13;
		st[82]._stagenum = 1;
		st[82]._boss1 = -1;
		st[82]._boss2 = -1;
		st[82]._boss3 = -1;
		st[82]._extramon = -1;
		st[82]._reward = 1;

		//stage84_b
		st[83]._index = 83;
		st[83]._bosscount = 3;
		st[83]._basemon1 = 6;
		st[83]._basemon2 = 12;
		st[83]._mainmon = 13;
		st[83]._stagenum = 1;
		st[83]._boss1 = 8;
		st[83]._boss2 = 4;
		st[83]._boss3 = 2;
		st[83]._extramon = -1;
		st[83]._reward = 114;

		//stage85
		st[84]._index = 84;
		st[84]._bosscount = 0;
		st[84]._basemon1 = 2;
		st[84]._basemon2 = 11;
		st[84]._mainmon = 14;
		st[84]._stagenum = 1;
		st[84]._boss1 = -1;
		st[84]._boss2 = -1;
		st[84]._boss3 = -1;
		st[84]._extramon = -1;
		st[84]._reward = 1;

		//stage86
		st[85]._index = 85;
		st[85]._bosscount = 0;
		st[85]._basemon1 = 2;
		st[85]._basemon2 = 11;
		st[85]._mainmon = 14;
		st[85]._stagenum = 1;
		st[85]._boss1 = -1;
		st[85]._boss2 = -1;
		st[85]._boss3 = -1;
		st[85]._extramon = -1;
		st[85]._reward = 1;

		//stage87_b
		st[86]._index = 86;
		st[86]._bosscount = 3;
		st[86]._basemon1 = 2;
		st[86]._basemon2 = 11;
		st[86]._mainmon = 14;
		st[86]._stagenum = 1;
		st[86]._boss1 = 9;
		st[86]._boss2 = 6;
		st[86]._boss3 = 7;
		st[86]._extramon = -1;
		st[86]._reward = 208;

		//stage88
		st[87]._index = 87;
		st[87]._bosscount = 0;
		st[87]._basemon1 = 5;
		st[87]._basemon2 = 9;
		st[87]._mainmon = 14;
		st[87]._stagenum = 1;
		st[87]._boss1 = -1;
		st[87]._boss2 = -1;
		st[87]._boss3 = -1;
		st[87]._extramon = -1;
		st[87]._reward = 1;

		//stage89
		st[88]._index = 88;
		st[88]._bosscount = 0;
		st[88]._basemon1 = 5;
		st[88]._basemon2 = 9;
		st[88]._mainmon = 14;
		st[88]._stagenum = 1;
		st[88]._boss1 = -1;
		st[88]._boss2 = -1;
		st[88]._boss3 = -1;
		st[88]._extramon = -1;
		st[88]._reward = 1;

		//stage90_b
		st[89]._index = 89;
		st[89]._bosscount = 1;
		st[89]._basemon1 = 5;
		st[89]._basemon2 = 9;
		st[89]._mainmon = 14;
		st[89]._stagenum = 1;
		st[89]._boss1 = 11;
		st[89]._boss2 = -1;
		st[89]._boss3 = -1;
		st[89]._extramon = -1;
		st[89]._reward = 115;
	}

}
