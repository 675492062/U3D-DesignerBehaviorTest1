using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum ChapterAwardMoney{
	Silver,		//银两
	GoldIngots	// 元宝
}
public class AwaradItem{
	public int id;
	public int type;
	public int num;
	
	public AwaradItem(int id , int type , int num){
		this.id = id;
		this.type = type;
		this.num = num;
	}
}
//章节奖励
public class ChapterAwardItem : BaseItem {
	public int id{												//奖励id， 填写在章节表box1,box2中
		set{
			templateID = value;
		}
		get{
			return templateID;
		}
	}
	
	public List<AwaradItem> items;
		
	public ChapterAwardItem(int id){
		this.id = id;
		items = new List<AwaradItem>();
		ReadList();
	}
	
	public void ReadList(){
		for(int i = 1; i <= 10 ; i ++){
			string id1 = "itemid" + i;
			string id2 = "itemtype" + i;
			string id3 = "itemnum" + i;
			int itemId = StaticChapter_star.Instance().getInt(templateID , id1);
			int type = StaticChapter_star.Instance().getInt(templateID , id2);
			int num = StaticChapter_star.Instance().getInt(templateID , id3);
			if(itemId != 0 && num != 0){
				var item = new AwaradItem(itemId , type , num);
				items.Add(item);
			}
		}
	}	
}