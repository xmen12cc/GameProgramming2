using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : State
{
    public PatrolState(GuardAgent agent) : base(agent) { }

    public override void Enter(){
        Debug.Log("Entering Patrol State");
        guardAgent.StartPatrolling();
    }

    public override void Execute(){
        if (guardAgent.PlayerInFront() && guardAgent.DistanceToPlayer() < 3)
        {
            guardAgent.ChangeState(new ChaseState(guardAgent));
        }
        else if (guardAgent.HQUnderAttack())
        {
            guardAgent.ChangeState(new AttackState(guardAgent));
        }
    }

    public override void Exit(){
        Debug.Log("Exiting Patrol State");
    }
}

