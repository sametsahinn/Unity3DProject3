using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyController : MonoBehaviour, IEntityController
{
    IMover mover;
    IHealth health;

    CharacterAnimation characterAnimation;
    NavMeshAgent navMeshAgent;
    InventoryController inventory;
    Transform target;

   public bool CanAttack =>
          Vector3.Distance(target.position, this.transform.position) <= navMeshAgent.stoppingDistance &&
          navMeshAgent.velocity == Vector3.zero;

    private void Awake()
    {
        mover = new MoveWithNavMesh(this);
        characterAnimation = new CharacterAnimation(this);
        navMeshAgent = GetComponent<NavMeshAgent>();
        health = GetComponent<IHealth>();
        inventory = GetComponent<InventoryController>();
    }
    private void Start()
    {
        target = FindObjectOfType<PlayerController>().transform;
    }

    private void Update()
    {
        if (health.IsDead) return;

        mover.MoveAction(target.position, 10f);
    }

    private void FixedUpdate()
    {
        if (CanAttack)
        {
            inventory.CurrentWeapon.Attack();
        }
    }

    public void LateUpdate()
    {
        if (health.IsDead) return;

        characterAnimation.MoveAnimation(navMeshAgent.velocity.magnitude);
        characterAnimation.AttackAnimation(CanAttack);
    }

    public void FindNearestTarget()
    {
        /*
        Transform nearest = EnemyManager.Instance.Targets[0];

        foreach (Transform target in EnemyManager.Instance.Targets)
        {
            float nearestValue = Vector3.Distance(nearest.position, this.transform.position);
            float newValue = Vector3.Distance(target.position, transform.position);

            if (newValue < nearestValue)
            {
                nearest = target;
            }
        }

        Target = nearest;*/
    }
}
