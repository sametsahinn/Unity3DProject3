using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackType : IAttackType
{
    // [SerializeField] Transform _transformObject;
    // [SerializeField] AttackScriptableObject _attackSo;

    // public AttackScriptableObject AttackInfo => _attackSo;

    AttackScriptableObject attackScriptableObject;
    Transform transform;

    public MeleeAttackType(Transform transform, AttackScriptableObject attackScriptableObject)
    {
        this.transform = transform;
        this.attackScriptableObject = attackScriptableObject;
    }

    public void ActionAttack()
    {
        Vector3 attackPoint = transform.position;
        Collider[] colliders = Physics.OverlapSphere(attackPoint, attackScriptableObject.FloatValue, attackScriptableObject.LayerMask);

        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent(out IHealth health))
            {
                health.TakeDamage(attackScriptableObject.Damage);
            }
        }
    }
}
