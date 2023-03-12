using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StepsHandlerAudio : MonoBehaviour
{
    [SerializeField] private Movement _movement;

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _stepSound;
    
    private float _minPitch = 0.9f;
    private float _maxPitch = 0.8f;

    private Coroutine _playStepsCoroutine;

    private bool _isStarted = false;

    private void Update()
    {
        if (_movement.IsMoving == true)
        {
            if (_isStarted == true)
            {
                if(_playStepsCoroutine != null)
                {
                    return;
                }
                
            }

            _isStarted = true;

            _playStepsCoroutine = StartCoroutine(PlayStepsDelayed());
        }
        else
        {
            _isStarted = false;

            if (_playStepsCoroutine == null)
                return;

            StopCoroutine(_playStepsCoroutine);
        }        
    }

    private void PlayRandomStepSound()
    {
        _audioSource.pitch = GetRandomPitch();

        _audioSource.PlayOneShot(_stepSound);
    }

    private float GetRandomPitch()
    {
        return Random.Range(_minPitch, _maxPitch);
    }

    private IEnumerator PlayStepsDelayed()
    {
        yield return new WaitForSecondsRealtime(0.6f);

        PlayRandomStepSound();

        _playStepsCoroutine = null;
    }
}
