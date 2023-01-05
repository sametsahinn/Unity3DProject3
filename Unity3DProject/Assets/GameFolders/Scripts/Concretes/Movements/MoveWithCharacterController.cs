using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithCharacterController : IMover
{
    CharacterController characterController;

    float moveSpeed;

    public MoveWithCharacterController(PlayerController playerController)
    {
        characterController = playerController.GetComponent<CharacterController>();
    }

    public void MoveAction(Vector3 direction, float moveSpeed)
    {
        if (direction == Vector3.zero) return;

        Vector3 v3 = characterController.transform.TransformDirection(direction);
        Vector3 vMoment = v3 * Time.deltaTime * moveSpeed;

        characterController.Move(vMoment);

    }
}
