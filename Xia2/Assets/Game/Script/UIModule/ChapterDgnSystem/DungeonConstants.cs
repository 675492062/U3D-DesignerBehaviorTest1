using UnityEngine;
using System.Collections;

public struct ChapterConstants {

	//副本之间的路标sprite
	public struct Chapter{
		public const string Sign_White_SpriteName  = "routewhitesign";
		
		public const string Sign_Red_SpriteName = "routeredsign";
	}

	//副本图标中的解锁，未解锁等对应的sprite
	public struct Dungeont{
		public const string Lock_Bg_SpriteName = "do_05";
		
		public const string Normal_UnLocked_Bg_SpriteName = "do_02";
		
		public const string Normal_UnLocked_Icon_SpriteName = "do_02_1";
		
		public const string Normal_Locked_Icon_priteName = "do_05_1";
		
		
		public const string Boss_UnLocked_Bg_SpriteName = "do_04";
		 
		public const string Boss_UnLocked_Icon_SpriteName = "do_04_1";
		
		public const string Boss_Locked_Icon_SpriteName = "do_05_3";
		
		
		public const string Special_UnLock_Bg_SpriteName = "do_03";
		
		public const string Special_UnLocked_Icon_SpriteName = "do_03_1";
		
		public const string Special_Lock_Icon_SpriteName = "do_05_2";
		
		public const string Star_Light_SpriteName = "do_01_1";						//only is used in map
		
		public const string Star_Grey_SpriteName = "do_01_1_1";
		
		public const string Star_Poly_Light_SpriteName = "ui_sys_yingxiongxingxing";
		
		public const string Star_Poly_Grey_SpriteName = "ui_sys_gray_yingxiongxingxing-";
	}
	
	public struct RankConstants {
		
		public const string SPRITE_PHOTO_NAME_1 = "bs-13";
		
		public const string SPRITE_PHOTO_NAME_2 = "bs-14";
		
		public const string SPRITE_RANK_INDEX_1 = "do_16";
		
		public const string SPRITE_RANK_INDEX_2 = "do_17";
		
		public const string SPRITE_RANK_INDEX_3 = "do_18";	
		
		public const string SPRITE_BG_YELLOW = "do_13";
		
		public const string SPRITE_BG_BLUE = "do_14";
		
		public const string SPRITE_BG_RED = "do_15";
	}
	
	public struct RewardConstants{
		public const string SPRITE_BOX_CLOSED = "do_20";
		
		public const string SPRITE_BOX_HASKEY = "do_08";
		
		public const string SPRITE_BOX_OPEN = "do_21";
	}
}