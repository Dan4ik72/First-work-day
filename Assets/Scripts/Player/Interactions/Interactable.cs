using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public bool IsAvailable { get; protected set; } = true;

    public abstract void OnInteract();
}
