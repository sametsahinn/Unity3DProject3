using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttackType : IAttackType
{
    AttackScriptableObject attackScriptableObject;
    Camera camera;

    public RangeAttackType(Transform transform, AttackScriptableObject attackScriptableObject)
    {
        camera = transform.GetComponent<Camera>();
        this.attackScriptableObject = attackScriptableObject;
    }

    public void ActionAttack()
    {
        Ray ray = camera.ViewportPointToRay(Vector3.one / 2f);
        
        if (Physics.Raycast(ray, out RaycastHit hit, attackScriptableObject.FloatValue, attackScriptableObject.LayerMask))
        {
            // Debug.Log(hit.collider.name);

            if (hit.collider.TryGetComponent(out IHealth health))
            {
                health.TakeDamage(attackScriptableObject.Damage);
            }
        }
    }
}
