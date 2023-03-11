using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueHandler : MonoBehaviour
{
    public event UnityAction DialogueEnded;

    [SerializeField] private DialogueRenderer _dialogueRenderer;
    [SerializeField] private Movement _movement;

    public DialogueInfo _currentDialogueInfo { get; private set; }

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

        _currentDialogueInfo = dialogueInfo;
    }

    private void OnDialogueEnded()
    {
        DialogueEnded?.Invoke();

        _currentDialogueInfo = null;

        _movement.enabled = true;
    }
}
