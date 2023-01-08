using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackRangeDisplay : MonoBehaviour
{
    [SerializeField] AttackScriptableObject attackScriptableObject;

    private void OnDrawGizmos()
    {
        OnDrawGizmosSelected();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, attackScriptableObject.FloatValue);

    }
}
