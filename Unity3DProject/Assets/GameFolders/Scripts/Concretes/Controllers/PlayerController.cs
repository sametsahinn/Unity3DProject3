using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IEntityController
{
    [Header("Movement Informations")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float turnSpeed = 10f;
    [SerializeField] Transform turnTransform;
    // [SerializeField] WeaponController weaponController;

    [Header("Uis")]
    [SerializeField] GameObject _gameOverPanel;

    IInputReader input;  
    IMover mover;
    IHealth health;
    IRotator ribRotator;
    IRotator xRotator;
    IRotator yRotator;

    CharacterAnimation animation;
    InventoryController inventory;

    Vector3 direction;
    Vector3 rotation;

    public Transform TurnTransform => turnTransform;

    private void Awake()
    {
        input = GetComponent<IInputReader>();
        mover = new MoveWithCharacterController(this);
        animation = new CharacterAnimation(this);
        health = GetComponent<IHealth>();

        xRotator = new RotatorX(this);
        yRotator = new RotatorY(this);

        inventory = GetComponent<InventoryController>();
    }

    void OnEnable()
    {
        health.OnDead += () =>
        {
            animation.DeadAnimation("death");
            // gameOverPanel.SetActive(true);
        };

        //EnemyManager.Instance.Targets.Add(this.transform);
    }

    private void Update()
    {
        if (health.IsDead) return;

        direction = input.Direction;
        rotation = input.Rotation;

        xRotator.RotationAction(rotation.x, turnSpeed);
        yRotator.RotationAction(rotation.y, turnSpeed);

        if (input.IsAttackButtonPress)
        {
            // weaponController.Attack();
            inventory.CurrentWeapon.Attack();
        }

        if (input.IsInventoryButtonPressed)
        {
            inventory.ChangeWeapon();
        }
    }

    private void FixedUpdate()
    {
        if (health.IsDead) return;

        mover.MoveAction(direction, moveSpeed);        
    }

    public void LateUpdate()
    {

        if (health.IsDead) return;

        animation.MoveAnimation(direction.magnitude);
        animation.AttackAnimation(input.IsAttackButtonPress);
    }
}
