using UnityEngine;
using System.Collections;

//using System; 
//using System.Data; 
//using System.Data.Odbc; 

public  struct monster
{
	public short _level;
	public short _maxhp;
	public short _power;
	public short _haveExp;
	public short _block;
	public short _sizekind;

	public float _runspeed;
	public float _backspeed;
	public float _firerange;
	public float _moving_atk;

	public bool _attach_ef;
	public short _dash;
	
	public float _speed_move;
	public float _speed_m_attack1;
	public float _speed_m_attack1_i;

	public float _speed_idle;
	public short _kind;
}

public class DB_Monster : MonoBehaviour {
	
	
	const int MAXMON = 16;
	
	public monster[] enemy = new monster[MAXMON];
	
	/*void Awake ()
	{
		readXLS(Application.dataPath + "/Book1.xls");
	}
	
	void readXLS( string filetoread)
	{
		// Must be saved as excel 2003 workbook, not 2007, mono issue really
		string con = "Driver={Microsoft Excel Driver (*.xls)}; DriverId=790; Dbq="+filetoread+";";
		Debug.Log(con);
		string yourQuery = "SELECT * FROM [Sheet1$]"; 
		// our odbc connector 
		OdbcConnection oCon = new OdbcConnection(con); 
		// our command object 
		OdbcCommand oCmd = new OdbcCommand(yourQuery, oCon);
		// table to hold the data 
		DataTable dtYourData = new DataTable("YourData"); 
		// open the connection 
		oCon.Open(); 
		// lets use a datareader to fill that table! 
		OdbcDataReader rData = oCmd.ExecuteReader(); 
		// now lets blast that into the table by sheer man power! 
		dtYourData.Load(rData); 
		// close that reader! 
		rData.Close(); 
		// close your connection to the spreadsheet! 
		oCon.Close(); 
		
		for (int i = 0 ; i<dtYourData.Rows.Count; ++i)
		{
			enemy[i]._level = dtYourData.Rows[i+1][dtYourData.Columns[1].ColumnName].ToString();
			enemy[i]._maxhp = dtYourData.Rows[i+1][dtYourData.Columns[2].ColumnName].ToString();
			enemy[i]._power = dtYourData.Rows[i+1][dtYourData.Columns[3].ColumnName].ToString();
			enemy[i]._haveExp = dtYourData.Rows[i+1][dtYourData.Columns[4].ColumnName].ToString();
			enemy[i]._block = dtYourData.Rows[i+1][dtYourData.Columns[5].ColumnName].ToString();
		
			enemy[i]._firerange = dtYourData.Rows[i+1][dtYourData.Columns[6].ColumnName].ToString();
			enemy[i]._runspeed = dtYourData.Rows[i+1][dtYourData.Columns[7].ColumnName].ToString();
			enemy[i]._backspeed = dtYourData.Rows[i+1][dtYourData.Columns[8].ColumnName].ToString();
			enemy[i]._dash = dtYourData.Rows[i+1][dtYourData.Columns[9].ColumnName].ToString();
			enemy[i]._moving_atk = dtYourData.Rows[i+1][dtYourData.Columns[10].ColumnName].ToString();
			enemy[i]._attach_ef = dtYourData.Rows[i+1][dtYourData.Columns[11].ColumnName].ToString();
			
			
			enemy[i]._speed_move = dtYourData.Rows[i+1][dtYourData.Columns[12].ColumnName].ToString();
			enemy[i]._speed_m_attack1 = dtYourData.Rows[i+1][dtYourData.Columns[13].ColumnName].ToString();
			enemy[i]._speed_m_attack1_i = dtYourData.Rows[i+1][dtYourData.Columns[14].ColumnName].ToString();
			enemy[i]._speed_idle = dtYourData.Rows[i+1][dtYourData.Columns[15].ColumnName].ToString();
			
			enemy[i]._sizekind = dtYourData.Rows[i+1][dtYourData.Columns[16].ColumnName].ToString();
			enemy[i]._kind = dtYourData.Rows[i+1][dtYourData.Columns[17].ColumnName].ToString();
		}
	}*/
	
	void Awake()
	{
		//~~~dagger
		enemy[0]._level = 1;          //等级
		enemy[0]._maxhp = 20;         //最大血量
		enemy[0]._power = 15;         //攻击
		enemy[0]._haveExp = 1;        //携带的经验
		enemy[0]._block = 0;          //防御
		enemy[0]._firerange = 0.24f;
		enemy[0]._runspeed = 0.3f;    //奔跑速度
		enemy[0]._backspeed = -0.05f; //后退速度
		enemy[0]._dash = 0;           
		enemy[0]._moving_atk = 0.3f;
		enemy[0]._attach_ef = false;
		enemy[0]._speed_move = 0.34f; //移动速度
		enemy[0]._speed_m_attack1 = 0.4f;  //攻击速度
		enemy[0]._speed_m_attack1_i = 0.4f;//攻击速度
		enemy[0]._speed_idle = 0.3f;  //待机速度
		enemy[0]._sizekind = 10;      
		enemy[0]._kind = 2;           //种类

		//spear
		enemy[1]._level = 1;
		enemy[1]._maxhp = 20;
		enemy[1]._power = 15;
		enemy[1]._haveExp = 1;
		enemy[1]._block = 4;
		enemy[1]._firerange = 0.24f;
		enemy[1]._runspeed = 0.3f;
		enemy[1]._backspeed = -0.05f;
		enemy[1]._dash = 0;
		enemy[1]._moving_atk = 0.2f;
		enemy[1]._attach_ef = false;
		enemy[1]._speed_move = 0.34f;
		enemy[1]._speed_m_attack1 = 0.4f;
		enemy[1]._speed_m_attack1_i = 0.4f;
		enemy[1]._speed_idle = 0.3f;
		enemy[1]._sizekind = 10;
		enemy[1]._kind = 2;

		//bow
		enemy[2]._level = 1;
		enemy[2]._maxhp = 20;
		enemy[2]._power = 10;
		enemy[2]._haveExp = 1;
		enemy[2]._block = 1;
		enemy[2]._firerange = 0.5f;
		enemy[2]._runspeed = 0.2f;
		enemy[2]._backspeed = -0.05f;
		enemy[2]._dash = 0;
		enemy[2]._moving_atk = 0;
		enemy[2]._attach_ef = false;
		enemy[2]._speed_move = 0.3f;
		enemy[2]._speed_m_attack1 = 0.3f;
		enemy[2]._speed_m_attack1_i = 0.4f;
		enemy[2]._speed_idle = 0.3f;
		enemy[2]._sizekind = 10;
		enemy[2]._kind = 2;

		//hammer
		enemy[3]._level = 1;
		enemy[3]._maxhp = 25;
		enemy[3]._power = 15;
		enemy[3]._haveExp = 2;
		enemy[3]._block = 2;
		enemy[3]._firerange = 0.3f;
		enemy[3]._runspeed = 0.3f;
		enemy[3]._backspeed = -0.06f;
		enemy[3]._dash = 0;
		enemy[3]._moving_atk = 0;
		enemy[3]._attach_ef = false;
		enemy[3]._speed_move = 0.3f;
		enemy[3]._speed_m_attack1 = 0.3f;
		enemy[3]._speed_m_attack1_i = 0.4f;
		enemy[3]._speed_idle = 0.3f;
		enemy[3]._sizekind = 20;
		enemy[3]._kind = 2;

		//sword
		enemy[4]._level = 1;
		enemy[4]._maxhp = 20;
		enemy[4]._power = 15;
		enemy[4]._haveExp = 2;
		enemy[4]._block = 3;
		enemy[4]._firerange = 0.3f;
		enemy[4]._runspeed = 0.4f;
		enemy[4]._backspeed = -0.05f;
		enemy[4]._dash = 0;
		enemy[4]._moving_atk = 0.5f;
		enemy[4]._attach_ef = false;
		enemy[4]._speed_move = 0.42f;
		enemy[4]._speed_m_attack1 = 0.25f;
		enemy[4]._speed_m_attack1_i = 0.4f;
		enemy[4]._speed_idle = 0.3f;
		enemy[4]._sizekind = 10;
		enemy[4]._kind = 2;

		//fireball
		enemy[5]._level = 1;
		enemy[5]._maxhp = 40;
		enemy[5]._power = 15;
		enemy[5]._haveExp = 2;
		enemy[5]._block = 1;
		enemy[5]._firerange = 0.5f;
		enemy[5]._runspeed = 0.2f;
		enemy[5]._backspeed = -0.05f;
		enemy[5]._dash = 0;
		enemy[5]._moving_atk = 0;
		enemy[5]._attach_ef = false;
		enemy[5]._speed_move = 0.3f;
		enemy[5]._speed_m_attack1 = 0.3f;
		enemy[5]._speed_m_attack1_i = 0.1f;
		enemy[5]._speed_idle = 0.3f;
		enemy[5]._sizekind = 10;
		enemy[5]._kind = 2;

		//twinaxe
		enemy[6]._level = 1;
		enemy[6]._maxhp = 45;
		enemy[6]._power = 15;
		enemy[6]._haveExp = 2;
		enemy[6]._block = 2;
		enemy[6]._firerange = 0.5f;
		enemy[6]._runspeed = 0.3f;
		enemy[6]._backspeed = -0.06f;
		enemy[6]._dash = 0;
		enemy[6]._moving_atk = 0.6f;
		enemy[6]._attach_ef = true;
		enemy[6]._speed_move = 0.3f;
		enemy[6]._speed_m_attack1 = 0.2f;
		enemy[6]._speed_m_attack1_i = 0.25f;
		enemy[6]._speed_idle = 0.3f;
		enemy[6]._sizekind = 20;
		enemy[6]._kind = 2;

		//armor
		enemy[7]._level = 1;
		enemy[7]._maxhp = 60;
		enemy[7]._power = 15;
		enemy[7]._haveExp = 2;
		enemy[7]._block = 10;
		enemy[7]._firerange = 0.5f;
		enemy[7]._runspeed = 0.3f;
		enemy[7]._backspeed = -0.06f;
		enemy[7]._dash = 0;
		enemy[7]._moving_atk = 0.6f;
		enemy[7]._attach_ef = false;
		enemy[7]._speed_move = 0.3f;
		enemy[7]._speed_m_attack1 = 0.3f;
		enemy[7]._speed_m_attack1_i = 0.2f;
		enemy[7]._speed_idle = 0.3f;
		enemy[7]._sizekind = 20;
		enemy[7]._kind = 2;

		//wolf
		enemy[8]._level = 1;
		enemy[8]._maxhp = 15;
		enemy[8]._power = 15;
		enemy[8]._haveExp = 2;
		enemy[8]._block = 2;
		enemy[8]._firerange = 0.4f;
		enemy[8]._runspeed = 0.5f;
		enemy[8]._backspeed = -0.05f;
		enemy[8]._dash = 80;
		enemy[8]._moving_atk = 0.1f;
		enemy[8]._attach_ef = true;
		enemy[8]._speed_move = 0.6f;
		enemy[8]._speed_m_attack1 = 0.3f;
		enemy[8]._speed_m_attack1_i = 0.34f;
		enemy[8]._speed_idle = 0.4f;
		enemy[8]._sizekind = 10;
		enemy[8]._kind = 1;

		//beast
		enemy[9]._level = 1;
		enemy[9]._maxhp = 60;
		enemy[9]._power = 30;
		enemy[9]._haveExp = 3;
		enemy[9]._block = 4;
		enemy[9]._firerange = 0.4f;
		enemy[9]._runspeed = 0.5f;
		enemy[9]._backspeed = -0.05f;
		enemy[9]._dash = 100;
		enemy[9]._moving_atk = 0;
		enemy[9]._attach_ef = true;
		enemy[9]._speed_move = 0.44f;
		enemy[9]._speed_m_attack1 = 0.3f;
		enemy[9]._speed_m_attack1_i = 0.3f;
		enemy[9]._speed_idle = 0.3f;
		enemy[9]._sizekind = 24;
		enemy[9]._kind = 1;

		//raptile
		enemy[10]._level = 1;
		enemy[10]._maxhp = 60;
		enemy[10]._power = 30;
		enemy[10]._haveExp = 3;
		enemy[10]._block = 4;
		enemy[10]._firerange = 0.24f;
		enemy[10]._runspeed = 0.3f;
		enemy[10]._backspeed = -0.05f;
		enemy[10]._dash = 0;
		enemy[10]._moving_atk = 0;
		enemy[10]._attach_ef = false;
		enemy[10]._speed_move = 0.5f;
		enemy[10]._speed_m_attack1 = 0.4f;
		enemy[10]._speed_m_attack1_i = 0.4f;
		enemy[10]._speed_idle = 0.3f;
		enemy[10]._sizekind = 10;
		enemy[10]._kind = 1;

		//tonado
		enemy[11]._level = 1;
		enemy[11]._maxhp = 50;
		enemy[11]._power = 25;
		enemy[11]._haveExp = 2;
		enemy[11]._block = 5;
		enemy[11]._firerange = 0.6f;
		enemy[11]._runspeed = 0.3f;
		enemy[11]._backspeed = -0.06f;
		enemy[11]._dash = 0;
		enemy[11]._moving_atk = 0;
		enemy[11]._attach_ef = true;
		enemy[11]._speed_move = 0.3f;
		enemy[11]._speed_m_attack1 = 0.25f;
		enemy[11]._speed_m_attack1_i = 0.25f;
		enemy[11]._speed_idle = 0.3f;
		enemy[11]._sizekind = 20;
		enemy[11]._kind = 2;

		//greataxe
		enemy[12]._level = 1;
		enemy[12]._maxhp = 50;
		enemy[12]._power = 20;
		enemy[12]._haveExp = 3;
		enemy[12]._block = 5;
		enemy[12]._firerange = 0.7f;
		enemy[12]._runspeed = 0.3f;
		enemy[12]._backspeed = -0.06f;
		enemy[12]._dash = 0;
		enemy[12]._moving_atk = 0;
		enemy[12]._attach_ef = false;
		enemy[12]._speed_move = 0.3f;
		enemy[12]._speed_m_attack1 = 0.3f;
		enemy[12]._speed_m_attack1_i = 0.4f;
		enemy[12]._speed_idle = 0.3f;
		enemy[12]._sizekind = 20;
		enemy[12]._kind = 2;

		//lightning
		enemy[13]._level = 1;
		enemy[13]._maxhp = 50;
		enemy[13]._power = 25;
		enemy[13]._haveExp = 2;
		enemy[13]._block = 4;
		enemy[13]._firerange = 0.5f;
		enemy[13]._runspeed = 0.2f;
		enemy[13]._backspeed = -0.05f;
		enemy[13]._dash = 0;
		enemy[13]._moving_atk = 0;
		enemy[13]._attach_ef = false;
		enemy[13]._speed_move = 0.3f;
		enemy[13]._speed_m_attack1 = 0.3f;
		enemy[13]._speed_m_attack1_i = 0.4f;
		enemy[13]._speed_idle = 0.3f;
		enemy[13]._sizekind = 10;
		enemy[13]._kind = 2;

		//crossbow
		enemy[14]._level = 1;
		enemy[14]._maxhp = 30;
		enemy[14]._power = 20;
		enemy[14]._haveExp = 3;
		enemy[14]._block = 4;
		enemy[14]._firerange = 0.5f;
		enemy[14]._runspeed = 0.2f;
		enemy[14]._backspeed = -0.05f;
		enemy[14]._dash = 0;
		enemy[14]._moving_atk = 0;
		enemy[14]._attach_ef = false;
		enemy[14]._speed_move = 0.3f;
		enemy[14]._speed_m_attack1 = 0.3f;
		enemy[14]._speed_m_attack1_i = 0.4f;
		enemy[14]._speed_idle = 0.3f;
		enemy[14]._sizekind = 10;
		enemy[14]._kind = 2;

		//???
		enemy[15]._level = 1;
		enemy[15]._maxhp = 30;
		enemy[15]._power = 20;
		enemy[15]._haveExp = 2;
		enemy[15]._block = 4;
		enemy[15]._firerange = 0.5f;
		enemy[15]._runspeed = 0.3f;
		enemy[15]._backspeed = -0.05f;
		enemy[15]._dash = 0;
		enemy[15]._moving_atk = 0;
		enemy[15]._attach_ef = false;
		enemy[15]._speed_move = 0.3f;
		enemy[15]._speed_m_attack1 = 0.3f;
		enemy[15]._speed_m_attack1_i = 0.4f;
		enemy[15]._speed_idle = 0.3f;
		enemy[15]._sizekind = 10;
		enemy[15]._kind = 2;
	}
}
