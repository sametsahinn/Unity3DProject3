using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation
{
    Animator animator;

    public CharacterAnimation(IEntityController entity)
    {
        this.animator = entity.transform.GetComponentInChildren<Animator>();
    }


    public void MoveAnimation(float moveSpeed)
    {
        if (animator.GetFloat("MoveSpeed") == moveSpeed) return;

        animator.SetFloat("MoveSpeed", moveSpeed, 0.1f, Time.deltaTime);
    }

    public void AttackAnimation(bool canAttack)
    {
        animator.SetBool("IsAttack", canAttack);
    }

    public void DeadAnimation(string parameterName)
    {
        animator.SetTrigger(parameterName);
    }
}
