using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardAgent : MonoBehaviour
{
    private State currentState;

    public Transform player;
    public Transform hq;
    public float health = 100f;
    public float maxHealth = 100f;

    private void Start(){
        ChangeState(new PatrolState(this));
    }

    private void Update(){
        currentState.Execute();
    }

    public void ChangeState(State newState){
        if (currentState != null)
            currentState.Exit();

        currentState = newState;
        currentState.Enter();
    }

    public void StartPatrolling(){
    }

    public void StartChasingPlayer(){
    }

    public bool PlayerInFront(){
        return true;
    }

    public float DistanceToPlayer(){
        return Vector3.Distance(transform.position, player.position);
    }

    public bool HQUnderAttack(){
        return false;
    }

    public bool HealthLow(){
        return health < 20;
    }

    public bool EnemiesDetected(){
        return false;
    }

    public void StartAttackingPlayer(){
    }

    public bool PlayerDefeated(){
        return false;
    }

    public void SetDestination(Vector3 destination){
    }

    public bool ReachedHQ(){
        return Vector3.Distance(transform.position, hq.position) < 1f;
    }

    public void StartResting(){
    }

    public bool HealthRecovered(){
        return health >= maxHealth;
    }

    public bool NoEnemiesNearby(){
        return true;
    }
}

