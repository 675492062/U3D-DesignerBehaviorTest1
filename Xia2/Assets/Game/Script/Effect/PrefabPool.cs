using UnityEngine;
using System.Collections;

/// <summary>
/// 用于取Prefab的类 ，寄生于PrefabManager
/// 
/// Maintaince Logs: 
/// 2014-11-27  WP      Initial version: Added member
/// 
/// </summary>
public static class PrefabPool
{
    public static Transform prbGameSign
    { get { return PrefabManager.Instance().GetFx(AllStrings.NAME_SIGN_PREFAB, PrefabManager.enEfPathType.EF_OTHER); } }
    public static Transform prbParclose
    { get { return PrefabManager.Instance().GetFx(AllStrings.NAME_PARCLOSE_PREFAB, PrefabManager.enEfPathType.EF_OTHER); } }
    public static Transform prbUIEffComboC
    { get { return PrefabManager.Instance().GetFx(AllStrings.FILE_GUIFX_COMBO_C, PrefabManager.enEfPathType.EF_UI); } }
    public static Transform prbUIEffComboS
    {
        get
        {
            return PrefabManager.Instance().GetFx(AllStrings.FILE_GUIFX_COMBO_S, PrefabManager.enEfPathType.EF_UI);
        }
    }

    
    private const string PATH_ENEMIES = "Prefab/Monster";
    public static Transform GetMonster(string name)
    {
        return PrefabManager.Instance().GetPrefab(name, PATH_ENEMIES);
    }

}
