using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AnimalMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    protected bool isAtDestinaytion{
        get{return agent.remainingDistance <= agent.stoppingDistance;}
    }
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isAtDestinaytion)
        {
            SetDestination();
        }
    }

    protected void SetDestination()
    {
        NavMeshManager navMeshManager = new NavMeshManager();
        Vector3 randomOnNavMesh = navMeshManager.FindRandomOnNavMesh();
        agent.SetDestination(randomOnNavMesh);
    }
}
