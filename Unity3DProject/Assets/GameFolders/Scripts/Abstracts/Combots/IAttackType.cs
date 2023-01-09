using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackType
{
    void ActionAttack();
    public AttackScriptableObject AttackInfo { get; }
}
