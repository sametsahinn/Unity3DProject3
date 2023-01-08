using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHealth : MonoBehaviour
{
    Image healthImage;

    void Awake()
    {
        healthImage = GetComponent<Image>();
    }

    void OnEnable()
    {
        Health health = GetComponentInParent<Health>();
        health.OnTakeHit += HandleTakeHit;
    }

    void HandleTakeHit(int currentHealth, int maxHealth)
    {
        healthImage.fillAmount = Convert.ToSingle(currentHealth) / Convert.ToSingle(maxHealth);
    }
}
