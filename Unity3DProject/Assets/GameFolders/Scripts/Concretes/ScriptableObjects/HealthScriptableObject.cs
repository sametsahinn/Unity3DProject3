using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Health Info", menuName = "Combat/Health Information / Create New", order = 1)]

public class HealthScriptableObject : ScriptableObject
{
    [SerializeField] int maxHealth = 100;

    public int MaxHealth => maxHealth;
}
