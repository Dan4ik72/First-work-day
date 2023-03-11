using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private State _enterState;

    private State _currentState;

    public State CurrentState => _currentState;

    private void Start()
    {
        Reset(_enterState);
    }

    private void Update()
    {
        if (_currentState == null)
            return;

        var nextState = TryGetStateToTransit();

        if (nextState != null)
            SwitchState(nextState);
    }

    private void Reset(State enterState)
    {
        SwitchState(enterState);
    }

    private State TryGetStateToTransit()
    {
        foreach (var transition in _currentState.Transitions)
        {
            if (transition.IsAbleToTransit == true)
            {
                return transition.TargetState;
            }
        }

        return null;
    }

    private void SwitchState(State nextState)
    {
        if (nextState == null)
            return;

        _currentState?.Exit();

        _currentState = nextState;
        _currentState.Enter();
    }
}
