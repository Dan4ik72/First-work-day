using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicController : MonoBehaviour
{
    [SerializeField] private TimeMachineIntaraction _timeMachine;
    [SerializeField] private Game _gameManager;
    [SerializeField] private ExperimentInteraction _reactor;

    [SerializeField] private AudioClip _introMusicClip;
    [SerializeField] private AudioClip _stealthMusicClip;

    private AudioSource _audioSource;

    private AudioClip _currentAudioClip;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _reactor.Explosion += ChangeMusic;
    }

    private void OnDisable()
    {
        _reactor.Explosion -= ChangeMusic;
    }

    private void Start()
    {
        _currentAudioClip = _introMusicClip;
    }

    private void Update()
    {
        PlayMusic();
    }

    private void PlayMusic()
    {
        if(_audioSource.isPlaying == false)
        {
            Debug.Log(_currentAudioClip);

            _audioSource.PlayOneShot(_currentAudioClip);
        }                
    }

    private void ChangeMusic()
    {
        _currentAudioClip = _stealthMusicClip;
    }
}