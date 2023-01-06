using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorY : IRotator
{
    Transform transform;

    float tilt;

    public RotatorY(PlayerController playerController)
    {
        transform = playerController.TurnTransform;
    }

    public void RotationAction(float direction, float turnSpeed)
    {
        direction *= turnSpeed * Time.deltaTime;
        tilt = Mathf.Clamp(tilt - direction, -30f, 30f);
        transform.localRotation = Quaternion.Euler(tilt, 0f, 0f);
    }
}
