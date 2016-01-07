using UnityEngine;
using System.Collections;

public  struct skillset
{
	public short _requireLV;
	public short _txtkind;
	public short _name;
	public short _info;
	
	public short _attackpoint;
	public short _price;
	public short _pricekind;
	public short _soulprice;
	public short _kind;
	public float _cooltime;
}

public class DB_Skill : MonoBehaviour {
	

	public skillset[,] ss = new skillset[20,5];
	
	void Awake()
	{
		//0.swordwind
		ss[0,0]._requireLV = 1;
		ss[0,0]._txtkind = 0;
		ss[0,0]._attackpoint = 120;
		ss[0,0]._cooltime = 15.1f;
		ss[0,0]._price = 0;
		ss[0,0]._pricekind = 0;
		ss[0,0]._soulprice = 1;
		ss[0,0]._name = 101;
		ss[0,0]._info = 121;
		ss[0,0]._kind = 1;

		ss[0,1]._requireLV = 1;
		ss[0,1]._txtkind = 0;
		ss[0,1]._attackpoint = 140;
		ss[0,1]._cooltime = 14.1f;
		ss[0,1]._price = 300;
		ss[0,1]._pricekind = 0;
		ss[0,1]._soulprice = 1;
		ss[0,1]._name = 101;
		ss[0,1]._info = 121;
		ss[0,1]._kind = 1;

		ss[0,2]._requireLV = 1;
		ss[0,2]._txtkind = 0;
		ss[0,2]._attackpoint = 165;
		ss[0,2]._cooltime = 12.1f;
		ss[0,2]._price = 600;
		ss[0,2]._pricekind = 0;
		ss[0,2]._soulprice = 1;
		ss[0,2]._name = 101;
		ss[0,2]._info = 121;
		ss[0,2]._kind = 1;

		ss[0,3]._requireLV = 1;
		ss[0,3]._txtkind = 0;
		ss[0,3]._attackpoint = 195;
		ss[0,3]._cooltime = 10.1f;
		ss[0,3]._price = 900;
		ss[0,3]._pricekind = 0;
		ss[0,3]._soulprice = 1;
		ss[0,3]._name = 101;
		ss[0,3]._info = 121;
		ss[0,3]._kind = 1;

		ss[0,4]._requireLV = 1;
		ss[0,4]._txtkind = 0;
		ss[0,4]._attackpoint = 225;
		ss[0,4]._cooltime = 7.1f;
		ss[0,4]._price = 1200;
		ss[0,4]._pricekind = 0;
		ss[0,4]._soulprice = 1;
		ss[0,4]._name = 101;
		ss[0,4]._info = 121;
		ss[0,4]._kind = 1;


		//1.jump splash
		ss[1,0]._requireLV = 3;
		ss[1,0]._txtkind = 0;
		ss[1,0]._attackpoint = 140;
		ss[1,0]._cooltime = 15.1f;
		ss[1,0]._price = 0;
		ss[1,0]._pricekind = 0;
		ss[1,0]._soulprice = 1;
		ss[1,0]._name = 105;
		ss[1,0]._info = 125;
		ss[1,0]._kind = 1;

		ss[1,1]._requireLV = 3;
		ss[1,1]._txtkind = 0;
		ss[1,1]._attackpoint = 160;
		ss[1,1]._cooltime = 14.1f;
		ss[1,1]._price = 300;
		ss[1,1]._pricekind = 0;
		ss[1,1]._soulprice = 1;
		ss[1,1]._name = 105;
		ss[1,1]._info = 125;
		ss[1,1]._kind = 1;

		ss[1,2]._requireLV = 3;
		ss[1,2]._txtkind = 0;
		ss[1,2]._attackpoint = 185;
		ss[1,2]._cooltime = 12.1f;
		ss[1,2]._price = 600;
		ss[1,2]._pricekind = 0;
		ss[1,2]._soulprice = 1;
		ss[1,2]._name = 105;
		ss[1,2]._info = 125;
		ss[1,2]._kind = 1;

		ss[1,3]._requireLV = 3;
		ss[1,3]._txtkind = 0;
		ss[1,3]._attackpoint = 215;
		ss[1,3]._cooltime = 10.1f;
		ss[1,3]._price = 900;
		ss[1,3]._pricekind = 0;
		ss[1,3]._soulprice = 1;
		ss[1,3]._name = 105;
		ss[1,3]._info = 125;
		ss[1,3]._kind = 1;

		ss[1,4]._requireLV = 3;
		ss[1,4]._txtkind = 0;
		ss[1,4]._attackpoint = 250;
		ss[1,4]._cooltime = 7.1f;
		ss[1,4]._price = 1200;
		ss[1,4]._pricekind = 0;
		ss[1,4]._soulprice = 1;
		ss[1,4]._name = 105;
		ss[1,4]._info = 125;
		ss[1,4]._kind = 1;


		//2whirl wind
		ss[2,0]._requireLV = 5;
		ss[2,0]._txtkind = 0;
		ss[2,0]._attackpoint = 65;
		ss[2,0]._cooltime = 15.1f;
		ss[2,0]._price = 0;
		ss[2,0]._pricekind = 0;
		ss[2,0]._soulprice = 2;
		ss[2,0]._name = 103;
		ss[2,0]._info = 123;
		ss[2,0]._kind = 1;

		ss[2,1]._requireLV = 5;
		ss[2,1]._txtkind = 0;
		ss[2,1]._attackpoint = 75;
		ss[2,1]._cooltime = 14.1f;
		ss[2,1]._price = 600;
		ss[2,1]._pricekind = 0;
		ss[2,1]._soulprice = 2;
		ss[2,1]._name = 103;
		ss[2,1]._info = 123;
		ss[2,1]._kind = 1;

		ss[2,2]._requireLV = 5;
		ss[2,2]._txtkind = 0;
		ss[2,2]._attackpoint = 90;
		ss[2,2]._cooltime = 12.1f;
		ss[2,2]._price = 1200;
		ss[2,2]._pricekind = 0;
		ss[2,2]._soulprice = 2;
		ss[2,2]._name = 103;
		ss[2,2]._info = 123;
		ss[2,2]._kind = 1;

		ss[2,3]._requireLV = 5;
		ss[2,3]._txtkind = 0;
		ss[2,3]._attackpoint = 110;
		ss[2,3]._cooltime = 10.1f;
		ss[2,3]._price = 1800;
		ss[2,3]._pricekind = 0;
		ss[2,3]._soulprice = 2;
		ss[2,3]._name = 103;
		ss[2,3]._info = 123;
		ss[2,3]._kind = 1;

		ss[2,4]._requireLV = 5;
		ss[2,4]._txtkind = 0;
		ss[2,4]._attackpoint = 135;
		ss[2,4]._cooltime = 7.1f;
		ss[2,4]._price = 2400;
		ss[2,4]._pricekind = 0;
		ss[2,4]._soulprice = 2;
		ss[2,4]._name = 103;
		ss[2,4]._info = 123;
		ss[2,4]._kind = 1;


		//3.defence boost
		ss[3,0]._requireLV = 1;
		ss[3,0]._txtkind = 1;
		ss[3,0]._attackpoint = 8;
		ss[3,0]._cooltime = 15.1f;
		ss[3,0]._price = 2;
		ss[3,0]._pricekind = 1;
		ss[3,0]._soulprice = 2;
		ss[3,0]._name = 110;
		ss[3,0]._info = 130;
		ss[3,0]._kind = 2;

		ss[3,1]._requireLV = 1;
		ss[3,1]._txtkind = 1;
		ss[3,1]._attackpoint = 10;
		ss[3,1]._cooltime = 14.1f;
		ss[3,1]._price = 4;
		ss[3,1]._pricekind = 1;
		ss[3,1]._soulprice = 2;
		ss[3,1]._name = 110;
		ss[3,1]._info = 130;
		ss[3,1]._kind = 2;

		ss[3,2]._requireLV = 1;
		ss[3,2]._txtkind = 1;
		ss[3,2]._attackpoint = 12;
		ss[3,2]._cooltime = 12.1f;
		ss[3,2]._price = 6;
		ss[3,2]._pricekind = 1;
		ss[3,2]._soulprice = 2;
		ss[3,2]._name = 110;
		ss[3,2]._info = 130;
		ss[3,2]._kind = 2;

		ss[3,3]._requireLV = 1;
		ss[3,3]._txtkind = 1;
		ss[3,3]._attackpoint = 14;
		ss[3,3]._cooltime = 10.1f;
		ss[3,3]._price = 8;
		ss[3,3]._pricekind = 1;
		ss[3,3]._soulprice = 2;
		ss[3,3]._name = 110;
		ss[3,3]._info = 130;
		ss[3,3]._kind = 2;

		ss[3,4]._requireLV = 1;
		ss[3,4]._txtkind = 1;
		ss[3,4]._attackpoint = 16;
		ss[3,4]._cooltime = 7.1f;
		ss[3,4]._price = 10;
		ss[3,4]._pricekind = 1;
		ss[3,4]._soulprice = 2;
		ss[3,4]._name = 110;
		ss[3,4]._info = 130;
		ss[3,4]._kind = 2;


		//4.rapid slash
		ss[4,0]._requireLV = 7;
		ss[4,0]._txtkind = 0;
		ss[4,0]._attackpoint = 70;
		ss[4,0]._cooltime = 15.1f;
		ss[4,0]._price = 0;
		ss[4,0]._pricekind = 0;
		ss[4,0]._soulprice = 2;
		ss[4,0]._name = 102;
		ss[4,0]._info = 122;
		ss[4,0]._kind = 1;

		ss[4,1]._requireLV = 7;
		ss[4,1]._txtkind = 0;
		ss[4,1]._attackpoint = 80;
		ss[4,1]._cooltime = 14.1f;
		ss[4,1]._price = 600;
		ss[4,1]._pricekind = 0;
		ss[4,1]._soulprice = 2;
		ss[4,1]._name = 102;
		ss[4,1]._info = 122;
		ss[4,1]._kind = 1;

		ss[4,2]._requireLV = 7;
		ss[4,2]._txtkind = 0;
		ss[4,2]._attackpoint = 95;
		ss[4,2]._cooltime = 12.1f;
		ss[4,2]._price = 1200;
		ss[4,2]._pricekind = 0;
		ss[4,2]._soulprice = 2;
		ss[4,2]._name = 102;
		ss[4,2]._info = 122;
		ss[4,2]._kind = 1;

		ss[4,3]._requireLV = 7;
		ss[4,3]._txtkind = 0;
		ss[4,3]._attackpoint = 115;
		ss[4,3]._cooltime = 10.1f;
		ss[4,3]._price = 1800;
		ss[4,3]._pricekind = 0;
		ss[4,3]._soulprice = 2;
		ss[4,3]._name = 102;
		ss[4,3]._info = 122;
		ss[4,3]._kind = 1;

		ss[4,4]._requireLV = 7;
		ss[4,4]._txtkind = 0;
		ss[4,4]._attackpoint = 140;
		ss[4,4]._cooltime = 7.1f;
		ss[4,4]._price = 2400;
		ss[4,4]._pricekind = 0;
		ss[4,4]._soulprice = 2;
		ss[4,4]._name = 102;
		ss[4,4]._info = 122;
		ss[4,4]._kind = 1;


		//5.lightningblade
		ss[5,0]._requireLV = 9;
		ss[5,0]._txtkind = 0;
		ss[5,0]._attackpoint = 160;
		ss[5,0]._cooltime = 15.1f;
		ss[5,0]._price = 0;
		ss[5,0]._pricekind = 0;
		ss[5,0]._soulprice = 2;
		ss[5,0]._name = 108;
		ss[5,0]._info = 128;
		ss[5,0]._kind = 1;

		ss[5,1]._requireLV = 9;
		ss[5,1]._txtkind = 0;
		ss[5,1]._attackpoint = 180;
		ss[5,1]._cooltime = 14.1f;
		ss[5,1]._price = 600;
		ss[5,1]._pricekind = 0;
		ss[5,1]._soulprice = 2;
		ss[5,1]._name = 108;
		ss[5,1]._info = 128;
		ss[5,1]._kind = 1;

		ss[5,2]._requireLV = 9;
		ss[5,2]._txtkind = 0;
		ss[5,2]._attackpoint = 205;
		ss[5,2]._cooltime = 12.1f;
		ss[5,2]._price = 1200;
		ss[5,2]._pricekind = 0;
		ss[5,2]._soulprice = 2;
		ss[5,2]._name = 108;
		ss[5,2]._info = 128;
		ss[5,2]._kind = 1;

		ss[5,3]._requireLV = 9;
		ss[5,3]._txtkind = 0;
		ss[5,3]._attackpoint = 235;
		ss[5,3]._cooltime = 10.1f;
		ss[5,3]._price = 1800;
		ss[5,3]._pricekind = 0;
		ss[5,3]._soulprice = 2;
		ss[5,3]._name = 108;
		ss[5,3]._info = 128;
		ss[5,3]._kind = 1;

		ss[5,4]._requireLV = 9;
		ss[5,4]._txtkind = 0;
		ss[5,4]._attackpoint = 265;
		ss[5,4]._cooltime = 7.1f;
		ss[5,4]._price = 2400;
		ss[5,4]._pricekind = 0;
		ss[5,4]._soulprice = 2;
		ss[5,4]._name = 108;
		ss[5,4]._info = 128;
		ss[5,4]._kind = 1;


		//6.ice spear
		ss[6,0]._requireLV = 11;
		ss[6,0]._txtkind = 0;
		ss[6,0]._attackpoint = 110;
		ss[6,0]._cooltime = 15.1f;
		ss[6,0]._price = 0;
		ss[6,0]._pricekind = 0;
		ss[6,0]._soulprice = 2;
		ss[6,0]._name = 104;
		ss[6,0]._info = 124;
		ss[6,0]._kind = 2;

		ss[6,1]._requireLV = 11;
		ss[6,1]._txtkind = 0;
		ss[6,1]._attackpoint = 120;
		ss[6,1]._cooltime = 14.1f;
		ss[6,1]._price = 600;
		ss[6,1]._pricekind = 0;
		ss[6,1]._soulprice = 2;
		ss[6,1]._name = 104;
		ss[6,1]._info = 124;
		ss[6,1]._kind = 2;

		ss[6,2]._requireLV = 11;
		ss[6,2]._txtkind = 0;
		ss[6,2]._attackpoint = 135;
		ss[6,2]._cooltime = 12.1f;
		ss[6,2]._price = 1200;
		ss[6,2]._pricekind = 0;
		ss[6,2]._soulprice = 2;
		ss[6,2]._name = 104;
		ss[6,2]._info = 124;
		ss[6,2]._kind = 2;

		ss[6,3]._requireLV = 11;
		ss[6,3]._txtkind = 0;
		ss[6,3]._attackpoint = 155;
		ss[6,3]._cooltime = 10.1f;
		ss[6,3]._price = 1800;
		ss[6,3]._pricekind = 0;
		ss[6,3]._soulprice = 2;
		ss[6,3]._name = 104;
		ss[6,3]._info = 124;
		ss[6,3]._kind = 2;

		ss[6,4]._requireLV = 11;
		ss[6,4]._txtkind = 0;
		ss[6,4]._attackpoint = 180;
		ss[6,4]._cooltime = 7.1f;
		ss[6,4]._price = 2400;
		ss[6,4]._pricekind = 0;
		ss[6,4]._soulprice = 2;
		ss[6,4]._name = 104;
		ss[6,4]._info = 124;
		ss[6,4]._kind = 2;


		//7.attack boost
		ss[7,0]._requireLV = 1;
		ss[7,0]._txtkind = 1;
		ss[7,0]._attackpoint = 6;
		ss[7,0]._cooltime = 15.1f;
		ss[7,0]._price = 2;
		ss[7,0]._pricekind = 1;
		ss[7,0]._soulprice = 2;
		ss[7,0]._name = 109;
		ss[7,0]._info = 129;
		ss[7,0]._kind = 2;

		ss[7,1]._requireLV = 1;
		ss[7,1]._txtkind = 1;
		ss[7,1]._attackpoint = 8;
		ss[7,1]._cooltime = 14.1f;
		ss[7,1]._price = 4;
		ss[7,1]._pricekind = 1;
		ss[7,1]._soulprice = 2;
		ss[7,1]._name = 109;
		ss[7,1]._info = 129;
		ss[7,1]._kind = 2;

		ss[7,2]._requireLV = 1;
		ss[7,2]._txtkind = 1;
		ss[7,2]._attackpoint = 10;
		ss[7,2]._cooltime = 12.1f;
		ss[7,2]._price = 6;
		ss[7,2]._pricekind = 1;
		ss[7,2]._soulprice = 2;
		ss[7,2]._name = 109;
		ss[7,2]._info = 129;
		ss[7,2]._kind = 2;

		ss[7,3]._requireLV = 1;
		ss[7,3]._txtkind = 1;
		ss[7,3]._attackpoint = 12;
		ss[7,3]._cooltime = 10.1f;
		ss[7,3]._price = 8;
		ss[7,3]._pricekind = 1;
		ss[7,3]._soulprice = 2;
		ss[7,3]._name = 109;
		ss[7,3]._info = 129;
		ss[7,3]._kind = 2;

		ss[7,4]._requireLV = 1;
		ss[7,4]._txtkind = 1;
		ss[7,4]._attackpoint = 14;
		ss[7,4]._cooltime = 7.1f;
		ss[7,4]._price = 10;
		ss[7,4]._pricekind = 1;
		ss[7,4]._soulprice = 2;
		ss[7,4]._name = 109;
		ss[7,4]._info = 129;
		ss[7,4]._kind = 2;


		//8.poison ball
		ss[8,0]._requireLV = 13;
		ss[8,0]._txtkind = 0;
		ss[8,0]._attackpoint = 5;
		ss[8,0]._cooltime = 20.1f;
		ss[8,0]._price = 0;
		ss[8,0]._pricekind = 0;
		ss[8,0]._soulprice = 3;
		ss[8,0]._name = 112;
		ss[8,0]._info = 132;
		ss[8,0]._kind = 3;

		ss[8,1]._requireLV = 13;
		ss[8,1]._txtkind = 0;
		ss[8,1]._attackpoint = 6;
		ss[8,1]._cooltime = 18.1f;
		ss[8,1]._price = 900;
		ss[8,1]._pricekind = 0;
		ss[8,1]._soulprice = 3;
		ss[8,1]._name = 112;
		ss[8,1]._info = 132;
		ss[8,1]._kind = 3;

		ss[8,2]._requireLV = 13;
		ss[8,2]._txtkind = 0;
		ss[8,2]._attackpoint = 7;
		ss[8,2]._cooltime = 16.1f;
		ss[8,2]._price = 1800;
		ss[8,2]._pricekind = 0;
		ss[8,2]._soulprice = 3;
		ss[8,2]._name = 112;
		ss[8,2]._info = 132;
		ss[8,2]._kind = 3;

		ss[8,3]._requireLV = 13;
		ss[8,3]._txtkind = 0;
		ss[8,3]._attackpoint = 8;
		ss[8,3]._cooltime = 14.1f;
		ss[8,3]._price = 2700;
		ss[8,3]._pricekind = 0;
		ss[8,3]._soulprice = 3;
		ss[8,3]._name = 112;
		ss[8,3]._info = 132;
		ss[8,3]._kind = 3;

		ss[8,4]._requireLV = 13;
		ss[8,4]._txtkind = 0;
		ss[8,4]._attackpoint = 9;
		ss[8,4]._cooltime = 12.1f;
		ss[8,4]._price = 3600;
		ss[8,4]._pricekind = 0;
		ss[8,4]._soulprice = 3;
		ss[8,4]._name = 112;
		ss[8,4]._info = 132;
		ss[8,4]._kind = 3;


		//9.death hand
		ss[9,0]._requireLV = 15;
		ss[9,0]._txtkind = 2;
		ss[9,0]._attackpoint = 50;
		ss[9,0]._cooltime = 20.1f;
		ss[9,0]._price = 0;
		ss[9,0]._pricekind = 0;
		ss[9,0]._soulprice = 3;
		ss[9,0]._name = 113;
		ss[9,0]._info = 133;
		ss[9,0]._kind = 3;

		ss[9,1]._requireLV = 15;
		ss[9,1]._txtkind = 2;
		ss[9,1]._attackpoint = 60;
		ss[9,1]._cooltime = 18.1f;
		ss[9,1]._price = 900;
		ss[9,1]._pricekind = 0;
		ss[9,1]._soulprice = 3;
		ss[9,1]._name = 113;
		ss[9,1]._info = 133;
		ss[9,1]._kind = 3;

		ss[9,2]._requireLV = 15;
		ss[9,2]._txtkind = 2;
		ss[9,2]._attackpoint = 70;
		ss[9,2]._cooltime = 16.1f;
		ss[9,2]._price = 1800;
		ss[9,2]._pricekind = 0;
		ss[9,2]._soulprice = 3;
		ss[9,2]._name = 113;
		ss[9,2]._info = 133;
		ss[9,2]._kind = 3;

		ss[9,3]._requireLV = 15;
		ss[9,3]._txtkind = 2;
		ss[9,3]._attackpoint = 80;
		ss[9,3]._cooltime = 14.1f;
		ss[9,3]._price = 2700;
		ss[9,3]._pricekind = 0;
		ss[9,3]._soulprice = 3;
		ss[9,3]._name = 113;
		ss[9,3]._info = 133;
		ss[9,3]._kind = 3;

		ss[9,4]._requireLV = 15;
		ss[9,4]._txtkind = 2;
		ss[9,4]._attackpoint = 90;
		ss[9,4]._cooltime = 12.1f;
		ss[9,4]._price = 3600;
		ss[9,4]._pricekind = 0;
		ss[9,4]._soulprice = 3;
		ss[9,4]._name = 113;
		ss[9,4]._info = 133;
		ss[9,4]._kind = 3;


		//10.Beam sword
		ss[10,0]._requireLV = 17;
		ss[10,0]._txtkind = 0;
		ss[10,0]._attackpoint = 230;
		ss[10,0]._cooltime = 20.1f;
		ss[10,0]._price = 0;
		ss[10,0]._pricekind = 0;
		ss[10,0]._soulprice = 3;
		ss[10,0]._name = 106;
		ss[10,0]._info = 126;
		ss[10,0]._kind = 1;

		ss[10,1]._requireLV = 17;
		ss[10,1]._txtkind = 0;
		ss[10,1]._attackpoint = 240;
		ss[10,1]._cooltime = 18.1f;
		ss[10,1]._price = 900;
		ss[10,1]._pricekind = 0;
		ss[10,1]._soulprice = 3;
		ss[10,1]._name = 106;
		ss[10,1]._info = 126;
		ss[10,1]._kind = 1;

		ss[10,2]._requireLV = 17;
		ss[10,2]._txtkind = 0;
		ss[10,2]._attackpoint = 260;
		ss[10,2]._cooltime = 16.1f;
		ss[10,2]._price = 1800;
		ss[10,2]._pricekind = 0;
		ss[10,2]._soulprice = 3;
		ss[10,2]._name = 106;
		ss[10,2]._info = 126;
		ss[10,2]._kind = 1;

		ss[10,3]._requireLV = 17;
		ss[10,3]._txtkind = 0;
		ss[10,3]._attackpoint = 290;
		ss[10,3]._cooltime = 14.1f;
		ss[10,3]._price = 2700;
		ss[10,3]._pricekind = 0;
		ss[10,3]._soulprice = 3;
		ss[10,3]._name = 106;
		ss[10,3]._info = 126;
		ss[10,3]._kind = 1;

		ss[10,4]._requireLV = 17;
		ss[10,4]._txtkind = 0;
		ss[10,4]._attackpoint = 330;
		ss[10,4]._cooltime = 12.1f;
		ss[10,4]._price = 3600;
		ss[10,4]._pricekind = 0;
		ss[10,4]._soulprice = 3;
		ss[10,4]._name = 106;
		ss[10,4]._info = 126;
		ss[10,4]._kind = 1;


		//11.rising fire
		ss[11,0]._requireLV = 19;
		ss[11,0]._txtkind = 0;
		ss[11,0]._attackpoint = 190;
		ss[11,0]._cooltime = 20.1f;
		ss[11,0]._price = 0;
		ss[11,0]._pricekind = 0;
		ss[11,0]._soulprice = 3;
		ss[11,0]._name = 107;
		ss[11,0]._info = 127;
		ss[11,0]._kind = 4;

		ss[11,1]._requireLV = 19;
		ss[11,1]._txtkind = 0;
		ss[11,1]._attackpoint = 200;
		ss[11,1]._cooltime = 18.1f;
		ss[11,1]._price = 900;
		ss[11,1]._pricekind = 0;
		ss[11,1]._soulprice = 3;
		ss[11,1]._name = 107;
		ss[11,1]._info = 127;
		ss[11,1]._kind = 4;

		ss[11,2]._requireLV = 19;
		ss[11,2]._txtkind = 0;
		ss[11,2]._attackpoint = 220;
		ss[11,2]._cooltime = 16.1f;
		ss[11,2]._price = 1800;
		ss[11,2]._pricekind = 0;
		ss[11,2]._soulprice = 3;
		ss[11,2]._name = 107;
		ss[11,2]._info = 127;
		ss[11,2]._kind = 4;

		ss[11,3]._requireLV = 19;
		ss[11,3]._txtkind = 0;
		ss[11,3]._attackpoint = 250;
		ss[11,3]._cooltime = 14.1f;
		ss[11,3]._price = 2700;
		ss[11,3]._pricekind = 0;
		ss[11,3]._soulprice = 3;
		ss[11,3]._name = 107;
		ss[11,3]._info = 127;
		ss[11,3]._kind = 4;

		ss[11,4]._requireLV = 19;
		ss[11,4]._txtkind = 0;
		ss[11,4]._attackpoint = 290;
		ss[11,4]._cooltime = 12.1f;
		ss[11,4]._price = 3600;
		ss[11,4]._pricekind = 0;
		ss[11,4]._soulprice = 3;
		ss[11,4]._name = 107;
		ss[11,4]._info = 127;
		ss[11,4]._kind = 4;


		//12.sword dance
		ss[12,0]._requireLV = 1;
		ss[12,0]._txtkind = 0;
		ss[12,0]._attackpoint = 110;
		ss[12,0]._cooltime = 30.1f;
		ss[12,0]._price = 7;
		ss[12,0]._pricekind = 1;
		ss[12,0]._soulprice = 4;
		ss[12,0]._name = 111;
		ss[12,0]._info = 131;
		ss[12,0]._kind = 1;

		ss[12,1]._requireLV = 1;
		ss[12,1]._txtkind = 0;
		ss[12,1]._attackpoint = 120;
		ss[12,1]._cooltime = 26.1f;
		ss[12,1]._price = 9;
		ss[12,1]._pricekind = 1;
		ss[12,1]._soulprice = 4;
		ss[12,1]._name = 111;
		ss[12,1]._info = 131;
		ss[12,1]._kind = 1;

		ss[12,2]._requireLV = 1;
		ss[12,2]._txtkind = 0;
		ss[12,2]._attackpoint = 140;
		ss[12,2]._cooltime = 22.1f;
		ss[12,2]._price = 11;
		ss[12,2]._pricekind = 1;
		ss[12,2]._soulprice = 4;
		ss[12,2]._name = 111;
		ss[12,2]._info = 131;
		ss[12,2]._kind = 1;

		ss[12,3]._requireLV = 1;
		ss[12,3]._txtkind = 0;
		ss[12,3]._attackpoint = 170;
		ss[12,3]._cooltime = 18.1f;
		ss[12,3]._price = 13;
		ss[12,3]._pricekind = 1;
		ss[12,3]._soulprice = 4;
		ss[12,3]._name = 111;
		ss[12,3]._info = 131;
		ss[12,3]._kind = 1;

		ss[12,4]._requireLV = 1;
		ss[12,4]._txtkind = 0;
		ss[12,4]._attackpoint = 210;
		ss[12,4]._cooltime = 14.1f;
		ss[12,4]._price = 15;
		ss[12,4]._pricekind = 1;
		ss[12,4]._soulprice = 4;
		ss[12,4]._name = 111;
		ss[12,4]._info = 131;
		ss[12,4]._kind = 1;


		//13.junwui
		ss[13,0]._requireLV = 1;
		ss[13,0]._txtkind = 0;
		ss[13,0]._attackpoint = 110;
		ss[13,0]._cooltime = 30.1f;
		ss[13,0]._price = 7;
		ss[13,0]._pricekind = 1;
		ss[13,0]._soulprice = 4;
		ss[13,0]._name = 115;
		ss[13,0]._info = 135;
		ss[13,0]._kind = 2;

		ss[13,1]._requireLV = 1;
		ss[13,1]._txtkind = 0;
		ss[13,1]._attackpoint = 120;
		ss[13,1]._cooltime = 26.1f;
		ss[13,1]._price = 9;
		ss[13,1]._pricekind = 1;
		ss[13,1]._soulprice = 4;
		ss[13,1]._name = 115;
		ss[13,1]._info = 135;
		ss[13,1]._kind = 2;

		ss[13,2]._requireLV = 1;
		ss[13,2]._txtkind = 0;
		ss[13,2]._attackpoint = 140;
		ss[13,2]._cooltime = 22.1f;
		ss[13,2]._price = 11;
		ss[13,2]._pricekind = 1;
		ss[13,2]._soulprice = 4;
		ss[13,2]._name = 115;
		ss[13,2]._info = 135;
		ss[13,2]._kind = 2;

		ss[13,3]._requireLV = 1;
		ss[13,3]._txtkind = 0;
		ss[13,3]._attackpoint = 170;
		ss[13,3]._cooltime = 18.1f;
		ss[13,3]._price = 13;
		ss[13,3]._pricekind = 1;
		ss[13,3]._soulprice = 4;
		ss[13,3]._name = 115;
		ss[13,3]._info = 135;
		ss[13,3]._kind = 2;

		ss[13,4]._requireLV = 1;
		ss[13,4]._txtkind = 0;
		ss[13,4]._attackpoint = 210;
		ss[13,4]._cooltime = 14.1f;
		ss[13,4]._price = 15;
		ss[13,4]._pricekind = 1;
		ss[13,4]._soulprice = 4;
		ss[13,4]._name = 115;
		ss[13,4]._info = 135;
		ss[13,4]._kind = 2;


		//14.water dragon
		ss[14,0]._requireLV = 1;
		ss[14,0]._txtkind = 0;
		ss[14,0]._attackpoint = 140;
		ss[14,0]._cooltime = 30.1f;
		ss[14,0]._price = 7;
		ss[14,0]._pricekind = 1;
		ss[14,0]._soulprice = 4;
		ss[14,0]._name = 116;
		ss[14,0]._info = 136;
		ss[14,0]._kind = 3;

		ss[14,1]._requireLV = 1;
		ss[14,1]._txtkind = 0;
		ss[14,1]._attackpoint = 180;
		ss[14,1]._cooltime = 26.1f;
		ss[14,1]._price = 9;
		ss[14,1]._pricekind = 1;
		ss[14,1]._soulprice = 4;
		ss[14,1]._name = 116;
		ss[14,1]._info = 136;
		ss[14,1]._kind = 3;

		ss[14,2]._requireLV = 1;
		ss[14,2]._txtkind = 0;
		ss[14,2]._attackpoint = 220;
		ss[14,2]._cooltime = 22.1f;
		ss[14,2]._price = 11;
		ss[14,2]._pricekind = 1;
		ss[14,2]._soulprice = 4;
		ss[14,2]._name = 116;
		ss[14,2]._info = 136;
		ss[14,2]._kind = 3;

		ss[14,3]._requireLV = 1;
		ss[14,3]._txtkind = 0;
		ss[14,3]._attackpoint = 260;
		ss[14,3]._cooltime = 18.1f;
		ss[14,3]._price = 13;
		ss[14,3]._pricekind = 1;
		ss[14,3]._soulprice = 4;
		ss[14,3]._name = 116;
		ss[14,3]._info = 136;
		ss[14,3]._kind = 3;

		ss[14,4]._requireLV = 1;
		ss[14,4]._txtkind = 0;
		ss[14,4]._attackpoint = 300;
		ss[14,4]._cooltime = 14.1f;
		ss[14,4]._price = 15;
		ss[14,4]._pricekind = 1;
		ss[14,4]._soulprice = 4;
		ss[14,4]._name = 116;
		ss[14,4]._info = 136;
		ss[14,4]._kind = 3;


		//15.chosun
		ss[15,0]._requireLV = 1;
		ss[15,0]._txtkind = 0;
		ss[15,0]._attackpoint = 120;
		ss[15,0]._cooltime = 30.1f;
		ss[15,0]._price = 7;
		ss[15,0]._pricekind = 1;
		ss[15,0]._soulprice = 4;
		ss[15,0]._name = 114;
		ss[15,0]._info = 134;
		ss[15,0]._kind = 2;

		ss[15,1]._requireLV = 1;
		ss[15,1]._txtkind = 0;
		ss[15,1]._attackpoint = 150;
		ss[15,1]._cooltime = 26.1f;
		ss[15,1]._price = 9;
		ss[15,1]._pricekind = 1;
		ss[15,1]._soulprice = 4;
		ss[15,1]._name = 114;
		ss[15,1]._info = 134;
		ss[15,1]._kind = 2;

		ss[15,2]._requireLV = 1;
		ss[15,2]._txtkind = 0;
		ss[15,2]._attackpoint = 180;
		ss[15,2]._cooltime = 22.1f;
		ss[15,2]._price = 11;
		ss[15,2]._pricekind = 1;
		ss[15,2]._soulprice = 4;
		ss[15,2]._name = 114;
		ss[15,2]._info = 134;
		ss[15,2]._kind = 2;

		ss[15,3]._requireLV = 1;
		ss[15,3]._txtkind = 0;
		ss[15,3]._attackpoint = 210;
		ss[15,3]._cooltime = 18.1f;
		ss[15,3]._price = 13;
		ss[15,3]._pricekind = 1;
		ss[15,3]._soulprice = 4;
		ss[15,3]._name = 114;
		ss[15,3]._info = 134;
		ss[15,3]._kind = 2;

		ss[15,4]._requireLV = 1;
		ss[15,4]._txtkind = 0;
		ss[15,4]._attackpoint = 240;
		ss[15,4]._cooltime = 14.1f;
		ss[15,4]._price = 15;
		ss[15,4]._pricekind = 1;
		ss[15,4]._soulprice = 4;
		ss[15,4]._name = 114;
		ss[15,4]._info = 134;
		ss[15,4]._kind = 2;


		//16.jangkak
		ss[16,0]._requireLV = 1;
		ss[16,0]._txtkind = 0;
		ss[16,0]._attackpoint = 80;
		ss[16,0]._cooltime = 30.1f;
		ss[16,0]._price = 7;
		ss[16,0]._pricekind = 1;
		ss[16,0]._soulprice = 5;
		ss[16,0]._name = 117;
		ss[16,0]._info = 137;
		ss[16,0]._kind = 4;

		ss[16,1]._requireLV = 1;
		ss[16,1]._txtkind = 0;
		ss[16,1]._attackpoint = 90;
		ss[16,1]._cooltime = 26.1f;
		ss[16,1]._price = 9;
		ss[16,1]._pricekind = 1;
		ss[16,1]._soulprice = 5;
		ss[16,1]._name = 117;
		ss[16,1]._info = 137;
		ss[16,1]._kind = 4;

		ss[16,2]._requireLV = 1;
		ss[16,2]._txtkind = 0;
		ss[16,2]._attackpoint = 100;
		ss[16,2]._cooltime = 22.1f;
		ss[16,2]._price = 11;
		ss[16,2]._pricekind = 1;
		ss[16,2]._soulprice = 5;
		ss[16,2]._name = 117;
		ss[16,2]._info = 137;
		ss[16,2]._kind = 4;

		ss[16,3]._requireLV = 1;
		ss[16,3]._txtkind = 0;
		ss[16,3]._attackpoint = 110;
		ss[16,3]._cooltime = 18.1f;
		ss[16,3]._price = 13;
		ss[16,3]._pricekind = 1;
		ss[16,3]._soulprice = 5;
		ss[16,3]._name = 117;
		ss[16,3]._info = 137;
		ss[16,3]._kind = 4;

		ss[16,4]._requireLV = 1;
		ss[16,4]._txtkind = 0;
		ss[16,4]._attackpoint = 120;
		ss[16,4]._cooltime = 14.1f;
		ss[16,4]._price = 15;
		ss[16,4]._pricekind = 1;
		ss[16,4]._soulprice = 5;
		ss[16,4]._name = 117;
		ss[16,4]._info = 137;
		ss[16,4]._kind = 4;


		//17.bamboo
		ss[17,0]._requireLV = 1;
		ss[17,0]._txtkind = 0;
		ss[17,0]._attackpoint = 400;
		ss[17,0]._cooltime = 30.1f;
		ss[17,0]._price = 7;
		ss[17,0]._pricekind = 1;
		ss[17,0]._soulprice = 5;
		ss[17,0]._name = 118;
		ss[17,0]._info = 138;
		ss[17,0]._kind = 4;

		ss[17,1]._requireLV = 1;
		ss[17,1]._txtkind = 0;
		ss[17,1]._attackpoint = 420;
		ss[17,1]._cooltime = 26.1f;
		ss[17,1]._price = 9;
		ss[17,1]._pricekind = 1;
		ss[17,1]._soulprice = 5;
		ss[17,1]._name = 118;
		ss[17,1]._info = 138;
		ss[17,1]._kind = 4;

		ss[17,2]._requireLV = 1;
		ss[17,2]._txtkind = 0;
		ss[17,2]._attackpoint = 450;
		ss[17,2]._cooltime = 22.1f;
		ss[17,2]._price = 11;
		ss[17,2]._pricekind = 1;
		ss[17,2]._soulprice = 5;
		ss[17,2]._name = 118;
		ss[17,2]._info = 138;
		ss[17,2]._kind = 4;

		ss[17,3]._requireLV = 1;
		ss[17,3]._txtkind = 0;
		ss[17,3]._attackpoint = 490;
		ss[17,3]._cooltime = 18.1f;
		ss[17,3]._price = 13;
		ss[17,3]._pricekind = 1;
		ss[17,3]._soulprice = 5;
		ss[17,3]._name = 118;
		ss[17,3]._info = 138;
		ss[17,3]._kind = 4;

		ss[17,4]._requireLV = 1;
		ss[17,4]._txtkind = 0;
		ss[17,4]._attackpoint = 540;
		ss[17,4]._cooltime = 14.1f;
		ss[17,4]._price = 15;
		ss[17,4]._pricekind = 1;
		ss[17,4]._soulprice = 5;
		ss[17,4]._name = 118;
		ss[17,4]._info = 138;
		ss[17,4]._kind = 4;


		//18.swordrain
		ss[18,0]._requireLV = 1;
		ss[18,0]._txtkind = 0;
		ss[18,0]._attackpoint = 110;
		ss[18,0]._cooltime = 30.1f;
		ss[18,0]._price = 7;
		ss[18,0]._pricekind = 1;
		ss[18,0]._soulprice = 5;
		ss[18,0]._name = 119;
		ss[18,0]._info = 139;
		ss[18,0]._kind = 4;

		ss[18,1]._requireLV = 1;
		ss[18,1]._txtkind = 0;
		ss[18,1]._attackpoint = 120;
		ss[18,1]._cooltime = 26.1f;
		ss[18,1]._price = 9;
		ss[18,1]._pricekind = 1;
		ss[18,1]._soulprice = 5;
		ss[18,1]._name = 119;
		ss[18,1]._info = 139;
		ss[18,1]._kind = 4;

		ss[18,2]._requireLV = 1;
		ss[18,2]._txtkind = 0;
		ss[18,2]._attackpoint = 140;
		ss[18,2]._cooltime = 22.1f;
		ss[18,2]._price = 11;
		ss[18,2]._pricekind = 1;
		ss[18,2]._soulprice = 5;
		ss[18,2]._name = 119;
		ss[18,2]._info = 139;
		ss[18,2]._kind = 4;

		ss[18,3]._requireLV = 1;
		ss[18,3]._txtkind = 0;
		ss[18,3]._attackpoint = 170;
		ss[18,3]._cooltime = 18.1f;
		ss[18,3]._price = 13;
		ss[18,3]._pricekind = 1;
		ss[18,3]._soulprice = 5;
		ss[18,3]._name = 119;
		ss[18,3]._info = 139;
		ss[18,3]._kind = 4;

		ss[18,4]._requireLV = 1;
		ss[18,4]._txtkind = 0;
		ss[18,4]._attackpoint = 210;
		ss[18,4]._cooltime = 14.1f;
		ss[18,4]._price = 15;
		ss[18,4]._pricekind = 1;
		ss[18,4]._soulprice = 5;
		ss[18,4]._name = 119;
		ss[18,4]._info = 139;
		ss[18,4]._kind = 4;


		//19.godfist
		ss[19,0]._requireLV = 1;
		ss[19,0]._txtkind = 0;
		ss[19,0]._attackpoint = 420;
		ss[19,0]._cooltime = 30.1f;
		ss[19,0]._price = 7;
		ss[19,0]._pricekind = 1;
		ss[19,0]._soulprice = 5;
		ss[19,0]._name = 120;
		ss[19,0]._info = 140;
		ss[19,0]._kind = 2;

		ss[19,1]._requireLV = 1;
		ss[19,1]._txtkind = 0;
		ss[19,1]._attackpoint = 440;
		ss[19,1]._cooltime = 26.1f;
		ss[19,1]._price = 9;
		ss[19,1]._pricekind = 1;
		ss[19,1]._soulprice = 5;
		ss[19,1]._name = 120;
		ss[19,1]._info = 140;
		ss[19,1]._kind = 2;

		ss[19,2]._requireLV = 1;
		ss[19,2]._txtkind = 0;
		ss[19,2]._attackpoint = 470;
		ss[19,2]._cooltime = 22.1f;
		ss[19,2]._price = 11;
		ss[19,2]._pricekind = 1;
		ss[19,2]._soulprice = 5;
		ss[19,2]._name = 120;
		ss[19,2]._info = 140;
		ss[19,2]._kind = 2;

		ss[19,3]._requireLV = 1;
		ss[19,3]._txtkind = 0;
		ss[19,3]._attackpoint = 510;
		ss[19,3]._cooltime = 18.1f;
		ss[19,3]._price = 13;
		ss[19,3]._pricekind = 1;
		ss[19,3]._soulprice = 5;
		ss[19,3]._name = 120;
		ss[19,3]._info = 140;
		ss[19,3]._kind = 2;

		ss[19,4]._requireLV = 1;
		ss[19,4]._txtkind = 0;
		ss[19,4]._attackpoint = 560;
		ss[19,4]._cooltime = 14.1f;
		ss[19,4]._price = 15;
		ss[19,4]._pricekind = 1;
		ss[19,4]._soulprice = 5;
		ss[19,4]._name = 120;
		ss[19,4]._info = 140;
		ss[19,4]._kind = 2;

	}
}
