using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform[] waypoints;
    int waypointIndex;
    Vector3 target;
    public GameObject playerChaseTarget;
    public bool isOnPatrol;
    public bool isOnChase;

    private void Start()
    {
        isOnPatrol = true;
        isOnChase = false;
        agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, target) < 1)
        {
            isOnPatrol = true;
            isOnChase = false;
            IterateWaypointIndex();
            UpdateDestination();
            return;
        }

        FieldOfView FOV = FindObjectOfType<FieldOfView>();
        if (FOV.canSeePlayer == true)
        {
            isOnChase = true;
            isOnPatrol = false;
            ChasePlayer();
        }
        else if (FOV.canSeePlayer == false)
        {
            isOnChase =false;
            UpdateDestination();
            return;
        }
    }

    void UpdateDestination()
    {
        target = waypoints[waypointIndex].position;
        agent.SetDestination(target);
    }

    void IterateWaypointIndex()
    {
        waypointIndex++;
        if(waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
        }
    }

    void ChasePlayer()
    {
        if (!isOnChase)
        {
            return;
        }

        agent.SetDestination(playerChaseTarget.transform.position);
    }
}
