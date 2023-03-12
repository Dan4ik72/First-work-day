using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicController : MonoBehaviour
{
    [SerializeField] private AudioClip _introMusic;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _audioSource.PlayOneShot(_introMusic);
    }

    private void Update()
    {
        if(_audioSource.isPlaying == false)
        {
            _audioSource.PlayOneShot(_introMusic);
        }
    }
}
