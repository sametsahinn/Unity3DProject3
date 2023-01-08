using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState
{
    IEnemyController enemyController;

    public AttackState(IEnemyController enemyController)
    {
        this.enemyController = enemyController;
    }

    public void OnEnter()
    {
        Debug.Log($"{nameof(AttackState)} {nameof(OnEnter)}");
    }

    public void OnExit()
    {
        Debug.Log($"{nameof(AttackState)} {nameof(OnExit)}");

        enemyController.Animation.AttackAnimation(false);
    }

    public void Tick()
    {
        enemyController.transform.LookAt(enemyController.Target);
        enemyController.transform.eulerAngles = new Vector3(0f, enemyController.transform.eulerAngles.y, 0f);
    }

    public void TickFixed()
    {
        enemyController.Inventory.CurrentWeapon.Attack();
        enemyController.FindNearestTarget();
    }

    public void TickLate()
    {
        enemyController.Animation.AttackAnimation(true);
    }
}
