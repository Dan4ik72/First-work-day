using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PutOnBoxInteracrtion : Interactable
{
    public event UnityAction BoxPuttedOn;

    public override void OnInteract(InteractionCatcher interactionCatcher)
    {
        if (interactionCatcher.gameObject.GetComponentInChildren<PickUpBlockInteraction>() != null && IsAvailable == true)
        {   
            var block = interactionCatcher.gameObject.GetComponentInChildren<PickUpBlockInteraction>();

            block.transform.parent = transform;
            Destroy(block.gameObject);

            BoxPuttedOn?.Invoke();
        }
    }
}
