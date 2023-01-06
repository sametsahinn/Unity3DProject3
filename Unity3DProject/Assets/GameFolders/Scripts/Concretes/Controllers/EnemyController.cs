using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyController : MonoBehaviour, IEntityController
{
    [SerializeField] Transform playerPreFab;

    IMover mover;
    CharacterAnimation characterAnimation;
    NavMeshAgent navMeshAgent;

    private void Awake()
    {
        mover = new MoveWithNavMesh(this);
        characterAnimation = new CharacterAnimation(this);
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        mover.MoveAction(playerPreFab.transform.position, 10f);
    }

    public void LateUpdate()
    {

        characterAnimation.MoveAnimation(navMeshAgent.velocity.magnitude);
    }

}
