using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IEntityController
{
    [Header("Movement Informations")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float turnSpeed = 10f;
    [SerializeField] Transform turnTransform;
    [SerializeField] WeaponController weaponController;


    IInputReader input;
    IMover mover;
    IRotator xRotator;
    IRotator yRotator;

    CharacterAnimation animation;

    Vector3 direction;

    public Transform TurnTransform => turnTransform;

    private void Awake()
    {
        input = GetComponent<IInputReader>();
        mover = new MoveWithCharacterController(this);
        animation = new CharacterAnimation(this);

        xRotator = new RotatorX(this);
        yRotator = new RotatorY(this);

    }

    private void Update()
    {
        direction = input.Direction;

        xRotator.RotationAction(input.Rotation.x, turnSpeed);
        yRotator.RotationAction(input.Rotation.y, turnSpeed);

        if (input.IsAttackButtonPress)
        {
            weaponController.Attack();
        }
    }

    private void FixedUpdate()
    {
        mover.MoveAction(direction, moveSpeed);        
    }

    public void LateUpdate()
    {

        animation.MoveAnimation(direction.magnitude);
    }
}
