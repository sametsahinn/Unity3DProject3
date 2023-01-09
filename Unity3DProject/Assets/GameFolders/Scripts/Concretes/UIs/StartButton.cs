using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MyButton
{
    protected override void HandleOnButtonClicked()
    {
        GameManager.Instance.LoadLevel("Game");
    }
}