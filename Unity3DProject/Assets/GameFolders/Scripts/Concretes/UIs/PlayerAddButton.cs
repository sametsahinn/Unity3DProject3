using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAddButton : MyButton
{
    protected override void HandleOnButtonClicked()
    {
        GameManager.Instance.IncreasePlayerCount();
    }
}
