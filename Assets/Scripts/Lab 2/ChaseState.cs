using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    public ChaseState(GuardAgent agent) : base(agent) { }

    public override void Enter(){
        Debug.Log("Entering Chase State");
        guardAgent.StartChasingPlayer();
    }

    public override void Execute(){
        if (guardAgent.DistanceToPlayer() < 1)
        {
            guardAgent.ChangeState(new AttackState(guardAgent));
        }
        else if (guardAgent.DistanceToPlayer() > 5)
        {
            guardAgent.ChangeState(new PatrolState(guardAgent));
        }
        else if (guardAgent.HealthLow() && guardAgent.EnemiesDetected())
        {
            guardAgent.ChangeState(new FleeToHQState(guardAgent));
        }
    }

    public override void Exit(){
        Debug.Log("Exiting Chase State");
    }
}

