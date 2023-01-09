using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnButton : MyButton
{
    protected override void HandleOnButtonClicked()
    {
        GameManager.Instance.ReturnMenu();
    }
}
