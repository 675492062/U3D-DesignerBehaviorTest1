/****************************************************************************** 
 * 
 * Maintaince Logs: 
 * 2014-10-15   WP      Initial version
 * 
 * *****************************************************************************/

using UnityEngine;
using System.Collections;

public class UIKeyNValue : MonoBehaviour
{

    public UILabel key;
    public UILabel value;

    void Awake()
    {
        if (key == null || value == null)
        {
            Debug.LogError("not setting ", gameObject);
            gameObject.SetActive(false);
        }
    }
}
