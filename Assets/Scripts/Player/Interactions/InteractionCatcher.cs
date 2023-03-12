using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractionCatcher : MonoBehaviour
{
    [SerializeField] private InteractionRenderer _interactionRenderer;

    private Interactable _currentInteractable;

    public Interactable CurrentInteractable => _currentInteractable;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Interactable interactable))
        {
            if (interactable.IsAvailable == false)
                return;

            TryToSetInteraction(interactable);
        }        
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent(out Interactable interactable))
            TryToRemoveInteraction(interactable);        
    }

    public void OnInteract()
    {
        _currentInteractable.OnInteract(this);
        _interactionRenderer.DisableRender();
        _currentInteractable = null;
    }

    private void TryToSetInteraction(Interactable interactable)
    {
        if (interactable.IsAvailable == false)
            return;

        _currentInteractable = _currentInteractable == null ? interactable : _currentInteractable;

        _interactionRenderer.RenderInteraction(interactable.InteractionDescription, interactable.InteractionIcon);
    }

    private void TryToRemoveInteraction(Interactable interactable)
    {
        if (interactable != _currentInteractable)
            return;

        _interactionRenderer.DisableRender();
        
        _currentInteractable = null;
    }
}
