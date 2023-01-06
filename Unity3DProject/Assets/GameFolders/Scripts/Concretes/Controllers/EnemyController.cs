using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IEntityController
{
    [SerializeField] Transform playerPreFab;

    IMover mover;

    private void Awake()
    {
        mover = new MoveWithNavMesh(this);
    }

    private void Update()
    {
        mover.MoveAction(playerPreFab.transform.position, 10f);
    }

}
