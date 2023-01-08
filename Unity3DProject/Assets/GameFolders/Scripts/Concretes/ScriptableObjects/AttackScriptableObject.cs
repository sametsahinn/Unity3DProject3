using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum AttackTypeEnum : byte
{
    Range,
    Melee
}

[CreateAssetMenu(fileName = "Attack Info", menuName = "Combat/Attack Information / Create New", order = 1)]
public class AttackScriptableObject : ScriptableObject
{
    [SerializeField] AttackTypeEnum attackType;
    [SerializeField] int damage = 10;
    [SerializeField] float floatValue = 1f;
    [SerializeField] LayerMask layerMask;
    [SerializeField] float attackMaxDelay = 0.25f;
    [SerializeField] AnimatorOverrideController animatorOverride;

    public float FloatValue => floatValue;
    public int Damage => damage;
    public LayerMask LayerMask => layerMask;
    public float AttackMaxDelay => attackMaxDelay;
    public AnimatorOverrideController AnimatorOverride => animatorOverride;

    public IAttackType GetAttackType(Transform transform)
    {
        if (attackType == AttackTypeEnum.Range)
        {
            return new RangeAttackType(transform, this);
        }
        else
        {
            return new MeleeAttackType(transform, this);
        }
    }
}

