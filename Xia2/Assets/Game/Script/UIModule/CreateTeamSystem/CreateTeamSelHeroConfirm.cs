//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.34209
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------
using UnityEngine;
using System.Collections;

public class CreateTeamSelHeroConfirm : MonoBehaviour
{
	public CreateTeamSystemUIManager m_uiMng;

	void Start()
	{
	}

	void OnClick()
	{
		if (m_uiMng)
		{
			m_uiMng.SelectHeroConfirm();
		}
	}
}

