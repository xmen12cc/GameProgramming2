using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestState : State
{
    public RestState(GuardAgent agent) : base(agent) { }

    public override void Enter(){
        Debug.Log("Resting at HQ");
        guardAgent.StartResting();
    }

    public override void Execute(){
        if (guardAgent.HealthRecovered() && guardAgent.NoEnemiesNearby())
        {
            guardAgent.ChangeState(new PatrolState(guardAgent));
        }
    }

    public override void Exit(){
        Debug.Log("Exiting Rest State");
    }
}
