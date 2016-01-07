using UnityEngine;
using System.Collections;

public class MaterialItem : BaseItem {

    public MaterialItem()
	{
        
	}

    public MaterialItem(int id, int number = 0) { parseData(id, number); }


    public virtual void parseData(int id,int number = 0)
    {
        templateID = id;
        this.number = number;
    }

    public string icon { get { return StaticMaterial.Instance().getStr(templateID, "icon"); } }
    public int type { get { return StaticMaterial.Instance().getInt(templateID, "type"); } }
    public string name { get { return StaticMaterial.Instance().getStr(templateID, "name"); } }
    public int maxcount { get { return StaticMaterial.Instance().getInt(templateID, "maxcount"); } }
    public int sellmoney { get { return StaticMaterial.Instance().getInt(templateID, "sellmoney"); } }
    public int description { get { return StaticMaterial.Instance().getInt(templateID, "description"); } }

    public int number { get; set; }
}
