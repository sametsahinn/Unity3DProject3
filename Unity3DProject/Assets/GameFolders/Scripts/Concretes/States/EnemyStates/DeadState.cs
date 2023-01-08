using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : IState
{
    IEnemyController enemyController;
    float maxTime = 5f;
    float currentTime = 0f;

    public DeadState(IEnemyController enemyController)
    {
        this.enemyController = enemyController;
    }

    public void OnEnter()
    {
        Debug.Log($"{nameof(DeadState)} {nameof(OnEnter)}");

        enemyController.Dead.DeadAction();
        enemyController.Animation.DeadAnimation("dying");
        enemyController.transform.GetComponent<CapsuleCollider>().enabled = false;
    }

    public void OnExit()
    {
        Debug.Log($"{nameof(DeadState)} {nameof(OnExit)}");
    }

    public void Tick()
    {
        return;
    }

    public void TickFixed()
    {
        return;
    }

    public void TickLate()
    {
        return;
    }
}