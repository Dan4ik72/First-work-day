using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    [SerializeField] private List<Transition> _transitions;

    public IReadOnlyList<Transition> Transitions => _transitions;

    public virtual void Enter()
    {
        enabled = true;

        foreach (var transition in _transitions)
        {
            transition.ResetByDefault();
            transition.enabled = true;
        }
    }

    public virtual void Exit()
    {
        foreach (var transition in _transitions)
            transition.enabled = false;

        enabled = false;
    }
}
