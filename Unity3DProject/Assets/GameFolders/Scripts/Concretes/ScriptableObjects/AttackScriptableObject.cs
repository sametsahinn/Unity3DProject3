using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Attack Info", menuName = "Create Attack Information / Create New", order = 1)]
public class AttackScriptableObject : ScriptableObject
{
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

}

