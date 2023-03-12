using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimeMachineIntaraction : Interactable
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Player _player;
    [SerializeField] private NPC _npc;
    [SerializeField] private ParticleSystem _effect;
    [SerializeField] private AudioSource _audioSource;

    [HideInInspector] public UnityAction Restarted;

    public override void OnInteract(InteractionCatcher interactionCatcher)
    {
        Debug.Log("Time Travel");
        _player.GetComponent<Recorder>().StartCorutineReplay();
        _npc.PlayRecord();
        _npc.transform.position = new Vector3(-132.6f, 1.17f, -187.7f);

        int random = Random.Range(0, _spawnPoints.Length);

        _player.transform.position = _spawnPoints[random].position;
        _player.transform.rotation = _spawnPoints[random].rotation;
        Game.Instance.RestartQuests();
        _effect.Stop();
        _audioSource.Play();
        Restarted?.Invoke();
    }

    public void RestartReplays()
    {
        _npc.RestartReplay();
        _player.GetComponent<Recorder>().RestartReplay();

        int random = Random.Range(0, _spawnPoints.Length);

        _player.transform.position = _spawnPoints[random].position;
        _player.transform.rotation = _spawnPoints[random].rotation;
        _audioSource.Play();
        Restarted?.Invoke();
    }

    public void TurnOn()
    {
        _effect.Play();
    }
}
