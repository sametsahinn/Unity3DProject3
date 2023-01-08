using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyController : IEntityController
{
    IMover Mover { get; }
    InventoryController Inventory { get; }
    CharacterAnimation Animation { get; }
    public Dead Dead { get; }
    Transform Target { get; set; }
    float Magnitude { get; }
    void FindNearestTarget();
}
