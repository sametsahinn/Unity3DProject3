using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] bool canFire;

    // [SerializeField] Transform transform;
    // [SerializeField] AttackScriptableObject attackScriptableObject;

    IAttackType attackType;

    public AnimatorOverrideController AnimatorOverride => attackType.AttackInfo.AnimatorOverride;
    float currentTime;    

    private void Awake()
    {
        // attackType = new RangeAttackType(this.transform, attackScriptableObject);
        attackType = GetComponent<IAttackType>();
        // attackType = attackScriptableObject.GetAttackType(transform);
    }

    private void Update()
    {
        currentTime += Time.deltaTime;

        canFire = currentTime > attackType.AttackInfo.AttackMaxDelay;
    }

    public void Attack()
    {
        if (!canFire) return;       

        attackType.ActionAttack();

        currentTime = 0f;

    }

}
