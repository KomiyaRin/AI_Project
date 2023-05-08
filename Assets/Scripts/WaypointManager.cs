using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointManager : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject chaseTarget;
    public bool isOnPatrol;
    public bool isOnChase;

    [SerializeField] private float chaseSpeed = 1f;
    [SerializeField] private float chaseRotationSpeed = 1f;
    private bool isChaseTargetActive;

    void Start()
    {
        isOnPatrol = true;
        isOnChase = false;
    }

    void LateUpdate()
    {
        if (Vector3.Distance(chaseTarget.transform.position, transform.position) >= 30f)
        {
            isOnPatrol = true;
            isOnChase = false;
            return;
        }
        if (Vector3.Distance(chaseTarget.transform.position, transform.position) <= 30f)
        {
            isOnChase = true;
            isOnPatrol = false;
            ChaseStart();
        }
    }

    void ChaseStart()
    {
        if (!isOnChase)
        {
            return;
        }

        agent.SetDestination(chaseTarget.transform.position);
        agent.speed = chaseSpeed;
        agent.angularSpeed = chaseRotationSpeed;
    }
}
