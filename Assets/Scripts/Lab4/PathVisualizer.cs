using System.Collections.Generic;
using UnityEngine;

public class PathVisualizer : MonoBehaviour
{
    public Grid grid;

    void OnDrawGizmos()
    {
        if (grid != null)
        {
            Debug.Log("Grid = null !");
            foreach (Node n in grid.grid)
            {
                Gizmos.color = (n.isWalkable) ? Color.white : Color.red;
                Gizmos.DrawCube(n.worldPosition, Vector3.one * (grid.nodeDiameter - 0.1f));
            }

            if (grid.path != null)
            {
                foreach (Node n in grid.path)
                {
                    Gizmos.color = Color.magenta;
                    Gizmos.DrawCube(n.worldPosition, Vector3.one * (grid.nodeDiameter - 0.1f));
                }
            }
        }
    }
}
