using UnityEngine;
using System.Collections;

public  struct weapon
{
	public short _name;
	public short _info;

	public short _power;
	public float _speed;
	public short _mesh;
	public short _kind;
	public short _jadecost;
}

public class DB_Weapon : MonoBehaviour {

	
	public weapon[] wi = new weapon[26];
		void Awake()
	{
		//basic
		wi[0]._power = 8;
		wi[0]._speed = 1;
		wi[0]._name = 81;
		wi[0]._info = 61;
		wi[0]._mesh = 0;
		wi[0]._kind = 0;
		wi[0]._jadecost = 0;

		//1sword(duel)
		wi[1]._power = 15;
		wi[1]._speed = 1.5f;
		wi[1]._name = 41;
		wi[1]._info = 63;
		wi[1]._mesh = 1;
		wi[1]._kind = 1;
		wi[1]._jadecost = 0;

		//2sword(spear)
		wi[2]._power = 25;
		wi[2]._speed = 2;
		wi[2]._name = 42;
		wi[2]._info = 64;
		wi[2]._mesh = 2;
		wi[2]._kind = 2;
		wi[2]._jadecost = 0;

		//3sword
		wi[3]._power = 35;
		wi[3]._speed = 2.5f;
		wi[3]._name = 43;
		wi[3]._info = 65;
		wi[3]._mesh = 3;
		wi[3]._kind = 0;
		wi[3]._jadecost = 0;

		//4sword(duel)
		wi[4]._power = 45;
		wi[4]._speed = 3;
		wi[4]._name = 44;
		wi[4]._info = 66;
		wi[4]._mesh = 4;
		wi[4]._kind = 1;
		wi[4]._jadecost = 0;

		//5sword(spear)
		wi[5]._power = 55;
		wi[5]._speed = 3.5f;
		wi[5]._name = 45;
		wi[5]._info = 67;
		wi[5]._mesh = 5;
		wi[5]._kind = 2;
		wi[5]._jadecost = 0;

		//6sword
		wi[6]._power = 65;
		wi[6]._speed = 4;
		wi[6]._name = 46;
		wi[6]._info = 68;
		wi[6]._mesh = 6;
		wi[6]._kind = 0;
		wi[6]._jadecost = 0;

		//7sword(duel)
		wi[7]._power = 75;
		wi[7]._speed = 4.5f;
		wi[7]._name = 47;
		wi[7]._info = 69;
		wi[7]._mesh = 7;
		wi[7]._kind = 1;
		wi[7]._jadecost = 0;

		//8sword(spear)
		wi[8]._power = 85;
		wi[8]._speed = 5;
		wi[8]._name = 48;
		wi[8]._info = 70;
		wi[8]._mesh = 8;
		wi[8]._kind = 2;
		wi[8]._jadecost = 0;

		//9sword
		wi[9]._power = 95;
		wi[9]._speed = 5.5f;
		wi[9]._name = 49;
		wi[9]._info = 68;
		wi[9]._mesh = 9;
		wi[9]._kind = 0;
		wi[9]._jadecost = 0;

		//10sword(duel)
		wi[10]._power = 105;
		wi[10]._speed = 6;
		wi[10]._name = 50;
		wi[10]._info = 69;
		wi[10]._mesh = 10;
		wi[10]._kind = 1;
		wi[10]._jadecost = 0;

		//11sword(spear)
		wi[11]._power = 115;
		wi[11]._speed = 6.5f;
		wi[11]._name = 51;
		wi[11]._info = 70;
		wi[11]._mesh = 11;
		wi[11]._kind = 2;
		wi[11]._jadecost = 0;

		//12sword
		wi[12]._power = 125;
		wi[12]._speed = 7;
		wi[12]._name = 52;
		wi[12]._info = 68;
		wi[12]._mesh = 12;
		wi[12]._kind = 0;
		wi[12]._jadecost = 0;

		//13sword(duel)
		wi[13]._power = 135;
		wi[13]._speed = 7.5f;
		wi[13]._name = 53;
		wi[13]._info = 69;
		wi[13]._mesh = 13;
		wi[13]._kind = 1;
		wi[13]._jadecost = 0;

		//14sword(spear)
		wi[14]._power = 145;
		wi[14]._speed = 8;
		wi[14]._name = 54;
		wi[14]._info = 70;
		wi[14]._mesh = 14;
		wi[14]._kind = 2;
		wi[14]._jadecost = 0;

		//15sword
		wi[15]._power = 155;
		wi[15]._speed = 8.5f;
		wi[15]._name = 55;
		wi[15]._info = 71;
		wi[15]._mesh = 15;
		wi[15]._kind = 0;
		wi[15]._jadecost = 0;

		//16sword_UNIQUE
		wi[16]._power = 55;
		wi[16]._speed = 5.8f;
		wi[16]._name = 71;
		wi[16]._info = 92;
		wi[16]._mesh = 16;
		wi[16]._kind = 0;
		wi[16]._jadecost = 45;

		//sword(duel)
		wi[17]._power = 55;
		wi[17]._speed = 6.1f;
		wi[17]._name = 72;
		wi[17]._info = 93;
		wi[17]._mesh = 17;
		wi[17]._kind = 1;
		wi[17]._jadecost = 60;

		//sword(spear)
		wi[18]._power = 55;
		wi[18]._speed = 6.5f;
		wi[18]._name = 73;
		wi[18]._info = 94;
		wi[18]._mesh = 18;
		wi[18]._kind = 2;
		wi[18]._jadecost = 60;

		//sword
		wi[19]._power = 135;
		wi[19]._speed = 6.8f;
		wi[19]._name = 74;
		wi[19]._info = 95;
		wi[19]._mesh = 19;
		wi[19]._kind = 0;
		wi[19]._jadecost = 70;

		//sword(duel)
		wi[20]._power = 135;
		wi[20]._speed = 7.1f;
		wi[20]._name = 75;
		wi[20]._info = 96;
		wi[20]._mesh = 20;
		wi[20]._kind = 1;
		wi[20]._jadecost = 115;

		//sword(spear)
		wi[21]._power = 135;
		wi[21]._speed = 7.5f;
		wi[21]._name = 76;
		wi[21]._info = 97;
		wi[21]._mesh = 21;
		wi[21]._kind = 2;
		wi[21]._jadecost = 115;

		//sword
		wi[22]._power = 220;
		wi[22]._speed = 7.8f;
		wi[22]._name = 77;
		wi[22]._info = 98;
		wi[22]._mesh = 22;
		wi[22]._kind = 0;
		wi[22]._jadecost = 100;

		//sword(duel)
		wi[23]._power = 220;
		wi[23]._speed = 8.1f;
		wi[23]._name = 78;
		wi[23]._info = 99;
		wi[23]._mesh = 23;
		wi[23]._kind = 1;
		wi[23]._jadecost = 230;

		//sword(spear)
		wi[24]._power = 220;
		wi[24]._speed = 8.5f;
		wi[24]._name = 79;
		wi[24]._info = 100;
		wi[24]._mesh = 24;
		wi[24]._kind = 2;
		wi[24]._jadecost = 230;

		//sword
		wi[25]._power = 280;
		wi[25]._speed = 9.5f;
		wi[25]._name = 80;
		wi[25]._info = 101;
		wi[25]._mesh = 25;
		wi[25]._kind = 0;
		wi[25]._jadecost = 200;
	}
}
