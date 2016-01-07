using UnityEngine;
using System.Collections;

//副本基础数据，从配置表中读取的
public class DungeonItem : BaseItem{
	public enum DungeonType{
		Normal = 1 << 0,				//1
		Boss = 1 << 1,					//2
		Special_Gold = 1 << 2,			//4
		Special_Exp = 1 << 3,			//8
		Special_Stuff = 1 << 4,			//16		材料	
		Special_Jewel = 1 << 5,			//32
		Special_Holiday = 1 << 6		
	}
	
	public DungeonItem(int id){
		this.id = id;
	}
	
	public int id{
		get{
			return templateID;
		}
		set{
			templateID = value;
		}
	}
	
	public int belongId{							//隶属的章节id
		get{
			return StaticDungeon.Instance().getInt(templateID , "belong");
		}
	}
	
	public string name{
		get{
			return StaticDungeon.Instance().getStr(templateID , "name");
		}
	}
	
	public string txt{
		get{
			return StaticDungeon.Instance().getStr(templateID , "txt");
		}
	}
	
	public int energy{
		get{
			return StaticDungeon.Instance().getInt(templateID , "energy");
		}
	}
	
	public int baseType{
		get{
			return StaticDungeon.Instance().getInt(templateID , "type");
		}
	}
	
	public DungeonType type{
		get{
			return (DungeonType) (1 << (this.baseType - 1));
		}
	}
	
	public int linkedId{
		get{
			return StaticDungeon.Instance().getInt(templateID , "linkeddg");
		}
	}

    public string resname
    {
        get
        {
            return StaticDungeon.Instance().getStr(templateID, "resname");
        }
    }

}