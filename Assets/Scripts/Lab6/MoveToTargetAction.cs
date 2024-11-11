using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Move to Target", story: "CustomAction", category: "Actions", id: "d6c59e8a73f93bada15c65e82ac3270b")]
public partial class MoveToTargetAction : Action
{
    [SerializeField]
    private GameObject target;

    [SerializeField]
    private GameObject actor; 

    [SerializeField]
    private float speed = 5f; 

    protected override Status OnStart()
    {
        Debug.Log("Action started: Moving towards the target.");
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (target == null || actor == null)
        {
            Debug.LogWarning("Target or Actor not assigned.");
            return Status.Failure;
        }

        actor.transform.position = Vector3.MoveTowards(
            actor.transform.position,
            target.transform.position,
            speed * Time.deltaTime
        );

        if (Vector3.Distance(actor.transform.position, target.transform.position) < 0.1f)
        {
            return Status.Success;
        }

        return Status.Running;
    }

    protected override void OnEnd()
    {
        Debug.Log("Action ended.");
    }
}
