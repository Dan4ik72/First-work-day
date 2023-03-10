using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InteractionCatcher))]
public class InteractionHandler : MonoBehaviour
{
    private InteractionCatcher _interactionCatcher;

    private void Awake()
    {
        _interactionCatcher = GetComponent<InteractionCatcher>();
    }

    private void Update()
    {
        if (_interactionCatcher.CurrentInteractable == null)
            return;

        if (Input.GetKeyDown(KeyCode.E))
            Interact();
    }

    private void Interact()
    {
        _interactionCatcher.OnInteract();
    }
}

