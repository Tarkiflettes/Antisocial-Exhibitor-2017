using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route3 : Route
{
    private void Start()
    {
        pathPoints = new GameObject[12];
        pathPoints[0] = GameObject.Find("PathPoints/PathPoint (18)").gameObject;
        pathPoints[1] = GameObject.Find("PathPoints/PathPoint (17)").gameObject;
        pathPoints[2] = GameObject.Find("PathPoints/PathPoint (13)").gameObject;
        pathPoints[3] = GameObject.Find("PathPoints/PathPoint (14)").gameObject;
        pathPoints[4] = GameObject.Find("PathPoints/PathPoint (15)").gameObject;
        pathPoints[5] = GameObject.Find("PathPoints/PathPoint (16)").gameObject;
        pathPoints[6] = GameObject.Find("PathPoints/PathPoint (15)").gameObject;
        pathPoints[7] = GameObject.Find("PathPoints/PathPoint (11)").gameObject;
        pathPoints[8] = GameObject.Find("PathPoints/PathPoint (10)").gameObject;
        pathPoints[9] = GameObject.Find("PathPoints/PathPoint (9)").gameObject;
        pathPoints[10] = GameObject.Find("PathPoints/PathPoint (7)").gameObject;
        pathPoints[11] = GameObject.Find("PathPoints/PathPoint (8)").gameObject;
    }
}
