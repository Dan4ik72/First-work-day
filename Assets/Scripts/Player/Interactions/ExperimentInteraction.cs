using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ExperimentInteraction : Interactable
{
    [SerializeField] private Player _player;
    [SerializeField] private ParticleSystem _explosion;

    public UnityAction Explosion;

    public override void OnInteract()
    {
        Debug.Log("Boom!");
        _explosion.Play();
        _player.GetComponent<Recorder>().StopRecording();
        Explosion?.Invoke();
    }
}
