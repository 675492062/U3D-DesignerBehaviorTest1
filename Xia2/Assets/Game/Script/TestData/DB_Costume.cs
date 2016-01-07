using UnityEngine;
using System.Collections;

public  struct coustume
{
	public short _name;
	public short _info;
	public short _bossindex;
	public short _plushp;
	public short _jadecost;
}

public class DB_Costume : MonoBehaviour {

	
	public coustume[] ci = new coustume[17];
	void Awake()
	{
		//basic
		ci[0]._jadecost = 0;
		ci[0]._bossindex = -1;
		ci[0]._plushp = 0;
		ci[0]._name = 1;
		ci[0]._info = 21;

		//armor
		ci[1]._jadecost = 1500;
		ci[1]._bossindex = -1;
		ci[1]._plushp = 20;
		ci[1]._name = 2;
		ci[1]._info = 22;

		//armor
		ci[2]._jadecost = 3000;
		ci[2]._bossindex = -1;
		ci[2]._plushp = 40;
		ci[2]._name = 3;
		ci[2]._info = 23;

		//armor
		ci[3]._jadecost = 100;
		ci[3]._bossindex = -1;
		ci[3]._plushp = 20;
		ci[3]._name = 4;
		ci[3]._info = 24;

		//armor
		ci[4]._jadecost = 100;
		ci[4]._bossindex = -1;
		ci[4]._plushp = 20;
		ci[4]._name = 5;
		ci[4]._info = 25;

		//armor
		ci[5]._jadecost = 100;
		ci[5]._bossindex = -1;
		ci[5]._plushp = 20;
		ci[5]._name = 6;
		ci[5]._info = 26;

		//armor
		ci[6]._jadecost = 100;
		ci[6]._bossindex = -1;
		ci[6]._plushp = 20;
		ci[6]._name = 7;
		ci[6]._info = 27;

		//armor
		ci[7]._jadecost = 100;
		ci[7]._bossindex = -1;
		ci[7]._plushp = 20;
		ci[7]._name = 8;
		ci[7]._info = 28;

		//armor
		ci[8]._jadecost = 100;
		ci[8]._bossindex = -1;
		ci[8]._plushp = 20;
		ci[8]._name = 9;
		ci[8]._info = 29;

		//armor
		ci[9]._jadecost = 100;
		ci[9]._bossindex = -1;
		ci[9]._plushp = 20;
		ci[9]._name = 10;
		ci[9]._info = 30;

		//armor
		ci[10]._jadecost = 100;
		ci[10]._bossindex = -1;
		ci[10]._plushp = 20;
		ci[10]._name = 11;
		ci[10]._info = 31;

		//armor
		ci[11]._jadecost = 100;
		ci[11]._bossindex = -1;
		ci[11]._plushp = 20;
		ci[11]._name = 12;
		ci[11]._info = 32;

		//armor
		ci[12]._jadecost = 100;
		ci[12]._bossindex = -1;
		ci[12]._plushp = 20;
		ci[12]._name = 13;
		ci[12]._info = 33;

		//armor
		ci[13]._jadecost = 100;
		ci[13]._bossindex = -1;
		ci[13]._plushp = 20;
		ci[13]._name = 14;
		ci[13]._info = 34;

		//armor
		ci[14]._jadecost = 100;
		ci[14]._bossindex = -1;
		ci[14]._plushp = 20;
		ci[14]._name = 15;
		ci[14]._info = 35;

		//armor
		ci[15]._jadecost = 100;
		ci[15]._bossindex = -1;
		ci[15]._plushp = 20;
		ci[15]._name = 16;
		ci[15]._info = 36;

		//armor
		ci[16]._jadecost = 300;
		ci[16]._bossindex = -1;
		ci[16]._plushp = 20;
		ci[16]._name = 17;
		ci[16]._info = 37;
	}

}
