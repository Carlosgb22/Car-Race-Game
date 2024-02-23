using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointNode : MonoBehaviour
{
    public float maxSpeed = 0;
    public float minDistanceToReachWaypoint = 5;
    public WayPointNode[] nextWaypointNode;
}
