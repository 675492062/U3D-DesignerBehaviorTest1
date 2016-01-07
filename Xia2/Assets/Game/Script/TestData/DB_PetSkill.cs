using UnityEngine;
using System.Collections;

public  struct petset
{
	public short _grade;
	public short _info;
	public short _attackpoint;
	public short _price;
	public short _passive;
	public float _duration;
}

public class DB_PetSkill : MonoBehaviour {
	

	public petset[,] ps = new petset[2,10];
	
	// Use this for initialization
	void Awake()
	{
		//1.horse
		ps[0,0]._attackpoint = 100;
		ps[0,0]._duration = 8;
		ps[0,0]._grade = 0;
		ps[0,0]._price = 2;
		ps[0,0]._info = 69;
		ps[0,0]._passive = 0;

		ps[0,1]._attackpoint = 110;
		ps[0,1]._duration = 9;
		ps[0,1]._grade = 1;
		ps[0,1]._price = 2;
		ps[0,1]._info = 0;
		ps[0,1]._passive = 10;

		ps[0,2]._attackpoint = 120;
		ps[0,2]._duration = 10;
		ps[0,2]._grade = 2;
		ps[0,2]._price = 2;
		ps[0,2]._info = 275;
		ps[0,2]._passive = 20;

		ps[0,3]._attackpoint = 130;
		ps[0,3]._duration = 11;
		ps[0,3]._grade = 3;
		ps[0,3]._price = 2;
		ps[0,3]._info = 277;
		ps[0,3]._passive = 30;

		ps[0,4]._attackpoint = 140;
		ps[0,4]._duration = 12;
		ps[0,4]._grade = 4;
		ps[0,4]._price = 2;
		ps[0,4]._info = 0;
		ps[0,4]._passive = 40;

		ps[0,5]._attackpoint = 150;
		ps[0,5]._duration = 13;
		ps[0,5]._grade = 5;
		ps[0,5]._price = 2;
		ps[0,5]._info = 0;
		ps[0,5]._passive = 50;

		ps[0,6]._attackpoint = 160;
		ps[0,6]._duration = 14;
		ps[0,6]._grade = 6;
		ps[0,6]._price = 2;
		ps[0,6]._info = 0;
		ps[0,6]._passive = 60;

		ps[0,7]._attackpoint = 170;
		ps[0,7]._duration = 15;
		ps[0,7]._grade = 7;
		ps[0,7]._price = 2;
		ps[0,7]._info = 0;
		ps[0,7]._passive = 70;

		ps[0,8]._attackpoint = 180;
		ps[0,8]._duration = 16;
		ps[0,8]._grade = 8;
		ps[0,8]._price = 2;
		ps[0,8]._info = 0;
		ps[0,8]._passive = 80;

		ps[0,9]._attackpoint = 190;
		ps[0,9]._duration = 17;
		ps[0,9]._grade = 9;
		ps[0,9]._price = 2;
		ps[0,9]._info = 0;
		ps[0,9]._passive = 90;


		//2.eagle
		ps[1,0]._attackpoint = 40;
		ps[1,0]._duration = 7;
		ps[1,0]._grade = 0;
		ps[1,0]._price = 2;
		ps[1,0]._info = 70;
		ps[1,0]._passive = 0;

		ps[1,1]._attackpoint = 45;
		ps[1,1]._duration = 8;
		ps[1,1]._grade = 1;
		ps[1,1]._price = 2;
		ps[1,1]._info = 0;
		ps[1,1]._passive = 10;

		ps[1,2]._attackpoint = 50;
		ps[1,2]._duration = 9;
		ps[1,2]._grade = 2;
		ps[1,2]._price = 2;
		ps[1,2]._info = 276;
		ps[1,2]._passive = 20;

		ps[1,3]._attackpoint = 55;
		ps[1,3]._duration = 10;
		ps[1,3]._grade = 3;
		ps[1,3]._price = 2;
		ps[1,3]._info = 278;
		ps[1,3]._passive = 30;

		ps[1,4]._attackpoint = 60;
		ps[1,4]._duration = 11;
		ps[1,4]._grade = 4;
		ps[1,4]._price = 2;
		ps[1,4]._info = 0;
		ps[1,4]._passive = 40;

		ps[1,5]._attackpoint = 65;
		ps[1,5]._duration = 12;
		ps[1,5]._grade = 5;
		ps[1,5]._price = 2;
		ps[1,5]._info = 0;
		ps[1,5]._passive = 50;

		ps[1,6]._attackpoint = 70;
		ps[1,6]._duration = 13;
		ps[1,6]._grade = 6;
		ps[1,6]._price = 2;
		ps[1,6]._info = 0;
		ps[1,6]._passive = 60;

		ps[1,7]._attackpoint = 75;
		ps[1,7]._duration = 14;
		ps[1,7]._grade = 7;
		ps[1,7]._price = 2;
		ps[1,7]._info = 0;
		ps[1,7]._passive = 70;

		ps[1,8]._attackpoint = 80;
		ps[1,8]._duration = 15;
		ps[1,8]._grade = 8;
		ps[1,8]._price = 2;
		ps[1,8]._info = 0;
		ps[1,8]._passive = 80;

		ps[1,9]._attackpoint = 85;
		ps[1,9]._duration = 16;
		ps[1,9]._grade = 9;
		ps[1,9]._price = 2;
		ps[1,9]._info = 0;
		ps[1,9]._passive = 90;
	}
}
