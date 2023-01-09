using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeckRotator : IRotator
{
    float speed = 10f;
    Transform transform;
    float tilt;

    public NeckRotator(Transform transform)
    {
        this.transform = transform;
    }

    public void RotationAction(float direction, float speed)
    {
        direction *= speed * Time.deltaTime;
        tilt = Mathf.Clamp(tilt - direction, -30f, 30f);

        transform.Rotate(new Vector3(0f, 0f, tilt));
    }
}
