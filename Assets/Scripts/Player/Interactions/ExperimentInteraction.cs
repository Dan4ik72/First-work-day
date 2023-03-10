using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperimentInteraction : Interactable
{
    [SerializeField] private Player _player;

    public override void OnInteract()
    {
        Debug.Log("Boom!");
        _player.GetComponent<Recorder>().StopRecording();
    }
}
