using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ExperimentInteraction : Interactable
{
    [SerializeField] private Player _player;
    [SerializeField] private ParticleSystem _explosion;
    [SerializeField] private AudioSource _audioSource;

    public UnityAction Explosion;

    public override void OnInteract(InteractionCatcher interactionCatcher)
    {
        Debug.Log("Boom!");
        _explosion.Play();
        _player.GetComponent<Recorder>().StopRecording();
        DisableQuest();
        _audioSource.Play();
        Explosion?.Invoke();
    }
}
