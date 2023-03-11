using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperimentInteraction : Interactable
{
    [SerializeField] private Player _player;
    [SerializeField] private ParticleSystem _explosion;

    public override void OnInteract(InteractionCatcher interactionCatcher)
    {
        Debug.Log("Boom!");
        _explosion.Play();
        _player.GetComponent<Recorder>().StopRecording();
    }
}
