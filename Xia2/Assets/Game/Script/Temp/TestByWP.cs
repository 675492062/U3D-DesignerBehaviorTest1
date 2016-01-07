
#if UNITY_EDITOR
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using UnityEditor;


//[ExecuteInEditMode]
public class TestByWP : MonoBehaviour
{
    float time = 0;


    //void Start() { StartCoroutine(BeginTim()); }
    void KMDebug()
    {
       

    }

    private IEnumerator BeginTim()
    {
        while (time <= 10)
        {
            time += Time.deltaTime;
            Debug.Log("time : " + time + " Time.time" + Time.time); 
            yield return null;
        }

    }

    void KMEditor()
    {
        Debug.Log("Vector3.Angle " + Vector3.Angle(Vector3.forward, Vector3.forward));
    }


}

#endif