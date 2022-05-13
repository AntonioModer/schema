﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Schema;

[DarkIcon("c_Rigidbody")]
[LightIcon("c_Rigidbody")]
[Category("Rigidbody")]
[RequireAgentComponent(typeof(Rigidbody))]
public class AddForce : Action
{
    public ComponentSelector<Rigidbody> rigidbody;
    public BlackboardEntrySelector<Vector3> forceVector;
    public ForceMode forceMode;
    public override NodeStatus Tick(object nodeMemory, SchemaAgent agent)
    {
        Rigidbody r = agent.GetComponent(rigidbody);

        if (r != null)
        {
            r.AddForce(forceVector.value, forceMode);
            return NodeStatus.Success;
        }
        else
        {
            return NodeStatus.Failure;
        }
    }
}
