using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float patrolSpeed = 5f;
    public float turnSpeed = 5;
    public GameObject[] patrolPoints;
    public float changeTargetDistance = 1f;
    int currentTarget;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (MoveToTarget())
        {
            currentTarget = GetNextTarget();
        }
        LookAtTarget2(patrolPoints[currentTarget].GetComponent<Transform>().position);
    }
    private bool MoveToTarget()
    {
        Vector3 distanceVector = patrolPoints[currentTarget].GetComponent<Transform>().position - transform.position;
        if (distanceVector.magnitude < changeTargetDistance)
        {
            return true;
        }
        Vector3 velocityVector = distanceVector.normalized;
        transform.position += velocityVector * patrolSpeed * Time.deltaTime;
        return false;
    }
    private int GetNextTarget()
    {
        currentTarget++;
        if (currentTarget >= patrolPoints.Length)
        {
            currentTarget = 0;
        }
        return currentTarget;
    }
    private void LookAtTarget2(Vector2 targetPosition)
    {
        Vector2 direction = (Vector2)transform.position - targetPosition;
        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion toRotation = Quaternion.AngleAxis(targetAngle - 90, Vector3.forward);
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, turnSpeed * Time.deltaTime);
    }
    void LookAtTarget(Vector2 targetPosition)
    {
        Vector2 direction = targetPosition - (Vector2)transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion toRotation = Quaternion.AngleAxis(angle -90, Vector3.forward);
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, turnSpeed * Time.deltaTime);
    }
}
