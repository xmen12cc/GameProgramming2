using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeToHQState : State
{
    public FleeToHQState(GuardAgent agent) : base(agent) { }

    public override void Enter(){
        Debug.Log("Fleeing to HQ");
        guardAgent.SetDestination(guardAgent.hq.position);
    }

    public override void Execute(){
        if (guardAgent.ReachedHQ())
        {
            guardAgent.ChangeState(new RestState(guardAgent));
        }
    }

    public override void Exit(){
        Debug.Log("Exiting FleeToHQ State");
    }
}
