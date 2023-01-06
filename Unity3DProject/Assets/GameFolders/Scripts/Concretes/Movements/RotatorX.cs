using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorX : IRotator
{
    PlayerController playerController;

    float turnSpeed;

    public RotatorX(PlayerController playerController)
    {
        this.playerController = playerController;
    }

    public void RotationAction(float direction, float turnSpeed)
    {
        this.playerController.transform.Rotate(Vector3.up * direction * Time.deltaTime * turnSpeed);
    }
}
