using System.Collections;
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
    private float _startVolume;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _reactor.Explosion += StartChangeMusic;
    }

    private void OnDisable()
    {
        _reactor.Explosion -= StartChangeMusic;
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

    private void StartChangeMusic()
    {
        //_currentAudioClip = _stealthMusicClip;
        StartCoroutine(ChangeMusic());
    }

    private IEnumerator ChangeMusic()
    {
        _startVolume = _audioSource.volume;

        while(_audioSource.volume > 0)
        {
            _audioSource.volume = Mathf.Lerp(_audioSource.volume, -0.5f, Time.deltaTime);
            yield return null;
        }
        _audioSource.Stop();
        _currentAudioClip = _stealthMusicClip;
        PlayMusic();

        while(_audioSource.volume < _startVolume - 0.05f)
        {
            _audioSource.volume = Mathf.Lerp(_audioSource.volume, _startVolume, Time.deltaTime);
            yield return null;
        }
    }
}