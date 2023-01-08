using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyController : MonoBehaviour, IEnemyController
{
    public IMover Mover { get; private set; }
    IHealth health;

    StateMachine stateMachine;
    public CharacterAnimation Animation { get; private set; }
    NavMeshAgent navMeshAgent;
    public InventoryController Inventory { get; private set; }
    public Transform Target { get; set; }
    public Dead Dead { get; private set; }
    public float Magnitude => navMeshAgent.velocity.magnitude;


    public bool CanAttack =>
          Vector3.Distance(Target.position, this.transform.position) <= navMeshAgent.stoppingDistance &&
          navMeshAgent.velocity == Vector3.zero;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        stateMachine = new StateMachine();

        Mover = new MoveWithNavMesh(this);
        Animation = new CharacterAnimation(this);
        health = GetComponent<IHealth>();
        Inventory = GetComponent<InventoryController>();
        Dead = GetComponent<Dead>();
    }
    private void Start()
    {
        Target = FindObjectOfType<PlayerController>().transform;

        ChaseState chaseState = new ChaseState(this);
        AttackState attackState = new AttackState(this);
        DeadState deadState = new DeadState(this);

        stateMachine.AddState(chaseState, attackState, () => CanAttack);
        stateMachine.AddState(attackState, chaseState, () => !CanAttack);
        stateMachine.AddAnyState(deadState, () => health.IsDead);

        stateMachine.SetState(chaseState);
    }

    private void Update()
    {
        stateMachine.Tick();
    }

    private void FixedUpdate()
    {
        stateMachine.TickFixed();
    }

    public void LateUpdate()
    {
        stateMachine.TickLate();
    }

    void OnDestroy()
    {
        EnemyManager.Instance.RemoveEnemyController(this);
    }

    public void FindNearestTarget()
    {        
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

        Target = nearest;
    }
}
