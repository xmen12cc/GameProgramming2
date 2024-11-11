using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "Check Health Threshold", story: "CustomCondition", category: "Conditions", id: "7a8f572fbca0c564fe55d0db86e12a1b")]
public partial class CheckHealthThresholdCondition : Condition
{
    [SerializeField]
    private float healthThreshold = 50f;

    [SerializeField]
    private float currentHealth;

    public override bool IsTrue()
    {
        return currentHealth <= healthThreshold;
    }

    public override void OnStart()
    {
        Debug.Log("Condition started: Checking health threshold.");
    }

    public override void OnEnd()
    {
        Debug.Log("Condition ended.");
    }
}
