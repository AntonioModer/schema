using UnityEngine;

namespace Schema.Builtin.Nodes
{
    [DarkIcon("Nodes/d_Math"), LightIcon("Nodes/Math"), Category("Math"), Description("Get the arccosine of a value")]
    public class Acos : Action
    {
        [Tooltip("Input for the arccosine function")]
        public BlackboardEntrySelector<float> value;

        [Tooltip("Selector to store the arccosine in"), WriteOnly] 
        public BlackboardEntrySelector<float> result;

        [Tooltip("Return degrees instead of radians")]
        public bool degrees;

        public override NodeStatus Tick(object nodeMemory, SchemaAgent agent)
        {
            result.value = degrees ? Mathf.Acos(value.value) * Mathf.Rad2Deg : Mathf.Acos(value.value);

            return NodeStatus.Success;
        }
    }
}