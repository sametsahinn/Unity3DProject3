using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] WeaponController[] weapons;

    Animator animator;

    public WeaponController CurrentWeapon { get; private set; }

    int index = 0;

    void Awake()
    {
        weapons = GetComponentsInChildren<WeaponController>();

        foreach (WeaponController weapon in weapons)
        {
            weapon.gameObject.SetActive(false);
        }

        animator = GetComponentInChildren<Animator>();
    }

    void Start()
    {
        CurrentWeapon = weapons[index];
        CurrentWeapon.gameObject.SetActive(true);
    }

    public void ChangeWeapon()
    {
        index++;

        if (index >= weapons.Length)
        {
            index = 0;
        }

        CurrentWeapon = weapons[index];

        foreach (WeaponController weapon in weapons)
        {
            if (CurrentWeapon == weapon)
            {
                weapon.gameObject.SetActive(true);
                animator.runtimeAnimatorController = CurrentWeapon.AnimatorOverride;
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
        }
    }
}
