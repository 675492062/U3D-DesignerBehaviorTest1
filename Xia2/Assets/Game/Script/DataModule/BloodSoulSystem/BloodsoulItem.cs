using UnityEngine;
using System.Collections;

public class BloodsoulItem
{
	public BloodsoulItem() {}
	/// 等级
	public int level{get;private set;}
	/// 升到下一级所需经验
	public int exp{get;private set;}
	/// 印记栏位数
	public int markbox{get;private set;}
	/// 附加生命值
	public int hp{get;private set;}
	/// 附加攻击力
	public int attack{get;private set;}
	/// 附加防御
	public int armor{get;private set;}
	/// 附加爆击等级
	public int criticallv{get;private set;}
	/// 附加命中等级
	public int hitlv{get;private set;}
	/// 附加闪避等级
	public int dodgelv{get;private set;}
	/// 附加韧性等级
	public int tenacitylv{get;private set;}
	/// 附加该等级生命槽上限
	public int hpmax{get;private set;}
	/// 附加该等级攻击槽上限
	public int attackmax{get;private set;}
	/// 附加该等级防御槽上限
	public int armormax{get;private set;}
	/// 附加该等级爆击等级槽上限
	public int criticallvmax{get;private set;}
	/// 附加该等级命中等级槽上限
	public int hitlvmax{get;private set;}
	/// 附加该等级闪避等级槽上限
	public int dodgelvmax{get;private set;}
	/// 附加该等级韧性等级槽上限
	public int tenacitylvmax{get;private set;}


	public void parseData(int nLvl)
	{
		StaticBloodsoul datas = StaticBloodsoul.Instance();
		int templateID = nLvl;

		exp = datas.getInt(templateID, "exp");
		markbox = datas.getInt(templateID, "markbox");
		// extra property
		hp = datas.getInt(templateID, "hp");
		attack = datas.getInt(templateID, "attack");
		armor = datas.getInt(templateID, "armor");
		criticallv = datas.getInt(templateID, "criticallv");
		hitlv = datas.getInt(templateID, "hitlv");
		dodgelv = datas.getInt(templateID, "dodgelv");
		tenacitylv = datas.getInt(templateID, "tenacitylv");
		hpmax = datas.getInt(templateID, "hpmax");
		attackmax = datas.getInt(templateID, "attackmax");
		armormax = datas.getInt(templateID, "armormax");
		criticallvmax = datas.getInt(templateID, "criticallvmax");
		hitlvmax = datas.getInt(templateID, "hitlvmax");
		dodgelvmax = datas.getInt(templateID, "dodgelvmax");
		tenacitylvmax = datas.getInt(templateID, "tenacitylvmax");
	}
}
