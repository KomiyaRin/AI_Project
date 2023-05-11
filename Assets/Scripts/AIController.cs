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
    public float patrolSpeed = 2f;
    public float chaseSpeed = 4f;

    private Animator anim;
    public GameObject DeadPanel;

    private void Start()
    {
        isOnPatrol = true;
        isOnChase = false;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
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
        agent.speed = patrolSpeed;
        anim.SetBool("isIdle", false);
        anim.SetBool("isWalk", true);
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
            anim.SetBool("isWalk", true);
            anim.SetBool("isChase", false);
            return;
        }

        agent.SetDestination(playerChaseTarget.transform.position);
        agent.speed = chaseSpeed;
        anim.SetBool("isWalk", false);
        anim.SetBool("isChase", true);
    }

    public void stopChaseOnLook()
    {
        anim.SetBool("isIdle", true);
        anim.SetBool("isWalk", false);
        anim.SetBool("isChase", false);
    }
}
