using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractionCatcher : MonoBehaviour
{
    public event UnityAction<Interactable> InteractableEntered;
    public event UnityAction<Interactable> Interacted;
    public event UnityAction<Interactable> InteractableExited;

    private Interactable _currentInteractable;

    public Interactable CurrentInteractable => _currentInteractable;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Interactable interactable))
        {
            Debug.Log("entered");

            TryToSetInteraction(interactable);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent(out Interactable interactable))
        {
            Debug.Log("exited");

            TryToRemoveInteraction(interactable);
        }
    }

    public void OnInteract()
    {
        _currentInteractable.OnInteract();
        Interacted?.Invoke(_currentInteractable);
        _currentInteractable = null;
    }

    private void TryToSetInteraction(Interactable interactable)
    {
        if (interactable.IsAvailable == false)
            return;

        _currentInteractable = _currentInteractable == null ? interactable : _currentInteractable;

        InteractableEntered?.Invoke(_currentInteractable);
    }

    private void TryToRemoveInteraction(Interactable interactable)
    {
        if (interactable != _currentInteractable)
            return;

        InteractableExited?.Invoke(_currentInteractable);

        _currentInteractable = null;
    }
}
