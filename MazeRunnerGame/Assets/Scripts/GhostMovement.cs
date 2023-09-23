using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform target;
    [SerializeField] private float speed = 2f;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (target != null)
        {
            MoveToTarget();
        }
    }

    private void MoveToTarget()
    {
        agent.speed = speed;
        agent.SetDestination(target.position);
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
