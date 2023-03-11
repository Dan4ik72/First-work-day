using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CuratorMoveState))]
public class CuratorDialogueState : MonoBehaviour
{
    [SerializeField] private DialogueHandler _dialogueHandler;
    [SerializeField] private List<DialogueInfo> _dialogueInfoSequence = new List<DialogueInfo>();

    private CuratorMoveState _moveState;

    private int _currentDialogueInfoIndex = -1;

    private void Awake()
    {
        _moveState = GetComponent<CuratorMoveState>();
    }

    private void OnEnable()
    {
        _moveState.enabled = false;
        _dialogueHandler.DialogueEnded += OnDialogueEnded;
    }

    private void OnDisable()
    {
        _dialogueHandler.DialogueEnded -= OnDialogueEnded;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (this.enabled == true)
        {
            if (other.gameObject.TryGetComponent(out Player player))
            {
                StartDialogue();
            }
        }
    }

    private void StartDialogue()
    {
        if (_currentDialogueInfoIndex + 1>= _dialogueInfoSequence.Count)
        {
            return;
        }

        _currentDialogueInfoIndex++;

        _dialogueHandler.StartDialogue(_dialogueInfoSequence[_currentDialogueInfoIndex]);
    }

    private void OnDialogueEnded()
    {
        if (_dialogueHandler._currentDialogueInfo == _dialogueInfoSequence[_currentDialogueInfoIndex])
        {            
            _moveState.enabled = true;
            _moveState.SetNextPath();
        }
    }
}
