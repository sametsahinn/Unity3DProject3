using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackType : MonoBehaviour, IAttackType
{
    [SerializeField] AttackScriptableObject attackScriptableObject;
    [SerializeField] Transform transform;

    public AttackScriptableObject AttackInfo => attackScriptableObject;

    /*
    public MeleeAttackType(Transform transform, AttackScriptableObject attackScriptableObject)
    {
        this.transform = transform;
        this.attackScriptableObject = attackScriptableObject;
    }*/

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

        SoundManager.Instance.MeleeAttackSound(attackScriptableObject.Clip, transform.position);
    }
}
