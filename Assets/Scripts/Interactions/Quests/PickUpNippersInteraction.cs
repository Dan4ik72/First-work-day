using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class PickUpNippersInteraction : Interactable
{
    [SerializeField] private GameObject _grabPoint;

    public override void OnInteract(InteractionCatcher interactionCatcher)
    {
        transform.position = _grabPoint.transform.position;
        transform.parent = interactionCatcher.gameObject.transform;
    }
}
