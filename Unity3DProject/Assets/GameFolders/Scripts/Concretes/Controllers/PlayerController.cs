using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Informations")]
    [SerializeField] float moveSpeed = 10f;

    IInputReader input;
    IMover mover;

    Vector3 direction;

    private void Awake()
    {
        input = GetComponent<IInputReader>();
        mover = new MoveWithCharacterController(this);
    }

    private void Update()
    {
        direction = input.Direction;
    }

    private void FixedUpdate()
    {
        mover.MoveAction(direction, moveSpeed);
    }
}
