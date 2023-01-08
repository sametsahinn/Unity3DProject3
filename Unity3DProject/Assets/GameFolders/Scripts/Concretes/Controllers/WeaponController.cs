using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] bool canFire;
    [SerializeField] Transform transform;
    [SerializeField] AttackScriptableObject attackScriptableObject;
    public AnimatorOverrideController AnimatorOverride => attackScriptableObject.AnimatorOverride;

    float currentTime;

    IAttackType attackType;

    private void Awake()
    {
        attackType = new RangeAttackType(this.transform, attackScriptableObject);
    }

    private void Update()
    {
        currentTime += Time.deltaTime;

        canFire = currentTime > attackScriptableObject.AttackMaxDelay;
    }

    public void Attack()
    {
        if (!canFire) return;       

        attackType.ActionAttack();

        currentTime = 0f;

    }

}
