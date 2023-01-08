using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IHealth
{
    [SerializeField] HealthScriptableObject healthInfo;

    int currentHealth;

    public event System.Action<int, int> OnTakeHit;
    public event System.Action OnDead;

    public bool IsDead => currentHealth <= 0;

    private void Awake()
    {
        currentHealth = healthInfo.MaxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (IsDead) return;

        currentHealth -= damage;

        OnTakeHit?.Invoke(currentHealth, healthInfo.MaxHealth);

        if (IsDead) OnDead?.Invoke();
    }
}
