using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Pathfinding : NetworkBehaviour
{
    public Transform seeker, target;
    private Grid grid;

    void Start()
    {
        grid = GetComponent<Grid>();
        if (grid == null)
        {
            Debug.LogError("Grid component not found on this GameObject!");
        }
    }

    void Update()
    {
        if (seeker == null || target == null)
        {
            Debug.LogError("Seeker or Target is not assigned in the Inspector!");
            return;
        }
        FindPath(seeker.position, target.position);
    }

void FindPath(Vector3 startPos, Vector3 targetPos)
{
    Node startNode = grid.NodeFromWorldPoint(startPos);
    Node targetNode = grid.NodeFromWorldPoint(targetPos);

    if (startNode == null || targetNode == null)
    {
        Debug.LogError("Start or Target Node is null.");
        return;
    }

    List<Node> path = new List<Node>();

    var (positions, walkables) = ConvertPathToVectors(path);
    SendPathToClientRpc(positions.ToArray(), walkables.ToArray());
}



    private (List<Vector3>, List<bool>) ConvertPathToVectors(List<Node> path)
    {
        List<Vector3> positions = new List<Vector3>();
        List<bool> walkables = new List<bool>();

        foreach (var node in path)
        {
            positions.Add(node.worldPosition);
            walkables.Add(node.isWalkable);
        }

        return (positions, walkables);
    }

[ClientRpc]
private void SendPathToClientRpc(Vector3[] positions, bool[] walkables)
{

    List<Vector3> positionList = new List<Vector3>(positions);
    List<bool> walkableList = new List<bool>(walkables);


}

}
