﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route1 : Route
{
    private void Start()
    {
        pathPoints = new GameObject[17];
        pathPoints[0] = GameObject.Find("PathPoints/PathPoint (34)").gameObject;
        pathPoints[1] = GameObject.Find("PathPoints/PathPoint (5)").gameObject;
        pathPoints[2] = GameObject.Find("PathPoints/PathPoint (1)").gameObject;
        pathPoints[3] = GameObject.Find("PathPoints/PathPoint").gameObject;
        pathPoints[4] = GameObject.Find("PathPoints/PathPoint (2)").gameObject;
        pathPoints[5] = GameObject.Find("PathPoints/PathPoint (9)").gameObject;
        pathPoints[6] = GameObject.Find("PathPoints/PathPoint (10)").gameObject;
        pathPoints[7] = GameObject.Find("PathPoints/PathPoint (12)").gameObject;
        pathPoints[8] = GameObject.Find("PathPoints/PathPoint (20)").gameObject;
        pathPoints[9] = GameObject.Find("PathPoints/PathPoint (21)").gameObject;
        pathPoints[10] = GameObject.Find("PathPoints/PathPoint (22)").gameObject;
        pathPoints[11] = GameObject.Find("PathPoints/PathPoint (24)").gameObject;
        pathPoints[12] = GameObject.Find("PathPoints/PathPoint").gameObject;
        pathPoints[13] = GameObject.Find("PathPoints/PathPoint (3)").gameObject;
        pathPoints[14] = GameObject.Find("PathPoints/PathPoint (4)").gameObject;
        pathPoints[15] = GameObject.Find("PathPoints/PathPoint (7)").gameObject;
        pathPoints[16] = GameObject.Find("PathPoints/PathPoint (8)").gameObject;
    }
}