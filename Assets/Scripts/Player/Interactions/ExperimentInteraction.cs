using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ExperimentInteraction : Interactable
{
    [SerializeField] private Player _player;
    [SerializeField] private ParticleSystem _explosion;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _boomSound;

    public UnityAction Explosion;

    public override void OnInteract(InteractionCatcher interactionCatcher)
    {
        Debug.Log("Boom!");
        _explosion.Play();
        _player.GetComponent<Recorder>().StopRecording();
        DisableQuest();
        StartCoroutine(PlaySound());
        Explosion?.Invoke();
    }

    private IEnumerator PlaySound()
    {
        _audioSource.PlayOneShot(_boomSound);
        yield return new WaitForSeconds(8f);
        _audioSource.Play();
    }

    public void StopSound()
    {
        _audioSource.Stop();
    }
}
