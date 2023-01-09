using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttackType : MonoBehaviour, IAttackType
{
    [SerializeField] AttackScriptableObject attackScriptableObject;
    [SerializeField] Camera camera;
    [SerializeField] BulletFxController bulletFx;
    [SerializeField] Transform bulletPoint;

    public AttackScriptableObject AttackInfo => attackScriptableObject;

    /*
    public RangeAttackType(Transform transform, AttackScriptableObject attackScriptableObject)
    {
        camera = transform.GetComponent<Camera>();
        this.attackScriptableObject = attackScriptableObject;
    }*/

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

        var bullet = Instantiate(bulletFx, bulletPoint.position, bulletPoint.rotation);
        bullet.SetDirection(ray.direction);

        SoundManager.Instance.RangeAttackSound(attackScriptableObject.Clip, camera.transform.position);
    }
}
