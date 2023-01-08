using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackType : IAttackType
{
    [SerializeField] Transform _transformObject;
    [SerializeField] AttackScriptableObject _attackSo;

    public AttackScriptableObject AttackInfo => _attackSo;

    public void ActionAttack()
    {
        Vector3 attackPoint = _transformObject.position;
        Collider[] colliders = Physics.OverlapSphere(attackPoint, _attackSo.FloatValue, _attackSo.LayerMask);

        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent(out IHealth health))
            {
                health.TakeDamage(_attackSo.Damage);
            }
        }
    }
}
