using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogues", menuName = "Dialogues/Create new dialogue")]
public class DialogueInfo : ScriptableObject
{
    [SerializeField] private List<DialogueLine> _dialogueLines;

    public IReadOnlyList<DialogueLine> DialogueLines => _dialogueLines;
}
