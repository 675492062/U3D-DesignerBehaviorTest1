using UnityEngine;
using System.Collections;

public  struct scenario
{
	public string _chaimg;
	public bool _mirror;
	public short _pos;
	public short _showef;
	public short _txtidx;
	public short _extraimg;
}

public class DB_Scenario : MonoBehaviour {
	

	public scenario[,] sn = new scenario[91,14];
	
	void Awake()
	{
		///*0*/
		sn[0,0]._chaimg = "cc_bro0";
		sn[0,0]._mirror = false;
		sn[0,0]._pos = 0;
		sn[0,0]._showef = 1;
		sn[0,0]._txtidx = 1;
		sn[0,0]._extraimg = 0;

		sn[0,1]._chaimg = "cc_cha2";
		sn[0,1]._mirror = false;
		sn[0,1]._pos = 1;
		sn[0,1]._showef = 1;
		sn[0,1]._txtidx = 2;
		sn[0,1]._extraimg = 0;

		sn[0,2]._chaimg = "cc_bro0";
		sn[0,2]._mirror = false;
		sn[0,2]._pos = 0;
		sn[0,2]._showef = 0;
		sn[0,2]._txtidx = 3;
		sn[0,2]._extraimg = 1001;

		sn[0,3]._chaimg = "cc_cha1";
		sn[0,3]._mirror = false;
		sn[0,3]._pos = 1;
		sn[0,3]._showef = 0;
		sn[0,3]._txtidx = 4;
		sn[0,3]._extraimg = 0;

		sn[0,4]._chaimg = "cc_skill";
		sn[0,4]._mirror = false;
		sn[0,4]._pos = 0;
		sn[0,4]._showef = 1;
		sn[0,4]._txtidx = 5;
		sn[0,4]._extraimg = 0;

		sn[0,5]._chaimg = "cc_cha4";
		sn[0,5]._mirror = false;
		sn[0,5]._pos = 1;
		sn[0,5]._showef = 2;
		sn[0,5]._txtidx = 6;
		sn[0,5]._extraimg = 0;

		sn[0,6]._chaimg = "cc_skill";
		sn[0,6]._mirror = false;
		sn[0,6]._pos = 0;
		sn[0,6]._showef = 0;
		sn[0,6]._txtidx = 7;
		sn[0,6]._extraimg = 0;

		sn[0,7]._chaimg = "cc_cha2";
		sn[0,7]._mirror = false;
		sn[0,7]._pos = 1;
		sn[0,7]._showef = 0;
		sn[0,7]._txtidx = 8;
		sn[0,7]._extraimg = 0;

		sn[0,8]._chaimg = "cc_skill";
		sn[0,8]._mirror = false;
		sn[0,8]._pos = 0;
		sn[0,8]._showef = 0;
		sn[0,8]._txtidx = 9;
		sn[0,8]._extraimg = 0;

		sn[0,9]._chaimg = "cc_cha1";
		sn[0,9]._mirror = false;
		sn[0,9]._pos = 1;
		sn[0,9]._showef = 0;
		sn[0,9]._txtidx = 10;
		sn[0,9]._extraimg = 0;

		sn[0,10]._chaimg = "cc_bro0";
		sn[0,10]._mirror = false;
		sn[0,10]._pos = 0;
		sn[0,10]._showef = 1;
		sn[0,10]._txtidx = 11;
		sn[0,10]._extraimg = 0;

		sn[0,11]._chaimg = "cc_skill";
		sn[0,11]._mirror = false;
		sn[0,11]._pos = 0;
		sn[0,11]._showef = 1;
		sn[0,11]._txtidx = 12;
		sn[0,11]._extraimg = 0;

		sn[0,12]._chaimg = "cc_cha1";
		sn[0,12]._mirror = false;
		sn[0,12]._pos = 1;
		sn[0,12]._showef = 4;
		sn[0,12]._txtidx = 13;
		sn[0,12]._extraimg = 212;


		///*1-1*/
		sn[1,0]._chaimg = "cc_cha1";
		sn[1,0]._mirror = false;
		sn[1,0]._pos = 1;
		sn[1,0]._showef = 1;
		sn[1,0]._txtidx = 14;
		sn[1,0]._extraimg = 0;

		sn[1,1]._chaimg = "cc_archive";
		sn[1,1]._mirror = false;
		sn[1,1]._pos = 0;
		sn[1,1]._showef = 1;
		sn[1,1]._txtidx = 15;
		sn[1,1]._extraimg = 0;

		sn[1,2]._chaimg = "cc_cha0";
		sn[1,2]._mirror = false;
		sn[1,2]._pos = 1;
		sn[1,2]._showef = 0;
		sn[1,2]._txtidx = 16;
		sn[1,2]._extraimg = 0;

		sn[1,3]._chaimg = "cc_archive";
		sn[1,3]._mirror = false;
		sn[1,3]._pos = 0;
		sn[1,3]._showef = 0;
		sn[1,3]._txtidx = 17;
		sn[1,3]._extraimg = 0;

		sn[1,4]._chaimg = "cc_cha3";
		sn[1,4]._mirror = false;
		sn[1,4]._pos = 1;
		sn[1,4]._showef = 0;
		sn[1,4]._txtidx = 18;
		sn[1,4]._extraimg = 0;

		sn[1,5]._chaimg = "cc_archive";
		sn[1,5]._mirror = false;
		sn[1,5]._pos = 0;
		sn[1,5]._showef = 0;
		sn[1,5]._txtidx = 19;
		sn[1,5]._extraimg = 0;

		sn[1,6]._chaimg = "cc_cha1";
		sn[1,6]._mirror = false;
		sn[1,6]._pos = 1;
		sn[1,6]._showef = 4;
		sn[1,6]._txtidx = 20;
		sn[1,6]._extraimg = 217;


		///*1-2*/
		sn[2,0]._chaimg = "cc_bro0";
		sn[2,0]._mirror = false;
		sn[2,0]._pos = 0;
		sn[2,0]._showef = 1;
		sn[2,0]._txtidx = 21;
		sn[2,0]._extraimg = 0;

		sn[2,1]._chaimg = "cc_cha0";
		sn[2,1]._mirror = false;
		sn[2,1]._pos = 1;
		sn[2,1]._showef = 1;
		sn[2,1]._txtidx = 22;
		sn[2,1]._extraimg = 0;

		sn[2,2]._chaimg = "cc_bro0";
		sn[2,2]._mirror = false;
		sn[2,2]._pos = 0;
		sn[2,2]._showef = 0;
		sn[2,2]._txtidx = 23;
		sn[2,2]._extraimg = 0;

		sn[2,3]._chaimg = "cc_cha3";
		sn[2,3]._mirror = false;
		sn[2,3]._pos = 1;
		sn[2,3]._showef = 0;
		sn[2,3]._txtidx = 24;
		sn[2,3]._extraimg = 0;

		sn[2,4]._chaimg = "cc_bro0";
		sn[2,4]._mirror = false;
		sn[2,4]._pos = 0;
		sn[2,4]._showef = 0;
		sn[2,4]._txtidx = 25;
		sn[2,4]._extraimg = 0;

		sn[2,5]._chaimg = "cc_cha3";
		sn[2,5]._mirror = false;
		sn[2,5]._pos = 1;
		sn[2,5]._showef = 0;
		sn[2,5]._txtidx = 26;
		sn[2,5]._extraimg = 0;

		sn[2,6]._chaimg = "cc_bro0";
		sn[2,6]._mirror = false;
		sn[2,6]._pos = 0;
		sn[2,6]._showef = 0;
		sn[2,6]._txtidx = 27;
		sn[2,6]._extraimg = 0;

		sn[2,7]._chaimg = "cc_cha2";
		sn[2,7]._mirror = false;
		sn[2,7]._pos = 1;
		sn[2,7]._showef = 4;
		sn[2,7]._txtidx = 28;
		sn[2,7]._extraimg = 211;


		///*1-3*/
		sn[3,0]._chaimg = "cc_cha3";
		sn[3,0]._mirror = false;
		sn[3,0]._pos = 1;
		sn[3,0]._showef = 1;
		sn[3,0]._txtidx = 29;
		sn[3,0]._extraimg = 0;

		sn[3,1]._chaimg = "cc_shop";
		sn[3,1]._mirror = false;
		sn[3,1]._pos = 0;
		sn[3,1]._showef = 1;
		sn[3,1]._txtidx = 30;
		sn[3,1]._extraimg = 0;

		sn[3,2]._chaimg = "cc_cha3";
		sn[3,2]._mirror = false;
		sn[3,2]._pos = 1;
		sn[3,2]._showef = 0;
		sn[3,2]._txtidx = 31;
		sn[3,2]._extraimg = 0;

		sn[3,3]._chaimg = "cc_shop";
		sn[3,3]._mirror = false;
		sn[3,3]._pos = 0;
		sn[3,3]._showef = 0;
		sn[3,3]._txtidx = 32;
		sn[3,3]._extraimg = 0;

		sn[3,4]._chaimg = "cc_cha3";
		sn[3,4]._mirror = false;
		sn[3,4]._pos = 1;
		sn[3,4]._showef = 0;
		sn[3,4]._txtidx = 33;
		sn[3,4]._extraimg = 0;

		sn[3,5]._chaimg = "cc_shop";
		sn[3,5]._mirror = false;
		sn[3,5]._pos = 0;
		sn[3,5]._showef = 0;
		sn[3,5]._txtidx = 34;
		sn[3,5]._extraimg = 1002;

		sn[3,6]._chaimg = "cc_cha0";
		sn[3,6]._mirror = false;
		sn[3,6]._pos = 1;
		sn[3,6]._showef = 0;
		sn[3,6]._txtidx = 35;
		sn[3,6]._extraimg = 0;

		sn[3,7]._chaimg = "cc_shop";
		sn[3,7]._mirror = false;
		sn[3,7]._pos = 0;
		sn[3,7]._showef = 0;
		sn[3,7]._txtidx = 36;
		sn[3,7]._extraimg = 0;

		sn[3,8]._chaimg = "cc_cha2";
		sn[3,8]._mirror = false;
		sn[3,8]._pos = 1;
		sn[3,8]._showef = 4;
		sn[3,8]._txtidx = 37;
		sn[3,8]._extraimg = 213;


		///*2-1*/
		sn[4,0]._chaimg = "cc_cha0";
		sn[4,0]._mirror = false;
		sn[4,0]._pos = 1;
		sn[4,0]._showef = 1;
		sn[4,0]._txtidx = 38;
		sn[4,0]._extraimg = 0;

		sn[4,1]._chaimg = "cc_bro0";
		sn[4,1]._mirror = false;
		sn[4,1]._pos = 0;
		sn[4,1]._showef = 1;
		sn[4,1]._txtidx = 39;
		sn[4,1]._extraimg = 0;

		sn[4,2]._chaimg = "cc_cha1";
		sn[4,2]._mirror = false;
		sn[4,2]._pos = 1;
		sn[4,2]._showef = 0;
		sn[4,2]._txtidx = 40;
		sn[4,2]._extraimg = 0;

		sn[4,3]._chaimg = "cc_shop";
		sn[4,3]._mirror = false;
		sn[4,3]._pos = 0;
		sn[4,3]._showef = 1;
		sn[4,3]._txtidx = 41;
		sn[4,3]._extraimg = 0;

		sn[4,4]._chaimg = "cc_pet";
		sn[4,4]._mirror = false;
		sn[4,4]._pos = 0;
		sn[4,4]._showef = 1;
		sn[4,4]._txtidx = 42;
		sn[4,4]._extraimg = 0;

		sn[4,5]._chaimg = "cc_archive";
		sn[4,5]._mirror = false;
		sn[4,5]._pos = 0;
		sn[4,5]._showef = 1;
		sn[4,5]._txtidx = 43;
		sn[4,5]._extraimg = 0;

		sn[4,6]._chaimg = "cc_cha2";
		sn[4,6]._mirror = false;
		sn[4,6]._pos = 1;
		sn[4,6]._showef = 4;
		sn[4,6]._txtidx = 44;
		sn[4,6]._extraimg = 216;


		///*2-2*/
		sn[5,0]._chaimg = "cc_bro0";
		sn[5,0]._mirror = false;
		sn[5,0]._pos = 0;
		sn[5,0]._showef = 1;
		sn[5,0]._txtidx = 45;
		sn[5,0]._extraimg = 0;

		sn[5,1]._chaimg = "cc_cha0";
		sn[5,1]._mirror = false;
		sn[5,1]._pos = 1;
		sn[5,1]._showef = 1;
		sn[5,1]._txtidx = 46;
		sn[5,1]._extraimg = 0;

		sn[5,2]._chaimg = "cc_bro0";
		sn[5,2]._mirror = false;
		sn[5,2]._pos = 0;
		sn[5,2]._showef = 0;
		sn[5,2]._txtidx = 47;
		sn[5,2]._extraimg = 0;

		sn[5,3]._chaimg = "cc_skill";
		sn[5,3]._mirror = false;
		sn[5,3]._pos = 0;
		sn[5,3]._showef = 1;
		sn[5,3]._txtidx = 48;
		sn[5,3]._extraimg = 0;

		sn[5,4]._chaimg = "cc_cha1";
		sn[5,4]._mirror = false;
		sn[5,4]._pos = 1;
		sn[5,4]._showef = 0;
		sn[5,4]._txtidx = 49;
		sn[5,4]._extraimg = 0;

		sn[5,5]._chaimg = "cc_bro0";
		sn[5,5]._mirror = false;
		sn[5,5]._pos = 0;
		sn[5,5]._showef = 1;
		sn[5,5]._txtidx = 50;
		sn[5,5]._extraimg = 0;

		sn[5,6]._chaimg = "cc_skill";
		sn[5,6]._mirror = false;
		sn[5,6]._pos = 0;
		sn[5,6]._showef = 1;
		sn[5,6]._txtidx = 51;
		sn[5,6]._extraimg = 0;

		sn[5,7]._chaimg = "cc_cha4";
		sn[5,7]._mirror = false;
		sn[5,7]._pos = 1;
		sn[5,7]._showef = 4;
		sn[5,7]._txtidx = 52;
		sn[5,7]._extraimg = 218;


		///*2-3*/
		sn[6,0]._chaimg = "cc_pet";
		sn[6,0]._mirror = false;
		sn[6,0]._pos = 0;
		sn[6,0]._showef = 1;
		sn[6,0]._txtidx = 53;
		sn[6,0]._extraimg = 1003;

		sn[6,1]._chaimg = "cc_cha0";
		sn[6,1]._mirror = false;
		sn[6,1]._pos = 1;
		sn[6,1]._showef = 1;
		sn[6,1]._txtidx = 54;
		sn[6,1]._extraimg = 0;

		sn[6,2]._chaimg = "cc_pet";
		sn[6,2]._mirror = false;
		sn[6,2]._pos = 0;
		sn[6,2]._showef = 0;
		sn[6,2]._txtidx = 55;
		sn[6,2]._extraimg = 0;

		sn[6,3]._chaimg = "cc_cha1";
		sn[6,3]._mirror = false;
		sn[6,3]._pos = 1;
		sn[6,3]._showef = 0;
		sn[6,3]._txtidx = 56;
		sn[6,3]._extraimg = 0;

		sn[6,4]._chaimg = "cc_pet";
		sn[6,4]._mirror = false;
		sn[6,4]._pos = 0;
		sn[6,4]._showef = 0;
		sn[6,4]._txtidx = 57;
		sn[6,4]._extraimg = 0;

		sn[6,5]._chaimg = "cc_pet";
		sn[6,5]._mirror = false;
		sn[6,5]._pos = 0;
		sn[6,5]._showef = 0;
		sn[6,5]._txtidx = 58;
		sn[6,5]._extraimg = 0;

		sn[6,6]._chaimg = "cc_cha1";
		sn[6,6]._mirror = false;
		sn[6,6]._pos = 1;
		sn[6,6]._showef = 4;
		sn[6,6]._txtidx = 59;
		sn[6,6]._extraimg = 214;


		///*3-1*/
		sn[7,0]._chaimg = "cc_bro0";
		sn[7,0]._mirror = false;
		sn[7,0]._pos = 0;
		sn[7,0]._showef = 1;
		sn[7,0]._txtidx = 60;
		sn[7,0]._extraimg = 0;

		sn[7,1]._chaimg = "cc_cha0";
		sn[7,1]._mirror = false;
		sn[7,1]._pos = 1;
		sn[7,1]._showef = 1;
		sn[7,1]._txtidx = 61;
		sn[7,1]._extraimg = 0;

		sn[7,2]._chaimg = "cc_bro0";
		sn[7,2]._mirror = false;
		sn[7,2]._pos = 0;
		sn[7,2]._showef = 0;
		sn[7,2]._txtidx = 62;
		sn[7,2]._extraimg = 1005;

		sn[7,3]._chaimg = "cc_cha1";
		sn[7,3]._mirror = false;
		sn[7,3]._pos = 1;
		sn[7,3]._showef = 0;
		sn[7,3]._txtidx = 63;
		sn[7,3]._extraimg = 0;

		sn[7,4]._chaimg = "cc_bro0";
		sn[7,4]._mirror = false;
		sn[7,4]._pos = 0;
		sn[7,4]._showef = 4;
		sn[7,4]._txtidx = 64;
		sn[7,4]._extraimg = 0;


		///*3-2*/
		sn[8,0]._chaimg = "cc_archive";
		sn[8,0]._mirror = false;
		sn[8,0]._pos = 0;
		sn[8,0]._showef = 1;
		sn[8,0]._txtidx = 65;
		sn[8,0]._extraimg = 1004;

		sn[8,1]._chaimg = "cc_cha1";
		sn[8,1]._mirror = false;
		sn[8,1]._pos = 1;
		sn[8,1]._showef = 1;
		sn[8,1]._txtidx = 66;
		sn[8,1]._extraimg = 0;

		sn[8,2]._chaimg = "cc_archive";
		sn[8,2]._mirror = false;
		sn[8,2]._pos = 0;
		sn[8,2]._showef = 0;
		sn[8,2]._txtidx = 67;
		sn[8,2]._extraimg = 0;

		sn[8,3]._chaimg = "cc_cha1";
		sn[8,3]._mirror = false;
		sn[8,3]._pos = 1;
		sn[8,3]._showef = 0;
		sn[8,3]._txtidx = 68;
		sn[8,3]._extraimg = 0;

		sn[8,4]._chaimg = "cc_archive";
		sn[8,4]._mirror = false;
		sn[8,4]._pos = 0;
		sn[8,4]._showef = 0;
		sn[8,4]._txtidx = 69;
		sn[8,4]._extraimg = 0;

		sn[8,5]._chaimg = "cc_cha3";
		sn[8,5]._mirror = false;
		sn[8,5]._pos = 1;
		sn[8,5]._showef = 0;
		sn[8,5]._txtidx = 70;
		sn[8,5]._extraimg = 0;

		sn[8,6]._chaimg = "cc_archive";
		sn[8,6]._mirror = false;
		sn[8,6]._pos = 0;
		sn[8,6]._showef = 4;
		sn[8,6]._txtidx = 71;
		sn[8,6]._extraimg = 215;


		///*3-3*/
		sn[9,0]._chaimg = "cc_cha0";
		sn[9,0]._mirror = false;
		sn[9,0]._pos = 1;
		sn[9,0]._showef = 1;
		sn[9,0]._txtidx = 72;
		sn[9,0]._extraimg = 0;

		sn[9,1]._chaimg = "cc_pet";
		sn[9,1]._mirror = false;
		sn[9,1]._pos = 0;
		sn[9,1]._showef = 1;
		sn[9,1]._txtidx = 73;
		sn[9,1]._extraimg = 0;

		sn[9,2]._chaimg = "cc_pet";
		sn[9,2]._mirror = false;
		sn[9,2]._pos = 0;
		sn[9,2]._showef = 0;
		sn[9,2]._txtidx = 74;
		sn[9,2]._extraimg = 0;

		sn[9,3]._chaimg = "cc_cha0";
		sn[9,3]._mirror = false;
		sn[9,3]._pos = 1;
		sn[9,3]._showef = 0;
		sn[9,3]._txtidx = 75;
		sn[9,3]._extraimg = 0;

		sn[9,4]._chaimg = "cc_pet";
		sn[9,4]._mirror = false;
		sn[9,4]._pos = 0;
		sn[9,4]._showef = 0;
		sn[9,4]._txtidx = 76;
		sn[9,4]._extraimg = 0;

		sn[9,5]._chaimg = "cc_cha3";
		sn[9,5]._mirror = false;
		sn[9,5]._pos = 1;
		sn[9,5]._showef = 0;
		sn[9,5]._txtidx = 77;
		sn[9,5]._extraimg = 0;

		sn[9,6]._chaimg = "cc_pet";
		sn[9,6]._mirror = false;
		sn[9,6]._pos = 0;
		sn[9,6]._showef = 4;
		sn[9,6]._txtidx = 78;
		sn[9,6]._extraimg = 0;


		///*4-1*/
		sn[10,0]._chaimg = "cc_bro0";
		sn[10,0]._mirror = false;
		sn[10,0]._pos = 0;
		sn[10,0]._showef = 1;
		sn[10,0]._txtidx = 79;
		sn[10,0]._extraimg = 0;

		sn[10,1]._chaimg = "cc_cha0";
		sn[10,1]._mirror = false;
		sn[10,1]._pos = 1;
		sn[10,1]._showef = 1;
		sn[10,1]._txtidx = 80;
		sn[10,1]._extraimg = 0;

		sn[10,2]._chaimg = "cc_bro0";
		sn[10,2]._mirror = false;
		sn[10,2]._pos = 0;
		sn[10,2]._showef = 0;
		sn[10,2]._txtidx = 81;
		sn[10,2]._extraimg = 0;

		sn[10,3]._chaimg = "cc_cha3";
		sn[10,3]._mirror = false;
		sn[10,3]._pos = 1;
		sn[10,3]._showef = 0;
		sn[10,3]._txtidx = 82;
		sn[10,3]._extraimg = 0;

		sn[10,4]._chaimg = "cc_bro0";
		sn[10,4]._mirror = false;
		sn[10,4]._pos = 0;
		sn[10,4]._showef = 0;
		sn[10,4]._txtidx = 83;
		sn[10,4]._extraimg = 0;

		sn[10,5]._chaimg = "cc_bro0";
		sn[10,5]._mirror = false;
		sn[10,5]._pos = 0;
		sn[10,5]._showef = 4;
		sn[10,5]._txtidx = 84;
		sn[10,5]._extraimg = 1008;


		///*4-2*/
		sn[11,0]._chaimg = "cc_cha0";
		sn[11,0]._mirror = false;
		sn[11,0]._pos = 1;
		sn[11,0]._showef = 1;
		sn[11,0]._txtidx = 85;
		sn[11,0]._extraimg = 0;

		sn[11,1]._chaimg = "cc_bro0";
		sn[11,1]._mirror = false;
		sn[11,1]._pos = 0;
		sn[11,1]._showef = 1;
		sn[11,1]._txtidx = 86;
		sn[11,1]._extraimg = 0;

		sn[11,2]._chaimg = "cc_cha1";
		sn[11,2]._mirror = false;
		sn[11,2]._pos = 1;
		sn[11,2]._showef = 0;
		sn[11,2]._txtidx = 87;
		sn[11,2]._extraimg = 0;

		sn[11,3]._chaimg = "cc_bro0";
		sn[11,3]._mirror = false;
		sn[11,3]._pos = 0;
		sn[11,3]._showef = 0;
		sn[11,3]._txtidx = 88;
		sn[11,3]._extraimg = 0;

		sn[11,4]._chaimg = "cc_cha1";
		sn[11,4]._mirror = false;
		sn[11,4]._pos = 1;
		sn[11,4]._showef = 0;
		sn[11,4]._txtidx = 89;
		sn[11,4]._extraimg = 0;

		sn[11,5]._chaimg = "cc_bro0";
		sn[11,5]._mirror = false;
		sn[11,5]._pos = 0;
		sn[11,5]._showef = 0;
		sn[11,5]._txtidx = 90;
		sn[11,5]._extraimg = 0;

		sn[11,6]._chaimg = "cc_pet";
		sn[11,6]._mirror = false;
		sn[11,6]._pos = 0;
		sn[11,6]._showef = 1;
		sn[11,6]._txtidx = 91;
		sn[11,6]._extraimg = 0;

		sn[11,7]._chaimg = "cc_cha1";
		sn[11,7]._mirror = false;
		sn[11,7]._pos = 1;
		sn[11,7]._showef = 4;
		sn[11,7]._txtidx = 92;
		sn[11,7]._extraimg = 0;


		///*4-3*/
		sn[12,0]._chaimg = "cc_cha0";
		sn[12,0]._mirror = false;
		sn[12,0]._pos = 1;
		sn[12,0]._showef = 1;
		sn[12,0]._txtidx = 93;
		sn[12,0]._extraimg = 0;

		sn[12,1]._chaimg = "cc_bro0";
		sn[12,1]._mirror = false;
		sn[12,1]._pos = 0;
		sn[12,1]._showef = 1;
		sn[12,1]._txtidx = 94;
		sn[12,1]._extraimg = 0;

		sn[12,2]._chaimg = "cc_cha0";
		sn[12,2]._mirror = false;
		sn[12,2]._pos = 1;
		sn[12,2]._showef = 0;
		sn[12,2]._txtidx = 95;
		sn[12,2]._extraimg = 0;

		sn[12,3]._chaimg = "cc_bro0";
		sn[12,3]._mirror = false;
		sn[12,3]._pos = 0;
		sn[12,3]._showef = 0;
		sn[12,3]._txtidx = 96;
		sn[12,3]._extraimg = 0;

		sn[12,4]._chaimg = "cc_cha0";
		sn[12,4]._mirror = false;
		sn[12,4]._pos = 1;
		sn[12,4]._showef = 0;
		sn[12,4]._txtidx = 97;
		sn[12,4]._extraimg = 0;

		sn[12,5]._chaimg = "cc_bro0";
		sn[12,5]._mirror = false;
		sn[12,5]._pos = 0;
		sn[12,5]._showef = 4;
		sn[12,5]._txtidx = 98;
		sn[12,5]._extraimg = 0;


		///*5-1*/
		sn[13,0]._chaimg = "cc_cha0";
		sn[13,0]._mirror = false;
		sn[13,0]._pos = 1;
		sn[13,0]._showef = 1;
		sn[13,0]._txtidx = 99;
		sn[13,0]._extraimg = 0;

		sn[13,1]._chaimg = "cc_pet";
		sn[13,1]._mirror = false;
		sn[13,1]._pos = 0;
		sn[13,1]._showef = 1;
		sn[13,1]._txtidx = 100;
		sn[13,1]._extraimg = 0;

		sn[13,2]._chaimg = "cc_shop";
		sn[13,2]._mirror = false;
		sn[13,2]._pos = 0;
		sn[13,2]._showef = 1;
		sn[13,2]._txtidx = 101;
		sn[13,2]._extraimg = 1006;

		sn[13,3]._chaimg = "cc_cha1";
		sn[13,3]._mirror = false;
		sn[13,3]._pos = 1;
		sn[13,3]._showef = 0;
		sn[13,3]._txtidx = 102;
		sn[13,3]._extraimg = 0;

		sn[13,4]._chaimg = "cc_shop";
		sn[13,4]._mirror = false;
		sn[13,4]._pos = 0;
		sn[13,4]._showef = 0;
		sn[13,4]._txtidx = 103;
		sn[13,4]._extraimg = 0;

		sn[13,5]._chaimg = "cc_cha1";
		sn[13,5]._mirror = false;
		sn[13,5]._pos = 1;
		sn[13,5]._showef = 0;
		sn[13,5]._txtidx = 104;
		sn[13,5]._extraimg = 0;

		sn[13,6]._chaimg = "cc_shop";
		sn[13,6]._mirror = false;
		sn[13,6]._pos = 0;
		sn[13,6]._showef = 2;
		sn[13,6]._txtidx = 105;
		sn[13,6]._extraimg = 0;

		sn[13,7]._chaimg = "cc_cha1";
		sn[13,7]._mirror = false;
		sn[13,7]._pos = 1;
		sn[13,7]._showef = 0;
		sn[13,7]._txtidx = 106;
		sn[13,7]._extraimg = 0;

		sn[13,8]._chaimg = "cc_cha3";
		sn[13,8]._mirror = false;
		sn[13,8]._pos = 1;
		sn[13,8]._showef = 4;
		sn[13,8]._txtidx = 107;
		sn[13,8]._extraimg = 219;


		///*5-2*/
		sn[14,0]._chaimg = "cc_cha0";
		sn[14,0]._mirror = false;
		sn[14,0]._pos = 1;
		sn[14,0]._showef = 1;
		sn[14,0]._txtidx = 108;
		sn[14,0]._extraimg = 0;

		sn[14,1]._chaimg = "cc_shop";
		sn[14,1]._mirror = false;
		sn[14,1]._pos = 0;
		sn[14,1]._showef = 1;
		sn[14,1]._txtidx = 109;
		sn[14,1]._extraimg = 0;

		sn[14,2]._chaimg = "cc_cha1";
		sn[14,2]._mirror = false;
		sn[14,2]._pos = 1;
		sn[14,2]._showef = 0;
		sn[14,2]._txtidx = 110;
		sn[14,2]._extraimg = 0;

		sn[14,3]._chaimg = "cc_shop";
		sn[14,3]._mirror = false;
		sn[14,3]._pos = 0;
		sn[14,3]._showef = 0;
		sn[14,3]._txtidx = 111;
		sn[14,3]._extraimg = 0;

		sn[14,4]._chaimg = "cc_cha1";
		sn[14,4]._mirror = false;
		sn[14,4]._pos = 1;
		sn[14,4]._showef = 0;
		sn[14,4]._txtidx = 112;
		sn[14,4]._extraimg = 0;

		sn[14,5]._chaimg = "cc_shop";
		sn[14,5]._mirror = false;
		sn[14,5]._pos = 0;
		sn[14,5]._showef = 4;
		sn[14,5]._txtidx = 113;
		sn[14,5]._extraimg = 0;


		///*5-3*/
		sn[15,0]._chaimg = "cc_cha0";
		sn[15,0]._mirror = false;
		sn[15,0]._pos = 1;
		sn[15,0]._showef = 1;
		sn[15,0]._txtidx = 114;
		sn[15,0]._extraimg = 0;

		sn[15,1]._chaimg = "cc_archive";
		sn[15,1]._mirror = false;
		sn[15,1]._pos = 0;
		sn[15,1]._showef = 1;
		sn[15,1]._txtidx = 115;
		sn[15,1]._extraimg = 0;

		sn[15,2]._chaimg = "cc_shop";
		sn[15,2]._mirror = false;
		sn[15,2]._pos = 0;
		sn[15,2]._showef = 1;
		sn[15,2]._txtidx = 116;
		sn[15,2]._extraimg = 0;

		sn[15,3]._chaimg = "cc_cha0";
		sn[15,3]._mirror = false;
		sn[15,3]._pos = 1;
		sn[15,3]._showef = 0;
		sn[15,3]._txtidx = 117;
		sn[15,3]._extraimg = 0;

		sn[15,4]._chaimg = "cc_shop";
		sn[15,4]._mirror = false;
		sn[15,4]._pos = 0;
		sn[15,4]._showef = 0;
		sn[15,4]._txtidx = 118;
		sn[15,4]._extraimg = 0;

		sn[15,5]._chaimg = "cc_cha0";
		sn[15,5]._mirror = false;
		sn[15,5]._pos = 1;
		sn[15,5]._showef = 4;
		sn[15,5]._txtidx = 119;
		sn[15,5]._extraimg = 0;


		///*6-1*/
		sn[16,0]._chaimg = "cc_cha0";
		sn[16,0]._mirror = false;
		sn[16,0]._pos = 1;
		sn[16,0]._showef = 1;
		sn[16,0]._txtidx = 120;
		sn[16,0]._extraimg = 0;

		sn[16,1]._chaimg = "cc_bro0";
		sn[16,1]._mirror = false;
		sn[16,1]._pos = 0;
		sn[16,1]._showef = 1;
		sn[16,1]._txtidx = 121;
		sn[16,1]._extraimg = 0;

		sn[16,2]._chaimg = "cc_cha0";
		sn[16,2]._mirror = false;
		sn[16,2]._pos = 1;
		sn[16,2]._showef = 0;
		sn[16,2]._txtidx = 122;
		sn[16,2]._extraimg = 0;

		sn[16,3]._chaimg = "cc_archive";
		sn[16,3]._mirror = false;
		sn[16,3]._pos = 0;
		sn[16,3]._showef = 1;
		sn[16,3]._txtidx = 123;
		sn[16,3]._extraimg = 0;

		sn[16,4]._chaimg = "cc_cha1";
		sn[16,4]._mirror = false;
		sn[16,4]._pos = 1;
		sn[16,4]._showef = 0;
		sn[16,4]._txtidx = 124;
		sn[16,4]._extraimg = 0;

		sn[16,5]._chaimg = "cc_archive";
		sn[16,5]._mirror = false;
		sn[16,5]._pos = 0;
		sn[16,5]._showef = 0;
		sn[16,5]._txtidx = 125;
		sn[16,5]._extraimg = 0;

		sn[16,6]._chaimg = "cc_shop";
		sn[16,6]._mirror = false;
		sn[16,6]._pos = 0;
		sn[16,6]._showef = 1;
		sn[16,6]._txtidx = 126;
		sn[16,6]._extraimg = 0;

		sn[16,7]._chaimg = "cc_pet";
		sn[16,7]._mirror = false;
		sn[16,7]._pos = 0;
		sn[16,7]._showef = 1;
		sn[16,7]._txtidx = 127;
		sn[16,7]._extraimg = 0;

		sn[16,8]._chaimg = "cc_cha2";
		sn[16,8]._mirror = false;
		sn[16,8]._pos = 1;
		sn[16,8]._showef = 4;
		sn[16,8]._txtidx = 128;
		sn[16,8]._extraimg = 0;


		///*6-2*/
		sn[17,0]._chaimg = "cc_cha0";
		sn[17,0]._mirror = false;
		sn[17,0]._pos = 1;
		sn[17,0]._showef = 1;
		sn[17,0]._txtidx = 129;
		sn[17,0]._extraimg = 0;

		sn[17,1]._chaimg = "cc_archive";
		sn[17,1]._mirror = false;
		sn[17,1]._pos = 0;
		sn[17,1]._showef = 1;
		sn[17,1]._txtidx = 130;
		sn[17,1]._extraimg = 0;

		sn[17,2]._chaimg = "cc_cha0";
		sn[17,2]._mirror = false;
		sn[17,2]._pos = 1;
		sn[17,2]._showef = 0;
		sn[17,2]._txtidx = 131;
		sn[17,2]._extraimg = 0;

		sn[17,3]._chaimg = "cc_bro0";
		sn[17,3]._mirror = false;
		sn[17,3]._pos = 0;
		sn[17,3]._showef = 1;
		sn[17,3]._txtidx = 132;
		sn[17,3]._extraimg = 0;

		sn[17,4]._chaimg = "cc_cha0";
		sn[17,4]._mirror = false;
		sn[17,4]._pos = 1;
		sn[17,4]._showef = 0;
		sn[17,4]._txtidx = 133;
		sn[17,4]._extraimg = 0;

		sn[17,5]._chaimg = "cc_pet";
		sn[17,5]._mirror = false;
		sn[17,5]._pos = 0;
		sn[17,5]._showef = 1;
		sn[17,5]._txtidx = 134;
		sn[17,5]._extraimg = 0;

		sn[17,6]._chaimg = "cc_cha1";
		sn[17,6]._mirror = false;
		sn[17,6]._pos = 1;
		sn[17,6]._showef = 4;
		sn[17,6]._txtidx = 135;
		sn[17,6]._extraimg = 0;


		///*6-3*/
		sn[18,0]._chaimg = "cc_cha2";
		sn[18,0]._mirror = false;
		sn[18,0]._pos = 1;
		sn[18,0]._showef = 1;
		sn[18,0]._txtidx = 136;
		sn[18,0]._extraimg = 0;

		sn[18,1]._chaimg = "cc_pet";
		sn[18,1]._mirror = false;
		sn[18,1]._pos = 0;
		sn[18,1]._showef = 1;
		sn[18,1]._txtidx = 137;
		sn[18,1]._extraimg = 0;

		sn[18,2]._chaimg = "cc_archive";
		sn[18,2]._mirror = false;
		sn[18,2]._pos = 1;
		sn[18,2]._showef = 1;
		sn[18,2]._txtidx = 138;
		sn[18,2]._extraimg = 0;

		sn[18,3]._chaimg = "cc_pet";
		sn[18,3]._mirror = false;
		sn[18,3]._pos = 0;
		sn[18,3]._showef = 0;
		sn[18,3]._txtidx = 139;
		sn[18,3]._extraimg = 0;

		sn[18,4]._chaimg = "cc_shop";
		sn[18,4]._mirror = false;
		sn[18,4]._pos = 1;
		sn[18,4]._showef = 1;
		sn[18,4]._txtidx = 140;
		sn[18,4]._extraimg = 0;

		sn[18,5]._chaimg = "cc_archive";
		sn[18,5]._mirror = false;
		sn[18,5]._pos = 1;
		sn[18,5]._showef = 1;
		sn[18,5]._txtidx = 141;
		sn[18,5]._extraimg = 0;

		sn[18,6]._chaimg = "cc_cha1";
		sn[18,6]._mirror = false;
		sn[18,6]._pos = 1;
		sn[18,6]._showef = 5;
		sn[18,6]._txtidx = 142;
		sn[18,6]._extraimg = 0;


		///*7-1*/
		sn[19,0]._chaimg = "cc_cha0";
		sn[19,0]._mirror = false;
		sn[19,0]._pos = 1;
		sn[19,0]._showef = 1;
		sn[19,0]._txtidx = 143;
		sn[19,0]._extraimg = 0;

		sn[19,1]._chaimg = "cc_archive";
		sn[19,1]._mirror = false;
		sn[19,1]._pos = 0;
		sn[19,1]._showef = 1;
		sn[19,1]._txtidx = 144;
		sn[19,1]._extraimg = 0;

		sn[19,2]._chaimg = "cc_cha1";
		sn[19,2]._mirror = false;
		sn[19,2]._pos = 1;
		sn[19,2]._showef = 0;
		sn[19,2]._txtidx = 145;
		sn[19,2]._extraimg = 0;

		sn[19,3]._chaimg = "cc_shop";
		sn[19,3]._mirror = false;
		sn[19,3]._pos = 0;
		sn[19,3]._showef = 1;
		sn[19,3]._txtidx = 146;
		sn[19,3]._extraimg = 0;

		sn[19,4]._chaimg = "cc_archive";
		sn[19,4]._mirror = false;
		sn[19,4]._pos = 0;
		sn[19,4]._showef = 1;
		sn[19,4]._txtidx = 147;
		sn[19,4]._extraimg = 0;

		sn[19,5]._chaimg = "cc_cha2";
		sn[19,5]._mirror = false;
		sn[19,5]._pos = 1;
		sn[19,5]._showef = 4;
		sn[19,5]._txtidx = 148;
		sn[19,5]._extraimg = 0;


		///*7-2*/
		sn[20,0]._chaimg = "cc_cha0";
		sn[20,0]._mirror = false;
		sn[20,0]._pos = 1;
		sn[20,0]._showef = 1;
		sn[20,0]._txtidx = 149;
		sn[20,0]._extraimg = 0;

		sn[20,1]._chaimg = "cc_pet";
		sn[20,1]._mirror = false;
		sn[20,1]._pos = 0;
		sn[20,1]._showef = 1;
		sn[20,1]._txtidx = 150;
		sn[20,1]._extraimg = 0;

		sn[20,2]._chaimg = "cc_cha3";
		sn[20,2]._mirror = false;
		sn[20,2]._pos = 1;
		sn[20,2]._showef = 0;
		sn[20,2]._txtidx = 151;
		sn[20,2]._extraimg = 0;

		sn[20,3]._chaimg = "cc_shop";
		sn[20,3]._mirror = false;
		sn[20,3]._pos = 0;
		sn[20,3]._showef = 1;
		sn[20,3]._txtidx = 152;
		sn[20,3]._extraimg = 0;

		sn[20,4]._chaimg = "cc_pet";
		sn[20,4]._mirror = false;
		sn[20,4]._pos = 0;
		sn[20,4]._showef = 1;
		sn[20,4]._txtidx = 153;
		sn[20,4]._extraimg = 0;

		sn[20,5]._chaimg = "cc_cha3";
		sn[20,5]._mirror = false;
		sn[20,5]._pos = 1;
		sn[20,5]._showef = 0;
		sn[20,5]._txtidx = 154;
		sn[20,5]._extraimg = 0;

		sn[20,6]._chaimg = "cc_archive";
		sn[20,6]._mirror = false;
		sn[20,6]._pos = 0;
		sn[20,6]._showef = 5;
		sn[20,6]._txtidx = 155;
		sn[20,6]._extraimg = 0;


		///*7-3*/
		sn[21,0]._chaimg = "cc_cha0";
		sn[21,0]._mirror = false;
		sn[21,0]._pos = 1;
		sn[21,0]._showef = 1;
		sn[21,0]._txtidx = 156;
		sn[21,0]._extraimg = 0;

		sn[21,1]._chaimg = "cc_bro0";
		sn[21,1]._mirror = false;
		sn[21,1]._pos = 0;
		sn[21,1]._showef = 1;
		sn[21,1]._txtidx = 157;
		sn[21,1]._extraimg = 0;

		sn[21,2]._chaimg = "cc_cha0";
		sn[21,2]._mirror = false;
		sn[21,2]._pos = 1;
		sn[21,2]._showef = 0;
		sn[21,2]._txtidx = 158;
		sn[21,2]._extraimg = 0;

		sn[21,3]._chaimg = "cc_bro0";
		sn[21,3]._mirror = false;
		sn[21,3]._pos = 0;
		sn[21,3]._showef = 0;
		sn[21,3]._txtidx = 159;
		sn[21,3]._extraimg = 0;

		sn[21,4]._chaimg = "cc_cha0";
		sn[21,4]._mirror = false;
		sn[21,4]._pos = 1;
		sn[21,4]._showef = 0;
		sn[21,4]._txtidx = 160;
		sn[21,4]._extraimg = 0;

		sn[21,5]._chaimg = "cc_bro0";
		sn[21,5]._mirror = false;
		sn[21,5]._pos = 0;
		sn[21,5]._showef = 0;
		sn[21,5]._txtidx = 161;
		sn[21,5]._extraimg = 0;

		sn[21,6]._chaimg = "cc_cha0";
		sn[21,6]._mirror = false;
		sn[21,6]._pos = 1;
		sn[21,6]._showef = 0;
		sn[21,6]._txtidx = 162;
		sn[21,6]._extraimg = 0;

		sn[21,7]._chaimg = "cc_bro0";
		sn[21,7]._mirror = false;
		sn[21,7]._pos = 0;
		sn[21,7]._showef = 4;
		sn[21,7]._txtidx = 163;
		sn[21,7]._extraimg = 0;


		///*8-1*/
		sn[22,0]._chaimg = "cc_shop2";
		sn[22,0]._mirror = false;
		sn[22,0]._pos = 0;
		sn[22,0]._showef = 1;
		sn[22,0]._txtidx = 164;
		sn[22,0]._extraimg = 0;

		sn[22,1]._chaimg = "cc_cha0";
		sn[22,1]._mirror = false;
		sn[22,1]._pos = 1;
		sn[22,1]._showef = 1;
		sn[22,1]._txtidx = 165;
		sn[22,1]._extraimg = 0;

		sn[22,2]._chaimg = "cc_cha3";
		sn[22,2]._mirror = false;
		sn[22,2]._pos = 1;
		sn[22,2]._showef = 0;
		sn[22,2]._txtidx = 166;
		sn[22,2]._extraimg = 0;

		sn[22,3]._chaimg = "cc_shop2";
		sn[22,3]._mirror = false;
		sn[22,3]._pos = 0;
		sn[22,3]._showef = 0;
		sn[22,3]._txtidx = 167;
		sn[22,3]._extraimg = 0;

		sn[22,4]._chaimg = "cc_cha0";
		sn[22,4]._mirror = false;
		sn[22,4]._pos = 1;
		sn[22,4]._showef = 0;
		sn[22,4]._txtidx = 168;
		sn[22,4]._extraimg = 0;

		sn[22,5]._chaimg = "cc_shop2";
		sn[22,5]._mirror = false;
		sn[22,5]._pos = 0;
		sn[22,5]._showef = 0;
		sn[22,5]._txtidx = 169;
		sn[22,5]._extraimg = 0;

		sn[22,6]._chaimg = "cc_cha3";
		sn[22,6]._mirror = false;
		sn[22,6]._pos = 1;
		sn[22,6]._showef = 4;
		sn[22,6]._txtidx = 170;
		sn[22,6]._extraimg = 0;


		///*8-2*/
		sn[23,0]._chaimg = "cc_cha0";
		sn[23,0]._mirror = false;
		sn[23,0]._pos = 1;
		sn[23,0]._showef = 1;
		sn[23,0]._txtidx = 171;
		sn[23,0]._extraimg = 0;

		sn[23,1]._chaimg = "cc_bro0";
		sn[23,1]._mirror = false;
		sn[23,1]._pos = 0;
		sn[23,1]._showef = 1;
		sn[23,1]._txtidx = 172;
		sn[23,1]._extraimg = 0;

		sn[23,2]._chaimg = "cc_bro2";
		sn[23,2]._mirror = false;
		sn[23,2]._pos = 0;
		sn[23,2]._showef = 2;
		sn[23,2]._txtidx = 173;
		sn[23,2]._extraimg = 0;

		sn[23,3]._chaimg = "cc_cha0";
		sn[23,3]._mirror = false;
		sn[23,3]._pos = 1;
		sn[23,3]._showef = 0;
		sn[23,3]._txtidx = 174;
		sn[23,3]._extraimg = 0;

		sn[23,4]._chaimg = "cc_bro0";
		sn[23,4]._mirror = false;
		sn[23,4]._pos = 0;
		sn[23,4]._showef = 0;
		sn[23,4]._txtidx = 175;
		sn[23,4]._extraimg = 0;

		sn[23,5]._chaimg = "cc_cha1";
		sn[23,5]._mirror = false;
		sn[23,5]._pos = 1;
		sn[23,5]._showef = 0;
		sn[23,5]._txtidx = 176;
		sn[23,5]._extraimg = 0;

		sn[23,6]._chaimg = "cc_bro0";
		sn[23,6]._mirror = false;
		sn[23,6]._pos = 0;
		sn[23,6]._showef = 4;
		sn[23,6]._txtidx = 177;
		sn[23,6]._extraimg = 0;


		///*8-3*/
		sn[24,0]._chaimg = "cc_cha0";
		sn[24,0]._mirror = false;
		sn[24,0]._pos = 1;
		sn[24,0]._showef = 1;
		sn[24,0]._txtidx = 178;
		sn[24,0]._extraimg = 0;

		sn[24,1]._chaimg = "cc_bro0";
		sn[24,1]._mirror = false;
		sn[24,1]._pos = 0;
		sn[24,1]._showef = 1;
		sn[24,1]._txtidx = 179;
		sn[24,1]._extraimg = 0;

		sn[24,2]._chaimg = "cc_pet";
		sn[24,2]._mirror = false;
		sn[24,2]._pos = 0;
		sn[24,2]._showef = 1;
		sn[24,2]._txtidx = 180;
		sn[24,2]._extraimg = 0;

		sn[24,3]._chaimg = "cc_cha2";
		sn[24,3]._mirror = false;
		sn[24,3]._pos = 1;
		sn[24,3]._showef = 0;
		sn[24,3]._txtidx = 181;
		sn[24,3]._extraimg = 0;

		sn[24,4]._chaimg = "cc_pet";
		sn[24,4]._mirror = false;
		sn[24,4]._pos = 0;
		sn[24,4]._showef = 0;
		sn[24,4]._txtidx = 182;
		sn[24,4]._extraimg = 0;

		sn[24,5]._chaimg = "cc_cha4";
		sn[24,5]._mirror = false;
		sn[24,5]._pos = 1;
		sn[24,5]._showef = 4;
		sn[24,5]._txtidx = 183;
		sn[24,5]._extraimg = 0;


		///*9-1*/
		sn[25,0]._chaimg = "cc_cha0";
		sn[25,0]._mirror = false;
		sn[25,0]._pos = 1;
		sn[25,0]._showef = 1;
		sn[25,0]._txtidx = 184;
		sn[25,0]._extraimg = 0;

		sn[25,1]._chaimg = "cc_bro0";
		sn[25,1]._mirror = false;
		sn[25,1]._pos = 0;
		sn[25,1]._showef = 1;
		sn[25,1]._txtidx = 185;
		sn[25,1]._extraimg = 0;

		sn[25,2]._chaimg = "cc_cha0";
		sn[25,2]._mirror = false;
		sn[25,2]._pos = 1;
		sn[25,2]._showef = 0;
		sn[25,2]._txtidx = 186;
		sn[25,2]._extraimg = 0;

		sn[25,3]._chaimg = "cc_bro0";
		sn[25,3]._mirror = false;
		sn[25,3]._pos = 0;
		sn[25,3]._showef = 0;
		sn[25,3]._txtidx = 187;
		sn[25,3]._extraimg = 0;

		sn[25,4]._chaimg = "cc_cha1";
		sn[25,4]._mirror = false;
		sn[25,4]._pos = 1;
		sn[25,4]._showef = 0;
		sn[25,4]._txtidx = 188;
		sn[25,4]._extraimg = 0;

		sn[25,5]._chaimg = "cc_bro0";
		sn[25,5]._mirror = false;
		sn[25,5]._pos = 0;
		sn[25,5]._showef = 4;
		sn[25,5]._txtidx = 189;
		sn[25,5]._extraimg = 0;


		///*9-2*/
		sn[26,0]._chaimg = "cc_bro0";
		sn[26,0]._mirror = false;
		sn[26,0]._pos = 0;
		sn[26,0]._showef = 1;
		sn[26,0]._txtidx = 190;
		sn[26,0]._extraimg = 0;

		sn[26,1]._chaimg = "cc_cha0";
		sn[26,1]._mirror = false;
		sn[26,1]._pos = 1;
		sn[26,1]._showef = 1;
		sn[26,1]._txtidx = 191;
		sn[26,1]._extraimg = 0;

		sn[26,2]._chaimg = "cc_bro0";
		sn[26,2]._mirror = false;
		sn[26,2]._pos = 0;
		sn[26,2]._showef = 0;
		sn[26,2]._txtidx = 192;
		sn[26,2]._extraimg = 0;

		sn[26,3]._chaimg = "cc_cha0";
		sn[26,3]._mirror = false;
		sn[26,3]._pos = 1;
		sn[26,3]._showef = 0;
		sn[26,3]._txtidx = 193;
		sn[26,3]._extraimg = 0;

		sn[26,4]._chaimg = "cc_bro0";
		sn[26,4]._mirror = false;
		sn[26,4]._pos = 0;
		sn[26,4]._showef = 0;
		sn[26,4]._txtidx = 194;
		sn[26,4]._extraimg = 0;

		sn[26,5]._chaimg = "cc_cha0";
		sn[26,5]._mirror = false;
		sn[26,5]._pos = 1;
		sn[26,5]._showef = 0;
		sn[26,5]._txtidx = 195;
		sn[26,5]._extraimg = 0;

		sn[26,6]._chaimg = "cc_bro0";
		sn[26,6]._mirror = false;
		sn[26,6]._pos = 0;
		sn[26,6]._showef = 0;
		sn[26,6]._txtidx = 196;
		sn[26,6]._extraimg = 0;

		sn[26,7]._chaimg = "cc_bro0";
		sn[26,7]._mirror = false;
		sn[26,7]._pos = 0;
		sn[26,7]._showef = 0;
		sn[26,7]._txtidx = 197;
		sn[26,7]._extraimg = 0;

		sn[26,8]._chaimg = "cc_cha0";
		sn[26,8]._mirror = false;
		sn[26,8]._pos = 1;
		sn[26,8]._showef = 0;
		sn[26,8]._txtidx = 198;
		sn[26,8]._extraimg = 0;

		sn[26,9]._chaimg = "cc_bro0";
		sn[26,9]._mirror = false;
		sn[26,9]._pos = 0;
		sn[26,9]._showef = 4;
		sn[26,9]._txtidx = 199;
		sn[26,9]._extraimg = 0;


		///*9-3*/
		sn[27,0]._chaimg = "cc_cha3";
		sn[27,0]._mirror = false;
		sn[27,0]._pos = 1;
		sn[27,0]._showef = 1;
		sn[27,0]._txtidx = 200;
		sn[27,0]._extraimg = 0;

		sn[27,1]._chaimg = "cc_yupo";
		sn[27,1]._mirror = false;
		sn[27,1]._pos = 0;
		sn[27,1]._showef = 1;
		sn[27,1]._txtidx = 201;
		sn[27,1]._extraimg = 0;

		sn[27,2]._chaimg = "cc_cha4";
		sn[27,2]._mirror = false;
		sn[27,2]._pos = 1;
		sn[27,2]._showef = 2;
		sn[27,2]._txtidx = 202;
		sn[27,2]._extraimg = 0;

		sn[27,3]._chaimg = "cc_yupo";
		sn[27,3]._mirror = false;
		sn[27,3]._pos = 0;
		sn[27,3]._showef = 0;
		sn[27,3]._txtidx = 203;
		sn[27,3]._extraimg = 0;

		sn[27,4]._chaimg = "cc_cha4";
		sn[27,4]._mirror = false;
		sn[27,4]._pos = 1;
		sn[27,4]._showef = 0;
		sn[27,4]._txtidx = 204;
		sn[27,4]._extraimg = 0;

		sn[27,5]._chaimg = "cc_yupo";
		sn[27,5]._mirror = false;
		sn[27,5]._pos = 0;
		sn[27,5]._showef = 0;
		sn[27,5]._txtidx = 205;
		sn[27,5]._extraimg = 0;

		sn[27,6]._chaimg = "cc_cha4";
		sn[27,6]._mirror = false;
		sn[27,6]._pos = 1;
		sn[27,6]._showef = 2;
		sn[27,6]._txtidx = 206;
		sn[27,6]._extraimg = 0;

		sn[27,7]._chaimg = "cc_yupo";
		sn[27,7]._mirror = false;
		sn[27,7]._pos = 0;
		sn[27,7]._showef = 0;
		sn[27,7]._txtidx = 207;
		sn[27,7]._extraimg = 0;

		sn[27,8]._chaimg = "cc_cha4";
		sn[27,8]._mirror = false;
		sn[27,8]._pos = 1;
		sn[27,8]._showef = 0;
		sn[27,8]._txtidx = 208;
		sn[27,8]._extraimg = 0;

		sn[27,9]._chaimg = "cc_yupo";
		sn[27,9]._mirror = false;
		sn[27,9]._pos = 0;
		sn[27,9]._showef = 4;
		sn[27,9]._txtidx = 209;
		sn[27,9]._extraimg = 0;


		///*10-1*/
		sn[28,0]._chaimg = "cc_shop2";
		sn[28,0]._mirror = false;
		sn[28,0]._pos = 0;
		sn[28,0]._showef = 1;
		sn[28,0]._txtidx = 210;
		sn[28,0]._extraimg = 0;

		sn[28,1]._chaimg = "cc_cha6";
		sn[28,1]._mirror = false;
		sn[28,1]._pos = 1;
		sn[28,1]._showef = 1;
		sn[28,1]._txtidx = 211;
		sn[28,1]._extraimg = 0;

		sn[28,2]._chaimg = "cc_shop2";
		sn[28,2]._mirror = false;
		sn[28,2]._pos = 0;
		sn[28,2]._showef = 0;
		sn[28,2]._txtidx = 212;
		sn[28,2]._extraimg = 0;

		sn[28,3]._chaimg = "cc_cha6";
		sn[28,3]._mirror = false;
		sn[28,3]._pos = 1;
		sn[28,3]._showef = 0;
		sn[28,3]._txtidx = 213;
		sn[28,3]._extraimg = 0;

		sn[28,4]._chaimg = "cc_shop2";
		sn[28,4]._mirror = false;
		sn[28,4]._pos = 0;
		sn[28,4]._showef = 0;
		sn[28,4]._txtidx = 214;
		sn[28,4]._extraimg = 0;

		sn[28,5]._chaimg = "cc_cha4";
		sn[28,5]._mirror = false;
		sn[28,5]._pos = 1;
		sn[28,5]._showef = 2;
		sn[28,5]._txtidx = 215;
		sn[28,5]._extraimg = 0;

		sn[28,6]._chaimg = "cc_shop2";
		sn[28,6]._mirror = false;
		sn[28,6]._pos = 0;
		sn[28,6]._showef = 0;
		sn[28,6]._txtidx = 216;
		sn[28,6]._extraimg = 0;

		sn[28,7]._chaimg = "cc_cha6";
		sn[28,7]._mirror = false;
		sn[28,7]._pos = 1;
		sn[28,7]._showef = 0;
		sn[28,7]._txtidx = 217;
		sn[28,7]._extraimg = 0;

		sn[28,8]._chaimg = "cc_shop2";
		sn[28,8]._mirror = false;
		sn[28,8]._pos = 0;
		sn[28,8]._showef = 0;
		sn[28,8]._txtidx = 218;
		sn[28,8]._extraimg = 0;

		sn[28,9]._chaimg = "cc_shop2";
		sn[28,9]._mirror = false;
		sn[28,9]._pos = 0;
		sn[28,9]._showef = 0;
		sn[28,9]._txtidx = 219;
		sn[28,9]._extraimg = 0;

		sn[28,10]._chaimg = "cc_cha6";
		sn[28,10]._mirror = false;
		sn[28,10]._pos = 1;
		sn[28,10]._showef = 0;
		sn[28,10]._txtidx = 220;
		sn[28,10]._extraimg = 0;

		sn[28,11]._chaimg = "cc_cha5";
		sn[28,11]._mirror = false;
		sn[28,11]._pos = 1;
		sn[28,11]._showef = 4;
		sn[28,11]._txtidx = 221;
		sn[28,11]._extraimg = 0;


		///*10-2*/
		sn[29,0]._chaimg = "cc_bro2";
		sn[29,0]._mirror = false;
		sn[29,0]._pos = 0;
		sn[29,0]._showef = 2;
		sn[29,0]._txtidx = 222;
		sn[29,0]._extraimg = 0;

		sn[29,1]._chaimg = "cc_cha0";
		sn[29,1]._mirror = false;
		sn[29,1]._pos = 1;
		sn[29,1]._showef = 1;
		sn[29,1]._txtidx = 223;
		sn[29,1]._extraimg = 0;

		sn[29,2]._chaimg = "cc_bro2";
		sn[29,2]._mirror = false;
		sn[29,2]._pos = 0;
		sn[29,2]._showef = 0;
		sn[29,2]._txtidx = 224;
		sn[29,2]._extraimg = 0;

		sn[29,3]._chaimg = "cc_cha6";
		sn[29,3]._mirror = false;
		sn[29,3]._pos = 1;
		sn[29,3]._showef = 2;
		sn[29,3]._txtidx = 225;
		sn[29,3]._extraimg = 0;

		sn[29,4]._chaimg = "cc_bro2";
		sn[29,4]._mirror = false;
		sn[29,4]._pos = 0;
		sn[29,4]._showef = 0;
		sn[29,4]._txtidx = 226;
		sn[29,4]._extraimg = 0;

		sn[29,5]._chaimg = "cc_cha6";
		sn[29,5]._mirror = false;
		sn[29,5]._pos = 1;
		sn[29,5]._showef = 0;
		sn[29,5]._txtidx = 227;
		sn[29,5]._extraimg = 0;

		sn[29,6]._chaimg = "cc_bro2";
		sn[29,6]._mirror = false;
		sn[29,6]._pos = 0;
		sn[29,6]._showef = 0;
		sn[29,6]._txtidx = 228;
		sn[29,6]._extraimg = 0;

		sn[29,7]._chaimg = "cc_cha3";
		sn[29,7]._mirror = false;
		sn[29,7]._pos = 1;
		sn[29,7]._showef = 0;
		sn[29,7]._txtidx = 229;
		sn[29,7]._extraimg = 0;

		sn[29,8]._chaimg = "cc_bro2";
		sn[29,8]._mirror = false;
		sn[29,8]._pos = 0;
		sn[29,8]._showef = 2;
		sn[29,8]._txtidx = 230;
		sn[29,8]._extraimg = 0;

		sn[29,9]._chaimg = "cc_cha3";
		sn[29,9]._mirror = false;
		sn[29,9]._pos = 1;
		sn[29,9]._showef = 0;
		sn[29,9]._txtidx = 231;
		sn[29,9]._extraimg = 0;

		sn[29,10]._chaimg = "cc_bro2";
		sn[29,10]._mirror = false;
		sn[29,10]._pos = 0;
		sn[29,10]._showef = 2;
		sn[29,10]._txtidx = 232;
		sn[29,10]._extraimg = 0;

		sn[29,11]._chaimg = "cc_cha5";
		sn[29,11]._mirror = false;
		sn[29,11]._pos = 1;
		sn[29,11]._showef = 4;
		sn[29,11]._txtidx = 233;
		sn[29,11]._extraimg = 0;


		///*10-3*/
		sn[30,0]._chaimg = "cc_cha0";
		sn[30,0]._mirror = false;
		sn[30,0]._pos = 1;
		sn[30,0]._showef = 1;
		sn[30,0]._txtidx = 234;
		sn[30,0]._extraimg = 0;

		sn[30,1]._chaimg = "cc_bro3";
		sn[30,1]._mirror = false;
		sn[30,1]._pos = 0;
		sn[30,1]._showef = 1;
		sn[30,1]._txtidx = 235;
		sn[30,1]._extraimg = 0;

		sn[30,2]._chaimg = "cc_cha6";
		sn[30,2]._mirror = false;
		sn[30,2]._pos = 1;
		sn[30,2]._showef = 0;
		sn[30,2]._txtidx = 236;
		sn[30,2]._extraimg = 0;

		sn[30,3]._chaimg = "cc_cha3";
		sn[30,3]._mirror = false;
		sn[30,3]._pos = 1;
		sn[30,3]._showef = 0;
		sn[30,3]._txtidx = 237;
		sn[30,3]._extraimg = 0;

		sn[30,4]._chaimg = "cc_bro3";
		sn[30,4]._mirror = false;
		sn[30,4]._pos = 0;
		sn[30,4]._showef = 2;
		sn[30,4]._txtidx = 238;
		sn[30,4]._extraimg = 0;

		sn[30,5]._chaimg = "cc_cha3";
		sn[30,5]._mirror = false;
		sn[30,5]._pos = 1;
		sn[30,5]._showef = 0;
		sn[30,5]._txtidx = 239;
		sn[30,5]._extraimg = 0;

		sn[30,6]._chaimg = "cc_bro3";
		sn[30,6]._mirror = false;
		sn[30,6]._pos = 0;
		sn[30,6]._showef = 2;
		sn[30,6]._txtidx = 240;
		sn[30,6]._extraimg = 0;

		sn[30,7]._chaimg = "cc_cha3";
		sn[30,7]._mirror = false;
		sn[30,7]._pos = 1;
		sn[30,7]._showef = 0;
		sn[30,7]._txtidx = 241;
		sn[30,7]._extraimg = 0;

		sn[30,8]._chaimg = "cc_bro3";
		sn[30,8]._mirror = false;
		sn[30,8]._pos = 0;
		sn[30,8]._showef = 2;
		sn[30,8]._txtidx = 242;
		sn[30,8]._extraimg = 0;

		sn[30,9]._chaimg = "cc_cha3";
		sn[30,9]._mirror = false;
		sn[30,9]._pos = 1;
		sn[30,9]._showef = 0;
		sn[30,9]._txtidx = 243;
		sn[30,9]._extraimg = 0;

		sn[30,10]._chaimg = "cc_cha6";
		sn[30,10]._mirror = false;
		sn[30,10]._pos = 1;
		sn[30,10]._showef = 2;
		sn[30,10]._txtidx = 244;
		sn[30,10]._extraimg = 0;

		sn[30,11]._chaimg = "cc_cha5";
		sn[30,11]._mirror = false;
		sn[30,11]._pos = 1;
		sn[30,11]._showef = 4;
		sn[30,11]._txtidx = 245;
		sn[30,11]._extraimg = 0;


		///*11-1*/
		sn[31,0]._chaimg = "cc_cha6";
		sn[31,0]._mirror = false;
		sn[31,0]._pos = 1;
		sn[31,0]._showef = 1;
		sn[31,0]._txtidx = 246;
		sn[31,0]._extraimg = 0;

		sn[31,1]._chaimg = "cc_shop2";
		sn[31,1]._mirror = false;
		sn[31,1]._pos = 0;
		sn[31,1]._showef = 1;
		sn[31,1]._txtidx = 247;
		sn[31,1]._extraimg = 0;

		sn[31,2]._chaimg = "cc_cha6";
		sn[31,2]._mirror = false;
		sn[31,2]._pos = 1;
		sn[31,2]._showef = 0;
		sn[31,2]._txtidx = 248;
		sn[31,2]._extraimg = 0;

		sn[31,3]._chaimg = "cc_shop2";
		sn[31,3]._mirror = false;
		sn[31,3]._pos = 0;
		sn[31,3]._showef = 0;
		sn[31,3]._txtidx = 249;
		sn[31,3]._extraimg = 0;

		sn[31,4]._chaimg = "cc_cha6";
		sn[31,4]._mirror = false;
		sn[31,4]._pos = 1;
		sn[31,4]._showef = 0;
		sn[31,4]._txtidx = 250;
		sn[31,4]._extraimg = 0;

		sn[31,5]._chaimg = "cc_shop2";
		sn[31,5]._mirror = false;
		sn[31,5]._pos = 0;
		sn[31,5]._showef = 0;
		sn[31,5]._txtidx = 251;
		sn[31,5]._extraimg = 0;

		sn[31,6]._chaimg = "cc_cha5";
		sn[31,6]._mirror = false;
		sn[31,6]._pos = 1;
		sn[31,6]._showef = 0;
		sn[31,6]._txtidx = 252;
		sn[31,6]._extraimg = 0;

		sn[31,7]._chaimg = "cc_shop2";
		sn[31,7]._mirror = false;
		sn[31,7]._pos = 0;
		sn[31,7]._showef = 4;
		sn[31,7]._txtidx = 253;
		sn[31,7]._extraimg = 0;


		///*11-2*/
		sn[32,0]._chaimg = "cc_archive";
		sn[32,0]._mirror = false;
		sn[32,0]._pos = 0;
		sn[32,0]._showef = 1;
		sn[32,0]._txtidx = 254;
		sn[32,0]._extraimg = 0;

		sn[32,1]._chaimg = "cc_cha0";
		sn[32,1]._mirror = false;
		sn[32,1]._pos = 1;
		sn[32,1]._showef = 1;
		sn[32,1]._txtidx = 255;
		sn[32,1]._extraimg = 0;

		sn[32,2]._chaimg = "cc_archive";
		sn[32,2]._mirror = false;
		sn[32,2]._pos = 0;
		sn[32,2]._showef = 0;
		sn[32,2]._txtidx = 256;
		sn[32,2]._extraimg = 0;

		sn[32,3]._chaimg = "cc_cha0";
		sn[32,3]._mirror = false;
		sn[32,3]._pos = 1;
		sn[32,3]._showef = 0;
		sn[32,3]._txtidx = 257;
		sn[32,3]._extraimg = 0;

		sn[32,4]._chaimg = "cc_archive";
		sn[32,4]._mirror = false;
		sn[32,4]._pos = 0;
		sn[32,4]._showef = 0;
		sn[32,4]._txtidx = 258;
		sn[32,4]._extraimg = 0;

		sn[32,5]._chaimg = "cc_cha6";
		sn[32,5]._mirror = false;
		sn[32,5]._pos = 1;
		sn[32,5]._showef = 0;
		sn[32,5]._txtidx = 259;
		sn[32,5]._extraimg = 0;

		sn[32,6]._chaimg = "cc_archive";
		sn[32,6]._mirror = false;
		sn[32,6]._pos = 0;
		sn[32,6]._showef = 0;
		sn[32,6]._txtidx = 260;
		sn[32,6]._extraimg = 0;

		sn[32,7]._chaimg = "cc_cha6";
		sn[32,7]._mirror = false;
		sn[32,7]._pos = 1;
		sn[32,7]._showef = 0;
		sn[32,7]._txtidx = 261;
		sn[32,7]._extraimg = 0;

		sn[32,8]._chaimg = "cc_archive";
		sn[32,8]._mirror = false;
		sn[32,8]._pos = 0;
		sn[32,8]._showef = 0;
		sn[32,8]._txtidx = 262;
		sn[32,8]._extraimg = 0;

		sn[32,9]._chaimg = "cc_cha6";
		sn[32,9]._mirror = false;
		sn[32,9]._pos = 1;
		sn[32,9]._showef = 0;
		sn[32,9]._txtidx = 263;
		sn[32,9]._extraimg = 0;

		sn[32,10]._chaimg = "cc_archive";
		sn[32,10]._mirror = false;
		sn[32,10]._pos = 0;
		sn[32,10]._showef = 0;
		sn[32,10]._txtidx = 264;
		sn[32,10]._extraimg = 0;

		sn[32,11]._chaimg = "cc_cha6";
		sn[32,11]._mirror = false;
		sn[32,11]._pos = 1;
		sn[32,11]._showef = 4;
		sn[32,11]._txtidx = 265;
		sn[32,11]._extraimg = 0;


		///*11-3*/
		sn[33,0]._chaimg = "cc_cha6";
		sn[33,0]._mirror = false;
		sn[33,0]._pos = 1;
		sn[33,0]._showef = 1;
		sn[33,0]._txtidx = 266;
		sn[33,0]._extraimg = 0;

		sn[33,1]._chaimg = "cc_pet";
		sn[33,1]._mirror = false;
		sn[33,1]._pos = 0;
		sn[33,1]._showef = 1;
		sn[33,1]._txtidx = 267;
		sn[33,1]._extraimg = 0;

		sn[33,2]._chaimg = "cc_pet";
		sn[33,2]._mirror = false;
		sn[33,2]._pos = 0;
		sn[33,2]._showef = 0;
		sn[33,2]._txtidx = 268;
		sn[33,2]._extraimg = 0;

		sn[33,3]._chaimg = "cc_cha0";
		sn[33,3]._mirror = false;
		sn[33,3]._pos = 1;
		sn[33,3]._showef = 0;
		sn[33,3]._txtidx = 269;
		sn[33,3]._extraimg = 0;

		sn[33,4]._chaimg = "cc_pet";
		sn[33,4]._mirror = false;
		sn[33,4]._pos = 0;
		sn[33,4]._showef = 0;
		sn[33,4]._txtidx = 270;
		sn[33,4]._extraimg = 0;

		sn[33,5]._chaimg = "cc_pet";
		sn[33,5]._mirror = false;
		sn[33,5]._pos = 0;
		sn[33,5]._showef = 0;
		sn[33,5]._txtidx = 271;
		sn[33,5]._extraimg = 0;

		sn[33,6]._chaimg = "cc_cha0";
		sn[33,6]._mirror = false;
		sn[33,6]._pos = 1;
		sn[33,6]._showef = 0;
		sn[33,6]._txtidx = 272;
		sn[33,6]._extraimg = 0;

		sn[33,7]._chaimg = "cc_pet";
		sn[33,7]._mirror = false;
		sn[33,7]._pos = 0;
		sn[33,7]._showef = 0;
		sn[33,7]._txtidx = 273;
		sn[33,7]._extraimg = 0;

		sn[33,8]._chaimg = "cc_cha0";
		sn[33,8]._mirror = false;
		sn[33,8]._pos = 1;
		sn[33,8]._showef = 0;
		sn[33,8]._txtidx = 274;
		sn[33,8]._extraimg = 0;

		sn[33,9]._chaimg = "cc_pet";
		sn[33,9]._mirror = false;
		sn[33,9]._pos = 0;
		sn[33,9]._showef = 0;
		sn[33,9]._txtidx = 275;
		sn[33,9]._extraimg = 0;

		sn[33,10]._chaimg = "cc_cha1";
		sn[33,10]._mirror = false;
		sn[33,10]._pos = 1;
		sn[33,10]._showef = 4;
		sn[33,10]._txtidx = 276;
		sn[33,10]._extraimg = 0;


		///*12-1*/
		sn[34,0]._chaimg = "cc_cha6";
		sn[34,0]._mirror = false;
		sn[34,0]._pos = 1;
		sn[34,0]._showef = 1;
		sn[34,0]._txtidx = 277;
		sn[34,0]._extraimg = 0;

		sn[34,1]._chaimg = "cc_yun0";
		sn[34,1]._mirror = false;
		sn[34,1]._pos = 0;
		sn[34,1]._showef = 1;
		sn[34,1]._txtidx = 278;
		sn[34,1]._extraimg = 0;

		sn[34,2]._chaimg = "cc_cha4";
		sn[34,2]._mirror = false;
		sn[34,2]._pos = 1;
		sn[34,2]._showef = 2;
		sn[34,2]._txtidx = 279;
		sn[34,2]._extraimg = 0;

		sn[34,3]._chaimg = "cc_yun0";
		sn[34,3]._mirror = false;
		sn[34,3]._pos = 0;
		sn[34,3]._showef = 0;
		sn[34,3]._txtidx = 280;
		sn[34,3]._extraimg = 0;

		sn[34,4]._chaimg = "cc_cha1";
		sn[34,4]._mirror = false;
		sn[34,4]._pos = 1;
		sn[34,4]._showef = 0;
		sn[34,4]._txtidx = 281;
		sn[34,4]._extraimg = 0;

		sn[34,5]._chaimg = "cc_yun0";
		sn[34,5]._mirror = false;
		sn[34,5]._pos = 0;
		sn[34,5]._showef = 0;
		sn[34,5]._txtidx = 282;
		sn[34,5]._extraimg = 0;

		sn[34,6]._chaimg = "cc_cha0";
		sn[34,6]._mirror = false;
		sn[34,6]._pos = 1;
		sn[34,6]._showef = 0;
		sn[34,6]._txtidx = 283;
		sn[34,6]._extraimg = 0;

		sn[34,7]._chaimg = "cc_yun0";
		sn[34,7]._mirror = false;
		sn[34,7]._pos = 0;
		sn[34,7]._showef = 0;
		sn[34,7]._txtidx = 284;
		sn[34,7]._extraimg = 0;

		sn[34,8]._chaimg = "cc_cha0";
		sn[34,8]._mirror = false;
		sn[34,8]._pos = 1;
		sn[34,8]._showef = 0;
		sn[34,8]._txtidx = 285;
		sn[34,8]._extraimg = 0;

		sn[34,9]._chaimg = "cc_yun0";
		sn[34,9]._mirror = false;
		sn[34,9]._pos = 0;
		sn[34,9]._showef = 0;
		sn[34,9]._txtidx = 286;
		sn[34,9]._extraimg = 0;

		sn[34,10]._chaimg = "cc_cha0";
		sn[34,10]._mirror = false;
		sn[34,10]._pos = 1;
		sn[34,10]._showef = 2;
		sn[34,10]._txtidx = 287;
		sn[34,10]._extraimg = 0;

		sn[34,11]._chaimg = "cc_yun0";
		sn[34,11]._mirror = false;
		sn[34,11]._pos = 0;
		sn[34,11]._showef = 4;
		sn[34,11]._txtidx = 288;
		sn[34,11]._extraimg = 0;


		///*12-2*/
		sn[35,0]._chaimg = "cc_yun0";
		sn[35,0]._mirror = false;
		sn[35,0]._pos = 0;
		sn[35,0]._showef = 1;
		sn[35,0]._txtidx = 289;
		sn[35,0]._extraimg = 0;

		sn[35,1]._chaimg = "cc_cha0";
		sn[35,1]._mirror = false;
		sn[35,1]._pos = 1;
		sn[35,1]._showef = 1;
		sn[35,1]._txtidx = 290;
		sn[35,1]._extraimg = 0;

		sn[35,2]._chaimg = "cc_yun0";
		sn[35,2]._mirror = false;
		sn[35,2]._pos = 0;
		sn[35,2]._showef = 0;
		sn[35,2]._txtidx = 291;
		sn[35,2]._extraimg = 0;

		sn[35,3]._chaimg = "cc_cha0";
		sn[35,3]._mirror = false;
		sn[35,3]._pos = 1;
		sn[35,3]._showef = 0;
		sn[35,3]._txtidx = 292;
		sn[35,3]._extraimg = 0;

		sn[35,4]._chaimg = "cc_yun0";
		sn[35,4]._mirror = false;
		sn[35,4]._pos = 0;
		sn[35,4]._showef = 0;
		sn[35,4]._txtidx = 293;
		sn[35,4]._extraimg = 0;

		sn[35,5]._chaimg = "cc_yun0";
		sn[35,5]._mirror = false;
		sn[35,5]._pos = 0;
		sn[35,5]._showef = 0;
		sn[35,5]._txtidx = 294;
		sn[35,5]._extraimg = 0;

		sn[35,6]._chaimg = "cc_cha2";
		sn[35,6]._mirror = false;
		sn[35,6]._pos = 1;
		sn[35,6]._showef = 0;
		sn[35,6]._txtidx = 295;
		sn[35,6]._extraimg = 0;

		sn[35,7]._chaimg = "cc_yun0";
		sn[35,7]._mirror = false;
		sn[35,7]._pos = 0;
		sn[35,7]._showef = 0;
		sn[35,7]._txtidx = 296;
		sn[35,7]._extraimg = 0;

		sn[35,8]._chaimg = "cc_yun0";
		sn[35,8]._mirror = false;
		sn[35,8]._pos = 0;
		sn[35,8]._showef = 0;
		sn[35,8]._txtidx = 297;
		sn[35,8]._extraimg = 0;

		sn[35,9]._chaimg = "cc_cha0";
		sn[35,9]._mirror = false;
		sn[35,9]._pos = 1;
		sn[35,9]._showef = 2;
		sn[35,9]._txtidx = 298;
		sn[35,9]._extraimg = 0;

		sn[35,10]._chaimg = "cc_yun0";
		sn[35,10]._mirror = false;
		sn[35,10]._pos = 0;
		sn[35,10]._showef = 4;
		sn[35,10]._txtidx = 299;
		sn[35,10]._extraimg = 0;


		///*12-3*/
		sn[36,0]._chaimg = "cc_yun0";
		sn[36,0]._mirror = false;
		sn[36,0]._pos = 0;
		sn[36,0]._showef = 1;
		sn[36,0]._txtidx = 300;
		sn[36,0]._extraimg = 0;

		sn[36,1]._chaimg = "cc_pet";
		sn[36,1]._mirror = false;
		sn[36,1]._pos = 0;
		sn[36,1]._showef = 1;
		sn[36,1]._txtidx = 301;
		sn[36,1]._extraimg = 0;

		sn[36,2]._chaimg = "cc_shop";
		sn[36,2]._mirror = false;
		sn[36,2]._pos = 0;
		sn[36,2]._showef = 1;
		sn[36,2]._txtidx = 302;
		sn[36,2]._extraimg = 0;

		sn[36,3]._chaimg = "cc_archive";
		sn[36,3]._mirror = false;
		sn[36,3]._pos = 0;
		sn[36,3]._showef = 1;
		sn[36,3]._txtidx = 303;
		sn[36,3]._extraimg = 0;

		sn[36,4]._chaimg = "cc_cha1";
		sn[36,4]._mirror = false;
		sn[36,4]._pos = 1;
		sn[36,4]._showef = 1;
		sn[36,4]._txtidx = 304;
		sn[36,4]._extraimg = 0;

		sn[36,5]._chaimg = "cc_pet";
		sn[36,5]._mirror = false;
		sn[36,5]._pos = 0;
		sn[36,5]._showef = 1;
		sn[36,5]._txtidx = 305;
		sn[36,5]._extraimg = 0;

		sn[36,6]._chaimg = "cc_archive";
		sn[36,6]._mirror = false;
		sn[36,6]._pos = 0;
		sn[36,6]._showef = 1;
		sn[36,6]._txtidx = 306;
		sn[36,6]._extraimg = 0;

		sn[36,7]._chaimg = "cc_cha1";
		sn[36,7]._mirror = false;
		sn[36,7]._pos = 1;
		sn[36,7]._showef = 0;
		sn[36,7]._txtidx = 307;
		sn[36,7]._extraimg = 0;

		sn[36,8]._chaimg = "cc_archive";
		sn[36,8]._mirror = false;
		sn[36,8]._pos = 0;
		sn[36,8]._showef = 0;
		sn[36,8]._txtidx = 308;
		sn[36,8]._extraimg = 0;

		sn[36,9]._chaimg = "cc_cha0";
		sn[36,9]._mirror = false;
		sn[36,9]._pos = 1;
		sn[36,9]._showef = 4;
		sn[36,9]._txtidx = 309;
		sn[36,9]._extraimg = 0;


		///*13-1*/
		sn[37,0]._chaimg = "cc_skill";
		sn[37,0]._mirror = false;
		sn[37,0]._pos = 0;
		sn[37,0]._showef = 1;
		sn[37,0]._txtidx = 310;
		sn[37,0]._extraimg = 0;

		sn[37,1]._chaimg = "cc_cha1";
		sn[37,1]._mirror = false;
		sn[37,1]._pos = 1;
		sn[37,1]._showef = 1;
		sn[37,1]._txtidx = 311;
		sn[37,1]._extraimg = 0;

		sn[37,2]._chaimg = "cc_skill";
		sn[37,2]._mirror = false;
		sn[37,2]._pos = 0;
		sn[37,2]._showef = 0;
		sn[37,2]._txtidx = 312;
		sn[37,2]._extraimg = 0;

		sn[37,3]._chaimg = "cc_cha0";
		sn[37,3]._mirror = false;
		sn[37,3]._pos = 1;
		sn[37,3]._showef = 0;
		sn[37,3]._txtidx = 313;
		sn[37,3]._extraimg = 0;

		sn[37,4]._chaimg = "cc_skill";
		sn[37,4]._mirror = false;
		sn[37,4]._pos = 0;
		sn[37,4]._showef = 0;
		sn[37,4]._txtidx = 314;
		sn[37,4]._extraimg = 0;

		sn[37,5]._chaimg = "cc_cha1";
		sn[37,5]._mirror = false;
		sn[37,5]._pos = 1;
		sn[37,5]._showef = 0;
		sn[37,5]._txtidx = 315;
		sn[37,5]._extraimg = 0;

		sn[37,6]._chaimg = "cc_skill";
		sn[37,6]._mirror = false;
		sn[37,6]._pos = 0;
		sn[37,6]._showef = 0;
		sn[37,6]._txtidx = 316;
		sn[37,6]._extraimg = 0;

		sn[37,7]._chaimg = "cc_cha1";
		sn[37,7]._mirror = false;
		sn[37,7]._pos = 1;
		sn[37,7]._showef = 0;
		sn[37,7]._txtidx = 317;
		sn[37,7]._extraimg = 0;

		sn[37,8]._chaimg = "cc_skill";
		sn[37,8]._mirror = false;
		sn[37,8]._pos = 0;
		sn[37,8]._showef = 0;
		sn[37,8]._txtidx = 318;
		sn[37,8]._extraimg = 0;

		sn[37,9]._chaimg = "cc_skill";
		sn[37,9]._mirror = false;
		sn[37,9]._pos = 0;
		sn[37,9]._showef = 4;
		sn[37,9]._txtidx = 319;
		sn[37,9]._extraimg = 0;


		///*13-2*/
		sn[38,0]._chaimg = "cc_cha1";
		sn[38,0]._mirror = false;
		sn[38,0]._pos = 1;
		sn[38,0]._showef = 1;
		sn[38,0]._txtidx = 320;
		sn[38,0]._extraimg = 0;

		sn[38,1]._chaimg = "cc_yun0";
		sn[38,1]._mirror = false;
		sn[38,1]._pos = 0;
		sn[38,1]._showef = 1;
		sn[38,1]._txtidx = 321;
		sn[38,1]._extraimg = 0;

		sn[38,2]._chaimg = "cc_cha2";
		sn[38,2]._mirror = false;
		sn[38,2]._pos = 1;
		sn[38,2]._showef = 0;
		sn[38,2]._txtidx = 322;
		sn[38,2]._extraimg = 0;

		sn[38,3]._chaimg = "cc_yun0";
		sn[38,3]._mirror = false;
		sn[38,3]._pos = 0;
		sn[38,3]._showef = 0;
		sn[38,3]._txtidx = 323;
		sn[38,3]._extraimg = 0;

		sn[38,4]._chaimg = "cc_cha3";
		sn[38,4]._mirror = false;
		sn[38,4]._pos = 1;
		sn[38,4]._showef = 0;
		sn[38,4]._txtidx = 324;
		sn[38,4]._extraimg = 0;

		sn[38,5]._chaimg = "cc_yun0";
		sn[38,5]._mirror = false;
		sn[38,5]._pos = 0;
		sn[38,5]._showef = 0;
		sn[38,5]._txtidx = 325;
		sn[38,5]._extraimg = 0;

		sn[38,6]._chaimg = "cc_cha0";
		sn[38,6]._mirror = false;
		sn[38,6]._pos = 1;
		sn[38,6]._showef = 0;
		sn[38,6]._txtidx = 326;
		sn[38,6]._extraimg = 0;

		sn[38,7]._chaimg = "cc_cha0";
		sn[38,7]._mirror = false;
		sn[38,7]._pos = 1;
		sn[38,7]._showef = 0;
		sn[38,7]._txtidx = 327;
		sn[38,7]._extraimg = 0;

		sn[38,8]._chaimg = "cc_yun0";
		sn[38,8]._mirror = false;
		sn[38,8]._pos = 0;
		sn[38,8]._showef = 0;
		sn[38,8]._txtidx = 328;
		sn[38,8]._extraimg = 0;

		sn[38,9]._chaimg = "cc_cha2";
		sn[38,9]._mirror = false;
		sn[38,9]._pos = 1;
		sn[38,9]._showef = 0;
		sn[38,9]._txtidx = 329;
		sn[38,9]._extraimg = 0;

		sn[38,10]._chaimg = "cc_yun0";
		sn[38,10]._mirror = false;
		sn[38,10]._pos = 0;
		sn[38,10]._showef = 0;
		sn[38,10]._txtidx = 330;
		sn[38,10]._extraimg = 0;

		sn[38,11]._chaimg = "cc_cha0";
		sn[38,11]._mirror = false;
		sn[38,11]._pos = 1;
		sn[38,11]._showef = 0;
		sn[38,11]._txtidx = 331;
		sn[38,11]._extraimg = 0;

		sn[38,12]._chaimg = "cc_yun0";
		sn[38,12]._mirror = false;
		sn[38,12]._pos = 0;
		sn[38,12]._showef = 4;
		sn[38,12]._txtidx = 332;
		sn[38,12]._extraimg = 0;


		///*13-3*/
		sn[39,0]._chaimg = "cc_cha6";
		sn[39,0]._mirror = false;
		sn[39,0]._pos = 1;
		sn[39,0]._showef = 1;
		sn[39,0]._txtidx = 333;
		sn[39,0]._extraimg = 0;

		sn[39,1]._chaimg = "cc_yun0";
		sn[39,1]._mirror = false;
		sn[39,1]._pos = 0;
		sn[39,1]._showef = 1;
		sn[39,1]._txtidx = 334;
		sn[39,1]._extraimg = 0;

		sn[39,2]._chaimg = "cc_yun0";
		sn[39,2]._mirror = false;
		sn[39,2]._pos = 0;
		sn[39,2]._showef = 0;
		sn[39,2]._txtidx = 335;
		sn[39,2]._extraimg = 0;

		sn[39,3]._chaimg = "cc_yun0";
		sn[39,3]._mirror = false;
		sn[39,3]._pos = 0;
		sn[39,3]._showef = 0;
		sn[39,3]._txtidx = 336;
		sn[39,3]._extraimg = 0;

		sn[39,4]._chaimg = "cc_yun0";
		sn[39,4]._mirror = false;
		sn[39,4]._pos = 0;
		sn[39,4]._showef = 0;
		sn[39,4]._txtidx = 337;
		sn[39,4]._extraimg = 0;

		sn[39,5]._chaimg = "cc_cha2";
		sn[39,5]._mirror = false;
		sn[39,5]._pos = 1;
		sn[39,5]._showef = 0;
		sn[39,5]._txtidx = 338;
		sn[39,5]._extraimg = 0;

		sn[39,6]._chaimg = "cc_yun0";
		sn[39,6]._mirror = false;
		sn[39,6]._pos = 0;
		sn[39,6]._showef = 0;
		sn[39,6]._txtidx = 339;
		sn[39,6]._extraimg = 0;

		sn[39,7]._chaimg = "cc_cha2";
		sn[39,7]._mirror = false;
		sn[39,7]._pos = 1;
		sn[39,7]._showef = 4;
		sn[39,7]._txtidx = 340;
		sn[39,7]._extraimg = 0;


		///*14-1*/
		sn[40,0]._chaimg = "cc_cha0";
		sn[40,0]._mirror = false;
		sn[40,0]._pos = 1;
		sn[40,0]._showef = 1;
		sn[40,0]._txtidx = 341;
		sn[40,0]._extraimg = 0;

		sn[40,1]._chaimg = "cc_cha0";
		sn[40,1]._mirror = false;
		sn[40,1]._pos = 1;
		sn[40,1]._showef = 0;
		sn[40,1]._txtidx = 342;
		sn[40,1]._extraimg = 0;

		sn[40,2]._chaimg = "cc_yun0";
		sn[40,2]._mirror = false;
		sn[40,2]._pos = 0;
		sn[40,2]._showef = 1;
		sn[40,2]._txtidx = 343;
		sn[40,2]._extraimg = 0;

		sn[40,3]._chaimg = "cc_cha0";
		sn[40,3]._mirror = false;
		sn[40,3]._pos = 1;
		sn[40,3]._showef = 0;
		sn[40,3]._txtidx = 344;
		sn[40,3]._extraimg = 0;

		sn[40,4]._chaimg = "cc_yun0";
		sn[40,4]._mirror = false;
		sn[40,4]._pos = 0;
		sn[40,4]._showef = 0;
		sn[40,4]._txtidx = 345;
		sn[40,4]._extraimg = 0;

		sn[40,5]._chaimg = "cc_cha3";
		sn[40,5]._mirror = false;
		sn[40,5]._pos = 1;
		sn[40,5]._showef = 0;
		sn[40,5]._txtidx = 346;
		sn[40,5]._extraimg = 0;

		sn[40,6]._chaimg = "cc_pet";
		sn[40,6]._mirror = false;
		sn[40,6]._pos = 1;
		sn[40,6]._showef = 1;
		sn[40,6]._txtidx = 347;
		sn[40,6]._extraimg = 0;

		sn[40,7]._chaimg = "cc_yun0";
		sn[40,7]._mirror = false;
		sn[40,7]._pos = 0;
		sn[40,7]._showef = 0;
		sn[40,7]._txtidx = 348;
		sn[40,7]._extraimg = 0;

		sn[40,8]._chaimg = "cc_pet";
		sn[40,8]._mirror = false;
		sn[40,8]._pos = 1;
		sn[40,8]._showef = 0;
		sn[40,8]._txtidx = 349;
		sn[40,8]._extraimg = 0;

		sn[40,9]._chaimg = "cc_cha2";
		sn[40,9]._mirror = false;
		sn[40,9]._pos = 1;
		sn[40,9]._showef = 4;
		sn[40,9]._txtidx = 350;
		sn[40,9]._extraimg = 0;


		///*14-2*/
		sn[41,0]._chaimg = "cc_cha6";
		sn[41,0]._mirror = false;
		sn[41,0]._pos = 1;
		sn[41,0]._showef = 1;
		sn[41,0]._txtidx = 351;
		sn[41,0]._extraimg = 0;

		sn[41,1]._chaimg = "cc_yun0";
		sn[41,1]._mirror = false;
		sn[41,1]._pos = 0;
		sn[41,1]._showef = 1;
		sn[41,1]._txtidx = 352;
		sn[41,1]._extraimg = 0;

		sn[41,2]._chaimg = "cc_cha0";
		sn[41,2]._mirror = false;
		sn[41,2]._pos = 1;
		sn[41,2]._showef = 0;
		sn[41,2]._txtidx = 353;
		sn[41,2]._extraimg = 0;

		sn[41,3]._chaimg = "cc_yun0";
		sn[41,3]._mirror = false;
		sn[41,3]._pos = 0;
		sn[41,3]._showef = 0;
		sn[41,3]._txtidx = 354;
		sn[41,3]._extraimg = 0;

		sn[41,4]._chaimg = "cc_yun0";
		sn[41,4]._mirror = false;
		sn[41,4]._pos = 0;
		sn[41,4]._showef = 0;
		sn[41,4]._txtidx = 355;
		sn[41,4]._extraimg = 0;

		sn[41,5]._chaimg = "cc_yun0";
		sn[41,5]._mirror = false;
		sn[41,5]._pos = 0;
		sn[41,5]._showef = 0;
		sn[41,5]._txtidx = 356;
		sn[41,5]._extraimg = 0;

		sn[41,6]._chaimg = "cc_cha0";
		sn[41,6]._mirror = false;
		sn[41,6]._pos = 1;
		sn[41,6]._showef = 0;
		sn[41,6]._txtidx = 357;
		sn[41,6]._extraimg = 0;

		sn[41,7]._chaimg = "cc_yun0";
		sn[41,7]._mirror = false;
		sn[41,7]._pos = 0;
		sn[41,7]._showef = 0;
		sn[41,7]._txtidx = 358;
		sn[41,7]._extraimg = 0;

		sn[41,8]._chaimg = "cc_cha0";
		sn[41,8]._mirror = false;
		sn[41,8]._pos = 1;
		sn[41,8]._showef = 0;
		sn[41,8]._txtidx = 359;
		sn[41,8]._extraimg = 0;

		sn[41,9]._chaimg = "cc_yun0";
		sn[41,9]._mirror = false;
		sn[41,9]._pos = 0;
		sn[41,9]._showef = 0;
		sn[41,9]._txtidx = 360;
		sn[41,9]._extraimg = 0;

		sn[41,10]._chaimg = "cc_cha2";
		sn[41,10]._mirror = false;
		sn[41,10]._pos = 1;
		sn[41,10]._showef = 4;
		sn[41,10]._txtidx = 361;
		sn[41,10]._extraimg = 0;


		///*14-3*/
		sn[42,0]._chaimg = "cc_pet";
		sn[42,0]._mirror = false;
		sn[42,0]._pos = 0;
		sn[42,0]._showef = 1;
		sn[42,0]._txtidx = 362;
		sn[42,0]._extraimg = 0;

		sn[42,1]._chaimg = "cc_pet";
		sn[42,1]._mirror = false;
		sn[42,1]._pos = 0;
		sn[42,1]._showef = 0;
		sn[42,1]._txtidx = 363;
		sn[42,1]._extraimg = 0;

		sn[42,2]._chaimg = "cc_cha1";
		sn[42,2]._mirror = false;
		sn[42,2]._pos = 1;
		sn[42,2]._showef = 1;
		sn[42,2]._txtidx = 364;
		sn[42,2]._extraimg = 0;

		sn[42,3]._chaimg = "cc_pet";
		sn[42,3]._mirror = false;
		sn[42,3]._pos = 0;
		sn[42,3]._showef = 0;
		sn[42,3]._txtidx = 365;
		sn[42,3]._extraimg = 0;

		sn[42,4]._chaimg = "cc_cha3";
		sn[42,4]._mirror = false;
		sn[42,4]._pos = 1;
		sn[42,4]._showef = 0;
		sn[42,4]._txtidx = 366;
		sn[42,4]._extraimg = 0;

		sn[42,5]._chaimg = "cc_yun0";
		sn[42,5]._mirror = false;
		sn[42,5]._pos = 0;
		sn[42,5]._showef = 1;
		sn[42,5]._txtidx = 367;
		sn[42,5]._extraimg = 0;

		sn[42,6]._chaimg = "cc_yun0";
		sn[42,6]._mirror = false;
		sn[42,6]._pos = 0;
		sn[42,6]._showef = 0;
		sn[42,6]._txtidx = 368;
		sn[42,6]._extraimg = 0;

		sn[42,7]._chaimg = "cc_cha0";
		sn[42,7]._mirror = false;
		sn[42,7]._pos = 1;
		sn[42,7]._showef = 0;
		sn[42,7]._txtidx = 369;
		sn[42,7]._extraimg = 0;

		sn[42,8]._chaimg = "cc_yun0";
		sn[42,8]._mirror = false;
		sn[42,8]._pos = 0;
		sn[42,8]._showef = 4;
		sn[42,8]._txtidx = 370;
		sn[42,8]._extraimg = 0;


		///*15-1*/
		sn[43,0]._chaimg = "cc_cha2";
		sn[43,0]._mirror = false;
		sn[43,0]._pos = 1;
		sn[43,0]._showef = 1;
		sn[43,0]._txtidx = 371;
		sn[43,0]._extraimg = 0;

		sn[43,1]._chaimg = "cc_shop2";
		sn[43,1]._mirror = false;
		sn[43,1]._pos = 0;
		sn[43,1]._showef = 1;
		sn[43,1]._txtidx = 372;
		sn[43,1]._extraimg = 0;

		sn[43,2]._chaimg = "cc_cha3";
		sn[43,2]._mirror = false;
		sn[43,2]._pos = 1;
		sn[43,2]._showef = 0;
		sn[43,2]._txtidx = 373;
		sn[43,2]._extraimg = 0;

		sn[43,3]._chaimg = "cc_yun0";
		sn[43,3]._mirror = false;
		sn[43,3]._pos = 0;
		sn[43,3]._showef = 1;
		sn[43,3]._txtidx = 374;
		sn[43,3]._extraimg = 0;

		sn[43,4]._chaimg = "cc_cha1";
		sn[43,4]._mirror = false;
		sn[43,4]._pos = 1;
		sn[43,4]._showef = 0;
		sn[43,4]._txtidx = 375;
		sn[43,4]._extraimg = 0;

		sn[43,5]._chaimg = "cc_yun0";
		sn[43,5]._mirror = false;
		sn[43,5]._pos = 0;
		sn[43,5]._showef = 0;
		sn[43,5]._txtidx = 376;
		sn[43,5]._extraimg = 0;

		sn[43,6]._chaimg = "cc_yun0";
		sn[43,6]._mirror = false;
		sn[43,6]._pos = 0;
		sn[43,6]._showef = 0;
		sn[43,6]._txtidx = 377;
		sn[43,6]._extraimg = 0;

		sn[43,7]._chaimg = "cc_pet";
		sn[43,7]._mirror = false;
		sn[43,7]._pos = 0;
		sn[43,7]._showef = 1;
		sn[43,7]._txtidx = 378;
		sn[43,7]._extraimg = 0;

		sn[43,8]._chaimg = "cc_cha3";
		sn[43,8]._mirror = false;
		sn[43,8]._pos = 1;
		sn[43,8]._showef = 0;
		sn[43,8]._txtidx = 379;
		sn[43,8]._extraimg = 0;

		sn[43,9]._chaimg = "cc_archive";
		sn[43,9]._mirror = false;
		sn[43,9]._pos = 0;
		sn[43,9]._showef = 4;
		sn[43,9]._txtidx = 380;
		sn[43,9]._extraimg = 0;


		///*15-2*/
		sn[44,0]._chaimg = "cc_yun0";
		sn[44,0]._mirror = false;
		sn[44,0]._pos = 0;
		sn[44,0]._showef = 1;
		sn[44,0]._txtidx = 381;
		sn[44,0]._extraimg = 0;

		sn[44,1]._chaimg = "cc_cha2";
		sn[44,1]._mirror = false;
		sn[44,1]._pos = 1;
		sn[44,1]._showef = 1;
		sn[44,1]._txtidx = 382;
		sn[44,1]._extraimg = 0;

		sn[44,2]._chaimg = "cc_yun0";
		sn[44,2]._mirror = false;
		sn[44,2]._pos = 0;
		sn[44,2]._showef = 0;
		sn[44,2]._txtidx = 383;
		sn[44,2]._extraimg = 0;

		sn[44,3]._chaimg = "cc_cha0";
		sn[44,3]._mirror = false;
		sn[44,3]._pos = 1;
		sn[44,3]._showef = 0;
		sn[44,3]._txtidx = 384;
		sn[44,3]._extraimg = 0;

		sn[44,4]._chaimg = "cc_yun0";
		sn[44,4]._mirror = false;
		sn[44,4]._pos = 0;
		sn[44,4]._showef = 0;
		sn[44,4]._txtidx = 385;
		sn[44,4]._extraimg = 0;

		sn[44,5]._chaimg = "cc_pet";
		sn[44,5]._mirror = false;
		sn[44,5]._pos = 0;
		sn[44,5]._showef = 1;
		sn[44,5]._txtidx = 386;
		sn[44,5]._extraimg = 0;

		sn[44,6]._chaimg = "cc_shop";
		sn[44,6]._mirror = false;
		sn[44,6]._pos = 0;
		sn[44,6]._showef = 1;
		sn[44,6]._txtidx = 387;
		sn[44,6]._extraimg = 0;

		sn[44,7]._chaimg = "cc_cha2";
		sn[44,7]._mirror = false;
		sn[44,7]._pos = 1;
		sn[44,7]._showef = 4;
		sn[44,7]._txtidx = 388;
		sn[44,7]._extraimg = 0;


		///*15-3*/
		sn[45,0]._chaimg = "cc_skill";
		sn[45,0]._mirror = false;
		sn[45,0]._pos = 0;
		sn[45,0]._showef = 1;
		sn[45,0]._txtidx = 389;
		sn[45,0]._extraimg = 0;

		sn[45,1]._chaimg = "cc_cha1";
		sn[45,1]._mirror = false;
		sn[45,1]._pos = 1;
		sn[45,1]._showef = 1;
		sn[45,1]._txtidx = 390;
		sn[45,1]._extraimg = 0;

		sn[45,2]._chaimg = "cc_skill";
		sn[45,2]._mirror = false;
		sn[45,2]._pos = 0;
		sn[45,2]._showef = 0;
		sn[45,2]._txtidx = 391;
		sn[45,2]._extraimg = 0;

		sn[45,3]._chaimg = "cc_skill";
		sn[45,3]._mirror = false;
		sn[45,3]._pos = 0;
		sn[45,3]._showef = 0;
		sn[45,3]._txtidx = 392;
		sn[45,3]._extraimg = 0;

		sn[45,4]._chaimg = "cc_cha2";
		sn[45,4]._mirror = false;
		sn[45,4]._pos = 1;
		sn[45,4]._showef = 0;
		sn[45,4]._txtidx = 393;
		sn[45,4]._extraimg = 0;

		sn[45,5]._chaimg = "cc_skill";
		sn[45,5]._mirror = false;
		sn[45,5]._pos = 0;
		sn[45,5]._showef = 4;
		sn[45,5]._txtidx = 394;
		sn[45,5]._extraimg = 0;


		///*16-1*/
		sn[46,0]._chaimg = "cc_archive";
		sn[46,0]._mirror = false;
		sn[46,0]._pos = 0;
		sn[46,0]._showef = 1;
		sn[46,0]._txtidx = 395;
		sn[46,0]._extraimg = 0;

		sn[46,1]._chaimg = "cc_yun0";
		sn[46,1]._mirror = false;
		sn[46,1]._pos = 0;
		sn[46,1]._showef = 1;
		sn[46,1]._txtidx = 396;
		sn[46,1]._extraimg = 0;

		sn[46,2]._chaimg = "cc_pet";
		sn[46,2]._mirror = false;
		sn[46,2]._pos = 1;
		sn[46,2]._showef = 1;
		sn[46,2]._txtidx = 397;
		sn[46,2]._extraimg = 0;

		sn[46,3]._chaimg = "cc_yun0";
		sn[46,3]._mirror = false;
		sn[46,3]._pos = 0;
		sn[46,3]._showef = 0;
		sn[46,3]._txtidx = 398;
		sn[46,3]._extraimg = 0;

		sn[46,4]._chaimg = "cc_archive";
		sn[46,4]._mirror = false;
		sn[46,4]._pos = 0;
		sn[46,4]._showef = 1;
		sn[46,4]._txtidx = 399;
		sn[46,4]._extraimg = 0;

		sn[46,5]._chaimg = "cc_cha2";
		sn[46,5]._mirror = false;
		sn[46,5]._pos = 1;
		sn[46,5]._showef = 2;
		sn[46,5]._txtidx = 400;
		sn[46,5]._extraimg = 0;

		sn[46,6]._chaimg = "cc_yun0";
		sn[46,6]._mirror = false;
		sn[46,6]._pos = 0;
		sn[46,6]._showef = 1;
		sn[46,6]._txtidx = 401;
		sn[46,6]._extraimg = 0;

		sn[46,7]._chaimg = "cc_cha0";
		sn[46,7]._mirror = false;
		sn[46,7]._pos = 1;
		sn[46,7]._showef = 0;
		sn[46,7]._txtidx = 402;
		sn[46,7]._extraimg = 0;

		sn[46,8]._chaimg = "cc_yun0";
		sn[46,8]._mirror = false;
		sn[46,8]._pos = 0;
		sn[46,8]._showef = 0;
		sn[46,8]._txtidx = 403;
		sn[46,8]._extraimg = 0;

		sn[46,9]._chaimg = "cc_cha2";
		sn[46,9]._mirror = false;
		sn[46,9]._pos = 1;
		sn[46,9]._showef = 4;
		sn[46,9]._txtidx = 404;
		sn[46,9]._extraimg = 0;


		///*16-2*/
		sn[47,0]._chaimg = "cc_cha0";
		sn[47,0]._mirror = false;
		sn[47,0]._pos = 1;
		sn[47,0]._showef = 1;
		sn[47,0]._txtidx = 405;
		sn[47,0]._extraimg = 0;

		sn[47,1]._chaimg = "cc_pet";
		sn[47,1]._mirror = false;
		sn[47,1]._pos = 0;
		sn[47,1]._showef = 1;
		sn[47,1]._txtidx = 406;
		sn[47,1]._extraimg = 0;

		sn[47,2]._chaimg = "cc_yun0";
		sn[47,2]._mirror = false;
		sn[47,2]._pos = 0;
		sn[47,2]._showef = 1;
		sn[47,2]._txtidx = 407;
		sn[47,2]._extraimg = 0;

		sn[47,3]._chaimg = "cc_cha0";
		sn[47,3]._mirror = false;
		sn[47,3]._pos = 1;
		sn[47,3]._showef = 0;
		sn[47,3]._txtidx = 408;
		sn[47,3]._extraimg = 0;

		sn[47,4]._chaimg = "cc_yun0";
		sn[47,4]._mirror = false;
		sn[47,4]._pos = 0;
		sn[47,4]._showef = 0;
		sn[47,4]._txtidx = 409;
		sn[47,4]._extraimg = 0;

		sn[47,5]._chaimg = "cc_cha2";
		sn[47,5]._mirror = false;
		sn[47,5]._pos = 1;
		sn[47,5]._showef = 0;
		sn[47,5]._txtidx = 410;
		sn[47,5]._extraimg = 0;

		sn[47,6]._chaimg = "cc_yun0";
		sn[47,6]._mirror = false;
		sn[47,6]._pos = 0;
		sn[47,6]._showef = 0;
		sn[47,6]._txtidx = 411;
		sn[47,6]._extraimg = 0;

		sn[47,7]._chaimg = "cc_cha6";
		sn[47,7]._mirror = false;
		sn[47,7]._pos = 1;
		sn[47,7]._showef = 0;
		sn[47,7]._txtidx = 412;
		sn[47,7]._extraimg = 0;

		sn[47,8]._chaimg = "cc_yun0";
		sn[47,8]._mirror = false;
		sn[47,8]._pos = 0;
		sn[47,8]._showef = 0;
		sn[47,8]._txtidx = 413;
		sn[47,8]._extraimg = 0;

		sn[47,9]._chaimg = "cc_cha2";
		sn[47,9]._mirror = false;
		sn[47,9]._pos = 1;
		sn[47,9]._showef = 4;
		sn[47,9]._txtidx = 414;
		sn[47,9]._extraimg = 0;


		///*16-3*/
		sn[48,0]._chaimg = "cc_cha2";
		sn[48,0]._mirror = false;
		sn[48,0]._pos = 1;
		sn[48,0]._showef = 1;
		sn[48,0]._txtidx = 415;
		sn[48,0]._extraimg = 0;

		sn[48,1]._chaimg = "cc_skill";
		sn[48,1]._mirror = false;
		sn[48,1]._pos = 0;
		sn[48,1]._showef = 1;
		sn[48,1]._txtidx = 416;
		sn[48,1]._extraimg = 0;

		sn[48,2]._chaimg = "cc_cha4";
		sn[48,2]._mirror = false;
		sn[48,2]._pos = 1;
		sn[48,2]._showef = 0;
		sn[48,2]._txtidx = 417;
		sn[48,2]._extraimg = 0;

		sn[48,3]._chaimg = "cc_skill";
		sn[48,3]._mirror = false;
		sn[48,3]._pos = 0;
		sn[48,3]._showef = 0;
		sn[48,3]._txtidx = 418;
		sn[48,3]._extraimg = 0;

		sn[48,4]._chaimg = "cc_cha5";
		sn[48,4]._mirror = false;
		sn[48,4]._pos = 1;
		sn[48,4]._showef = 0;
		sn[48,4]._txtidx = 419;
		sn[48,4]._extraimg = 0;

		sn[48,5]._chaimg = "cc_skill";
		sn[48,5]._mirror = false;
		sn[48,5]._pos = 0;
		sn[48,5]._showef = 0;
		sn[48,5]._txtidx = 420;
		sn[48,5]._extraimg = 0;

		sn[48,6]._chaimg = "cc_cha0";
		sn[48,6]._mirror = false;
		sn[48,6]._pos = 1;
		sn[48,6]._showef = 0;
		sn[48,6]._txtidx = 421;
		sn[48,6]._extraimg = 0;

		sn[48,7]._chaimg = "cc_skill";
		sn[48,7]._mirror = false;
		sn[48,7]._pos = 0;
		sn[48,7]._showef = 4;
		sn[48,7]._txtidx = 422;
		sn[48,7]._extraimg = 0;


		///*17-1*/
		sn[49,0]._chaimg = "cc_cha2";
		sn[49,0]._mirror = false;
		sn[49,0]._pos = 1;
		sn[49,0]._showef = 1;
		sn[49,0]._txtidx = 423;
		sn[49,0]._extraimg = 0;

		sn[49,1]._chaimg = "cc_yun0";
		sn[49,1]._mirror = false;
		sn[49,1]._pos = 0;
		sn[49,1]._showef = 1;
		sn[49,1]._txtidx = 424;
		sn[49,1]._extraimg = 0;

		sn[49,2]._chaimg = "cc_yun0";
		sn[49,2]._mirror = false;
		sn[49,2]._pos = 0;
		sn[49,2]._showef = 0;
		sn[49,2]._txtidx = 425;
		sn[49,2]._extraimg = 0;

		sn[49,3]._chaimg = "cc_cha6";
		sn[49,3]._mirror = false;
		sn[49,3]._pos = 1;
		sn[49,3]._showef = 0;
		sn[49,3]._txtidx = 426;
		sn[49,3]._extraimg = 0;

		sn[49,4]._chaimg = "cc_yun0";
		sn[49,4]._mirror = false;
		sn[49,4]._pos = 0;
		sn[49,4]._showef = 0;
		sn[49,4]._txtidx = 427;
		sn[49,4]._extraimg = 0;

		sn[49,5]._chaimg = "cc_cha0";
		sn[49,5]._mirror = false;
		sn[49,5]._pos = 1;
		sn[49,5]._showef = 0;
		sn[49,5]._txtidx = 428;
		sn[49,5]._extraimg = 0;

		sn[49,6]._chaimg = "cc_yun0";
		sn[49,6]._mirror = false;
		sn[49,6]._pos = 0;
		sn[49,6]._showef = 0;
		sn[49,6]._txtidx = 429;
		sn[49,6]._extraimg = 0;

		sn[49,7]._chaimg = "cc_cha0";
		sn[49,7]._mirror = false;
		sn[49,7]._pos = 1;
		sn[49,7]._showef = 0;
		sn[49,7]._txtidx = 430;
		sn[49,7]._extraimg = 0;

		sn[49,8]._chaimg = "cc_yun0";
		sn[49,8]._mirror = false;
		sn[49,8]._pos = 0;
		sn[49,8]._showef = 0;
		sn[49,8]._txtidx = 431;
		sn[49,8]._extraimg = 0;

		sn[49,9]._chaimg = "cc_yun0";
		sn[49,9]._mirror = false;
		sn[49,9]._pos = 0;
		sn[49,9]._showef = 0;
		sn[49,9]._txtidx = 432;
		sn[49,9]._extraimg = 0;

		sn[49,10]._chaimg = "cc_cha6";
		sn[49,10]._mirror = false;
		sn[49,10]._pos = 1;
		sn[49,10]._showef = 0;
		sn[49,10]._txtidx = 433;
		sn[49,10]._extraimg = 0;

		sn[49,11]._chaimg = "cc_yun0";
		sn[49,11]._mirror = false;
		sn[49,11]._pos = 0;
		sn[49,11]._showef = 4;
		sn[49,11]._txtidx = 434;
		sn[49,11]._extraimg = 0;


		///*17-2*/
		sn[50,0]._chaimg = "cc_shop";
		sn[50,0]._mirror = false;
		sn[50,0]._pos = 0;
		sn[50,0]._showef = 1;
		sn[50,0]._txtidx = 435;
		sn[50,0]._extraimg = 0;

		sn[50,1]._chaimg = "cc_pet";
		sn[50,1]._mirror = false;
		sn[50,1]._pos = 0;
		sn[50,1]._showef = 1;
		sn[50,1]._txtidx = 436;
		sn[50,1]._extraimg = 0;

		sn[50,2]._chaimg = "cc_cha1";
		sn[50,2]._mirror = false;
		sn[50,2]._pos = 1;
		sn[50,2]._showef = 1;
		sn[50,2]._txtidx = 437;
		sn[50,2]._extraimg = 0;

		sn[50,3]._chaimg = "cc_yun0";
		sn[50,3]._mirror = false;
		sn[50,3]._pos = 0;
		sn[50,3]._showef = 1;
		sn[50,3]._txtidx = 438;
		sn[50,3]._extraimg = 0;

		sn[50,4]._chaimg = "cc_cha0";
		sn[50,4]._mirror = false;
		sn[50,4]._pos = 1;
		sn[50,4]._showef = 0;
		sn[50,4]._txtidx = 439;
		sn[50,4]._extraimg = 0;

		sn[50,5]._chaimg = "cc_yun0";
		sn[50,5]._mirror = false;
		sn[50,5]._pos = 0;
		sn[50,5]._showef = 0;
		sn[50,5]._txtidx = 440;
		sn[50,5]._extraimg = 0;

		sn[50,6]._chaimg = "cc_cha1";
		sn[50,6]._mirror = false;
		sn[50,6]._pos = 1;
		sn[50,6]._showef = 4;
		sn[50,6]._txtidx = 441;
		sn[50,6]._extraimg = 0;


		///*17-3*/
		sn[51,0]._chaimg = "cc_cha0";
		sn[51,0]._mirror = false;
		sn[51,0]._pos = 1;
		sn[51,0]._showef = 1;
		sn[51,0]._txtidx = 442;
		sn[51,0]._extraimg = 0;

		sn[51,1]._chaimg = "cc_yun0";
		sn[51,1]._mirror = false;
		sn[51,1]._pos = 0;
		sn[51,1]._showef = 1;
		sn[51,1]._txtidx = 443;
		sn[51,1]._extraimg = 0;

		sn[51,2]._chaimg = "cc_yun0";
		sn[51,2]._mirror = false;
		sn[51,2]._pos = 0;
		sn[51,2]._showef = 0;
		sn[51,2]._txtidx = 444;
		sn[51,2]._extraimg = 0;

		sn[51,3]._chaimg = "cc_cha0";
		sn[51,3]._mirror = false;
		sn[51,3]._pos = 1;
		sn[51,3]._showef = 0;
		sn[51,3]._txtidx = 445;
		sn[51,3]._extraimg = 0;

		sn[51,4]._chaimg = "cc_yun0";
		sn[51,4]._mirror = false;
		sn[51,4]._pos = 0;
		sn[51,4]._showef = 0;
		sn[51,4]._txtidx = 446;
		sn[51,4]._extraimg = 0;

		sn[51,5]._chaimg = "cc_cha0";
		sn[51,5]._mirror = false;
		sn[51,5]._pos = 1;
		sn[51,5]._showef = 0;
		sn[51,5]._txtidx = 447;
		sn[51,5]._extraimg = 0;

		sn[51,6]._chaimg = "cc_yun0";
		sn[51,6]._mirror = false;
		sn[51,6]._pos = 0;
		sn[51,6]._showef = 0;
		sn[51,6]._txtidx = 448;
		sn[51,6]._extraimg = 0;

		sn[51,7]._chaimg = "cc_cha1";
		sn[51,7]._mirror = false;
		sn[51,7]._pos = 1;
		sn[51,7]._showef = 0;
		sn[51,7]._txtidx = 449;
		sn[51,7]._extraimg = 0;

		sn[51,8]._chaimg = "cc_yun0";
		sn[51,8]._mirror = false;
		sn[51,8]._pos = 0;
		sn[51,8]._showef = 4;
		sn[51,8]._txtidx = 450;
		sn[51,8]._extraimg = 0;


		///*18-1*/
		sn[52,0]._chaimg = "cc_cha0";
		sn[52,0]._mirror = false;
		sn[52,0]._pos = 1;
		sn[52,0]._showef = 1;
		sn[52,0]._txtidx = 451;
		sn[52,0]._extraimg = 0;

		sn[52,1]._chaimg = "cc_yun0";
		sn[52,1]._mirror = false;
		sn[52,1]._pos = 0;
		sn[52,1]._showef = 1;
		sn[52,1]._txtidx = 452;
		sn[52,1]._extraimg = 0;

		sn[52,2]._chaimg = "cc_yun0";
		sn[52,2]._mirror = false;
		sn[52,2]._pos = 0;
		sn[52,2]._showef = 0;
		sn[52,2]._txtidx = 453;
		sn[52,2]._extraimg = 0;

		sn[52,3]._chaimg = "cc_cha0";
		sn[52,3]._mirror = false;
		sn[52,3]._pos = 1;
		sn[52,3]._showef = 0;
		sn[52,3]._txtidx = 454;
		sn[52,3]._extraimg = 0;

		sn[52,4]._chaimg = "cc_yun0";
		sn[52,4]._mirror = false;
		sn[52,4]._pos = 0;
		sn[52,4]._showef = 0;
		sn[52,4]._txtidx = 455;
		sn[52,4]._extraimg = 0;

		sn[52,5]._chaimg = "cc_cha1";
		sn[52,5]._mirror = false;
		sn[52,5]._pos = 1;
		sn[52,5]._showef = 0;
		sn[52,5]._txtidx = 456;
		sn[52,5]._extraimg = 0;

		sn[52,6]._chaimg = "cc_yun0";
		sn[52,6]._mirror = false;
		sn[52,6]._pos = 0;
		sn[52,6]._showef = 4;
		sn[52,6]._txtidx = 457;
		sn[52,6]._extraimg = 0;


		///*18-2*/
		sn[53,0]._chaimg = "cc_cha0";
		sn[53,0]._mirror = false;
		sn[53,0]._pos = 1;
		sn[53,0]._showef = 1;
		sn[53,0]._txtidx = 458;
		sn[53,0]._extraimg = 0;

		sn[53,1]._chaimg = "cc_pet";
		sn[53,1]._mirror = false;
		sn[53,1]._pos = 0;
		sn[53,1]._showef = 1;
		sn[53,1]._txtidx = 459;
		sn[53,1]._extraimg = 0;

		sn[53,2]._chaimg = "cc_cha0";
		sn[53,2]._mirror = false;
		sn[53,2]._pos = 1;
		sn[53,2]._showef = 0;
		sn[53,2]._txtidx = 460;
		sn[53,2]._extraimg = 0;

		sn[53,3]._chaimg = "cc_pet";
		sn[53,3]._mirror = false;
		sn[53,3]._pos = 0;
		sn[53,3]._showef = 0;
		sn[53,3]._txtidx = 461;
		sn[53,3]._extraimg = 0;

		sn[53,4]._chaimg = "cc_cha0";
		sn[53,4]._mirror = false;
		sn[53,4]._pos = 1;
		sn[53,4]._showef = 0;
		sn[53,4]._txtidx = 462;
		sn[53,4]._extraimg = 0;

		sn[53,5]._chaimg = "cc_pet";
		sn[53,5]._mirror = false;
		sn[53,5]._pos = 0;
		sn[53,5]._showef = 0;
		sn[53,5]._txtidx = 463;
		sn[53,5]._extraimg = 0;

		sn[53,6]._chaimg = "cc_cha2";
		sn[53,6]._mirror = false;
		sn[53,6]._pos = 1;
		sn[53,6]._showef = 2;
		sn[53,6]._txtidx = 464;
		sn[53,6]._extraimg = 0;

		sn[53,7]._chaimg = "fortuneteller";
		sn[53,7]._mirror = false;
		sn[53,7]._pos = 0;
		sn[53,7]._showef = 1;
		sn[53,7]._txtidx = 465;
		sn[53,7]._extraimg = 0;

		sn[53,8]._chaimg = "cc_cha1";
		sn[53,8]._mirror = false;
		sn[53,8]._pos = 1;
		sn[53,8]._showef = 0;
		sn[53,8]._txtidx = 466;
		sn[53,8]._extraimg = 0;

		sn[53,9]._chaimg = "fortuneteller";
		sn[53,9]._mirror = false;
		sn[53,9]._pos = 0;
		sn[53,9]._showef = 0;
		sn[53,9]._txtidx = 467;
		sn[53,9]._extraimg = 0;

		sn[53,10]._chaimg = "cc_cha3";
		sn[53,10]._mirror = false;
		sn[53,10]._pos = 1;
		sn[53,10]._showef = 0;
		sn[53,10]._txtidx = 468;
		sn[53,10]._extraimg = 0;

		sn[53,11]._chaimg = "cc_pet";
		sn[53,11]._mirror = false;
		sn[53,11]._pos = 0;
		sn[53,11]._showef = 1;
		sn[53,11]._txtidx = 469;
		sn[53,11]._extraimg = 0;

		sn[53,12]._chaimg = "cc_cha2";
		sn[53,12]._mirror = false;
		sn[53,12]._pos = 1;
		sn[53,12]._showef = 4;
		sn[53,12]._txtidx = 470;
		sn[53,12]._extraimg = 0;


		///*18-3*/
		sn[54,0]._chaimg = "cc_cha2";
		sn[54,0]._mirror = false;
		sn[54,0]._pos = 1;
		sn[54,0]._showef = 1;
		sn[54,0]._txtidx = 471;
		sn[54,0]._extraimg = 0;

		sn[54,1]._chaimg = "cc_shop";
		sn[54,1]._mirror = false;
		sn[54,1]._pos = 0;
		sn[54,1]._showef = 1;
		sn[54,1]._txtidx = 472;
		sn[54,1]._extraimg = 0;

		sn[54,2]._chaimg = "cc_cha4";
		sn[54,2]._mirror = false;
		sn[54,2]._pos = 1;
		sn[54,2]._showef = 0;
		sn[54,2]._txtidx = 473;
		sn[54,2]._extraimg = 0;

		sn[54,3]._chaimg = "cc_pet";
		sn[54,3]._mirror = false;
		sn[54,3]._pos = 0;
		sn[54,3]._showef = 2;
		sn[54,3]._txtidx = 474;
		sn[54,3]._extraimg = 0;

		sn[54,4]._chaimg = "cc_archive";
		sn[54,4]._mirror = false;
		sn[54,4]._pos = 0;
		sn[54,4]._showef = 2;
		sn[54,4]._txtidx = 475;
		sn[54,4]._extraimg = 0;

		sn[54,5]._chaimg = "cc_shop";
		sn[54,5]._mirror = false;
		sn[54,5]._pos = 0;
		sn[54,5]._showef = 2;
		sn[54,5]._txtidx = 476;
		sn[54,5]._extraimg = 0;

		sn[54,6]._chaimg = "cc_pet";
		sn[54,6]._mirror = false;
		sn[54,6]._pos = 0;
		sn[54,6]._showef = 1;
		sn[54,6]._txtidx = 477;
		sn[54,6]._extraimg = 0;

		sn[54,7]._chaimg = "cc_archive";
		sn[54,7]._mirror = false;
		sn[54,7]._pos = 0;
		sn[54,7]._showef = 1;
		sn[54,7]._txtidx = 478;
		sn[54,7]._extraimg = 0;

		sn[54,8]._chaimg = "cc_shop";
		sn[54,8]._mirror = false;
		sn[54,8]._pos = 0;
		sn[54,8]._showef = 1;
		sn[54,8]._txtidx = 479;
		sn[54,8]._extraimg = 0;

		sn[54,9]._chaimg = "cc_cha2";
		sn[54,9]._mirror = false;
		sn[54,9]._pos = 1;
		sn[54,9]._showef = 4;
		sn[54,9]._txtidx = 480;
		sn[54,9]._extraimg = 0;


		///*19-1*/
		sn[55,0]._chaimg = "cc_skill";
		sn[55,0]._mirror = false;
		sn[55,0]._pos = 0;
		sn[55,0]._showef = 1;
		sn[55,0]._txtidx = 481;
		sn[55,0]._extraimg = 0;

		sn[55,1]._chaimg = "cc_cha0";
		sn[55,1]._mirror = false;
		sn[55,1]._pos = 1;
		sn[55,1]._showef = 1;
		sn[55,1]._txtidx = 482;
		sn[55,1]._extraimg = 0;

		sn[55,2]._chaimg = "cc_skill";
		sn[55,2]._mirror = false;
		sn[55,2]._pos = 0;
		sn[55,2]._showef = 0;
		sn[55,2]._txtidx = 483;
		sn[55,2]._extraimg = 0;

		sn[55,3]._chaimg = "cc_shop";
		sn[55,3]._mirror = false;
		sn[55,3]._pos = 0;
		sn[55,3]._showef = 1;
		sn[55,3]._txtidx = 484;
		sn[55,3]._extraimg = 0;

		sn[55,4]._chaimg = "cc_cha0";
		sn[55,4]._mirror = false;
		sn[55,4]._pos = 1;
		sn[55,4]._showef = 0;
		sn[55,4]._txtidx = 485;
		sn[55,4]._extraimg = 0;

		sn[55,5]._chaimg = "cc_skill";
		sn[55,5]._mirror = false;
		sn[55,5]._pos = 0;
		sn[55,5]._showef = 4;
		sn[55,5]._txtidx = 486;
		sn[55,5]._extraimg = 0;


		///*19-2*/
		sn[56,0]._chaimg = "cc_shop";
		sn[56,0]._mirror = false;
		sn[56,0]._pos = 0;
		sn[56,0]._showef = 1;
		sn[56,0]._txtidx = 487;
		sn[56,0]._extraimg = 0;

		sn[56,1]._chaimg = "cc_cha0";
		sn[56,1]._mirror = false;
		sn[56,1]._pos = 1;
		sn[56,1]._showef = 1;
		sn[56,1]._txtidx = 488;
		sn[56,1]._extraimg = 0;

		sn[56,2]._chaimg = "cc_shop";
		sn[56,2]._mirror = false;
		sn[56,2]._pos = 0;
		sn[56,2]._showef = 0;
		sn[56,2]._txtidx = 489;
		sn[56,2]._extraimg = 0;

		sn[56,3]._chaimg = "cc_pet";
		sn[56,3]._mirror = false;
		sn[56,3]._pos = 0;
		sn[56,3]._showef = 1;
		sn[56,3]._txtidx = 490;
		sn[56,3]._extraimg = 0;

		sn[56,4]._chaimg = "cc_cha0";
		sn[56,4]._mirror = false;
		sn[56,4]._pos = 1;
		sn[56,4]._showef = 0;
		sn[56,4]._txtidx = 491;
		sn[56,4]._extraimg = 0;

		sn[56,5]._chaimg = "cc_pet";
		sn[56,5]._mirror = false;
		sn[56,5]._pos = 0;
		sn[56,5]._showef = 0;
		sn[56,5]._txtidx = 492;
		sn[56,5]._extraimg = 0;

		sn[56,6]._chaimg = "cc_archive";
		sn[56,6]._mirror = false;
		sn[56,6]._pos = 0;
		sn[56,6]._showef = 1;
		sn[56,6]._txtidx = 493;
		sn[56,6]._extraimg = 0;

		sn[56,7]._chaimg = "cc_cha0";
		sn[56,7]._mirror = false;
		sn[56,7]._pos = 1;
		sn[56,7]._showef = 4;
		sn[56,7]._txtidx = 494;
		sn[56,7]._extraimg = 0;


		///*19-3*/
		sn[57,0]._chaimg = "cc_skill";
		sn[57,0]._mirror = false;
		sn[57,0]._pos = 0;
		sn[57,0]._showef = 1;
		sn[57,0]._txtidx = 495;
		sn[57,0]._extraimg = 0;

		sn[57,1]._chaimg = "cc_cha0";
		sn[57,1]._mirror = false;
		sn[57,1]._pos = 1;
		sn[57,1]._showef = 1;
		sn[57,1]._txtidx = 496;
		sn[57,1]._extraimg = 0;

		sn[57,2]._chaimg = "cc_skill";
		sn[57,2]._mirror = false;
		sn[57,2]._pos = 0;
		sn[57,2]._showef = 0;
		sn[57,2]._txtidx = 497;
		sn[57,2]._extraimg = 0;

		sn[57,3]._chaimg = "cc_cha2";
		sn[57,3]._mirror = false;
		sn[57,3]._pos = 1;
		sn[57,3]._showef = 0;
		sn[57,3]._txtidx = 498;
		sn[57,3]._extraimg = 0;

		sn[57,4]._chaimg = "cc_skill";
		sn[57,4]._mirror = false;
		sn[57,4]._pos = 0;
		sn[57,4]._showef = 0;
		sn[57,4]._txtidx = 499;
		sn[57,4]._extraimg = 0;

		sn[57,5]._chaimg = "cc_cha0";
		sn[57,5]._mirror = false;
		sn[57,5]._pos = 1;
		sn[57,5]._showef = 0;
		sn[57,5]._txtidx = 500;
		sn[57,5]._extraimg = 0;

		sn[57,6]._chaimg = "cc_skill";
		sn[57,6]._mirror = false;
		sn[57,6]._pos = 0;
		sn[57,6]._showef = 0;
		sn[57,6]._txtidx = 501;
		sn[57,6]._extraimg = 0;

		sn[57,7]._chaimg = "cc_cha2";
		sn[57,7]._mirror = false;
		sn[57,7]._pos = 1;
		sn[57,7]._showef = 4;
		sn[57,7]._txtidx = 502;
		sn[57,7]._extraimg = 0;


		///*20-1*/
		sn[58,0]._chaimg = "cc_cha0";
		sn[58,0]._mirror = false;
		sn[58,0]._pos = 1;
		sn[58,0]._showef = 1;
		sn[58,0]._txtidx = 503;
		sn[58,0]._extraimg = 0;

		sn[58,1]._chaimg = "cc_pet";
		sn[58,1]._mirror = false;
		sn[58,1]._pos = 0;
		sn[58,1]._showef = 1;
		sn[58,1]._txtidx = 504;
		sn[58,1]._extraimg = 0;

		sn[58,2]._chaimg = "cc_cha3";
		sn[58,2]._mirror = false;
		sn[58,2]._pos = 1;
		sn[58,2]._showef = 0;
		sn[58,2]._txtidx = 505;
		sn[58,2]._extraimg = 0;

		sn[58,3]._chaimg = "cc_pet";
		sn[58,3]._mirror = false;
		sn[58,3]._pos = 0;
		sn[58,3]._showef = 0;
		sn[58,3]._txtidx = 506;
		sn[58,3]._extraimg = 0;

		sn[58,4]._chaimg = "cc_cha0";
		sn[58,4]._mirror = false;
		sn[58,4]._pos = 1;
		sn[58,4]._showef = 0;
		sn[58,4]._txtidx = 507;
		sn[58,4]._extraimg = 0;

		sn[58,5]._chaimg = "cc_cha1";
		sn[58,5]._mirror = false;
		sn[58,5]._pos = 1;
		sn[58,5]._showef = 0;
		sn[58,5]._txtidx = 508;
		sn[58,5]._extraimg = 0;

		sn[58,6]._chaimg = "cc_pet";
		sn[58,6]._mirror = false;
		sn[58,6]._pos = 0;
		sn[58,6]._showef = 0;
		sn[58,6]._txtidx = 509;
		sn[58,6]._extraimg = 0;

		sn[58,7]._chaimg = "cc_cha1";
		sn[58,7]._mirror = false;
		sn[58,7]._pos = 1;
		sn[58,7]._showef = 0;
		sn[58,7]._txtidx = 510;
		sn[58,7]._extraimg = 0;

		sn[58,8]._chaimg = "cc_pet";
		sn[58,8]._mirror = false;
		sn[58,8]._pos = 0;
		sn[58,8]._showef = 0;
		sn[58,8]._txtidx = 511;
		sn[58,8]._extraimg = 0;

		sn[58,9]._chaimg = "cc_cha2";
		sn[58,9]._mirror = false;
		sn[58,9]._pos = 1;
		sn[58,9]._showef = 4;
		sn[58,9]._txtidx = 512;
		sn[58,9]._extraimg = 0;


		///*20-2*/
		sn[59,0]._chaimg = "cc_cha0";
		sn[59,0]._mirror = false;
		sn[59,0]._pos = 1;
		sn[59,0]._showef = 1;
		sn[59,0]._txtidx = 513;
		sn[59,0]._extraimg = 0;

		sn[59,1]._chaimg = "cc_shop";
		sn[59,1]._mirror = false;
		sn[59,1]._pos = 0;
		sn[59,1]._showef = 1;
		sn[59,1]._txtidx = 514;
		sn[59,1]._extraimg = 0;

		sn[59,2]._chaimg = "cc_cha4";
		sn[59,2]._mirror = false;
		sn[59,2]._pos = 1;
		sn[59,2]._showef = 0;
		sn[59,2]._txtidx = 515;
		sn[59,2]._extraimg = 0;

		sn[59,3]._chaimg = "cc_archive";
		sn[59,3]._mirror = false;
		sn[59,3]._pos = 0;
		sn[59,3]._showef = 1;
		sn[59,3]._txtidx = 516;
		sn[59,3]._extraimg = 0;

		sn[59,4]._chaimg = "cc_cha0";
		sn[59,4]._mirror = false;
		sn[59,4]._pos = 1;
		sn[59,4]._showef = 0;
		sn[59,4]._txtidx = 517;
		sn[59,4]._extraimg = 0;

		sn[59,5]._chaimg = "cc_shop";
		sn[59,5]._mirror = false;
		sn[59,5]._pos = 0;
		sn[59,5]._showef = 4;
		sn[59,5]._txtidx = 518;
		sn[59,5]._extraimg = 0;


		///*20-3*/
		sn[60,0]._chaimg = "cc_cha6";
		sn[60,0]._mirror = false;
		sn[60,0]._pos = 1;
		sn[60,0]._showef = 1;
		sn[60,0]._txtidx = 519;
		sn[60,0]._extraimg = 0;

		sn[60,1]._chaimg = "cc_yun0";
		sn[60,1]._mirror = false;
		sn[60,1]._pos = 0;
		sn[60,1]._showef = 1;
		sn[60,1]._txtidx = 520;
		sn[60,1]._extraimg = 0;

		sn[60,2]._chaimg = "cc_cha6";
		sn[60,2]._mirror = false;
		sn[60,2]._pos = 1;
		sn[60,2]._showef = 2;
		sn[60,2]._txtidx = 521;
		sn[60,2]._extraimg = 0;

		sn[60,3]._chaimg = "cc_yun0";
		sn[60,3]._mirror = false;
		sn[60,3]._pos = 0;
		sn[60,3]._showef = 0;
		sn[60,3]._txtidx = 522;
		sn[60,3]._extraimg = 0;

		sn[60,4]._chaimg = "cc_cha6";
		sn[60,4]._mirror = false;
		sn[60,4]._pos = 1;
		sn[60,4]._showef = 0;
		sn[60,4]._txtidx = 523;
		sn[60,4]._extraimg = 0;

		sn[60,5]._chaimg = "cc_yun0";
		sn[60,5]._mirror = false;
		sn[60,5]._pos = 0;
		sn[60,5]._showef = 0;
		sn[60,5]._txtidx = 524;
		sn[60,5]._extraimg = 0;

		sn[60,6]._chaimg = "cc_cha6";
		sn[60,6]._mirror = false;
		sn[60,6]._pos = 1;
		sn[60,6]._showef = 0;
		sn[60,6]._txtidx = 525;
		sn[60,6]._extraimg = 0;

		sn[60,7]._chaimg = "cc_yun0";
		sn[60,7]._mirror = false;
		sn[60,7]._pos = 0;
		sn[60,7]._showef = 4;
		sn[60,7]._txtidx = 526;
		sn[60,7]._extraimg = 0;


		///*21-1*/
		sn[61,0]._chaimg = "cc_cha1";
		sn[61,0]._mirror = false;
		sn[61,0]._pos = 1;
		sn[61,0]._showef = 1;
		sn[61,0]._txtidx = 527;
		sn[61,0]._extraimg = 0;

		sn[61,1]._chaimg = "cc_yun0";
		sn[61,1]._mirror = false;
		sn[61,1]._pos = 0;
		sn[61,1]._showef = 1;
		sn[61,1]._txtidx = 528;
		sn[61,1]._extraimg = 0;

		sn[61,2]._chaimg = "cc_shop";
		sn[61,2]._mirror = false;
		sn[61,2]._pos = 0;
		sn[61,2]._showef = 1;
		sn[61,2]._txtidx = 529;
		sn[61,2]._extraimg = 0;

		sn[61,3]._chaimg = "cc_cha4";
		sn[61,3]._mirror = false;
		sn[61,3]._pos = 1;
		sn[61,3]._showef = 0;
		sn[61,3]._txtidx = 530;
		sn[61,3]._extraimg = 0;

		sn[61,4]._chaimg = "cc_cha2";
		sn[61,4]._mirror = false;
		sn[61,4]._pos = 1;
		sn[61,4]._showef = 0;
		sn[61,4]._txtidx = 531;
		sn[61,4]._extraimg = 0;

		sn[61,5]._chaimg = "cc_yun0";
		sn[61,5]._mirror = false;
		sn[61,5]._pos = 0;
		sn[61,5]._showef = 1;
		sn[61,5]._txtidx = 532;
		sn[61,5]._extraimg = 0;

		sn[61,6]._chaimg = "cc_cha0";
		sn[61,6]._mirror = false;
		sn[61,6]._pos = 1;
		sn[61,6]._showef = 0;
		sn[61,6]._txtidx = 533;
		sn[61,6]._extraimg = 0;

		sn[61,7]._chaimg = "cc_archive";
		sn[61,7]._mirror = false;
		sn[61,7]._pos = 0;
		sn[61,7]._showef = 1;
		sn[61,7]._txtidx = 534;
		sn[61,7]._extraimg = 0;

		sn[61,8]._chaimg = "cc_shop";
		sn[61,8]._mirror = false;
		sn[61,8]._pos = 0;
		sn[61,8]._showef = 0;
		sn[61,8]._txtidx = 535;
		sn[61,8]._extraimg = 0;

		sn[61,9]._chaimg = "cc_pet";
		sn[61,9]._mirror = false;
		sn[61,9]._pos = 0;
		sn[61,9]._showef = 0;
		sn[61,9]._txtidx = 536;
		sn[61,9]._extraimg = 0;

		sn[61,10]._chaimg = "cc_cha1";
		sn[61,10]._mirror = false;
		sn[61,10]._pos = 1;
		sn[61,10]._showef = 4;
		sn[61,10]._txtidx = 537;
		sn[61,10]._extraimg = 0;


		///*21-2*/
		sn[62,0]._chaimg = "cc_cha0";
		sn[62,0]._mirror = false;
		sn[62,0]._pos = 1;
		sn[62,0]._showef = 0;
		sn[62,0]._txtidx = 538;
		sn[62,0]._extraimg = 0;

		sn[62,1]._chaimg = "cc_yun0";
		sn[62,1]._mirror = false;
		sn[62,1]._pos = 0;
		sn[62,1]._showef = 1;
		sn[62,1]._txtidx = 539;
		sn[62,1]._extraimg = 0;

		sn[62,2]._chaimg = "cc_pet";
		sn[62,2]._mirror = false;
		sn[62,2]._pos = 0;
		sn[62,2]._showef = 0;
		sn[62,2]._txtidx = 540;
		sn[62,2]._extraimg = 0;

		sn[62,3]._chaimg = "cc_yun0";
		sn[62,3]._mirror = false;
		sn[62,3]._pos = 0;
		sn[62,3]._showef = 0;
		sn[62,3]._txtidx = 541;
		sn[62,3]._extraimg = 0;

		sn[62,4]._chaimg = "cc_cha0";
		sn[62,4]._mirror = false;
		sn[62,4]._pos = 1;
		sn[62,4]._showef = 1;
		sn[62,4]._txtidx = 542;
		sn[62,4]._extraimg = 0;

		sn[62,5]._chaimg = "cc_yun0";
		sn[62,5]._mirror = false;
		sn[62,5]._pos = 0;
		sn[62,5]._showef = 0;
		sn[62,5]._txtidx = 543;
		sn[62,5]._extraimg = 0;

		sn[62,6]._chaimg = "cc_cha1";
		sn[62,6]._mirror = false;
		sn[62,6]._pos = 1;
		sn[62,6]._showef = 1;
		sn[62,6]._txtidx = 544;
		sn[62,6]._extraimg = 0;

		sn[62,7]._chaimg = "cc_yun0";
		sn[62,7]._mirror = false;
		sn[62,7]._pos = 0;
		sn[62,7]._showef = 0;
		sn[62,7]._txtidx = 545;
		sn[62,7]._extraimg = 0;

		sn[62,8]._chaimg = "cc_pet";
		sn[62,8]._mirror = false;
		sn[62,8]._pos = 0;
		sn[62,8]._showef = 1;
		sn[62,8]._txtidx = 546;
		sn[62,8]._extraimg = 0;

		sn[62,9]._chaimg = "cc_cha3";
		sn[62,9]._mirror = false;
		sn[62,9]._pos = 1;
		sn[62,9]._showef = 0;
		sn[62,9]._txtidx = 547;
		sn[62,9]._extraimg = 1007;

		sn[62,10]._chaimg = "cc_yun0";
		sn[62,10]._mirror = false;
		sn[62,10]._pos = 0;
		sn[62,10]._showef = 4;
		sn[62,10]._txtidx = 548;
		sn[62,10]._extraimg = 0;


		///*21-3*/
		sn[63,0]._chaimg = "cc_shop";
		sn[63,0]._mirror = false;
		sn[63,0]._pos = 0;
		sn[63,0]._showef = 1;
		sn[63,0]._txtidx = 549;
		sn[63,0]._extraimg = 0;

		sn[63,1]._chaimg = "cc_cha0";
		sn[63,1]._mirror = false;
		sn[63,1]._pos = 1;
		sn[63,1]._showef = 1;
		sn[63,1]._txtidx = 550;
		sn[63,1]._extraimg = 0;

		sn[63,2]._chaimg = "cc_shop";
		sn[63,2]._mirror = false;
		sn[63,2]._pos = 0;
		sn[63,2]._showef = 0;
		sn[63,2]._txtidx = 551;
		sn[63,2]._extraimg = 0;

		sn[63,3]._chaimg = "cc_cha0";
		sn[63,3]._mirror = false;
		sn[63,3]._pos = 1;
		sn[63,3]._showef = 0;
		sn[63,3]._txtidx = 552;
		sn[63,3]._extraimg = 0;

		sn[63,4]._chaimg = "cc_shop";
		sn[63,4]._mirror = false;
		sn[63,4]._pos = 0;
		sn[63,4]._showef = 0;
		sn[63,4]._txtidx = 553;
		sn[63,4]._extraimg = 0;

		sn[63,5]._chaimg = "cc_cha0";
		sn[63,5]._mirror = false;
		sn[63,5]._pos = 1;
		sn[63,5]._showef = 0;
		sn[63,5]._txtidx = 554;
		sn[63,5]._extraimg = 0;

		sn[63,6]._chaimg = "cc_shop";
		sn[63,6]._mirror = false;
		sn[63,6]._pos = 0;
		sn[63,6]._showef = 0;
		sn[63,6]._txtidx = 555;
		sn[63,6]._extraimg = 0;

		sn[63,7]._chaimg = "cc_shop";
		sn[63,7]._mirror = false;
		sn[63,7]._pos = 0;
		sn[63,7]._showef = 0;
		sn[63,7]._txtidx = 556;
		sn[63,7]._extraimg = 0;

		sn[63,8]._chaimg = "cc_cha0";
		sn[63,8]._mirror = false;
		sn[63,8]._pos = 1;
		sn[63,8]._showef = 0;
		sn[63,8]._txtidx = 557;
		sn[63,8]._extraimg = 0;

		sn[63,9]._chaimg = "cc_shop";
		sn[63,9]._mirror = false;
		sn[63,9]._pos = 0;
		sn[63,9]._showef = 4;
		sn[63,9]._txtidx = 558;
		sn[63,9]._extraimg = 0;


		///*22-1*/
		sn[64,0]._chaimg = "cc_skill";
		sn[64,0]._mirror = false;
		sn[64,0]._pos = 0;
		sn[64,0]._showef = 1;
		sn[64,0]._txtidx = 559;
		sn[64,0]._extraimg = 0;

		sn[64,1]._chaimg = "cc_cha0";
		sn[64,1]._mirror = false;
		sn[64,1]._pos = 1;
		sn[64,1]._showef = 1;
		sn[64,1]._txtidx = 560;
		sn[64,1]._extraimg = 0;

		sn[64,2]._chaimg = "cc_skill";
		sn[64,2]._mirror = false;
		sn[64,2]._pos = 0;
		sn[64,2]._showef = 0;
		sn[64,2]._txtidx = 561;
		sn[64,2]._extraimg = 0;

		sn[64,3]._chaimg = "cc_cha1";
		sn[64,3]._mirror = false;
		sn[64,3]._pos = 1;
		sn[64,3]._showef = 0;
		sn[64,3]._txtidx = 562;
		sn[64,3]._extraimg = 0;

		sn[64,4]._chaimg = "cc_skill";
		sn[64,4]._mirror = false;
		sn[64,4]._pos = 0;
		sn[64,4]._showef = 0;
		sn[64,4]._txtidx = 563;
		sn[64,4]._extraimg = 0;

		sn[64,5]._chaimg = "cc_cha0";
		sn[64,5]._mirror = false;
		sn[64,5]._pos = 1;
		sn[64,5]._showef = 0;
		sn[64,5]._txtidx = 564;
		sn[64,5]._extraimg = 0;

		sn[64,6]._chaimg = "cc_skill";
		sn[64,6]._mirror = false;
		sn[64,6]._pos = 0;
		sn[64,6]._showef = 0;
		sn[64,6]._txtidx = 565;
		sn[64,6]._extraimg = 0;

		sn[64,7]._chaimg = "cc_skill";
		sn[64,7]._mirror = false;
		sn[64,7]._pos = 0;
		sn[64,7]._showef = 4;
		sn[64,7]._txtidx = 566;
		sn[64,7]._extraimg = 0;


		///*22-2*/
		sn[65,0]._chaimg = "cc_pet";
		sn[65,0]._mirror = false;
		sn[65,0]._pos = 0;
		sn[65,0]._showef = 1;
		sn[65,0]._txtidx = 567;
		sn[65,0]._extraimg = 0;

		sn[65,1]._chaimg = "cc_cha0";
		sn[65,1]._mirror = false;
		sn[65,1]._pos = 1;
		sn[65,1]._showef = 1;
		sn[65,1]._txtidx = 568;
		sn[65,1]._extraimg = 0;

		sn[65,2]._chaimg = "cc_cha2";
		sn[65,2]._mirror = false;
		sn[65,2]._pos = 1;
		sn[65,2]._showef = 0;
		sn[65,2]._txtidx = 569;
		sn[65,2]._extraimg = 0;

		sn[65,3]._chaimg = "cc_pet";
		sn[65,3]._mirror = false;
		sn[65,3]._pos = 0;
		sn[65,3]._showef = 0;
		sn[65,3]._txtidx = 570;
		sn[65,3]._extraimg = 0;

		sn[65,4]._chaimg = "cc_cha1";
		sn[65,4]._mirror = false;
		sn[65,4]._pos = 1;
		sn[65,4]._showef = 0;
		sn[65,4]._txtidx = 571;
		sn[65,4]._extraimg = 0;

		sn[65,5]._chaimg = "cc_shop";
		sn[65,5]._mirror = false;
		sn[65,5]._pos = 0;
		sn[65,5]._showef = 1;
		sn[65,5]._txtidx = 572;
		sn[65,5]._extraimg = 0;

		sn[65,6]._chaimg = "cc_archive";
		sn[65,6]._mirror = false;
		sn[65,6]._pos = 0;
		sn[65,6]._showef = 1;
		sn[65,6]._txtidx = 573;
		sn[65,6]._extraimg = 0;

		sn[65,7]._chaimg = "cc_cha2";
		sn[65,7]._mirror = false;
		sn[65,7]._pos = 1;
		sn[65,7]._showef = 4;
		sn[65,7]._txtidx = 574;
		sn[65,7]._extraimg = 0;


		///*22-3*/
		sn[66,0]._chaimg = "cc_pet";
		sn[66,0]._mirror = false;
		sn[66,0]._pos = 0;
		sn[66,0]._showef = 1;
		sn[66,0]._txtidx = 575;
		sn[66,0]._extraimg = 0;

		sn[66,1]._chaimg = "cc_cha2";
		sn[66,1]._mirror = false;
		sn[66,1]._pos = 1;
		sn[66,1]._showef = 1;
		sn[66,1]._txtidx = 576;
		sn[66,1]._extraimg = 0;

		sn[66,2]._chaimg = "cc_pet";
		sn[66,2]._mirror = false;
		sn[66,2]._pos = 0;
		sn[66,2]._showef = 0;
		sn[66,2]._txtidx = 577;
		sn[66,2]._extraimg = 0;

		sn[66,3]._chaimg = "cc_cha2";
		sn[66,3]._mirror = false;
		sn[66,3]._pos = 1;
		sn[66,3]._showef = 0;
		sn[66,3]._txtidx = 578;
		sn[66,3]._extraimg = 0;

		sn[66,4]._chaimg = "cc_pet";
		sn[66,4]._mirror = false;
		sn[66,4]._pos = 0;
		sn[66,4]._showef = 0;
		sn[66,4]._txtidx = 579;
		sn[66,4]._extraimg = 0;

		sn[66,5]._chaimg = "cc_cha0";
		sn[66,5]._mirror = false;
		sn[66,5]._pos = 1;
		sn[66,5]._showef = 0;
		sn[66,5]._txtidx = 580;
		sn[66,5]._extraimg = 0;

		sn[66,6]._chaimg = "cc_shop";
		sn[66,6]._mirror = false;
		sn[66,6]._pos = 0;
		sn[66,6]._showef = 1;
		sn[66,6]._txtidx = 581;
		sn[66,6]._extraimg = 0;

		sn[66,7]._chaimg = "cc_cha3";
		sn[66,7]._mirror = false;
		sn[66,7]._pos = 1;
		sn[66,7]._showef = 4;
		sn[66,7]._txtidx = 582;
		sn[66,7]._extraimg = 0;


		///*23-1*/
		sn[67,0]._chaimg = "cc_cha6";
		sn[67,0]._mirror = false;
		sn[67,0]._pos = 1;
		sn[67,0]._showef = 0;
		sn[67,0]._txtidx = 583;
		sn[67,0]._extraimg = 0;

		sn[67,1]._chaimg = "cc_pet";
		sn[67,1]._mirror = false;
		sn[67,1]._pos = 0;
		sn[67,1]._showef = 1;
		sn[67,1]._txtidx = 584;
		sn[67,1]._extraimg = 0;

		sn[67,2]._chaimg = "cc_cha0";
		sn[67,2]._mirror = false;
		sn[67,2]._pos = 1;
		sn[67,2]._showef = 0;
		sn[67,2]._txtidx = 585;
		sn[67,2]._extraimg = 0;

		sn[67,3]._chaimg = "cc_archive";
		sn[67,3]._mirror = false;
		sn[67,3]._pos = 0;
		sn[67,3]._showef = 1;
		sn[67,3]._txtidx = 586;
		sn[67,3]._extraimg = 0;

		sn[67,4]._chaimg = "cc_cha0";
		sn[67,4]._mirror = false;
		sn[67,4]._pos = 1;
		sn[67,4]._showef = 0;
		sn[67,4]._txtidx = 587;
		sn[67,4]._extraimg = 0;

		sn[67,5]._chaimg = "cc_archive";
		sn[67,5]._mirror = false;
		sn[67,5]._pos = 0;
		sn[67,5]._showef = 0;
		sn[67,5]._txtidx = 588;
		sn[67,5]._extraimg = 0;

		sn[67,6]._chaimg = "cc_cha0";
		sn[67,6]._mirror = false;
		sn[67,6]._pos = 1;
		sn[67,6]._showef = 0;
		sn[67,6]._txtidx = 589;
		sn[67,6]._extraimg = 0;

		sn[67,7]._chaimg = "cc_archive";
		sn[67,7]._mirror = false;
		sn[67,7]._pos = 0;
		sn[67,7]._showef = 0;
		sn[67,7]._txtidx = 590;
		sn[67,7]._extraimg = 0;

		sn[67,8]._chaimg = "cc_cha2";
		sn[67,8]._mirror = false;
		sn[67,8]._pos = 1;
		sn[67,8]._showef = 4;
		sn[67,8]._txtidx = 591;
		sn[67,8]._extraimg = 0;


		///*23-2*/
		sn[68,0]._chaimg = "cc_skill";
		sn[68,0]._mirror = false;
		sn[68,0]._pos = 0;
		sn[68,0]._showef = 1;
		sn[68,0]._txtidx = 592;
		sn[68,0]._extraimg = 0;

		sn[68,1]._chaimg = "cc_cha0";
		sn[68,1]._mirror = false;
		sn[68,1]._pos = 1;
		sn[68,1]._showef = 1;
		sn[68,1]._txtidx = 593;
		sn[68,1]._extraimg = 0;

		sn[68,2]._chaimg = "cc_skill";
		sn[68,2]._mirror = false;
		sn[68,2]._pos = 0;
		sn[68,2]._showef = 0;
		sn[68,2]._txtidx = 594;
		sn[68,2]._extraimg = 0;

		sn[68,3]._chaimg = "cc_cha1";
		sn[68,3]._mirror = false;
		sn[68,3]._pos = 1;
		sn[68,3]._showef = 0;
		sn[68,3]._txtidx = 595;
		sn[68,3]._extraimg = 0;

		sn[68,4]._chaimg = "cc_skill";
		sn[68,4]._mirror = false;
		sn[68,4]._pos = 0;
		sn[68,4]._showef = 0;
		sn[68,4]._txtidx = 596;
		sn[68,4]._extraimg = 0;

		sn[68,5]._chaimg = "cc_cha0";
		sn[68,5]._mirror = false;
		sn[68,5]._pos = 1;
		sn[68,5]._showef = 0;
		sn[68,5]._txtidx = 597;
		sn[68,5]._extraimg = 0;

		sn[68,6]._chaimg = "cc_skill";
		sn[68,6]._mirror = false;
		sn[68,6]._pos = 0;
		sn[68,6]._showef = 0;
		sn[68,6]._txtidx = 598;
		sn[68,6]._extraimg = 0;

		sn[68,7]._chaimg = "cc_cha0";
		sn[68,7]._mirror = false;
		sn[68,7]._pos = 1;
		sn[68,7]._showef = 0;
		sn[68,7]._txtidx = 599;
		sn[68,7]._extraimg = 0;

		sn[68,8]._chaimg = "cc_skill";
		sn[68,8]._mirror = false;
		sn[68,8]._pos = 0;
		sn[68,8]._showef = 0;
		sn[68,8]._txtidx = 600;
		sn[68,8]._extraimg = 0;

		sn[68,9]._chaimg = "cc_cha1";
		sn[68,9]._mirror = false;
		sn[68,9]._pos = 1;
		sn[68,9]._showef = 4;
		sn[68,9]._txtidx = 601;
		sn[68,9]._extraimg = 0;


		///*23-3*/
		sn[69,0]._chaimg = "cc_yun0";
		sn[69,0]._mirror = false;
		sn[69,0]._pos = 0;
		sn[69,0]._showef = 1;
		sn[69,0]._txtidx = 602;
		sn[69,0]._extraimg = 0;

		sn[69,1]._chaimg = "cc_cha2";
		sn[69,1]._mirror = false;
		sn[69,1]._pos = 1;
		sn[69,1]._showef = 1;
		sn[69,1]._txtidx = 603;
		sn[69,1]._extraimg = 0;

		sn[69,2]._chaimg = "cc_yun0";
		sn[69,2]._mirror = false;
		sn[69,2]._pos = 0;
		sn[69,2]._showef = 0;
		sn[69,2]._txtidx = 604;
		sn[69,2]._extraimg = 0;

		sn[69,3]._chaimg = "cc_cha2";
		sn[69,3]._mirror = false;
		sn[69,3]._pos = 1;
		sn[69,3]._showef = 0;
		sn[69,3]._txtidx = 605;
		sn[69,3]._extraimg = 0;

		sn[69,4]._chaimg = "cc_pet";
		sn[69,4]._mirror = false;
		sn[69,4]._pos = 1;
		sn[69,4]._showef = 1;
		sn[69,4]._txtidx = 606;
		sn[69,4]._extraimg = 0;

		sn[69,5]._chaimg = "cc_yun0";
		sn[69,5]._mirror = false;
		sn[69,5]._pos = 0;
		sn[69,5]._showef = 4;
		sn[69,5]._txtidx = 607;
		sn[69,5]._extraimg = 0;


		///*24-1*/
		sn[70,0]._chaimg = "cc_pet";
		sn[70,0]._mirror = false;
		sn[70,0]._pos = 1;
		sn[70,0]._showef = 1;
		sn[70,0]._txtidx = 608;
		sn[70,0]._extraimg = 0;

		sn[70,1]._chaimg = "cc_shop";
		sn[70,1]._mirror = false;
		sn[70,1]._pos = 0;
		sn[70,1]._showef = 1;
		sn[70,1]._txtidx = 609;
		sn[70,1]._extraimg = 0;

		sn[70,2]._chaimg = "cc_cha1";
		sn[70,2]._mirror = false;
		sn[70,2]._pos = 1;
		sn[70,2]._showef = 1;
		sn[70,2]._txtidx = 610;
		sn[70,2]._extraimg = 0;

		sn[70,3]._chaimg = "cc_cha1";
		sn[70,3]._mirror = false;
		sn[70,3]._pos = 1;
		sn[70,3]._showef = 0;
		sn[70,3]._txtidx = 611;
		sn[70,3]._extraimg = 0;

		sn[70,4]._chaimg = "cc_shop";
		sn[70,4]._mirror = false;
		sn[70,4]._pos = 0;
		sn[70,4]._showef = 0;
		sn[70,4]._txtidx = 612;
		sn[70,4]._extraimg = 0;

		sn[70,5]._chaimg = "cc_pet";
		sn[70,5]._mirror = false;
		sn[70,5]._pos = 0;
		sn[70,5]._showef = 1;
		sn[70,5]._txtidx = 613;
		sn[70,5]._extraimg = 0;

		sn[70,6]._chaimg = "cc_cha0";
		sn[70,6]._mirror = false;
		sn[70,6]._pos = 1;
		sn[70,6]._showef = 0;
		sn[70,6]._txtidx = 614;
		sn[70,6]._extraimg = 0;

		sn[70,7]._chaimg = "cc_pet";
		sn[70,7]._mirror = false;
		sn[70,7]._pos = 0;
		sn[70,7]._showef = 0;
		sn[70,7]._txtidx = 615;
		sn[70,7]._extraimg = 0;

		sn[70,8]._chaimg = "cc_cha1";
		sn[70,8]._mirror = false;
		sn[70,8]._pos = 1;
		sn[70,8]._showef = 4;
		sn[70,8]._txtidx = 616;
		sn[70,8]._extraimg = 0;


		///*24-2*/
		sn[71,0]._chaimg = "cc_cha0";
		sn[71,0]._mirror = false;
		sn[71,0]._pos = 1;
		sn[71,0]._showef = 1;
		sn[71,0]._txtidx = 617;
		sn[71,0]._extraimg = 0;

		sn[71,1]._chaimg = "cc_archive";
		sn[71,1]._mirror = false;
		sn[71,1]._pos = 0;
		sn[71,1]._showef = 1;
		sn[71,1]._txtidx = 618;
		sn[71,1]._extraimg = 0;

		sn[71,2]._chaimg = "cc_cha1";
		sn[71,2]._mirror = false;
		sn[71,2]._pos = 1;
		sn[71,2]._showef = 0;
		sn[71,2]._txtidx = 619;
		sn[71,2]._extraimg = 0;

		sn[71,3]._chaimg = "cc_shop";
		sn[71,3]._mirror = false;
		sn[71,3]._pos = 0;
		sn[71,3]._showef = 1;
		sn[71,3]._txtidx = 620;
		sn[71,3]._extraimg = 0;

		sn[71,4]._chaimg = "cc_pet";
		sn[71,4]._mirror = false;
		sn[71,4]._pos = 1;
		sn[71,4]._showef = 1;
		sn[71,4]._txtidx = 621;
		sn[71,4]._extraimg = 0;

		sn[71,5]._chaimg = "cc_yun0";
		sn[71,5]._mirror = false;
		sn[71,5]._pos = 0;
		sn[71,5]._showef = 1;
		sn[71,5]._txtidx = 622;
		sn[71,5]._extraimg = 0;

		sn[71,6]._chaimg = "cc_cha1";
		sn[71,6]._mirror = false;
		sn[71,6]._pos = 1;
		sn[71,6]._showef = 0;
		sn[71,6]._txtidx = 623;
		sn[71,6]._extraimg = 0;

		sn[71,7]._chaimg = "cc_archive";
		sn[71,7]._mirror = false;
		sn[71,7]._pos = 0;
		sn[71,7]._showef = 4;
		sn[71,7]._txtidx = 624;
		sn[71,7]._extraimg = 0;


		///*24-3*/
		sn[72,0]._chaimg = "cc_cha0";
		sn[72,0]._mirror = false;
		sn[72,0]._pos = 1;
		sn[72,0]._showef = 1;
		sn[72,0]._txtidx = 625;
		sn[72,0]._extraimg = 0;

		sn[72,1]._chaimg = "cc_yun0";
		sn[72,1]._mirror = false;
		sn[72,1]._pos = 0;
		sn[72,1]._showef = 1;
		sn[72,1]._txtidx = 626;
		sn[72,1]._extraimg = 0;

		sn[72,2]._chaimg = "cc_cha1";
		sn[72,2]._mirror = false;
		sn[72,2]._pos = 1;
		sn[72,2]._showef = 0;
		sn[72,2]._txtidx = 627;
		sn[72,2]._extraimg = 0;

		sn[72,3]._chaimg = "cc_yun0";
		sn[72,3]._mirror = false;
		sn[72,3]._pos = 0;
		sn[72,3]._showef = 0;
		sn[72,3]._txtidx = 628;
		sn[72,3]._extraimg = 0;

		sn[72,4]._chaimg = "cc_cha0";
		sn[72,4]._mirror = false;
		sn[72,4]._pos = 1;
		sn[72,4]._showef = 0;
		sn[72,4]._txtidx = 629;
		sn[72,4]._extraimg = 0;

		sn[72,5]._chaimg = "cc_yun0";
		sn[72,5]._mirror = false;
		sn[72,5]._pos = 0;
		sn[72,5]._showef = 0;
		sn[72,5]._txtidx = 630;
		sn[72,5]._extraimg = 0;

		sn[72,6]._chaimg = "cc_cha0";
		sn[72,6]._mirror = false;
		sn[72,6]._pos = 1;
		sn[72,6]._showef = 0;
		sn[72,6]._txtidx = 631;
		sn[72,6]._extraimg = 0;

		sn[72,7]._chaimg = "cc_yun0";
		sn[72,7]._mirror = false;
		sn[72,7]._pos = 0;
		sn[72,7]._showef = 0;
		sn[72,7]._txtidx = 632;
		sn[72,7]._extraimg = 0;

		sn[72,8]._chaimg = "cc_cha0";
		sn[72,8]._mirror = false;
		sn[72,8]._pos = 1;
		sn[72,8]._showef = 0;
		sn[72,8]._txtidx = 633;
		sn[72,8]._extraimg = 0;

		sn[72,9]._chaimg = "cc_yun0";
		sn[72,9]._mirror = false;
		sn[72,9]._pos = 0;
		sn[72,9]._showef = 4;
		sn[72,9]._txtidx = 634;
		sn[72,9]._extraimg = 0;


		///*25-1*/
		sn[73,0]._chaimg = "cc_cha0";
		sn[73,0]._mirror = false;
		sn[73,0]._pos = 1;
		sn[73,0]._showef = 1;
		sn[73,0]._txtidx = 635;
		sn[73,0]._extraimg = 0;

		sn[73,1]._chaimg = "cc_yun0";
		sn[73,1]._mirror = false;
		sn[73,1]._pos = 0;
		sn[73,1]._showef = 1;
		sn[73,1]._txtidx = 636;
		sn[73,1]._extraimg = 0;

		sn[73,2]._chaimg = "cc_yun0";
		sn[73,2]._mirror = false;
		sn[73,2]._pos = 0;
		sn[73,2]._showef = 0;
		sn[73,2]._txtidx = 637;
		sn[73,2]._extraimg = 0;

		sn[73,3]._chaimg = "cc_yun0";
		sn[73,3]._mirror = false;
		sn[73,3]._pos = 0;
		sn[73,3]._showef = 0;
		sn[73,3]._txtidx = 638;
		sn[73,3]._extraimg = 0;

		sn[73,4]._chaimg = "cc_cha0";
		sn[73,4]._mirror = false;
		sn[73,4]._pos = 1;
		sn[73,4]._showef = 0;
		sn[73,4]._txtidx = 639;
		sn[73,4]._extraimg = 0;

		sn[73,5]._chaimg = "cc_yun0";
		sn[73,5]._mirror = false;
		sn[73,5]._pos = 0;
		sn[73,5]._showef = 0;
		sn[73,5]._txtidx = 640;
		sn[73,5]._extraimg = 0;

		sn[73,6]._chaimg = "cc_yun0";
		sn[73,6]._mirror = false;
		sn[73,6]._pos = 0;
		sn[73,6]._showef = 0;
		sn[73,6]._txtidx = 641;
		sn[73,6]._extraimg = 0;

		sn[73,7]._chaimg = "cc_yun0";
		sn[73,7]._mirror = false;
		sn[73,7]._pos = 0;
		sn[73,7]._showef = 0;
		sn[73,7]._txtidx = 642;
		sn[73,7]._extraimg = 0;

		sn[73,8]._chaimg = "cc_cha0";
		sn[73,8]._mirror = false;
		sn[73,8]._pos = 1;
		sn[73,8]._showef = 0;
		sn[73,8]._txtidx = 643;
		sn[73,8]._extraimg = 0;

		sn[73,9]._chaimg = "cc_yun0";
		sn[73,9]._mirror = false;
		sn[73,9]._pos = 0;
		sn[73,9]._showef = 0;
		sn[73,9]._txtidx = 644;
		sn[73,9]._extraimg = 0;

		sn[73,10]._chaimg = "cc_cha1";
		sn[73,10]._mirror = false;
		sn[73,10]._pos = 1;
		sn[73,10]._showef = 4;
		sn[73,10]._txtidx = 645;
		sn[73,10]._extraimg = 0;


		///*25-2*/
		sn[74,0]._chaimg = "cc_yun0";
		sn[74,0]._mirror = false;
		sn[74,0]._pos = 0;
		sn[74,0]._showef = 1;
		sn[74,0]._txtidx = 646;
		sn[74,0]._extraimg = 0;

		sn[74,1]._chaimg = "cc_cha1";
		sn[74,1]._mirror = false;
		sn[74,1]._pos = 1;
		sn[74,1]._showef = 1;
		sn[74,1]._txtidx = 647;
		sn[74,1]._extraimg = 0;

		sn[74,2]._chaimg = "cc_yun0";
		sn[74,2]._mirror = false;
		sn[74,2]._pos = 0;
		sn[74,2]._showef = 0;
		sn[74,2]._txtidx = 648;
		sn[74,2]._extraimg = 0;

		sn[74,3]._chaimg = "cc_cha2";
		sn[74,3]._mirror = false;
		sn[74,3]._pos = 1;
		sn[74,3]._showef = 0;
		sn[74,3]._txtidx = 649;
		sn[74,3]._extraimg = 0;

		sn[74,4]._chaimg = "cc_yun0";
		sn[74,4]._mirror = false;
		sn[74,4]._pos = 0;
		sn[74,4]._showef = 4;
		sn[74,4]._txtidx = 650;
		sn[74,4]._extraimg = 0;


		///*25-3*/
		sn[75,0]._chaimg = "cc_cha2";
		sn[75,0]._mirror = false;
		sn[75,0]._pos = 1;
		sn[75,0]._showef = 1;
		sn[75,0]._txtidx = 651;
		sn[75,0]._extraimg = 0;

		sn[75,1]._chaimg = "cc_cha0";
		sn[75,1]._mirror = false;
		sn[75,1]._pos = 1;
		sn[75,1]._showef = 0;
		sn[75,1]._txtidx = 652;
		sn[75,1]._extraimg = 0;

		sn[75,2]._chaimg = "cc_cha1";
		sn[75,2]._mirror = false;
		sn[75,2]._pos = 1;
		sn[75,2]._showef = 0;
		sn[75,2]._txtidx = 653;
		sn[75,2]._extraimg = 0;

		sn[75,3]._chaimg = "cc_yun0";
		sn[75,3]._mirror = false;
		sn[75,3]._pos = 0;
		sn[75,3]._showef = 1;
		sn[75,3]._txtidx = 654;
		sn[75,3]._extraimg = 0;

		sn[75,4]._chaimg = "cc_yun0";
		sn[75,4]._mirror = false;
		sn[75,4]._pos = 0;
		sn[75,4]._showef = 0;
		sn[75,4]._txtidx = 655;
		sn[75,4]._extraimg = 0;

		sn[75,5]._chaimg = "cc_yun0";
		sn[75,5]._mirror = false;
		sn[75,5]._pos = 0;
		sn[75,5]._showef = 0;
		sn[75,5]._txtidx = 656;
		sn[75,5]._extraimg = 0;

		sn[75,6]._chaimg = "cc_cha1";
		sn[75,6]._mirror = false;
		sn[75,6]._pos = 1;
		sn[75,6]._showef = 0;
		sn[75,6]._txtidx = 657;
		sn[75,6]._extraimg = 0;

		sn[75,7]._chaimg = "cc_yun0";
		sn[75,7]._mirror = false;
		sn[75,7]._pos = 0;
		sn[75,7]._showef = 0;
		sn[75,7]._txtidx = 658;
		sn[75,7]._extraimg = 0;

		sn[75,8]._chaimg = "cc_yun0";
		sn[75,8]._mirror = false;
		sn[75,8]._pos = 0;
		sn[75,8]._showef = 0;
		sn[75,8]._txtidx = 659;
		sn[75,8]._extraimg = 0;

		sn[75,9]._chaimg = "cc_yun0";
		sn[75,9]._mirror = false;
		sn[75,9]._pos = 0;
		sn[75,9]._showef = 4;
		sn[75,9]._txtidx = 660;
		sn[75,9]._extraimg = 0;


		///*26-1*/
		sn[76,0]._chaimg = "cc_cha0";
		sn[76,0]._mirror = false;
		sn[76,0]._pos = 1;
		sn[76,0]._showef = 1;
		sn[76,0]._txtidx = 661;
		sn[76,0]._extraimg = 0;

		sn[76,1]._chaimg = "cc_yun0";
		sn[76,1]._mirror = false;
		sn[76,1]._pos = 0;
		sn[76,1]._showef = 1;
		sn[76,1]._txtidx = 662;
		sn[76,1]._extraimg = 0;

		sn[76,2]._chaimg = "cc_cha2";
		sn[76,2]._mirror = false;
		sn[76,2]._pos = 1;
		sn[76,2]._showef = 0;
		sn[76,2]._txtidx = 663;
		sn[76,2]._extraimg = 0;

		sn[76,3]._chaimg = "cc_yun0";
		sn[76,3]._mirror = false;
		sn[76,3]._pos = 0;
		sn[76,3]._showef = 0;
		sn[76,3]._txtidx = 664;
		sn[76,3]._extraimg = 0;

		sn[76,4]._chaimg = "cc_cha0";
		sn[76,4]._mirror = false;
		sn[76,4]._pos = 1;
		sn[76,4]._showef = 0;
		sn[76,4]._txtidx = 665;
		sn[76,4]._extraimg = 0;

		sn[76,5]._chaimg = "cc_cha0";
		sn[76,5]._mirror = false;
		sn[76,5]._pos = 1;
		sn[76,5]._showef = 0;
		sn[76,5]._txtidx = 666;
		sn[76,5]._extraimg = 0;

		sn[76,6]._chaimg = "cc_yun0";
		sn[76,6]._mirror = false;
		sn[76,6]._pos = 0;
		sn[76,6]._showef = 0;
		sn[76,6]._txtidx = 667;
		sn[76,6]._extraimg = 0;

		sn[76,7]._chaimg = "cc_cha2";
		sn[76,7]._mirror = false;
		sn[76,7]._pos = 1;
		sn[76,7]._showef = 0;
		sn[76,7]._txtidx = 668;
		sn[76,7]._extraimg = 0;

		sn[76,8]._chaimg = "cc_yun0";
		sn[76,8]._mirror = false;
		sn[76,8]._pos = 0;
		sn[76,8]._showef = 4;
		sn[76,8]._txtidx = 669;
		sn[76,8]._extraimg = 0;


		///*26-2*/
		sn[77,0]._chaimg = "cc_yun0";
		sn[77,0]._mirror = false;
		sn[77,0]._pos = 0;
		sn[77,0]._showef = 1;
		sn[77,0]._txtidx = 670;
		sn[77,0]._extraimg = 0;

		sn[77,1]._chaimg = "cc_yun0";
		sn[77,1]._mirror = false;
		sn[77,1]._pos = 0;
		sn[77,1]._showef = 0;
		sn[77,1]._txtidx = 671;
		sn[77,1]._extraimg = 0;

		sn[77,2]._chaimg = "cc_yun0";
		sn[77,2]._mirror = false;
		sn[77,2]._pos = 0;
		sn[77,2]._showef = 0;
		sn[77,2]._txtidx = 672;
		sn[77,2]._extraimg = 0;

		sn[77,3]._chaimg = "cc_cha0";
		sn[77,3]._mirror = false;
		sn[77,3]._pos = 1;
		sn[77,3]._showef = 1;
		sn[77,3]._txtidx = 673;
		sn[77,3]._extraimg = 0;

		sn[77,4]._chaimg = "cc_yun0";
		sn[77,4]._mirror = false;
		sn[77,4]._pos = 0;
		sn[77,4]._showef = 0;
		sn[77,4]._txtidx = 674;
		sn[77,4]._extraimg = 0;

		sn[77,5]._chaimg = "cc_cha4";
		sn[77,5]._mirror = false;
		sn[77,5]._pos = 1;
		sn[77,5]._showef = 0;
		sn[77,5]._txtidx = 675;
		sn[77,5]._extraimg = 0;

		sn[77,6]._chaimg = "cc_yun0";
		sn[77,6]._mirror = false;
		sn[77,6]._pos = 0;
		sn[77,6]._showef = 0;
		sn[77,6]._txtidx = 676;
		sn[77,6]._extraimg = 0;

		sn[77,7]._chaimg = "cc_cha6";
		sn[77,7]._mirror = false;
		sn[77,7]._pos = 1;
		sn[77,7]._showef = 0;
		sn[77,7]._txtidx = 677;
		sn[77,7]._extraimg = 0;

		sn[77,8]._chaimg = "cc_yun0";
		sn[77,8]._mirror = false;
		sn[77,8]._pos = 0;
		sn[77,8]._showef = 0;
		sn[77,8]._txtidx = 678;
		sn[77,8]._extraimg = 0;

		sn[77,9]._chaimg = "cc_cha6";
		sn[77,9]._mirror = false;
		sn[77,9]._pos = 1;
		sn[77,9]._showef = 0;
		sn[77,9]._txtidx = 679;
		sn[77,9]._extraimg = 0;

		sn[77,10]._chaimg = "cc_shop";
		sn[77,10]._mirror = false;
		sn[77,10]._pos = 0;
		sn[77,10]._showef = 1;
		sn[77,10]._txtidx = 680;
		sn[77,10]._extraimg = 0;

		sn[77,11]._chaimg = "cc_pet";
		sn[77,11]._mirror = false;
		sn[77,11]._pos = 0;
		sn[77,11]._showef = 1;
		sn[77,11]._txtidx = 681;
		sn[77,11]._extraimg = 0;

		sn[77,12]._chaimg = "cc_archive";
		sn[77,12]._mirror = false;
		sn[77,12]._pos = 0;
		sn[77,12]._showef = 4;
		sn[77,12]._txtidx = 682;
		sn[77,12]._extraimg = 0;


		///*26-3*/
		sn[78,0]._chaimg = "cc_cha2";
		sn[78,0]._mirror = false;
		sn[78,0]._pos = 1;
		sn[78,0]._showef = 1;
		sn[78,0]._txtidx = 683;
		sn[78,0]._extraimg = 0;

		sn[78,1]._chaimg = "cc_yun0";
		sn[78,1]._mirror = false;
		sn[78,1]._pos = 0;
		sn[78,1]._showef = 1;
		sn[78,1]._txtidx = 684;
		sn[78,1]._extraimg = 0;

		sn[78,2]._chaimg = "cc_yun0";
		sn[78,2]._mirror = false;
		sn[78,2]._pos = 0;
		sn[78,2]._showef = 0;
		sn[78,2]._txtidx = 685;
		sn[78,2]._extraimg = 0;

		sn[78,3]._chaimg = "cc_pet";
		sn[78,3]._mirror = false;
		sn[78,3]._pos = 1;
		sn[78,3]._showef = 1;
		sn[78,3]._txtidx = 686;
		sn[78,3]._extraimg = 0;

		sn[78,4]._chaimg = "cc_yun0";
		sn[78,4]._mirror = false;
		sn[78,4]._pos = 0;
		sn[78,4]._showef = 0;
		sn[78,4]._txtidx = 687;
		sn[78,4]._extraimg = 0;

		sn[78,5]._chaimg = "cc_shop";
		sn[78,5]._mirror = false;
		sn[78,5]._pos = 1;
		sn[78,5]._showef = 1;
		sn[78,5]._txtidx = 688;
		sn[78,5]._extraimg = 0;

		sn[78,6]._chaimg = "cc_yun0";
		sn[78,6]._mirror = false;
		sn[78,6]._pos = 0;
		sn[78,6]._showef = 0;
		sn[78,6]._txtidx = 689;
		sn[78,6]._extraimg = 0;

		sn[78,7]._chaimg = "cc_cha2";
		sn[78,7]._mirror = false;
		sn[78,7]._pos = 1;
		sn[78,7]._showef = 1;
		sn[78,7]._txtidx = 690;
		sn[78,7]._extraimg = 0;

		sn[78,8]._chaimg = "cc_yun0";
		sn[78,8]._mirror = false;
		sn[78,8]._pos = 0;
		sn[78,8]._showef = 0;
		sn[78,8]._txtidx = 691;
		sn[78,8]._extraimg = 0;

		sn[78,9]._chaimg = "cc_cha6";
		sn[78,9]._mirror = false;
		sn[78,9]._pos = 1;
		sn[78,9]._showef = 0;
		sn[78,9]._txtidx = 692;
		sn[78,9]._extraimg = 0;

		sn[78,10]._chaimg = "cc_yun0";
		sn[78,10]._mirror = false;
		sn[78,10]._pos = 0;
		sn[78,10]._showef = 0;
		sn[78,10]._txtidx = 693;
		sn[78,10]._extraimg = 0;

		sn[78,11]._chaimg = "cc_cha1";
		sn[78,11]._mirror = false;
		sn[78,11]._pos = 1;
		sn[78,11]._showef = 0;
		sn[78,11]._txtidx = 694;
		sn[78,11]._extraimg = 0;

		sn[78,12]._chaimg = "cc_yun0";
		sn[78,12]._mirror = false;
		sn[78,12]._pos = 0;
		sn[78,12]._showef = 4;
		sn[78,12]._txtidx = 695;
		sn[78,12]._extraimg = 0;


		///*27-1*/
		sn[79,0]._chaimg = "cc_cha0";
		sn[79,0]._mirror = false;
		sn[79,0]._pos = 1;
		sn[79,0]._showef = 1;
		sn[79,0]._txtidx = 696;
		sn[79,0]._extraimg = 0;

		sn[79,1]._chaimg = "cc_shop";
		sn[79,1]._mirror = false;
		sn[79,1]._pos = 0;
		sn[79,1]._showef = 1;
		sn[79,1]._txtidx = 697;
		sn[79,1]._extraimg = 0;

		sn[79,2]._chaimg = "cc_cha1";
		sn[79,2]._mirror = false;
		sn[79,2]._pos = 1;
		sn[79,2]._showef = 0;
		sn[79,2]._txtidx = 698;
		sn[79,2]._extraimg = 0;

		sn[79,3]._chaimg = "cc_shop";
		sn[79,3]._mirror = false;
		sn[79,3]._pos = 0;
		sn[79,3]._showef = 0;
		sn[79,3]._txtidx = 699;
		sn[79,3]._extraimg = 0;

		sn[79,4]._chaimg = "cc_cha0";
		sn[79,4]._mirror = false;
		sn[79,4]._pos = 1;
		sn[79,4]._showef = 0;
		sn[79,4]._txtidx = 700;
		sn[79,4]._extraimg = 0;

		sn[79,5]._chaimg = "cc_shop";
		sn[79,5]._mirror = false;
		sn[79,5]._pos = 0;
		sn[79,5]._showef = 0;
		sn[79,5]._txtidx = 701;
		sn[79,5]._extraimg = 0;

		sn[79,6]._chaimg = "cc_cha0";
		sn[79,6]._mirror = false;
		sn[79,6]._pos = 1;
		sn[79,6]._showef = 0;
		sn[79,6]._txtidx = 702;
		sn[79,6]._extraimg = 0;

		sn[79,7]._chaimg = "cc_shop";
		sn[79,7]._mirror = false;
		sn[79,7]._pos = 0;
		sn[79,7]._showef = 0;
		sn[79,7]._txtidx = 703;
		sn[79,7]._extraimg = 0;

		sn[79,8]._chaimg = "cc_cha2";
		sn[79,8]._mirror = false;
		sn[79,8]._pos = 1;
		sn[79,8]._showef = 4;
		sn[79,8]._txtidx = 704;
		sn[79,8]._extraimg = 0;


		///*27-2*/
		sn[80,0]._chaimg = "cc_yun0";
		sn[80,0]._mirror = false;
		sn[80,0]._pos = 0;
		sn[80,0]._showef = 1;
		sn[80,0]._txtidx = 705;
		sn[80,0]._extraimg = 0;

		sn[80,1]._chaimg = "cc_cha0";
		sn[80,1]._mirror = false;
		sn[80,1]._pos = 1;
		sn[80,1]._showef = 1;
		sn[80,1]._txtidx = 706;
		sn[80,1]._extraimg = 0;

		sn[80,2]._chaimg = "cc_yun0";
		sn[80,2]._mirror = false;
		sn[80,2]._pos = 0;
		sn[80,2]._showef = 0;
		sn[80,2]._txtidx = 707;
		sn[80,2]._extraimg = 0;

		sn[80,3]._chaimg = "cc_cha1";
		sn[80,3]._mirror = false;
		sn[80,3]._pos = 1;
		sn[80,3]._showef = 0;
		sn[80,3]._txtidx = 708;
		sn[80,3]._extraimg = 0;

		sn[80,4]._chaimg = "cc_yun0";
		sn[80,4]._mirror = false;
		sn[80,4]._pos = 0;
		sn[80,4]._showef = 0;
		sn[80,4]._txtidx = 709;
		sn[80,4]._extraimg = 0;

		sn[80,5]._chaimg = "cc_cha0";
		sn[80,5]._mirror = false;
		sn[80,5]._pos = 1;
		sn[80,5]._showef = 0;
		sn[80,5]._txtidx = 710;
		sn[80,5]._extraimg = 0;

		sn[80,6]._chaimg = "cc_yun0";
		sn[80,6]._mirror = false;
		sn[80,6]._pos = 0;
		sn[80,6]._showef = 0;
		sn[80,6]._txtidx = 711;
		sn[80,6]._extraimg = 0;

		sn[80,7]._chaimg = "cc_cha0";
		sn[80,7]._mirror = false;
		sn[80,7]._pos = 1;
		sn[80,7]._showef = 0;
		sn[80,7]._txtidx = 712;
		sn[80,7]._extraimg = 0;

		sn[80,8]._chaimg = "cc_cha3";
		sn[80,8]._mirror = false;
		sn[80,8]._pos = 1;
		sn[80,8]._showef = 0;
		sn[80,8]._txtidx = 713;
		sn[80,8]._extraimg = 0;

		sn[80,9]._chaimg = "cc_yun0";
		sn[80,9]._mirror = false;
		sn[80,9]._pos = 0;
		sn[80,9]._showef = 0;
		sn[80,9]._txtidx = 714;
		sn[80,9]._extraimg = 0;

		sn[80,10]._chaimg = "cc_cha2";
		sn[80,10]._mirror = false;
		sn[80,10]._pos = 1;
		sn[80,10]._showef = 4;
		sn[80,10]._txtidx = 715;
		sn[80,10]._extraimg = 0;


		///*27-3*/
		sn[81,0]._chaimg = "cc_cha1";
		sn[81,0]._mirror = false;
		sn[81,0]._pos = 1;
		sn[81,0]._showef = 1;
		sn[81,0]._txtidx = 716;
		sn[81,0]._extraimg = 0;

		sn[81,1]._chaimg = "cc_pet";
		sn[81,1]._mirror = false;
		sn[81,1]._pos = 0;
		sn[81,1]._showef = 1;
		sn[81,1]._txtidx = 717;
		sn[81,1]._extraimg = 0;

		sn[81,2]._chaimg = "cc_cha0";
		sn[81,2]._mirror = false;
		sn[81,2]._pos = 1;
		sn[81,2]._showef = 0;
		sn[81,2]._txtidx = 718;
		sn[81,2]._extraimg = 0;

		sn[81,3]._chaimg = "cc_pet";
		sn[81,3]._mirror = false;
		sn[81,3]._pos = 0;
		sn[81,3]._showef = 0;
		sn[81,3]._txtidx = 719;
		sn[81,3]._extraimg = 0;

		sn[81,4]._chaimg = "cc_cha1";
		sn[81,4]._mirror = false;
		sn[81,4]._pos = 1;
		sn[81,4]._showef = 0;
		sn[81,4]._txtidx = 720;
		sn[81,4]._extraimg = 0;

		sn[81,5]._chaimg = "cc_pet";
		sn[81,5]._mirror = false;
		sn[81,5]._pos = 0;
		sn[81,5]._showef = 0;
		sn[81,5]._txtidx = 721;
		sn[81,5]._extraimg = 0;

		sn[81,6]._chaimg = "cc_shop";
		sn[81,6]._mirror = false;
		sn[81,6]._pos = 0;
		sn[81,6]._showef = 1;
		sn[81,6]._txtidx = 722;
		sn[81,6]._extraimg = 0;

		sn[81,7]._chaimg = "cc_archive";
		sn[81,7]._mirror = false;
		sn[81,7]._pos = 0;
		sn[81,7]._showef = 1;
		sn[81,7]._txtidx = 723;
		sn[81,7]._extraimg = 0;

		sn[81,8]._chaimg = "cc_cha1";
		sn[81,8]._mirror = false;
		sn[81,8]._pos = 1;
		sn[81,8]._showef = 4;
		sn[81,8]._txtidx = 724;
		sn[81,8]._extraimg = 0;


		///*28-1*/
		sn[82,0]._chaimg = "cc_shop";
		sn[82,0]._mirror = false;
		sn[82,0]._pos = 0;
		sn[82,0]._showef = 1;
		sn[82,0]._txtidx = 725;
		sn[82,0]._extraimg = 0;

		sn[82,1]._chaimg = "cc_cha0";
		sn[82,1]._mirror = false;
		sn[82,1]._pos = 1;
		sn[82,1]._showef = 1;
		sn[82,1]._txtidx = 726;
		sn[82,1]._extraimg = 0;

		sn[82,2]._chaimg = "cc_yun0";
		sn[82,2]._mirror = false;
		sn[82,2]._pos = 0;
		sn[82,2]._showef = 1;
		sn[82,2]._txtidx = 727;
		sn[82,2]._extraimg = 0;

		sn[82,3]._chaimg = "cc_cha0";
		sn[82,3]._mirror = false;
		sn[82,3]._pos = 1;
		sn[82,3]._showef = 0;
		sn[82,3]._txtidx = 728;
		sn[82,3]._extraimg = 0;

		sn[82,4]._chaimg = "cc_yun0";
		sn[82,4]._mirror = false;
		sn[82,4]._pos = 0;
		sn[82,4]._showef = 0;
		sn[82,4]._txtidx = 729;
		sn[82,4]._extraimg = 0;

		sn[82,5]._chaimg = "cc_cha0";
		sn[82,5]._mirror = false;
		sn[82,5]._pos = 1;
		sn[82,5]._showef = 0;
		sn[82,5]._txtidx = 730;
		sn[82,5]._extraimg = 0;

		sn[82,6]._chaimg = "cc_cha2";
		sn[82,6]._mirror = false;
		sn[82,6]._pos = 1;
		sn[82,6]._showef = 0;
		sn[82,6]._txtidx = 731;
		sn[82,6]._extraimg = 0;

		sn[82,7]._chaimg = "cc_yun0";
		sn[82,7]._mirror = false;
		sn[82,7]._pos = 0;
		sn[82,7]._showef = 4;
		sn[82,7]._txtidx = 732;
		sn[82,7]._extraimg = 0;


		///*28-2*/
		sn[83,0]._chaimg = "cc_pet";
		sn[83,0]._mirror = false;
		sn[83,0]._pos = 0;
		sn[83,0]._showef = 1;
		sn[83,0]._txtidx = 733;
		sn[83,0]._extraimg = 0;

		sn[83,1]._chaimg = "cc_cha1";
		sn[83,1]._mirror = false;
		sn[83,1]._pos = 1;
		sn[83,1]._showef = 1;
		sn[83,1]._txtidx = 734;
		sn[83,1]._extraimg = 0;

		sn[83,2]._chaimg = "cc_pet";
		sn[83,2]._mirror = false;
		sn[83,2]._pos = 0;
		sn[83,2]._showef = 0;
		sn[83,2]._txtidx = 735;
		sn[83,2]._extraimg = 0;

		sn[83,3]._chaimg = "cc_cha0";
		sn[83,3]._mirror = false;
		sn[83,3]._pos = 1;
		sn[83,3]._showef = 0;
		sn[83,3]._txtidx = 736;
		sn[83,3]._extraimg = 0;

		sn[83,4]._chaimg = "cc_pet";
		sn[83,4]._mirror = false;
		sn[83,4]._pos = 0;
		sn[83,4]._showef = 0;
		sn[83,4]._txtidx = 737;
		sn[83,4]._extraimg = 0;

		sn[83,5]._chaimg = "cc_cha0";
		sn[83,5]._mirror = false;
		sn[83,5]._pos = 1;
		sn[83,5]._showef = 0;
		sn[83,5]._txtidx = 738;
		sn[83,5]._extraimg = 0;

		sn[83,6]._chaimg = "cc_pet";
		sn[83,6]._mirror = false;
		sn[83,6]._pos = 0;
		sn[83,6]._showef = 0;
		sn[83,6]._txtidx = 739;
		sn[83,6]._extraimg = 0;

		sn[83,7]._chaimg = "cc_cha0";
		sn[83,7]._mirror = false;
		sn[83,7]._pos = 1;
		sn[83,7]._showef = 4;
		sn[83,7]._txtidx = 740;
		sn[83,7]._extraimg = 0;


		///*28-3*/
		sn[84,0]._chaimg = "cc_cha0";
		sn[84,0]._mirror = false;
		sn[84,0]._pos = 1;
		sn[84,0]._showef = 1;
		sn[84,0]._txtidx = 741;
		sn[84,0]._extraimg = 0;

		sn[84,1]._chaimg = "cc_cha4";
		sn[84,1]._mirror = false;
		sn[84,1]._pos = 1;
		sn[84,1]._showef = 0;
		sn[84,1]._txtidx = 742;
		sn[84,1]._extraimg = 0;

		sn[84,2]._chaimg = "cc_archive";
		sn[84,2]._mirror = false;
		sn[84,2]._pos = 0;
		sn[84,2]._showef = 1;
		sn[84,2]._txtidx = 743;
		sn[84,2]._extraimg = 0;

		sn[84,3]._chaimg = "cc_cha1";
		sn[84,3]._mirror = false;
		sn[84,3]._pos = 1;
		sn[84,3]._showef = 0;
		sn[84,3]._txtidx = 744;
		sn[84,3]._extraimg = 0;

		sn[84,4]._chaimg = "cc_shop";
		sn[84,4]._mirror = false;
		sn[84,4]._pos = 0;
		sn[84,4]._showef = 1;
		sn[84,4]._txtidx = 745;
		sn[84,4]._extraimg = 0;

		sn[84,5]._chaimg = "cc_pet";
		sn[84,5]._mirror = false;
		sn[84,5]._pos = 0;
		sn[84,5]._showef = 1;
		sn[84,5]._txtidx = 746;
		sn[84,5]._extraimg = 0;

		sn[84,6]._chaimg = "cc_cha0";
		sn[84,6]._mirror = false;
		sn[84,6]._pos = 1;
		sn[84,6]._showef = 0;
		sn[84,6]._txtidx = 747;
		sn[84,6]._extraimg = 0;

		sn[84,7]._chaimg = "cc_cha2";
		sn[84,7]._mirror = false;
		sn[84,7]._pos = 1;
		sn[84,7]._showef = 4;
		sn[84,7]._txtidx = 748;
		sn[84,7]._extraimg = 0;


		///*29-1*/
		sn[85,0]._chaimg = "cc_pet";
		sn[85,0]._mirror = false;
		sn[85,0]._pos = 0;
		sn[85,0]._showef = 1;
		sn[85,0]._txtidx = 749;
		sn[85,0]._extraimg = 0;

		sn[85,1]._chaimg = "cc_cha2";
		sn[85,1]._mirror = false;
		sn[85,1]._pos = 1;
		sn[85,1]._showef = 1;
		sn[85,1]._txtidx = 750;
		sn[85,1]._extraimg = 0;

		sn[85,2]._chaimg = "cc_shop";
		sn[85,2]._mirror = false;
		sn[85,2]._pos = 0;
		sn[85,2]._showef = 1;
		sn[85,2]._txtidx = 751;
		sn[85,2]._extraimg = 0;

		sn[85,3]._chaimg = "cc_cha0";
		sn[85,3]._mirror = false;
		sn[85,3]._pos = 1;
		sn[85,3]._showef = 0;
		sn[85,3]._txtidx = 752;
		sn[85,3]._extraimg = 0;

		sn[85,4]._chaimg = "cc_pet";
		sn[85,4]._mirror = false;
		sn[85,4]._pos = 0;
		sn[85,4]._showef = 1;
		sn[85,4]._txtidx = 753;
		sn[85,4]._extraimg = 0;

		sn[85,5]._chaimg = "cc_cha2";
		sn[85,5]._mirror = false;
		sn[85,5]._pos = 1;
		sn[85,5]._showef = 4;
		sn[85,5]._txtidx = 754;
		sn[85,5]._extraimg = 0;


		///*29-2*/
		sn[86,0]._chaimg = "cc_yun0";
		sn[86,0]._mirror = false;
		sn[86,0]._pos = 0;
		sn[86,0]._showef = 1;
		sn[86,0]._txtidx = 755;
		sn[86,0]._extraimg = 0;

		sn[86,1]._chaimg = "cc_cha1";
		sn[86,1]._mirror = false;
		sn[86,1]._pos = 1;
		sn[86,1]._showef = 1;
		sn[86,1]._txtidx = 756;
		sn[86,1]._extraimg = 0;

		sn[86,2]._chaimg = "cc_yun0";
		sn[86,2]._mirror = false;
		sn[86,2]._pos = 0;
		sn[86,2]._showef = 0;
		sn[86,2]._txtidx = 757;
		sn[86,2]._extraimg = 0;

		sn[86,3]._chaimg = "cc_cha1";
		sn[86,3]._mirror = false;
		sn[86,3]._pos = 1;
		sn[86,3]._showef = 0;
		sn[86,3]._txtidx = 758;
		sn[86,3]._extraimg = 0;

		sn[86,4]._chaimg = "cc_yun0";
		sn[86,4]._mirror = false;
		sn[86,4]._pos = 0;
		sn[86,4]._showef = 0;
		sn[86,4]._txtidx = 759;
		sn[86,4]._extraimg = 0;

		sn[86,5]._chaimg = "cc_cha6";
		sn[86,5]._mirror = false;
		sn[86,5]._pos = 1;
		sn[86,5]._showef = 0;
		sn[86,5]._txtidx = 760;
		sn[86,5]._extraimg = 0;

		sn[86,6]._chaimg = "cc_cha0";
		sn[86,6]._mirror = false;
		sn[86,6]._pos = 1;
		sn[86,6]._showef = 0;
		sn[86,6]._txtidx = 761;
		sn[86,6]._extraimg = 0;

		sn[86,7]._chaimg = "cc_cha0";
		sn[86,7]._mirror = false;
		sn[86,7]._pos = 1;
		sn[86,7]._showef = 0;
		sn[86,7]._txtidx = 762;
		sn[86,7]._extraimg = 0;

		sn[86,8]._chaimg = "cc_yun0";
		sn[86,8]._mirror = false;
		sn[86,8]._pos = 0;
		sn[86,8]._showef = 1;
		sn[86,8]._txtidx = 763;
		sn[86,8]._extraimg = 0;

		sn[86,9]._chaimg = "cc_cha3";
		sn[86,9]._mirror = false;
		sn[86,9]._pos = 1;
		sn[86,9]._showef = 4;
		sn[86,9]._txtidx = 764;
		sn[86,9]._extraimg = 0;


		///*29-3*/
		sn[87,0]._chaimg = "cc_yun0";
		sn[87,0]._mirror = false;
		sn[87,0]._pos = 0;
		sn[87,0]._showef = 1;
		sn[87,0]._txtidx = 765;
		sn[87,0]._extraimg = 0;

		sn[87,1]._chaimg = "cc_cha0";
		sn[87,1]._mirror = false;
		sn[87,1]._pos = 1;
		sn[87,1]._showef = 1;
		sn[87,1]._txtidx = 766;
		sn[87,1]._extraimg = 0;

		sn[87,2]._chaimg = "cc_yun0";
		sn[87,2]._mirror = false;
		sn[87,2]._pos = 0;
		sn[87,2]._showef = 0;
		sn[87,2]._txtidx = 767;
		sn[87,2]._extraimg = 0;

		sn[87,3]._chaimg = "cc_cha2";
		sn[87,3]._mirror = false;
		sn[87,3]._pos = 1;
		sn[87,3]._showef = 0;
		sn[87,3]._txtidx = 768;
		sn[87,3]._extraimg = 0;

		sn[87,4]._chaimg = "cc_pet";
		sn[87,4]._mirror = false;
		sn[87,4]._pos = 0;
		sn[87,4]._showef = 1;
		sn[87,4]._txtidx = 769;
		sn[87,4]._extraimg = 0;

		sn[87,5]._chaimg = "cc_cha0";
		sn[87,5]._mirror = false;
		sn[87,5]._pos = 1;
		sn[87,5]._showef = 0;
		sn[87,5]._txtidx = 770;
		sn[87,5]._extraimg = 0;

		sn[87,6]._chaimg = "cc_archive";
		sn[87,6]._mirror = false;
		sn[87,6]._pos = 0;
		sn[87,6]._showef = 1;
		sn[87,6]._txtidx = 771;
		sn[87,6]._extraimg = 0;

		sn[87,7]._chaimg = "cc_cha1";
		sn[87,7]._mirror = false;
		sn[87,7]._pos = 1;
		sn[87,7]._showef = 0;
		sn[87,7]._txtidx = 772;
		sn[87,7]._extraimg = 0;

		sn[87,8]._chaimg = "cc_cha3";
		sn[87,8]._mirror = false;
		sn[87,8]._pos = 1;
		sn[87,8]._showef = 4;
		sn[87,8]._txtidx = 773;
		sn[87,8]._extraimg = 0;


		///*30-1*/
		sn[88,0]._chaimg = "cc_archive";
		sn[88,0]._mirror = false;
		sn[88,0]._pos = 0;
		sn[88,0]._showef = 1;
		sn[88,0]._txtidx = 774;
		sn[88,0]._extraimg = 0;

		sn[88,1]._chaimg = "cc_cha5";
		sn[88,1]._mirror = false;
		sn[88,1]._pos = 1;
		sn[88,1]._showef = 3;
		sn[88,1]._txtidx = 775;
		sn[88,1]._extraimg = 0;

		sn[88,2]._chaimg = "cc_dongtak";
		sn[88,2]._mirror = false;
		sn[88,2]._pos = 0;
		sn[88,2]._showef = 1;
		sn[88,2]._txtidx = 776;
		sn[88,2]._extraimg = 0;

		sn[88,3]._chaimg = "cc_cha4";
		sn[88,3]._mirror = false;
		sn[88,3]._pos = 1;
		sn[88,3]._showef = 2;
		sn[88,3]._txtidx = 777;
		sn[88,3]._extraimg = 0;

		sn[88,4]._chaimg = "cc_dongtak";
		sn[88,4]._mirror = false;
		sn[88,4]._pos = 0;
		sn[88,4]._showef = 0;
		sn[88,4]._txtidx = 778;
		sn[88,4]._extraimg = 0;

		sn[88,5]._chaimg = "cc_cha4";
		sn[88,5]._mirror = false;
		sn[88,5]._pos = 1;
		sn[88,5]._showef = 0;
		sn[88,5]._txtidx = 779;
		sn[88,5]._extraimg = 0;

		sn[88,6]._chaimg = "cc_dongtak";
		sn[88,6]._mirror = false;
		sn[88,6]._pos = 0;
		sn[88,6]._showef = 0;
		sn[88,6]._txtidx = 780;
		sn[88,6]._extraimg = 0;

		sn[88,7]._chaimg = "cc_cha4";
		sn[88,7]._mirror = false;
		sn[88,7]._pos = 1;
		sn[88,7]._showef = 0;
		sn[88,7]._txtidx = 781;
		sn[88,7]._extraimg = 0;

		sn[88,8]._chaimg = "cc_dongtak";
		sn[88,8]._mirror = false;
		sn[88,8]._pos = 0;
		sn[88,8]._showef = 0;
		sn[88,8]._txtidx = 782;
		sn[88,8]._extraimg = 0;

		sn[88,9]._chaimg = "cc_cha4";
		sn[88,9]._mirror = false;
		sn[88,9]._pos = 1;
		sn[88,9]._showef = 2;
		sn[88,9]._txtidx = 783;
		sn[88,9]._extraimg = 0;

		sn[88,10]._chaimg = "cc_dongtak";
		sn[88,10]._mirror = false;
		sn[88,10]._pos = 0;
		sn[88,10]._showef = 0;
		sn[88,10]._txtidx = 784;
		sn[88,10]._extraimg = 0;

		sn[88,11]._chaimg = "cc_dongtak";
		sn[88,11]._mirror = false;
		sn[88,11]._pos = 0;
		sn[88,11]._showef = 0;
		sn[88,11]._txtidx = 785;
		sn[88,11]._extraimg = 0;

		sn[88,12]._chaimg = "cc_dongtak";
		sn[88,12]._mirror = false;
		sn[88,12]._pos = 0;
		sn[88,12]._showef = 4;
		sn[88,12]._txtidx = 786;
		sn[88,12]._extraimg = 0;


		///*30-2*/
		sn[89,0]._chaimg = "cc_pet";
		sn[89,0]._mirror = false;
		sn[89,0]._pos = 0;
		sn[89,0]._showef = 1;
		sn[89,0]._txtidx = 787;
		sn[89,0]._extraimg = 0;

		sn[89,1]._chaimg = "cc_cha6";
		sn[89,1]._mirror = false;
		sn[89,1]._pos = 1;
		sn[89,1]._showef = 1;
		sn[89,1]._txtidx = 788;
		sn[89,1]._extraimg = 0;

		sn[89,2]._chaimg = "cc_archive";
		sn[89,2]._mirror = false;
		sn[89,2]._pos = 0;
		sn[89,2]._showef = 1;
		sn[89,2]._txtidx = 789;
		sn[89,2]._extraimg = 0;

		sn[89,3]._chaimg = "cc_cha6";
		sn[89,3]._mirror = false;
		sn[89,3]._pos = 1;
		sn[89,3]._showef = 0;
		sn[89,3]._txtidx = 790;
		sn[89,3]._extraimg = 0;

		sn[89,4]._chaimg = "cc_shop";
		sn[89,4]._mirror = false;
		sn[89,4]._pos = 0;
		sn[89,4]._showef = 1;
		sn[89,4]._txtidx = 791;
		sn[89,4]._extraimg = 0;

		sn[89,5]._chaimg = "cc_cha6";
		sn[89,5]._mirror = false;
		sn[89,5]._pos = 1;
		sn[89,5]._showef = 0;
		sn[89,5]._txtidx = 792;
		sn[89,5]._extraimg = 0;

		sn[89,6]._chaimg = "cc_yun0";
		sn[89,6]._mirror = false;
		sn[89,6]._pos = 0;
		sn[89,6]._showef = 1;
		sn[89,6]._txtidx = 793;
		sn[89,6]._extraimg = 0;

		sn[89,7]._chaimg = "cc_cha6";
		sn[89,7]._mirror = false;
		sn[89,7]._pos = 1;
		sn[89,7]._showef = 0;
		sn[89,7]._txtidx = 794;
		sn[89,7]._extraimg = 0;

		sn[89,8]._chaimg = "cc_yun0";
		sn[89,8]._mirror = false;
		sn[89,8]._pos = 0;
		sn[89,8]._showef = 1;
		sn[89,8]._txtidx = 795;
		sn[89,8]._extraimg = 0;

		sn[89,9]._chaimg = "cc_cha0";
		sn[89,9]._mirror = false;
		sn[89,9]._pos = 1;
		sn[89,9]._showef = 0;
		sn[89,9]._txtidx = 796;
		sn[89,9]._extraimg = 0;

		sn[89,10]._chaimg = "cc_cha3";
		sn[89,10]._mirror = false;
		sn[89,10]._pos = 1;
		sn[89,10]._showef = 0;
		sn[89,10]._txtidx = 797;
		sn[89,10]._extraimg = 0;

		sn[89,11]._chaimg = "cc_cha5";
		sn[89,11]._mirror = false;
		sn[89,11]._pos = 1;
		sn[89,11]._showef = 4;
		sn[89,11]._txtidx = 798;
		sn[89,11]._extraimg = 0;


		///*30-3*/
		sn[90,0]._chaimg = "cc_yun0";
		sn[90,0]._mirror = false;
		sn[90,0]._pos = 0;
		sn[90,0]._showef = 1;
		sn[90,0]._txtidx = 799;
		sn[90,0]._extraimg = 0;

		sn[90,1]._chaimg = "cc_cha0";
		sn[90,1]._mirror = false;
		sn[90,1]._pos = 1;
		sn[90,1]._showef = 1;
		sn[90,1]._txtidx = 800;
		sn[90,1]._extraimg = 0;

		sn[90,2]._chaimg = "cc_shop";
		sn[90,2]._mirror = false;
		sn[90,2]._pos = 0;
		sn[90,2]._showef = 1;
		sn[90,2]._txtidx = 801;
		sn[90,2]._extraimg = 0;

		sn[90,3]._chaimg = "cc_archive";
		sn[90,3]._mirror = false;
		sn[90,3]._pos = 0;
		sn[90,3]._showef = 1;
		sn[90,3]._txtidx = 802;
		sn[90,3]._extraimg = 0;

		sn[90,4]._chaimg = "cc_pet";
		sn[90,4]._mirror = false;
		sn[90,4]._pos = 0;
		sn[90,4]._showef = 1;
		sn[90,4]._txtidx = 803;
		sn[90,4]._extraimg = 0;

		sn[90,5]._chaimg = "cc_cha0";
		sn[90,5]._mirror = false;
		sn[90,5]._pos = 1;
		sn[90,5]._showef = 0;
		sn[90,5]._txtidx = 804;
		sn[90,5]._extraimg = 0;

		sn[90,6]._chaimg = "cc_yun0";
		sn[90,6]._mirror = false;
		sn[90,6]._pos = 0;
		sn[90,6]._showef = 0;
		sn[90,6]._txtidx = 805;
		sn[90,6]._extraimg = 0;

		sn[90,7]._chaimg = "cc_cha0";
		sn[90,7]._mirror = false;
		sn[90,7]._pos = 1;
		sn[90,7]._showef = 0;
		sn[90,7]._txtidx = 806;
		sn[90,7]._extraimg = 0;

		sn[90,8]._chaimg = "cc_pet";
		sn[90,8]._mirror = false;
		sn[90,8]._pos = 0;
		sn[90,8]._showef = 0;
		sn[90,8]._txtidx = 807;
		sn[90,8]._extraimg = 0;

		sn[90,9]._chaimg = "cc_pet";
		sn[90,9]._mirror = false;
		sn[90,9]._pos = 0;
		sn[90,9]._showef = 0;
		sn[90,9]._txtidx = 808;
		sn[90,9]._extraimg = 0;

		sn[90,10]._chaimg = "cc_cha1";
		sn[90,10]._mirror = false;
		sn[90,10]._pos = 1;
		sn[90,10]._showef = 0;
		sn[90,10]._txtidx = 809;
		sn[90,10]._extraimg = 0;

		sn[90,11]._chaimg = "cc_pet";
		sn[90,11]._mirror = false;
		sn[90,11]._pos = 0;
		sn[90,11]._showef = 0;
		sn[90,11]._txtidx = 810;
		sn[90,11]._extraimg = 0;

		sn[90,12]._chaimg = "cc_cha2";
		sn[90,12]._mirror = false;
		sn[90,12]._pos = 1;
		sn[90,12]._showef = 4;
		sn[90,12]._txtidx = 811;
		sn[90,12]._extraimg = 0;
	}

}
