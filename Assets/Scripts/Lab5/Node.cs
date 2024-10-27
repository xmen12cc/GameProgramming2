using Unity.Netcode;
using UnityEngine;

public class Node : INetworkSerializable
{
    public bool isWalkable;
    public Vector3 worldPosition;
    public int gridX;
    public int gridY;

    public int gCost;
    public int hCost;
    public Node parent;

    public Node(bool _isWalkable, Vector3 _worldPos, int _gridX, int _gridY)
    {
        isWalkable = _isWalkable;
        worldPosition = _worldPos;
        gridX = _gridX;
        gridY = _gridY;
    }

    public int fCost => gCost + hCost;

    public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
    {
        serializer.SerializeValue(ref isWalkable);
        serializer.SerializeValue(ref worldPosition);
        serializer.SerializeValue(ref gridX);
        serializer.SerializeValue(ref gridY);
    }
}
