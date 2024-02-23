using System.Linq;
using UnityEngine;

public class CarAIHandler : MonoBehaviour
{
    public float carMaxSpeed = 20;
    public float maxSpeed = 20;
    Vector3 targetPosition = Vector3.zero;
    //Transform targetTransform = null;
    WayPointNode currentWaypoint = null;
    WayPointNode[] allWaypoints;
    TopDownCarController topDownCarController;
    void Awake()
    {
        topDownCarController = GetComponent<TopDownCarController>();
        allWaypoints = FindObjectsOfType<WayPointNode>();
    }
    void FixedUpdate()
    {
        Vector3 inputVector = Vector3.zero;
        FollowWaypoints();
        inputVector.x = TurnTowardTarget();
        inputVector.y = ApplyThrottleOrBrake(inputVector.x);
        topDownCarController.SetInputVector(inputVector);
    }
    void FollowWaypoints()
    {
        if (currentWaypoint == null)
        {
            currentWaypoint = FindClosestWaypoint();
        }
        if (currentWaypoint != null)
        {
            targetPosition = currentWaypoint.transform.position;
            float distanceToWaypoint = (targetPosition - transform.position).magnitude;
            if (distanceToWaypoint <= currentWaypoint.minDistanceToReachWaypoint)
            {
                currentWaypoint = currentWaypoint.nextWaypointNode[Random.Range(0, currentWaypoint.nextWaypointNode.Length)];
                if (currentWaypoint.maxSpeed > 0 && currentWaypoint.maxSpeed < carMaxSpeed)
                {
                    maxSpeed = currentWaypoint.maxSpeed;
                }
                else
                {
                    maxSpeed = carMaxSpeed;
                }
            }
        }
    }

    WayPointNode FindClosestWaypoint()
    {
        return allWaypoints
        .OrderBy(t => Vector3.Distance(transform.position, t.transform.position))
        .FirstOrDefault();
    }
    float TurnTowardTarget()
    {
        Vector2 vectorToTarget = targetPosition - transform.position;
        vectorToTarget.Normalize();
        float angleToTarget = Vector2.SignedAngle(transform.up, vectorToTarget);
        angleToTarget *= -1;
        float steerAmount = angleToTarget / 45.0f;
        steerAmount = Mathf.Clamp(steerAmount, -1.0f, 1.0f);
        return steerAmount;
    }
    private float ApplyThrottleOrBrake(float inputX)
    {
        if (topDownCarController.GetVelocityMagnitude() > maxSpeed)
        {
            return 0;
        }
        return 1.05f - Mathf.Abs(inputX) / 1.0f;
    }
    //bool IsCarInFrontOfAICar(out Vector3 position, out Vector3 otherCarRightVector)
    //{

    //}
}
