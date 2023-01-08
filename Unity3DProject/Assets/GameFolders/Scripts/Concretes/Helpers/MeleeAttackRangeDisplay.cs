using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackRangeDisplay : MonoBehaviour
{
    [SerializeField] float radius = 1f;

    private void OnDrawGizmos()
    {
        OnDrawGizmosSelected();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, radius);
    }
}
