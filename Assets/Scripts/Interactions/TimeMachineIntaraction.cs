using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeMachineIntaraction : Interactable
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Player _player;

    public override void OnInteract()
    {
        Debug.Log("Time Travel");
        _player.GetComponent<Recorder>().StartCorutineReplay();

        int random = Random.Range(0, _spawnPoints.Length);

        _player.transform.position = _spawnPoints[random].position;
        _player.transform.rotation = _spawnPoints[random].rotation;
    }
}
