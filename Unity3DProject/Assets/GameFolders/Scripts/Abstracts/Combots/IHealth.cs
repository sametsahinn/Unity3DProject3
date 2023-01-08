using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealth
{
    bool IsDead { get; }
    void TakeDamage(int damage);
    event System.Action OnDead;
}
