using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class MoveWithNavMesh : IMover
{
    public float Velocity => throw new System.NotImplementedException();

    NavMeshAgent navMeshAgent;

    float moveSpeed;

    public MoveWithNavMesh(IEntityController entityController)
    {
        navMeshAgent = entityController.transform.GetComponent<NavMeshAgent>();
    }

    public void MoveAction(Vector3 direction, float moveSpeed)
    {
        navMeshAgent.SetDestination(direction);
    }

}
