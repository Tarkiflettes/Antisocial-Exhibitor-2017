using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route : MonoBehaviour {

    protected GameObject[] pathPoints;

    public Route()
    {
        pathPoints = new GameObject[1];
    }

    public GameObject GetPathPoint(int i)
    {
        return pathPoints[i];
    }

    public int GetNbPoints()
    {
        return pathPoints.Length;
    }
}
