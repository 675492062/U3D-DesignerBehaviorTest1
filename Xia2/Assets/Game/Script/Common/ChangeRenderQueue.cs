using UnityEngine;
using System.Collections;

public class ChangeRenderQueue : MonoBehaviour {

	void Awake()
	{
		setRenderQueue(4000);
	}
	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	public void setRenderQueue(int num)
	{
		Renderer[] matr = GetComponentsInChildren<Renderer>();
		for(int i = 0; i < matr.Length; i++)
		{
            if (matr[i].sharedMaterial == null)
            {
                Debug.Log("mat is null -----", matr[i]);
                break;
            }
			matr[i].sharedMaterial.renderQueue = num;
		}
	}
}
