using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithCharacterController : IMover
{
    CharacterController characterController;

    float moveSpeed;

    public float Velocity => characterController.velocity.magnitude;

    public MoveWithCharacterController(IEntityController entityController)
    {
        characterController = entityController.transform.GetComponent<CharacterController>();
    }

    public void MoveAction(Vector3 direction, float moveSpeed)
    {
        if (direction == Vector3.zero) return;

        Vector3 v3 = characterController.transform.TransformDirection(direction);
        Vector3 vMoment = v3 * Time.deltaTime * moveSpeed;

        characterController.Move(vMoment);

    }
}
