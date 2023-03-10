using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInteraction : Interactable
{
    public override void OnInteract()
    {
        Debug.Log("Interacted with " + name);
    }
}
