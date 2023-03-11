using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TestInteraction : Interactable
{
    [SerializeField] private DialogueHandler _dialogueHandler;

    [SerializeField] private DialogueInfo _dialogueInfo;

    public override void OnInteract(InteractionCatcher interactionCatcher)
    {
        _dialogueHandler.StartDialogue(_dialogueInfo);
    }
}
