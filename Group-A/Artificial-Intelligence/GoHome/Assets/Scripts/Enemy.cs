using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public enum State
    {
        Patrol,
        Seek
    }

    public State currentState;
    public Transform waypointParent;
    public float moveSpeed = 2f;

    private Transform[] waypoints;
    private int currentIndex = 1;
    private NavMeshAgent agent;
    private Transform target;

    // Use this for initialization
    void Start()
    {
        // Get the children from WaypointParent
        waypoints = waypointParent.GetComponentsInChildren<Transform>();

        // Get the AI component
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check the current state of the Enemy
        switch (currentState)
        {
            case State.Patrol:
                Patrol();
                break;
            case State.Seek:
                Seek();
                break;
            default:
                break;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Set target to the thing that we hit
        target = other.transform;
        // Switch state over to Seek
        currentState = State.Seek;
    }

    void OnTriggerExit(Collider other)
    {
        // Switch state back over to Patrol
        currentState = State.Patrol;
    }
    
    // Switching Waypoints
    void Patrol()
    {
        // Get the current waypoint
        Transform point = waypoints[currentIndex];

        // Get distance to waypoint
        float distance = Vector3.Distance(transform.position, point.position);
        
        // If distance is less than stopping distance
        if (distance < agent.stoppingDistance)
        {
            // Move to next waypoint
            currentIndex++;
            // If currentIndex >= waypoints.Length
            if (currentIndex >= waypoints.Length)
            {
                // Set currentIndex to 1
                currentIndex = 1;
            }
        }
        
        // Get enemy to follow waypoint
        agent.SetDestination(point.position);
    }

    void Seek()
    {
        // Get enemy to follow target
        agent.SetDestination(target.position);
    }

    void OnDrawGizmosSelected()
    {
        // If waypoints array is not null and waypoints is not empty
        if (waypoints != null && waypoints.Length > 0)
        {
            // Get current waypoint
            Transform point = waypoints[currentIndex];
            // Draw line from position to waypoint
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, point.position);
        }
    }
}
