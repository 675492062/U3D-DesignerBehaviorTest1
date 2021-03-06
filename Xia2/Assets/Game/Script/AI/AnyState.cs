using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;
using System.Collections;
using FSMTestingProject;
[TaskDescription("任意状态，直接返回成功，在selector子分支有可能全部返回失败的时候挂载这个状态放在最后就可以")]
[TaskCategory("AI")]
class AnyState : BaseState
{
	public AnyState(string name)
		: base(name)
	{
		
	}
	
	public override void OnAwake()
	{
	}
	
	public override void OnStart()
	{
	}
	
	public override TaskStatus OnUpdate()
	{
		return TaskStatus.Success;
	}
}