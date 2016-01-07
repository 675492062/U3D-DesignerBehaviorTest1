/****************************************************************************** 
 * 
 * Maintaince Logs: 
 * 2014-10-29   WP      Initial version: Added member
 * 
 * *****************************************************************************/

using UnityEngine;
using System.Collections;

public class Ef_OddsPlay : MonoBehaviour
{

    public int oddsPlay = 80;

    void OnEnable()
    {
        if (GetComponent<Renderer>() == null)
        {
            //print("ren is null");
            return;
        }

        if ((Random.Range(1, 100) < (oddsPlay)))
        {
            //print("show");
            GetComponent<Renderer>().enabled = true;
        }
        else GetComponent<Renderer>().enabled = false;
    }
}
