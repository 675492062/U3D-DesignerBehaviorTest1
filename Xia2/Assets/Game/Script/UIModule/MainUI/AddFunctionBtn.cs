using UnityEngine;
using System.Collections;

public class AddFunctionBtn : MonoBehaviour {

	public UIGrid H_Grid;
	public UIGrid V_Grid;
	public UIButton FunctionBtn;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	public void addHBtn()
	{
		if(null == FunctionBtn || null == H_Grid)
		{
			Debug.LogError("loss refrence!");
			return;
		}
		UIButton btn = Instantiate(FunctionBtn) as UIButton;
		btn.transform.parent = H_Grid.transform;
		btn.transform.localScale = Vector3.one;
		btn.transform.localPosition = Vector3.zero;
		H_Grid.Reposition();
	}
	public void addVBtn()
	{
		if(null == FunctionBtn || null == V_Grid)
		{
			Debug.LogError("loss refrence!");
			return;
		}
		UIButton btn = Instantiate(FunctionBtn) as UIButton;
		btn.transform.parent = V_Grid.transform;
		btn.transform.localScale = Vector3.one;
		btn.transform.localPosition = Vector3.zero;
		V_Grid.Reposition();
	}
}
