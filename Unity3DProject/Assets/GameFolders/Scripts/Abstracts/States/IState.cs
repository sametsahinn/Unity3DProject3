using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    void Tick();
    void OnExit();
    void OnEnter();
    void TickFixed();
    void TickLate();
}