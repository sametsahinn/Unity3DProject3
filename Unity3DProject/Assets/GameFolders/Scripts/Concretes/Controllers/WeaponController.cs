using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] bool canFire;
    [SerializeField] float attackMaxDelay = 0.25f;
    [SerializeField] float distance = 100f;
    [SerializeField] Camera camera;
    [SerializeField] LayerMask layerMask;

    float currentTime;

    private void Update()
    {
        currentTime += Time.deltaTime;

        canFire = currentTime > attackMaxDelay;
    }

    public void Attack()
    {
        if (!canFire) return;

        Ray ray = camera.ViewportPointToRay(Vector3.one / 2f);

        if (Physics.Raycast(ray, out RaycastHit hit, distance, layerMask))
        {
            Debug.Log(hit.collider.gameObject.name);
        }

        currentTime = 0f;

    }

}
