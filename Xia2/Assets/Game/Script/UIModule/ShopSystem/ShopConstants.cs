using UnityEngine;
using System.Collections;

public class ShopConstants {
	public struct BuyDialog{
		public const string Price_Gold_SpritName = "ui_mon_yinliang";						//银两 
		
		public const string Price_Jewel_SpritName = "ui_mon_yuanbao";						//元宝
		
		public const string Price_Arean_SpriteName = "ui_mon_warfar";									//竞技币
	}
	
	public static string PriceIcon(int type){
		if(type == (int)PriceType.Gold){
			return BuyDialog.Price_Gold_SpritName;
		}
		else if(type == (int)PriceType.Jewel)
		{
			return BuyDialog.Price_Jewel_SpritName;
		}
		else if(type == (int)PriceType.Arean )
		{
			return BuyDialog.Price_Arean_SpriteName;
		}
		Debug.LogError("[ShopConstants] PriceIcon : cannot find the price icon which type is " + type);
		return null;
	}
}