using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField] private string _interactionDescription;
    [SerializeField] private Sprite _interactionIcon;

    public bool IsAvailable { get; protected set; } = true;

    public string InteractionDescription => _interactionDescription;
    public Sprite InteractionIcon => _interactionIcon;

    public abstract void OnInteract(InteractionCatcher interactionCatcher);

    public virtual void ResetByDefault()
    {
        IsAvailable = true;
    }

    public void DisableQuest()
    {
        IsAvailable = false;
    }
}
