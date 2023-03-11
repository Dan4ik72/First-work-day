using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class PickUpNippersInteraction : Interactable
{
    [SerializeField] private Vector3 _positionOffset = new Vector3(0, 1, 0);

    public override void OnInteract(InteractionCatcher interactionCatcher)
    {
        transform.position = interactionCatcher.gameObject.transform.position + _positionOffset;
        transform.parent = interactionCatcher.gameObject.transform;
    }
}
