using System.Collections.Generic;
using UnityEngine;

public class GOAPAgent : MonoBehaviour
{
    private List<GOAPAction> availableActions = new List<GOAPAction>();
    private GOAPAction currentAction;

    void Start()
    {
        availableActions.AddRange(GetComponents<GOAPAction>());
        AssignNewAction();
    }

    void Update()
    {
        if (currentAction != null)
        {
            if (!currentAction.PerformAction())
            {
                return;
            }

            currentAction = null;
            AssignNewAction();
        }
    }

    private void AssignNewAction()
    {
        foreach (var action in availableActions)
        {
            if (action.Preconditions())
            {
                currentAction = action;
                if (currentAction is WanderAction wander)
                {
                    wander.SetTarget(GetRandomPosition());
                }
                Debug.Log($"Performing: {currentAction.ActionName}");
                return;
            }
        }
    }

    private Vector3 GetRandomPosition()
    {
        return new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5));
    }
}
