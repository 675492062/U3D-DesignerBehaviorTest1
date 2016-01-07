using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace BehaviorDesigner.Runtime.Tasks.Basic.SharedVariables
{
    [TaskCategory("Basic/SharedVariable")]
    [TaskDescription("Sets the SharedFloat variable to the specified object. Returns Success.")]
    public class SetSharedFloat : Action
    {
        [Tooltip("The value to set the SharedFloat to")]
        public SharedFloat targetValue;
        [Tooltip("The SharedFloat to set")]
        public SharedFloat targetVariable;

        public override TaskStatus OnUpdate()
        {
            targetVariable.Value = targetValue.Value;

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            if (targetValue != null) {
                targetValue.Value = 0;
            }
            if (targetVariable != null) {
                targetVariable.Value = 0;
            }
        }
    }
}