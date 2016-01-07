/****************************************************************************** 
 * 
 * Maintaince Logs: 
 * 2014-10-18   WP      Initial version
 * 
 * *****************************************************************************/

using UnityEngine;
using System.Collections.Generic;

public class EquipSmeltItem : BaseItem
{
    public EquipSmeltItem(int id) { templateID = id;  }
    public void Init(int id) { templateID = id; }

    public string name { get { return StaticEquip_smelt.Instance().getStr(templateID, "name"); } }

    public int material1 { get { return StaticEquip_smelt.Instance().getInt(templateID, "material1"); } }
    public int material2 { get { return StaticEquip_smelt.Instance().getInt(templateID, "material2"); } }
    public int material3 { get { return StaticEquip_smelt.Instance().getInt(templateID, "material3"); } }
    public int material4 { get { return StaticEquip_smelt.Instance().getInt(templateID, "material4"); } }
    public int material5 { get { return StaticEquip_smelt.Instance().getInt(templateID, "material5"); } }

    private List<int> matIds = new List<int>();
    public List<int> GetMaterialIds()
    {
        if (matIds.Count < 1)
        {
            matIds.Add(material1);
            if (!matIds.Contains(material2)) matIds.Add(material2);
            if (!matIds.Contains(material3)) matIds.Add(material3);
            if (!matIds.Contains(material4)) matIds.Add(material4);
            if (!matIds.Contains(material5)) matIds.Add(material5);
        }

        return matIds;
    }

}
