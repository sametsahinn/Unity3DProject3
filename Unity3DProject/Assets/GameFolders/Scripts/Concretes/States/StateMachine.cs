using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    List<StateTransformer> stateTransformers = new List<StateTransformer>();
    List<StateTransformer> anyStateTransformer = new List<StateTransformer>();

    IState currentState;

    public void SetState(IState state)
    {
        if (currentState == state) return;

        currentState?.OnExit();

        currentState = state;

        currentState.OnEnter();
    }

    public void Tick()
    {
        StateTransformer stateTransformer = CheckForTransformer();

        if (stateTransformer != null) SetState(stateTransformer.To);

        currentState.Tick();
    }

    public void TickFixed()
    {
        currentState.TickFixed();
    }

    public void TickLate()
    {
        currentState.TickLate();
    }

    private StateTransformer CheckForTransformer()
    {
        foreach (StateTransformer stateTransformer in anyStateTransformer)
        {
            if (stateTransformer.Condition.Invoke()) return stateTransformer;
        }

        foreach (StateTransformer stateTransformer in stateTransformers)
        {
            if (stateTransformer.Condition.Invoke() && currentState == stateTransformer.From) return stateTransformer;
        }

        return null;
    }

    public void AddState(IState from, IState to, System.Func<bool> condition)
    {
        StateTransformer stateTransformer = new StateTransformer(from, to, condition);
        stateTransformers.Add(stateTransformer);
    }

    public void AddAnyState(IState to, System.Func<bool> condition)
    {
        StateTransformer stateTransformer = new StateTransformer(null, to, condition);
        anyStateTransformer.Add(stateTransformer);
    }
}
