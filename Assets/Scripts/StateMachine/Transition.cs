using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] private State _targetState;

    public State TargetState => _targetState;
    public bool IsAbleToTransit { get; private set; }

    public void ResetByDefault()
    {
        IsAbleToTransit = false;
    }

    protected void SetTransitionCompleted()
    {
        IsAbleToTransit = true;
    }
}
