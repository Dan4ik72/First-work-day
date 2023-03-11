using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBlockInteraction : Interactable
{
    [SerializeField] private Vector3 _positionOffset;

    public override void OnInteract(InteractionCatcher interactionCatcher)
    {
        transform.position = interactionCatcher.gameObject.transform.position + _positionOffset;
        transform.parent = interactionCatcher.gameObject.transform;
    }
}
