using UnityEngine;
using Schema.Runtime;

[DarkIcon("c_MeshFilter")]
[LightIcon("c_MeshFilter")]
public class GetBounds : Action
{
    [Tooltip("When toggled, will get the bounds of the current SchemaAgent")]
    public bool useSelf;
    [Tooltip("The GameObject to get the bounds from")]
    public BlackboardGameObject gameObject;
    [Tooltip("Blackboard key to store the boudns of the object in")]
    public BlackboardVector3 boundsKey;
    public override NodeStatus Tick(object nodeMemory, SchemaAgent agent)
    {
        GameObject obj = useSelf ? agent.gameObject : agent.blackboard.GetValue<GameObject>(gameObject);

        if (obj == null || boundsKey == null)
            return NodeStatus.Failure;

        Mesh mesh = obj.GetComponent<MeshFilter>()?.mesh;

        if (mesh == null)
            return NodeStatus.Failure;

        Vector3 objectSize = Vector3.Scale(obj.transform.localScale, mesh.bounds.size);

        agent.blackboard.SetValue<Vector3>(boundsKey, objectSize);

        return NodeStatus.Success;
    }
}