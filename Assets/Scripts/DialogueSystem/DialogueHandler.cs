using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHandler : MonoBehaviour
{
    [SerializeField] private DialogueRenderer _dialogueRenderer;
    [SerializeField] private Movement _movement;

    private void OnEnable()
    {
        _dialogueRenderer.DialogueEnded += OnDialogueEnded;
    }

    private void OnDisable()
    {
        _dialogueRenderer.DialogueEnded -= OnDialogueEnded;
    }

    public void StartDialogue(DialogueInfo dialogueInfo)
    {
        _movement.enabled = false;

        _dialogueRenderer.gameObject.SetActive(true);
        _dialogueRenderer.StartDialogue(dialogueInfo);
    }

    private void OnDialogueEnded()
    {
        _movement.enabled = true;
    }
}
