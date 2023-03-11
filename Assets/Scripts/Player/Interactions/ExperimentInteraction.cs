using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperimentInteraction : Interactable
{
    [SerializeField] private Player _player;

    public override void OnInteract(InteractionCatcher interactionCatcher)
    {
        Debug.Log("Boom!");
        _player.GetComponent<Recorder>().StopRecording();
    }
}
