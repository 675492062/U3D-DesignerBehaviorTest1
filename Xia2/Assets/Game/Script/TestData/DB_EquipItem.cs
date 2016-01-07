using UnityEngine;
using System.Collections;

public  struct equipitem
{
	public short _name;
	public short _grade;
	public short _capacity;
	public short _price;
}

public class DB_EquipItem : MonoBehaviour {
	

	public equipitem[,] ei = new equipitem[6,11];
	
	// Use this for initialization
	void Awake()
	{
		//1.accuracy
		ei[0,0]._name = 247;
		ei[0,0]._grade = 0;
		ei[0,0]._capacity = 1;
		ei[0,0]._price = 0;

		ei[0,1]._name = 247;
		ei[0,1]._grade = 1;
		ei[0,1]._capacity = 3;
		ei[0,1]._price = 100;

		ei[0,2]._name = 247;
		ei[0,2]._grade = 2;
		ei[0,2]._capacity = 7;
		ei[0,2]._price = 500;

		ei[0,3]._name = 247;
		ei[0,3]._grade = 3;
		ei[0,3]._capacity = 11;
		ei[0,3]._price = 1100;

		ei[0,4]._name = 247;
		ei[0,4]._grade = 4;
		ei[0,4]._capacity = 15;
		ei[0,4]._price = 1900;

		ei[0,5]._name = 247;
		ei[0,5]._grade = 5;
		ei[0,5]._capacity = 19;
		ei[0,5]._price = 2900;

		ei[0,6]._name = 247;
		ei[0,6]._grade = 6;
		ei[0,6]._capacity = 23;
		ei[0,6]._price = 4100;

		ei[0,7]._name = 247;
		ei[0,7]._grade = 7;
		ei[0,7]._capacity = 27;
		ei[0,7]._price = 5500;

		ei[0,8]._name = 247;
		ei[0,8]._grade = 8;
		ei[0,8]._capacity = 31;
		ei[0,8]._price = 7100;

		ei[0,9]._name = 247;
		ei[0,9]._grade = 9;
		ei[0,9]._capacity = 35;
		ei[0,9]._price = 8900;

		ei[0,10]._name = 247;
		ei[0,10]._grade = 10;
		ei[0,10]._capacity = 39;
		ei[0,10]._price = 10900;


		//3.indure
		ei[1,0]._name = 249;
		ei[1,0]._grade = 0;
		ei[1,0]._capacity = 1;
		ei[1,0]._price = 0;

		ei[1,1]._name = 249;
		ei[1,1]._grade = 1;
		ei[1,1]._capacity = 3;
		ei[1,1]._price = 100;

		ei[1,2]._name = 249;
		ei[1,2]._grade = 2;
		ei[1,2]._capacity = 7;
		ei[1,2]._price = 500;

		ei[1,3]._name = 249;
		ei[1,3]._grade = 3;
		ei[1,3]._capacity = 11;
		ei[1,3]._price = 1100;

		ei[1,4]._name = 249;
		ei[1,4]._grade = 4;
		ei[1,4]._capacity = 15;
		ei[1,4]._price = 1900;

		ei[1,5]._name = 249;
		ei[1,5]._grade = 5;
		ei[1,5]._capacity = 19;
		ei[1,5]._price = 2900;

		ei[1,6]._name = 249;
		ei[1,6]._grade = 6;
		ei[1,6]._capacity = 23;
		ei[1,6]._price = 4100;

		ei[1,7]._name = 249;
		ei[1,7]._grade = 7;
		ei[1,7]._capacity = 27;
		ei[1,7]._price = 5500;

		ei[1,8]._name = 249;
		ei[1,8]._grade = 8;
		ei[1,8]._capacity = 31;
		ei[1,8]._price = 7100;

		ei[1,9]._name = 249;
		ei[1,9]._grade = 9;
		ei[1,9]._capacity = 35;
		ei[1,9]._price = 8900;

		ei[1,10]._name = 249;
		ei[1,10]._grade = 10;
		ei[1,10]._capacity = 39;
		ei[1,10]._price = 10900;


		//4.critical
		ei[2,0]._name = 250;
		ei[2,0]._grade = 0;
		ei[2,0]._capacity = 5;
		ei[2,0]._price = 0;

		ei[2,1]._name = 250;
		ei[2,1]._grade = 1;
		ei[2,1]._capacity = 7;
		ei[2,1]._price = 100;

		ei[2,2]._name = 250;
		ei[2,2]._grade = 2;
		ei[2,2]._capacity = 11;
		ei[2,2]._price = 500;

		ei[2,3]._name = 250;
		ei[2,3]._grade = 3;
		ei[2,3]._capacity = 15;
		ei[2,3]._price = 1100;

		ei[2,4]._name = 250;
		ei[2,4]._grade = 4;
		ei[2,4]._capacity = 19;
		ei[2,4]._price = 1900;

		ei[2,5]._name = 250;
		ei[2,5]._grade = 5;
		ei[2,5]._capacity = 23;
		ei[2,5]._price = 2900;

		ei[2,6]._name = 250;
		ei[2,6]._grade = 6;
		ei[2,6]._capacity = 27;
		ei[2,6]._price = 4100;

		ei[2,7]._name = 250;
		ei[2,7]._grade = 7;
		ei[2,7]._capacity = 31;
		ei[2,7]._price = 5500;

		ei[2,8]._name = 250;
		ei[2,8]._grade = 8;
		ei[2,8]._capacity = 35;
		ei[2,8]._price = 7100;

		ei[2,9]._name = 250;
		ei[2,9]._grade = 9;
		ei[2,9]._capacity = 39;
		ei[2,9]._price = 8900;

		ei[2,10]._name = 250;
		ei[2,10]._grade = 10;
		ei[2,10]._capacity = 43;
		ei[2,10]._price = 10900;


		//5.evade
		ei[3,0]._name = 251;
		ei[3,0]._grade = 0;
		ei[3,0]._capacity = 1;
		ei[3,0]._price = 0;

		ei[3,1]._name = 251;
		ei[3,1]._grade = 1;
		ei[3,1]._capacity = 3;
		ei[3,1]._price = 100;

		ei[3,2]._name = 251;
		ei[3,2]._grade = 2;
		ei[3,2]._capacity = 7;
		ei[3,2]._price = 500;

		ei[3,3]._name = 251;
		ei[3,3]._grade = 3;
		ei[3,3]._capacity = 11;
		ei[3,3]._price = 1100;

		ei[3,4]._name = 251;
		ei[3,4]._grade = 4;
		ei[3,4]._capacity = 15;
		ei[3,4]._price = 1900;

		ei[3,5]._name = 251;
		ei[3,5]._grade = 5;
		ei[3,5]._capacity = 19;
		ei[3,5]._price = 2900;

		ei[3,6]._name = 251;
		ei[3,6]._grade = 6;
		ei[3,6]._capacity = 23;
		ei[3,6]._price = 4100;

		ei[3,7]._name = 251;
		ei[3,7]._grade = 7;
		ei[3,7]._capacity = 27;
		ei[3,7]._price = 5500;

		ei[3,8]._name = 251;
		ei[3,8]._grade = 8;
		ei[3,8]._capacity = 31;
		ei[3,8]._price = 7100;

		ei[3,9]._name = 251;
		ei[3,9]._grade = 9;
		ei[3,9]._capacity = 35;
		ei[3,9]._price = 8900;

		ei[3,10]._name = 251;
		ei[3,10]._grade = 10;
		ei[3,10]._capacity = 39;
		ei[3,10]._price = 10900;


		//2.hp
		ei[4,0]._name = 248;
		ei[4,0]._grade = 0;
		ei[4,0]._capacity = 0;
		ei[4,0]._price = 0;

		ei[4,1]._name = 248;
		ei[4,1]._grade = 1;
		ei[4,1]._capacity = 10;
		ei[4,1]._price = 100;

		ei[4,2]._name = 248;
		ei[4,2]._grade = 2;
		ei[4,2]._capacity = 20;
		ei[4,2]._price = 500;

		ei[4,3]._name = 248;
		ei[4,3]._grade = 3;
		ei[4,3]._capacity = 30;
		ei[4,3]._price = 1100;

		ei[4,4]._name = 248;
		ei[4,4]._grade = 4;
		ei[4,4]._capacity = 40;
		ei[4,4]._price = 1900;

		ei[4,5]._name = 248;
		ei[4,5]._grade = 5;
		ei[4,5]._capacity = 50;
		ei[4,5]._price = 2900;

		ei[4,6]._name = 248;
		ei[4,6]._grade = 6;
		ei[4,6]._capacity = 60;
		ei[4,6]._price = 4100;

		ei[4,7]._name = 248;
		ei[4,7]._grade = 7;
		ei[4,7]._capacity = 70;
		ei[4,7]._price = 5500;

		ei[4,8]._name = 248;
		ei[4,8]._grade = 8;
		ei[4,8]._capacity = 80;
		ei[4,8]._price = 7100;

		ei[4,9]._name = 248;
		ei[4,9]._grade = 9;
		ei[4,9]._capacity = 90;
		ei[4,9]._price = 8900;

		ei[4,10]._name = 248;
		ei[4,10]._grade = 10;
		ei[4,10]._capacity = 100;
		ei[4,10]._price = 10900;


		//6.max_sp
		ei[5,0]._name = 252;
		ei[5,0]._grade = 0;
		ei[5,0]._capacity = 100;
		ei[5,0]._price = 0;

		ei[5,1]._name = 252;
		ei[5,1]._grade = 1;
		ei[5,1]._capacity = 110;
		ei[5,1]._price = 100;

		ei[5,2]._name = 252;
		ei[5,2]._grade = 2;
		ei[5,2]._capacity = 130;
		ei[5,2]._price = 500;

		ei[5,3]._name = 252;
		ei[5,3]._grade = 3;
		ei[5,3]._capacity = 150;
		ei[5,3]._price = 1100;

		ei[5,4]._name = 252;
		ei[5,4]._grade = 4;
		ei[5,4]._capacity = 170;
		ei[5,4]._price = 1900;

		ei[5,5]._name = 252;
		ei[5,5]._grade = 5;
		ei[5,5]._capacity = 190;
		ei[5,5]._price = 2900;

		ei[5,6]._name = 252;
		ei[5,6]._grade = 6;
		ei[5,6]._capacity = 210;
		ei[5,6]._price = 4100;

		ei[5,7]._name = 252;
		ei[5,7]._grade = 7;
		ei[5,7]._capacity = 230;
		ei[5,7]._price = 5500;

		ei[5,8]._name = 252;
		ei[5,8]._grade = 8;
		ei[5,8]._capacity = 250;
		ei[5,8]._price = 7100;

		ei[5,9]._name = 252;
		ei[5,9]._grade = 9;
		ei[5,9]._capacity = 270;
		ei[5,9]._price = 8900;

		ei[5,10]._name = 252;
		ei[5,10]._grade = 10;
		ei[5,10]._capacity = 290;
		ei[5,10]._price = 10900;
	}

}
