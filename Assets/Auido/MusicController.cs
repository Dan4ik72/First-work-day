using System.Collections;
using System.Collections.Generic;
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

        StartCoroutine(PlayMusicDelayed());
    }

    private void Update()
    {
        if(_audioSource.isPlaying == false)
        {
            _audioSource.PlayOneShot(_introMusic);
        }
    }

    private IEnumerator PlayMusicDelayed()
    {
        yield return new WaitForSecondsRealtime(3f);

        _audioSource.PlayOneShot(_introMusic);
    }
}
