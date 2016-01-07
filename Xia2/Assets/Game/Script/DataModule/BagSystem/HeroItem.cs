/****************************************************************************** 
 * 
 * Maintaince Logs: 
 * 2014-10-20   WP      Initial version
 * 
 * *****************************************************************************/

using UnityEngine;
using System.Collections;

public class HeroItem : BaseItem
{
    public HeroItem(int id) { templateID = id; }

    private StaticHero datas { get { return StaticHero.Instance(); } }

    public string icon1 { get { return datas.getStr(templateID, "icon1"); } }

    public int hero_type { get { return datas.getInt(templateID, "hero_type"); } }

    public int type { get { return datas.getInt(templateID, "type"); } }
    public string name { get { return datas.getStr(templateID, "name"); } }
    public string resname { get { return datas.getStr(templateID, "resname"); } }

    public int force { get { return datas.getInt(templateID, "force"); } }

    public int itemid { get { return datas.getInt(templateID, "itemid"); } }

    public int itemnum { get { return datas.getInt(templateID, "itemnum"); } }

    public int changeitemnum { get { return datas.getInt(templateID, "changeitemnum"); } }

    public int init_star { get { return datas.getInt(templateID, "init_star"); } }

    private static HeroItem mInstance;
    public static HeroItem GetData(int templateId)
    {
        if (mInstance == null) mInstance = new HeroItem(templateId);
        else mInstance.templateID = templateId;
        return mInstance;
    }
    //TODO 未添加完
}
