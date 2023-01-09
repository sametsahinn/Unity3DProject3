using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : IState
{
    float speed = 10f;
    IEnemyController enemyController;

    public ChaseState(IEnemyController enemyController)
    {
        this.enemyController = enemyController;
    }

    public void OnEnter()
    {
        Debug.Log($"{nameof(ChaseState)} {nameof(OnEnter)}");
    }

    public void OnExit()
    {
        Debug.Log($"{nameof(ChaseState)} {nameof(OnExit)}");
        enemyController.Mover.MoveAction(enemyController.transform.position, 0f);
    }

    public void Tick()
    {
        enemyController.Mover.MoveAction(enemyController.Target.position, speed);
    }

    public void TickFixed()
    {
        enemyController.FindNearestTarget();
    }

    public void TickLate()
    {
        enemyController.Animation.MoveAnimation(enemyController.Magnitude);
    }
}
