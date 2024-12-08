using UnityEngine;

public abstract class GOAPAction : MonoBehaviour
{
    public string ActionName;
    public float Cost = 1f;
    public bool IsCompleted { get; protected set; }

    public abstract bool Preconditions();
    public abstract bool PerformAction();
    public abstract bool Effects();
}
