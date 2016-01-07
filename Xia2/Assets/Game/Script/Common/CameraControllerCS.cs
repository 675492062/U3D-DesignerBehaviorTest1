/*
*	这个脚本控制的基础上，跟随玩家移动摄像机。
*
*/

using UnityEngine;
using System.Collections;

public class CameraControllerCS : MonoBehaviour {
	
	private Transform tViewRoot;	

	private float fCamShakeImpulse = 0.0f;
	public float fCamShakeNum = 1.0f;

	public bool isCamShake = false;
	private bool isCamShakeEnd = false;

	void Start()
	{
		tViewRoot = this.transform;
		fCamShakeImpulse = 0.0f;
	}


	void FixedUpdate()
	{
		CameraMain();//camera transitions
	}

	private void CameraMain()
	{
		if (!isCamShakeEnd) 
		{
			if(isCamShake)
			{
				isCamShakeEnd = true;
				fCamShakeImpulse = fCamShakeNum;
			}
		}

		if(fCamShakeImpulse>0.0f)
			shakeCamera();
	}


	public void setCameraShakeImpulseValue(int iShakeValue)
	{
		if(iShakeValue==1)
			fCamShakeImpulse = 1.0f;
		else if(iShakeValue==2)
			fCamShakeImpulse = 2.0f;
		else if(iShakeValue==3)
			fCamShakeImpulse = 1.3f;
		else if(iShakeValue==4)
			fCamShakeImpulse = 1.5f;
		else if(iShakeValue==5)
			fCamShakeImpulse = 1.3f;
	}

	private void shakeCamera()
	{
		tViewRoot.position += new Vector3(0, Random.Range(-fCamShakeImpulse,fCamShakeImpulse),
			Random.Range(-fCamShakeImpulse,fCamShakeImpulse));
		
		fCamShakeImpulse-=Time.deltaTime * fCamShakeImpulse*4.0f;
		if(fCamShakeImpulse<0.01f)
			fCamShakeImpulse = 0.0f;
	}

}
