using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class InputReader : MonoBehaviour, IInputReader
{
    public Vector3 Direction { get; private set; }
    public Vector2 Rotation { get; private set; }
    public bool IsAttackButtonPress { get; private set; }
    public bool IsInventoryButtonPressed { get; private set; }

    int index;

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 oldDirection = context.ReadValue<Vector2>();
        Direction = new Vector3(oldDirection.x, 0, oldDirection.y);
    }

    public void OnRotator(InputAction.CallbackContext context)
    {        
        Rotation = context.ReadValue<Vector2>();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        IsAttackButtonPress = context.ReadValueAsButton();
    }

    public void OnInventoryPressed(InputAction.CallbackContext context)
    {
        if (IsInventoryButtonPressed && context.action.triggered) return;

        StartCoroutine(WaitOnFrameAsync());
    }

    IEnumerator WaitOnFrameAsync()
    {
        IsInventoryButtonPressed = true && index % 2 == 0;
        yield return new WaitForEndOfFrame();
        IsInventoryButtonPressed = false;

        index++;
    }
}
