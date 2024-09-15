using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLines : MonoBehaviour
{
    public Vector3[] points; // Inspector will allow you to set these

    void Start()
    {
        if (points.Length < 2)
        {
            Debug.LogError("At least 2 points are needed to draw a line.");
            return;
        }
    }

    void Update()
    {
        for (int i = 0; i < points.Length - 1; i++)
        {
            Debug.DrawLine(points[i], points[i + 1], Color.red);
        }
    }
}
