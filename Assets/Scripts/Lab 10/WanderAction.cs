using UnityEngine;

public class WanderAction : GOAPAction
{
    private Vector3 targetPosition;

    void Start()
    {
        ActionName = "Wander";
    }

    public override bool Preconditions()
    {
        return true;  // Always available
    }

    public override bool PerformAction()
    {
        if (Vector3.Distance(transform.position, targetPosition) < 1f)
        {
            IsCompleted = true;
            return true;
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * 2f);
        return false;
    }

    public override bool Effects()
    {
        Debug.Log("Reached target!");
        return true;
    }

    public void SetTarget(Vector3 position)
    {
        targetPosition = position;
    }
}
