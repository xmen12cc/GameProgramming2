using System;
using System.Collections.Generic;
using UnityEngine;

public class BetterFSM : MonoBehaviour
{
    private Dictionary<string, Action> states;
    private string currentState;

    private void Start()
    {
        states = new Dictionary<string, Action>
        {
            { "Patrol", Patrol },
            { "Chase", Chase },
            { "Attack", Attack },
            { "FleeToHQ", FleeToHQ }
        };

        currentState = "Patrol";
    }

    private void Update()
    {
        if (states.ContainsKey(currentState))
        {
            states[currentState].Invoke();
        }

        HandleTransitions();
    }

    private void Patrol()
    {
        Debug.Log("Patrolling...");
    }

    private void Chase()
    {
        Debug.Log("Chasing...");
    }

    private void Attack()
    {
        Debug.Log("Attacking...");
    }

    private void FleeToHQ()
    {
        Debug.Log("Fleeing to HQ...");
    }

    private void HandleTransitions()
    {
        if (IsEnemyInSight()) 
        {
            ChangeState("Chase");
        }
        else if (IsEnemyInRange()) 
        {
            ChangeState("Attack");
        }
        else if (IsHealthLow()) 
        {
            ChangeState("FleeToHQ");
        }
        else
        {
            ChangeState("Patrol");
        }
    }

    public void ChangeState(string newState)
    {
        if (states.ContainsKey(newState))
        {
            Debug.Log("Changing state to: " + newState);
            currentState = newState;
        }
        else
        {
            Debug.LogError("State not found: " + newState);
        }
    }

    private bool IsEnemyInSight() { return false; }
    private bool IsEnemyInRange() { return false; }
    private bool IsHealthLow() { return false; }
}
