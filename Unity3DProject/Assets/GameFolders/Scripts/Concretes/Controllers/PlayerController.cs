using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IEntityController
{
    [Header("Movement Informations")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float turnSpeed = 10f;
    [SerializeField] Transform turnTransform;
    [SerializeField] Transform neckTransform;

    // [SerializeField] WeaponController weaponController;

    [Header("Uis")]
    [SerializeField] GameObject gameOverPanel;

    IInputReader input;  
    IMover mover;
    IHealth health;
    IRotator neckRotator;
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
        neckRotator = new NeckRotator(neckTransform);

        inventory = GetComponent<InventoryController>();
    }

    void OnEnable()
    {
        health.OnDead += () =>
        {
            animation.DeadAnimation("death");
            gameOverPanel.SetActive(true);
        };

        EnemyManager.Instance.Targets.Add(this.transform);
    }

    void OnDisable()
    {
        EnemyManager.Instance.Targets.Remove(this.transform);
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

        neckRotator.RotationAction(rotation.y * -1f, turnSpeed);
    }
}
