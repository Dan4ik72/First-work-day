using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeMachineIntaraction : Interactable
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Player _player;

    public override void OnInteract()
    {
        Debug.Log("Time Travel");
        _player.GetComponent<Recorder>().StartCorutineReplay();

        _player.transform.position = _spawnPoint.position;
        _player.transform.rotation = _spawnPoint.rotation;
    }
}
