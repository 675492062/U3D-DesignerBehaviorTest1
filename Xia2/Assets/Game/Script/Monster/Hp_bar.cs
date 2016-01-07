using UnityEngine;
using System.Collections;

public class Hp_bar : MonoBehaviour {

	Mesh thismesh;
	Vector2[] originUV = new Vector2[4];
	Transform mytransform;
	//Renderer myrenderer;
	Transform parentmon;
	float _amount = 0;
	Vector2 amountU;
	Vector2 amuontV;
	float posY = 0;
	int oldstatus = 0;
	
	void Awake () 
	{
		mytransform = transform;
		thismesh = GetComponent<MeshFilter>().mesh ;
		originUV = thismesh.uv;
		//myrenderer = renderer;
		//myrenderer.enabled = false;
		amuontV = Vector2.up *0.25f;
	}
	
	public void Damaged(int _maxhp, int _hp , Transform _parent , float _height ,int _status)
	{
		//myrenderer.enabled = true;
		parentmon = _parent;
		if (_maxhp != 0)
		{
			_amount = (1-(float)_hp/(float)_maxhp)*0.5f;
			
			amountU = Vector2.right * _amount;
			
			if (_status == -1)
			{
				_status = oldstatus;
			}
			thismesh.uv = new Vector2[]
			{
				originUV[0] + amountU +amuontV*_status, originUV[1] + amountU +amuontV*_status, 
				originUV[2] + amountU +amuontV*_status, originUV[3] + amountU+amuontV*_status,
			};
		}
		posY = _height;
		oldstatus = _status;
	}
	
	public void FreeSelect()
	{
		mytransform.position = Vector3.one*4;
		parentmon = null;
		//myrenderer.enabled = false;
	}
	
	void Update()
	{
		if (parentmon != null)
			mytransform.position = parentmon.position + new Vector3(0,posY,-0.02f);
	}

}
