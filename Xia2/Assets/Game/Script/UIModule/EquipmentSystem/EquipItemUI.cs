using UnityEngine;
using System.Collections;

public class EquipItemUI : MonoBehaviour {

    public UISprite             Icon;   
	public UILabel              Name;
	public UILabel              EquipType;
	public UILabel              EquipSubType;
	public UILabel              EquipPinzhi;
	public UILabel              EquipNeedLevel;
	public UISprite []          Star;
	public UILabel              Damage;
	public UILabel []           PropertyNum;
	public UILabel []           PropertyName;
	public UILabel              DamasceneAward;
	public UISprite []          Damond;
	public UILabel[]            DamondName;
	public UILabel              LegendProperty;
    public Color[]              color;
	public UILabel              Price;
    public UIButton             m_close;
    public UISprite             m_equipSprite;

    private int[]               attributeList; 

	public int type{get; set;}
	// Use this for initialization
	void Start () 
	{
		type = (int)GlobalDef.EquipStateType.EQUIP_ONDRESS;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	public void UpdateInfo(EquipmentItem item)
	{
        if (item == null)
        {
           gameObject.SetActive(false);
           return;
        }      

        Icon.spriteName = item.icon;
		Name.text = item.name;
		EquipType.text = item.getItemType();
		EquipPinzhi.text = item.getItemQuality();
		EquipSubType.text = item.getRoleLimit();
		EquipNeedLevel.text = "需要等级Lv." + item.needlv;
		if(MonoInstancePool.getInstance<HeroManager>().getCurShowHero().level >= item.needlv)
		{
			Color c = EquipNeedLevel.color;
			c.r = 0f; c.g = 1f; c.b = 0f;
			EquipNeedLevel.color = c;
		}
		Price.text = "" + item.sellprice1;


        Damage.text = item.mindamage + "-" + item.maxdamage +"伤害";
      
        if (item.changeStar != 0)
            setStarNum(item.changeStar);
        else
		    setStarNum(0);
        
		attributeList = new int[] { item.gattribute, item.base_attribute_int, item.base_attribute_int };

        setAttributeid(item);
        setDamond(item);

        LegendProperty.text = item.description;
	}
	void setStarNum(int star)
	{
		if(star > Star.Length)
		{
			return;
		}
		for(int i = 0; i < Star.Length; i++)
		{
			Star[i].gameObject.SetActive(false);
		}
		for(int i = 0; i < star; i++)
		{
			Star[i].gameObject.SetActive(true);
		}
	}

    void setAttributeid(EquipmentItem item)
    {
        if (item == null)
        {
            for (int i = 0; i < PropertyNum.Length; i++)
            {
                PropertyNum[i].transform.parent.gameObject.SetActive(false);
            }
            return;
        }

        for (int i = 0; i < item.changeStar; i++)
        {
            PropertyNum[i].text = attributeList[i].ToString();
            PropertyName[i].text = item.getAttriButeidName(i);

            PropertyNum[i].transform.parent.gameObject.SetActive(true);
           
            for (int j = i+1; j < PropertyNum.Length; j++)
            {
                PropertyNum[j].transform.parent.gameObject.SetActive(false);
            }
        }    
    }

    void setDamond(EquipmentItem item)
    {
        if (item == null)
        {
            for (int i = 0; i < Damond.Length; i++)
            {
               Damond[i].transform.parent.gameObject.SetActive(false);
            }
            return;
        }

        if (item.gholestar1 >= item.changeStar )
        {
            //Damond[0].spriteName = item.gholecolor1.ToString();
            Damond[0].spriteName = "hb_60";
            DamondName[0].text = "未镶嵌宝石";
            DamondName[0].color = color[0];
        }
        if (item.gholestar2 >= item.changeStar )
        {
            //Damond[1].spriteName = item.gholecolor2.ToString();
            Damond[1].spriteName = "hb_60";
            DamondName[1].text = "未镶嵌宝石";
            DamondName[1].color = color[0];
            
        }
        
        DamasceneAward.text = item.gattribute.ToString() 
                                + item.getAttriButeidName(item.gattributeid);
    }
}
