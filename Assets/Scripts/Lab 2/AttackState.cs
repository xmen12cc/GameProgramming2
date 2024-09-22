using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public AttackState(GuardAgent agent) : base(agent) { }

    public override void Enter(){
        Debug.Log("Entering Attack State");
        guardAgent.StartAttackingPlayer();
    }

    public override void Execute(){
        if (guardAgent.DistanceToPlayer() > 1)
        {
            guardAgent.ChangeState(new ChaseState(guardAgent));
        }
        else if (guardAgent.PlayerDefeated())
        {
            guardAgent.ChangeState(new PatrolState(guardAgent));
        }
    }

    public override void Exit(){
        Debug.Log("Exiting Attack State");
    }
}
