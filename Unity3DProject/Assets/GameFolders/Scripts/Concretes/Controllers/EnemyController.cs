using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyController : MonoBehaviour, IEntityController
{
    [SerializeField] Transform playerPreFab;

    IMover mover;
    IHealth health;

    CharacterAnimation characterAnimation;
    NavMeshAgent navMeshAgent;

    private void Awake()
    {
        mover = new MoveWithNavMesh(this);
        characterAnimation = new CharacterAnimation(this);
        navMeshAgent = GetComponent<NavMeshAgent>();
        health = GetComponent<IHealth>();

    }

    private void Update()
    {
        if (health.IsDead) return;

        mover.MoveAction(playerPreFab.transform.position, 10f);
    }

    public void LateUpdate()
    {
        if (health.IsDead) return;

        characterAnimation.MoveAnimation(navMeshAgent.velocity.magnitude);
    }

}
